using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfect_Freight_Manager.Models
{
    public class Broker
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string codezip { get; set; }
        public string phonelocal { get; set; }
        public string phonetollfree { get; set; }
        public string cellphone { get; set; }
        public string cellservice { get; set; }
        public string fax { get; set; }
        public string emergencynumber { get; set; }
        public string notes { get; set; }
        public string mcnumber { get; set; }
        public string usddot { get; set; }
        public string email { get; set; }
    }
}
