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
    public partial class FormForo : UserControl
    {
        public FormForo()
        {
            InitializeComponent();
            anadirAlgunosHilos();
        }

        private void anadirAlgunosHilos()
        {
            for (int i = 0; i < 10; i++)
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView1);
                fila.Cells[0].Value = "¿Qué tal el examen?";
                fila.Cells[1].Value = "Pues eso, cómo os ha ido el examen? A mí to mal";
                fila.Cells[2].Value = "Antonio";
                fila.Cells[3].Value = "10/05/2009";
                fila.Cells[4].Value = "11/05/2009";
                fila.Cells[5].Value = "4";
                dataGridView1.Rows.Add(fila);
            }
        }

        private void bCrearHilo_Click(object sender, EventArgs e)
        {
            FormHilo form = new FormHilo();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormHilo form = new FormHilo();
            form.Show();
        }
    }
}
