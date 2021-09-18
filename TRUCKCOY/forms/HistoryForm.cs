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
            cbox.Image = Properties.Resources.checkbox_unchecked;
            loadFrontEnd();
        }

        private void loadFrontEnd()
        {
            //-> Load HistoryForm data
            Connect con = new Connect();

            if(con.testConnection() == "Successful")
            {
                string[] incomeOrders = con.getlast14orders("ignaciocorball@techcoy.xyz");

                if(incomeOrders.Length >= 14)                                               // If register exist show them
                {
                    lblCreated0.Text = "Mayor de 14: " + incomeOrders.Length.ToString();
                }
                
                else if (incomeOrders.Length >= 1)                                          // If registers data is less than 14 show avalaible
                {
                    lblCreated0.Text = "Menor de 14: " + incomeOrders.Length.ToString();
                }
                else                                                                        // If registers doesn't exists load no data registered
                {
                    lblCreated0.Text = "Sin registros: " + incomeOrders.Length.ToString();
                }
                
            }
            else
            {
                // Load database connection error
                lblCreated0.Text = con.testConnection();
            }
            
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {

        }

        #region CheckBox Events
        private void cbox_Click(object sender, EventArgs e)
        {
            switch (checkboxs[0])
            {
                case 0:
                    cbox.Image = Properties.Resources.checkbox_checked;
                    cbox0.Image = Properties.Resources.checkbox_checked;
                    cbox1.Image = Properties.Resources.checkbox_checked;
                    cbox2.Image = Properties.Resources.checkbox_checked;
                    cbox3.Image = Properties.Resources.checkbox_checked;
                    cbox4.Image = Properties.Resources.checkbox_checked;
                    cbox5.Image = Properties.Resources.checkbox_checked;
                    cbox6.Image = Properties.Resources.checkbox_checked;
                    cbox7.Image = Properties.Resources.checkbox_checked;
                    cbox8.Image = Properties.Resources.checkbox_checked;
                    cbox9.Image = Properties.Resources.checkbox_checked;
                    cbox10.Image = Properties.Resources.checkbox_checked;
                    cbox11.Image = Properties.Resources.checkbox_checked;
                    cbox12.Image = Properties.Resources.checkbox_checked;
                    cbox13.Image = Properties.Resources.checkbox_checked;

                    checkboxs[0] = 1;
                    checkboxs[1] = 1;
                    checkboxs[2] = 1;
                    checkboxs[3] = 1;
                    checkboxs[4] = 1;
                    checkboxs[5] = 1;
                    checkboxs[6] = 1;
                    checkboxs[7] = 1;
                    checkboxs[8] = 1;
                    checkboxs[9] = 1;
                    checkboxs[10] = 1;
                    checkboxs[11] = 1;
                    checkboxs[12] = 1;
                    checkboxs[13] = 1;
                    break;
                case 1:
                    cbox.Image = Properties.Resources.checkbox_unchecked;
                    cbox0.Image = Properties.Resources.checkbox_unchecked;
                    cbox1.Image = Properties.Resources.checkbox_unchecked;
                    cbox2.Image = Properties.Resources.checkbox_unchecked;
                    cbox3.Image = Properties.Resources.checkbox_unchecked;
                    cbox4.Image = Properties.Resources.checkbox_unchecked;
                    cbox5.Image = Properties.Resources.checkbox_unchecked;
                    cbox6.Image = Properties.Resources.checkbox_unchecked;
                    cbox7.Image = Properties.Resources.checkbox_unchecked;
                    cbox8.Image = Properties.Resources.checkbox_unchecked;
                    cbox9.Image = Properties.Resources.checkbox_unchecked;
                    cbox10.Image = Properties.Resources.checkbox_unchecked;
                    cbox11.Image = Properties.Resources.checkbox_unchecked;
                    cbox12.Image = Properties.Resources.checkbox_unchecked;
                    cbox13.Image = Properties.Resources.checkbox_unchecked;
                    checkboxs[0] = 0;
                    checkboxs[0] = 0;
                    checkboxs[1] = 0;
                    checkboxs[2] = 0;
                    checkboxs[3] = 0;
                    checkboxs[4] = 0;
                    checkboxs[5] = 0;
                    checkboxs[6] = 0;
                    checkboxs[7] = 0;
                    checkboxs[8] = 0;
                    checkboxs[9] = 0;
                    checkboxs[10] = 0;
                    checkboxs[11] = 0;
                    checkboxs[12] = 0;
                    checkboxs[13] = 0;
                    break;
            }
        }
        private void cbox0_Click(object sender, EventArgs e)
        {
            switch (checkboxs[1])
            {
                case 0:
                    cbox0.Image = Properties.Resources.checkbox_checked;
                    checkboxs[1] = 1;
                    break;
                case 1:
                    cbox0.Image = Properties.Resources.checkbox_unchecked;
                    checkboxs[1] = 0;
                    break;
            }
        }
        private void cbox1_Click(object sender, EventArgs e)
        {
            switch (checkboxs[2])
            {
                case 0:
                    cbox1.Image = Properties.Resources.checkbox_checked;
                    checkboxs[2] = 1;
                    break;
                case 1:
                    cbox1.Image = Properties.Resources.checkbox_unchecked;
                    checkboxs[2] = 0;
                    break;
            }
        }
        private void cbox2_Click(object sender, EventArgs e)
        {
            switch (checkboxs[3])
            {
                case 0:
                    cbox2.Image = Properties.Resources.checkbox_checked;
                    checkboxs[3] = 1;
                    break;
                case 1:
                    cbox2.Image = Properties.Resources.checkbox_unchecked;
                    checkboxs[3] = 0;
                    break;
            }
        }
        private void cbox3_Click(object sender, EventArgs e)
        {
            switch (checkboxs[4])
            {
                case 0:
                    cbox3.Image = Properties.Resources.checkbox_checked;
                    checkboxs[4] = 1;
                    break;
                case 1:
                    cbox3.Image = Properties.Resources.checkbox_unchecked;
                    checkboxs[4] = 0;
                    break;
            }
        }
        private void cbox4_Click(object sender, EventArgs e)
        {
            switch (checkboxs[5])
            {
                case 0:
                    cbox4.Image = Properties.Resources.checkbox_checked;
                    checkboxs[5] = 1;
                    break;
                case 1:
                    cbox4.Image = Properties.Resources.checkbox_unchecked;
                    checkboxs[5] = 0;
                    break;
            }
        }
        private void cbox5_Click(object sender, EventArgs e)
        {
            switch (checkboxs[6])
            {
                case 0:
                    cbox5.Image = Properties.Resources.checkbox_checked;
                    checkboxs[6] = 1;
                    break;
                case 1:
                    cbox5.Image = Properties.Resources.checkbox_unchecked;
                    checkboxs[6] = 0;
                    break;
            }
        }
        private void cbox6_Click(object sender, EventArgs e)
        {
            switch (checkboxs[7])
            {
                case 0:
                    cbox6.Image = Properties.Resources.checkbox_checked;
                    checkboxs[7] = 1;
                    break;
                case 1:
                    cbox6.Image = Properties.Resources.checkbox_unchecked;
                    checkboxs[7] = 0;
                    break;
            }
        }
        private void cbox7_Click(object sender, EventArgs e)
        {
            switch (checkboxs[8])
            {
                case 0:
                    cbox7.Image = Properties.Resources.checkbox_checked;
                    checkboxs[8] = 1;
                    break;
                case 1:
                    cbox7.Image = Properties.Resources.checkbox_unchecked;
                    checkboxs[8] = 0;
                    break;
            }
        }
        private void cbox8_Click(object sender, EventArgs e)
        {
            switch (checkboxs[9])
            {
                case 0:
                    cbox8.Image = Properties.Resources.checkbox_checked;
                    checkboxs[9] = 1;
                    break;
                case 1:
                    cbox8.Image = Properties.Resources.checkbox_unchecked;
                    checkboxs[9] = 0;
                    break;
            }
        }
        private void cbox9_Click(object sender, EventArgs e)
        {
            switch (checkboxs[10])
            {
                case 0:
                    cbox9.Image = Properties.Resources.checkbox_checked;
                    checkboxs[10] = 1;
                    break;
                case 1:
                    cbox9.Image = Properties.Resources.checkbox_unchecked;
                    checkboxs[10] = 0;
                    break;
            }
        }
        private void cbox10_Click(object sender, EventArgs e)
        {
            switch (checkboxs[11])
            {
                case 0:
                    cbox10.Image = Properties.Resources.checkbox_checked;
                    checkboxs[11] = 1;
                    break;
                case 1:
                    cbox10.Image = Properties.Resources.checkbox_unchecked;
                    checkboxs[11] = 0;
                    break;
            }
        }
        private void cbox11_Click(object sender, EventArgs e)
        {
            switch (checkboxs[12])
            {
                case 0:
                    cbox11.Image = Properties.Resources.checkbox_checked;
                    checkboxs[12] = 1;
                    break;
                case 1:
                    cbox11.Image = Properties.Resources.checkbox_unchecked;
                    checkboxs[12] = 0;
                    break;
            }
        }
        private void cbox12_Click(object sender, EventArgs e)
        {
            switch (checkboxs[13])
            {
                case 0:
                    cbox12.Image = Properties.Resources.checkbox_checked;
                    checkboxs[13] = 1;
                    break;
                case 1:
                    cbox12.Image = Properties.Resources.checkbox_unchecked;
                    checkboxs[13] = 0;
                    break;
            }
        }
        private void cbox13_Click(object sender, EventArgs e)
        {
            switch (checkboxs[14])
            {
                case 0:
                    cbox13.Image = Properties.Resources.checkbox_checked;
                    checkboxs[14] = 1;
                    break;
                case 1:
                    cbox13.Image = Properties.Resources.checkbox_unchecked;
                    checkboxs[14] = 0;
                    break;
            }
        }
        #endregion

        #region Details Button Events
        //--> Open Full History Details Form
        private void details_Click(object sender, EventArgs e)
        {

        }
        private void details0_Click(object sender, EventArgs e)
        {

        }
        private void details1_Click(object sender, EventArgs e)
        {

        }
        private void details2_Click(object sender, EventArgs e)
        {

        }
        private void details3_Click(object sender, EventArgs e)
        {

        }
        private void details4_Click(object sender, EventArgs e)
        {

        }
        private void details5_Click(object sender, EventArgs e)
        {

        }
        private void details6_Click(object sender, EventArgs e)
        {

        }
        private void details7_Click(object sender, EventArgs e)
        {

        }
        private void details8_Click(object sender, EventArgs e)
        {

        }
        private void details9_Click(object sender, EventArgs e)
        {

        }
        private void details10_Click(object sender, EventArgs e)
        {

        }
        private void details11_Click(object sender, EventArgs e)
        {

        }
        private void details12_Click(object sender, EventArgs e)
        {

        }
        private void details13_Click(object sender, EventArgs e)
        {

        }


        private void details_MouseHover(object sender, EventArgs e)
        {
            details.Image = Properties.Resources.eye_hover;
        }
        private void details0_MouseHover(object sender, EventArgs e)
        {
            details0.Image = Properties.Resources.eye_hover;
        }
        private void details1_MouseHover(object sender, EventArgs e)
        {
            details1.Image = Properties.Resources.eye_hover;
        }
        private void details2_MouseHover(object sender, EventArgs e)
        {
            details2.Image = Properties.Resources.eye_hover;
        }
        private void details3_MouseHover(object sender, EventArgs e)
        {
            details3.Image = Properties.Resources.eye_hover;
        }
        private void details4_MouseHover(object sender, EventArgs e)
        {
            details4.Image = Properties.Resources.eye_hover;
        }
        private void details5_MouseHover(object sender, EventArgs e)
        {
            details5.Image = Properties.Resources.eye_hover;
        }
        private void details6_MouseHover(object sender, EventArgs e)
        {
            details6.Image = Properties.Resources.eye_hover;
        }
        private void details7_MouseHover(object sender, EventArgs e)
        {
            details7.Image = Properties.Resources.eye_hover;
        }
        private void details8_MouseHover(object sender, EventArgs e)
        {
            details8.Image = Properties.Resources.eye_hover;
        }
        private void details9_MouseHover(object sender, EventArgs e)
        {
            details9.Image = Properties.Resources.eye_hover;
        }
        private void details10_MouseHover(object sender, EventArgs e)
        {
            details10.Image = Properties.Resources.eye_hover;
        }
        private void details11_MouseHover(object sender, EventArgs e)
        {
            details11.Image = Properties.Resources.eye_hover;
        }
        private void details12_MouseHover(object sender, EventArgs e)
        {
            details12.Image = Properties.Resources.eye_hover;
        }
        private void details13_MouseHover(object sender, EventArgs e)
        {
            details13.Image = Properties.Resources.eye_hover;
        }

        private void details_MouseLeave(object sender, EventArgs e)
        {
            details.Image = Properties.Resources.eye_leave;
        }
        private void details0_MouseLeave(object sender, EventArgs e)
        {
            details0.Image = Properties.Resources.eye_leave;
        }
        private void details1_MouseLeave(object sender, EventArgs e)
        {
            details1.Image = Properties.Resources.eye_leave;
        }
        private void details2_MouseLeave(object sender, EventArgs e)
        {
            details2.Image = Properties.Resources.eye_leave;
        }
        private void details3_MouseLeave(object sender, EventArgs e)
        {
            details3.Image = Properties.Resources.eye_leave;
        }
        private void details4_MouseLeave(object sender, EventArgs e)
        {
            details4.Image = Properties.Resources.eye_leave;
        }
        private void details5_MouseLeave(object sender, EventArgs e)
        {
            details5.Image = Properties.Resources.eye_leave;
        }
        private void details6_MouseLeave(object sender, EventArgs e)
        {
            details6.Image = Properties.Resources.eye_leave;
        }
        private void details7_MouseLeave(object sender, EventArgs e)
        {
            details7.Image = Properties.Resources.eye_leave;
        }
        private void details8_MouseLeave(object sender, EventArgs e)
        {
            details8.Image = Properties.Resources.eye_leave;
        }
        private void details9_MouseLeave(object sender, EventArgs e)
        {
            details9.Image = Properties.Resources.eye_leave;
        }
        private void details10_MouseLeave(object sender, EventArgs e)
        {
            details10.Image = Properties.Resources.eye_leave;
        }
        private void details11_MouseLeave(object sender, EventArgs e)
        {
            details11.Image = Properties.Resources.eye_leave;
        }
        private void details12_MouseLeave(object sender, EventArgs e)
        {
            details12.Image = Properties.Resources.eye_leave;
        }
        private void details13_MouseLeave(object sender, EventArgs e)
        {
            details13.Image = Properties.Resources.eye_leave;
        }

        #endregion


    }
}
