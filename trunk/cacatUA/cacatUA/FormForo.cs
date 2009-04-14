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
    public partial class FormForo : InterfazForm
    {
        private FormForoEdicion formEdicion;
        private FormForoBusqueda formBusqueda;
        private enum FormularioActivo { NINGUNO = 0, BUSQUEDA = 1, EDICION = 2 };
        FormularioActivo formularioActivo;

        private void inicializar()
        {
            InitializeComponent();

            // Se crean los formularios que se van a utilizar.
            formEdicion = new FormForoEdicion(this);
            formBusqueda = new FormForoBusqueda(this);
            formEdicion.Dock = DockStyle.Top;
            formBusqueda.Dock = DockStyle.Top;
            formularioActivo = FormularioActivo.NINGUNO;
        }

        public FormForo()
        {
            inicializar();
            CambiarFormularioBusqueda();
            formBusqueda.Buscar();
        }

        public FormForo(ENCategoria categoria)
        {
            inicializar();
            CambiarFormularioBusqueda();
            formBusqueda.Recibir(categoria);
            formBusqueda.Buscar();
        }

        public void CambiarFormularioBusqueda()
        {
            if (formularioActivo != FormularioActivo.BUSQUEDA)
            {
                formularioActivo = FormularioActivo.BUSQUEDA;
                label_seccion1.Text = "Búsqueda";
                panel_contenedor.Controls.Clear();
                panel_contenedor.Controls.Add(formBusqueda);
                tableLayoutPanel_principal.RowStyles[3].Height = formBusqueda.Height;
            }
        }

        public void CambiarFormularioEdicion(string label)
        {
            label_seccion1.Text = label;
            if (formularioActivo != FormularioActivo.EDICION)
            {
                formularioActivo = FormularioActivo.EDICION;
                panel_contenedor.Controls.Clear();
                panel_contenedor.Controls.Add(formEdicion);
                tableLayoutPanel_principal.RowStyles[3].Height = formEdicion.Height;
            }
        }

        public ArrayList Resultados
        {
            set
            {
                dataGridView_resultados.Rows.Clear();
                ArrayList lista = value;
                if (lista != null)
                {
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
                else
                {
                    MessageBox.Show("Ocurrió un error con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_seccionBuscar_Click(object sender, EventArgs e)
        {
            CambiarFormularioBusqueda();
        }

        private void button_seccionCrear_Click(object sender, EventArgs e)
        {
            CambiarFormularioEdicion("Crear nuevo hilo");
            formEdicion.CambiarNuevo();
        }

        private void dataGridView_resultados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView_resultados.SelectedRows.Count > 0)
            {
                CambiarFormularioEdicion("Editando hilo");
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
                CambiarFormularioEdicion("Editando hilo");
                formEdicion.CambiarSeleccionado(int.Parse(dataGridView_resultados.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }

        public override void Recibir(object objeto)
        {
            if (objeto != null)
            {
                if (formularioActivo == FormularioActivo.BUSQUEDA)
                {
                    formBusqueda.Recibir(objeto);
                }
                else
                {
                    formEdicion.Recibir(objeto);
                }
            }
        }
    }
}
