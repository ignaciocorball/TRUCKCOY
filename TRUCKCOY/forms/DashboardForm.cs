using TRUCKCOY.classes;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TRUCKCOY.forms
{
    public partial class DashboardForm : Form
    {
        HistoryForm hform;
        public DashboardForm()
        {
            InitializeComponent();
            loadMapSettings();
            getVehiclesFeet();
            setFrontEnd();
        }


        #region Frontend
        //#-> Buttons Events
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
        private void btnSatellite_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleHybridMap;
            btnNormal.Image = Properties.Resources.normal_off;
            btnTerrain.Image = Properties.Resources.terr_off;
            btnSatellite.Image = Properties.Resources.sat_on;
        }
        private void btnNormal_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            btnTerrain.Image = Properties.Resources.terr_off;
            btnSatellite.Image = Properties.Resources.sat_off;
            btnNormal.Image = Properties.Resources.normal_on;
        }
        private void btnTerrain_Click(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleTerrainMap;
            btnSatellite.Image = Properties.Resources.sat_off;
            btnNormal.Image = Properties.Resources.normal_off;
            btnTerrain.Image = Properties.Resources.terr_on;
        }
        private void picRegFleet_Click(object sender, EventArgs e)
        {

        }

        //$-> FrontEnd 
        private void setFrontEnd()
        {
            //ttNoFleet.SetToolTip(this.picRegFleet, "No encontramos registros de flota vehicular, porfavor añadelos haciendo click en el botón :)");

            //-> Load Form History
            hform = new HistoryForm() { TopLevel = false, Dock = DockStyle.Top, Name = "formHistory"};
            panelHistory.Controls.Add(hform);
            hform.Visible = true;
        }
        private void add_Click(object sender, EventArgs e)
        {
            for(int x = 0; x < 10; x++)
            {
                HistoryForm hf = new HistoryForm() { TopLevel = false, Dock = DockStyle.Top, Name = "p"+(x+5) };
                //hf.lblID.Text = 111;
                panelHistory.Controls.Add(hf);
                hf.Visible = true;
            }
        }
        #endregion

        #region Backend
        //#-> Private methods
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

            // Scroll Config
            panelStats.AutoScroll = true;
            //vScrollBar1.Visible = (panelStats.VerticalScroll.Visible == true) ? false : true;
            //vScrollBar1.ThumbColor = Color.FromArgb(0, 113, 188);

        }
        private void addMarker(PointLatLng pointToAdd, GMarkerGoogleType markerType = GMarkerGoogleType.arrow)
        {
            // Marker Personalized
            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(new GMapPointExpanded(new PointLatLng(Properties.Settings.Default.lat_coy, Properties.Settings.Default.lng_coy), 10));
            gMapControl1.Overlays.Add(markers);

        }
        //#-> Storage Access
        private void getVehiclesFeet()
        {
            // SQL CONNECTION
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=truckcoy;SSL Mode=None";
            string query = "SELECT * FROM `routes` WHERE `company` = 'truckcoy' ORDER BY `id` DESC";
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
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10) };
                        int degrees = Convert.ToInt32(row[7]);
                        // Marker Personalized
                        //GMapOverlay points_ = new GMapOverlay("pointCollection");
                        //points_.Markers.Add(new GMapPointExpanded(new PointLatLng(reader.GetFloat(4), reader.GetFloat(5)), 10));
                        //gMapControl1.Overlays.Add(points_);
                        PointLatLng point = new PointLatLng(reader.GetFloat(4), reader.GetFloat(5));

                        Bitmap bmpmarker = (Bitmap)Image.FromFile("img/fleeticon_20x20.png");
                        Bitmap bmpMarkerRotated = RotateImage(bmpmarker, degrees);

                        GMapMarker marker = new GMarkerGoogle(point, bmpMarkerRotated);

                        GMapOverlay markers = new GMapOverlay("Markers");
                        markers.Markers.Add(marker);
                        gMapControl1.Overlays.Add(markers);
                    }

                }
                else
                {
                    overlayGMap.Visible = true;
                }

                // Cerrar la conexión
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Mostrar cualquier excepción
                MessageBox.Show(ex.Message);
                overlayGMap.Visible = true;
            }
        }
        private Bitmap RotateImage(Bitmap bmp, float angle)
        {
            Bitmap rotatedImage = new Bitmap(bmp.Width, bmp.Height);
            rotatedImage.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                // Set the rotation point to the center in the matrix
                g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
                // Rotate
                g.RotateTransform(angle);
                // Restore rotation point in the matrix
                g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
                // Draw the image on the bitmap
                g.DrawImage(bmp, new Point(0, 0));
            }

            return rotatedImage;
        }
        //-> Async Methods
        #endregion
    }
}
