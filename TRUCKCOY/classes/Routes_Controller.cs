using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

namespace TRUCKCOY.classes
{
    class Routes_Controller : DBConnect
    {
        public List<Object> query(string data)
        {
            MySqlDataReader reader;
            List<Object> list = new List<object>();
            string sql;

            if (data == null)
            {
                sql = "SELECT id,name,destination_address,source_address,city,patente,phone,lat,lng,alt,degrees,order_income_date,order_finished_date,company,status FROM routes ORDER BY id DESC";
            }
            else
            {
                sql = "SELECT id,destination_address,source_address,city,patente,phone,lat,lng,alt,degrees,order_income_date,order_finished_date,company,status FROM routes WHERE name LIKE '%"
                       + data + "%' OR phone LIKE '%" 
                       + data + "%' OR patente LIKE '%" 
                       + data + "%' OR status LIKE '%"
                       + data + "%' OR city LIKE '%"
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
                    Routes _routes = new Routes();
                    _routes.Id = int.Parse(reader.GetString(0));
                    _routes.Name = reader.GetString(1).ToString();
                    _routes.Dest = reader.GetString(2).ToString();
                    _routes.Src = reader.GetString(3).ToString();
                    _routes.City = reader.GetString(4).ToString();
                    _routes.Patente = reader.GetString(5).ToString();
                    _routes.Phone = reader.GetString(6).ToString();
                    _routes.CurrentLat = reader.GetString(7).ToString();
                    _routes.CurrentLng = reader.GetString(8).ToString();
                    _routes.CurrentAlt = reader.GetString(9).ToString();
                    _routes.CurrentDeg = reader.GetString(10).ToString();
                    _routes.OrderIncomeDate = reader.GetString(11).ToString().Replace("/", "-");
                    _routes.OrderFinishedDate = reader.GetString(12).ToString().Replace("/", "-");
                    _routes.Company = reader.GetString(13).ToString();
                    _routes.Status = reader.GetString(14).ToString();
                    list.Add(_routes);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return list;
        }
    }
}
