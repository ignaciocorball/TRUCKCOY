using System;
using System.Drawing;
using System.Windows.Forms;
using TRUCKCOY.forms;
using TRUCKCOY.forms.resforms;

namespace TRUCKCOY
{
    public partial class mainForm : Form
    {
        #region Forms and Collections
        DashboardForm     dform = new DashboardForm() { TopLevel = false, TopMost = true, Dock = DockStyle.Fill, Visible = true };
        HistoricalForm    hform;
        DriversForm       drform;
        NotificationsForm notform = new NotificationsForm() { TopLevel = false, TopMost = true, Dock = DockStyle.Fill, Visible = true };
        ProfilePopupForm  ppForm = new ProfilePopupForm() { TopLevel = false, TopMost = true, Dock = DockStyle.Fill, Visible = true };
        int[]             formsInitialized = { 1, 0, 0, 0, 0, 0 };
        #endregion
        public mainForm()
        {
            InitializeComponent();
            getDateTime();
        }
        private void mainForm_Load(object sender, EventArgs e)
        {
            panelContainer.Controls.Add(dform);
            pnlProfile.Controls.Add(ppForm);
            pnlNotification.Controls.Add(notform);
        }


        /// <summary>
        /// Backend Methods
        /// </summary>
        #region BackEnd
        private void getDateTime()
        {
            // Date & Time 
            DateTime currentDate = DateTime.Now;
            string monthToUpper = currentDate.ToString("MMM").ToUpper();

            if(currentDate.ToString("dd." + monthToUpper + ".yyyy") != lblDate.Text)
            {
                lblDate.Text = currentDate.ToString("dd." + monthToUpper + ".yyyy");
                lblTime.Text = currentDate.ToString("HH:mm:ss tt");
            }
            else
            {
                lblTime.Text = currentDate.ToString("HH:mm:ss tt");
            }
        }
        private void tmrSecond_Tick(object sender, EventArgs e)
        {
            getDateTime();
        }
        private void tmrLoadNavBar_Tick(object sender, EventArgs e)
        {
            if(panelNavBar.Width < 250)
            {
                panelNavBar.Width += 5;
                divisorLine1.Width += 5;
                divisorLine2.Width += 5;
            }
            else
            {
                tmrLoadNavBar.Enabled = false;
                tmrLoadNavBar.Stop();
            }
        }
        private void tmrHideNavBar_Tick(object sender, EventArgs e)
        {
            if (panelNavBar.Width > 60)
            {
                panelNavBar.Width -= 5;
                divisorLine1.Width -= 5;
                divisorLine2.Width -= 5;
            }
            else
            {
                tmrHideNavBar.Enabled = false;
                tmrHideNavBar.Stop();
            }
        }
        private void hideNavButtons()
        {
            btnDashboard.Image = Properties.Resources.dashboard_off;
            btnEvents.Image = Properties.Resources.schedule_off;
            btnDrivers.Image = Properties.Resources.drivers_off;
            btnMaps.Image = Properties.Resources.maps_off;
            btnStats.Image = Properties.Resources.temp_off;
            lblHome.ForeColor = Color.FromArgb(128, 128, 128);
            lblHistory.ForeColor = Color.FromArgb(128, 128, 128);
            lblDrivers.ForeColor = Color.FromArgb(128, 128, 128);
            lblStats.ForeColor = Color.FromArgb(128, 128, 128);
            lblMaps.ForeColor = Color.FromArgb(128, 128, 128);
        }
        private void selectNavButtons(int num)
        {
            switch (num)
            {
                case 0: // Form Dashboard

                    // FrontEnd
                    hideNavButtons();
                    hideChildOpenForms(0);
                    lblHome.ForeColor = Color.CornflowerBlue;

                    // Add childForm
                    dform.Visible = true;

                    // Variables
                    btnDashboard.Image = Properties.Resources.dashboard_on;
                    Properties.Settings.Default.navButtonSelected = 0;

                    break;
                case 1: // Form Orders List

                    // FrontEnd
                    hideNavButtons();
                    hideChildOpenForms(1);
                    lblHistory.ForeColor = Color.CornflowerBlue;
                    hform = new HistoricalForm() { TopLevel = false, TopMost = true, Dock = DockStyle.Fill, Visible = false, Opacity = 0 };
                    btnEvents.Image = Properties.Resources.schedule_on;

                    // Add childForm
                    panelContainer.Controls.Add(hform);
                    hform.Visible = true;

                    // Variables 
                    formsInitialized[1] = 1;
                    Properties.Settings.Default.navButtonSelected = 1;

                    break;
                case 2:  // Form Drivers

                    // FrontEnd
                    hideNavButtons();
                    hideChildOpenForms(2);
                    lblDrivers.ForeColor = Color.CornflowerBlue;

                    drform = new DriversForm() { TopLevel = false, TopMost = true, Dock = DockStyle.Fill, Visible = false, Opacity = 0 };
                    btnDrivers.Image = Properties.Resources.drivers_on;

                    // Add childForm
                    panelContainer.Controls.Add(drform);
                    drform.Visible = true;

                    // Variables
                    formsInitialized[2] = 1;
                    Properties.Settings.Default.navButtonSelected = 2;

                    break;
                case 3:  // Form Maps
                    hideNavButtons();
                    btnMaps.Image = Properties.Resources.maps_on;
                    lblMaps.ForeColor = Color.CornflowerBlue;

                    Properties.Settings.Default.navButtonSelected = 3;
                    break;
                case 4:  // Form Stats
                    hideNavButtons();
                    btnStats.Image = Properties.Resources.temp_on;
                    lblStats.ForeColor = Color.CornflowerBlue;
                    Properties.Settings.Default.navButtonSelected = 4;

                    break;
                case 5:  // Form 
                    // do something
                    break;
                case 6:  // Form 
                    // do something
                    break;
                case 7:  // Form 
                    // do something
                    break;
            }
        }
        private void hideChildOpenForms(int buttonID)
        {
            if(formsInitialized[0] == 1)
            {
                dform.Visible = false;
            }
            if (formsInitialized[1] == 1)
            {
                hform.Visible = false;
            }
            if (formsInitialized[2] == 1)
            {
                drform.Visible = false;
            }
            if (formsInitialized[3] == 1)
            {
                // add more forms
            }
            if (formsInitialized[4] == 1)
            {
                // add more forms
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
                g.DrawImage(bmp, new System.Drawing.Point(0, 0));
            }

            return rotatedImage;
        }
        #endregion

        /// <summary>
        /// Frontend Events
        /// </summary>
        #region FrontEnd
        private void btnProfile_Click(object sender, EventArgs e)
        {
            switch (pnlProfile.Visible)
            {
                case true:
                    pnlProfile.Visible = false;
                    break;
                case false:
                    pnlNotification.Visible = false;
                    pnlProfile.Visible = true;
                    break;
            }
        }
        private void btnNotification_Click(object sender, EventArgs e)
        {
            switch (pnlNotification.Visible)
            {
                case true:
                    pnlNotification.Visible = false;
                    break;
                case false:
                    pnlProfile.Visible = false;
                    pnlNotification.Visible = true;
                    break;
            }
        }
        private void btnExpand_Click(object sender, EventArgs e)
        {
            /// Rotate button image
            Bitmap bmpExpand = (Bitmap)btnExpand.Image;
            Bitmap bmpExpandRotated = RotateImage(bmpExpand, 180);
            btnExpand.Image = bmpExpandRotated;

            if (Width > 950)
            {
                // Without Animation
                if (panelNavBar.Width == 60)
                {
                    panelNavBar.Width = 190;
                    divisorLine1.Width = 170;
                    divisorLine2.Width = 170;
                }
                else if (panelNavBar.Width == 190)
                {
                    panelNavBar.Width = 60;
                    divisorLine1.Width = 40;
                    divisorLine2.Width = 40;
                }
            }
            else
            {
                // With Animation
                if (panelNavBar.Width == 60)
                {
                    tmrLoadNavBar.Enabled = true;
                    tmrLoadNavBar.Start();
                }
                else if (panelNavBar.Width == 190)
                {
                    tmrHideNavBar.Enabled = true;
                    tmrHideNavBar.Start();
                }
            }
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            selectNavButtons(0);
        }
        private void btnHistory_Click(object sender, EventArgs e)
        {
            selectNavButtons(1);
        }
        private void btnDrivers_Click(object sender, EventArgs e)
        {
            selectNavButtons(2);
        }
        private void btnMaps_Click(object sender, EventArgs e)
        {
            selectNavButtons(3);
        }
        private void btnStats_Click(object sender, EventArgs e)
        {
            selectNavButtons(4);
        }
        private void lblHome_Click(object sender, EventArgs e)
        {
            btnDashboard_Click(sender, e);
        }
        private void lblHistory_Click(object sender, EventArgs e)
        {
            btnHistory_Click(sender, e);
        }
        private void lblDrivers_Click(object sender, EventArgs e)
        {
            btnDrivers_Click(sender, e);
        }
        private void lblMaps_Click(object sender, EventArgs e)
        {
            btnMaps_Click(sender, e);
        }
        private void lblStats_Click(object sender, EventArgs e)
        {
            btnStats_Click(sender, e);
        }
        private void btnLogo_Click(object sender, EventArgs e)
        {
            // Redirect to main page
        }
        private void txtSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text == "Buscar...") { 
                txtSearch.Text = ""; 
            }
            else{  }
            
        }
        private void txtSearch_MouseLeave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Buscar...";
                lblDate.Focus();
            }
        }

        private void panel11_MouseEnter(object sender, EventArgs e)
        {
            panel11.BackColor = Color.IndianRed;
            btnLogout.Image = Properties.Resources.logout_w;
            lblLogout.ForeColor = Color.White;
        }

        private void panel11_MouseLeave(object sender, EventArgs e)
        {
            panel11.BackColor = Color.White;
            btnLogout.Image = Properties.Resources.logout;
            lblLogout.ForeColor = Color.Firebrick;
        }

        private void btnLogout_MouseEnter(object sender, EventArgs e)
        {
            panel11.BackColor = Color.IndianRed;
            btnLogout.Image = Properties.Resources.logout_w;
            lblLogout.ForeColor = Color.White;
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            panel11.BackColor = Color.White;
            btnLogout.Image = Properties.Resources.logout;
            lblLogout.ForeColor = Color.Firebrick;
        }

        private void lblLogout_MouseEnter(object sender, EventArgs e)
        {
            panel11.BackColor = Color.IndianRed;
            btnLogout.Image = Properties.Resources.logout_w;
            lblLogout.ForeColor = Color.White;
        }

        private void lblLogout_MouseLeave(object sender, EventArgs e)
        {
            panel11.BackColor = Color.White;
            btnLogout.Image = Properties.Resources.logout;
            lblLogout.ForeColor = Color.Firebrick;
        }


        #endregion


    }
}
