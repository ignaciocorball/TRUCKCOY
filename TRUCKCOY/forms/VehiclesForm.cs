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
        Vehicles_Controller _ctrlVehicles = new Vehicles_Controller();

        public VehiclesForm()
        {
            InitializeComponent();
            loadMapSettings();
        }
        private void VehiclesForm_Load(object sender, EventArgs e)
        {
            LoadDGV();
            getVehiclesFeet();
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
        private void LoadDGV()
        {
            List<Vehicles> vehicles = new List<Vehicles>();
            dgvHistory.DataSource = _ctrlVehicles.query(null);


            if (dgvHistory.Rows.Count > 0)
            {
                lblNoData.Visible = false;
                pnlAddFleet.Visible = false;
            }
            else
            {
                lblNoData.Visible = true;
                pnlAddFleet.Visible = true;
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
                    string statusValidator = (string)dgvHistory.Rows[row.Index].Cells[9].Value;
                    switch (statusValidator)
                    {
                        case "Online":
                            dgvHistory.Rows[row.Index].Cells[9].Style.ForeColor = Color.LightSeaGreen;
                            break;
                        case "Offline":
                            dgvHistory.Rows[row.Index].Cells[9].Style.ForeColor = Color.LightCoral;
                            break;
                    }

                    /// Ignition Cells
                    if (this.dgvHistory.Columns.Contains("Encendido"))
                    {
                        if ((string)dgvHistory.Rows[row.Index].Cells[9].Value == "Online")
                        {
                            this.dgvHistory.Rows[row.Index].Cells[10].Value = Properties.Resources.ignition_on;
                        }
                        else
                        {
                            this.dgvHistory.Rows[row.Index].Cells[10].Value = Properties.Resources.ignition_off;
                        }
                    }
                }
            }
        }
        private void getVehiclesFeet()
        {
            /// SQL CONNECTION
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=truckcoy;SSL Mode=None";
            string query = "SELECT * FROM `drivers` WHERE `status` = 'Activo' ORDER BY `id` DESC";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                // Open connection
                databaseConnection.Open();
                // Execute query
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12) };
                        int degrees = Convert.ToInt32(row[12]);

                        /// Marker Personalized
                        // GMapOverlay points_ = new GMapOverlay("pointCollection");
                        // points_.Markers.Add(new GMapPointExpanded(new PointLatLng(reader.GetFloat(4), reader.GetFloat(5)), 10));
                        // gMapControl1.Overlays.Add(points_);

                        PointLatLng point = new PointLatLng(reader.GetFloat(9), reader.GetFloat(10));

                        Bitmap bmpmarker = (Bitmap)Image.FromFile("img/fleeticon_20x20.png");
                        Bitmap bmpMarkerRotated = RotateImage(bmpmarker, degrees);

                        GMapMarker marker = new GMarkerGoogle(point, bmpMarkerRotated);

                        GMapOverlay markers = new GMapOverlay("Markers");
                        markers.Markers.Add(marker);
                        gMapControl1.Overlays.Add(markers);
                    }
                    pnlAddFleet.Visible = false;
                }
                else { pnlAddFleet.Visible = true; }

                databaseConnection.Close();
            }
            catch (Exception) { 
                Console.WriteLine("No hay conexión con la base de datos"); 
            }
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
            if (e.RowIndex == -1 && e.ColumnIndex == 10)
            {
                Image img = Properties.Resources.ignition_on;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                e.Graphics.DrawImage(img, e.CellBounds);
                e.Handled = true;
            }
            /// Add Edit header to dgv
            if (e.RowIndex == -1 && e.ColumnIndex == 11)
            {
                Image img = Properties.Resources.edit;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                e.Graphics.DrawImage(img, e.CellBounds);
                e.Handled = true;
            }
            /// Add Trash header to dgv
            if (e.RowIndex == -1 && e.ColumnIndex == 12)
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
