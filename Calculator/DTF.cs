using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class DTF : Form
    {
        public DTF()
        {
            InitializeComponent();
        }

        private void DTF_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu form = new MainMenu();
            form.Visible = true;
        }
    }
}
