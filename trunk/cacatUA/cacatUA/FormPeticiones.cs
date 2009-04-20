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

        private int cantidadPorPagina;
        public int CantidadPorPagina
        {
            get { return cantidadPorPagina; }
            set { cantidadPorPagina = value; }
        }

        private string propiedadOrdenar;
        public string PropiedadOrdenar
        {
            get { return propiedadOrdenar; }
            set { propiedadOrdenar = value; }
        }

        private int pagina;
        public int Pagina
        {
            get { return pagina; }
            set { pagina = value; }
        }

        public SortOrder Orden()
        {
            string nomColumna = "dataGridViewTextBoxColumn_" + propiedadOrdenar;
            return dataGridView_Peticiones.Columns[nomColumna].HeaderCell.SortGlyphDirection;
        }

        public FormPeticiones()
        {
            InitializeComponent();
            radioButton_Ambas.Checked = true;

            cantidadPorPagina = 10;
            comboBox_cantidadPorPagina.Text = CantidadPorPagina.ToString();
            comboBox_pagina.Text = "1";
            pagina = 1;
            propiedadOrdenar = "id";
            dataGridView_Peticiones.Columns["dataGridViewTextBoxColumn_id"].HeaderCell.SortGlyphDirection = SortOrder.Descending;
            
            ActualizarPaginacion(numeroResultados());
            ActualizarPeticiones();
            
            
        }

        public void ActualizarPeticiones()
        {

            int resultados = 0;

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

            bool ascendente = false;
            if (SortOrder.Ascending== Orden())
            {
                ascendente = true;
            }

            DateTime inicio = dateTimePicker_FechaInicio.Value;
            DateTime fin = dateTimePicker_FechaFin.Value;
            ArrayList a = ENPeticion.Obtener(textBox_buscarPeticionAsunto.Text, textBox_buscarPeticionTexto.Text, int.Parse(usuario), mostrar,ref inicio,ref fin,porFecha,propiedadOrdenar,ascendente,Pagina,CantidadPorPagina,ref resultados);
            
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

            richTextBox_PeticionSeleccionada.Text = "Selecciona una Petición para verla";
            
        }

        private int numeroResultados()
        {
            int resultados = 0;

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
            
            ArrayList a = ENPeticion.Obtener(textBox_buscarPeticionAsunto.Text, textBox_buscarPeticionTexto.Text, int.Parse(usuario), mostrar, ref inicio, ref fin, porFecha, propiedadOrdenar, true, Pagina, CantidadPorPagina, ref resultados);

            return resultados;
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
                    if (fila.Cells["dataGridViewTextBoxColumn_Respuesta"].Value.ToString() == "")
                    {
                        string id = fila.Cells["dataGridViewTextBoxColumn_Id"].Value.ToString();
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
                    if (fila.Cells["dataGridViewTextBoxColumn_Respuesta"].Value.ToString() == "")
                    {
                        string id = fila.Cells["dataGridViewTextBoxColumn_Id"].Value.ToString();
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
                    richTextBox_PeticionSeleccionada.Text = "Seleccione una Petición para verla";

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
                    errorProvider1.SetError(panel_BuscarPorAutor, "");
                    errorProvider2.SetError(checkBox_BuscarPeticionesPorFecha, "");
                    pagina = 1;
                    comboBox_pagina.Text = "1";
                    ActualizarPaginacion(numeroResultados());
                    ActualizarPeticiones();
                }
            }
            else
            {
                errorProvider1.SetError(panel_BuscarPorAutor, "El autor no es valido");
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
                    ActualizarPaginacion(numeroResultados());
                    ActualizarPeticiones();
                }
            }
        }

        private void button_LimpiarBusquedaPeticion_Click(object sender, EventArgs e)
        {
            textBox_buscarPeticionAsunto.Text = "";
            textBox_buscarPeticionAutor.Text= "";
            textBox_buscarPeticionTexto.Text= "";
            dateTimePicker_FechaInicio.Value = new DateTime(2008, 9, 1);
            dateTimePicker_FechaFin.Value = DateTime.Now;
            errorProvider2.Clear();
            errorProvider1.Clear();
        }

        private void button_paginaSiguiente_Click(object sender, EventArgs e)
        {
            pagina++;
            comboBox_pagina.Text = pagina.ToString();
            ActualizarPaginacion(numeroResultados());
            ActualizarPeticiones();
        }

        private void button_paginaAnterior_Click(object sender, EventArgs e)
        {
            pagina--;
            comboBox_pagina.Text = pagina.ToString();
            ActualizarPaginacion(numeroResultados());
            ActualizarPeticiones();
        }

        /// <summary>
        /// Cuando en el formulario de búsqueda se realiza una búsqueda, este llama a esta función y le pasa
        /// el número de resultados obtenidos y el array list con todos los resultados obtenidos en función
        /// del número de resultados por página indicado.
        /// </summary>
        public void ActualizarPaginacion(int totalResultados)
        {
            if (totalResultados > 0)
            {
                int paginas = (int)Math.Ceiling(totalResultados / (float)CantidadPorPagina);
                // Añadimos las páginas al combo box
                string paginaActual = pagina.ToString();
                comboBox_pagina.Items.Clear();
                for (int i = 1; i <= paginas; i++)
                    comboBox_pagina.Items.Add(i.ToString());
                comboBox_pagina.Text = paginaActual;

                int inicial = (pagina - 1) * CantidadPorPagina + 1;
                int final = inicial - 1 + CantidadPorPagina;
                if (final > totalResultados) final = totalResultados;

                label_resultados.Text = "(mostrando " + inicial + " - " + final + " de " + totalResultados + " materiales encontrados)";
                if (comboBox_pagina.Text == "1")
                    button_paginaAnterior.Enabled = false;
                else
                    button_paginaAnterior.Enabled = true;

                if (comboBox_pagina.Text == paginas.ToString())
                    button_paginaSiguiente.Enabled = false;
                else
                    button_paginaSiguiente.Enabled = true;
            }
            else
            {
                label_resultados.Text = "(no hay resultados con este criterio de búsqueda)";
                button_paginaAnterior.Enabled = false;
                button_paginaSiguiente.Enabled = false;
            }
        }

        

        

        private void comboBox_cantidadPorPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            cantidadPorPagina = int.Parse(comboBox_cantidadPorPagina.Text.ToString());
        }

        private void dataGridView_Peticiones_CellClick(object sender, DataGridViewCellEventArgs e)
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
            if (e.RowIndex < 0)
            {
                ordenModificado(e.ColumnIndex);
            }
        }

        private void ordenModificado(int numColumna)
        {
            // Obtenemos la columna a ordenar
            DataGridViewColumn columna = dataGridView_Peticiones.Columns[numColumna];
            // Obtenemos el nombre de la columna que estaba ordenada anteriormente
            string nomColumnaAnterior = "dataGridViewTextBoxColumn_" + propiedadOrdenar;
            // Comprobamos si coincide con la columna actual
            if (columna.Name == nomColumnaAnterior)
            {
                // Coincide, cambiamos el orden
                
                if (columna.HeaderCell.SortGlyphDirection == SortOrder.Ascending)
                {
             
                    columna.HeaderCell.SortGlyphDirection = SortOrder.Descending;
                    
                }
                else
                {
                    columna.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                }
            }
            else
            {
                // Si no coincide, quitamos al orden a la anterior columna
                dataGridView_Peticiones.Columns[nomColumnaAnterior].HeaderCell.SortGlyphDirection = SortOrder.None;
                // Ponemos por defecto a la nueva columna descendente
                columna.HeaderCell.SortGlyphDirection = SortOrder.Descending;
                // Guardamos la nueva propiedad por la que ordenamos
                string nomColumna = columna.Name;
                propiedadOrdenar = nomColumna.Substring(nomColumna.LastIndexOf('_') + 1);
            }
            FormPanelAdministracion.Instancia.MensajeEstado("Ordenando columna " + columna.HeaderText + " en modo " + Orden().ToString());
            pagina = 1;
            comboBox_pagina.Text = pagina.ToString();
            
            ActualizarPeticiones();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, true, "Volver al panel anterior seleccionando el usuario actual", "Cancelar la selección y volver al panel anterior");
        }

        private void comboBox_cantidadPorPagina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cantidadPorPagina = int.Parse(comboBox_cantidadPorPagina.Text.ToString());
            ActualizarPaginacion(numeroResultados());
            ActualizarPeticiones();
        }

        private void comboBox_pagina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            pagina = int.Parse(comboBox_pagina.Text.ToString());
            ActualizarPaginacion(numeroResultados());
            ActualizarPeticiones();

        }

        private void dataGridView_Peticiones_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

        }

    }
}
