using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRUCKCOY.forms
{
    public partial class HistoricalForm : Form
    {
        public HistoricalForm()
        {
            InitializeComponent();
        }

        private void HistoricalForm_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        #region Frontend

        private void loadDataGridView()
        {
            DateTime now = DateTime.Now;
            string monthToUpper = now.ToString("MMM", new CultureInfo("cl")).ToUpper();

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

        #endregion


    }
}


