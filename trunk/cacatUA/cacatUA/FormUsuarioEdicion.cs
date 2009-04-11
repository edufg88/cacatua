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

        public void CambiarSeleccionado(int id)
        { 
            // Cargamos los datos del usuario con esa id en los campos
            ENUsuario usuario = new ENUsuario(id);

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

        private void CargarFirmas()
        {
            ArrayList al = new ArrayList();
            al = ENFirma.Obtener();
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


        private void button_buscarGaleria_Click(object sender, EventArgs e)
        {
            // Código para buscar imagenes
            // Cogemos los datos de los formularios

            // Aquí cargamos el DataGridView
            
        }

        private void button_buscarMensaje_Click(object sender, EventArgs e)
        {
            // Código para buscar firmas
            // Aquí cargamos el DataGridView
        }

        private void button_buscarPeticion_Click(object sender, EventArgs e)
        {
            // Código para buscar firmas
            // Aquí cargamos el DataGridView
        }

        private void button_buscarEncuesta_Click(object sender, EventArgs e)
        {
            // Código para buscar firmas
            // Aquí cargamos el DataGridView
        }

        private void button_guardarCambios_Click(object sender, EventArgs e)
        {
            // Código para almacenar los cambios

            // Comprobamos si existe el usuario
                // Si existe actualizamos
                // Si no existe creamos
        }

        private void button_descartarCambios_Click(object sender, EventArgs e)
        {
            // Código para descartar los cambios
        }

        private void linkLabel_verFirmas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarioFirmas(), "Respuestas del usuario nº " + textBox_id.Text, true, false, "Volver al usuario", "");
        }

        private void linkLabel_verImagenes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarioImagenes(), "Imágenes del usuario nº " + textBox_id.Text, true, false, "Volver al usuario", "");
        }

        private void linkLabel_verMensajes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarioMensajes(), "Mensajes del usuario nº " + textBox_id.Text, true, false, "Volver al usuario", "");
        }

        private void linkLabel_verEncuestas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarioEncuestas(), "Encuestas del usuario nº " + textBox_id.Text, true, false, "Volver al usuario", "");
        }
    }
}
