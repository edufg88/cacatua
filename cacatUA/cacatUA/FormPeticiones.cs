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
    public partial class FormPeticiones : InterfazForm
    {
        public FormPeticiones()
        {
            InitializeComponent();
            anadirPeticiones();
        }

        private void anadirPeticiones()
        {
            ArrayList a = ENPeticion.GetContestadas();

            DataGridViewRow fila=null;
            int i = 0;

            foreach(ENPeticion p in a)
            {
                fila= new DataGridViewRow();
                fila.CreateCells(dataGridView_Anteriores);
                fila.Cells[0].Value = p.Usuario.Usuario;
                fila.Cells[1].Value = p.Asunto;
                fila.Cells[2].Value = p.Fecha;
                fila.Cells[3].Value = p.Texto;
                fila.Cells[4].Value = p.Id;
                dataGridView_Anteriores.Rows.Add(fila);
                i++;

            }

            a = ENPeticion.GetSinContestar();

            i = 0;

            foreach (ENPeticion p in a)
            {
                fila = new DataGridViewRow();
                fila.CreateCells(dataGridViewRecientes);
                fila.Cells[0].Value = p.Usuario.Usuario;
                fila.Cells[1].Value = p.Asunto;
                fila.Cells[2].Value = p.Fecha;
                fila.Cells[3].Value = p.Texto;
                fila.Cells[4].Value = p.Id;
                dataGridViewRecientes.Rows.Add(fila);
                i++;

            }

        }

        public void ContestarPeticion(int id)
        {
            DataGridViewRow fila = new DataGridViewRow();
            DataGridViewRow origen;
            string stringid = "" + id;
            for (int i = 0; i < dataGridViewRecientes.Rows.Count; i++)
            {
                origen = dataGridViewRecientes.Rows[i];
                if (origen.Cells[4].Value.ToString() == stringid)
                {
                    fila.CreateCells(dataGridView_Anteriores);
                    fila.Cells[0].Value = origen.Cells[0].Value;
                    fila.Cells[1].Value = origen.Cells[1].Value;
                    fila.Cells[2].Value = origen.Cells[2].Value;
                    fila.Cells[3].Value = origen.Cells[3].Value;
                    fila.Cells[4].Value = origen.Cells[4].Value;
                    dataGridView_Anteriores.Rows.Add(fila);
                    dataGridViewRecientes.Rows.Remove(dataGridViewRecientes.Rows[i]);
                    richTextBox_peticionSeleccionada.Text = "";
                    break;
                }
            }

            

           
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
                if (dataGridViewRecientes.SelectedCells.Count > 0)
                {

                    dataGridViewRecientes.Rows[dataGridViewRecientes.CurrentCell.RowIndex].Selected = true;

                    DataGridViewSelectedRowCollection filas = dataGridViewRecientes.SelectedRows;

                    DataGridViewRow fila = fila = filas[0];
                    dataGridViewRecientes.ClearSelection();
                    dataGridViewRecientes.Rows[fila.Index].Selected = true;
                    string id = fila.Cells["Autor"].Value.ToString();
                    FormPeticionContestar form = new FormPeticionContestar(id,this);
                    form.Show();
                }
            }
        }

        private void dataGridViewRecientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewRecientes.SelectedRows != null)
            {
                if (dataGridViewRecientes.SelectedCells.Count > 0)
                {
                    dataGridViewRecientes.Rows[dataGridViewRecientes.CurrentCell.RowIndex].Selected = true;

                    DataGridViewSelectedRowCollection filas = dataGridViewRecientes.SelectedRows;

                    DataGridViewRow fila = fila = filas[0];
                    dataGridViewRecientes.ClearSelection();
                    dataGridViewRecientes.Rows[fila.Index].Selected = true;
                    string id = fila.Cells["id"].Value.ToString();
                    FormPeticionContestar form = new FormPeticionContestar(id,this);
                    form.Show();
                }
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
                    ENPeticion.BorrarPeticion(int.Parse(dataGridViewRecientes.Rows[fila.Index].Cells[4].Value.ToString()));
                    richTextBox_peticionSeleccionada.Text = "";
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
                    ENPeticion.BorrarPeticion(int.Parse(dataGridView_Anteriores.Rows[fila.Index].Cells[4].Value.ToString()));
                    richTextBox_peticionSeleccionadaAnt.Text = "";
                    dataGridView_Anteriores.Rows.Remove(dataGridView_Anteriores.CurrentRow);
                }
            }
        }

        private void dataGridViewRecientes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewRecientes.SelectedCells.Count > 0)
            {
                if (dataGridViewRecientes.SelectedRows != null)
                {
                    dataGridViewRecientes.Rows[dataGridViewRecientes.CurrentCell.RowIndex].Selected = true;

                    DataGridViewSelectedRowCollection filas = dataGridViewRecientes.SelectedRows;

                    DataGridViewRow fila = fila = filas[0];
                    dataGridViewRecientes.ClearSelection();
                    dataGridViewRecientes.Rows[fila.Index].Selected = true;

                    ENPeticion pet = ENPeticion.GetPeticion(int.Parse(dataGridViewRecientes.Rows[fila.Index].Cells[4].Value.ToString()));

                    richTextBox_peticionSeleccionada.Text = "Usuario: " + pet.Usuario +
                        "\nFecha: " + pet.Fecha + "\nAsunto: " + pet.Asunto +
                        "\nMensaje: " + pet.Texto;
                }
            }
        }

        private void dataGridView_Anteriores_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

                    ENPeticion pet = ENPeticion.GetPeticion(int.Parse(dataGridView_Anteriores.Rows[fila.Index].Cells[4].Value.ToString()));

                    richTextBox_peticionSeleccionadaAnt.Text = "Usuario: " + pet.Usuario +
                        "\nFecha: " + pet.Fecha + "\nAsunto: " + pet.Asunto +
                        "\nMensaje: " + pet.Texto + "\nRespuesta: " + pet.Respuesta;
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            
        }

        private void button_seccionBuscar_Click(object sender, EventArgs e)
        {

            dataGridViewRecientes.Rows.Clear();
            string usuario= textBox_buscarPetAutor.Text;
            if ( usuario == "")
            {
                usuario = "0";
            }

            ArrayList a = ENPeticion.Obtener(textBox_buscarPetTitulo.Text,textBox_buscarPetTexto.Text,int.Parse(usuario));

            DataGridViewRow fila = null;
            int i = 0;

            foreach (ENPeticion p in a)
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

        
    }
}
