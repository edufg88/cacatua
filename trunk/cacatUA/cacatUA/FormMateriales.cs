using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Libreria;

namespace cacatUA
{
    public partial class FormMateriales : InterfazForm
    {
        FormMaterialesEdicion formEditarMateriales = null;
        FormMaterialesBusqueda formMaterialesBusqueda = null;
        WebClient cliente;

        Dictionary<int, WebClient> descargas = null;

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
            descargas = new Dictionary<int, WebClient>();
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
                fila.Cells[posicion].Value = material.Fecha;
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
                // Comprobamos si se está descargando
                if (estaDescargando(material))
                {
                    fila.Cells["dataGridViewTextBoxColumn_descargar"] = new DataGridViewTextBoxCell();
                    fila.Cells["dataGridViewTextBoxColumn_descargar"].Value = "hola";
                }
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
        /*
        private void actualizarDataGridDescargas()
        {
            // Para cada descarga activa, comprobamos 

        }
        */
        private void archivoDescargado(object sender, AsyncCompletedEventArgs e)
        {
            WebClient webCliente = (WebClient)sender;
            // Obtenemos la ruta del archivo
            string ruta = webCliente.BaseAddress;
            // Obtenemos el id de la ruta
            string id = ruta.Remove(0, ruta.LastIndexOf(@"/") + 1);
            id = id.Remove(id.LastIndexOf(@"."));
            // Eliminamos de las descargas
            if(descargas.Remove(int.Parse(id)))
                FormPanelAdministracion.Instancia.MensajeEstado("Material " + id + " descargado");
            // Cambiamos el icono del datagrid
            // Comprobamos si está en el datagrid el material
            DataGridViewRowCollection filas = dataGridView_materiales.Rows;
            foreach (DataGridViewRow fila in filas)
            {
                if (fila.Cells["dataGridViewTextBoxColumn_id"].Value.ToString() == id)
                {
                    // Lo hemos encontrado
                    fila.Cells["dataGridViewTextBoxColumn_descargar"] = new DataGridViewImageCell();
                    fila.Cells["dataGridViewTextBoxColumn_descargar"].Value = Properties.Resources.descargar;
                     
                    break;
                }
            }
                    
        }

        private void cambioPorcentaje(object sender, DownloadProgressChangedEventArgs e)
        {
            WebClient webCliente = (WebClient)sender;
            // Obtenemos la ruta del archivo
            string ruta = webCliente.BaseAddress;
            // Obtenemos el id de la ruta
            string id = ruta.Remove(0, ruta.LastIndexOf(@"/")+1);
            id = id.Remove(id.LastIndexOf(@"."));
            // Comprobamos si está en el datagrid el material
            DataGridViewRowCollection filas = dataGridView_materiales.Rows;
            foreach (DataGridViewRow fila in filas)
            {
                if (fila.Cells["dataGridViewTextBoxColumn_id"].Value.ToString() == id)
                {
                    // Lo hemos encontrado
                    fila.Cells["dataGridViewTextBoxColumn_descargar"] = new DataGridViewTextBoxCell();
                    fila.Cells["dataGridViewTextBoxColumn_descargar"].Value = e.ProgressPercentage.ToString() + "%";
                    break;
                }
            }
        }

        private void dataGridView_materiales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView_materiales.Columns["dataGridViewTextBoxColumn_descargar"].Index)
            {
                // Obtenemos la fila seleccionada
                DataGridViewSelectedRowCollection filas = dataGridView_materiales.SelectedRows;
                if (filas.Count == 1)
                {
                    // Descargamos el material seleccionado
                    DataGridViewRow fila = filas[0];
                    int id = int.Parse(fila.Cells["dataGridViewTextBoxColumn_id"].Value.ToString());
                    ENMaterial material = ENMaterial.Obtener(id);
                    // Obtenemos la ruta donde el usuario quiere guardar el material
                    saveFileDialog.FileName = material.Archivo;
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (material != null)
                        {
                            
                            WebClient cliente = new WebClient();
                            descargas.Add(material.Id, cliente);
                            Uri uri = new Uri("http://84.120.44.73/ficheros/" + material.Archivo);
                            
                            
                            // Specify that the DownloadFileCallback method gets called
                            // when the download completes.
                            cliente.DownloadFileCompleted += new AsyncCompletedEventHandler(archivoDescargado);
                            // Specify a progress notification handler.
                            cliente.DownloadProgressChanged += new DownloadProgressChangedEventHandler(cambioPorcentaje);
                            cliente.DownloadFileAsync(uri, saveFileDialog.FileName);
                            cliente.BaseAddress = "http://84.120.44.73/ficheros/" + material.Archivo;
                            //webCliente.DownloadFile("http://84.120.44.73/ficheros/" + material.Archivo,saveFileDialog.FileName);
                            //webCliente.DownloadFileCompleted
                        }
                        else
                        {
                            MessageBox.Show("material no válido");
                        }
                    }
                }
            }
        }

        private bool estaDescargando(ENMaterial material)
        {
            bool descargando = false;
            foreach (KeyValuePair<int, WebClient> i in descargas)
            {
                // Obtenemos el nombre
                int id = i.Key;
                // Obtenemos el control
                WebClient cliente = i.Value;
                if (id == material.Id)
                {
                    descargando = true;
                    break;
                }
            }
            return descargando;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Obtenemos la fila seleccionada
            DataGridViewSelectedRowCollection filas = dataGridView_materiales.SelectedRows;
            if (filas.Count == 1)
            {
                // Descargamos el material seleccionado
                DataGridViewRow fila = filas[0];
                int id = int.Parse(fila.Cells["dataGridViewTextBoxColumn_id"].Value.ToString());
                ENMaterial material = ENMaterial.Obtener(id);
                // Comprobamos si se está descargando actualmente
                if (estaDescargando(material))
                {
                    WebClient cliente = descargas[id];
                    // Eliminamos la descarga
                    descargas.Remove(id);
                    cliente.CancelAsync();
                    
                    //MessageBox.Show("Cancelado: " + cliente.BaseAddress);
                    fila.Cells["dataGridViewTextBoxColumn_descargar"] = new DataGridViewImageCell();
                    fila.Cells["dataGridViewTextBoxColumn_descargar"].Value = Properties.Resources.descargar;
                    FormPanelAdministracion.Instancia.MensajeEstado("Descarga del material " + id.ToString() + " cancelada"); 
                }
            }
        }

        private void dataGridView_materiales_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection filas = dataGridView_materiales.SelectedRows;
            if (filas.Count == 1)
            {
                // Descargamos el material seleccionado
                DataGridViewRow fila = filas[0];
                int id = int.Parse(fila.Cells["dataGridViewTextBoxColumn_id"].Value.ToString());
                ENMaterial material = ENMaterial.Obtener(id);
                // Comprobamos si se está descargando el material
                if (estaDescargando(material))
                {
                    // Activamos el botón de cancelar
                    button_cancelarDescarga.Enabled = true;
                }
                else
                    button_cancelarDescarga.Enabled = false;
            }
        }
    }
}