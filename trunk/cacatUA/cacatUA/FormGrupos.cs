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
    public partial class FormGrupos : UserControl
    {
        private FormGruposEdicion formEdicion;
        private FormGruposBusqueda formBusqueda;

        public FormGrupos()
        {
            InitializeComponent();
            formEdicion = new FormGruposEdicion();
            formBusqueda = new FormGruposBusqueda();
            formEdicion.Dock = DockStyle.Top;
            formBusqueda.Dock = DockStyle.Top;

            tableLayoutPanel_principal.RowStyles[5].Height = 0;
            anadirGrupos();
            Busqueda();

        }
        /// <summary>
        /// Función para ver solo las opciones de búsqueda
        /// </summary>
        private void Busqueda()
        {
            label_seccion1.Text = "Búsqueda";
            panel_contenedor.Controls.Clear();
            panel_contenedor.Controls.Add(formBusqueda);
            tableLayoutPanel_principal.RowStyles[2].Height = formBusqueda.Height;
        }

        /// <summary>
        /// Función para ver solo las opciones de edición
        /// </summary>
        private void Edicion() 
        {
            label_seccion1.Text = "Edición";
            panel_contenedor.Controls.Clear();
            panel_contenedor.Controls.Add(formEdicion);
            tableLayoutPanel_principal.RowStyles[2].Height = formEdicion.Height;
        }

        /// <summary>
        /// Añade los grupos que hay en la BD
        /// </summary>
        private void anadirGrupos()
        {
            ENGruposCRUD grupos = new ENGruposCRUD();
            ArrayList lista = grupos.obtenerGrupos();
            for (int i = 0; i < lista.Count; i++)
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView_resultados);

                ENGruposCRUD auxiliar = (ENGruposCRUD)lista[i];
                fila.Cells[0].Value = auxiliar.Id.ToString();
                fila.Cells[1].Value = auxiliar.Nombre.ToString();
                fila.Cells[2].Value = auxiliar.NumUsuarios.ToString();
                fila.Cells[3].Value = auxiliar.Fecha.ToString();
                dataGridView_resultados.Rows.Add(fila);
            }
        }


        private void button_seccionBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }

        private void button_seccionCrear_Click(object sender, EventArgs e)
        {
            Edicion();
            formEdicion.Nuevo();
        }

        private void button_eliminar_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection filas = dataGridView_resultados.SelectedRows;
            String mensaje;
            if (filas.Count > 0)
            {
                if (filas.Count > 1)
                {
                    mensaje = "¿Está seguro de que desea eliminar los grupos seleccionados?";
                }
                else
                {
                    mensaje = "¿Está seguro de que desea eliminar el grupo seleccionado?";
                }

                DialogResult resultado = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    for (int i = 0; i < filas.Count; i++)
                    {
                        // Obtenemos la fila
                        DataGridViewRow fila = filas[i];
                        // Eliminamos la fila
                        dataGridView_resultados.Rows.Remove(fila);
                    }
                }
            }
        }

        private void button_editar_Click(object sender, EventArgs e)
        {
            Edicion();
            formEdicion.Editar(int.Parse(dataGridView_resultados.SelectedRows[0].Cells[0].Value.ToString()));
        }

        private void dataGridView_resultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Edicion();
            formEdicion.Editar(int.Parse(dataGridView_resultados.SelectedRows[0].Cells[0].Value.ToString()));
        }


    }
}
