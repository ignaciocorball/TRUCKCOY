using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
        public Task<DataTable> getFleet(string data)
        {
            return Task.Run(() =>
            {
                MySqlDataReader reader;
                DataTable list = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

                string sql = "SELECT name,status,lat_src,lng_src,degrees_src,city FROM drivers ORDER BY id DESC";
                
                try
                {
                    MySqlConnection dbcon = base.conexion();
                    dbcon.Open();
                    dataAdapter.SelectCommand = new MySqlCommand(sql, dbcon);
                    //MySqlCommand command = new MySqlCommand(sql, dbcon);
                    dataAdapter.Fill(list);
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
