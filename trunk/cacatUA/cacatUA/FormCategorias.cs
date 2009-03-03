using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cacatUA
{
    public partial class FormCategorias : UserControl
    {
        public FormCategorias()
        {
            InitializeComponent();
        }

        private void bForo_Click(object sender, EventArgs e)
        {
            FormForo form = new FormForo();
            panel1.Controls.Clear();
            panel1.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }
    }
}
