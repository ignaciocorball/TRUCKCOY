using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace TRUCKCOY.forms.resforms
{
    public partial class NotificationsForm : Form
    {
        public NotificationsForm()
        {
            InitializeComponent();
            #region Panel0
            panel0.MouseEnter += (s, ee) => mouseEnterEvent(0);
            label0.MouseEnter += (s, ee) => mouseEnterEvent(0);
            label1.MouseEnter += (s, ee) => mouseEnterEvent(0);
            label2.MouseEnter += (s, ee) => mouseEnterEvent(0);
            pictureBox1.MouseEnter += (s, ee) => mouseEnterEvent(0);
            pictureBox2.MouseEnter += (s, ee) => mouseEnterEvent(0);
            pictureBox3.MouseEnter += (s, ee) => mouseEnterEvent(0);
            panel0.MouseLeave += (s, ee) => mouseLeaveEvent(0);
            label0.MouseLeave += (s, ee) => mouseLeaveEvent(0);
            label1.MouseLeave += (s, ee) => mouseLeaveEvent(0);
            label2.MouseLeave += (s, ee) => mouseLeaveEvent(0);
            pictureBox1.MouseLeave += (s, ee) => mouseLeaveEvent(0);
            pictureBox2.MouseLeave += (s, ee) => mouseLeaveEvent(0);
            pictureBox3.MouseLeave += (s, ee) => mouseLeaveEvent(0);
            #endregion
            #region Panel1
            panel1.MouseEnter += (s, ee) => mouseEnterEvent(1);
            label3.MouseEnter += (s, ee) => mouseEnterEvent(1);
            label4.MouseEnter += (s, ee) => mouseEnterEvent(1);
            label5.MouseEnter += (s, ee) => mouseEnterEvent(1);
            pictureBox4.MouseEnter += (s, ee) => mouseEnterEvent(1);
            pictureBox5.MouseEnter += (s, ee) => mouseEnterEvent(1);
            pictureBox6.MouseEnter += (s, ee) => mouseEnterEvent(1);
            panel1.MouseLeave += (s, ee) => mouseLeaveEvent(1);
            label3.MouseLeave += (s, ee) => mouseLeaveEvent(1);
            label4.MouseLeave += (s, ee) => mouseLeaveEvent(1);
            label5.MouseLeave += (s, ee) => mouseLeaveEvent(1);
            pictureBox4.MouseLeave += (s, ee) => mouseLeaveEvent(1);
            pictureBox5.MouseLeave += (s, ee) => mouseLeaveEvent(1);
            pictureBox6.MouseLeave += (s, ee) => mouseLeaveEvent(1);
            #endregion
            #region Panel2
            panel2.MouseEnter += (s, ee) => mouseEnterEvent(2);
            label6.MouseEnter += (s, ee) => mouseEnterEvent(2);
            label7.MouseEnter += (s, ee) => mouseEnterEvent(2);
            label8.MouseEnter += (s, ee) => mouseEnterEvent(2);
            pictureBox7.MouseEnter += (s, ee) => mouseEnterEvent(2);
            pictureBox8.MouseEnter += (s, ee) => mouseEnterEvent(2);
            pictureBox9.MouseEnter += (s, ee) => mouseEnterEvent(2);
            panel2.MouseLeave += (s, ee) => mouseLeaveEvent(2);
            label6.MouseLeave += (s, ee) => mouseLeaveEvent(2);
            label7.MouseLeave += (s, ee) => mouseLeaveEvent(2);
            label8.MouseLeave += (s, ee) => mouseLeaveEvent(2);
            pictureBox7.MouseLeave += (s, ee) => mouseLeaveEvent(2);
            pictureBox8.MouseLeave += (s, ee) => mouseLeaveEvent(2);
            pictureBox9.MouseLeave += (s, ee) => mouseLeaveEvent(2);
            #endregion
            #region Panel3
            panel3.MouseEnter += (s, ee) => mouseEnterEvent(3);
            label9.MouseEnter += (s, ee) => mouseEnterEvent(3);
            label10.MouseEnter += (s, ee) => mouseEnterEvent(3);
            label11.MouseEnter += (s, ee) => mouseEnterEvent(3);
            pictureBox10.MouseEnter += (s, ee) => mouseEnterEvent(3);
            pictureBox11.MouseEnter += (s, ee) => mouseEnterEvent(3);
            pictureBox12.MouseEnter += (s, ee) => mouseEnterEvent(3);
            panel3.MouseLeave += (s, ee) => mouseLeaveEvent(3);
            label9.MouseLeave += (s, ee) => mouseLeaveEvent(3);
            label10.MouseLeave += (s, ee) => mouseLeaveEvent(3);
            label11.MouseLeave += (s, ee) => mouseLeaveEvent(3);
            pictureBox10.MouseLeave += (s, ee) => mouseLeaveEvent(3);
            pictureBox11.MouseLeave += (s, ee) => mouseLeaveEvent(3);
            pictureBox12.MouseLeave += (s, ee) => mouseLeaveEvent(3);
            #endregion
            panel2.BackColor = Color.White;
            panel3.BackColor = Color.White;
        }

        private void mouseEnterEvent(int num)
        {
            switch (num)
            {
                case 0:
                    panel0.BackColor = Color.FromArgb(72, 175, 229);
                    panel4.Visible = false;
                    break;
                case 1:
                    panel1.BackColor = Color.FromArgb(72, 175, 229);
                    panel5.Visible = false;
                    break;
                case 2:
                    panel2.BackColor = Color.FromArgb(72, 175, 229);
                    panel6.Visible = false;
                    break;
                case 3:
                    panel3.BackColor = Color.FromArgb(72, 175, 229);
                    panel7.Visible = false;
                    break;
            }
        }
        private void mouseLeaveEvent(int num)
        {
            switch (num)
            {
                case 0:
                    panel0.BackColor = Color.FromArgb(240, 240, 240);
                    panel4.Visible = true;
                    break;
                case 1:
                    panel1.BackColor = Color.FromArgb(240, 240, 240);
                    panel5.Visible = true;  
                    break;                  
                case 2:                     
                    panel2.BackColor = Color.White;
                    panel6.Visible = true;  
                    break;                  
                case 3:                     
                    panel3.BackColor = Color.White;
                    panel7.Visible = true;
                    break;
            }
        }

        private void label3_Click(object sender, System.EventArgs e)
        {
            Process.Start("https://www.truckcoy.cl/");
        }
        private void label0_Click(object sender, System.EventArgs e)
        {
            Process.Start("https://www.truckcoy.cl/");
        }
        private void label6_Click(object sender, System.EventArgs e)
        {
            Process.Start("https://www.truckcoy.cl/");
        }
        private void label9_Click(object sender, System.EventArgs e)
        {
            Process.Start("https://www.truckcoy.cl/");
        }
    }
}
