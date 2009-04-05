using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Libreria;

namespace cacatUA
{
    public partial class FormForo : UserControl
    {
        private FormForoEdicion formEdicion;
        private FormForoBusqueda formBusqueda;

        public FormForo()
        {
            InitializeComponent();

            // Se crean los formularios que se van a utilizar.
            formEdicion = new FormForoEdicion();
            formBusqueda = new FormForoBusqueda(this);
            formEdicion.Dock = DockStyle.Top;
            formBusqueda.Dock = DockStyle.Top;

            // Se oculta la fila del TableLayoutEditor que contiene el botón "Volver".
            tableLayoutPanel_principal.RowStyles[6].Height = 0;


            CambiarFormularioBusqueda();

            Resultados = ENHilo.Obtener();
        }

        public void CambiarFormularioBusqueda()
        {
            label_seccion1.Text = "Búsqueda";
            panel_contenedor.Controls.Clear();
            panel_contenedor.Controls.Add(formBusqueda);
            tableLayoutPanel_principal.RowStyles[3].Height = formBusqueda.Height;
        }

        public void CambiarFormularioEdicion()
        {
            label_seccion1.Text = "Edición";
            panel_contenedor.Controls.Clear();
            panel_contenedor.Controls.Add(formEdicion);
            tableLayoutPanel_principal.RowStyles[3].Height = formEdicion.Height;
        }

        public ArrayList Resultados
        {
            set
            {
                dataGridView_resultados.Rows.Clear();
                ArrayList lista = value;
                for (int i = 0; i < lista.Count; i++)
                {
                    DataGridViewRow fila = new DataGridViewRow();
                    fila.CreateCells(dataGridView_resultados);

                    ENHilo auxiliar = (ENHilo)lista[i];
                    fila.Cells[0].Value = auxiliar.Id.ToString();
                    fila.Cells[1].Value = auxiliar.Titulo.ToString();
                    fila.Cells[2].Value = auxiliar.Texto.ToString();
                    fila.Cells[3].Value = auxiliar.Autor.Usuario.ToString();
                    fila.Cells[4].Value = auxiliar.Fecha.ToString();
                    fila.Cells[5].Value = auxiliar.NumRespuestas;
                    dataGridView_resultados.Rows.Add(fila);
                }
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
            //FormCategoria form = new FormCategoria();
            //form.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //int posX = button_Seleccionar_categoria.Location.X;
            //int posY = button_Seleccionar_categoria.Location.Y;
            //posX += this.ParentForm.Location.X;
            //posX += this.ParentForm.Location.Y;
            //form.Location = new Point(posX, posY);
            //form.ShowDialog();
        }

        private void button_seccionBuscar_Click(object sender, EventArgs e)
        {
            CambiarFormularioBusqueda();
        }

        private void button_seccionCrear_Click(object sender, EventArgs e)
        {
            CambiarFormularioEdicion();
            formEdicion.CambiarNuevo();
        }

        private void dataGridView_resultados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /* FALTA CREAR LA CLASE ENHiloNoseque Y AÑADIR UN MÉTODO A FormForoEdicion QUE RECIBA UN OBJETO DE ESE TIPO.
             * DataGridViewRow filaSeleccionada = dataGridView_resultados.SelectedRows[0];
            formEdicion.textBox_id.Text = filaSeleccionada.Cells[0].Value.ToString();
            formEdicion.textBox_titulo.Text = filaSeleccionada.Cells[1].Value.ToString();
            formEdicion.textBox_texto.Text = filaSeleccionada.Cells[2].Value.ToString();
            formEdicion.textBox_autor.Text = filaSeleccionada.Cells[3].Value.ToString();
            //dateTimePicker_fecha.Text = filaSeleccionada.Cells[4].Value.ToString();
            formEdicion.textBox_respuestas.Text = filaSeleccionada.Cells[5].Value.ToString();*/

            if (dataGridView_resultados.SelectedRows.Count > 0)
            {
                CambiarFormularioEdicion();
                formEdicion.CambiarSeleccionado(int.Parse(dataGridView_resultados.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }

        private void button_borrarHilo_Click(object sender, EventArgs e)
        {
            if (dataGridView_resultados.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection filas = dataGridView_resultados.SelectedRows;
                if (DialogResult.Yes == MessageBox.Show("¿Está seguro de que desea borrar los hilos seleccionados?", "Ventana de confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    foreach (DataGridViewRow i in filas)
                    {
                        // Se borra de la lista y de la base de datos.
                        ENHilo.Borrar(int.Parse(i.Cells[0].Value.ToString()));
                        dataGridView_resultados.Rows.Remove(i);
                    }
                }
            }
        }

        private void button_editarHilo_Click(object sender, EventArgs e)
        {
            if (dataGridView_resultados.SelectedRows.Count > 0)
            {
                CambiarFormularioEdicion();
                formEdicion.CambiarSeleccionado(int.Parse(dataGridView_resultados.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }
    }
}
