using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fInicio
{
    public partial class fInicio : Form
    {
        public fInicio()
        {
            InitializeComponent();
        }

        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bEntrar_Click(object sender, EventArgs e)
        {
            formularioBase f = new formularioBase();
            f.Owner = this;
            f.ShowDialog();
            this.Close();
        }
    }
}
