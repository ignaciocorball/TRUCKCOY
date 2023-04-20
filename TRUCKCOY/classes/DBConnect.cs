using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace TRUCKCOY.classes
{
    class DBConnect
    {
        public MySqlConnection conexion()
        {
            string servidor = "";
            string bd = "";
            string usuario = "";
            string password = "";

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
