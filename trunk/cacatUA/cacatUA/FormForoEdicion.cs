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
    }
}
