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
    public partial class FormMateriales : InterfazForm
    {
        FormMaterialesEdicion formEditarMateriales = null;
        FormMaterialesBusqueda formMaterialesBusqueda = null;

        public enum estados { EDITAR = 0, BUSCAR = 1, CREAR = 2};
        private estados estado;
        private estados estadoAnterior;
        public estados Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private ENMaterial seleccionado = null;
        public ENMaterial Seleccionado
        {
            get { return seleccionado; }
            set { seleccionado = value; }
        }

        private void CambiarFormulario(InterfazForm form)
        {
            panel_contenido.Controls.Clear();
            panel_contenido.Controls.Add(form);
            form.Dock = DockStyle.Top;
            tableLayoutPanel_principal.RowStyles[3].Height = form.Height;
        }

        private void ActualizarFormulario(estados estado)
        {
            this.estadoAnterior = this.estado;
            this.estado = estado;
            switch (estado)
            {
                case estados.CREAR:
                    {
                        if(formEditarMateriales == null)
                            formEditarMateriales = new FormMaterialesEdicion(this);
                        label_seccion.Text = "Crear nuevo material";
                        // Si el estado anterior no era crear o editar, mostramos el formulario
                        if(estadoAnterior != estados.CREAR && estadoAnterior != estados.EDITAR)
                            CambiarFormulario(formEditarMateriales);
                        // Actualizamos el formulario
                        formEditarMateriales.actualizarFormulario(FormMaterialesEdicion.modos.CREAR, null);
                        break;
                    }
                case estados.BUSCAR:
                    {
                        // En caso de que ya estemos en búsqueda no cambiamos el formulario
                        if (estadoAnterior != estados.BUSCAR)
                        {
                            // Cambiamos el título de la sección
                            label_seccion.Text = "Búsqueda";
                            if (formMaterialesBusqueda == null)
                                formMaterialesBusqueda = new FormMaterialesBusqueda(this);
                            CambiarFormulario(formMaterialesBusqueda);
                        }
                        break;
                    }
                case estados.EDITAR:
                    {
                        if (seleccionado != null)
                        {
                            if (formEditarMateriales == null)
                                formEditarMateriales = new FormMaterialesEdicion(this);
                            label_seccion.Text = "Editar material";
                            // Si el estado anterior no era crear o editar, mostramos el formulario
                            if (estadoAnterior != estados.CREAR && estadoAnterior != estados.EDITAR)  
                                CambiarFormulario(formEditarMateriales);
                            // Actualizamos el formulario
                            formEditarMateriales.actualizarFormulario(FormMaterialesEdicion.modos.EDITAR, seleccionado);                      
                        }
                        else
                        {
                            MessageBox.Show("error al seleccionar el material");
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Modo no válido");
                        break;
                    }
            }
        }

        public FormMateriales()
        {
            InitializeComponent();
            // Por defecto se muestra el formulario de búsqueda
            ActualizarFormulario(estados.BUSCAR);
            estadoAnterior = estados.BUSCAR;

            ArrayList materiales = ENMaterial.Obtener();
            mostrarMateriales(materiales);
        }

        public FormMateriales(ENCategoria categoria)
        {
            InitializeComponent();
            // Por defecto se muestra el formulario de búsqueda
            ActualizarFormulario(estados.BUSCAR);
            estadoAnterior = estados.BUSCAR;

            formMaterialesBusqueda.Recibir(categoria);
            formMaterialesBusqueda.Buscar();
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
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_comentarios"].Index;
                fila.Cells[posicion].Value = material.NumComentarios;
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_fecha"].Index;
                fila.Cells[posicion].Value = material.Fecha.ToUniversalTime();
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_usuario"].Index;
                fila.Cells[posicion].Value = material.Usuario.Usuario;
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_categoria"].Index;
                fila.Cells[posicion].Value = material.Categoria.NombreCompleto();
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_tamaño"].Index;
                fila.Cells[posicion].Value = material.Tamaño;
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_descargas"].Index;
                fila.Cells[posicion].Value = material.Descargas;
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_valoracion"].Index;
                fila.Cells[posicion].Value = material.Puntuacion;                               
                dataGridView_materiales.Rows.Add(fila);
            }
        }

        private void editarMaterial(object sender, EventArgs e)
        {
            // Comprobamos si hay algún material seleccionado 
            DataGridViewSelectedRowCollection filas = dataGridView_materiales.SelectedRows;
            if (filas.Count == 0)
            {
                // No hay ningún material seleccionado, mostramos un aviso
                MessageBox.Show("Debes seleccionar un material", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Obtenemos la fila seleccionada
                DataGridViewRow fila = fila = filas[0];
                // Comprobamos si hay un material seleccionado únicamente
                if (filas.Count > 1)
                {
                    // Deseleccionamos el resto de elementos
                    dataGridView_materiales.ClearSelection();
                    dataGridView_materiales.Rows[fila.Index].Selected = true;
                }
                // Obtenemos el material a editar
                int id = int.Parse(fila.Cells["dataGridViewTextBoxColumn_id"].Value.ToString());
                // Comprobamos si corresponde con el que está actualmente seleccionado
                if (seleccionado == null || id != seleccionado.Id)
                    seleccionado = ENMaterial.Obtener(id); 
                ActualizarFormulario(estados.EDITAR);
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
            ActualizarFormulario(estados.CREAR);
        }

        private void buscarMateriales(object sender, EventArgs e)
        {
            ActualizarFormulario(estados.BUSCAR);
        }

        public override void Recibir(object objeto)
        {
            if (objeto != null)
            {
                if (estado == estados.BUSCAR)
                    formMaterialesBusqueda.Recibir(objeto);
                else
                    formEditarMateriales.Recibir(objeto);
            }
        }
    }
}