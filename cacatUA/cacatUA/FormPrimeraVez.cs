using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Libreria;

namespace cacatUA
{
    public partial class FormPrimeraVez : Form
    {
        public FormPrimeraVez()
        {
            InitializeComponent();
        }

        private void button_conectar_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                bool correcto = false;
                ENUsuario usuario = new ENUsuario();
                usuario.Usuario = textBox_usuario.Text;
                usuario.Contrasena = textBox_contraseña.Text;
                usuario.Activo = true;
                if (usuario.Guardar())
                {
                    usuario = ENUsuario.Obtener(textBox_usuario.Text);
                    if (usuario.GuardarAdmin())
                    {
                        correcto = true;
                    }
                }

                if (correcto)
                {
                    this.Hide();
                    FormPanelAdministracion panel = FormPanelAdministracion.Instancia;
                    panel.Usuario = usuario;
                    panel.Show();
                }
                else
                {
                    label_error.Visible = true;
                }
            }
        }

        private void button_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validarDatos()
        {
            bool correcto = true;

            errorProvider1.Clear();


            if (textBox_usuario.Text.Length <= 0 || textBox_usuario.Text.Length >= 50)
            {
                correcto = false;
                errorProvider1.SetError(textBox_usuario, "El usuario debe tener entre 1 y 50 caracteres");
            }

            if (textBox_contraseña.Text != textBox_contraseña2.Text)
            {
                correcto = false;
                errorProvider1.SetError(textBox_contraseña, "Las contraseñas deben coincidir");
            }
            else
            {
                if (textBox_contraseña.Text.Length <= 0 || textBox_contraseña.Text.Length >= 50)
                {
                    correcto = false;
                    errorProvider1.SetError(textBox_contraseña, "La contraseña debe tener entre 1 y 50 caracteres");
                }
            }

            return correcto;
        }
    }
}
