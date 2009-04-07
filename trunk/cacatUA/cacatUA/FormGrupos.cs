using System;
using System.Collections.Generic;
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
    public partial class FormGrupos : InterfazForm
    {
        private FormGruposEdicion formEdicion;
        private FormGruposBusqueda formBusqueda;

        public FormGrupos()
        {
            InitializeComponent();
            formEdicion = new FormGruposEdicion(this);
            formBusqueda = new FormGruposBusqueda(this);
            formEdicion.Dock = DockStyle.Top;
            formBusqueda.Dock = DockStyle.Top;

            Busqueda();
        }
        /// <summary>
        /// Función para ver solo las opciones de búsqueda
        /// </summary>
        private void Busqueda()
        {
            Actualizar();
            label_seccion1.Text = "Búsqueda";
            panel_contenedor.Controls.Clear();
            panel_contenedor.Controls.Add(formBusqueda);
            tableLayoutPanel_principal.RowStyles[3].Height = formBusqueda.Height;
        }

        /// <summary>
        /// Función para ver solo las opciones de edición
        /// </summary>
        private void Edicion() 
        {
            label_seccion1.Text = "Edición";
            panel_contenedor.Controls.Clear();
            panel_contenedor.Controls.Add(formEdicion);
            tableLayoutPanel_principal.RowStyles[3].Height = formEdicion.Height;
        }

        public ArrayList Resultado
        {
            set
            {
                dataGridView_resultados.Rows.Clear();
                ArrayList lista = value;
                for (int i = 0; i < lista.Count; i++)
                {
                    DataGridViewRow fila = new DataGridViewRow();
                    fila.CreateCells(dataGridView_resultados);

                    ENGrupos auxiliar = (ENGrupos)lista[i];
                    fila.Cells[0].Value = auxiliar.Id.ToString();
                    fila.Cells[1].Value = auxiliar.Nombre.ToString();
                    fila.Cells[2].Value = auxiliar.NumUsuarios.ToString();
                    fila.Cells[3].Value = auxiliar.Fecha.ToString();
                    dataGridView_resultados.Rows.Add(fila);
                }
            }
        }

        public void Actualizar()
        {
            Resultado = ENGrupos.Obtener();
        }

        private void button_seccionBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
            formBusqueda.inicio();
        }

        private void button_seccionCrear_Click(object sender, EventArgs e)
        {
            Edicion();
            formEdicion.Nuevo();
        }

        private void button_editar_Click(object sender, EventArgs e)
        {
            if (dataGridView_resultados.SelectedRows.Count > 0)
            {
                Edicion();
                formEdicion.Editar(int.Parse(dataGridView_resultados.SelectedRows[0].Cells[0].Value.ToString()));
            }
            else
            {
                MessageBox.Show("Seleccione un grupo para editar", "Ventana de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_borrar_Click(object sender, EventArgs e)
        {
            ENGrupos grupos = new ENGrupos();
            DataGridViewSelectedRowCollection filas = dataGridView_resultados.SelectedRows;
            string mensaje = "";
            if (filas.Count > 0)
            {
                if (filas.Count == 1)
                {
                    mensaje = "¿Está seguro de que desea borrar el grupo seleccionado?";
                }
                else
                {
                    mensaje = "¿Está seguro de que desea borrar los grupos seleccionados?"; 
                }
                
                if (DialogResult.Yes == MessageBox.Show(mensaje, "Ventana de confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    foreach (DataGridViewRow i in filas)
                    {
                        // Se borra de la lista y de la base de datos.
                        grupos.Id = int.Parse(i.Cells[0].Value.ToString());
                        grupos.Borrar(); 
                        dataGridView_resultados.Rows.Remove(i);
                    }
                }
            }
        }

        public override object Enviar()
        {
            return null;
        }

        public override void Recibir(object objeto)
        {

        }

        private void dataGridView_resultados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Edicion();
            formEdicion.Editar(int.Parse(dataGridView_resultados.SelectedRows[0].Cells[0].Value.ToString()));
        }

    }
}
