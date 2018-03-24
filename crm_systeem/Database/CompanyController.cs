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
    class CompanyController : DatabaseController
    {
        public int PrimaryKey;

        /// <summary>
        /// Voeg een nieuw bedrijf toe aan de database. Return true als de toevoeging succesvol is, false als er iets verkeerd is gegaan. Deze boolean waarde wordt in de de klasse waar deze methode is aangeroepen gebruikt om te controleren of de methode geslaagd is. Bij een fout wordt de error in detail weggeschreven naar een apart bestand.
        /// </summary>
        /// <param name="Company"></param>
        /// <returns></returns>
        public bool InsertCompany(Company Company)
        {
            try
            {
                conn.Open();
                string query = @"INSERT INTO company (name, address, internship, internship_differentiation) VALUES (@companyName, @companyAddress, @companyInternship, @companyInternshipDifferentiation)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@companyName", Company.name);
                cmd.Parameters.AddWithValue("@companyAddress", Company.address);
                cmd.Parameters.AddWithValue("@companyInternship", Company.internship);
                cmd.Parameters.AddWithValue("@companyInternshipDifferentiation", Company.internship_differentiation);

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
        /// Haal alle bedrijf objecten op uit de database en sla ze op in een lijst. Return vervolgens deze lijst. Bij een fout wordt de error in detail weggeschreven naar een apart bestand.
        /// </summary>
        /// <returns></returns>
        public List<Company> GetCompanyList()
        {
            List<Company> CompanyList = new List<Company>();
            try
            {
                conn.Open();
                string mySqlContactPerson = @"SELECT * FROM company";
                MySqlCommand cmd = new MySqlCommand(mySqlContactPerson, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Company Company = new Company();

                    int companyId = dataReader.GetInt32("id");
                    string companyName = dataReader.GetString("name");
                    string companyAdress = dataReader.GetString("address");
                    string Companyinternship = dataReader.GetString("internship");
                    string CompanyInternship_diff = dataReader.GetString("internship_differentiation");

                    Company.id = companyId;
                    Company.name = companyName;
                    Company.address = companyAdress;
                    Company.internship = Companyinternship;
                    Company.internship_differentiation = CompanyInternship_diff;

                    CompanyList.Add(Company);
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
            return CompanyList;
        }

        /// <summary>
        /// Verwijder het binnenkomende Bedrijf object. Return true als de operatie gelukt is, en false als die mislukt is. Deze waarde wordt in de aanroepende klasse gebruikt om te achterhalen of de operatie gelukt is. Bij een fout wordt de error in detail weggeschreven naar een apart bestand.
        /// </summary>
        /// <param name="Company"></param>
        /// <returns></returns>
        public bool DeleteCompany(Company Company)
        {
            try
            {
                conn.Open();
                string query = @"DELETE FROM company WHERE id = @companyID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlParameter companyID = new MySqlParameter("@companyID", MySqlDbType.Int32);
                companyID.Value = Company.id;

                cmd.Parameters.Add(companyID);
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
        /// Wijzig de gegevens van een bedrijf. Return true als de operatie gelukt is, en false als die mislukt is. Deze waarde wordt in de aanroepende klasse gebruikt om te achterhalen of de operatie gelukt is. Bij een fout wordt de error in detail weggeschreven naar een apart bestand.
        /// </summary>
        /// <param name="Company"></param>
        /// <returns></returns>
        public bool UpdateCompany(Company Company)
        {
            try
            {
                conn.Open();
                string query = "UPDATE company SET name = @companyName, address = @companyAddress, internship = @companyInternship, internship_differentiation = @companyInternshipDifferentiation WHERE id = @companyID";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@companyName", Company.name);
                cmd.Parameters.AddWithValue("@companyID", Company.id);
                cmd.Parameters.AddWithValue("@companyAddress", Company.address);
                cmd.Parameters.AddWithValue("@companyInternship", Company.internship);
                cmd.Parameters.AddWithValue("@companyInternshipDifferentiation", Company.internship_differentiation);
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
