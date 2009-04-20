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
    public partial class FormGrupos : InterfazForm
    {
        private FormGruposEdicion formEdicion;
        private FormGruposBusqueda formBusqueda;
        private enum FormularioActivo { NINGUNO = 0, BUSQUEDA = 1, EDICION = 2 };
        FormularioActivo formularioActivo;

        private int cantidadPorPagina;
        private int totalResultados;
        private int paginaActual;
        private int totalPaginas;

        private void iniciar()
        {
            InitializeComponent();
            formEdicion = new FormGruposEdicion(this);
            formEdicion.Dock = DockStyle.Top;
            formBusqueda.Dock = DockStyle.Top;
            formularioActivo = FormularioActivo.NINGUNO;

            cantidadPorPagina = 5;
            comboBox_cantidadPorPagina.Text = cantidadPorPagina.ToString();
            comboBox_pagina.SelectedItem = comboBox_pagina.Items[0];

            propiedadOrdenar = "id";
            dataGridView_resultados.Columns["dataGridViewTextBoxColumn_id"].HeaderCell.SortGlyphDirection = SortOrder.Descending;
            totalResultados = 0;
            paginaActual = 0;
            totalPaginas = 0;
        }

        public FormGrupos()
        {
            formBusqueda = new FormGruposBusqueda(this);
            iniciar();
            Busqueda();
            formBusqueda.NuevaBusqueda();
        }

        public FormGrupos(ENUsuario usuario)
        {
            formBusqueda = new FormGruposBusqueda(this, usuario);
            iniciar();
            Busqueda();
            formBusqueda.NuevaBusqueda();
        }

        public void ReiniciarResultados()
        {
            Busqueda();
            formBusqueda.inicio();
            formBusqueda.NuevaBusqueda();
        }

        public void Busqueda()
        {
            if (formularioActivo != FormularioActivo.BUSQUEDA)
            {
                formularioActivo = FormularioActivo.BUSQUEDA;
                label_seccion1.Text = "Búsqueda";
                panel_contenedor.Controls.Clear();
                panel_contenedor.Controls.Add(formBusqueda);
                tableLayoutPanel_principal.RowStyles[3].Height = formBusqueda.Height;
                dataGridView_resultados.Sort(dataGridView_resultados.Columns[0], ListSortDirection.Descending);
            }
            else
            {
                formBusqueda.inicio();
                formBusqueda.NuevaBusqueda();
            }
        }

        /// <summary>
        /// Función para ver solo las opciones de edición
        /// </summary>
        private void Edicion()
        {
            if (formularioActivo != FormularioActivo.EDICION)
            {
                formularioActivo = FormularioActivo.EDICION;
                label_seccion1.Text = "Edición";
                panel_contenedor.Controls.Clear();
                panel_contenedor.Controls.Add(formEdicion);
                tableLayoutPanel_principal.RowStyles[3].Height = formEdicion.Height;
            }
        }

        public ArrayList Resultado
        {
            set
            {
                dataGridView_resultados.Rows.Clear();
                ArrayList lista = value;
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
        }

        private void button_seccionBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
            formBusqueda.inicio();
        }

        private void button_seccionCrear_Click(object sender, EventArgs e)
        {
            Edicion();
            formEdicion.Nuevo();
        }

        private void button_editar_Click(object sender, EventArgs e)
        {
            if (dataGridView_resultados.SelectedRows.Count > 0)
            {
                Edicion();
                formEdicion.Editar(int.Parse(dataGridView_resultados.SelectedRows[0].Cells[0].Value.ToString()));
            }
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
                    if (filas.Count == 1)
                    {
                        FormPanelAdministracion.Instancia.MensajeEstado("Grupo borrado correctamente");
                    }
                    else
                    {
                        FormPanelAdministracion.Instancia.MensajeEstado("Grupos borrados correctamente");
                    }
                }
                Busqueda();
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

        private void dataGridView_resultados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Edicion();
                formEdicion.Editar(int.Parse(dataGridView_resultados.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }


        /*
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

                label_resultados.Text = "(mostrando " + inicial + " - " + final + " de " + totalResultados + " grupos encontrados)";
            }
            else
            {
                label_resultados.Text = "(no hay resultados con este criterio de búsqueda)";
            }
        }*/

        /*public int TotalResultados
        {
            get
            {
                return totalResultados;
            }

            set
            {
                totalResultados = value;
                comboBox_pagina.Items.Clear();
                totalPaginas = (int)Math.Ceiling(totalResultados / (float)CantidadPorPagina);
                for (int i = 0; i < totalPaginas; i++)
                {
                    comboBox_pagina.Items.Add(i + 1);
                }
                if (totalPaginas > 0)
                {
                    comboBox_pagina.SelectedItem = comboBox_pagina.Items[0];
                    PaginaActual = 1;
                }

                ActualizarPaginacion();
            }
        }

        public ENGrupos UltimoGrupo
        {
            get
            {
                if (dataGridView_resultados.Rows.Count > 0)
                    return ENGrupos.Obtener(int.Parse(dataGridView_resultados.Rows[dataGridView_resultados.Rows.Count - 1].Cells[0].Value.ToString()));
                else
                    return null;
            }
        }

        public ENGrupos PrimerGrupo
        {
            get
            {
                if (dataGridView_resultados.Rows.Count > 0)
                    return ENGrupos.Obtener(int.Parse(dataGridView_resultados.Rows[0].Cells[0].Value.ToString()));
                else
                    return null;
            }
        }*/
        public int CantidadPorPagina
        {
            get { return cantidadPorPagina; }
            set { cantidadPorPagina = value; }
        }

        /*public bool Orden
        {
            get { return dataGridView_resultados.SortOrder == SortOrder.Ascending; }
        }*/

        public int PaginaActual
        {
            get { return paginaActual; }
            set { paginaActual = value; }
        }
        /*
        private void button_paginaSiguiente_Click(object sender, EventArgs e)
        {
            PaginaActual++;
            comboBox_pagina.SelectedItem = comboBox_pagina.Items[PaginaActual - 1];
            formBusqueda.Siguiente();
        }

        private void button_paginaAnterior_Click(object sender, EventArgs e)
        {
            PaginaActual--;
            if (PaginaActual > 0)
                comboBox_pagina.SelectedItem = comboBox_pagina.Items[PaginaActual - 1];
            formBusqueda.Anterior();
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
        }*/

        private void dataGridView_resultados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                ordenModificado(e.ColumnIndex);
            }
        }

        /*private void dataGridView_resultados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
        }*/

        private void ordenModificado(int numColumna)
        {
            // Obtenemos la columna a ordenar
            DataGridViewColumn columna = dataGridView_resultados.Columns[numColumna];
            // Obtenemos el nombre de la columna que estaba ordenada anteriormente
            string nomColumnaAnterior = "DataGridViewTextBoxColumn_" + propiedadOrdenar;
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
                dataGridView_resultados.Columns[nomColumnaAnterior].HeaderCell.SortGlyphDirection = SortOrder.None;
                // Ponemos por defecto a la nueva columna descendente
                columna.HeaderCell.SortGlyphDirection = SortOrder.Descending;
                // Guardamos la nueva propiedad por la que ordenamos
                string nomColumna = columna.Name;
                propiedadOrdenar = nomColumna.Substring(nomColumna.LastIndexOf('_') + 1);
            }
            FormPanelAdministracion.Instancia.MensajeEstado("Ordenando columna " + columna.HeaderText + " en modo " + Ordenar().ToString());
            paginaActual = 1;
            comboBox_pagina.Text = paginaActual.ToString();
            formBusqueda.Buscar();
        }

        private string propiedadOrdenar;
        public string PropiedadOrdenar
        {
            get { return propiedadOrdenar; }
            set { propiedadOrdenar = value; }
        }

        public SortOrder Ordenar()
        {
            string nomColumna = "dataGridViewTextBoxColumn_" + propiedadOrdenar;
            return dataGridView_resultados.Columns[nomColumna].HeaderCell.SortGlyphDirection;
        }

        public void ActualizarPaginacion(int totalResultados)
        {
            if (totalResultados > 0)
            {
                int paginas = (int)Math.Ceiling(totalResultados / (float)CantidadPorPagina);
                // Añadimos las páginas al combo box
                string pagina = paginaActual.ToString();
                comboBox_pagina.Items.Clear();
                for (int i = 1; i <= paginas; i++)
                    comboBox_pagina.Items.Add(i.ToString());
                comboBox_pagina.Text = pagina;

                int inicial = (paginaActual - 1) * CantidadPorPagina + 1;
                int final = inicial - 1 + CantidadPorPagina;
                if (final > totalResultados) final = totalResultados;

                label_resultados.Text = "(mostrando " + inicial + " - " + final + " de " + totalResultados + " grupos encontrados)";
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
            CantidadPorPagina = int.Parse(comboBox_cantidadPorPagina.Text.ToString());
        }

        private void button_paginaSiguiente_Click(object sender, EventArgs e)
        {
            // Cambiamos de página
            paginaActual++;
            comboBox_pagina.Text = paginaActual.ToString();
            // Realizamos una nueva búsqueda
            formBusqueda.Buscar();
        }

        private void button_paginaAnterior_Click(object sender, EventArgs e)
        {
            // Cambiamos de página
            paginaActual--;
            comboBox_pagina.Text = paginaActual.ToString();
            // Realizamos una nueva búsqueda
            formBusqueda.Buscar();
        }

        private void comboBox_pagina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            paginaActual = int.Parse(comboBox_pagina.Text.ToString());
            formBusqueda.Buscar();
        }

        private void comboBox_cantidadPorPagina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Actualizamos el número de resultados por página
            CantidadPorPagina = int.Parse(comboBox_cantidadPorPagina.Text.ToString());
            formBusqueda.Buscar();
        }
    }
}

