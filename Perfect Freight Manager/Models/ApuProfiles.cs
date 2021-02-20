using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfect_Freight_Manager.Models
{
    public class ApuProfiles
    {
        public int id { get; set; }
        public string owner { get; set; }
        public string apunumber { get; set; }
        public string vinnumber { get; set; }
        public string licensedate { get; set; }
        public string licensedateexpire { get; set; }
        public string year { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public string totalhours { get; set; }
        public byte[] photo { get; set; }
        public string notes { get; set; }
        public string trucknumber { get; set; }
        public string statusstop { get; set; }
    }
}
