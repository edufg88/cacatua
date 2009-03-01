using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cacatUA
{
    public partial class FormGrupos : cacatUA.FormPanelAdministracion
    {
        public FormGrupos()
        {
            InitializeComponent();
        }

        private void buttonTraspaso_Click(object sender, EventArgs e)
        {
            if (listBoxGrupo.SelectedIndex != -1)
            {
                listBoxUsuario.Items.Clear();
                listBoxUsuario.Items.Add("Pepe");
                listBoxUsuario.Items.Add("Jose");
                listBoxUsuario.Items.Add("Juan");
            }
        }


    }
}
