using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Libreria;

namespace cacatUA
{
    public partial class FormPeticiones : UserControl
    {
        public FormPeticiones()
        {
            InitializeComponent();
            anadirPeticiones();
        }

        private void anadirPeticiones()
        {
            ArrayList a = ENPeticionCRUD.getContestadas();

            DataGridViewRow fila=null;
            int i = 0;

            foreach(ENPeticionCRUD p in a)
            {
                fila= new DataGridViewRow();
                fila.CreateCells(dataGridView_Anteriores);
                fila.Cells[0].Value = p.Usuario;
                fila.Cells[1].Value = p.Asunto;
                fila.Cells[2].Value = p.Fecha;
                fila.Cells[3].Value = p.Texto;
                fila.Cells[4].Value = p.Id;
                dataGridView_Anteriores.Rows.Add(fila);
                i++;

            }

            a = ENPeticionCRUD.getSinContestar();

            i = 0;

            foreach (ENPeticionCRUD p in a)
            {
                fila = new DataGridViewRow();
                fila.CreateCells(dataGridViewRecientes);
                fila.Cells[0].Value = p.Usuario;
                fila.Cells[1].Value = p.Asunto;
                fila.Cells[2].Value = p.Fecha;
                fila.Cells[3].Value = p.Texto;
                fila.Cells[4].Value = p.Id;
                dataGridViewRecientes.Rows.Add(fila);
                i++;

            }

        }

        
        private void buttonUsuario_Click(object sender, EventArgs e)
        {
            FormUsuario form = new FormUsuario();
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.Show();
        }
        private void buttonMensajes_Click(object sender, EventArgs e)
        {
            FormMensaje form = new FormMensaje();
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.Size = new Size(800, 400);
            form.Show();
        }

        private void buttonRealizada_Click(object sender, EventArgs e)
        {
            if (dataGridViewRecientes.SelectedRows != null)
            {
                /*DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridViewRecientes);
                dataGridViewRecientes.SelectedCells.ToString();*/


            }

        }

        private void panel_cabeceraSeccion1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Antiguas_Click(object sender, EventArgs e)
        {

        }

        private void label_buscarPetTitulo_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl_peticiones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_contestarPeticion_Click(object sender, EventArgs e)
        {
            if (dataGridViewRecientes.SelectedRows != null)
            {
          
                dataGridViewRecientes.Rows[dataGridViewRecientes.CurrentCell.RowIndex].Selected = true;
                
                DataGridViewSelectedRowCollection filas = dataGridViewRecientes.SelectedRows;

                DataGridViewRow fila = fila = filas[0];
                dataGridViewRecientes.ClearSelection();
                dataGridViewRecientes.Rows[fila.Index].Selected = true;
                string id = fila.Cells["Autor"].Value.ToString();
                FormContestarPeticion form = new FormContestarPeticion(id);
                form.Show();
            }
        }

        private void dataGridViewRecientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewRecientes.SelectedRows != null)
            {

                dataGridViewRecientes.Rows[dataGridViewRecientes.CurrentCell.RowIndex].Selected = true;

                DataGridViewSelectedRowCollection filas = dataGridViewRecientes.SelectedRows;

                DataGridViewRow fila = fila = filas[0];
                dataGridViewRecientes.ClearSelection();
                dataGridViewRecientes.Rows[fila.Index].Selected = true;
                string id = fila.Cells["id"].Value.ToString();
                FormContestarPeticion form = new FormContestarPeticion(id);
                form.Show();
            }
        }

        private void button_borrarPeticion_Click(object sender, EventArgs e)
        {
            if (dataGridViewRecientes.SelectedCells.Count >0)
            {
                if (dataGridViewRecientes.SelectedRows != null)
                {

                    dataGridViewRecientes.Rows[dataGridViewRecientes.CurrentCell.RowIndex].Selected = true;

                    DataGridViewSelectedRowCollection filas = dataGridViewRecientes.SelectedRows;

                    DataGridViewRow fila = fila = filas[0];
                    dataGridViewRecientes.ClearSelection();
                    dataGridViewRecientes.Rows[fila.Index].Selected = true;
                    dataGridViewRecientes.Rows.Remove(dataGridViewRecientes.CurrentRow);
                }
            }
        }

        private void button_borrarPeticionAnt_Click(object sender, EventArgs e)
        {
            if (dataGridView_Anteriores.SelectedCells.Count > 0)
            {
                if (dataGridView_Anteriores.SelectedRows != null)
                {

                    dataGridView_Anteriores.Rows[dataGridView_Anteriores.CurrentCell.RowIndex].Selected = true;

                    DataGridViewSelectedRowCollection filas = dataGridView_Anteriores.SelectedRows;

                    DataGridViewRow fila = fila = filas[0];
                    dataGridView_Anteriores.ClearSelection();
                    dataGridView_Anteriores.Rows[fila.Index].Selected = true;
                    dataGridView_Anteriores.Rows.Remove(dataGridView_Anteriores.CurrentRow);
                }
            }
        }

        
    }
}
