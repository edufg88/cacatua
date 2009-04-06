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
    public partial class FormMateriales : UserControl
    {
        private bool busqueda;
        FormEditarMateriales formEditarMateriales;

        public FormMateriales()
        {
            InitializeComponent();
            // Por defecto se muestra el formulario de búsqueda
            busqueda = true;
            formEditarMateriales = null;
            FormBusquedaMateriales form = new FormBusquedaMateriales(this);
            panel_contenido.Controls.Clear();
            panel_contenido.Controls.Add(form);
            //form.Dock = DockStyle.Fill;
            form.Dock = DockStyle.Top;
            tableLayoutPanel_principal.RowStyles[3].Height = form.Height;
            ArrayList materiales = ENMaterial.Obtener();
            mostrarMateriales(materiales);
        }
        
        public DataGridView Materiales
        {
            get { return dataGridView_materiales; }
            set { dataGridView_materiales = value; }
        }

        public void mostrarMateriales(ArrayList materiales)
        {
            dataGridView_materiales.Rows.Clear();
            // Obtenemos todos los materiales que hay en la base de datos
            for (int i = 0; i < materiales.Count; i++)
            {
                ENMaterial material = (ENMaterial)materiales[i];
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView_materiales);
                int posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_id"].Index;
                fila.Cells[posicion].Value = material.Id.ToString();
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_nombre"].Index;
                fila.Cells[posicion].Value = material.Nombre;
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_descripcion"].Index;
                fila.Cells[posicion].Value = material.Descripcion;
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_fecha"].Index;
                fila.Cells[posicion].Value = material.Fecha.ToUniversalTime();
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_usuario"].Index;
                fila.Cells[posicion].Value = material.Usuario.Nombre;
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_categoria"].Index;
                fila.Cells[posicion].Value = material.Categoria;
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_tamaño"].Index;
                fila.Cells[posicion].Value = material.Tamaño;
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_descargas"].Index;
                fila.Cells[posicion].Value = material.Descargas;
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_idioma"].Index;
                fila.Cells[posicion].Value = material.Idioma;
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_valoracion"].Index;
                fila.Cells[posicion].Value = material.Puntuacion;                               
                dataGridView_materiales.Rows.Add(fila);
            }
        }

        private void editarMaterial(object sender, EventArgs e)
        {
            // Comprobamos si hay algún material seleccionado 
            DataGridViewSelectedRowCollection filas = dataGridView_materiales.SelectedRows;
            if(filas.Count == 0)
            {
                // No hay ningún material seleccionado, mostramos un aviso
                MessageBox.Show("Debes seleccionar un material", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataGridViewRow fila = fila = filas[0];
                // Comprobamos si hay un material seleccionado únicamente
                if (filas.Count > 1)
                {
                    // Deseleccionamos el resto de elementos
                    dataGridView_materiales.ClearSelection();
                    dataGridView_materiales.Rows[fila.Index].Selected = true;
                }

                // Obtenemos el id del material que vamos a editar
                string id = fila.Cells["dataGridViewTextBoxColumn_id"].Value.ToString();
                // Comprobamos si el formulario visible es el de búsqueda
                if (busqueda == true)
                {
                    // Mostramos el formulario de editar material
                    formEditarMateriales = new FormEditarMateriales(FormEditarMateriales.modos.EDITAR, id);
                    panel_contenido.Controls.Clear();
                    panel_contenido.Controls.Add(formEditarMateriales);
                    //formEditarMateriales.Dock = DockStyle.Fill;
                    formEditarMateriales.Dock = DockStyle.Top;
                    tableLayoutPanel_principal.RowStyles[3].Height = formEditarMateriales.Height;
                }
                else
                {
                    // Recargamos el formulario editar material con los nuevos datos
                    if (formEditarMateriales != null)
                    {
                        // Cambiamos el formulario al modo editar
                        formEditarMateriales.Modo = FormEditarMateriales.modos.EDITAR;
                        formEditarMateriales.actualizarFormulario(id);

                    }
                    //else
                      //  formEditarMateriales = new FormEditarMateriales(FormEditarMateriales.modos.EDITAR, id);
                }
                busqueda = false;
            }
        }

        private void borrarMaterial(object sender, EventArgs e)
        {
            // Comprobamos que haya algún material seleccionado
            DataGridViewSelectedRowCollection filas = dataGridView_materiales.SelectedRows;
            if (filas.Count == 0)
            {
                // No hay ningún material seleccionado, mostramos un aviso
                MessageBox.Show("Debes seleccionar un material", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult resultado;
                // Mostramos un mensaje de aviso para que el usuario confirme que quiere borrar el material
                if (filas.Count == 1)
                {
                    string mensaje = "¿Está seguro de que desea eliminar " + filas[0].Cells["dataGridViewTextBoxColumn_nombre"].Value.ToString() + "?";
                    resultado = MessageBox.Show(mensaje, "Confirmar eliminación de material", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    string mensaje = "¿Está seguro que desea eliminar estos " + filas.Count + " materiales?";
                    resultado = MessageBox.Show(mensaje, "Confirmar la eliminación de múltiples materiales", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                // Comprobamos cual ha sido el resultado
                if (resultado == DialogResult.Yes)
                {
                    for (int i = 0; i < filas.Count; i++)
                    {
                        // Obtenemos la fila
                        DataGridViewRow fila = filas[i];
                        // Eliminamos el material de la base de datos
                        int id = int.Parse(fila.Cells["dataGridViewTextBoxColumn_id"].Value.ToString());
                        bool borrado = ENMaterial.borrarMaterial(id);
                        if (borrado == false)
                        {
                            string mensaje = "ERROR: No se ha podido borrar el material " + id;
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        // Eliminamos la fila
                        dataGridView_materiales.Rows.Remove(fila);
                    }
                }
            }
        }

        private void añadirMaterial(object sender, EventArgs e)
        {
            // Comprobamos si el formulario visible es el de búsqueda
            if (busqueda == true || formEditarMateriales == null)
            {
                // Añadimos un nuevo material
                formEditarMateriales = new FormEditarMateriales(FormEditarMateriales.modos.CREAR, "");
                panel_contenido.Controls.Clear();
                panel_contenido.Controls.Add(formEditarMateriales);
                //formEditarMateriales.Dock = DockStyle.Fill;
                formEditarMateriales.Dock = DockStyle.Top;
                tableLayoutPanel_principal.RowStyles[3].Height = formEditarMateriales.Height;
            }
            else
            {
                formEditarMateriales.Modo = FormEditarMateriales.modos.CREAR;
                formEditarMateriales.actualizarFormulario("");
            }
            busqueda = false;
        }

        private void buscarMateriales(object sender, EventArgs e)
        {
            busqueda = true;
            FormBusquedaMateriales form = new FormBusquedaMateriales(this);
            panel_contenido.Controls.Clear();
            panel_contenido.Controls.Add(form);
            //form.Dock = DockStyle.Fill;
            form.Dock = DockStyle.Top;
            tableLayoutPanel_principal.RowStyles[3].Height = form.Height;
        }
    }
}