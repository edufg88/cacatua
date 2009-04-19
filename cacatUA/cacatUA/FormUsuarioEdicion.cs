using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Libreria;
using System.Collections;

namespace cacatUA
{
    public partial class FormUsuarioEdicion : InterfazForm
    {
        /// <summary>
        /// Puntero al formulario padre
        /// </summary>
        private FormUsuarios padre;

        /// <summary>
        /// Constructor del formulario de edición de usuario
        /// </summary>
        /// <param name="padre">Recibe un puntero al formulario padre</param>
        public FormUsuarioEdicion(FormUsuarios padre)
        {
            InitializeComponent();

            this.padre = padre;
        }

        /// <summary>
        /// Carga el formulario en blanco
        /// </summary>
        public void CambiarNuevo()
        {
            errorProvider1.Clear();

            textBox_id.Text = "";
            textBox_usuario.Text = "";
            textBox_contrasena.Text = "";
            textBox_nombre.Text = "";
            textBox_dni.Text = "";
            textBox_email.Text = "";
            textBox_adicional.Text = "";
            dateTimePicker_fechaDeIngreso.Value = DateTime.Now;

            textBox_numEncuestas.Text = "";
            textBox_numFirmas.Text = "";
            textBox_numImagenes.Text = "";
            textBox_numMensajes.Text = "";

            checkBox_administrador.Checked = false;
            checkBox_activo.Checked = false;
        }

        /// <summary>
        /// Carga el formulario con los datos del usuario recibido
        /// </summary>
        /// <param name="id">Recibe un id del usuario cuyos datos se cargarán</param>
        public void CambiarSeleccionado(int id)
        { 
            // Cargamos los datos del usuario con esa id en los campos
            ENUsuario usuario = ENUsuario.Obtener(id);

            if (usuario != null)
            {
                errorProvider1.Clear();

                textBox_id.Text = usuario.Id.ToString();
                textBox_usuario.Text = usuario.Usuario;
                textBox_contrasena.Text = usuario.Contrasena;
                textBox_nombre.Text = usuario.Nombre;
                textBox_dni.Text = usuario.Dni;
                textBox_email.Text = usuario.Correo;
                textBox_adicional.Text = usuario.Adicional;
                dateTimePicker_fechaDeIngreso.Value = usuario.Fechaingreso;

                textBox_numEncuestas.Text = usuario.CantidadEncuestas().ToString();
                textBox_numFirmas.Text = usuario.CantidadFirmas().ToString();
                textBox_numImagenes.Text = usuario.CantidadImagenes().ToString();
                textBox_numMensajes.Text = usuario.CantidadMensajes().ToString();

                checkBox_administrador.Checked = usuario.EsAdministrador();
                checkBox_activo.Checked = usuario.Activo;
            }
        }
        
        /// <summary>
        /// Activa los botones
        /// </summary>
        private void activarBotones()
        {
            button_guardarCambios.Enabled = true;
            button_descartarCambios.Enabled = true;
        }

        /// <summary>
        /// Desactiva los botones
        /// </summary>
        private void desactivarBotones()
        {
            button_guardarCambios.Enabled = false;
            button_descartarCambios.Enabled = false;
        }

        /// <summary>
        /// Valida los campos del formulario
        /// </summary>
        /// <returns>Devuelve true si los campos se validan correctamente, false en caso contrario</returns>
        private bool validarFormulario()
        { 
            // Validamos uno a uno todos los campos
            bool correcto = true;
            string error = "";
            // El nombre de usuario
            error = ENUsuario.ValidarFormulario("usuario", textBox_usuario.Text);
            if (error != "")
            {
                errorProvider1.SetError(textBox_usuario, error);
                error = "";
                correcto = false;
            }
            // La contraseña
            error = ENUsuario.ValidarFormulario("contrasena", textBox_contrasena.Text);
            if (error != "")
            {
                errorProvider1.SetError(textBox_contrasena, error);
                error = "";
                correcto = false;
            }
            // El nombre
            error = ENUsuario.ValidarFormulario("nombre", textBox_nombre.Text);
            if (error != "")
            {
                errorProvider1.SetError(textBox_nombre, error);
                error = "";
                correcto = false;
            }
            // El email
            error = ENUsuario.ValidarFormulario("correo", textBox_email.Text);
            if (error != "")
            {
                errorProvider1.SetError(textBox_email, error);
                error = "";
                correcto = false;
            }
            // El DNI
            error = ENUsuario.ValidarFormulario("dni", textBox_dni.Text);
            if (error != "")
            {
                errorProvider1.SetError(textBox_dni, error);
                error = "";
                correcto = false;
            }
            // Adicional
            error = ENUsuario.ValidarFormulario("adicional", textBox_adicional.Text);
            if (error != "")
            {
                errorProvider1.SetError(textBox_adicional, error);
                error = "";
                correcto = false;
            }

            return correcto;        
        }

        private void button_guardarCambios_Click(object sender, EventArgs e)
        {
            if (validarFormulario())
            {
                ENUsuario nuevo = new ENUsuario();
                nuevo.Usuario = textBox_usuario.Text;
                nuevo.Contrasena = textBox_contrasena.Text;
                nuevo.Nombre = textBox_nombre.Text;
                nuevo.Correo = textBox_email.Text;
                nuevo.Dni = textBox_dni.Text;
                nuevo.Adicional = textBox_adicional.Text;
                nuevo.Activo = checkBox_activo.Checked;
                
                if (textBox_id.Text == "")
                {
                    if (nuevo.Guardar())
                    {
                        // Comprobamos si el usuario tiene privilegios de administrador
                        if (checkBox_administrador.Checked == true)
                        {
                            ENUsuario aux = ENUsuario.Obtener(nuevo.Usuario);
                            if (aux.GuardarAdmin())
                            {
                                // Si se ha creado, mostramos el mensaje en la barra de estado
                                FormPanelAdministracion.Instancia.MensajeEstado("Usuario guardado correctamente.");
                                // Cambiamos al formulario de búsqueda
                                padre.CambiarFormularioBusqueda();
                                // Recargamos los usuarios
                                padre.CargarUsuarios();
                            }
                            else
                            {
                                FormPanelAdministracion.Instancia.MensajeEstado("Error al guardar como admistrador");
                            }
                        }
                        else
                        {
                            // Si se ha creado, mostramos el mensaje en la barra de estado
                            FormPanelAdministracion.Instancia.MensajeEstado("Usuario guardado correctamente.");
                            // Cambiamos al formulario de búsqueda
                            padre.CambiarFormularioBusqueda();
                            // Recargamos los usuarios
                            padre.CargarUsuarios();
                        }
                    }
                    else
                    {
                        FormPanelAdministracion.Instancia.MensajeEstado("Error al guardar el usuario");
                    }
                }
                else
                {
                    nuevo.Id = int.Parse(textBox_id.Text);
                    if (nuevo.Actualizar())
                    {
                        if (checkBox_administrador.Checked == true)
                        {
                            // Si no era administrador lo creamos
                            if (nuevo.EsAdministrador() == false)
                            {
                                ENUsuario aux = ENUsuario.Obtener(nuevo.Usuario);
                                aux.GuardarAdmin();
                            }
                        }
                        else
                        { 
                            // Si era y hemos desmarcado la casilla, lo borramos
                            if (nuevo.EsAdministrador() == true)
                            {
                                ENUsuario aux = ENUsuario.Obtener(nuevo.Usuario);
                                aux.BorrarAdmin();
                            }
                        }
                        
                        FormPanelAdministracion.Instancia.MensajeEstado("Usuario actualizado correctamente.");
                        padre.CargarUsuarios();
                    }
                    else
                    {
                        FormPanelAdministracion.Instancia.MensajeEstado("Error al actualizar el usuario.");
                    }
                }
            }
        }

        private void button_descartarCambios_Click(object sender, EventArgs e)
        {
            if (textBox_id.Text == "")
            {
                CambiarNuevo();
            }
            else
            {
                CambiarSeleccionado(int.Parse(textBox_id.Text));
            }
        }

        private void linkLabel_verFirmas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox_id.Text != "")
            {
                FormPanelAdministracion.Instancia.Apilar(new FormUsuarioFirmas(ENUsuario.Obtener(int.Parse(textBox_id.Text))), "Firmas del usuario nº " + textBox_id.Text, true, false, "Volver al usuario", "");
            }
        }

        private void linkLabel_verImagenes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox_id.Text != "")
            {
                FormPanelAdministracion.Instancia.Apilar(new FormUsuarioImagenes(ENUsuario.Obtener(int.Parse(textBox_id.Text))), "Imágenes del usuario nº " + textBox_id.Text, true, false, "Volver al usuario", "");
            }
        }

        private void linkLabel_verMensajes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox_id.Text != "")
            {
                FormPanelAdministracion.Instancia.Apilar(new FormUsuarioMensajes(ENUsuario.Obtener(int.Parse(textBox_id.Text))), "Mensajes del usuario nº " + textBox_id.Text, true, false, "Volver al usuario", "");
            }
        }

        private void linkLabel_verEncuestas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox_id.Text != "")
            {
                FormPanelAdministracion.Instancia.Apilar(new FormUsuarioEncuestas(ENUsuario.Obtener(int.Parse(textBox_id.Text))), "Encuestas del usuario nº " + textBox_id.Text, true, false, "Volver al usuario", "");
            }
        }
    }
}
