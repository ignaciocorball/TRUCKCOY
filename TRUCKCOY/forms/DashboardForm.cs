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
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace TRUCKCOY.forms
{
    public partial class DashboardForm : Form
    {
        WorkOnItForm workOnIt;
        public DashboardForm()
        {
            InitializeComponent();
            loadMapSettings();
            setFrontEnd();
            getVehiclesFeet();
            tmrDGVUpdater.Enabled = true;
            tmrDGVUpdater.Start();
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
            lblActive.Location = new Point(-1, -1);
            lblActive.ForeColor = Color.White;
            lblActive.TextAlign = ContentAlignment.MiddleCenter;

            lblInactive.Parent = picInactive;
            lblInactive.Location = new Point(-1, -1);
            lblInactive.ForeColor = Color.White;
            lblInactive.TextAlign = ContentAlignment.MiddleCenter;

            lblTotal.Parent = picTotal;
            lblTotal.Location = new Point(-1, -1);
            lblTotal.ForeColor = Color.White;
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            #endregion


        }
        private async Task loadDGV()
        {
            Routes_Controller _ctrlRoutes = new Routes_Controller();
            dgvHistory.DataSource = await _ctrlRoutes.query(null);

            if (dgvHistory.Rows.Count > 0)
            {
                lblNoData.Visible = false;
            }
            else
            {
                lblNoData.Visible = true;
            }
        }
        private void setDGVStyles()
        {
            /// Validate Cell Status and change color
            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                string dataValidator = (string)dgvHistory.Rows[row.Index].Cells[7].Value;
                switch (dataValidator)
                {
                    case "En Tránsito":
                        dgvHistory.Rows[row.Index].Cells[7].Style.ForeColor = Color.LightSeaGreen;
                        break;
                    case "Exitoso":
                        dgvHistory.Rows[row.Index].Cells[7].Style.ForeColor = Color.LightSkyBlue;
                        break;
                    case "Cancelado":
                        dgvHistory.Rows[row.Index].Cells[7].Style.ForeColor = Color.DimGray;
                        break;
                }
            }
        }
        /// <summary>
        /// Maps Settings
        /// </summary>
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
        private async Task getVehiclesFeet()
        {
            Drivers_Controller _ctrlDrivers = new Drivers_Controller();
            DataTable list = await _ctrlDrivers.getFleet(null);

            if(list.Rows.Count > 0)
            {
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    string Name = list.Rows[i][0].ToString();
                    string Status = list.Rows[i][1].ToString();
                    double Latitude = Convert.ToDouble(list.Rows[i][2]);
                    double Longitude = Convert.ToDouble(list.Rows[i][3]);
                    int Degrees = Convert.ToInt32(list.Rows[i][4]);
                    string City = list.Rows[i][5].ToString();

                    PointLatLng point = new PointLatLng(Latitude, Longitude);
                    Bitmap bmpmarker = (Bitmap)Image.FromFile("img/fleeticon_20x20.png");
                    Bitmap bmpMarkerRotated = RotateImage(bmpmarker, Degrees);
                    GMapMarker marker = new GMarkerGoogle(point, bmpMarkerRotated);
                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    marker.ToolTipText = System.Environment.NewLine + 
                                         "Nombre: " + Name + System.Environment.NewLine +
                                         "Estado: " + Status + System.Environment.NewLine +
                                         "Ciudad: " + City + System.Environment.NewLine;


                    GMapOverlay markers = new GMapOverlay("Markers");
                    markers.Markers.Add(marker);
                    gMapControl1.Overlays.Add(markers);
                    overlayGMap.Visible = false;
                    lblRegError.Visible = false;
                }
                gMapControl1.Zoom = 12;
                gMapControl1.Zoom = 13;
                picMaps.Visible = false;
            }
            else
            {
                overlayGMap.Visible = true;
                lblRegError.Visible = true;
                picMaps.Visible = false;
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
        private void tmrDGVUpdater_Tick(object sender, EventArgs e)
        {
            if (dgvHistory.Rows.Count > 0)
            {
                setDGVStyles();
                picLoading.Visible = false;
                tmrDGVUpdater.Stop();
                tmrDGVUpdater.Enabled = false;
            }
            else
            {
                if (tmrDGVUpdater.Interval > 10000)
                {
                    picLoading.Visible = false;
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
    }
}
