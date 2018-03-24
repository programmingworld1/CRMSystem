using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm_systeem.Models
{
    public class ContactpersonPeriod
    {
        public int contactperson_id { get; set; }
        public string period_name { get; set; }
        public string differentiation { get; set; }
        public int year { get; set; }
        public string helped_with { get; set; }
    }
}
