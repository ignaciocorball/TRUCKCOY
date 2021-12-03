using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace TRUCKCOY.classes
{
    class DBConnect
    {
        public MySqlConnection conexion()
        {
            string servidor = "156.67.73.151";
            string bd = "u853513044_truckcoy";
            string usuario = "u853513044_G";
            string password = "@Andromeda123@";

            string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id= " + usuario + "; Password=" + password + "; SslMode=none";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                return conexionBD;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }

    }
}
