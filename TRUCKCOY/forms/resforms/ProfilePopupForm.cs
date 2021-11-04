using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRUCKCOY.forms
{
    public partial class ProfilePopupForm : Form
    {
        public ProfilePopupForm()
        {
            InitializeComponent();
        }

        #region Edit Profile Button
        private void btnEditProfile_Click(object sender, EventArgs e)
        {

        }
        private void btnEditProfile_MouseHover(object sender, EventArgs e)
        {
            btnEditProfile.BackColor = Color.FromArgb(245, 247, 251);
        }
        private void btnEditProfile_MouseLeave(object sender, EventArgs e)
        {
            btnEditProfile.BackColor = Color.White;
        }
        private void lblProfileEdit_MouseHover(object sender, EventArgs e)
        {
            btnEditProfile.BackColor = Color.FromArgb(245, 247, 251);
        }
        private void lblProfileEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEditProfile.BackColor = Color.White;
        }
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            btnEditProfile.BackColor = Color.FromArgb(245, 247, 251);
        }
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            btnEditProfile.BackColor = Color.White;
        }
        #endregion
        #region Config Button
        private void btnConfig_Click(object sender, EventArgs e)
        {

        }
        private void btnConfig_MouseHover(object sender, EventArgs e)
        {
            btnConfig.BackColor = Color.FromArgb(245, 247, 251);
        }
        private void btnConfig_MouseLeave(object sender, EventArgs e)
        {
            btnConfig.BackColor = Color.White;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            btnConfig.BackColor = Color.FromArgb(245, 247, 251);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            btnConfig.BackColor = Color.White;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            btnConfig.BackColor = Color.FromArgb(245, 247, 251);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            btnConfig.BackColor = Color.White;
        }
        #endregion
    }
}
