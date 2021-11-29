using TRUCKCOY.classes;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.Defaults;
using System.Globalization;
using System.Data;
using TRUCKCOY.forms.resforms;

namespace TRUCKCOY.forms
{
    public partial class DashboardForm : Form
    {
        WorkOnItForm workOnIt;
        public DashboardForm()
        {
            InitializeComponent();
            loadMapSettings();
            getVehiclesFeet();
            setFrontEnd();

        }
        /// <summary>
        /// Frontend Events
        /// </summary>
        #region Frontend

        /// Buttons Events
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
        private void label4_Click(object sender, EventArgs e)
        {
            workOnIt = new WorkOnItForm() { };
            workOnIt.Show();
        }
        private void label12_Click(object sender, EventArgs e)
        {
            workOnIt = new WorkOnItForm() { };
            workOnIt.Show();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            workOnIt = new WorkOnItForm() { };
            workOnIt.Show();
        }
        private void picRegFleet_Click(object sender, EventArgs e)
        {
            workOnIt = new WorkOnItForm() { };
            workOnIt.Show();
        }
        private void DetailsMain_Click(object sender, EventArgs e)
        {

        }

        private void DeleteMain_Click(object sender, EventArgs e)
        {

        }

        /// DataGridView Events
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
        private void clear_Click(object sender, EventArgs e)
        {
            dgvHistory.Rows.Clear();
        }
        private void checkBoxMain_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[9];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
            }
        }

        /// Data Frontend Management
        private void setFrontEnd()
        {

            /// Set up History Data Grid View
            loadDGV();
            /// Set up Cartesian Chart
            cartesianChartSetUp();
            /// Set up Solid Gauge Chart
            solidGaugeSetUp();
            /// Labels background transparent 
            #region Transparent Images with labels
            lblActive.Parent = picActive;
            lblActive.Location = new System.Drawing.Point(0, 0);
            lblActive.ForeColor = Color.White;
            lblActive.TextAlign = ContentAlignment.MiddleCenter;

            lblInactive.Parent = picInactive;
            lblInactive.Location = new System.Drawing.Point(0, 0);
            lblInactive.ForeColor = Color.White;
            lblInactive.TextAlign = ContentAlignment.MiddleCenter;

            lblTotal.Parent = picTotal;
            lblTotal.Location = new System.Drawing.Point(0, 0);
            lblTotal.ForeColor = Color.White;
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            #endregion

        }
        private void loadDGV()
        {
            Routes_Controller _ctrlRoutes = new Routes_Controller();
            dgvHistory.DataSource = _ctrlRoutes.query(null);

            /// Zoom Buttons
            //for (int i = 0; i < dgvHistory.Columns.Count; i++)
            //    if (dgvHistory.Columns[i] is DataGridViewImageColumn)
            //    {
            //        ((DataGridViewImageColumn)dgvHistory.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
            //    }

            if (dgvHistory.Rows.Count > 0)
            {
                lblNoData.Visible = false;
            }
            else
            {
                lblNoData.Visible = true;
            }
        }

        #endregion

        /// <summary>
        /// Backend Events
        /// </summary>
        #region Backend

        private string getDateByNumber(double num)
        {
            int num2 = Convert.ToInt32(num);
            DateTime date = new DateTime(2021, num2, 01);
            string month_name = date.ToString("MMMM", new CultureInfo("es"));
            string month_name2 = char.ToUpper(month_name[0]) + month_name.Substring(1);
            return month_name2;
        }
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
            panelStats.AutoScroll = true;

        }
        private void addMarker(PointLatLng pointToAdd, GMarkerGoogleType markerType = GMarkerGoogleType.arrow)
        {
            /// Marker Personalized
            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(new GMapPointExpanded(new PointLatLng(Properties.Settings.Default.lat_coy, Properties.Settings.Default.lng_coy), 10));
            gMapControl1.Overlays.Add(markers);

        }
        private void getVehiclesFeet()
        {
            /// SQL CONNECTION
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=truckcoy;SSL Mode=None";
            string query = "SELECT * FROM `drivers` WHERE `status` = 'Online' AND `company` = '"+Properties.Settings.Default.Company+"' ORDER BY `id` DESC";
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
                }
                else
                {
                    overlayGMap.Visible = true;
                    lblRegError.Visible = true;
                }

                // Cerrar la conexión
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                overlayGMap.Visible = true;
                lblRegError.Visible = true;
            }
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
        private void solidGaugeSetUp()
        {

            /// Solid Gauge Chart Set up

            // solidGauge1.HighFontSize = 20;
            // solidGauge1.ForeColor = Color.FromArgb(30, 96, 164);
            // solidGauge1.Uses360Mode = true;
            // solidGauge1.From = 0;
            // solidGauge1.To = 100;
            // solidGauge1.Value = Math.Round(77.7,1);

            /// Graph Gradient
            
            // solidGauge1.Base.LabelsVisibility = Visibility.Hidden;
            // solidGauge1.Base.GaugeActiveFill = new System.Windows.Media.LinearGradientBrush
            // {
            //     GradientStops = new System.Windows.Media.GradientStopCollection {
            //     new System.Windows.Media.GradientStop(System.Windows.Media.Colors.DodgerBlue,.2),
            //     new System.Windows.Media.GradientStop(System.Windows.Media.Colors.AliceBlue,1),
            //     }
            // };
            // solidGauge1.LabelFormatter = val => solidGauge1.Value + "%";
            
        }
        private void cartesianChartSetUp()
        {
            cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                new LineSeries
                {
                    AreaLimit = -10,
                    Title = "$",
                    LineSmoothness = 0.6,
                    PointForeground = System.Windows.Media.Brushes.AliceBlue,
                    DataLabels = true,
                    Values = new ChartValues<ObservablePoint>
                    {
                        /// Historical Income Money Per Year
                                         // x y
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

            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                LabelFormatter = val => val + "K",
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection(new double[] { 4 }),
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86))
                }
            });

            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                LabelFormatter = val => getDateByNumber(val),
                Separator = new Separator
                {
                    Step = 11,
                    StrokeThickness = 1,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection(new double[] { 4 }),
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 79, 86))
                }
            });
        }


        #endregion
    }
}
