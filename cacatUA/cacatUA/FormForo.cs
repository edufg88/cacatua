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

        private int totalResultados;
        private int paginaActual;
        private int totalPaginas;

        private void inicializar()
        {
            InitializeComponent();

            // Se crean los formularios que se van a utilizar.
            formEdicion = new FormForoEdicion(this);
            formBusqueda = new FormForoBusqueda(this);
            formEdicion.Dock = DockStyle.Top;
            formBusqueda.Dock = DockStyle.Top;
            formularioActivo = FormularioActivo.NINGUNO;

            comboBox_cantidadPorPagina.SelectedItem = comboBox_cantidadPorPagina.Items[4];
            comboBox_pagina.SelectedItem = comboBox_pagina.Items[0];

            totalResultados = 0;
            totalPaginas = 0;
            PaginaActual = 0;
        }

        public FormForo()
        {
            inicializar();
            CambiarFormularioBusqueda();
            formBusqueda.Buscar(true);
        }

        public FormForo(ENCategoria categoria)
        {
            inicializar();
            CambiarFormularioBusqueda();
            formBusqueda.Recibir(categoria);
            formBusqueda.Buscar(true);
        }

        /// <summary>
        /// Cambia al formulario de búsqueda. Limpia el antiguo UserControl del panel y carga el nuevo.
        /// </summary>
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

        /// <summary>
        /// Cambia al formulario de edición. Limpia el antiguo UserControl del panel y carga el nuevo.
        /// </summary>
        /// <param name="label">
        /// Texto con el que se identifica la acción. Por ejemplo, para diferenciar
        /// si es un nuevo hilo o una edición de otro antiguo.
        /// </param>
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

        /// <summary>
        /// Cambia al formulario de búsqueda, limpia el formulario y realiza una búsqueda ordenada por fecha.
        /// </summary>
        public void ReiniciarResultados()
        {
            CambiarFormularioBusqueda();
            formBusqueda.Limpiar();
            formBusqueda.Buscar(true);
        }

        /// <summary>
        /// Comprueba si el hilo recibido está actualmente mostrándose en el DataGridView y si está,
        /// actualiza dicha fila.
        /// </summary>
        /// <param name="hilo">Hilo que se va a actualizar.</param>
        /// <returns>Devuelve verdadero si ha actualizado alguna fila.</returns>
        public bool ActualizarResultados(ENHilo hilo)
        {
            bool actualizado = false;

            DataGridViewRowCollection filas = dataGridView_resultados.Rows;

            foreach (DataGridViewRow i in filas)
            {
                if (hilo.Id.ToString() == i.Cells[0].Value.ToString())
                {
                    i.Cells[1].Value = hilo.Titulo.ToString();
                    i.Cells[2].Value = hilo.Texto.ToString();
                    i.Cells[3].Value = hilo.Autor.Usuario.ToString();
                    i.Cells[5].Value = hilo.NumRespuestas;

                    actualizado = true;
                    break;
                }
            }

            return actualizado;
        }

        /// <summary>
        /// Establece los resultados en el DataGridView.
        /// </summary>
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
            if (e.RowIndex >= 0)
            {
                if (dataGridView_resultados.SelectedRows.Count > 0)
                {
                    CambiarFormularioEdicion("Editando hilo");
                    formEdicion.CambiarSeleccionado(int.Parse(dataGridView_resultados.SelectedRows[0].Cells[0].Value.ToString()));
                }
            }
        }

        private void button_borrarHilo_Click(object sender, EventArgs e)
        {
            if (dataGridView_resultados.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection filas = dataGridView_resultados.SelectedRows;
                if (DialogResult.Yes == MessageBox.Show("¿Está seguro de que desea borrar los hilos seleccionados?", "Ventana de confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    if (dataGridView_resultados.SelectedRows.Count>1)
                        FormPanelAdministracion.Instancia.MensajeEstado("Hilos eliminados correctamente.");
                    else
                        FormPanelAdministracion.Instancia.MensajeEstado("Hilo eliminado correctamente.");

                    foreach (DataGridViewRow i in filas)
                    {
                        // Se borra de la lista y de la base de datos.
                        ENHilo.Borrar(int.Parse(i.Cells[0].Value.ToString()));
                        dataGridView_resultados.Rows.Remove(i);

                        // Comprobamos si éste era el hilo seleccionado en el formulario de edición.
                        if (formEdicion.Seleccionado != null)
                        {
                            if (formEdicion.Seleccionado.Id == int.Parse(i.Cells[0].Value.ToString()))
                            {
                                formEdicion.CambiarNuevo();
                            }
                        }
                    }
                }
            }
            else
            {
                FormPanelAdministracion.Instancia.MensajeEstado("No hay hilos seleccionados.");
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

        /// <summary>
        /// Indica qué cantidad de resultados por página se están mostrando.
        /// Devuelve el valor seleccionado del ComboBox.
        /// </summary>
        public int CantidadPorPagina
        {
            get { return int.Parse(comboBox_cantidadPorPagina.Text); }
        }

        public int PaginaActual
        {
            get { return paginaActual; }
            set
            {
                paginaActual = value;
                if (paginaActual > 1)
                {
                    button_paginaAnterior.Enabled = true;
                }
                else
                {
                    button_paginaAnterior.Enabled = false;
                }

                if (paginaActual < totalPaginas && totalPaginas > 0 && totalResultados > 0)
                {
                    button_paginaSiguiente.Enabled = true;
                }
                else
                {
                    button_paginaSiguiente.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Indica por qué columna están siendo ordenados los resultados.
        /// </summary>
        public string OrdenarPor
        {
            get { return ""; }
            /*get
            {
                string ordenar = "";

                if (dataGridView_resultados.SortedColumn != null)
                {
                    if (dataGridView_resultados.SortedColumn == autor)
                    {
                        ordenar = "autor";
                    }
                    else if (dataGridView_resultados.SortedColumn == id)
                    {
                        ordenar = "id";
                    }
                    else if (dataGridView_resultados.SortedColumn == titulo)
                    {
                        ordenar = "titulo";
                    }
                    else if (dataGridView_resultados.SortedColumn == fechacreacion)
                    {
                        ordenar = "fechacreacion";
                    }
                    else if (dataGridView_resultados.SortedColumn == texto)
                    {
                        ordenar = "texto";
                    }
                    else if (dataGridView_resultados.SortedColumn == numRespuestas)
                    {
                        ordenar = "respuestas";
                    }
                }
                else
                {
                    Console.WriteLine("NO ESTA ORDENADA POR NINGUNA");
                }

                return ordenar;
            }*/
            /*get
            {
                if (comboBox1.SelectedItem != null)
                    return comboBox1.SelectedItem.ToString();
                else
                    return "";
            }*/
        }

        /// <summary>
        /// Indica si el orden es ascendente (verdadero) o descendente (falso).
        /// </summary>
        public bool Orden
        {
            get { return dataGridView_resultados.SortOrder == SortOrder.Ascending; }
            //get { return checkBox1.Checked; }
        }

        /// <summary>
        /// Devuelve la cantidad de resultados totales. También se pueden asignar una
        /// nueva cantidad de resultados, en cuyo caso se actualizará la cantidad de páginas.
        /// </summary>
        public int TotalResultados
        {
            get
            {
                return totalResultados;
            }

            set
            {
                totalResultados = value;
                comboBox_pagina.Items.Clear();
                totalPaginas = (int) Math.Ceiling(totalResultados / (float)CantidadPorPagina);
                for (int i = 0; i < totalPaginas; i++)
                {
                    comboBox_pagina.Items.Add(i + 1);
                }
                if (totalPaginas > 0)
                {
                    comboBox_pagina.SelectedItem = comboBox_pagina.Items[0];
                    PaginaActual = 1;
                }
                else
                {
                    PaginaActual = 0;
                }

                ActualizarPaginacion();
            }
        }

        /// <summary>
        /// Devuelve el último hilo que aparece en el DataGridView. Si no hay ninguno, null.
        /// </summary>
        public ENHilo UltimoHilo
        {
            get
            {
                if (dataGridView_resultados.Rows.Count > 0)
                    return ENHilo.Obtener(int.Parse(dataGridView_resultados.Rows[dataGridView_resultados.Rows.Count - 1].Cells[0].Value.ToString()));
                else
                    return null;
            }
        }

        /// <summary>
        /// Devuelve el primer hilo que aparece en el DataGridView. Si no hay ninguno, null.
        /// </summary>
        public ENHilo PrimerHilo
        {
            get
            {
                if (dataGridView_resultados.Rows.Count > 0)
                    return ENHilo.Obtener(int.Parse(dataGridView_resultados.Rows[0].Cells[0].Value.ToString()));
                else
                    return null;
            }
        }

        /// <summary>
        /// Sólo actualiza los label que indican los resultados totales, los resultados
        /// que se están mostrando, qué botones están activos, la página actual...
        /// </summary>
        public void ActualizarPaginacion()
        {
            if (totalResultados > 0)
            {
                int paginas = (int)Math.Ceiling(totalResultados / (float)CantidadPorPagina);
                int pagina = 0;

                try
                {
                    pagina = int.Parse(comboBox_pagina.Text);
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR: void FormForo.ActualizarPaginacion()");
                }

                int inicial = (pagina - 1) * CantidadPorPagina + 1;
                int final = inicial - 1 + CantidadPorPagina;
                if (final > totalResultados) final = totalResultados;

                label_resultados.Text = "(mostrando " + inicial + " - " + final + " de " + totalResultados + " hilos encontrados)";
            }
            else
            {
                label_resultados.Text = "(no hay resultados con este criterio de búsqueda)";
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

                if (objeto is ENHilo)
                {
                    ActualizarResultados((ENHilo)objeto);
                    formEdicion.CambiarSeleccionado(((ENHilo) objeto).Id);
                }
            }
        }

        private void dataGridView_resultados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (dataGridView_resultados.SortedColumn != null)
                {
                    dataGridView_resultados.SortedColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }

                ListSortDirection orden;
                if (dataGridView_resultados.SortOrder == SortOrder.Ascending)
                    orden = ListSortDirection.Descending;
                else
                    orden = ListSortDirection.Ascending;

                dataGridView_resultados.Sort(dataGridView_resultados.Columns[0], orden);

                formBusqueda.Buscar(false);
            }
        }

        private void button_paginaSiguiente_Click(object sender, EventArgs e)
        {
            PaginaActual++;
            if (PaginaActual > 0 && comboBox_pagina.Items.Count > PaginaActual - 1)
            {
                comboBox_pagina.SelectedItem = comboBox_pagina.Items[PaginaActual - 1];
                formBusqueda.Siguiente();
            }
        }

        private void button_paginaAnterior_Click(object sender, EventArgs e)
        {
            PaginaActual--;
            if (PaginaActual > 0 && comboBox_pagina.Items.Count > PaginaActual - 1)
            {
                comboBox_pagina.SelectedItem = comboBox_pagina.Items[PaginaActual - 1];
                formBusqueda.Anterior();
            }
        }

        private void comboBox_cantidadPorPagina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TotalResultados = TotalResultados;
            formBusqueda.Buscar(false);
        }

        private void comboBox_pagina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int paginaFinal = int.Parse(comboBox_pagina.SelectedItem.ToString());

            while (paginaFinal > PaginaActual)
            {
                PaginaActual++;
                formBusqueda.Siguiente();
            }

            while (paginaFinal < PaginaActual)
            {
                PaginaActual--;
                formBusqueda.Anterior();
            }
        }
    }
}
