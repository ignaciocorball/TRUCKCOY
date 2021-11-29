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
                sql = "SELECT id,name,destination_address,source_address,city,patente,phone,lat_src,lng_src,deg_src,lat_dest,lng_dest,order_income,order_finished,company,status FROM routes ORDER BY id DESC";
            }
            else
            {
                sql = "SELECT id,name,destination_address,source_address,city,patente,phone,lat_src,lng_src,deg_src,lat_dest,lng_dest,order_income,order_finished,company,status FROM routes WHERE name LIKE '%"
                       + data + "%' OR phone LIKE '%" 
                       + data + "%' OR source_address LIKE '%" 
                       + data + "%' OR status LIKE '%"
                       + data + "%' OR destination_address LIKE '%"
                       + data + "%' ORDER BY id DESC";
            }

            try
            {
                MySqlConnection dbcon = conexion();
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
                    _routes.LatSrc = reader.GetString(7).ToString();
                    _routes.LngSrc = reader.GetString(8).ToString();
                    _routes.DegSrc = reader.GetString(9).ToString();
                    _routes.LatDest = reader.GetString(10).ToString();
                    _routes.LngDest = reader.GetString(11).ToString();
                    _routes.OrderIncomeDate = reader.GetString(12).ToString().Replace("/", "-");
                    if(reader["order_finished"] != DBNull.Value)
                    {
                        _routes.OrderFinishedDate = reader.GetString(13).ToString().Replace("/", "-");
                    }
                    else
                    {
                        _routes.OrderFinishedDate = "En Proceso";
                    }
                    
                    _routes.Company = reader.GetString(14).ToString();
                    _routes.Status = reader.GetString(15).ToString();
                    list.Add(_routes);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return list;
        }

        public void insertRoute(List<string> data)
        {
            MySqlDataReader reader;

            MessageBox.Show(" [0]: " + data[0] +
                            " [1]: " + data[1] + 
                            " [2]: " + data[2] +
                            " [3]: " + data[3] + 
                            " [4]: " + data[4] + 
                            " [5]: " + data[5] + 
                            " [6]: " + data[6] + 
                            //" [7]: " + data[7] + 
                            //" [8]: " + data[8] + 
                            //" [9]: " + data[9] + 
                            //" [10]: " + data[10]+
                            //" [11]: " + data[11] +
                            " [12]: " + data[12] +
                            " [13]: " + data[13] +
                            " [14]: " + data[14] +
                            " [15]: " + data[15]);

            string sql;
            sql = "INSERT INTO `routes`(`id`, `name`, `destination_address`, `source_address`, `city`, `patente`, `phone`, `lat_src`, `lng_src`, `deg_src`, `lat_dest`, `lng_dest`, `order_income`, `order_finished`, `company`, `status`) " +
                "VALUES ('"+data[0]+ "','" + data[1] + "','" + data[2] + "','" + data[3] + 
                "','" + data[4] + "','" + data[5] + "','" + data[6] + "','" + data[7] + 
                "','" + data[8] +  "','" + data[9] + "','" + data[10] + "','" + data[11] + 
                "','" + data[12] + "','" + data[13] + "','" + data[14] + "','" + data[15] + "')";
            //
            //try
            //{
            //    MySqlConnection dbcon = conexion();
            //    dbcon.Open();
            //    MySqlCommand command = new MySqlCommand(sql, dbcon);
            //
            //    reader = command.ExecuteReader();
            //
            //    MessageBox.Show("Registro agregado exitosamente!");
            //    while (reader.Read())
            //    {
            //
            //    }
            //    dbcon.Close();
            //}
            //catch (MySqlException ex)
            //{
            //    Console.WriteLine(ex.Message.ToString());
            //}
        }

        public List<string> getDriver(string data)
        {
            MySqlDataReader reader;
            List<string> list = new List<string>();
            string sql;

            sql = "SELECT lat_src,lng_src,degrees_src FROM drivers WHERE name = '" + data + "'";

            try
            {
                MySqlConnection dbcon = base.conexion();
                dbcon.Open();
                MySqlCommand command = new MySqlCommand(sql, dbcon);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader.GetDouble(0).ToString());
                    list.Add(reader.GetDouble(1).ToString());
                    list.Add(reader.GetString(2).ToString());
                }   
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return list;
        }

        public List<string> convertAddressToCoords(string data)
        {
            List<string> list = new List<string>();

            // Get coords & return list



            return list;
        }
    }
}
