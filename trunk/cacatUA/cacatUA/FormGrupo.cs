using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cacatUA
{
    public partial class FormGrupo : Form
    {
        public FormGrupo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Activa las opciones para poder modificar el Grupo.
        /// </summary>
        public void Modificar()
        {
            textBoxNombreGrupo.ReadOnly = false;
            textBoxCreadorGrupo.ReadOnly = false;
            richTextBoxDesc.ReadOnly = false;
            panelAgregar.Visible = true;
        }


        private void buttonUsuario_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.Size = new Size(900, 500);
            form.Show();
        }
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (listBoxUsuarios.SelectedIndex != -1)
            {
                listBoxUsuarioGrupo.Items.Add(listBoxUsuarios.SelectedItem);
                listBoxUsuarios.Items.Remove(listBoxUsuarios.SelectedItem);
            }

        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            if (listBoxUsuarioGrupo.SelectedIndex != -1)
            {
                listBoxUsuarios.Items.Add(listBoxUsuarioGrupo.SelectedItem);
                listBoxUsuarioGrupo.Items.Remove(listBoxUsuarioGrupo.SelectedItem);
            }
        }
    }
}
