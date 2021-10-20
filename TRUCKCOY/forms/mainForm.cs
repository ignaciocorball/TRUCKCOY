﻿using System;
using System.Drawing;
using System.Windows.Forms;
using TRUCKCOY.forms;

namespace TRUCKCOY
{
    public partial class mainForm : Form
    {
        DashboardForm dform;
        ProfilePopupForm ppForm = new ProfilePopupForm() { TopLevel = false, TopMost = true, Dock = DockStyle.Fill };
        public mainForm()
        {
            InitializeComponent();
            getDateTime();
        }
        private void mainForm_Load(object sender, EventArgs e)
        {
            //#-> Load Dashboard content
            dform = new DashboardForm() { TopLevel = false, TopMost = true, Dock = DockStyle.Fill, Visible = false, Opacity = 0 };
            panelContainer.Controls.Add(dform);
            dform.Visible = true;

            pnlProfile.Controls.Add(ppForm);
        }

        #region BackEnd
        //#-> Internal methods
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
            btnMaps.Image = Properties.Resources.maps_off;
            btnTemperature.Image = Properties.Resources.temp_off;
        }
        private void selectNavButtons(int num)
        {
            switch (num)
            {
                case 1:
                    // Load Dashboard
                    hideNavButtons();
                    btnDashboard.Image = Properties.Resources.dashboard_on;
                    Properties.Settings.Default.navButtonSelected = 1;
                    break;
                case 2:
                    // Load Events
                    hideNavButtons();
                    btnEvents.Image = Properties.Resources.schedule_on;
                    Properties.Settings.Default.navButtonSelected = 2;
                    break;
                case 3:
                    // Load Maps
                    hideNavButtons();
                    btnMaps.Image = Properties.Resources.maps_on;
                    Properties.Settings.Default.navButtonSelected = 3;
                    break;
                case 4:
                    // Load Temperature
                    hideNavButtons();
                    btnTemperature.Image = Properties.Resources.temp_on;
                    Properties.Settings.Default.navButtonSelected = 4;
                    break;
                case 5:
                    // do something
                    break;
                case 6:
                    // do something
                    break;
                case 7:
                    // do something
                    break;
                case 8:
                    // do something
                    break;
            }
        }
        #endregion

        #region FrontEnd
        // MouseClick
        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (ppForm.Visible == false)
            {
                pnlProfile.Visible = true;
                ppForm.Visible = true;
                ppForm.Show();
            }
            else
            {
                pnlProfile.Visible = false;
                ppForm.Visible = false;
                ppForm.Hide();
            }

        }
        private void btnExpand_Click(object sender, EventArgs e)
        {
            if (Width > 950)
            {
                // Without Animation
                if (panelNavBar.Width == 60)
                {
                    panelNavBar.Width = 250;
                    divisorLine1.Width = 230;
                    divisorLine2.Width = 230;
                }
                else if (panelNavBar.Width == 250)
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
                else if (panelNavBar.Width == 250)
                {
                    tmrHideNavBar.Enabled = true;
                    tmrHideNavBar.Start();
                }
            }
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            selectNavButtons(1);
        }
        private void btnEvents_Click(object sender, EventArgs e)
        {
            selectNavButtons(2);
        }
        private void btnMaps_Click(object sender, EventArgs e)
        {
            selectNavButtons(3);
        }
        private void btnTemperature_Click(object sender, EventArgs e)
        {
            selectNavButtons(4);
        }
        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }
        // MouseOver & MouseLeave
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                txtSearch.Text = "Buscar . . .";
            }
        }
        private void btnDashboard_MouseHover(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.navButtonSelected != 1)
            {
                btnDashboard.Image = Properties.Resources.dashboard_on;
            }
        }
        private void btnDashboard_MouseLeave(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.navButtonSelected != 1)
            {
                btnDashboard.Image = Properties.Resources.dashboard_off;
            }
        }
        private void btnEvents_MouseHover(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.navButtonSelected != 2)
            {
                btnEvents.Image = Properties.Resources.schedule_on;
            }
        }
        private void btnEvents_MouseLeave(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.navButtonSelected != 2)
            {
                btnEvents.Image = Properties.Resources.schedule_off;
            }
        }
        private void btnMaps_MouseHover(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.navButtonSelected != 3)
            {
                btnMaps.Image = Properties.Resources.maps_on;
            }
        }
        private void btnMaps_MouseLeave(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.navButtonSelected != 3)
            {
                btnMaps.Image = Properties.Resources.maps_off;
            }
        }
        private void btnTemperature_MouseHover(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.navButtonSelected != 4)
            {
                btnTemperature.Image = Properties.Resources.temp_on;
            }
        }
        private void btnTemperature_MouseLeave(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.navButtonSelected != 4)
            {
                btnTemperature.Image = Properties.Resources.temp_off;
            }
        }
        #endregion

    }
}
