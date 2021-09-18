using MySql.Data.MySqlClient;

namespace TRUCKCOY.classes
{
    class Connect
    {
        //-> Mysql Strings and Connection
        public MySqlConnection connection;
        private string server;
        private string database;
        private string user;
        private string password;
        private string port;
        private string connectionString;
        private string sslM;

        //-> Connect with database
        public Connect()
        {
            server = "localhost";
            database = "TRUCKCOY";
            user = "root";
            password = "";
            port = "3306";
            sslM = "none";

            connectionString = string.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);

            connection = new MySqlConnection(connectionString);
        }

        //-> Return result of Mysql Connection
        public string testConnection()
        {
            try
            {
                connection.Open();
                connection.Close();
                return "Successful";
            }
            catch (MySqlException)
            {
                return "Failed";
            }
        }


        //-> Get historyForm data

        public string[] getlast14orders(string email)
        {
            string[] data = { "0","1","2" };

            return data;
        }



    }
}
