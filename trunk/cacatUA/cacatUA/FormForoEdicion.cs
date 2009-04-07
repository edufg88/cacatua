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
    public partial class FormForoEdicion : InterfazForm
    {
        private ENHilo hilo;
        private ENCategoria categoria;
        private ENUsuario usuario;

        public FormForoEdicion()
        {
            InitializeComponent();
        }

        public void CambiarSeleccionado(int id)
        {
            hilo = ENHilo.Obtener(id);
            if (hilo != null)
            {
                textBox_id.Text = hilo.Id.ToString();
                textBox_texto.Text = hilo.Texto;
                textBox_titulo.Text = hilo.Titulo;
                textBox_autor.Text = hilo.Autor.Usuario.ToString();
                textBox_categoria.Text = hilo.Categoria.Nombre.ToString();
                dateTimePicker_fecha.Value = hilo.Fecha;
                textBox_respuestas.Text = hilo.NumRespuestas.ToString();
                linkLabel_respuestas.Enabled = true;
                errorProvider1.Clear();
                desactivarBotones();

                categoria = hilo.Categoria;
                usuario = hilo.Autor;
            }
            else
            {
                MessageBox.Show("No se puede cambiar al hilo indicado: " + id);
            }
        }

        public void CambiarNuevo()
        {
            hilo = null;
            categoria = null;
            usuario = null;
            textBox_id.Text = "";
            textBox_texto.Text = "";
            textBox_titulo.Text = "";
            textBox_autor.Text = "";
            textBox_categoria.Text = "";
            textBox_respuestas.Text = "";
            dateTimePicker_fecha.Value = DateTime.Now;
            linkLabel_respuestas.Enabled = false;
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

            }
            else
            {
                correcto = false;
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
                correcto = false;
                errorUsuario = "Debes introducir un autor.";
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
                nuevo.Categoria = categoria;
                nuevo.Fecha = dateTimePicker_fecha.Value;

                if (textBox_id.Text == "")
                {
                    if (nuevo.Guardar())
                    {
                        CambiarSeleccionado(nuevo.Id);
                        MessageBox.Show("Hilo guardado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el hilo");
                    }
                }
                else
                {
                    nuevo.Id = int.Parse(textBox_id.Text);
                    if (nuevo.Actualizar())
                    {
                        desactivarBotones();
                        MessageBox.Show("Hilo actualizado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el hilo.");
                    }
                }
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

        private void button_seleccionarUsuario_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, true, "Volver al panel anterior seleccionando el usuario actual", "Cancelar la selección y volver al panel anterior");
        }

        private void button_seleccionarCategoria_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormCategorias(), "Seleccionando categoría", true, true, "Volver al panel anterior seleccionando la categoría actual", "Cancelar la selección y volver al panel anterior");
        }

        private void linkLabel_respuestas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormForoRespuestas(hilo), "Respuestas del hilo nº "+textBox_id.Text, true, false, "Volver al hilo", "");
        }

        public override void Recibir(object objeto)
        {
            if (objeto != null)
            {
                if (objeto is ENCategoria)
                {
                    categoria = (ENCategoria)objeto;
                    textBox_categoria.Text = categoria.Nombre;
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
    }
}
