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
    public partial class FormForoEdicion : UserControl
    {
        ENHiloCRUD hilo;
        public FormForoEdicion()
        {
            InitializeComponent();
        }

        public void CambiarSeleccionado(int id)
        {
            hilo = new ENHiloCRUD(id);
            textBox_id.Text = hilo.Id.ToString();
            textBox_texto.Text = hilo.Texto;
            textBox_titulo.Text = hilo.Titulo;
        }

        public void CambiarNuevo()
        {
            hilo = null;
            textBox_id.Text = "";
            textBox_texto.Text = "";
            textBox_titulo.Text = "";
            textBox_autor.Text = "";
            textBox_categoria.Text = "";
            textBox_respuestas.Text = "";
        }

        private void button_guardarCambios_Click(object sender, EventArgs e)
        {
            ENHiloCRUD nuevo = new ENHiloCRUD();
            nuevo.Texto = textBox_texto.Text;
            nuevo.Titulo = textBox_titulo.Text;
            nuevo.Guardar();
        }
    }
}
