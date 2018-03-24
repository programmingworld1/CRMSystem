using crm_systeem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm_systeem.Database
{
    class UserController : DatabaseController
    {
        public int PrimaryKey;

        /// <summary>
        /// Voeg een nieuwe gebruiker toe aan de database. Return true als de toevoeging succesvol is, false als er iets verkeerd is gegaan. Deze boolean waarde wordt in de de klasse waar deze methode is aangeroepen gebruikt om te controleren of de methode geslaagd is. Bij een fout wordt de error in detail weggeschreven naar een apart bestand.
        /// </summary>
        /// <param name="User">Het User object waarin de gegevens bevat zijn van de nieuwe gebruiker.</param>
        /// <returns></returns>
        public bool InsertUser(User User)
        {
            try
            {
                conn.Open();
                string query = @"INSERT INTO user (firstname, insertion, lastname, username, password, email, type) VALUES (@userFirstname, @userInsertion, @userLastname, @userUsername, @userPassword, @userEmail, @userType)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@userFirstname", User.firstname);
                cmd.Parameters.AddWithValue("@userInsertion", User.insertion);
                cmd.Parameters.AddWithValue("@userLastname", User.lastname);
                cmd.Parameters.AddWithValue("@userUsername", User.username);
                cmd.Parameters.AddWithValue("@userPassword", User.password);
                cmd.Parameters.AddWithValue("@userEmail", User.email);
                cmd.Parameters.AddWithValue("@userType", User.type);

                cmd.ExecuteNonQuery();

                // ... A
                PrimaryKey = (int)cmd.LastInsertedId;

                return true;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message : " + ex.Message + Environment.NewLine + ex.StackTrace
                    + Environment.NewLine + "Date : " + DateTime.Now.ToString() + Environment.NewLine);
                }
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Haal alle gebruikers (users) op uit de database en sla ze op in een lijst. Return vervolgens deze lijst. Bij een fout wordt de error in detail weggeschreven naar een apart bestand.
        /// </summary>
        /// <returns></returns>
        public List<User> GetUserList()
        {
            List<User> UserList = new List<User>();
            User User;
            string userInsertion = "";

            try
            {
                conn.Open();
                string query = @"SELECT * FROM user";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int userID = reader.GetInt32("id");
                    string userName = reader.GetString("username");
                    string userPassword = reader.GetString("password");
                    string userFirstName = reader.GetString("firstname");
                    string userLastName = reader.GetString("lastname");
                    string userType = reader.GetString("type");
                    string userEmail = reader.GetString("email");

                    //  In deze if statement wordt gekeken of de waarde "insertion" NULL is. Is dit niet het geval dan mag de waarde uit de database gehaald worden. Is dit veld wel NULL, dan wordt de vervanging string userInsertion gebruikt
                    if (!reader.IsDBNull(4))
                    {
                        userInsertion = reader.GetString("insertion");
                    }

                    // Maak de nieuwe gebruiker aan en voeg hem aan de lijst met users toe
                    User = new User { id = userID, username = userName, password = userPassword, firstname = userFirstName, insertion = userInsertion, lastname = userLastName, email = userEmail, type = userType };
                    UserList.Add(User);
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
            return UserList;
        }

        /// <summary>
        /// Verwijder het binnenkomende User object. Return true als de operatie gelukt is, en false als die mislukt is. Deze waarde wordt in de aanroepende klasse gebruikt om te achterhalen of de operatie gelukt is. Bij een fout wordt de error in detail weggeschreven naar een apart bestand.
        /// </summary>
        /// <param name="User">De binnenkomende gebruiker(user) die van de database verwijdert moet worden.</param>
        /// <returns></returns>
        public bool DeleteUser(User User)
        {
            try
            {
                conn.Open();
                string query = @"DELETE FROM user WHERE id = @userID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlParameter userID = new MySqlParameter("@userID", MySqlDbType.Int32);
                userID.Value = User.id;

                cmd.Parameters.Add(userID);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message : " + ex.Message + Environment.NewLine + ex.StackTrace
                    + Environment.NewLine + "Date : " + DateTime.Now.ToString() + Environment.NewLine);
                }
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Wijzig de gegevens van een gebruiker (user). Return true als de operatie gelukt is, en false als die mislukt is. Deze waarde wordt in de aanroepende klasse gebruikt om te achterhalen of de operatie gelukt is. Bij een fout wordt de error in detail weggeschreven naar een apart bestand.
        /// </summary>
        /// <param name="User">De gebruiker(user) waarvan de gegevens gewijzigd moeten worden.</param>
        /// <returns></returns>
        public bool UpdateUser(User User)
        {
            try
            {
                conn.Open();
                string query = "UPDATE user SET username = @userName, firstname = @userFirstname, insertion = @userInsertion, lastname = @userLastname, email = @userEmail, type = @userType WHERE id = @userID";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@userName", User.username);
                cmd.Parameters.AddWithValue("@userID", User.id);
                cmd.Parameters.AddWithValue("@userPassword", User.password);
                cmd.Parameters.AddWithValue("@userFirstName", User.firstname);
                cmd.Parameters.AddWithValue("@userInsertion", User.insertion);
                cmd.Parameters.AddWithValue("@userLastName", User.lastname);
                cmd.Parameters.AddWithValue("@userEmail", User.email);
                cmd.Parameters.AddWithValue("@userType", User.type);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message : " + ex.Message + Environment.NewLine + ex.StackTrace
                    + Environment.NewLine + "Date : " + DateTime.Now.ToString() + Environment.NewLine);
                }
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Een specifieke functionaliteit waarmee de gebruiker(user) op elk moment zijn wachtwoord kan wijzigen. Return true als de operatie gelukt is, en false als die mislukt is. Deze waarde wordt in de aanroepende klasse gebruikt om te achterhalen of de operatie gelukt is. Bij een fout wordt de error in detail weggeschreven naar een apart bestand.
        /// </summary>
        /// <param name="User">De gebruiker(user) waarvan het wachtwoord verandert moet worden.</param>
        /// <returns></returns>
        public bool ChangeUserPassword(User User)
        {
            try
            {
                conn.Open();
                string query = "UPDATE user SET password = @userPassword WHERE id = @userID";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@userPassword", User.password);
                cmd.Parameters.AddWithValue("@userID", User.id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message : " + ex.Message + Environment.NewLine + ex.StackTrace
                    + Environment.NewLine + "Date : " + DateTime.Now.ToString() + Environment.NewLine);
                }
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
