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
            Busqueda();

        }
        /// <summary>
        /// Función para ver solo las opciones de búsqueda
        /// </summary>
        private void Busqueda()
        {
            anadirGrupos();
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
            dataGridView_resultados.Rows.Clear();
            ENGrupos grupos = new ENGrupos();
            ArrayList lista = grupos.Obtener();
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
        /*
        public void Añadir(ArrayList grupos)
        {
            dataGridView_resultados.Rows.Clear();
            foreach (ENGrupos auxiliar in grupos)
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView_resultados);

                fila.Cells[0].Value = auxiliar.Id.ToString();
                fila.Cells[1].Value = auxiliar.Nombre.ToString();
                fila.Cells[2].Value = auxiliar.NumUsuarios.ToString();
                fila.Cells[3].Value = auxiliar.Fecha.ToString();
                dataGridView_resultados.Rows.Add(fila);

            }
        }*/

        private void button_seccionBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }

        private void button_seccionCrear_Click(object sender, EventArgs e)
        {
            Edicion();
            formEdicion.Nuevo();
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


    }
}
