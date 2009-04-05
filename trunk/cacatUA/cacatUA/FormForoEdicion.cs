using System;
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
    public partial class FormForoEdicion : UserControl
    {
        ENHilo hilo;
        public FormForoEdicion()
        {
            InitializeComponent();
        }

        public void CambiarSeleccionado(int id)
        {
            hilo = new ENHilo(id);
            textBox_id.Text = hilo.Id.ToString();
            textBox_texto.Text = hilo.Texto;
            textBox_titulo.Text = hilo.Titulo;
            textBox_autor.Text = hilo.Autor.Usuario.ToString();
            textBox_categoria.Text = hilo.Categoria.Nombre.ToString();
            dateTimePicker_fecha.Value = hilo.Fecha;
            textBox_respuestas.Text = hilo.NumRespuestas.ToString();
            errorProvider1.Clear();
            desactivarBotones();
        }

        public void CambiarNuevo()
        {
            hilo = null;
            textBox_id.Text = "";
            textBox_texto.Text = "";
            textBox_titulo.Text = "";
            textBox_autor.Text = "";
            textBox_categoria.Text = "";
            textBox_respuestas.Text = "";
            errorProvider1.Clear();
            desactivarBotones();
        }

        public bool ValidarFormulario()
        {
            bool correcto = true;
            string errorTitulo = "";
            string errorTexto = "";
            string errorCategoria = "";
            string errorUsuario = "";

            if (textBox_titulo.Text != "")
            {

            }
            else
            {
                errorTitulo = "Debes introducir un título.";
            }

            if (textBox_texto.Text != "")
            {

            }
            else
            {
                errorTexto = "Debes introducir un texto.";
            }

            if (textBox_categoria.Text != "")
            {
                ENCategoria categoria = new ENCategoria();// new ENCategoria(textBox_categoria.Text);
                if (categoria.Id == 0)
                {
                    correcto = false;
                    errorCategoria = "Esta categoría no existe.";
                }
            }
            else
            {
                errorCategoria = "Debes introducir una categoría.";
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
            else
            {
                errorUsuario = "Debes introducir una autor.";
            }

            errorProvider1.SetError(textBox_titulo, errorTitulo);
            errorProvider1.SetError(textBox_texto, errorTexto);
            errorProvider1.SetError(textBox_categoria, errorCategoria);
            errorProvider1.SetError(textBox_autor, errorUsuario);

            return correcto;
        }

        private void button_guardarCambios_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                ENHilo nuevo = new ENHilo();
                nuevo.Texto = textBox_texto.Text;
                nuevo.Titulo = textBox_titulo.Text;
                nuevo.Autor = new ENUsuario(textBox_autor.Text);
                //nuevo.Categoria = ENCategoria.ObtenerCategoria(textBox_categoria.Text);
                nuevo.Guardar();
            }
        }

        private void formulario_Modificado(object sender, EventArgs e)
        {
            activarBotones();
        }

        private void activarBotones()
        {
            button_guardarCambios.Enabled = true;
            button_descartarCambios.Enabled = true;
        }

        private void desactivarBotones()
        {
            button_guardarCambios.Enabled = false;
            button_descartarCambios.Enabled = false;
        }

        private void button_descartarCambios_Click(object sender, EventArgs e)
        {
            if (textBox_id.Text == "")
            {
                CambiarNuevo();
            }
            else
            {
                CambiarSeleccionado (int.Parse(textBox_id.Text));
            }
        }
    }
}
