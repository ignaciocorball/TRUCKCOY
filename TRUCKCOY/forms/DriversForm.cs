using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace TRUCKCOY.forms
{
    public partial class DriversForm : Form
    {
        DataGridViewImageColumn btnEditBlue = new DataGridViewImageColumn();
        DataGridViewImageColumn btnDelete = new DataGridViewImageColumn();
        public DriversForm()
        {
            InitializeComponent();
            loadDGV();
        }
        private void loadDGV()
        {
            /// <summary>
            /// Load DataGridView information
            /// </summary>
            /// 
            DateTime now = DateTime.Now;
            string monthToUpper = now.ToString("MMM", new CultureInfo("cl")).ToUpper();

            // Add array data in History Data Grid View
            for (int x = 0; x < 20; x++)
            {
                // Array to add
                string[] historyDGV = new string[]
                {
                ""+(x+1)+"","Carlos Fuentes", "Hyundai Elantra", "AB XX 11", "15.777 km","En recorrido",now.ToString("dd-"+monthToUpper+"-yyyy HH:mm:ss tt")
                };

                // Add array to Data Grid View
                dgvHistory.Rows.Add(historyDGV);

                // Validate Cell Status and change color
                string dataValidator = dgvHistory.Rows[x].Cells[5].Value.ToString();

                switch (dataValidator)
                {
                    case "En recorrido":
                        dgvHistory.Rows[x].Cells[5].Style.ForeColor = Color.LightSeaGreen;
                        break;
                    case "En espera":
                        dgvHistory.Rows[x].Cells[5].Style.ForeColor = Color.LightSkyBlue;
                        break;
                    case "Finalizado":
                        dgvHistory.Rows[x].Cells[5].Style.ForeColor = Color.Green;
                        break;
                    case "Cancelado":
                        dgvHistory.Rows[x].Cells[5].Style.ForeColor = Color.Gray;
                        break;
                }


                /// Edit Button
                btnEditBlue.Width = 20;
                btnEditBlue.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                btnEditBlue.Image = Properties.Resources.edit;
                btnEditBlue.ImageLayout = DataGridViewImageCellLayout.Zoom;
                btnEditBlue.DividerWidth = 1;

                /// Delete Button
                btnDelete.Width = 20;
                btnDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                btnDelete.Image = Properties.Resources.trash2;
                btnDelete.ImageLayout = DataGridViewImageCellLayout.Zoom;
                btnDelete.DividerWidth = 1;

                /// Checkbox
                dgvHistory.Rows[x].Cells[7].Value = false;
            }
            dgvHistory.Columns.Add(btnEditBlue);
            dgvHistory.Columns.Add(btnDelete);
            
        }
        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /// <summary>
            /// Buttons edit and delete actions
            /// </summary>

            switch (e.ColumnIndex)
            {
                case 8: /// EDIT BUTTON
                    MessageBox.Show("Button Edit [Row:" + (e.RowIndex + 1) + "Column:" + (e.ColumnIndex) + "]");
                    break;
                case 9: /// DELETE BUTTON
                    MessageBox.Show("Button Delete [Row:" + (e.RowIndex + 1) + "Column:" + (e.ColumnIndex) + "]");
                    break;
                case 7: /// CHECKBOX BUTTON
                    bool chk = (bool)dgvHistory.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value;

                    switch (chk)
                    {
                        case true:
                            dgvHistory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                            break;
                        case false:
                            dgvHistory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                            break;
                    }

                    
                    break;
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
    }
}
