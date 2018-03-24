using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using crm_systeem.Models;
using System.IO;

namespace crm_systeem.Database
{
    class LoginController : DatabaseController
    {
        /// <summary>
        /// Vergelijk het binnenkomende Login object met gegevens uit de database. Als er een match is de juiste gebruikersnaam en wachtwoord returnt de methode een boolean die true is.
        /// </summary>
        /// <param name="Login"></param>
        /// <returns></returns>
        public bool VerifyLogin(Login Login)
        {
            bool loginStatus = false;
            try
            {
                conn.Open();
                string mySqlLogin = @"SELECT count(*) FROM user WHERE BINARY username LIKE @username AND BINARY password LIKE @password";

                MySqlCommand cmd = new MySqlCommand(mySqlLogin, conn);

                MySqlParameter username = new MySqlParameter("@username", MySqlDbType.VarChar);
                MySqlParameter password = new MySqlParameter("@password", MySqlDbType.VarChar);

                username.Value = Login.username;
                password.Value = Login.password;
                cmd.Parameters.Add(username);
                cmd.Parameters.Add(password);

                cmd.ExecuteNonQuery();
                
                // Als er een match van gegevens gevonden wordt 1 gereturned. 
                int queryResult = Convert.ToInt32(cmd.ExecuteScalar());
                if (queryResult == 1)
                {
                    loginStatus = true;
                }
                else
                {
                    loginStatus = false;
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message : " + ex.Message + Environment.NewLine + ex.StackTrace
                    + Environment.NewLine + "Date : " + DateTime.Now.ToString() + Environment.NewLine);
                }
            }
            finally
            {
                conn.Close();
            }
            return loginStatus;
        }
    }
}
