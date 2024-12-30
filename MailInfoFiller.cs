using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocTemplatesFiller
{
    public partial class MailInfoFiller : Form
    {
        Controller controller = new Controller();
        public MailInfoFiller()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            controller.SendMessage(this.mailToTextBox, this.subjectTextBox, this.mailTextBox, this);
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
