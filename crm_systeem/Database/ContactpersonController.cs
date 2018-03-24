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
    class ContactpersonController : DatabaseController
    {
        public int PrimaryKey;
        /// <summary>
        /// Voeg een nieuwe contactpersoon toe aan de database. Return true als de toevoeging succesvol is, false als er iets verkeerd is gegaan. Deze boolean waarde wordt in de de klasse waar deze methode is aangeroepen gebruikt om te controleren of de methode geslaagd is. Bij een fout wordt de error in detail weggeschreven naar een apart bestand.        
        /// </summary>
        /// <param name="Contactperson">De nieuwe contactpersoon die toegevoegd gaat worden.</param>
        /// <returns></returns>
        public bool InsertContactperson(Contactperson Contactperson)
        {
            try
            {
                conn.Open();
                string query = @"INSERT INTO contactperson (firstname, insertion, lastname, email, phonenumber, company_id, function, next_time, rating, created, last_updated, contact_hhs, created_by) VALUES (@contactpersonFirstName, @contactpersonInsertion, @contactpersonLastname, @contactpersonEmail, @contactpersonPhonenumber, @contactpersonCompanyID, @contactpersonFunction, @contactpersonNextTime, @contactpersonRating, @contactpersonCreated, @contactpersonLastUpdated, @contactpersonHHSContact, @contactpersonCreatedBy)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@contactpersonFirstName", Contactperson.firstname);
                cmd.Parameters.AddWithValue("@contactpersonInsertion", Contactperson.insertion);
                cmd.Parameters.AddWithValue("@contactpersonLastname", Contactperson.lastname);
                cmd.Parameters.AddWithValue("@contactpersonEmail", Contactperson.email);
                cmd.Parameters.AddWithValue("@contactpersonPhonenumber", Contactperson.phonenumber);
                cmd.Parameters.AddWithValue("@contactpersonCompanyID", Contactperson.company_id);
                cmd.Parameters.AddWithValue("@contactpersonFunction", Contactperson.function);
                cmd.Parameters.AddWithValue("@contactpersonNextTime", Contactperson.next_time);
                cmd.Parameters.AddWithValue("@contactpersonRating", Contactperson.rating);
                cmd.Parameters.AddWithValue("@contactpersonCreated", DateTime.Now);
                cmd.Parameters.AddWithValue("@contactpersonLastUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@contactpersonHHSContact", Contactperson.contact_hhs);
                cmd.Parameters.AddWithValue("@contactpersonCreatedBy", Contactperson.created_by);

                cmd.ExecuteNonQuery();
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
        /// Haal alle contactpersonen op uit de database en sla ze op in een lijst. Return vervolgens deze lijst. Bij een fout wordt de error in detail weggeschreven naar een apart bestand.
        /// </summary>
        /// <returns></returns>
        public List<Contactperson> GetContactpersonList()
        {
            List<Contactperson> ContactpersonList = new List<Contactperson>();
            string contactpersonInsertion = "";
            string contactpersonComment = "";

            try
            {
                conn.Open();
                string query = @"SELECT * FROM contactperson";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Contactperson Contactperson = new Contactperson();
                    Company Company = new Company();
                    User User = new User();
                    int contactpersonID = reader.GetInt32("id");
                    string contactpersonFirstName = reader.GetString("firstname");
                    string contactpersonLastName = reader.GetString("lastname");
                    string contactpersonEmail = reader.GetString("email");
                    string contactpersonPhonenumber = reader.GetString("phonenumber");
                    int contactpersonCompanyID = reader.GetInt32("company_id");
                    string contactpersonFunction = reader.GetString("function");
                    string contactpersonNextTime = reader.GetString("next_time");
                    string contactpersonRating = reader.GetString("rating");
                    DateTime contactpersonCreated = reader.GetDateTime("created");
                    DateTime contactpersonLastUpdated = reader.GetDateTime("last_updated");
                    int contactpersonHHSContact = reader.GetInt32("contact_hhs");
                    int contactpersonCreatedBy = reader.GetInt32("created_by");

                    //  check if insertion is not NULL
                    if (!reader.IsDBNull(2))
                    {
                        contactpersonInsertion = reader.GetString("insertion");
                    }
                    //  check if comment is not NULL
                    if (!reader.IsDBNull(10))
                    {
                        contactpersonComment = reader.GetString("comment");
                    }

                    Contactperson.id = contactpersonID;
                    Contactperson.firstname = contactpersonFirstName;
                    Contactperson.insertion = contactpersonInsertion;
                    Contactperson.lastname = contactpersonLastName;
                    Contactperson.email = contactpersonEmail;
                    Contactperson.phonenumber = contactpersonPhonenumber;
                    Contactperson.company_id = contactpersonCompanyID;
                    Contactperson.function = contactpersonFunction;
                    Contactperson.next_time = contactpersonNextTime;
                    Contactperson.rating = contactpersonRating;
                    Contactperson.comment = contactpersonComment;
                    Contactperson.created = contactpersonCreated;
                    Contactperson.last_updated = contactpersonLastUpdated;
                    Contactperson.contact_hhs = contactpersonHHSContact;
                    Contactperson.created_by = contactpersonCreatedBy;

                    // Voeg de record van de contactpersoon toe aan de lijst
                    ContactpersonList.Add(Contactperson);
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
            return ContactpersonList;
        }

        /// <summary>
        /// Verwijder het binnenkomende contactpersoon object. Return true als de operatie gelukt is, en false als die mislukt is. Deze waarde wordt in de aanroepende klasse gebruikt om te achterhalen of de operatie gelukt is. Bij een fout wordt de error in detail weggeschreven naar een apart bestand.
        /// </summary>
        /// <param name="Contactperson"></param>
        /// <returns></returns>
        public bool DeleteContactperson(Contactperson Contactperson)
        {
            try
            {
                conn.Open();
                string query = @"DELETE FROM contactperson WHERE id = @contactpersonID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlParameter contactpersonID = new MySqlParameter("@contactpersonID", MySqlDbType.Int32);
                contactpersonID.Value = Contactperson.id;

                cmd.Parameters.Add(contactpersonID);
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
        /// Wijzig de gegevens van een contactpersoon. Return true als de operatie gelukt is, en false als die mislukt is. Deze waarde wordt in de aanroepende klasse gebruikt om te achterhalen of de operatie gelukt is. Bij een fout wordt de error in detail weggeschreven naar een apart bestand.
        /// </summary>
        /// <param name="Contactperson"></param>
        /// <returns></returns>
        public bool UpdateContactperson(Contactperson Contactperson)
        {
            try
            {
                conn.Open();
                string query = "UPDATE contactperson SET firstname = @contactpersonFirstName, insertion = @contactpersonInsertion, lastname = @contactpersonLastName, email = @contactpersonEmail, phonenumber = @contactpersonPhonenumber, company_id = @contactpersonCompanyID, function = @contactpersonFunction, next_time = @contactpersonNextTime, rating = @contactpersonRating, comment = @contactpersonComment, last_updated = @contactpersonLastUpdated, contact_hhs = @contactpersonHHSContact WHERE id = @contactpersonID";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@contactpersonID", Contactperson.id);
                cmd.Parameters.AddWithValue("@contactpersonFirstName", Contactperson.firstname);
                cmd.Parameters.AddWithValue("@contactpersonInsertion", Contactperson.insertion);
                cmd.Parameters.AddWithValue("@contactpersonLastName", Contactperson.lastname);
                cmd.Parameters.AddWithValue("@contactpersonEmail", Contactperson.email);
                cmd.Parameters.AddWithValue("@contactpersonPhonenumber", Contactperson.phonenumber);
                cmd.Parameters.AddWithValue("@contactpersonCompanyID", Contactperson.company_id);
                cmd.Parameters.AddWithValue("@contactpersonFunction", Contactperson.function);
                cmd.Parameters.AddWithValue("@contactpersonNextTime", Contactperson.next_time);
                cmd.Parameters.AddWithValue("@contactpersonRating", Contactperson.rating);
                cmd.Parameters.AddWithValue("@contactpersonComment", Contactperson.comment);
                cmd.Parameters.AddWithValue("@contactpersonLastUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@contactpersonHHSContact", Contactperson.contact_hhs);

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
