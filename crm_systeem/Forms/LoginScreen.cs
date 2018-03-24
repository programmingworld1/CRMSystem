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
using crm_systeem.Forms;

namespace crm_systeem
{
    public partial class LoginScreen : Form
    {
        public Login Login { get; private set; }
        LoginController LoginController;   
        public LoginScreen()
        {
            InitializeComponent();

            LoginController = new LoginController();

            // LoginScreen
            StartPosition = FormStartPosition.CenterScreen;

            // LoginScreen Logo
            PictureBoxLogo.Image = Image.FromFile(@"../../resources/hhs_logo.jpg");
            PictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            Login = new Login() { username = TextBoxUsername.Text, password = TextBoxPassword.Text };
            // Kijkt of de inlog details overeenkwamen in de controller
            if (LoginController.VerifyLogin(Login) == true)
            {
                this.Hide();
                HomeScreen HomeScreen = new HomeScreen(Login);
                HomeScreen.Show();
            }
            else
            {
                MessageBox.Show("Inloggen is mislukt!");
            }
        }

        private void LoginScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
