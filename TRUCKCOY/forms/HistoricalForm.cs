using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TRUCKCOY.classes;

namespace TRUCKCOY.forms
{
    public partial class HistoricalForm : Form
    {
        int rowIndex;
        public HistoricalForm()
        {
            InitializeComponent();
        }

        private void HistoricalForm_Load(object sender, EventArgs e)
        {
            loadDgv();
            tmrDGVUpdater.Enabled = true;
            tmrDGVUpdater.Start();

            txtID.AutoSize = true;
            txtDriver.AutoSize = true;
            txtPhone.AutoSize = true;
            txtPatente.AutoSize = true;
            txtSrc.AutoSize = true;
            txtDest.AutoSize = true;
            txtDateFinish.AutoSize = true;
            txtDateIncome.AutoSize = true;
        }

        #region Frontend

        private void loadDgv()
        {
            /// <summary>
            /// Load DataGridView information
            /// </summary>

            Routes_Controller _ctrlRoutes = new Routes_Controller();
            dgvHistory.DataSource = _ctrlRoutes.query(null);

            if (dgvHistory.Rows.Count > 0)
            {
                txtCompany.Text = Properties.Settings.Default.Company;
                lblNoData.Visible = false;
                setRegistersCount();
            }
            else
            {
                lblNoData.Visible = true;
                setRegistersCount();
            }
        }
        private void setDGVStyles()
        {
            /// Validate Cell Status and change color
            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                string dataValidator = (string)dgvHistory.Rows[row.Index].Cells[8].Value;
                switch (dataValidator)
                {
                    case "En Tránsito":
                        dgvHistory.Rows[row.Index].Cells[8].Style.ForeColor = Color.LightSeaGreen;
                        break;
                    case "Exitoso":
                        dgvHistory.Rows[row.Index].Cells[8].Style.ForeColor = Color.LightSkyBlue;
                        break;
                    case "Cancelado":
                        dgvHistory.Rows[row.Index].Cells[8].Style.ForeColor = Color.DimGray;
                        break;
                }
                string dataValidator2 = (string)dgvHistory.Rows[row.Index].Cells[7].Value;
                if (dataValidator2 == "En proceso")
                {
                    dgvHistory.Rows[row.Index].Cells[7].Style.ForeColor = Color.LightSeaGreen;
                }
            }
        }

        private void dgvHistory_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            /// Add Eye header to dgv
            //if (e.RowIndex == -1 && e.ColumnIndex == 9)
            //{
            //    Image img = Properties.Resources.eye24x24;
            //    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            //    e.Graphics.DrawImage(img, e.CellBounds);
            //    e.Handled = true;
            //
            //}
        }
        private void dgvHistory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private void dgvHistory_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 11)
            {
                dgvHistory.Cursor = Cursors.Hand;
            }
        }
        private void dgvHistory_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9 || e.ColumnIndex == 10 || e.ColumnIndex == 11)
            {
                dgvHistory.Cursor = Cursors.Default;
            }
        }
        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 9: /// DETAILS BUTTON
                    if (e.RowIndex != -1)
                    {
                        if (picLoading.Visible == true)
                        {
                            txtID.Text = dgvHistory.Rows[e.RowIndex].Cells[0].Value.ToString();
                            txtDriver.Text = dgvHistory.Rows[e.RowIndex].Cells[1].Value.ToString();
                            txtPhone.Text = dgvHistory.Rows[e.RowIndex].Cells[5].Value.ToString();
                            txtPatente.Text = dgvHistory.Rows[e.RowIndex].Cells[2].Value.ToString();
                            txtSrc.Text = dgvHistory.Rows[e.RowIndex].Cells[3].Value.ToString();
                            txtDest.Text = dgvHistory.Rows[e.RowIndex].Cells[4].Value.ToString();
                            txtDateFinish.Text = dgvHistory.Rows[e.RowIndex].Cells[7].Value.ToString();
                            txtDateIncome.Text = dgvHistory.Rows[e.RowIndex].Cells[6].Value.ToString();
                            lblStatus.Text = dgvHistory.Rows[e.RowIndex].Cells[8].Value.ToString();

                            switch (lblStatus.Text)
                            {
                                case "En Tránsito":
                                    picStatus.Image = Properties.Resources.load_green;
                                    lblStatus.ForeColor = Color.LightSeaGreen;
                                    btnFinish.Visible = true;
                                    btnCancel.Visible = true;
                                    btnDrivers.Visible = false;
                                    btnUndo.Visible = false;
                                    break;
                                case "Exitoso":
                                    picStatus.Image = Properties.Resources.load_blue;
                                    lblStatus.ForeColor = Color.LightSkyBlue;
                                    btnFinish.Visible = false;
                                    btnCancel.Visible = false;
                                    btnDrivers.Visible = false;
                                    btnUndo.Visible = false;
                                    break;
                                case "Cancelado":
                                    picStatus.Image = Properties.Resources.load_gray;
                                    lblStatus.ForeColor = Color.DimGray;
                                    btnFinish.Visible = false;
                                    btnCancel.Visible = false;
                                    btnDrivers.Visible = false;
                                    btnUndo.Visible = false;
                                    break;
                            }
                            rowIndex = e.RowIndex;
                            picBanner.Visible = false;
                            picLoading.Image = Properties.Resources.loading_drivers;
                            ImageAnimator.Animate(picLoading.Image, null);
                            tmrClock.Enabled = true;
                            tmrClock.Start();
                        }
                        else
                        {
                            txtID.Text = dgvHistory.Rows[e.RowIndex].Cells[0].Value.ToString();
                            txtDriver.Text = dgvHistory.Rows[e.RowIndex].Cells[1].Value.ToString();
                            txtPhone.Text = dgvHistory.Rows[e.RowIndex].Cells[5].Value.ToString();
                            txtPatente.Text = dgvHistory.Rows[e.RowIndex].Cells[2].Value.ToString();
                            txtSrc.Text = dgvHistory.Rows[e.RowIndex].Cells[3].Value.ToString();
                            txtDest.Text = dgvHistory.Rows[e.RowIndex].Cells[4].Value.ToString();
                            txtDateFinish.Text = dgvHistory.Rows[e.RowIndex].Cells[7].Value.ToString();
                            txtDateIncome.Text = dgvHistory.Rows[e.RowIndex].Cells[6].Value.ToString();
                            lblStatus.Text = dgvHistory.Rows[e.RowIndex].Cells[8].Value.ToString();

                            switch (lblStatus.Text)
                            {
                                case "En Tránsito":
                                    picStatus.Image = Properties.Resources.load_green;
                                    lblStatus.ForeColor = Color.LightSeaGreen;
                                    btnFinish.Visible = true;
                                    btnCancel.Visible = true;
                                    btnDrivers.Visible = false;
                                    btnUndo.Visible = false;
                                    break;
                                case "Exitoso":
                                    picStatus.Image = Properties.Resources.load_blue;
                                    lblStatus.ForeColor = Color.LightSkyBlue;
                                    btnFinish.Visible = true;
                                    btnCancel.Visible = false;
                                    btnDrivers.Visible = false;
                                    btnUndo.Visible = false;
                                    break;
                                case "Cancelado":
                                    picStatus.Image = Properties.Resources.load_gray;
                                    lblStatus.ForeColor = Color.DimGray;
                                    btnFinish.Visible = false;
                                    btnCancel.Visible = false;
                                    btnDrivers.Visible = false;
                                    btnUndo.Visible = false;
                                    break;
                            }
                            rowIndex = e.RowIndex;
                        }

                    }
                    break;
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            txtID.Text = dgvHistory.Rows[rowIndex].Cells[1].Value.ToString();
            txtDriver.Text = dgvHistory.Rows[rowIndex].Cells[2].Value.ToString();
            txtSrc.Text = dgvHistory.Rows[rowIndex].Cells[3].Value.ToString();
            txtDest.Text = dgvHistory.Rows[rowIndex].Cells[4].Value.ToString();
            txtPhone.Text = dgvHistory.Rows[rowIndex].Cells[5].Value.ToString();
            txtCompany.Text = Properties.Settings.Default.Company;
            btnUndo.Visible = false;
        }

        private void txtDriver_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(txtDriver.Text, txtDriver.Font);
            txtDriver.Width = size.Width;
            txtDriver.Height = size.Height;
        }
        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(txtPhone.Text, txtPhone.Font);
            txtPhone.Width = size.Width;
            txtPhone.Height = size.Height;
        }
        private void txtCompany_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(txtCompany.Text, txtCompany.Font);
            txtCompany.Width = size.Width;
            txtCompany.Height = size.Height;
        }
        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(txtCity.Text, txtCity.Font);
            txtCity.Width = size.Width;
            txtCity.Height = size.Height;
        }
        private void txtPatente_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(txtCity.Text, txtCity.Font);
            txtCity.Width = size.Width;
            txtCity.Height = size.Height;
        }
        private void txtSrc_TextChanged(object sender, EventArgs e)
        {
            btnUndo.Visible = true;
        }
        private void txtDest_TextChanged(object sender, EventArgs e)
        {
            btnUndo.Visible = true;
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
                else { lblFleetStatus.Text = "No se encontraron registros Code: 11"; }

                lblFleetStatus.Text = "Mostrando " + rowCounter + " de " + rowCounter + " registros";

                // Cerrar la conexión
                databaseConnection.Close();

            }
            catch (Exception ex) { lblFleetStatus.Text = "No se encontraron registros Code: 11"; }
        }
        private void tmrDGVUpdater_Tick(object sender, EventArgs e)
        {
            if (dgvHistory.Rows.Count > 0)
            {
                setDGVStyles();
                tmrDGVUpdater.Stop();
                tmrDGVUpdater.Enabled = false;
            }
            else
            {
                if (tmrDGVUpdater.Interval > 15000)
                {
                    tmrDGVUpdater.Stop();
                    tmrDGVUpdater.Enabled = false;
                }
                else
                {
                    tmrDGVUpdater.Interval += 500;
                }
            }
        }
        private void tmrClock_Tick(object sender, EventArgs e)
        {
            picLoading.Visible = false;
            tmrClock.Enabled = false;
            tmrClock.Stop();
        }

        #endregion
        private void addMethod()
        {

            // Formulary
            txtID.Text = "";
            txtDriver.Text = "";
            txtPhone.Text = "";
            txtPatente.Text = "";
            txtSrc.Text = "";
            txtDest.Text = "";
            txtDateFinish.Text = "";
            txtDateIncome.Text = "";
            lblStatus.Text = "";


            btnSave.Visible = true;
            btnFinish.Visible = false;
            btnCancel.Visible = false;
            btnDrivers.Visible = true;
            btnUndo.Visible = false;


            if (picBanner.Visible)
            {
                // Animation
                picBanner.Visible = false;
                picLoading.Image = Properties.Resources.loading_drivers;
                ImageAnimator.Animate(picLoading.Image, null);
                tmrClock.Enabled = true;
                tmrClock.Start();
            }

        }
        private void saveMethod()
        {
            Routes_Controller _ctrlRoutes = new Routes_Controller();
            List<string> data = new List<string>();
            List<string> driverPosition = new List<string>();
            List<string> locationDest = new List<string>();

            // Get Driver Coordinates
            driverPosition.AddRange(_ctrlRoutes.getDriver("Elon Musk"));

            // Address source to Latitude & Longitude
            locationDest.AddRange(_ctrlRoutes.convertAddressToCoords("Coyhaique"));

            if (txtDest.Text == "")
            {
                if (locationDest.Count == 2)
                {
                    MessageBox.Show("Lat: " + locationDest[0] + "Lng: " + locationDest[1]);
                }
                else
                {
                    MessageBox.Show("Lista menor a 2 variables");
                }
            }
            else
            {
                MessageBox.Show("Porfavor, introduce la dirección de destino");
            }

            string id = null;
            string driver = txtDriver.Text;
            string source = txtSrc.Text;
            string destination = txtDest.Text;
            string city = "Coyhaique";
            string patente = txtPatente.Text;
            string phone = txtPhone.Text;
            string latitude_src = driverPosition[0];
            string longitude_src = driverPosition[1];
            string degrees_src = driverPosition[2];
            string latitude_dest = "";
            string longitude_dest = "";
            string orderincome = txtDateIncome.Text;
            string order_finished = null;
            string company = Properties.Settings.Default.Company;
            string status = "En Tránsito";

            data.Add(id);
            data.Add(driver);
            data.Add(source);
            data.Add(destination);
            data.Add(city);
            data.Add(patente);
            data.Add(phone);
            data.Add(latitude_src);
            data.Add(longitude_src);
            data.Add(degrees_src);
            data.Add(latitude_dest);
            data.Add(longitude_dest);
            data.Add(orderincome);
            data.Add(order_finished);
            data.Add(company);
            data.Add(status);

            //_ctrlRoutes.insertRoute(data);


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addMethod();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveMethod();
        }

    }
}


