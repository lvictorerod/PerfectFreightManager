namespace DataAccess.Models
{
    public class TrucksProfile
    {
        public int id { get; set; }
        public string name { get; set; }
        public string ownername { get; set; }
        public string trucknumber { get; set; }
        public string vinnumber { get; set; }
        public string year { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string tag { get; set; }
        public string pmmileage { get; set; }
        public string truckcolor { get; set; }
        public string tiresize { get; set; }
        public string axles { get; set; }
        public string enginemake { get; set; }
        public string enginepower { get; set; }
        public string enginesn { get; set; }
        public string transtype { get; set; }
        public string emptywgt { get; set; }
        public string fueltank { get; set; }
        public string notes { get; set; }
        public byte[] photo { get; set; }
        public string licensedate { get; set; }
        public string licensedateexpire { get; set; }
        public string totalmiles { get; set; }
        public string statusstop { get; set; }
        public string equipment { get; set; }
    }
}
