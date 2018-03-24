using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace crm_systeem.Database
{
    class DatabaseController
    {
        protected MySqlConnection conn;

        // Dit is een tekstbestand waar error berichten naar toe worden geschreven
        public string filePath = @"..\..\..\Error_log.txt";

        public DatabaseController()
        {
            filePath = @"..\..\..\Error_log.txt";
            conn = new MySqlConnection("Server=localhost;Database=crm;Uid=root;Pwd=30oktober");
        }
    }
}
