namespace TRUCKCOY.classes
{
    class Routes
    {
        private int id;
        private string name;
        private string destination_address;
        private string source_address;
        private string city;
        private string patente;
        private string phone;
        private string lat_src;
        private string lng_src;
        private string deg_src;
        private string lat_dest;
        private string lng_dest;
        private string order_income;
        private string order_finished;
        private string company;
        private string status;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Dest { get => destination_address; set => destination_address = value; }
        public string Src { get => source_address; set => source_address = value; }
        public string City { get => city; set => city = value; }
        public string Patente { get => patente; set => patente = value; }
        public string Phone { get => phone; set => phone = value; }
        public string LatSrc { get => lat_src; set => lat_src = value; }
        public string LngSrc { get => lng_src; set => lng_src = value; }
        public string DegSrc { get => deg_src; set => deg_src = value; }
        public string LatDest { get => lat_dest; set => lat_dest = value; }
        public string LngDest { get => lng_dest; set => lng_dest = value; }
        public string OrderIncomeDate { get => order_income; set => order_income = value; }
        public string OrderFinishedDate { get => order_finished; set => order_finished = value; }
        public string Company { get => company; set => company = value; }
        public string Status { get => status; set => status = value; }
    }
}
