using System;
using System.Windows.Forms;
using TRUCKCOY.classes;

namespace TRUCKCOY.forms
{
    public partial class HistoryForm : Form
    {
        int[] checkboxs = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };
        public HistoryForm()
        {
            InitializeComponent();
            loadFrontEnd();
        }

        private void loadFrontEnd()
        {
            /// Load HistoryForm data
            //DBConnect con = new DBConnect();
            //
            //if(con.testConnection() == "Successful")
            //{
            //    string[] incomeOrders = con.getlast14orders("misupercorreo@123.cl");
            //
            //    if (incomeOrders.Length >= 14)                                               // If register exist show them
            //    {
            //        lblTittleDesc.Text = "El array es mayor a 14: " + "[" + incomeOrders.Length.ToString() + "]";
            //    }
            //    
            //    else if (incomeOrders.Length >= 1)                                          // If registers data is less than 14 show avalaible
            //    {
            //        lblTittleDesc.Text = "El array es menor a 14: " + "[" + incomeOrders.Length.ToString() + "]";
            //    }
            //    else                                                                        // If registers doesn't exists load no data registered
            //    {
            //        lblTittleDesc.Text = "El array es nulo: " + "[" + incomeOrders.Length.ToString() + "]";
            //    }
            //    
            //}
            //else
            //{
            //    // Load database connection error
            //    // lblCreated0.Text = con.testConnection();
            //}
            
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            // Add row to datagridview
            //DataGridViewRow row = (DataGridViewRow)dgvHistory.Rows[0].Clone();
            /*
            row.Cells["id"].Value               = "1";
            row.Cells["income_date"].Value      = "2";
            row.Cells["driver"].Value           = "3";
            row.Cells["patente"].Value          = "4";
            row.Cells["address_source"].Value   = "5";
            row.Cells["address_out"].Value      = "6";
            row.Cells["status"].Value           = "7";
            row.Cells["delete"].Value           = "8";
            row.Cells["details0"].Value         = "9";
            row.Cells["select"].Value           = "9";
            */
            DateTime now = DateTime.Now;
            

            string[] historyDGV = new string[]
            {
                "1",now.ToString("dd/MM/yyyy HH:mm:ss tt"),"Carlos Lopez","AB XX 11","Psje Rio Claro #2596","Teniente vidal #456","En Proceso","x","o","s"

            };
            dgvHistory.Rows.Add(historyDGV);
        }
    }
}
