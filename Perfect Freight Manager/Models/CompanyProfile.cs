using iText.IO.Source;

namespace Perfect_Freight_Manager.Models
{
    public class CompanyProfile
    {
        public int id { get; set; }
        public string company { get; set; }
        public string owner { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string phone { get; set; }
        public string contact { get; set; }
        public string billingemail { get; set; }
        public string tollfree { get; set; }
        public string fax { get; set; }
        public string usddot { get; set; }
        public string fid { get; set; }
        public string mc { get; set; }
        public string autohauler { get; set; }
        public string sendmailviaoutlook { get; set; }
        public string checkupdate { get; set; }
        public string uselogin { get; set; }
        public string notes { get; set; }
        public string invoicemessage { get; set; }
        public string emailsignature { get; set; }
        public byte[] companylogo { get; set; }
        public string paypermileload { get; set; }
        public string paypermileempty { get; set; }
        public string percentagepay { get; set; }
        public string percentagepayof { get; set; }
        public string tonnagepay { get; set; }
        public string paybyhours { get; set; }
        public string paymethod { get; set; }
    }
}
