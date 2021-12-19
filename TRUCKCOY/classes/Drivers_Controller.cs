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
        public Task<List<Object>> query(string data)
        {
            MySqlDataReader reader;
            List<Object> list = new List<object>();
            string sql;

            sql = "SELECT id,name,phone,imei,patente,status,company,regdate,lastaccess FROM drivers ORDER BY id DESC";
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
            });
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

        public Task<int> insertDriver(string name, string imei, string patente, string phone)
        {
            MySqlDataReader reader;
            List<Object> list = new List<object>();
            DateTime now = DateTime.Now;


            string imageName = PasswordGenerator(true, true, true, false, 7);
            string sqlcompare = "SELECT * FROM drivers WHERE imei ='" + imei + "' OR patente = '" + patente + "'";
            string sqlinsert = "INSERT INTO `drivers`(`id`, `name`, `phone`, `imei`, `patente`, `status`, `company`, `regdate`, `lastaccess`, `lat_src`, `lng_src`, `alt_src`, `degrees_src`, `city`, `img`) VALUES ('', '" + name + "', '+56 " + phone + "', '" + imei + "', '" + patente + "', 'Offline', 'TRUCKCOY', now(), now(), 0, 0, 0, 0, 'Coyhaique', 'TRUCKCOY_" + imageName+".png')";

            return Task.Run(() =>
            {
                try
                {
                    MySqlConnection dbcon = base.conexion();
                    dbcon.Open();
                    MySqlCommand command = new MySqlCommand(sqlcompare, dbcon);

                    reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            Console.WriteLine("El valor que se esta ingresando se encuentra en nuestra base de datos.");
                            return 0;
                        }
                        dbcon.Close();
                    }
                    dbcon.Close();

                    dbcon.Open();
                    command = new MySqlCommand(sqlinsert, dbcon);
                    reader = command.ExecuteReader();
                    return 1;

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error MySQL: " + ex);
                    return 2;
                }
            });
        }













        public string PasswordGenerator(bool lowerCase, bool upperCase, bool mumberic, bool specialCharacter, int length)
        {
            const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
            const string UPPER_CASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string NUMBERIC = "1234567890";
            const string SPECIAL_CHARACTER = @"~!@#$%^&*()+=-";

            char[] password = new char[length];
            string charSet = "";
            System.Random _random = new Random();
            if (lowerCase)
                charSet += LOWER_CASE;
            if (upperCase)
                charSet += UPPER_CASE;
            if (mumberic)
                charSet += NUMBERIC;
            if (specialCharacter)
                charSet += SPECIAL_CHARACTER;
            for (int i = 0; i < length; i++)
                password[i] = charSet[_random.Next(charSet.Length - 1)];
            return string.Join(null, password);
        }
    }
}
