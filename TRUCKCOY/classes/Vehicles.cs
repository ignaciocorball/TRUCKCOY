namespace TRUCKCOY.classes
{
    class Vehicles
    {
        private int id;
        private string name;
        private string driver;
        private bool ignition;
        private int temp;
        private int kms_today;
        private int kms_total;
        private int alerts;
        private string location;
        private int speed;
        private int trips;
        private string lastupdate;
        private string status;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Driver { get => driver; set => driver = value; }
        public bool Ignition { get => ignition; set => ignition = value; }
        public int Temperature { get => temp; set => temp = value; }
        public int Kms_today { get => kms_today; set => kms_today = value; }
        public int Kms_total { get => kms_total; set => kms_total = value; }
        public int Alerts { get => alerts; set => alerts = value; }
        public string Location { get => location; set => location = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Trips { get => trips; set => trips = value; }
        public string Lastupdate { get => lastupdate; set => lastupdate = value; }
        public string Status { get => status; set => status = value; }
    }
}
