using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cacatUA
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            // Limpiamos la etiqueta de mensajes
            label_mensaje.Text = "";
        }

        private void button_conectar_Click(object sender, EventArgs e)
        {
            // Validamos los datos
            string usuario = textBox_usuario.Text;
            string contraseña = textBox_contraseña.Text;
            bool correcto = Login.validarDatos(usuario, contraseña);
            if (correcto == true)
            {
                // Mostramos el panel de administración
                FormPanelAdministracion panel = new FormPanelAdministracion();
                //FormPanelAdministracion panel = new FormPanelAdministracion();
                panel.Show();
                this.Hide();
            }
            else
            {
                // Mostramos el mensaje de error
                label_mensaje.Text = "Error: Usuario o contraseña no válidos";
            }
        }

        private void button_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
