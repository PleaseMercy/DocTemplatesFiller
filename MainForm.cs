using System;
using System.Windows.Forms;

namespace DocTemplatesFiller
{
    public partial class MainForm : Form
    {
        Controller controller = new Controller();
        private string CurUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public MainForm()
        {
            controller.DataTransfer(CurUser,"",1);
            InitializeComponent();
        }

        private void filePicker_Click(object sender, EventArgs e)
        {
            controller.DataTransfer(CurUser, "Выбирает файл", 2);
            controller.WordGetStructure(this.dgvTemplates);            
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            controller.DataTransfer(CurUser, "Выбор директории для сохранения файла", 2);
            controller.WordFiller(this.dgvTemplates);
        }

        private void dgvTemplates_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvTemplates.Rows.Count > 0)
            { 
                saveBtn.Enabled = true;
            }
        }

        private void dgvTemplates_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvTemplates.Rows.Count == 0)
            {
                saveBtn.Enabled = false;
            }
        }

        private void mailSendBtn_Click(object sender, EventArgs e)
        {
            controller.DataTransfer(CurUser, "Открыл форму заполнения почты", 2);
            var MailInfoFiller = new MailInfoFiller();
            MailInfoFiller.Show();            
        }
    }
}
