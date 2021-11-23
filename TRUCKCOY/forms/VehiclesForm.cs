using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRUCKCOY.classes;

namespace TRUCKCOY.forms
{
    public partial class VehiclesForm : Form
    {
        /// <summary>
        /// Data and controllers
        /// </summary>

        public VehiclesForm()
        {
            InitializeComponent();
            loadMapSettings();
        }
        private void VehiclesForm_Load(object sender, EventArgs e)
        {
            LoadDGV();
            //getVehiclesFeet();
            tmrDGVUpdater.Enabled = true;
            tmrDGVUpdater.Start();
        }

        /// <summary>
        /// Backend
        /// </summary>
        #region Backend
        private void loadMapSettings()
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.RoutesEnabled = true;
            gMapControl1.PolygonsEnabled = true;
            gMapControl1.ShowCenter = false;
            gMapControl1.Position = new PointLatLng(Properties.Settings.Default.lat_coy, Properties.Settings.Default.lng_coy);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 13;
            gMapControl1.AutoScroll = true;

            /// Scroll Config
            panelMap.AutoScroll = true;
        }
        private async Task LoadDGV()
        {
            // #111 HERE LAG FORMULARY FIX IT SOON
            Vehicles_Controller _ctrlVehicles = new Vehicles_Controller();
            dgvHistory.DataSource = _ctrlVehicles.query(null);

            if (dgvHistory.Rows.Count < 1)
            {
                lblNoData.Visible = true;
                pnlAddFleet.Visible = true;
            }
            else
            {
                lblNoData.Visible = false;
                pnlAddFleet.Visible = false;
            }
        }
        private void setDGVStyles()
        {
            if (dgvHistory.Rows.Count > 0)
            {
                /// Validate Cell Status and change color
                foreach (DataGridViewRow row in dgvHistory.Rows)
                {
                    /// Status Cells
                    string statusValidator = (string)dgvHistory.Rows[row.Index].Cells[10].Value;
                    switch (statusValidator)
                    {
                        case "Online":
                            dgvHistory.Rows[row.Index].Cells[10].Style.ForeColor = Color.LightSeaGreen;
                            break;
                        case "Offline":
                            dgvHistory.Rows[row.Index].Cells[10].Style.ForeColor = Color.DimGray;
                            break;
                    }

                    /// Ignition Cells
                    if (this.dgvHistory.Columns.Contains("Encendido"))
                    {
                        if ((string)dgvHistory.Rows[row.Index].Cells[10].Value == "Online")
                        {
                            this.dgvHistory.Rows[row.Index].Cells[11].Value = Properties.Resources.ignition_on;
                        }
                        else
                        {
                            this.dgvHistory.Rows[row.Index].Cells[11].Value = Properties.Resources.ignition_off;
                        }
                    }
                }
            }
        }
        private void getVehiclesFeet()
        {
            try
            {
                /// SQL CONNECTION
                //string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=truckcoy;SSL Mode=None";
                //string query = "SELECT * FROM `vehicles` WHERE `company` = '"+Properties.Settings.Default.Company+"' ORDER BY `id` DESC";
                //MySqlConnection dbCon = new MySqlConnection(connectionString);
                //MySqlCommand dbCom = new MySqlCommand(query, dbCon);
                //MySqlDataReader reader;
                //dbCom.CommandTimeout = 60;
                ///// Open connection
                //dbCon.Open();

                //using (reader = dbCom.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        string[] row = { reader.GetString(0),   // ID         (int)
                //                         reader.GetString(1),   // Name       (string)
                //                         reader.GetString(2),   // Ignition   (bool)
                //                         reader.GetString(3),   // Temp       (int)
                //                         reader.GetString(4),   // Kms_today  (int)
                //                         reader.GetString(5),   // Alerts     (int)
                //                         reader.GetString(6),   // Location   (string)
                //                         reader.GetString(7),   // Speed      (int) 
                //                         reader.GetString(8),   // Trips      (int) 
                //                         reader.GetString(9),   // Kms_total  (int)
                //                         reader.GetString(10),  // Lastupdate (timestamp)
                //                         reader.GetString(11),  // Company    (string)
                //                         reader.GetString(12),  // Driver     (string)
                //                         reader.GetString(13),  // Latitude   (double)
                //                         reader.GetString(14),  // Longitude  (double)
                //                         reader.GetString(15),  // Degrees    (float)
                //                         reader.GetString(16),  // Status     (string)
                //        };
                //        int degrees = Convert.ToInt32(row[15]);
                //        PointLatLng point = new PointLatLng(reader.GetFloat(13), reader.GetFloat(14));
                //        Bitmap bmpmarker = (Bitmap)Properties.Resources.taxi_20x20;
                //        Bitmap bmpMarkerRotated = RotateImage(bmpmarker, degrees);
                //        GMapMarker marker = new GMarkerGoogle(point, bmpMarkerRotated);
                //        GMapOverlay markers = new GMapOverlay("Markers");
                //
                //        markers.Markers.Add(marker);
                //        gMapControl1.Overlays.Add(markers);
                //    }
                //}
                //dbCon.Close();
            }
            catch (MySqlException ex){ MessageBox.Show("No hay conexión con la base de datos"); }
        }
        public string getAddressByCoords(double lat, double lng)
        {
            /// Get Address by latitude and longitude
            ObjectRoot AddressObject = getAddress(lat, lng);
            string[] full_address = AddressObject.display_name.Split(',');
            string vehicleAddress = (full_address[1] + " #" + full_address[0] + ", " + full_address[2] + ".");
            return vehicleAddress;
        }
        private Bitmap RotateImage(Bitmap bmp, float angle)
        {
            Bitmap rotatedImage = new Bitmap(bmp.Width, bmp.Height);
            rotatedImage.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                /// Set the rotation point to the center in the matrix
                g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
                /// Rotate
                g.RotateTransform(angle);
                /// Restore rotation point in the matrix
                g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
                /// Draw the image on the bitmap
                g.DrawImage(bmp, new System.Drawing.Point(0, 0));
            }

            return rotatedImage;
        }
        public static ObjectRoot getAddress(double lat, double lon)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            webClient.Headers.Add("Referer", "http://www.microsoft.com");
            var jsonData = webClient.DownloadData("http://nominatim.openstreetmap.org/reverse?format=json&lat=" + lat + "&lon=" + lon);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ObjectRoot));
            ObjectRoot AddressObject = (ObjectRoot)ser.ReadObject(new MemoryStream(jsonData));
            return AddressObject;
        }
        private void dgvHistory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        private void tmrUpdater_Tick(object sender, EventArgs e)
        {
            if(dgvHistory.Rows.Count > 0)
            {
                setDGVStyles();
                tmrDGVUpdater.Stop();
                tmrDGVUpdater.Enabled = false;
            }
            else
            {
                if(tmrDGVUpdater.Interval > 15000)
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
        #endregion

        /// <summary>
        /// Frontend
        /// </summary>
        #region Frontend
        private void dgvHistory_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            /// Add Ignition image to dgv
            //if(e.ColumnIndex == 10 && e.RowIndex > -1)
            //{
            //    foreach (DataGridViewRow row in dgvHistory.Rows)
            //    {
            //        string dataValidator = (string)dgvHistory.Rows[row.Index].Cells[11].Value;
            //        switch (dataValidator)
            //        {
            //            case "Online":
            //                Image img = Properties.Resources.ignition_on;
            //                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            //                e.Graphics.DrawImage(img, e.CellBounds);
            //                e.Handled = true;
            //                break;
            //            case "Offline":
            //                Image img2 = Properties.Resources.ignition_off;
            //                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            //                e.Graphics.DrawImage(img2, e.CellBounds);
            //                e.Handled = true;
            //                break;
            //        }
            //    }
            //}
            /// Add Edit header to dgv
            if (e.RowIndex == -1 && e.ColumnIndex == 11)
            {
                Image img = Properties.Resources.ignition_on;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                e.Graphics.DrawImage(img, e.CellBounds);
                e.Handled = true;
            }
            /// Add Edit header to dgv
            if (e.RowIndex == -1 && e.ColumnIndex == 12)
            {
                Image img = Properties.Resources.edit;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                e.Graphics.DrawImage(img, e.CellBounds);
                e.Handled = true;
            }
            /// Add Trash header to dgv
            if (e.RowIndex == -1 && e.ColumnIndex == 13)
            {
                Image img = Properties.Resources.trash2;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                e.Graphics.DrawImage(img, e.CellBounds);
                e.Handled = true;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom = 1;
            gMapControl1.Position = new PointLatLng(Properties.Settings.Default.lat_coy, Properties.Settings.Default.lng_coy);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 13;
            gMapControl1.AutoScroll = true;
            gMapControl1.ReloadMap();
        }
        private void btnTerrain_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleTerrainMap;
            btnSatellite.Image = Properties.Resources.sat_off;
            btnNormal.Image = Properties.Resources.normal_off;
            btnTerrain.Image = Properties.Resources.terr_on;
        }
        private void btnNormal_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            btnTerrain.Image = Properties.Resources.terr_off;
            btnSatellite.Image = Properties.Resources.sat_off;
            btnNormal.Image = Properties.Resources.normal_on;
        }
        private void btnSatellite_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleHybridMap;
            btnNormal.Image = Properties.Resources.normal_off;
            btnTerrain.Image = Properties.Resources.terr_off;
            btnSatellite.Image = Properties.Resources.sat_on;
        }

        #endregion

    }
}
