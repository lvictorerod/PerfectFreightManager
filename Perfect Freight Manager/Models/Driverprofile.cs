namespace Perfect_Freight_Manager.Models
{
    public class Driverprofile
    {
        public int id { get; set; }
        public string name { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string birthay { get; set; }
        public string assignedtruck { get; set; }
        public string hiredate { get; set; }
        public string endservicedate { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string codezip { get; set; }
        public string homephone { get; set; }
        public string cellphone { get; set; }
        public string cellservice { get; set; }
        public string email { get; set; }
        public string emergname { get; set; }
        public string emergaddress { get; set; }
        public string emergcity { get; set; }
        public string emergstate { get; set; }
        public string emergzip { get; set; }
        public string emerghomephone { get; set; }
        public string emergcellphone { get; set; }
        public byte[] driverphoto { get; set; }
        public string loadedparpermile { get; set; }
        public string emptypaypermile { get; set; }
        public string percentagepay { get; set; }
        public string percentof { get; set; }
        public string tonnagepay { get; set; }
        public string paybyhours { get; set; }
        public string paymethod { get; set; }
        public string notes { get; set; }
        public string cdlnumber { get; set; }
        public string cdlstate { get; set; }
        public string cdlclass { get; set; }
        public string cdlendor { get; set; }
        public string cdlexpirdate { get; set; }
        public byte[] cdlphoto { get; set; }
        public string medcareexpirdate { get; set; }
        public string ssnumber { get; set; }
        public byte[] ssphoto { get; set; }
        public byte[] medcardphoto { get; set; }
        public string statusdriver { get; set; }
        public string flatratepay { get; set; }
        public string activedriver { get; set; }
        public string pickupdroppay { get; set; }
        public string vacation { get; set; }
        public string drivereld { get; set; }
        public string driverezpass { get; set; }
        public string driverinsurace { get; set; }
        public string driverprepass { get; set; }
        public string driverexpense { get; set; }
        public string driverfuel { get; set; }
        public string driverfactoryfee { get; set; }
        public string driverpaymentfee { get; set; }

    }
}
