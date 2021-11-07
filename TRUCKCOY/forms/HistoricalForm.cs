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
            /// <summary>
            /// Load DataGridView information
            /// </summary>

            DateTime now = DateTime.Now;
            string monthToUpper = now.ToString("MMM", new CultureInfo("cl")).ToUpper();

            for (int x = 0; x < 30; x++)
            {
                // Array list to add data
                string[] historyDGV = new string[]
                {
                ""+(x+1)+"",now.ToString("dd-"+monthToUpper+"-yyyy HH:mm:ss tt"),"Carlos Lopez","AB XX 11","Psje Rio Claro #2596","Teniente vidal #456","En recorrido"
                };

                // Add array to Data Grid View
                dgvHistory.Rows.Add(historyDGV);

                // Validate Cell Status and change color
                string dataValidator = dgvHistory.Rows[x].Cells[6].Value.ToString();
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
            }
        }

        #endregion


    }
}


