using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSClient
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
            SetTheme();
        }

        private void SetTheme()
        {
            this.BackColor = Themes.FormBackColor;
            this.label1.ForeColor = Themes.LabelForeColor;

        }
    }
}
