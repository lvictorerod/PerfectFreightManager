namespace DataAccess.Models
{
    public class Expense
    {
        public int id { get; set; }
        public string invoicenumber { get; set; }
        public string date { get; set; }
        public string payment { get; set; }
        public string truck { get; set; }
        public string trailer { get; set; }
        public string apu { get; set; }
        public string truckmileage { get; set; }
        public string trailermileage { get; set; }
        public string apuhours { get; set; }
        public string pmtruck { get; set; }
        public string notes { get; set; }
        public string phone { get; set; }
        public string contact { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string codezip { get; set; }
        public string vendor { get; set; }
    }
}
