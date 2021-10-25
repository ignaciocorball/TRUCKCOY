using TRUCKCOY.classes;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Windows.Forms.DataVisualization.Charting;
using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.Defaults;

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

            //-> Load Form History
            //hform = new HistoryForm() { TopLevel = false, Dock = DockStyle.Top, Name = "formHistory"};
            //panelStats.Controls.Add(hform);
            //hform.Visible = true;


            // Set up History Travels Data grid view


            // Set up Panel Chart 

            cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                new LineSeries
                {
                    Title = "$",
                    LineSmoothness = 0.6,
                    PointForeground = System.Windows.Media.Brushes.AliceBlue,
                    Values = new ChartValues<ObservablePoint>
                    {
                                           //x y
                        new ObservablePoint(1,100),
                        new ObservablePoint(2,125),
                        new ObservablePoint(3,146),
                        new ObservablePoint(4,177),
                        new ObservablePoint(5,157),
                        new ObservablePoint(6,197),
                        new ObservablePoint(7,205),
                        new ObservablePoint(8,186),
                        new ObservablePoint(9,242),
                        new ObservablePoint(10,236),
                        new ObservablePoint(11,260),
                        new ObservablePoint(12,275),
                    }
                }
            };
            /*
            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "",
                Labels = new[] { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" }
            });
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "",
                LabelFormatter = value => "$" + value,

            });

            cartesianChart1.Series.Add(new ColumnSeries
            {
                Values = new ChartValues<double> { 150, 125, 176, 242},
                DataLabels = true,
                LabelPoint = point => point.Y + "K",
            }); */

            // Panel 4
            solidGauge1.Uses360Mode = true;
            solidGauge1.From = 0;
            solidGauge1.To = 100;
            solidGauge1.Value = 75;
            // Graph Gradient
            solidGauge1.Base.LabelsVisibility = System.Windows.Visibility.Hidden;
            solidGauge1.Base.GaugeActiveFill = new System.Windows.Media.LinearGradientBrush {  GradientStops = new System.Windows.Media.GradientStopCollection {
                new System.Windows.Media.GradientStop(System.Windows.Media.Colors.RoyalBlue,.2),
                new System.Windows.Media.GradientStop(System.Windows.Media.Colors.DodgerBlue,1),
                }
            };

            // Transparent Images with labels
            lblActive.Parent = picActive;
            lblActive.Location = new Point(-2,0);
            lblActive.ForeColor = Color.White;

            lblInactive.Parent = picInactive;
            lblInactive.Location = new Point(-2, 0);
            lblInactive.ForeColor = Color.White;

            lblTotal.Parent = picTotal;
            lblTotal.Location = new Point(-2, 0);
            lblTotal.ForeColor = Color.White;
        }
        #endregion

        #region Backend
        // Google Map
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

        // History Data Grid View

        #endregion


        private void add_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string monthToUpper = now.ToString("MMM").ToUpper();

            for (int x = 0; x < 30; x++)
            {
                // Array list to add data
                string[] historyDGV = new string[]
                {
                ""+(x+1)+"",now.ToString("dd-"+monthToUpper+"-yyyy HH:mm:ss tt"),"Carlos Lopez","AB XX 11","Psje Rio Claro #2596","Teniente vidal #456","En Proceso","Delete","Details","Select"
                };

                // Add array to Data Grid View
                dgvHistory.Rows.Add(historyDGV);

                // Validate Cell Status and change color
                string dataValidator = dgvHistory.Rows[x].Cells[6].Value.ToString();
                if (dataValidator == "En Proceso")
                {
                    dgvHistory.Rows[x].Cells[6].Style.ForeColor = Color.CornflowerBlue;
                }

            }

            // Sort Data Grid View by ID
            // dgvHistory.Sort(dgvHistory.Columns["id"], ListSortDirection.Descending);
        }
        private void clear_Click(object sender, EventArgs e)
        {
            dgvHistory.Rows.Clear();
        }

        private void dgvHistory_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dgvHistory.Columns[e.ColumnIndex].Name;

            if (colname != "select" && colname != "delete" && colname != "details0")
            {
                dgvHistory.Cursor = Cursors.Default;
            }
            else
            {
                dgvHistory.Cursor = Cursors.Hand;
            }
        }
    }
}
