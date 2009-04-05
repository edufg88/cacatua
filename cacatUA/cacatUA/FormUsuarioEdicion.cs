using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cacatUA
{
    public partial class FormUsuarioEdicion : UserControl
    {
        private FormUsuarios padre;

        public FormUsuarioEdicion(FormUsuarios padre)
        {
            InitializeComponent();

            this.padre = padre;
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
    }
}
