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
    public partial class FormContestarPeticion : Form
    {
        private ENPeticion pet;
        public FormContestarPeticion(string p)
        {
            InitializeComponent();
            pet = ENPeticion.GetPeticion(int.Parse(p));
            this.textBox_envPetUsuario.Text = "" + pet.Usuario;
            this.textBox_envPetAsunto.Text = pet.Asunto;
            this.richTextBox_envPetPeticion.Text = pet.Texto;
            
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
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
