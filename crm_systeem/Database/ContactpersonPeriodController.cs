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
     class ContactpersonPeriodController : DatabaseController
    {
        /// <summary>
        /// Voeg een nieuwe ContactPersonPeriod toe aan de database. Een ContactPersonPeriod is een verband tussen Contactperson en Period, in dit verband staat in welke periode welke contactpersoon heeft meegedaan. Returnt true als de toevoeging succesvol is, false als er iets verkeerd is gegaan. Deze boolean waarde wordt in de de klasse waar deze methode is aangeroepen gebruikt om te controleren of de methode geslaagd is. Bij een fout wordt de error in detail weggeschreven naar een apart bestand.
        /// </summary>
        /// <param name="ContactpersonPeriod">Het binnenkomende ContactpersonPeriod object die toegevoegd moet gaan worden aan de database.</param>
        /// <returns></returns>
        public bool InsertContactpersonPeriod(ContactpersonPeriod ContactpersonPeriod)
        {
            try
            {
                conn.Open();
                string query = @"INSERT INTO contactperson_period (contactperson_id, period_name, year, differentiation, helped_with) VALUES (@ContactperonPeriodContactpersonID, @ContactperonPeriodPeriodName, @ContactperonPeriodYear, @ContactperonPeriodDifferentiation, @ContactperonPeriodHelpedWith)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ContactperonPeriodContactpersonID", ContactpersonPeriod.contactperson_id);
                cmd.Parameters.AddWithValue("@ContactperonPeriodPeriodName", ContactpersonPeriod.period_name);
                cmd.Parameters.AddWithValue("@ContactperonPeriodYear", ContactpersonPeriod.year);
                cmd.Parameters.AddWithValue("@ContactperonPeriodDifferentiation", ContactpersonPeriod.differentiation);
                cmd.Parameters.AddWithValue("@ContactperonPeriodHelpedWith", ContactpersonPeriod.helped_with);
                
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
        /// Haal alle ContactpersonPeriod objecten op uit de database en sla ze op in een lijst. Return vervolgens deze lijst. Bij een fout wordt de error in detail weggeschreven naar een apart bestand.
        /// </summary>
        /// <returns></returns>
        public List<ContactpersonPeriod> GetContactpersonPeriodList()
        {
            List<ContactpersonPeriod> ContactpersonPeriodList = new List<ContactpersonPeriod>();

            try
            {
                conn.Open();
                string query = @"SELECT * FROM contactperson_period";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ContactpersonPeriod ContactpersonPeriod = new ContactpersonPeriod();
                    int ContactperonPeriodContactpersonID = reader.GetInt32("contactperson_id");
                    string contactpersonPeriodPeriodName = reader.GetString("period_name");
                    string contactpersonPeriodDifferentiation = reader.GetString("differentiation");
                    string contactpersonPeriodHelpedWith = reader.GetString("helped_with");
                    int contactpersonPeriodYear = reader.GetInt32("year");

                    ContactpersonPeriod.contactperson_id = ContactperonPeriodContactpersonID;
                    ContactpersonPeriod.period_name = contactpersonPeriodPeriodName;
                    ContactpersonPeriod.differentiation = contactpersonPeriodDifferentiation;
                    ContactpersonPeriod.helped_with = contactpersonPeriodHelpedWith;
                    ContactpersonPeriod.year = contactpersonPeriodYear;

                    ContactpersonPeriodList.Add(ContactpersonPeriod);
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
            return ContactpersonPeriodList;
        }

        /// <summary>
        /// Verwijder het binnenkomende ContactpersonPeriod object. Return true als de operatie gelukt is, en false als die mislukt is. Deze waarde wordt in de aanroepende klasse gebruikt om te achterhalen of de operatie gelukt is. Bij een fout wordt de error in detail weggeschreven naar een apart bestand.
        /// </summary>
        /// <param name="ContactpersonPeriod"></param>
        /// <returns></returns>
        public bool DeleteContactpersonPeriod(ContactpersonPeriod ContactpersonPeriod)
        {
            try
            {
                conn.Open();
                string query = @"DELETE FROM contactperson_period WHERE contactperson_id = @ContactperonPeriodContactpersonID and period_name = @ContactperonPeriodPeriodName and year = @ContactperonPeriodYear;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlParameter ContactperonPeriodContactpersonID = new MySqlParameter("@ContactperonPeriodContactpersonID", MySqlDbType.Int32);
                MySqlParameter ContactperonPeriodPeriodName = new MySqlParameter("@ContactperonPeriodPeriodName", MySqlDbType.VarChar);
                MySqlParameter ContactperonPeriodYear = new MySqlParameter("@ContactperonPeriodYear", MySqlDbType.Int32);
                ContactperonPeriodContactpersonID.Value = ContactpersonPeriod.contactperson_id;
                ContactperonPeriodPeriodName.Value = ContactpersonPeriod.period_name;
                ContactperonPeriodYear.Value = ContactpersonPeriod.year;

                cmd.Parameters.Add(ContactperonPeriodContactpersonID);
                cmd.Parameters.Add(ContactperonPeriodPeriodName);
                cmd.Parameters.Add(ContactperonPeriodYear);
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
    }
}
