
namespace TRUCKCOY.forms
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel13 = new System.Windows.Forms.Panel();
            this.vScrollBar1 = new Siticone.Desktop.UI.WinForms.SiticoneVScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.PictureBox();
            this.btnSatellite = new System.Windows.Forms.PictureBox();
            this.btnNormal = new System.Windows.Forms.PictureBox();
            this.btnTerrain = new System.Windows.Forms.PictureBox();
            this.lblTittlePanel = new System.Windows.Forms.Label();
            this.panelContainerTittle = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.overlayGMap = new System.Windows.Forms.Panel();
            this.picRegFleet = new System.Windows.Forms.PictureBox();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.panelStats = new System.Windows.Forms.Panel();
            this.panelHistory = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSatellite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTerrain)).BeginInit();
            this.panelContainerTittle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.overlayGMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRegFleet)).BeginInit();
            this.panelStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel13
            // 
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(0, 41);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(31, 665);
            this.panel13.TabIndex = 7;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.AutoRoundedCorners = true;
            this.vScrollBar1.BorderColor = System.Drawing.Color.Transparent;
            this.vScrollBar1.BorderRadius = 6;
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.FillColor = System.Drawing.Color.White;
            this.vScrollBar1.HoverState.Parent = null;
            this.vScrollBar1.InUpdate = false;
            this.vScrollBar1.LargeChange = 30;
            this.vScrollBar1.Location = new System.Drawing.Point(859, 0);
            this.vScrollBar1.MouseWheelBarPartitions = 30;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.PressedState.Parent = this.vScrollBar1;
            this.vScrollBar1.ScrollbarSize = 15;
            this.vScrollBar1.Size = new System.Drawing.Size(15, 706);
            this.vScrollBar1.TabIndex = 10;
            this.vScrollBar1.ThumbColor = System.Drawing.Color.Gainsboro;
            this.vScrollBar1.ThumbSize = 250F;
            this.vScrollBar1.Visible = false;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.lblTittlePanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 41);
            this.panel1.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.85714F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.14286F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Controls.Add(this.btnRefresh, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSatellite, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNormal, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTerrain, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(537, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(303, 26);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.Image = global::TRUCKCOY.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(279, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(21, 20);
            this.btnRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.TabStop = false;
            // 
            // btnSatellite
            // 
            this.btnSatellite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSatellite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSatellite.Image = global::TRUCKCOY.Properties.Resources.sat_off;
            this.btnSatellite.Location = new System.Drawing.Point(196, 3);
            this.btnSatellite.Name = "btnSatellite";
            this.btnSatellite.Size = new System.Drawing.Size(77, 20);
            this.btnSatellite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSatellite.TabIndex = 13;
            this.btnSatellite.TabStop = false;
            // 
            // btnNormal
            // 
            this.btnNormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNormal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNormal.Image = global::TRUCKCOY.Properties.Resources.normal_on;
            this.btnNormal.Location = new System.Drawing.Point(113, 3);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(77, 20);
            this.btnNormal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNormal.TabIndex = 14;
            this.btnNormal.TabStop = false;
            // 
            // btnTerrain
            // 
            this.btnTerrain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTerrain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTerrain.Image = global::TRUCKCOY.Properties.Resources.terr_off;
            this.btnTerrain.Location = new System.Drawing.Point(28, 3);
            this.btnTerrain.Name = "btnTerrain";
            this.btnTerrain.Size = new System.Drawing.Size(79, 20);
            this.btnTerrain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnTerrain.TabIndex = 15;
            this.btnTerrain.TabStop = false;
            // 
            // lblTittlePanel
            // 
            this.lblTittlePanel.AutoSize = true;
            this.lblTittlePanel.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTittlePanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(38)))), ((int)(((byte)(55)))));
            this.lblTittlePanel.Location = new System.Drawing.Point(33, 9);
            this.lblTittlePanel.Name = "lblTittlePanel";
            this.lblTittlePanel.Size = new System.Drawing.Size(68, 23);
            this.lblTittlePanel.TabIndex = 0;
            this.lblTittlePanel.Text = "PANEL";
            // 
            // panelContainerTittle
            // 
            this.panelContainerTittle.Controls.Add(this.pictureBox1);
            this.panelContainerTittle.Controls.Add(this.overlayGMap);
            this.panelContainerTittle.Controls.Add(this.gMapControl1);
            this.panelContainerTittle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContainerTittle.Location = new System.Drawing.Point(31, 41);
            this.panelContainerTittle.Name = "panelContainerTittle";
            this.panelContainerTittle.Size = new System.Drawing.Size(828, 298);
            this.panelContainerTittle.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(0, 271);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(815, 27);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // overlayGMap
            // 
            this.overlayGMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.overlayGMap.BackColor = System.Drawing.Color.Transparent;
            this.overlayGMap.Controls.Add(this.picRegFleet);
            this.overlayGMap.Location = new System.Drawing.Point(689, 3);
            this.overlayGMap.Name = "overlayGMap";
            this.overlayGMap.Size = new System.Drawing.Size(120, 30);
            this.overlayGMap.TabIndex = 5;
            this.overlayGMap.Visible = false;
            // 
            // picRegFleet
            // 
            this.picRegFleet.BackColor = System.Drawing.Color.Transparent;
            this.picRegFleet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRegFleet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picRegFleet.Image = global::TRUCKCOY.Properties.Resources.reg_fleet;
            this.picRegFleet.Location = new System.Drawing.Point(0, 0);
            this.picRegFleet.Name = "picRegFleet";
            this.picRegFleet.Size = new System.Drawing.Size(120, 30);
            this.picRegFleet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRegFleet.TabIndex = 0;
            this.picRegFleet.TabStop = false;
            // 
            // gMapControl1
            // 
            this.gMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(0, 0);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(815, 298);
            this.gMapControl1.TabIndex = 3;
            this.gMapControl1.Zoom = 0D;
            // 
            // panelStats
            // 
            this.panelStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStats.AutoScroll = true;
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.panelStats.Controls.Add(this.panelHistory);
            this.panelStats.Location = new System.Drawing.Point(32, 340);
            this.panelStats.MaximumSize = new System.Drawing.Size(1926, 600);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(819, 366);
            this.panelStats.TabIndex = 13;
            // 
            // panelHistory
            // 
            this.panelHistory.AutoScroll = true;
            this.panelHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHistory.Location = new System.Drawing.Point(0, 0);
            this.panelHistory.Name = "panelHistory";
            this.panelHistory.Size = new System.Drawing.Size(819, 366);
            this.panelHistory.TabIndex = 27;
            this.panelHistory.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panelHistory_ControlAdded);
            this.panelHistory.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.panelHistory_ControlRemoved);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(874, 706);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelContainerTittle);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.vScrollBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(874, 706);
            this.Name = "DashboardForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "DashboardForm";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSatellite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTerrain)).EndInit();
            this.panelContainerTittle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.overlayGMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picRegFleet)).EndInit();
            this.panelStats.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel13;
        private Siticone.Desktop.UI.WinForms.SiticoneVScrollBar vScrollBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox btnRefresh;
        private System.Windows.Forms.PictureBox btnSatellite;
        private System.Windows.Forms.PictureBox btnNormal;
        private System.Windows.Forms.PictureBox btnTerrain;
        private System.Windows.Forms.Label lblTittlePanel;
        private System.Windows.Forms.Panel panelContainerTittle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel overlayGMap;
        private System.Windows.Forms.PictureBox picRegFleet;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panelHistory;
    }
}