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
    class PeriodController : DatabaseController
    {
        /// <summary>
        ///  Haal alle gebruikers (users) op uit de database en sla ze op in een lijst. Return vervolgens deze lijst. Bij een fout wordt de error in detail weggeschreven naar een apart bestand.
        /// </summary>
        /// <returns></returns>
        public List<Period> GetPeriodList()
        {
            List<Period> PeriodList = new List<Period>();
            try
            {
                conn.Open();
                string mySqlContactPerson = @"SELECT * FROM period";
                MySqlCommand cmd = new MySqlCommand(mySqlContactPerson, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Period Period = new Period();

                    string periodName = dataReader.GetString("name");
                    
                    Period.name = periodName;

                    PeriodList.Add(Period);
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
            return PeriodList;
        }
    }
}
