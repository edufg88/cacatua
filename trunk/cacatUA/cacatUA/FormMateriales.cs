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
            FormBusquedaMateriales form = new FormBusquedaMateriales();
            panel_contenido.Controls.Clear();
            panel_contenido.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            /*
            // Inicializamos las secciones
            comboBox_seccion.Items.Add("Ingeniería Informática");
            // Inicializamos las categorías
            comboBox_categoria.Items.Add("Primer Curso");
            comboBox_categoria.Items.Add("Segundo Curso");
            comboBox_categoria.Items.Add("Tercer Curso");
            comboBox_categoria.Items.Add("Cuarto Curso");
            comboBox_categoria.Items.Add("Quinto Curso");
            // Inicializamos las subcategorías
            comboBox_subcategoria.Items.Add("Algebra");
            comboBox_subcategoria.Items.Add("Informática Básica");
            comboBox_subcategoria.Items.Add("Matemática discreta");
            comboBox_subcategoria.Items.Add("Fundamentos de programación I");
            comboBox_subcategoria.Items.Add("Fundamentos de programación II");
             */
            /*
            comboBox_tipoBusqueda.SelectedIndex = 0;
            comboBox_fecha.SelectedIndex = 0;    
            comboBox_unidad.SelectedIndex = 1;
            comboBox_idioma.SelectedIndex = 0;
            comboBox_valoracion.SelectedIndex = 0;
             */
            // Añadimos unos cuantos materiales
            crearMateriales();
        }



        private void crearMateriales()
        {
            // Obtenemos todos los materiales que hay en la base de datos
            ArrayList materiales = ENMaterial.obtener();
            for (int i = 0; i < materiales.Count; i++)
            {
                ENMaterial material = (ENMaterial)materiales[i];
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridViewMateriales);
                int posicion = dataGridViewMateriales.Columns["dataGridViewTextBoxColumn_id"].Index;
                fila.Cells[posicion].Value = material.Id.ToString();
                posicion = dataGridViewMateriales.Columns["dataGridViewTextBoxColumn_nombre"].Index;
                fila.Cells[posicion].Value = material.Nombre;
                posicion = dataGridViewMateriales.Columns["dataGridViewTextBoxColumn_descripcion"].Index;
                fila.Cells[posicion].Value = material.Descripcion;
                posicion = dataGridViewMateriales.Columns["dataGridViewTextBoxColumn_fecha"].Index;
                fila.Cells[posicion].Value = material.Fecha.ToUniversalTime();
                posicion = dataGridViewMateriales.Columns["dataGridViewTextBoxColumn_usuario"].Index;
                fila.Cells[posicion].Value = material.Usuario.Nombre;
                posicion = dataGridViewMateriales.Columns["dataGridViewTextBoxColumn_categoria"].Index;
                fila.Cells[posicion].Value = material.Categoria;
                posicion = dataGridViewMateriales.Columns["dataGridViewTextBoxColumn_tamaño"].Index;
                fila.Cells[posicion].Value = material.Tamaño;
                posicion = dataGridViewMateriales.Columns["dataGridViewTextBoxColumn_descargas"].Index;
                fila.Cells[posicion].Value = material.Descargas;
                posicion = dataGridViewMateriales.Columns["dataGridViewTextBoxColumn_idioma"].Index;
                fila.Cells[posicion].Value = material.Idioma;
                posicion = dataGridViewMateriales.Columns["dataGridViewTextBoxColumn_valoracion"].Index;
                fila.Cells[posicion].Value = material.Valoracion;                               
                dataGridViewMateriales.Rows.Add(fila);
            }
        }

        private void button_añadirMaterial_Click(object sender, EventArgs e)
        {
            FormMaterial form = new FormMaterial();
            form.setModo(FormMaterial.modos.NUEVO);
            form.Show();
        }



        private void button_borrarMaterial_Click(object sender, EventArgs e)
        {
            /*
            DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas eliminar esos materiales?","Confirmación",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                // Obtenemos todas las filas seleccionada
                DataGridViewSelectedRowCollection filas = dataGridViewMateriales.SelectedRows;
                for (int i = 0; i < filas.Count; i++)
                {
                    // Obtenemos la fila
                    DataGridViewRow fila = filas[i];
                    // Eliminamos la fila
                    dataGridViewMateriales.Rows.Remove(fila);
                }
            }*/
        }

        private void button_buscarCategoria_Click(object sender, EventArgs e)
        {
            //FormCategoria form = new FormCategoria();
            //form.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            //form.Location = new Point(button_buscarCategoria.Location.X, button_buscarCategoria.Location.Y);
            //form.ShowDialog();
        }



        private void button_seccionBuscar_Click(object sender, EventArgs e)
        {
            // Mostramos el user control de busqueda
            FormBusquedaMateriales form = new FormBusquedaMateriales();
            panel_contenido.Controls.Clear();
            panel_contenido.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }


        private void editarMaterial(object sender, EventArgs e)
        {
            // Comprobamos si hay algún material seleccionado 
            DataGridViewSelectedRowCollection filas = dataGridViewMateriales.SelectedRows;
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
                    dataGridViewMateriales.ClearSelection();
                    dataGridViewMateriales.Rows[fila.Index].Selected = true;
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
                    formEditarMateriales.Dock = DockStyle.Fill;

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
            DataGridViewSelectedRowCollection filas = dataGridViewMateriales.SelectedRows;
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
                        dataGridViewMateriales.Rows.Remove(fila);
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
                formEditarMateriales.Dock = DockStyle.Fill;
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
            FormBusquedaMateriales form = new FormBusquedaMateriales();
            panel_contenido.Controls.Clear();
            panel_contenido.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }
    }
}