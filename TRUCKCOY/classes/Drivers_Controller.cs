using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace TRUCKCOY.classes
{
    class Drivers_Controller : DBConnect
    {
        public List<Object> query(string data)
        {
            MySqlDataReader reader;
            List<Object> list = new List<object>();
            string sql;

            sql = "SELECT id,name,phone,imei,patente,status,company,regdate,lastaccess FROM drivers ORDER BY id DESC";

            try
            {
                MySqlConnection dbcon = base.conexion();
                dbcon.Open();
                MySqlCommand command = new MySqlCommand(sql, dbcon);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Drivers _drivers = new Drivers();
                    _drivers.Id = int.Parse(reader.GetString(0));
                    _drivers.Name = reader.GetString(1).ToString();
                    _drivers.Phone = reader.GetString(2).ToString();
                    _drivers.Imei = reader.GetString(3).ToString();
                    _drivers.Patente = reader.GetString(4).ToString();
                    _drivers.Status = reader.GetString(5).ToString();
                    _drivers.Company = reader.GetString(6).ToString();
                    _drivers.Regdate = reader.GetString(7).ToString().Replace("/", "-");
                    _drivers.Lastaccess = reader.GetString(8).ToString().Replace("/", "-");
                    list.Add(_drivers);
                }
            }
            catch (MySqlException ex) { 
                Console.WriteLine(ex.Message.ToString()); 
            }

            return list;
        }
        public Task<List<string>> getFleet(string data)
        {
            return Task.Run(() =>
            {
                MySqlDataReader reader;
                List<string> list = new List<string>();

                string sql = "SELECT name,status,lat_src,lng_src,degrees_src,city FROM drivers ORDER BY id DESC";
                
                try
                {
                    MySqlConnection dbcon = base.conexion();
                    dbcon.Open();
                    MySqlCommand command = new MySqlCommand(sql, dbcon);

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if(reader.GetString(1) != "Eliminado")
                        {
                            list.Add(reader.GetString(0));
                            list.Add(reader.GetString(1));
                            list.Add(reader.GetDouble(2).ToString());
                            list.Add(reader.GetDouble(3).ToString());
                            list.Add(reader.GetInt32(4).ToString());
                            list.Add(reader.GetString(5));
                        }
                    }
                    return list;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex);
                    return list;
                }
            });
        }
    }
}
