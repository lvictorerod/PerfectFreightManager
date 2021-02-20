namespace DataAccess.Models
{
    public class TrailersProfile
    {
        public int id { get; set; }
        public string name { get; set; }
        public string trailernumber { get; set; }
        public string vinnumber { get; set; }
        public string tag { get; set; }
        public string pmmileage { get; set; }
        public string year { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public string tiresize { get; set; }
        public string axels { get; set; }
        public string notes { get; set; }
        public byte[] photo { get; set; }
        public string licensedate { get; set; }
        public string licensedateexpire { get; set; }
        public string totalmiles { get; set; }
        public string statusstop { get; set; }
        public string equipment { get; set; }
    }
}
