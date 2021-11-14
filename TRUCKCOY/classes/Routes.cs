namespace TRUCKCOY.classes
{
    class Routes
    {
        private int id;
        private string name;
        private string destination_address;
        private string source_address;
        private string patente;
        private string phone;
        private string lat;
        private string lng;
        private string city;
        private string alt;
        private string deg;
        private string order_income_date;
        private string order_finished_date;
        private string company;
        private string status;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Dest { get => destination_address; set => destination_address = value; }
        public string Src { get => source_address; set => source_address = value; }
        public string Patente { get => patente; set => patente = value; }
        public string Phone { get => phone; set => phone = value; }
        public string CurrentLat { get => lat; set => lat = value; }
        public string CurrentLng { get => lng; set => lng = value; }
        public string City { get => city; set => city = value; }
        public string CurrentAlt { get => alt; set => alt = value; }
        public string CurrentDeg { get => deg; set => deg = value; }
        public string OrderIncomeDate { get => order_income_date; set => order_income_date = value; }
        public string OrderFinishedDate { get => order_finished_date; set => order_finished_date = value; }
        public string Company { get => company; set => company = value; }
        public string Status { get => status; set => status = value; }
    }
}
