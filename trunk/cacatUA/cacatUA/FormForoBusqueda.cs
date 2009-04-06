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
    public partial class FormForoBusqueda : UserControl
    {
        private FormForo formularioPadre = null;
        public FormForoBusqueda(FormForo formularioPadre)
        {
            this.formularioPadre = formularioPadre;
            InitializeComponent();
        }

        public bool ValidarFormulario()
        {
            bool correcto = true;
            string errorCategoria = "";
            string errorUsuario = "";
            string errorFecha = "";

            if (textBox_categoria.Text != "")
            {
                ENCategoria categoria = new ENCategoria(int.Parse(textBox_categoria.Text));
                if (categoria.Id == 0)
                {
                    correcto = false;
                    errorCategoria = "Esta categoría no existe.";
                }
            }

            if (textBox_autor.Text != "")
            {
                ENUsuario usuario = new ENUsuario(textBox_autor.Text);
                if (usuario.Id == 0)
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

            errorProvider1.SetError(textBox_categoria, errorCategoria);
            errorProvider1.SetError(textBox_autor, errorUsuario);
            errorProvider1.SetError(dateTimePicker_fechaFin, errorFecha);

            return correcto;
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                ENUsuario usuario = null;
                if (textBox_autor.Text != "")
                    usuario = new ENUsuario(textBox_autor.Text);
                ENCategoria categoria = null;
                if (textBox_categoria.Text != "")
                    categoria = new ENCategoria(int.Parse(textBox_categoria.Text));
                DateTime fechaInicio = dateTimePicker_fechaInicio.Value;
                DateTime fechaFin = dateTimePicker_fechaFin.Value;

                formularioPadre.Resultados = ENHilo.Obtener(0, 0, 0, textBox_filtroBusqueda.Text,
                    textBox_filtroBusqueda.Text, ref usuario, ref fechaInicio, ref fechaFin, ref categoria);
            }
        }

        private void button_seleccionarUsuario_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, true);
        }

        private void button_seleccionarCategoria_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormCategorias(), "Seleccionando categoría", true, true);
        }
    }
}
