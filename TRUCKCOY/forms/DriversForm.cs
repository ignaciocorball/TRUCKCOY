using System;
using System.ComponentModel;
using System.Drawing;
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

            /// Add array data in History Data Grid View
            for (int x = 0; x < 20; x++)
            {
                /// Array to add
                string[] historyDGV = new string[]
                {
                ""+(x+1)+"","Carlos Fuentes", "Hyundai Elantra", "AB XX 11", "15.777 km","En recorrido","12-12-2021 12:12:12 PM"
                };

                /// Add array to Data Grid View
                dgvHistory.Rows.Add(historyDGV);

                /// Validate Cell Status and change color
                string dataValidator = dgvHistory.Rows[x].Cells[5].Value.ToString();
                if (dataValidator == "En recorrido")
                {
                    dgvHistory.Rows[x].Cells[5].Style.ForeColor = Color.LightGreen;
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
            }
            dgvHistory.Columns.Add(btnEditBlue);
            dgvHistory.Columns.Add(btnDelete);
        }
        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /// <summary>
            /// Buttons edit and delete actions
            /// </summary>

            /// EDIT BUTTON
            if(e.ColumnIndex == 7)
            {
                MessageBox.Show("Button Edit [Row:" + (e.RowIndex + 1) + "Column:" + (e.ColumnIndex) + "]");
            }
            /// DELETE BUTTON
            if (e.ColumnIndex == 8)
            {
                MessageBox.Show("Button Delete [Row:" + (e.RowIndex + 1) + "Column:" + (e.ColumnIndex)+"]");
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
