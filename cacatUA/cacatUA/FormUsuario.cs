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
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();
        }

        private void button_editarUsuarioFirma_Click(object sender, EventArgs e)
        {
            FormUsuarioFirma form = new FormUsuarioFirma();
            //form.setModo(FormUsuario.modos.NUEVO);
            form.Show();
        }

        private void button_editarUsuarioGaleria_Click(object sender, EventArgs e)
        {
            FormUsuarioGaleria form = new FormUsuarioGaleria();
            //form.setModo(FormUsuario.modos.NUEVO);
            form.Show();
        }

        private void button_editarUsuarioMensaje_Click(object sender, EventArgs e)
        {
            FormUsuarioMensaje form = new FormUsuarioMensaje();
            //form.setModo(FormUsuario.modos.NUEVO);
            form.Show();
        }
    }
}
