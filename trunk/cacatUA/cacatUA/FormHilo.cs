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
    public partial class FormHilo : Form
    {
        public FormHilo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormCategoria form = new FormCategoria();
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //int posX = button_Seleccionar_categoria.Location.X;
            //int posY = button_Seleccionar_categoria.Location.Y;
            //posX += this.ParentForm.Location.X;
            //posX += this.ParentForm.Location.Y;
            //form.Location = new Point(posX, posY);
            form.ShowDialog();
        }
    }
}
