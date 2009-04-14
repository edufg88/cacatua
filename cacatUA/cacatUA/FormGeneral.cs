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
    public partial class FormGeneral : InterfazForm
    {
        public FormGeneral()
        {
            InitializeComponent();
        }

        private void FormGeneral_Load(object sender, EventArgs e)
        {
            textBox_categoriasCreadas.Text = ENCategoria.NumCategorias().ToString();
        }
    }
}
