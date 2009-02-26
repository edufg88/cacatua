using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cacatUA
{
    public partial class FormCategorias : cacatUA.FormPanelAdministracion
    {
        public FormCategorias()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listSecciones.SelectedIndex != -1)
            {
                listCategorias.Items.Clear();
                listCategorias.Items.Add("Primer curso");
                listCategorias.Items.Add("Segundo curso");
                listCategorias.Items.Add("Tercer curso");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listCategorias.SelectedIndex != -1)
            {
                listSubcategorias.Items.Clear();
                listSubcategorias.Items.Add("DPAA");
                listSubcategorias.Items.Add("FAC");
                listSubcategorias.Items.Add("SIE");
            }
        }
    }
}
