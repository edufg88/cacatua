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
    public partial class FormMaterialesBusqueda : InterfazForm
    {
        private FormMateriales formularioPadre = null;
        private ENCategoria categoria = null;
        public FormMaterialesBusqueda(FormMateriales formularioPadre)
        {
            InitializeComponent();
            this.formularioPadre = formularioPadre;
            limpiarFormulario();
        }

        public override void Recibir(object objeto)
        {
            if (objeto != null)
            {
                if (objeto is ENCategoria)
                {
                    categoria = (ENCategoria)objeto;
                    textBox_categoria.Text = categoria.NombreCompleto();
                }
                else
                {
                    if (objeto is ENUsuario)
                        textBox_usuario.Text = ((ENUsuario)objeto).Usuario;
                }
            }
        }

        public void Buscar()
        {
            bool error = false;
            errorProvider1.Clear();
            ENUsuario usuario = null;
            // Obtenemos los datos introducidos por el usuario
            try
            {
                string str_usuario = textBox_usuario.Text;
                if (str_usuario != "")
                {
                    // Comprobamos si el usuario es válido
                    usuario = ENUsuario.Obtener(str_usuario);
                    if (usuario == null)
                    {
                        error = true;
                        errorProvider1.SetError(textBox_usuario, "Usuario no válido");
                    }
                }
                string filtroBusqueda = textBox_filtroBusqueda.Text;
                DateTime fechaInicio = dateTimePicker_fechaInicio.Value;
                DateTime fechaFin = dateTimePicker_fechaFin.Value;
                if (error == false)
                {
                    ArrayList materiales = ENMaterial.Obtener(filtroBusqueda, usuario, categoria, fechaInicio, fechaFin);
                    formularioPadre.mostrarMateriales(materiales);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buscarMaterial(object sender, EventArgs e)
        {
            bool error = false;
            errorProvider1.Clear();
            ENUsuario usuario = null;
            // Obtenemos los datos introducidos por el usuario
            try
            {
                string str_usuario = textBox_usuario.Text;
                if (str_usuario != "")
                {
                    // Comprobamos si el usuario es válido
                    usuario = ENUsuario.Obtener(str_usuario);
                    if(usuario == null)
                    {
                        error = true;
                        errorProvider1.SetError(textBox_usuario, "Usuario no válido");
                    }
                }
                string filtroBusqueda = textBox_filtroBusqueda.Text;
                DateTime fechaInicio = dateTimePicker_fechaInicio.Value;
                DateTime fechaFin = dateTimePicker_fechaFin.Value;
                if (error == false)
                {
                    ArrayList materiales = ENMaterial.Obtener(filtroBusqueda, usuario, categoria, fechaInicio, fechaFin);
                    formularioPadre.mostrarMateriales(materiales);
                }
            }
            catch (Exception)
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

        private void seleccionarCategoria(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormCategorias(), "Seleccionando categoría", true, true,
                "Volver al panel anterior seleccionando la categoría actual",
                "Cancelar la selección y volver al panel anterior");
        }

        private void seleccionarUsuario(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, true,
                "Volver al panel anterior seleccionando el usuario actual",
                "Cancelar la selección y volver al panel anterior");
        }

        private void limpiarFormulario(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        public void limpiarFormulario()
        {
            categoria = null;
            textBox_categoria.Clear();
            textBox_filtroBusqueda.Clear();
            textBox_usuario.Clear();
            dateTimePicker_fechaInicio.Value = new DateTime(2008, 9, 1);
            dateTimePicker_fechaFin.Value = DateTime.Now;
        }
    }
}
