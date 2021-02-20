using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfect_Freight_Manager.Models
{
    public class DispatchSheet
    {
        public int id { get; set; }
        public string dsid { get; set; }
        public string dsloadid { get; set; }
        public string dsdriver { get; set; }
        public string tdsequipment { get; set; }
        public string dsshipper { get; set; }
        public string dsaddressshipper { get; set; }
        public string dsphoneshipper { get; set; }
        public string dspickupdate { get; set; }
        public string dspickuptime { get; set; }
        public string dspickupnumber { get; set; }
        public string dspickupappoinment { get; set; }
        public string dsreceiver { get; set; }
        public string dsaddressreceiver { get; set; }
        public string dsphonereceiver { get; set; }
        public string dsreceiverdate { get; set; }
        public string dsdeliverytime { get; set; }
        public string dsdeliverynumber { get; set; }
        public string dsdeliveryappoinment { get; set; }
        public string rdloadid { get; set; }
        public string dsammount { get; set; }
        public string dsrate { get; set; }
        public string dsextended { get; set; }
        public string dstotal { get; set; }
        public string dsnotes { get; set; }
    }
}
