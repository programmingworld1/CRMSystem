using System;
using crm_systeem.Models;
using crm_systeem.Database;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crm_systeem.Forms.Panels
{
    public partial class PasswordChange : UserControl
    {
        UserController UserDB = new UserController();
        User ActivePerson;
        public PasswordChange(User ActivePersons)
        {
            ActivePerson = ActivePersons;
            InitializeComponent();
        }
        private void buttonConfirmPasswordChange_Click(object sender, EventArgs e)
        {
            if (textBoxNewPassword.Text.Equals(textBoxNewPassword02.Text) && ActivePerson.password.Equals(textBoxOldPassword.Text))
            {
                User User = new User { id = ActivePerson.id, password = textBoxNewPassword.Text };
                bool Transaction = UserDB.ChangeUserPassword(User);
                if (Transaction == true)
                {
                    ActivePerson.password = textBoxNewPassword.Text;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wachtwoord veranderen is mislukt!");
                }
            }
            else
            {
                MessageBox.Show("Wachtwoord veranderen is mislukt!");
            }
        }
        private void buttonCancelPasswordChange_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
