using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crm_systeem
{
    static class CrmApp
    {
        [STAThread]
        static void Main()
        {
            
            LoginScreen LoginScreen = new LoginScreen();
            LoginScreen.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(LoginScreen);

            // If login succeeds
            //if (LoginScreen.DialogResult == DialogResult.OK)
            //{

            //    HomeScreen HomeScreen = new HomeScreen(LoginScreen.Login);

            //    //HomeScreen.ShowDialog();
            //    Application.Run(HomeScreen);

            //}
        }
    }
}

// 09/06 om 21:12