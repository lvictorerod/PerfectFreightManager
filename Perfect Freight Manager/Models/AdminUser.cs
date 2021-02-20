namespace Perfect_Freight_Manager.Models
{
    public class AdminUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string codezip { get; set; }
        public string nick { get; set; }
        public string password { get; set; }
        public string notes { get; set; }
        public string datestart { get; set; }
        public string dateend { get; set; }
        public byte[] photo { get; set; }
    }
}
