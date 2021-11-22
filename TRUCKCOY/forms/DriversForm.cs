using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRUCKCOY.classes;

namespace TRUCKCOY.forms
{
    public partial class DriversForm : Form
    {
        DateTime now = DateTime.Now;
        int rowCounter = 0;
        public DriversForm()
        {
            InitializeComponent();
        }
        private void DriversForm_Load(object sender, EventArgs e)
        {
            loadDgv();
            getDriversProfileImagesAsync();
        }
        private void loadDgv()
        {
            /// <summary>
            /// Load DataGridView information
            /// </summary>
            //List<Drivers> list = new List<Drivers>();
            Drivers_Controller _ctrlDrivers = new Drivers_Controller();
            dgvHistory.DataSource = _ctrlDrivers.query(null);

            if (dgvHistory.Rows.Count > 0)
            {
                Bitmap imgEdit = new Bitmap(Properties.Resources.edit);
                Bitmap imgDelete = new Bitmap(Properties.Resources.trash_small);

                dgvHistory.Rows[0].Cells[9].Value = imgEdit;
                dgvHistory.Rows[0].Cells[10].Value = imgDelete;

                lblNoData.Visible = false;
                setRegistersCount();
            }
            else
            {
                lblNoData.Visible = true;
                setRegistersCount();
            }
        }
        private void setColors()
        {
            /// Validate Cell Status and change color
            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                string dataValidator = (string)dgvHistory.Rows[row.Index].Cells[8].Value;
                switch (dataValidator)
                {
                    case "Activo":
                        dgvHistory.Rows[row.Index].Cells[8].Style.ForeColor = Color.LightSeaGreen;
                        break;
                    case "Inactivo":
                        dgvHistory.Rows[row.Index].Cells[8].Style.ForeColor = Color.LightSkyBlue;
                        break;
                    case "Eliminado":
                        dgvHistory.Rows[row.Index].Cells[8].Style.ForeColor = Color.DimGray;
                        break;
                }
            }
        }

        /// <summary>
        /// Frontend development
        /// </summary>
        #region Frontend
        // DataGridView
        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 9: /// EDIT BUTTON
                    if (e.RowIndex != -1)
                    {
                        if (picLoading.Visible == true)
                        {
                            txtID.Text = dgvHistory.Rows[e.RowIndex].Cells[0].Value.ToString();
                            txtRegdate.Text = dgvHistory.Rows[e.RowIndex].Cells[1].Value.ToString();
                            txtName.Text = dgvHistory.Rows[e.RowIndex].Cells[2].Value.ToString();
                            txtPhone.Text = dgvHistory.Rows[e.RowIndex].Cells[3].Value.ToString();
                            txtImei.Text = dgvHistory.Rows[e.RowIndex].Cells[4].Value.ToString();
                            txtPatente.Text = dgvHistory.Rows[e.RowIndex].Cells[5].Value.ToString();
                            txtLastaccess.Text = dgvHistory.Rows[e.RowIndex].Cells[7].Value.ToString();
                            lblStatus.Text = dgvHistory.Rows[e.RowIndex].Cells[8].Value.ToString();

                            switch (lblStatus.Text)
                            {
                                case "Activo":
                                    picStatus.Image = Properties.Resources.load_green;
                                    lblStatus.ForeColor = Color.LightSeaGreen;
                                    break;
                                case "Inactivo":
                                    picStatus.Image = Properties.Resources.load_blue;
                                    lblStatus.ForeColor = Color.LightSkyBlue;
                                    break;
                                case "Eliminado":
                                    picStatus.Image = Properties.Resources.load_gray;
                                    lblStatus.ForeColor = Color.DimGray;
                                    break;
                            }

                            picBanner.Visible = false;
                            picLoading.Image = Properties.Resources.loading_drivers;
                            ImageAnimator.Animate(picLoading.Image, null);
                            tmrClock.Enabled = true;
                            tmrClock.Start();
                        }
                        else
                        {
                        
                            txtID.Text = dgvHistory.Rows[e.RowIndex].Cells[0].Value.ToString();
                            txtRegdate.Text = dgvHistory.Rows[e.RowIndex].Cells[1].Value.ToString();
                            txtName.Text = dgvHistory.Rows[e.RowIndex].Cells[2].Value.ToString();
                            txtPhone.Text = dgvHistory.Rows[e.RowIndex].Cells[3].Value.ToString();
                            txtImei.Text = dgvHistory.Rows[e.RowIndex].Cells[4].Value.ToString();
                            txtPatente.Text = dgvHistory.Rows[e.RowIndex].Cells[5].Value.ToString();
                            txtLastaccess.Text = dgvHistory.Rows[e.RowIndex].Cells[7].Value.ToString();
                            lblStatus.Text = dgvHistory.Rows[e.RowIndex].Cells[8].Value.ToString();

                            switch (lblStatus.Text)
                            {
                                case "Activo":
                                    picStatus.Image = Properties.Resources.load_green;
                                    lblStatus.ForeColor = Color.LightSeaGreen;
                                    break;
                                case "Inactivo":
                                    picStatus.Image = Properties.Resources.load_blue;
                                    lblStatus.ForeColor = Color.LightSkyBlue;
                                    break;
                                case "Eliminado":
                                    picStatus.Image = Properties.Resources.load_gray;
                                    lblStatus.ForeColor = Color.DimGray;
                                    break;
                            }
                        }

                    }
                    break;
                case 10: /// DELETE BUTTON
                    if (e.RowIndex != -1)
                    {
                        MessageBox.Show("Button Delete [Row:" + (e.RowIndex + 1) + "Column:" + (e.ColumnIndex) + "]");
                    }
                    break;
                case 11: /// CHECKBOX BUTTON
                    if (e.RowIndex != -1)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvHistory.Rows[e.RowIndex].Cells[11];
                        chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
                    }
                    break;
            }
        }
        private void dgvHistory_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 11)
            {
                dgvHistory.Cursor = Cursors.Hand;
            }

            setColors();
        }
        private void dgvHistory_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 11)
            {
                dgvHistory.Cursor = Cursors.Default;
            }
        }
        private void dgvHistory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        // Buttons, Textbox, Inputs, Labels, Picturebox...
        private void chkMain_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[11];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
            }
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            /// Validate Cell Status and change color
            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                string dataValidator = (string)dgvHistory.Rows[row.Index].Cells[8].Value;
                switch (dataValidator)
                {
                    case "Activo":
                        dgvHistory.Rows[row.Index].Cells[8].Style.ForeColor = Color.LightSeaGreen;
                        break;
                    case "Inactivo":
                        dgvHistory.Rows[row.Index].Cells[8].Style.ForeColor = Color.LightSkyBlue;
                        break;
                    case "Eliminado":
                        dgvHistory.Rows[row.Index].Cells[8].Style.ForeColor = Color.DimGray;
                        break;
                }
            }
        }
        #endregion


        /// <summary>
        /// Backend development
        /// </summary>
        #region Backend
        private void tmrClock_Tick(object sender, EventArgs e)
        {
             picLoading.Visible = false;
             tmrClock.Enabled = false;
             tmrClock.Stop();
        }
        private void dgvHistory_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            /// Add Trash header to dgv
            if (e.RowIndex == -1 && e.ColumnIndex == 10)
            {
                Image img = Properties.Resources.trash2;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                e.Graphics.DrawImage(img, e.CellBounds);
                e.Handled = true;
            }

        }

        private void setRegistersCount()
        {
            /// SQL CONNECTION
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=truckcoy;SSL Mode=None";
            string query = "SELECT * FROM `drivers` WHERE `company` = 'truckcoy' ORDER BY `id` DESC";
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            MySqlCommand dbcom = new MySqlCommand(query, dbcon);
            dbcom.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                dbcon.Open();
                /// Execute query
                reader = dbcom.ExecuteReader();
                /// Row Counter
                if (reader.HasRows) { while (reader.Read()) { rowCounter++; } }
                /// Counter equals to 0
                else { lblFleetStatus.Text = "No se encontraron registros Code: 11"; }
                /// Show rows data counter in label Fleet Status
                lblFleetStatus.Text = "Mostrando " + rowCounter + " de " + rowCounter + " registros";
                dbcon.Close();
            }
            catch (Exception ex)
            {
                lblFleetStatus.Text = "Mostrando " + rowCounter + " de " + rowCounter + " registros";
            }
        }
        private void getDriversProfileImagesAsync()
        {
            var directoryPath = @"C:\temp";
            var fileName = @"\test.jpg";
            var url = "https://cdn.discordapp.com/attachments/458291463663386646/592779619212460054/Screenshot_20190624-201411.jpg?query&with.dots";

            DownloadImage(directoryPath, fileName, url);
        }
        private void DownloadImage(string directoryPath, string fileName, string url)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFileAsync(new Uri(url), directoryPath + fileName);
            }
        }
        #endregion
    }
}
