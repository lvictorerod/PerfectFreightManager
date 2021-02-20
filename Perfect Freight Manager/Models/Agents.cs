using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfect_Freight_Manager.Models
{
    public class Agents
    {
        public int id { get; set; }
        public string name { get; set; }
        public string idclient { get; set; }
        public string department { get; set; }
        public string phonenumber { get; set; }
        public string extnumber { get; set; }
        public string celphonenumber { get; set; }
        public string faxnumber { get; set; }
        public string email { get; set; }
        public string dptcategory { get; set; }
        public string agreementdate { get; set; }
        public string detentionpay { get; set; }
        public string banned { get; set; }
        public string inactive { get; set; }
        public string startime { get; set; }
        public string usddotnumber { get; set; }
        public string mcnumber { get; set; }
        public string insuranceagency { get; set; }
        public string policynumber { get; set; }
        public string cargoamount { get; set; }
        public string liabilityamount { get; set; }
        public string expirationdate { get; set; }
    }
}
