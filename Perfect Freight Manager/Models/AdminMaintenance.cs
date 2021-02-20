using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfect_Freight_Manager.Models
{
    public class AdminMaintenance
    {
        public int id { get; set; }
        public string trucktipopm { get; set; }
        public string truckstoppm { get; set; }
        public string trucktipo2 { get; set; }
        public string truckstoptipo2 { get; set; }
        public string trucktipo3 { get; set; }
        public string truckstoptipo3 { get; set; }
        public string trailertipopm { get; set; }
        public string trailerstoppm { get; set; }
        public string trailertipo2 { get; set; }
        public string trailerstoptipo2 { get; set; }
        public string trailertipo3 { get; set; }
        public string trailerstoptipo3 { get; set; }
        public string apu { get; set; }
        public string apustop { get; set; }
        public string apurate { get; set; }
        public string summerfrom { get; set; }
        public string summerto { get; set; }
        public string winterfrom { get; set; }
        public string winterto { get; set; }
    }
}
