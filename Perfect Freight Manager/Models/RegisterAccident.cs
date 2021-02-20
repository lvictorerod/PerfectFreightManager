using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfect_Freight_Manager.Models
{
    public class RegisterAccident
    {
        public int id { get; set; }
        public string idreg { get; set; }
        public string regcarrier { get; set; }
        public string regfilenumber { get; set; }
        public string regvehiclenumber { get; set; }
        public string regdriver { get; set; }
        public string regfechafrom { get; set; }
        public string regfechato { get; set; }
        public string regfechaaccident { get; set; }
        public string reglocation { get; set; }
        public string reginjurence { get; set; }
        public string regfatalities { get; set; }
        public string regdollars { get; set; }
        public string reghazardous { get; set; }
    }
}
