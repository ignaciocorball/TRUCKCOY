using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace TRUCKCOY.classes
{
    class Vehicles_Controller : DBConnect
    {
        public List<Object> query(string data)
        {
            MySqlDataReader reader;
            List<Object> list = new List<object>();
            string sql;

            if (data == null)
            {
                sql = "SELECT id,name,ignition,temp,kms_today,alerts,location,speed,trips,kms_total,lastupdate,company,driver,lat,lng,deg,status FROM vehicles WHERE company = '"+Properties.Settings.Default.Company+"' ORDER BY id DESC";
            }
            else
            {
                sql = "SELECT id,name,ignition,temp,kms_today,alerts,location,speed,trips,kms_total,lastupdate,company,driver,lat,lng,deg,status FROM vehicles WHERE name LIKE '%"
                       + data + "%' OR driver LIKE '%"
                       + data + "%' OR status LIKE '%"
                       + data + "%' ORDER BY id DESC";
            }

            try
            {
                MySqlConnection dbcon = base.conexion();
                dbcon.Open();
                MySqlCommand command = new MySqlCommand(sql, dbcon);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string tempParsed = Convert.ToString(reader.GetInt32(3)) + "°C";


                    Vehicles _vehicles = new Vehicles();
                    _vehicles.Id =          int.Parse(reader.GetString(0));
                    _vehicles.Name =        reader.GetString(1);
                    _vehicles.Ignition =    reader.GetBoolean(2);
                    _vehicles.Temp =        reader.GetString(3) + " °C";
                    _vehicles.Kms_today =   reader.GetInt32(4);
                    _vehicles.Alerts =      reader.GetInt32(5);
                    _vehicles.Location =    reader.GetString(6);
                    _vehicles.Speed =       reader.GetString(7) + " Km/h";
                    _vehicles.Trips =       reader.GetInt32(8);
                    _vehicles.Kms_total =   reader.GetString(9) + " Kms";
                    _vehicles.Lastupdate =  reader.GetString(10).ToString().Replace("/", "-");
                    _vehicles.Company =     reader.GetString(11);
                    _vehicles.Driver =      reader.GetString(12);
                    _vehicles.Lat =         reader.GetDouble(13);
                    _vehicles.Lng =         reader.GetDouble(14);
                    _vehicles.Deg =         reader.GetFloat(15);
                    _vehicles.Status =      reader.GetString(16);
                    list.Add(_vehicles);  
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return list;
        }
    }
}
