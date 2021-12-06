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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Logo.Parent = background;
            Tittle.Parent = background;
            Username.Parent = background;
            Password.Parent = background;
            ForgotPass.Parent = background;
        }
    }
}
