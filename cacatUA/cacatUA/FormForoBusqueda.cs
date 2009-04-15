using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Libreria;

namespace cacatUA
{
    public partial class FormForoBusqueda : InterfazForm
    {
        private FormForo formularioPadre = null;
        private ENCategoria categoria = null;
        private ENUsuario usuario = null;

        public FormForoBusqueda(FormForo formularioPadre)
        {
            this.formularioPadre = formularioPadre;
            InitializeComponent();
        }

        public void Limpiar()
        {
            categoria = null;
            usuario = null;
            textBox_filtroBusqueda.Text = "";
            textBox_autor.Text = "";
            textBox_categoria.Text = "";
            dateTimePicker_fechaInicio.Value = new DateTime(2008, 9, 1);
            dateTimePicker_fechaFin.Value = DateTime.Now;
            errorProvider1.Clear();
        }

        public bool ValidarFormulario()
        {
            bool correcto = true;
            string errorUsuario = "";
            string errorFecha = "";

            if (textBox_autor.Text != "")
            {
                usuario = ENUsuario.Obtener(textBox_autor.Text);
                if (usuario==null)
                {
                    correcto = false;
                    errorUsuario = "Este usuario no existe.";
                }
            }

            if (dateTimePicker_fechaFin.Value < dateTimePicker_fechaInicio.Value)
            {
                correcto = false;
                errorFecha = "La fecha de inicio es posterior a la fecha de fin.";
            }

            errorProvider1.SetError(textBox_autor, errorUsuario);
            errorProvider1.SetError(dateTimePicker_fechaFin, errorFecha);

            return correcto;
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void button_seleccionarUsuario_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, true, "Volver al panel anterior seleccionando el usuario actual", "Cancelar la selección y volver al panel anterior");
        }

        private void button_seleccionarCategoria_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormCategorias(), "Seleccionando categoría", true, true, "Volver al panel anterior seleccionando la categoría actual", "Cancelar la selección y volver al panel anterior");
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
                    {
                        usuario = (ENUsuario)objeto;
                        textBox_autor.Text = usuario.Usuario;
                    }
                }
            }
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Buscar()
        {
            if (ValidarFormulario())
            {
                usuario = null;
                if (textBox_autor.Text != "")
                    usuario = ENUsuario.Obtener(textBox_autor.Text);
                DateTime fechaInicio = dateTimePicker_fechaInicio.Value;
                DateTime fechaFin = dateTimePicker_fechaFin.Value;

                formularioPadre.Resultados = ENHilo.Obtener(0, 0, 0, textBox_filtroBusqueda.Text,
                    textBox_filtroBusqueda.Text, ref usuario, ref fechaInicio, ref fechaFin, ref categoria);
            }
        }
    }
}
