namespace TRUCKCOY.classes
{
    class Vehicles
    {
        private int id;
        private string name;
        private bool ignition;
        private string temp;
        private int kms_today;
        private int alerts;
        private string location;
        private string speed;
        private int trips;
        private string kms_total;
        private string lastupdate;
        private string company;
        private string driver;
        private double lat;
        private double lng;
        private float deg;
        private string status;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public bool Ignition { get => ignition; set => ignition = value; }
        public string Temp { get => temp; set => temp = value; }
        public int Kms_today { get => kms_today; set => kms_today = value; }
        public int Alerts { get => alerts; set => alerts = value; }
        public string Location { get => location; set => location = value; }
        public string Speed { get => speed; set => speed = value; }
        public int Trips { get => trips; set => trips = value; }
        public string Kms_total { get => kms_total; set => kms_total = value; }
        public string Lastupdate { get => lastupdate; set => lastupdate = value; }
        public string Company { get => company; set => company = value; }
        public string Driver { get => driver; set => driver = value; }
        public double Lat { get => lat; set => lat = value; }
        public double Lng { get => lng; set => lng = value; }
        public float Deg { get => deg; set => deg = value; }
        public string Status { get => status; set => status = value; }
    }
}
