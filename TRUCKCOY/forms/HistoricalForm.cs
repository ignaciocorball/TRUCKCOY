using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRUCKCOY.classes;

namespace TRUCKCOY.forms
{
    public partial class HistoricalForm : Form
    {
        public HistoricalForm()
        {
            InitializeComponent();
        }

        private void HistoricalForm_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        #region Frontend

        private void loadDataGridView()
        {
            /// <summary>
            /// Load DataGridView information
            /// </summary>

            List<Routes> list = new List<Routes>();
            Routes_Controller _ctrlRoutes = new Routes_Controller();
            dgvHistory.DataSource = _ctrlRoutes.query(null);

            Bitmap imgEdit, imgDelete;
            imgEdit = new Bitmap(Properties.Resources.edit);
            imgDelete = new Bitmap(Properties.Resources.trash2);

            setRegistersCount();

            //dgvHistory.Rows[0].Cells[14].Value = imgEdit;
            //dgvHistory.Rows[0].Cells[15].Value = imgDelete;
            //dgvHistory.Rows[0].Cells[16].Value = false;
        }

        #endregion

        #region backend
        private void setRegistersCount()
        {
            /// SQL CONNECTION
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=truckcoy;SSL Mode=None";
            string query = "SELECT * FROM `routes` WHERE `company` = 'truckcoy' ORDER BY `id` DESC";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            int rowCounter = 0;

            try
            {
                // Open connection
                databaseConnection.Open();
                // Execute query
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows) { while (reader.Read()) { rowCounter++; } }
                else{ lblFleetStatus.Text = "No se encontraron registros Code: 11"; }

                lblFleetStatus.Text = "Mostrando " + rowCounter + " de " + rowCounter +" registros";
                
                // Cerrar la conexión
                databaseConnection.Close();

            } catch (Exception ex) { lblFleetStatus.Text = "No se encontraron registros Code: 11"; }
        }
        #endregion



    }
}


