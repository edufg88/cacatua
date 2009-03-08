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
    public partial class FormMaterial : Form
    {
        public enum modos { EDITAR = 0, NUEVO = 1 };

        public FormMaterial()
        {
            InitializeComponent();
        }

        public void setModo(modos modo)
        {
            this.modo = modo;
            switch (modo)
            {
                case modos.EDITAR:
                    {
                        button_accion.Text = "Guardar";
                        break;
                    }
                case modos.NUEVO:
                    {
                        button_accion.Text = "Crear";
                        break;
                    }
            }
        }

        private modos modo;

        private void button9_Click(object sender, EventArgs e)
        {
            FormCategoria form = new FormCategoria();
            //form.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            //form.Location = new Point(button_buscarCategoria.Location.X, button_buscarCategoria.Location.Y);
            form.ShowDialog();
        }
    }
}
