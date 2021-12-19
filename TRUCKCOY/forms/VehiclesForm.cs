using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
        GMapOverlay markers = new GMapOverlay("Markers");
        public VehiclesForm()
        {
            InitializeComponent();
            loadMapSettings();
            panelMap.Paint += dropShadow;
            panelStats.Paint += dropShadow;
            panel13.Paint += dropShadow;
        }

        private void VehiclesForm_Load(object sender, EventArgs e)
        {
            LoadDGV();
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
            gMapControl1.MinZoom = 10;
            gMapControl1.MaxZoom = 16;
            gMapControl1.Zoom = 13;
            gMapControl1.AutoScroll = true;

            /// Scroll Config
            panelMap.AutoScroll = true;
            tmrLoadMap.Enabled = true;
            tmrLoadMap.Start();
            picLogo.Parent = circularProgressBar1;
            picLogo.Location = new Point(30,30);

        }
        private async Task LoadDGV()
        {
            List<Vehicles> vehicles = new List<Vehicles>();
            dgvHistory.DataSource = await _ctrlVehicles.query(null);

            if (dgvHistory.Rows.Count > 0)
            {
                getVehiclesFeet();
                picLoading2.Visible = false;
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
        private async Task getVehiclesFeet()
        {
            Vehicles_Controller _ctrlDrivers = new Vehicles_Controller();
            DataTable list = await _ctrlDrivers.getFleet(null);

            try
            {
                /// Clear olds markers to update news
                markers.Markers.Clear();
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    /// If status is Online, add marker to collections
                    if (list.Rows[i][15].ToString() == "Online")
                    {
                        float degrees = float.Parse((list.Rows[i][14].ToString()));

                        PointLatLng point = new PointLatLng(Convert.ToDouble(list.Rows[i][12]), Convert.ToDouble(list.Rows[i][13]));

                        Bitmap bmpmarker = (Bitmap)Image.FromFile("img/fleeticon_20x20.png");
                        Bitmap bmpMarkerRotated = RotateImage(bmpmarker, degrees);

                        GMapMarker marker = new GMarkerGoogle(point, bmpMarkerRotated);
                        marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                        marker.ToolTipText = Environment.NewLine +
                                             "Nombre: " + list.Rows[i][11] + Environment.NewLine +
                                             "Viajes: " + list.Rows[i][7] + Environment.NewLine +
                                             "Kilometros hoy: " + list.Rows[i][3] + Environment.NewLine;

                        markers.Markers.Add(marker);
                    }
                }
                gMapControl1.Overlays.Add(markers);

                double currentZoom = gMapControl1.Zoom;
                gMapControl1.Zoom = currentZoom - 0.01;
                gMapControl1.Zoom = currentZoom + 0.01;
                pnlAddFleet.Visible = false;
                picLogo.Visible = false;
                circularProgressBar1.Visible = false;
                picBanner1.Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
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

        private void reloadMap_Tick(object sender, EventArgs e)
        {
            getVehiclesFeet();
        }

        private void tmrLoadMap_Tick(object sender, EventArgs e)
        {
            if(circularProgressBar1.Value < 100)
            {
                circularProgressBar1.Value += 4;

            }
            else
            {
                tmrLoadMap.Stop();
                tmrLoadMap.Enabled = false;
            }
        }


        private void dropShadow(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Color[] shadow = new Color[3];
            shadow[0] = Color.FromArgb(181, 181, 181);
            shadow[1] = Color.FromArgb(195, 195, 195);
            shadow[2] = Color.FromArgb(211, 211, 211);
            Pen pen = new Pen(shadow[0]);
            using (pen)
            {
                foreach (Panel p in panel.Controls.OfType<Panel>())
                {
                    Point pt = p.Location;
                    pt.Y += p.Height;
                    for (var sp = 0; sp < 3; sp++)
                    {
                        pen.Color = shadow[sp];
                        e.Graphics.DrawLine(pen, pt.X, pt.Y, pt.X + p.Width - 1, pt.Y);
                        pt.Y++;
                    }
                }
            }
        }
    }
}
