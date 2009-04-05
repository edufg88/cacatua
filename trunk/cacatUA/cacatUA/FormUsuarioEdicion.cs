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
    public partial class FormUsuarioEdicion : UserControl
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

            textBox_nombre.Text = usuario.Usuario;
            textBox_email.Text = usuario.Correo;
            dateTimePicker_fechaDeIngreso.Value = usuario.Fechaingreso;
            checkBox_esAdmin.Checked = usuario.EsAdministrador();
        }

        private void button_buscarFirma_Click(object sender, EventArgs e)
        {
            // Código para buscar firmas

            // Aquí cargamos el DataGridView
        }

        private void button_buscarGaleria_Click(object sender, EventArgs e)
        {
            // Código para buscar firmas
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
        }

        private void button_descartarCambios_Click(object sender, EventArgs e)
        {
            // Código para descartar los cambios
        }
    }
}
