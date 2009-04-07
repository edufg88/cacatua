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
        public FormPeticionContestar(string p, FormPeticiones fp)
        {
            InitializeComponent();
            pet = ENPeticion.GetPeticion(int.Parse(p));
            peticiones=fp;
            this.textBox_envPetUsuario.Text =pet.Usuario.Usuario;
            this.textBox_envPetAsunto.Text = pet.Asunto;
            this.richTextBox_envPetPeticion.Text = pet.Texto;
            
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            peticiones.ContestarPeticion(pet.Id);
            
            pet.Respuesta = richTextBox_envPetRespuesta.Text;
            ENPeticion.ActualizarPeticion(pet);
            Close();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
