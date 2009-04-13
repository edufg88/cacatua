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
        // Puntero al formulario padre
        private FormUsuarios padre;

        public FormUsuarioEdicion(FormUsuarios padre)
        {
            InitializeComponent();

            this.padre = padre;
        }

        public void CambiarNuevo()
        {
            textBox_id.Text = "";
            textBox_usuario.Text = "";
            textBox_contrasena.Text = "";
            textBox_nombre.Text = "";
            textBox_dni.Text = "";
            textBox_email.Text = "";
            textBox_adicional.Text = "";
            dateTimePicker_fechaDeIngreso.Value = DateTime.Now;

            checkBox_administrador.Checked = false;
            checkBox_activo.Checked = false;
        }

        public void CambiarSeleccionado(int id)
        { 
            // Cargamos los datos del usuario con esa id en los campos
            ENUsuario usuario = new ENUsuario(id);

            textBox_id.Text = usuario.Id.ToString();
            textBox_usuario.Text = usuario.Usuario;
            textBox_contrasena.Text = usuario.Contrasena;
            textBox_nombre.Text = usuario.Nombre;
            textBox_dni.Text = usuario.Dni;
            textBox_email.Text = usuario.Correo;
            textBox_adicional.Text = usuario.Adicional;
            dateTimePicker_fechaDeIngreso.Value = usuario.Fechaingreso;

            checkBox_administrador.Checked = usuario.EsAdministrador();
            checkBox_activo.Checked = usuario.Activo;
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

        private void CargarFirmas()
        {
            ArrayList al = new ArrayList();
            al = ENFirma.Obtener();
        }

        private bool ValidarFormulario()
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
        

        ////////////////////////////////////
        // MÉTODOS DE INSERCIÓN DE PRUEBA //
        ////////////////////////////////////

        private void insertarFirmasPrueba()
        {
            for (int i = 0; i < 10; i++)
            {
                ENFirma firma = new ENFirma("edu8", "que tal tio" + i.ToString(), DateTime.Now, "edu" + i.ToString());
                firma.Guardar();
            }
        }

        // ---------------------------------

        private void button_guardarCambios_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
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
                            ENUsuario aux = new ENUsuario(nuevo.Usuario);
                            if (aux.GuardarAdmin())
                            {
                                CambiarSeleccionado(nuevo.Id);
                                MessageBox.Show("Usuario guardado correctamente.");
                                padre.CargarUsuarios();
                            }
                            else
                            {
                                MessageBox.Show("Error al guardar como admistrador");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el usuario");
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
                                ENUsuario aux = new ENUsuario(nuevo.Usuario);
                                aux.GuardarAdmin();
                            }
                        }
                        else
                        { 
                            // Si era y hemos desmarcado la casilla, lo borramos
                            if (nuevo.EsAdministrador() == true)
                            {
                                ENUsuario aux = new ENUsuario(nuevo.Usuario);
                                aux.BorrarAdmin();
                            }
                        }
                        MessageBox.Show("Usuario actualizado correctamente.");
                        padre.CargarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el usuario.");
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
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarioFirmas(new ENUsuario(int.Parse(textBox_id.Text))), "Firmas del usuario nº " + textBox_id.Text, true, false, "Volver al usuario", "");
        }

        private void linkLabel_verImagenes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarioImagenes(new ENUsuario(int.Parse(textBox_id.Text))), "Imágenes del usuario nº " + textBox_id.Text, true, false, "Volver al usuario", "");
        }

        private void linkLabel_verMensajes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarioMensajes(new ENUsuario(int.Parse(textBox_id.Text))), "Mensajes del usuario nº " + textBox_id.Text, true, false, "Volver al usuario", "");
        }

        private void linkLabel_verEncuestas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarioEncuestas(new ENUsuario(int.Parse(textBox_id.Text))), "Encuestas del usuario nº " + textBox_id.Text, true, false, "Volver al usuario", "");
        }
    }
}
