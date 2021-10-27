using System;
using System.Windows.Forms;

namespace TRUCKCOY.forms
{
    public partial class _TestForm : Form
    {
        public _TestForm()
        {
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.VerticalScroll.Enabled = true;
            flowLayoutPanel1.VerticalScroll.Visible = false;

            flowLayoutPanel1.ControlAdded += flowLayoutPanel1_ControlAdded;
            flowLayoutPanel1.ControlRemoved += flowLayoutPanel1_ControlRemoved;
        }

        private void add_Click(object sender, EventArgs e)
        {
            for(int x = 0; x < 100; x++)
            {
                //flowLayoutPanel1.Controls.Add(new SiticoneButton() { Text = "[" + x + "] Added" , Dock = DockStyle.Top, Width = 500});
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
        }

        private void siticoneVScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //flowLayoutPanel1.VerticalScroll.Value = siticoneVScrollBar1.Value;
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            //siticoneVScrollBar1.Maximum = flowLayoutPanel1.VerticalScroll.Maximum;
        }

        private void flowLayoutPanel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            //siticoneVScrollBar1.Minimum = flowLayoutPanel1.VerticalScroll.Minimum;
        }


    }
}
