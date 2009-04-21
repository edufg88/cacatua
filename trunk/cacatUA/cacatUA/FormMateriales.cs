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
using System.Configuration;

namespace cacatUA
{
    public partial class FormMateriales : InterfazForm
    {
        private string servidor = cacatUA.Properties.Settings.Default.cacatUA_Uploader_FileUploader;
        
        public FormMaterialesEdicion formEditarMateriales = null;
        public FormMaterialesBusqueda formMaterialesBusqueda = null;
        private int cantidadPorPagina;
        public int CantidadPorPagina
        {
            get { return cantidadPorPagina; }
            set { cantidadPorPagina = value; }
        }

        private string propiedadOrdenar;
        public string PropiedadOrdenar
        {
            get { return propiedadOrdenar; }
            set { propiedadOrdenar = value; }
        }

        private int pagina;
        public int Pagina
        {
            get { return pagina; }
            set { pagina = value; }
        }

        public SortOrder Orden()
        {
            string nomColumna = "dataGridViewTextBoxColumn_" + propiedadOrdenar;
            return dataGridView_materiales.Columns[nomColumna].HeaderCell.SortGlyphDirection;
        }

        Dictionary<int, WebClient> descargas = null;

        public enum estados { EDITAR = 0, BUSCAR = 1, CREAR = 2, INICIAL = 3};
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

        public void ActualizarFormulario(estados estado)
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
                            {
                                formMaterialesBusqueda = new FormMaterialesBusqueda(this);
                                CambiarFormulario(formMaterialesBusqueda);
                                formMaterialesBusqueda.NuevaBusqueda();
                            }
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

        private void Inicializar()
        {
            InitializeComponent();
            descargas = new Dictionary<int, WebClient>();
            cantidadPorPagina = 10;
            comboBox_cantidadPorPagina.Text = cantidadPorPagina.ToString();
            comboBox_pagina.Text = "1";
            pagina = 1;

            // Por defecto ordenamos por id por orden descendente
            propiedadOrdenar = "id";
            dataGridView_materiales.Columns["dataGridViewTextBoxColumn_id"].HeaderCell.SortGlyphDirection = SortOrder.Descending;
            // Por defecto se muestra el formulario de búsqueda 
            // NOTA: Es importante de que esto se ponga al final del constructor
            estadoAnterior = estados.INICIAL;
            servidor = servidor.Remove(servidor.LastIndexOf(@"/"));
            //Console.WriteLine(servidor);
        }

        public FormMateriales()
        {
            Inicializar();
            ActualizarFormulario(estados.BUSCAR);
        }

        public void BuscarPorCategoria(ENCategoria categoria)
        {
            if (formMaterialesBusqueda == null)
                formMaterialesBusqueda = new FormMaterialesBusqueda(this);
            formMaterialesBusqueda.limpiarFormulario();
            formMaterialesBusqueda.Recibir(categoria);
            ActualizarFormulario(estados.BUSCAR);
            formMaterialesBusqueda.NuevaBusqueda();
        }

        public DataGridView Materiales
        {
            get { return dataGridView_materiales; }
            set { dataGridView_materiales = value; }
        }

        public void ActualizarMaterial(ENMaterial material)
        {
            DataGridViewRowCollection filas = dataGridView_materiales.Rows;
            foreach (DataGridViewRow fila in filas)
            {
                if (fila.Cells["dataGridViewTextBoxColumn_id"].Value.ToString() == material.Id.ToString())
                {
                    fila.Cells["dataGridViewTextBoxColumn_id"].Value = material.Id.ToString();
                    fila.Cells["dataGridViewTextBoxColumn_nombre"].Value = material.Nombre;
                    fila.Cells["dataGridViewTextBoxColumn_numComentarios"].Value = material.NumComentarios;
                    fila.Cells["dataGridViewTextBoxColumn_fecha"].Value = material.Fecha;
                    fila.Cells["dataGridViewTextBoxColumn_usuario"].Value = material.Usuario.Usuario;
                    fila.Cells["dataGridViewTextBoxColumn_categoria"].Value = material.Categoria.NombreCompleto();
                    fila.Cells["dataGridViewTextBoxColumn_tamaño"].Value = ENMaterial.convertirTamaño(material.Tamaño);
                    fila.Cells["dataGridViewTextBoxColumn_descargas"].Value = material.Descargas;
                    fila.Cells["dataGridViewTextBoxColumn_puntuacion"].Value = material.Puntuacion;
                    break;
                }
            }
            // Comprobamos si el material es el que está en el formulario de edición
            if (formEditarMateriales != null && formEditarMateriales.Controles["id"].Text == material.Id.ToString())
            {
                // Actualizamos el formulario
                formEditarMateriales.mostrarMaterial(material);
            }
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
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_numComentarios"].Index;
                fila.Cells[posicion].Value = material.NumComentarios;
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_fecha"].Index;
                fila.Cells[posicion].Value = material.Fecha;
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_usuario"].Index;
                fila.Cells[posicion].Value = material.Usuario.Usuario;
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_categoria"].Index;
                fila.Cells[posicion].Value = material.Categoria.NombreCompleto();
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_tamaño"].Index;
                fila.Cells[posicion].Value = ENMaterial.convertirTamaño(material.Tamaño);
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_descargas"].Index;
                fila.Cells[posicion].Value = material.Descargas;
                posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_puntuacion"].Index;
                fila.Cells[posicion].Value = material.Puntuacion; 
                // Comprobamos si se está descargando
                if (estaDescargando(material))
                {
                    posicion = dataGridView_materiales.Columns["dataGridViewTextBoxColumn_descargar"].Index;
                    fila.Cells[posicion].Value = "cargando";
                }
                dataGridView_materiales.Rows.Add(fila);
            }
        }

        private void editarMaterial()
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

        private void editarMaterial(object sender, EventArgs e)
        {
            editarMaterial();
        }

        private void borrarMaterial(object sender, EventArgs e)
        {
            Uploader.FileUploader fileUploader = new Uploader.FileUploader();
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
                        ENMaterial material = ENMaterial.Obtener(id);

                        bool borrado = true;
                        // Borramos el fichero físicamente del servidor
                        if (fileUploader.existeFichero(material.Archivo))
                        {
                            if (fileUploader.BorrarFichero(material.Archivo) == false)
                                borrado = false;
                        }
                        // Si se ha borrado del servidor, lo borramos de la base de datos
                        if (borrado == true)
                        {
                            borrado = material.Borrar();
                            if (borrado == false)
                            {
                                string mensaje = "ERROR: No se ha podido borrar el material " + id;
                                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                // Eliminamos la fila
                                dataGridView_materiales.Rows.Remove(fila);
                            }
                        }
                        else
                        {
                            string mensaje = "ERROR: No se ha podido borrar el material" + material.Archivo + " del servidor";
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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

            if (objeto is ENMaterial)
            {
                ActualizarMaterial((ENMaterial)objeto);
            }
        }

        private void archivoDescargado(object sender, AsyncCompletedEventArgs e)
        {
            WebClient webCliente = (WebClient)sender;
            // Obtenemos la ruta del archivo
            string ruta = webCliente.BaseAddress;
            // Obtenemos el id de la ruta
            string id = ruta.Remove(0, ruta.LastIndexOf(@"/") + 1);
            id = id.Remove(id.LastIndexOf(@"."));
            // Eliminamos de las descargas
            descargas.Remove(int.Parse(id));
            // Cambiamos el icono del datagrid
            // Comprobamos si está en el datagrid el material
            DataGridViewRowCollection filas = dataGridView_materiales.Rows;
            foreach (DataGridViewRow fila in filas)
            {
                if (fila.Cells["dataGridViewTextBoxColumn_id"].Value.ToString() == id)
                {
                    // Comprobamos si el porcentaje era 100%
                    if (fila.Cells["dataGridViewTextBoxColumn_descargar"].Value.ToString() == "100%")
                        FormPanelAdministracion.Instancia.MensajeEstado("Material " + id + " descargado");
                    else
                        MessageBox.Show("No se ha podido establecer conexión con el servidor", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            Uri uri = new Uri(servidor + "/materiales/" + material.Archivo);
                            cliente.DownloadFileCompleted += new AsyncCompletedEventHandler(archivoDescargado);
                            cliente.DownloadProgressChanged += new DownloadProgressChangedEventHandler(cambioPorcentaje);
                            cliente.DownloadFileAsync(uri, saveFileDialog.FileName);
                            cliente.BaseAddress = uri.ToString();
                            button_cancelarDescarga.Enabled = true;
                            // Aumentamos el número de descargas
                            material.Descargas++;
                            material.Actualizar();
                            ActualizarMaterial(material);
                        }
                        else
                        {
                            MessageBox.Show("material no válido");
                        }
                    }
                }
            }
            else
            {
                if (e.RowIndex < 0)
                {
                    // Comprobamos si la columna se puede ordenar
                    if(e.ColumnIndex != dataGridView_materiales.Columns["dataGridViewTextBoxColumn_descargar"].Index)
                    {
                        // Obtenemos el nombre de la columna que estaba ordenada anteriormente
                        string nomColumnaAnterior = "dataGridViewTextBoxColumn_" + propiedadOrdenar;
                        ordenModificado(e.ColumnIndex);
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

        /// <summary>
        /// Cuando en el formulario de búsqueda se realiza una búsqueda, este llama a esta función y le pasa
        /// el número de resultados obtenidos y el array list con todos los resultados obtenidos en función
        /// del número de resultados por página indicado.
        /// </summary>
        public void ActualizarPaginacion(int totalResultados)
        {
            if (totalResultados > 0)
            {
                int paginas = (int)Math.Ceiling(totalResultados / (float)CantidadPorPagina);
                // Añadimos las páginas al combo box
                string paginaActual = pagina.ToString();
                comboBox_pagina.Items.Clear();
                for (int i = 1; i <= paginas; i++)
                    comboBox_pagina.Items.Add(i.ToString());
                comboBox_pagina.Text = paginaActual;

                int inicial = (pagina - 1) * CantidadPorPagina + 1;
                int final = inicial - 1 + CantidadPorPagina;
                if (final > totalResultados) final = totalResultados;

                label_resultados.Text = "(mostrando " + inicial + " - " + final + " de " + totalResultados + " materiales encontrados)";
                if (comboBox_pagina.Text == "1")
                    button_paginaAnterior.Enabled = false;
                else
                    button_paginaAnterior.Enabled = true;

                if (comboBox_pagina.Text == paginas.ToString())
                    button_paginaSiguiente.Enabled = false;
                else
                    button_paginaSiguiente.Enabled = true;
            }
            else
            {
                label_resultados.Text = "(no hay resultados con este criterio de búsqueda)";
                button_paginaAnterior.Enabled = false;
                button_paginaSiguiente.Enabled = false;
            }
        }

        private void comboBox_cantidadPorPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Actualizamos el número de resultados por página
            cantidadPorPagina = int.Parse(comboBox_cantidadPorPagina.Text.ToString());
        }

        private void ordenModificado(int numColumna)
        {
            // Obtenemos la columna a ordenar
            DataGridViewColumn columna = dataGridView_materiales.Columns[numColumna];
            // Obtenemos el nombre de la columna que estaba ordenada anteriormente
            string nomColumnaAnterior = "dataGridViewTextBoxColumn_" + propiedadOrdenar;
            // Comprobamos si coincide con la columna actual
            if (columna.Name == nomColumnaAnterior)
            {
                // Coincide, cambiamos el orden
                if (columna.HeaderCell.SortGlyphDirection == SortOrder.Ascending)
                    columna.HeaderCell.SortGlyphDirection = SortOrder.Descending;
                else
                    columna.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
            }
            else
            {
                // Si no coincide, quitamos al orden a la anterior columna
                dataGridView_materiales.Columns[nomColumnaAnterior].HeaderCell.SortGlyphDirection = SortOrder.None;
                // Ponemos por defecto a la nueva columna descendente
                columna.HeaderCell.SortGlyphDirection = SortOrder.Descending;
                // Guardamos la nueva propiedad por la que ordenamos
                string nomColumna = columna.Name;
                propiedadOrdenar = nomColumna.Substring(nomColumna.LastIndexOf('_')+1);
            }
            FormPanelAdministracion.Instancia.MensajeEstado("Ordenando columna " + columna.HeaderText + " en modo " + Orden().ToString());
            pagina = 1;
            comboBox_pagina.Text = pagina.ToString();
            formMaterialesBusqueda.Buscar();
        }

        private void dataGridView_materiales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                editarMaterial();
        }

        private void button_paginaSiguiente_Click(object sender, EventArgs e)
        {
            // Cambiamos de página
            pagina++;
            comboBox_pagina.Text = pagina.ToString();
            // Realizamos una nueva búsqueda
            formMaterialesBusqueda.Buscar();
        }

        private void button_paginaAnterior_Click(object sender, EventArgs e)
        {
            // Cambiamos de página
            pagina--;
            comboBox_pagina.Text = pagina.ToString();
            // Realizamos una nueva búsqueda
            formMaterialesBusqueda.Buscar();
        }

        private void comboBox_pagina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            pagina = int.Parse(comboBox_pagina.Text.ToString());
            formMaterialesBusqueda.Buscar();
        }

        private void comboBox_cantidadPorPagina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Actualizamos el número de resultados por página
            cantidadPorPagina = int.Parse(comboBox_cantidadPorPagina.Text.ToString());
            pagina = 1;
            formMaterialesBusqueda.Buscar();
        }
    }
}