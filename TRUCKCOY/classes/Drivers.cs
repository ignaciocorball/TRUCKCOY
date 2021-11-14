
namespace TRUCKCOY.classes
{
    class Drivers
    {
        private int id;
        private string name;
        private string phone;
        private string imei;
        private string patente;
        private string status;
        private string company;
        private string regdate;
        private string lastaccess;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Imei { get => imei; set => imei = value; }
        public string Patente { get => patente; set => patente = value; }
        public string Status { get => status; set => status = value; }
        public string Company { get => company; set => company = value; }
        public string Regdate { get => regdate; set => regdate = value; }
        public string Lastaccess { get => lastaccess; set => lastaccess = value; }
    }
}
