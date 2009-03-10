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
        }
        /// <summary>
        /// Activa las opciones para poder crear un Grupo.
        /// </summary>
        public void Anadir()
        {
            textBoxNombreGrupo.ReadOnly = false;
            textBoxCreadorGrupo.ReadOnly = false;
            richTextBoxDesc.ReadOnly = false;
            panelAgregar.Visible = true;
            panelVer.Visible = true;
        }


        private void buttonUsuario_Click(object sender, EventArgs e)
        {
            if (listBoxUsuarioGrupo.SelectedIndex != -1)
            {
                FormUsuario form = new FormUsuario();
                form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                form.Show();
            }
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

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonVer2_Click(object sender, EventArgs e)
        {
            if (listBoxUsuarios.SelectedIndex != -1)
            {
                FormUsuario form = new FormUsuario();
                form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                form.Show();
            }
        }

        private void buttonAddUsuario_Click(object sender, EventArgs e)
        {
            panelAgregar.Visible = true;
            panelVer.Visible = true;
        }
    }
}
