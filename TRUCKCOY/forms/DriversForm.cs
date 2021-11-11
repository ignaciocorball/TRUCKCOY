using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace TRUCKCOY.forms
{
    public partial class DriversForm : Form
    {
        DateTime now = DateTime.Now;
        CheckBox checkboxHeader = new CheckBox();
        Image chkMain1 = Properties.Resources.chk_unchecked;
        public DriversForm()
        {
            InitializeComponent();
            loadDGV();
            ImageAnimator.StopAnimate(picLoading.Image, OnFrameChanged);
        }

        private void loadDGV()
        {
            /// <summary>
            /// Load DataGridView information
            /// </summary>

            Bitmap imgEdit, imgDelete;
            imgEdit = new Bitmap(Properties.Resources.edit);
            imgDelete = new Bitmap(Properties.Resources.trash2);

            string monthToUpper = now.ToString("MMM", new CultureInfo("cl")).ToUpper();

            // Add array data in History Data Grid View
            for (int x = 0; x < 13; x++)
            {
                // Array to add
                string[] historyDGV = new string[]
                {
                    x.ToString(),"Carlos Fuentes", "944448391", "151653786589314", "AB GZ 11","Activo",now.ToString("dd-"+monthToUpper+"-yyyy HH:mm:ss tt")
                };

                // Add array to Data Grid View
                dgvHistory.Rows.Add(historyDGV);

                // Validate Cell Status and change color
                string dataValidator = dgvHistory.Rows[x].Cells[5].Value.ToString();
                switch (dataValidator)
                {
                    case "Activo":
                        dgvHistory.Rows[x].Cells[5].Style.ForeColor = Color.LightSeaGreen;
                        break;
                    case "Inactivo":
                        dgvHistory.Rows[x].Cells[5].Style.ForeColor = Color.LightSkyBlue;
                        break;
                    case "Desconectado":
                        dgvHistory.Rows[x].Cells[5].Style.ForeColor = Color.DimGray;
                        break;
                }
                dgvHistory.Rows[x].Cells[7].Value = imgEdit;
                dgvHistory.Rows[x].Cells[8].Value = imgDelete;
                dgvHistory.Rows[x].Cells[9].Value = false;
            }


        }
        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 7: /// EDIT BUTTON
                    if (e.RowIndex != -1)
                    {
                        if (picLoading.Visible == true)
                        {
                            txtID.Text = dgvHistory.Rows[e.RowIndex].Cells[0].Value.ToString();
                            txtName.Text = dgvHistory.Rows[e.RowIndex].Cells[1].Value.ToString();
                            txtPhone.Text = dgvHistory.Rows[e.RowIndex].Cells[2].Value.ToString();
                            txtImei.Text = dgvHistory.Rows[e.RowIndex].Cells[3].Value.ToString();
                            txtPatente.Text = dgvHistory.Rows[e.RowIndex].Cells[4].Value.ToString();
                            txtStatus.Text = dgvHistory.Rows[e.RowIndex].Cells[5].Value.ToString();
                            txtRegdate.Text = dgvHistory.Rows[e.RowIndex].Cells[6].Value.ToString();
                            txtLastaccess.Text = now.ToString("dd-MM-yyyy hh:mm:ss tt");
                            picLoading.Image = Properties.Resources.loading_drivers;
                            ImageAnimator.Animate(picLoading.Image, OnFrameChanged);
                            tmrClock.Enabled = true;
                            tmrClock.Start();
                        }
                        else
                        {
                            txtID.Text = dgvHistory.Rows[e.RowIndex].Cells[0].Value.ToString();
                            txtName.Text = dgvHistory.Rows[e.RowIndex].Cells[1].Value.ToString();
                            txtPhone.Text = dgvHistory.Rows[e.RowIndex].Cells[2].Value.ToString();
                            txtImei.Text = dgvHistory.Rows[e.RowIndex].Cells[3].Value.ToString();
                            txtPatente.Text = dgvHistory.Rows[e.RowIndex].Cells[4].Value.ToString();
                            txtStatus.Text = dgvHistory.Rows[e.RowIndex].Cells[5].Value.ToString();
                            txtRegdate.Text = dgvHistory.Rows[e.RowIndex].Cells[6].Value.ToString();
                            txtLastaccess.Text = now.ToString("dd-MM-yyyy hh:mm:ss tt");
                        }
                    }
                    break;
                case 8: /// DELETE BUTTON
                    if (e.RowIndex != -1)
                    {
                        MessageBox.Show("Button Delete [Row:" + (e.RowIndex + 1) + "Column:" + (e.ColumnIndex) + "]");
                    }
                    break;
                case 9: /// CHECKBOX BUTTON
                    /// Prevent header checkbox click error
                    if(e.RowIndex != -1)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvHistory.Rows[e.RowIndex].Cells[9];
                        chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
                    }
                break;
            }
        }
        private void chkMain_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                if (chkMain.Checked) { row.Cells[9].Value = false; } else {  row.Cells[9].Value = true;  }
            }
        }
        private void dgvHistory_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 || e.ColumnIndex == 8)
            {
                dgvHistory.Cursor = Cursors.Hand;
            }
        }
        private void dgvHistory_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 7 || e.ColumnIndex != 8)
            {
                dgvHistory.Cursor = Cursors.Default;
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dgvHistory.Sort(dgvHistory.Columns[0], ListSortDirection.Descending);
        }
        private void dgvHistory_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }


        /// <summary>
        /// Example GiF PLAY AND STOP
        /// </summary>
        private void OnFrameChanged(object sender, EventArgs args)
        {
            picLoading.Invalidate();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            picLoading.Image = Properties.Resources.loading_drivers;
            ImageAnimator.Animate(picLoading.Image, OnFrameChanged);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ImageAnimator.StopAnimate(picLoading.Image, OnFrameChanged);
            picLoading.Image = Properties.Resources.loading_drivers1;
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {

             picLoading.Visible = false;
             tmrClock.Enabled = false;
             tmrClock.Stop();

        }

        private void dgvHistory_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 8)
            {
                Image img = Properties.Resources.trash2;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                e.Graphics.DrawImage(img, e.CellBounds);
                e.Handled = true;
            }
            if(e.RowIndex == -1 && e.ColumnIndex == 9)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                e.Graphics.DrawImage(chkMain1, e.CellBounds);
                e.Handled = true;
            }
        }
    }
}
