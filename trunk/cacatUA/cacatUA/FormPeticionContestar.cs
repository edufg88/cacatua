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
    public partial class FormPeticionContestar : Form
    {
        private ENPeticion pet;
        private FormPeticiones peticiones;
        private bool editado = false;

        public FormPeticionContestar(string p, FormPeticiones fp)
        {
            InitializeComponent();
            pet = ENPeticion.Obtener(int.Parse(p));
            peticiones=fp;
            this.textBox_envPetUsuario.Text =pet.Usuario.Usuario;
            this.textBox_envPetAsunto.Text = pet.Asunto;
            this.richTextBox_envPetPeticion.Text = pet.Texto;
            
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            if(validarRespuesta(richTextBox_envPetRespuesta.Text))
            {            
                pet.Respuesta = richTextBox_envPetRespuesta.Text;
                pet.Actualizar();
                peticiones.ActualizarPeticiones();
                Close();
            }
            else{
                MessageBox.Show("No es una respuesta valida","ERROR");
            }

        }

        private bool validarRespuesta(string respuesta)
        {
            if (respuesta != "descripción detallada del mensaje")
            {
                if (respuesta == "" || respuesta == "\n")
                {
                    return false;
                }
                else
                {
                    if (respuesta.Length > 5000)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void richTextBox_envPetPeticion_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox_envPetRespuesta_TextChanged(object sender, EventArgs e)
        {
            if (editado != true)
            {
                editado = true;
                richTextBox_envPetRespuesta.Text = "";
            }
        }

        private void richTextBox_envPetRespuesta_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
