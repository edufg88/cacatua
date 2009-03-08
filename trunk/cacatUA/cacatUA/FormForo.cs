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
                fila.CreateCells(dataGridView_hilos);
                fila.Cells[0].Value = "¿Qué tal el examen?";
                fila.Cells[1].Value = "Pues eso, cómo os ha ido el examen? A mí to mal";
                fila.Cells[2].Value = "Antonio";
                fila.Cells[3].Value = "10/05/2009";
                fila.Cells[4].Value = "11/05/2009";
                fila.Cells[5].Value = "4";
                dataGridView_hilos.Rows.Add(fila);
            }
        }

        private void button_anadirHilo_Click(object sender, EventArgs e)
        {
            FormHilo form = new FormHilo();
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            form.Show();
        }

        private void button_modificarHilo_Click(object sender, EventArgs e)
        {
            FormHilo form = new FormHilo();
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            // En este punto hay que pasarle el objeto del tipo Hilo que contiene los datos.
            form.Show();
        }

        private void button_seleccionarCategoria_Click(object sender, EventArgs e)
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

        private void button_eliminarHilo_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection filas = dataGridView_hilos.SelectedRows;
            String mensaje;
            if (filas.Count > 1)
            {
                mensaje = "¿Está seguro de que desea eliminar los hilos seleccionados?";
            }
            else
            {
                mensaje = "¿Está seguro de que desea eliminar el hilo seleccionado?";
            }

            DialogResult resultado = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                for (int i = 0; i < filas.Count; i++)
                {
                    // Obtenemos la fila
                    DataGridViewRow fila = filas[i];
                    // Eliminamos la fila
                    dataGridView_hilos.Rows.Remove(fila);
                }
            }
        }
    }
}
