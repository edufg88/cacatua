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
            radioButton_Ambas.Checked = true;
            ActualizarPeticiones();
            
            
        }

        public void ActualizarPeticiones()
        {

            dataGridView_Peticiones.Rows.Clear();
            string usuario = textBox_buscarPeticionAutor.Text;
            if (usuario == "")
            {
                usuario = "0";
            }
            else
            {
                ENUsuario us = ENUsuario.Obtener(usuario);
                usuario = "" + us.Id;
            }

            int mostrar = 0;

            if (radioButton_Ambas.Checked)
            {
                mostrar = 0;
            }
            if (radioButton_SinContestar.Checked)
            {
                mostrar = 1;
            }
            if (radioButton_Contestadas.Checked)
            {
                mostrar = 2;
            }

            bool porFecha = false;

            if (checkBox_BuscarPeticionesPorFecha.Checked)
            {
                porFecha = true;
            }

            DateTime inicio = dateTimePicker_FechaInicio.Value;
            DateTime fin = dateTimePicker_FechaFin.Value;
            ArrayList a = ENPeticion.Obtener(textBox_buscarPeticionAsunto.Text, textBox_buscarPeticionTexto.Text, int.Parse(usuario), mostrar,ref inicio,ref fin,porFecha);

            DataGridViewRow fila = null;
            int i = 0;

            foreach (ENPeticion p in a)
            {
                fila = new DataGridViewRow();
                fila.CreateCells(dataGridView_Peticiones);
                fila.Cells[0].Value = p.Usuario.Usuario;
                fila.Cells[1].Value = p.Asunto;
                fila.Cells[2].Value = p.Fecha;
                fila.Cells[3].Value = p.Texto;
                fila.Cells[4].Value = p.Respuesta;
                fila.Cells[5].Value = p.Id;
                dataGridView_Peticiones.Rows.Add(fila);
                i++;

            }
        }

        

        private void radioButton_SinContestar_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton_Contestadas_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton_Ambas_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView_Peticiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataGridView_Peticiones.SelectedRows != null)
            {
                if (dataGridView_Peticiones.SelectedCells.Count > 0)
                {
                    dataGridView_Peticiones.Rows[dataGridView_Peticiones.CurrentCell.RowIndex].Selected = true;

                    DataGridViewSelectedRowCollection filas = dataGridView_Peticiones.SelectedRows;

                    DataGridViewRow fila = fila = filas[0];
                    dataGridView_Peticiones.ClearSelection();
                    dataGridView_Peticiones.Rows[fila.Index].Selected = true;
                    if (fila.Cells["Respuesta"].Value.ToString()=="")
                    {
                        string id = fila.Cells["Id"].Value.ToString();
                        FormPeticionContestar form = new FormPeticionContestar(id, this);
                        form.Show();
                    }
                    
                }
            }

        }

        private void button_contestarPeticion_Click(object sender, EventArgs e)
        {
            if (dataGridView_Peticiones.SelectedRows != null)
            {
                if (dataGridView_Peticiones.SelectedCells.Count > 0)
                {
                    dataGridView_Peticiones.Rows[dataGridView_Peticiones.CurrentCell.RowIndex].Selected = true;

                    DataGridViewSelectedRowCollection filas = dataGridView_Peticiones.SelectedRows;

                    DataGridViewRow fila = fila = filas[0];
                    dataGridView_Peticiones.ClearSelection();
                    dataGridView_Peticiones.Rows[fila.Index].Selected = true;
                    if (fila.Cells["Respuesta"].Value.ToString() == "")
                    {
                        string id = fila.Cells["Id"].Value.ToString();
                        FormPeticionContestar form = new FormPeticionContestar(id, this);
                        form.Show();
                    }

                }
            }
        }

        private void button_borrarPeticion_Click(object sender, EventArgs e)
        {
            if (dataGridView_Peticiones.SelectedCells.Count > 0)
            {
                if (dataGridView_Peticiones.SelectedRows != null)
                {

                    if(MessageBox.Show("¿Esta seguro de que desea borrar la petición seleccionada?","Borrar petición",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes){
                    dataGridView_Peticiones.Rows[dataGridView_Peticiones.CurrentCell.RowIndex].Selected = true;

                    DataGridViewSelectedRowCollection filas = dataGridView_Peticiones.SelectedRows;

                    DataGridViewRow fila = fila = filas[0];
                    dataGridView_Peticiones.ClearSelection();
                    dataGridView_Peticiones.Rows[fila.Index].Selected = true;
                    ENPeticion.Obtener(int.Parse(dataGridView_Peticiones.Rows[fila.Index].Cells[5].Value.ToString())).Borrar();
                    dataGridView_Peticiones.Rows.Remove(dataGridView_Peticiones.CurrentRow);

                    }
                }
            }

        }

        private void dataGridView_Peticiones_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_Peticiones.SelectedCells.Count > 0)
            {
                if (dataGridView_Peticiones.SelectedRows != null)
                {


                    dataGridView_Peticiones.Rows[dataGridView_Peticiones.CurrentCell.RowIndex].Selected = true;

                    DataGridViewSelectedRowCollection filas = dataGridView_Peticiones.SelectedRows;

                    DataGridViewRow fila = fila = filas[0];
                    dataGridView_Peticiones.ClearSelection();
                    dataGridView_Peticiones.Rows[fila.Index].Selected = true;
                    string mostrar = "Autor: " + fila.Cells[0].Value.ToString() +
                        "\nAsunto: " + fila.Cells[1].Value.ToString() +
                        "\nFecha: " + fila.Cells[2].Value.ToString() +
                        "\nTexto: " + fila.Cells[3].Value.ToString();
                    if (fila.Cells[0].Value.ToString() != "")
                    {
                        mostrar += "\nRespuesta: " + fila.Cells[4].Value.ToString();
                    }
                    richTextBox_PeticionSeleccionada.Text = mostrar;
                }
            }
        }

        private void button_buscarPeticiones_Click(object sender, EventArgs e)
        {
            ENUsuario us =  ENUsuario.Obtener(textBox_buscarPeticionAutor.Text.ToString());

            
            if (textBox_buscarPeticionAutor.Text == "" || us!=null)
            {
                DateTime inicio = dateTimePicker_FechaInicio.Value;
                DateTime final = dateTimePicker_FechaFin.Value;
                if (inicio>final && checkBox_BuscarPeticionesPorFecha.Checked)
                {
                    errorProvider2.SetError(checkBox_BuscarPeticionesPorFecha, "La fecha de inicio no puede ser posterior a la de final de periodo");
                }
                else
                {
                    errorProvider1.SetError(textBox_buscarPeticionAutor, "");
                    errorProvider2.SetError(checkBox_BuscarPeticionesPorFecha, "");
                    ActualizarPeticiones();
                }
            }
            else
            {
                errorProvider1.SetError(textBox_buscarPeticionAutor, "El autor no es valido");
            }
        }

        private void dateTimePicker7_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button_seleccionarUsuario_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, true, "Volver al panel anterior seleccionando el usuario actual", "Cancelar la selección y volver al panel anterior");
        }

        public override void Recibir(object objeto)
        {
            if (objeto != null)
            {
                if (objeto is ENUsuario)
                {
                    ENUsuario usuario = (ENUsuario)objeto;
                    textBox_buscarPeticionAutor.Text = usuario.Usuario;
                }
            }
        }




    }
}
