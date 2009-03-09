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
    public partial class FormUsuarios : UserControl
    {
        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void button_añadirUsuario_Click(object sender, EventArgs e)
        {
            FormUsuario form = new FormUsuario();
            //form.setModo(FormUsuario.modos.NUEVO);
            form.Show();
        }

        private void button_editarUsuario_Click(object sender, EventArgs e)
        {
            /* 
            FormUsuario form = new FormUsuario();
            form.setModo(FormUsuario.modos.EDITAR);
            form.Show();
             */ 
        }

        private void button_borrarUsuario_Click(object sender, EventArgs e)
        {
            /*
            DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas eliminar ese/esos USUARIO(S)?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                // Obtenemos todas las filas seleccionada
                DataGridViewSelectedRowCollection filas = dataGridViewUsuarios.SelectedRows;
                for (int i = 0; i < filas.Count; i++)
                {
                    // Obtenemos la fila
                    DataGridViewRow fila = filas[i];
                    // Eliminamos la fila
                    dataGridViewUsuarios.Rows.Remove(fila);
                }
            }
             */ 
        }
    }
}
