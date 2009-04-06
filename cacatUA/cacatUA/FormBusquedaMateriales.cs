using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Libreria;

namespace cacatUA
{
    public partial class FormBusquedaMateriales : UserControl
    {
        private FormMateriales formularioPadre = null;

        public FormBusquedaMateriales(FormMateriales formularioPadre)
        {
            InitializeComponent();
            this.formularioPadre = formularioPadre;
        }

        private void buscarMaterial(object sender, EventArgs e)
        {
            bool error = false;
            errorProvider1.Clear();
            // Obtenemos los datos introducidos por el usuario
            try
            {
                /*
                string str_usuario = textBox_usuario.Text;
                if (str_usuario != "")
                {
                    // Comprobamos si el usuario es válido
                    ENUsuario usuario = new ENUsuario();
                    if (usuario.Id == 0)
                    {
                        error = true;
                        errorProvider1.SetError(textBox_usuario, "Usuario no válido");
                    }
                }
                string categoria = textBox_categoria.Text;
                string filtroBusqueda = textBox_filtroBusqueda.Text;
                DateTime fechaInicio = dateTimePicker_fechaInicio.Value;
                DateTime fechaFin = dateTimePicker_fechaFin.Value;
                if (error == false)
                {
                    ArrayList materiales = ENMaterial.Obtener(filtroBusqueda, usuario, categoria, fechaInicio, fechaFin);
                    formularioPadre.mostrarMateriales(materiales);
                }
                 */
            }
            catch (Exception ex)
            {
                MessageBox.Show("error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            /*
            if (ValidarFormulario())
            {
                ENUsuario usuario = null;
                if (textBox_usuario.Text != "")
                    usuario = new ENUsuario(textBox_usuario.Text);
                ENCategoria categoria = null;
                if (textBox_categoria.Text != "")
                    categoria = new ENCategoria(int.Parse(textBox_categoria.Text));
                DateTime fechaInicio = dateTimePicker_fechaInicio.Value;
                DateTime fechaFin = dateTimePicker_fechaFin.Value;

                formularioPadre.Resultados = ENHilo.Obtener(0, 0, 0, textBox_filtroBusqueda.Text,
                    textBox_filtroBusqueda.Text, ref usuario, ref fechaInicio, ref fechaFin, ref categoria);
            }
            */
        }
    }
}
