using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace TRUCKCOY.classes
{
    class Vehicles_Controller : DBConnect
    {
        public async Task<List<object>> query(string data)
        {
            MySqlDataReader reader;
            List<Object> list = new List<object>();
            string sql;

            if (data == null)
            {
                sql = "SELECT id,name,driver,ignition,temp,kms_today,kms_total,alerts,location,speed,trips,lastupdate,status FROM vehicles ORDER BY id DESC";
            }
            else
            {
                sql = "SELECT id,name,driver,ignition,temp,kms_today,kms_total,alerts,location,speed,trips,lastupdate,status FROM vehicles WHERE name LIKE '%"
                       + data + "%' OR driver LIKE '%"
                       + data + "%' OR status LIKE '%"
                       + data + "%' ORDER BY id DESC";
            }

            try
            {
                MySqlConnection dbcon = base.conexion();
                await dbcon.OpenAsync();
                MySqlCommand command = new MySqlCommand(sql, dbcon);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        Vehicles _vehicles = new Vehicles();
                        _vehicles.Id = int.Parse(reader.GetString(0));
                        _vehicles.Name = reader.GetString(1).ToString();
                        _vehicles.Driver = reader.GetString(2).ToString();
                        _vehicles.Ignition = bool.Parse(reader.GetString(3));
                        _vehicles.Temperature = int.Parse(reader.GetString(4));
                        _vehicles.Kms_today = int.Parse(reader.GetString(5));
                        _vehicles.Kms_total = int.Parse(reader.GetString(6));
                        _vehicles.Alerts = int.Parse(reader.GetString(7));
                        _vehicles.Location = reader.GetString(8).ToString();
                        _vehicles.Speed = int.Parse(reader.GetString(9));
                        _vehicles.Trips = int.Parse(reader.GetString(10));
                        _vehicles.Lastupdate = reader.GetString(11).ToString().Replace("/", "-");
                        _vehicles.Status = reader.GetString(12).ToString();
                        list.Add(_vehicles);
                    }
                    catch (Exception ex) { Console.WriteLine(ex); }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
            return list;
        }
    }
}
