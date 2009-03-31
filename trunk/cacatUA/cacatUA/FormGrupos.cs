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


        private void button_seccionBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }

        private void button_seccionCrear_Click(object sender, EventArgs e)
        {
            Edicion();
        }

        private void button_eliminar_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection filas = dataGridView_grupos.SelectedRows;
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
                        dataGridView_grupos.Rows.Remove(fila);
                    }
                }
            }
        }

        private void butto_editarHilo_Click(object sender, EventArgs e)
        {
            Edicion();
        }
    }
}
