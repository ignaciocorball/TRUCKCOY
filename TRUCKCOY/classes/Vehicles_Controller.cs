using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows;

namespace TRUCKCOY.classes
{
    class Vehicles_Controller : DBConnect
    {
        public Task<List<Object>> query(string data)
        {
            MySqlDataReader reader;
            List<Object> list = new List<object>();
            string sql;

            sql = "SELECT id,name,ignition,temp,kms_today,alerts,location,speed,trips,kms_total,lastupdate,company,driver,lat,lng,deg,status FROM vehicles WHERE company = '" + Properties.Settings.Default.Company + "' ORDER BY id DESC";

            return Task.Run(() =>
            {
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
                        _vehicles.Id = int.Parse(reader.GetString(0));
                        _vehicles.Name = reader.GetString(1);
                        _vehicles.Ignition = reader.GetBoolean(2);
                        _vehicles.Temp = reader.GetString(3) + " °C";
                        _vehicles.Kms_today = reader.GetInt32(4);
                        _vehicles.Alerts = reader.GetInt32(5);
                        _vehicles.Location = reader.GetString(6);
                        _vehicles.Speed = reader.GetString(7) + " Km/h";
                        _vehicles.Trips = reader.GetInt32(8);
                        _vehicles.Kms_total = reader.GetString(9) + " Kms";
                        _vehicles.Lastupdate = reader.GetString(10).ToString().Replace("/", "-");
                        _vehicles.Company = reader.GetString(11);
                        _vehicles.Driver = reader.GetString(12);
                        _vehicles.Lat = reader.GetDouble(13);
                        _vehicles.Lng = reader.GetDouble(14);
                        _vehicles.Deg = reader.GetFloat(15);
                        _vehicles.Status = reader.GetString(16);
                        list.Add(_vehicles);
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                return list;
            });
        }

        public Task<DataTable> getFleet(string data)
        {
            return Task.Run(() =>
            {
                DataTable list = new DataTable();
                list.Columns.Add("Id");
                list.Columns.Add("Name");
                list.Columns.Add("Ignition");
                list.Columns.Add("Temp");
                list.Columns.Add("Kms_today");
                list.Columns.Add("Alerts");
                list.Columns.Add("Location");
                list.Columns.Add("Speed");
                list.Columns.Add("Trips");
                list.Columns.Add("Kms_total");
                list.Columns.Add("Lastupdate");
                list.Columns.Add("Company");
                list.Columns.Add("Drivers");
                list.Columns.Add("Lat");
                list.Columns.Add("Lng");
                list.Columns.Add("Deg");
                list.Columns.Add("Status");

                try
                {
                    MySqlDataReader reader;
                    string sql = "SELECT `id`, `name`, `ignition`, `temp`, `kms_today`, `alerts`, `location`, `speed`, `trips`, `kms_total`, `lastupdate`, `company`, `driver`, `lat`, `lng`, `deg`, `status` FROM `vehicles` WHERE company = '"+Properties.Settings.Default.Company+"'";

                    MySqlConnection dbcon = conexion();
                    dbcon.Open();
                    MySqlCommand command = new MySqlCommand(sql, dbcon);

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Rows.Add(new Object[] { reader.GetString(0),
                                                     reader.GetString(1),
                                                     reader.GetString(3),
                                                     reader.GetString(4),
                                                     reader.GetString(5),
                                                     reader.GetString(6),
                                                     reader.GetString(7),
                                                     reader.GetString(8),
                                                     reader.GetString(9),
                                                     reader.GetString(10),
                                                     reader.GetString(11),
                                                     reader.GetString(12),
                                                     reader.GetString(13),
                                                     reader.GetString(14),
                                                     reader.GetString(15),
                                                     reader.GetString(16),
                                       });
                    }

                    return list;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                    return list;
                }
            });
        }

    }
}
