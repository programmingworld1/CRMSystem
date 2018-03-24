using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm_systeem.Models
{
    public class Contactperson
    {
        public int id { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string insertion { get; set; }
        public string lastname { get; set; }
        public int company_id { get; set; }
        public string function { get; set; }
        public string next_time { get; set; }
        public string rating { get; set; }
        public string comment { get; set; }
        public DateTime created { get; set; }
        public DateTime last_updated { get; set; }
        public int contact_hhs { get; set; }
        public int created_by { get; set; }
    }
}
