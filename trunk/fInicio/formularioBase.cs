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
    public partial class formularioBase : Form
    {
        public formularioBase()
        {
            InitializeComponent();
        }

        private void formularioBase_Load(object sender, EventArgs e)
        {
            fInicio.ActiveForm.Visible = false;
        }
    }
}
