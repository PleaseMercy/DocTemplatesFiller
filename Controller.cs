using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Word = Microsoft.Office.Interop.Word;
using System.Net.Mime;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;

namespace DocTemplatesFiller
{
    internal class Controller
    {
        private string CurUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        internal string filePath { get; set; }

        internal Controller() { }

        internal Controller (string filePath)
        {
            this.filePath = filePath;
        }      



        //Выбор шаблона, возвращает путь к шаблону
        internal string filePicker()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Documents";
                openFileDialog.Filter = @"Документ Word 97-2003 (*.doc)|*.doc|Документ Word (*.docx)|*.docx|Все файлы (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
                else 
                {
                    return null;
                }                
            }
            return filePath;
        }

        internal void WordGetStructure(DataGridView grid)
        {
            string FileName = filePicker();
            object rOnly = true;
            object MissingObj = System.Reflection.Missing.Value;

            if (FileName == null)
            {
                //Фиксируем отмену в БД
                return;
            }

            if (grid.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Форма для заполнения будет очищена, продолжить?", "Выберите действие", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    grid.Rows.Clear();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            Word.Application app = new Word.Application();
            Word.Document doc = null;
            Word.Range range = null;
            try
            {
                if (!File.Exists(FileName))
                {
                    MessageBox.Show("Исходный шаблон был перемещён или удалён." + System.Environment.NewLine + FileName, "ВНИМАНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                doc = app.Documents.Open(FileName, ref MissingObj, ref rOnly, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj);
                object StartPosition = 0;
                object EndPositiojn = doc.Characters.Count;
                range = doc.Range(ref StartPosition, ref EndPositiojn);

                // Получение основного текста со страниц 
                string MainText = (range == null || range.Text == null) ? null : range.Text;
                if (MainText != null)
                {
                    ICollection<string> matches =
                    Regex.Matches(MainText.Replace(Environment.NewLine, ""), @"\[([^]]*)\]")
                        .Cast<Match>()
                        .Select(x => x.Groups[1].Value)
                        .ToList();

                    foreach (string match in matches)
                    {
                        grid.Rows.Add(match);
                    }
                    if (matches.Count == 0) 
                    {                        
                        MessageBox.Show("В шаблоне не найдено ни одного элемента для заполнения", "Предупреждение", MessageBoxButtons.OK);
                    }
                }
            }
            finally
            {
                app.Quit();
            }
}

        internal void WordFiller(DataGridView grid)
        {
            string pathToSave = saveFilePath();
            string FileName = filePath;
            object MissingObj = System.Reflection.Missing.Value;

            Word.Application app = new Word.Application();
            Word.Document doc = null;
            Word.Range range = null;
            try
            {
                if ( !File.Exists(FileName) )
                {
                    MessageBox.Show("Исходный шаблон был перемещён или удалён." + System.Environment.NewLine + FileName, "ВНИМАНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
                doc = app.Documents.Open(FileName, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj, ref MissingObj);
                object StartPosition = 0;
                object EndPositiojn = doc.Characters.Count;
                range = doc.Range(ref StartPosition, ref EndPositiojn);

                foreach (string str in DataCollection(grid))
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = '[' + str.Split(';')[0] + ']';
                    find.Replacement.Text = str.Split(';')[1];

                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;

                    find.Execute(FindText: ref MissingObj,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: ref MissingObj,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: ref MissingObj, Replace: replace );
                }
                Object newFileName = Path.Combine(pathToSave, DateTime.Now.ToString("yyyyMMdd_HH_mm_") + Path.GetFileName(FileName));
                app.ActiveDocument.SaveAs2(newFileName);
                
                //Логгируем
                DataTransfer(CurUser
                            , "Сохранил себе документ " + "$"
                            + Path.GetFileName(FileName) + "#"
                            + string.Join("&",DataCollection(grid))
                            , 3);
            }
            finally
            {
                app.Quit();
            }
        }

        internal string[] DataCollection (DataGridView grid)
        {
            string[] collectedData = new string[grid.Rows.Count];
            for (int rowInc = 0; rowInc < grid.Rows.Count; rowInc++)
            {
                collectedData[rowInc] = (String)grid[0, rowInc].Value + ";" + (String)grid[1, rowInc].Value /*+ System.Environment.NewLine*/;
            }
            return collectedData;
        }

        internal void DataTransfer(string user, string inputData, int ActParam)
        {
            //Строку для подключения можно изменить в App.config
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["connectToLoggerDB"].ConnectionString;
            
            //Инициализируем пользователя
            if (ActParam == 1)
            {
                Console.WriteLine(Convert.ToChar(35));

                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();

                    using (SqlCommand query = new SqlCommand("", conn))
                    {
                        query.CommandText = "exec InsertData N'" + user + "',''," + ActParam + ";";
                        query.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
            //Логгирование
            //Форматы:
            //ActParam 2: действие_пользователя
            //ActParam 3: действие_пользователя$имя_файла#содержимое_полей_шаблона
            else
            {
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();

                    using (SqlCommand query = new SqlCommand("", conn))
                    {
                        query.CommandText = "exec InsertData N'" + user + "','" + inputData + "'," + ActParam + ";";
                        query.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
        }
        internal string saveFilePath()
        {
            FolderBrowserDialog saveFileDialog1 = new FolderBrowserDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog1.SelectedPath;
            }
            else
            {
                return "";
            }
        }

        internal void SendMessage(System.Windows.Forms.TextBox mailToTextBox, System.Windows.Forms.TextBox subjectTextBox, System.Windows.Forms.TextBox mailTextBox, MailInfoFiller FormSM)
        {
            string smtpServer = "smtp.mail.ru"; 
            int smtpPort = 587; 
            string smtpUsername = ConfigurationManager.AppSettings["mailAdress"];
            string smtpPassword = ConfigurationManager.AppSettings["mailPassword"];
            if (string.IsNullOrEmpty(mailToTextBox.Text))
            {
                MessageBox.Show("Адрес получателя не заполнен.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Создаем объект клиента SMTP
            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                // Настройки аутентификации
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(smtpUsername);
                    mailMessage.To.Add(mailToTextBox.Text);     // Адрес получателя
                    mailMessage.Subject = subjectTextBox.Text;  // Тема письма
                    mailMessage.Body = mailTextBox.Text;        // Текст письма

                    string filePathToSend = filePicker();
                    if (!File.Exists(filePathToSend) | filePathToSend is null)
                    {
                        if (!string.IsNullOrEmpty(filePathToSend)) 
                        {
                            MessageBox.Show("Исходный шаблон был перемещён или удалён." + System.Environment.NewLine + filePathToSend, "ВНИМАНИЕ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Console.WriteLine("Текущий фокус на файле: '" + filePathToSend + @"'");
                        return;
                    }
                    else 
                    { 
                        // Вложение файла
                        Attachment data = new Attachment(filePathToSend, MediaTypeNames.Application.Octet);
                        mailMessage.Attachments.Add(data);
                    }
                    try
                    {
                        // Отправляем сообщение
                        smtpClient.Send(mailMessage);
                        Console.WriteLine("Сообщение успешно отправлено.");
                        DataTransfer(CurUser
                            ,"Отправил сообщение на адрес " + mailToTextBox.Text + "$" 
                            + Path.GetFileName(filePathToSend) + "#"
                            + " "
                            , 3);
                        FormSM.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка отправки сообщения: {ex.Message}");
                    }
                }
            }
        }
    }
}
