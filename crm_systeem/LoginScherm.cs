using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using crm_systeem.Models;
using crm_systeem.Database;

namespace crm_systeem
{
    public partial class LoginScherm : Form
    {
        LoginController loginController;   
        public LoginScherm()
        {
            InitializeComponent();
            loginController = new LoginController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginGegevens login = new LoginGegevens() { gebruikersnaam = textBox1.Text, wachtwoord = textBox2.Text };
            if(loginController.controleerGegevens(login)== true)
            {
                HoofdPagina hoofdPagina = new HoofdPagina();
                hoofdPagina.ShowDialog();
            }
        }
    }
}
