using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Libreria;
using System.Collections;

namespace cacatUA
{
    public partial class FormUsuarios : InterfazForm
    {
        /// <summary>
        /// Formulario de búsqueda de usuario
        /// </summary>
        private FormUsuarioBusqueda formBusqueda;
        /// <summary>
        /// Formulario de edición de usuario
        /// </summary>
        private FormUsuarioEdicion formEdicion;
        /// <summary>
        /// Último usuario seleccionado
        /// </summary>
        private ENUsuario usuarioSeleccionado;

        /// <summary>
        /// Indica si el formulario tiene que enviar un usuario a otro.
        /// </summary>
        private bool devolver;

        private int numeroPagina = 1;
        private int tamañoPagina = 10;
        private int totalPaginas;
        private int totalBusqueda;

        public int NumeroPagina
        {
            get { return numeroPagina; }
            set { numeroPagina = value; }
        }

        public int TamañoPagina
        {
            get { return tamañoPagina; }
            set { tamañoPagina = value; }
        }

        public int TotalPaginas
        {
            get { return totalPaginas; }
            set { totalPaginas = value; }
        }

        public int TotalBusqueda
        {
            get { return totalBusqueda; }
            set { totalBusqueda = value; }
        }

        /// <summary>
        /// Constructor del formulario principal de usuarios
        /// </summary>
        public FormUsuarios()
        {
            InitializeComponent();
            formBusqueda = new FormUsuarioBusqueda(this);
            formEdicion = new FormUsuarioEdicion(this);
            formEdicion.Dock = DockStyle.Top;
            formBusqueda.Dock = DockStyle.Top;

            devolver = true;
            CambiarFormularioBusqueda();
            CargarUsuarios(); // Los cargamos en el DataGridView
        }

        /// <summary>
        /// Constructor sobrecargado
        /// </summary>
        /// <param name="usuario">Recibe un usuario y lo carga en el formulario de edición</param>
        public FormUsuarios(ENUsuario usuario)
        {
            InitializeComponent();
            formBusqueda = new FormUsuarioBusqueda(this);
            formEdicion = new FormUsuarioEdicion(this);
            formEdicion.Dock = DockStyle.Top;
            formBusqueda.Dock = DockStyle.Top;

            devolver = false;
            // En este constructor cargamos directamente un usuario en el formulario de edición
            CambiarFormularioEdicion();
            formEdicion.CambiarSeleccionado(usuario.Id);
            usuarioSeleccionado = usuario;
            CargarUsuarios();// Los cargamos en el DataGridView
        }

        /// <summary>
        /// Carga el formulario de búsqueda de usuarios
        /// </summary>
        public void CambiarFormularioBusqueda()
        {
            label_seccion1.Text = "Búsqueda";
            panel_contenedor.Controls.Clear();
            panel_contenedor.Controls.Add(formBusqueda);
            tableLayoutPanel_principal.RowStyles[3].Height = formBusqueda.Height;
        }

        /// <summary>
        /// Carga el formulario de edición de usuarios
        /// </summary>
        public void CambiarFormularioEdicion()
        {
            label_seccion1.Text = "Edición";
            panel_contenedor.Controls.Clear();
            panel_contenedor.Controls.Add(formEdicion);
            tableLayoutPanel_principal.RowStyles[3].Height = formEdicion.Height;
        }
        
        /// <summary>
        /// Carga todos los usuarios en el DataGridView de 'FormUsuarios'
        /// </summary>
        public void CargarUsuarios()
        {
            formBusqueda.BuscarUsuarios();

            comboBox_pagina.Items.Clear();
            for (int i = 1; i <= totalPaginas; i++)
                comboBox_pagina.Items.Add(i);

            comboBox_cantidadPorPagina.SelectedIndex = comboBox_cantidadPorPagina.Items.IndexOf(tamañoPagina.ToString());
            comboBox_pagina.SelectedIndex = comboBox_pagina.Items.IndexOf(numeroPagina);

            if (numeroPagina == 1)
                button_paginaAnterior.Enabled = false;
            else
                button_paginaAnterior.Enabled = true;
            if (numeroPagina == totalPaginas)
                button_paginaSiguiente.Enabled = false;
            else
                button_paginaSiguiente.Enabled = true;

            int desde = ((numeroPagina - 1) * tamañoPagina) + 1;
            int hasta = (numeroPagina * tamañoPagina);
            int total = totalBusqueda;

            if (hasta > total)
                hasta = total;

            if (totalBusqueda > 0)
                label_resultados.Text = "(mostrando " + desde + " - " + hasta + " de " + total + " hilos encontrados)";
            else
                label_resultados.Text = "(no hay resultados con este criterio de búsqueda)";
        }

        /// <summary>
        /// Carga un ArrayList con datos en el DataGridView de 'FormUsuarios'
        /// </summary>
        /// <param name="datos"> ArrayList con los datos a cargar </param>
        public void CargarDatos(ArrayList datos)
        {
            // Borramos los elementos previos
            dataGridView_usuarios.Rows.Clear();

            // Obtenemos todos los materiales que hay en la base de datos
            for (int i = 0; i < datos.Count; i++)
            {
                ENUsuario usuario = (ENUsuario)datos[i];
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView_usuarios);

                fila.Cells[0].Value = usuario.Id.ToString();
                fila.Cells[1].Value = usuario.Usuario.ToString();
                fila.Cells[2].Value = usuario.Contrasena.ToString();
                fila.Cells[3].Value = usuario.Nombre.ToString();
                fila.Cells[4].Value = usuario.Dni.ToString();
                fila.Cells[5].Value = usuario.Correo.ToString();
                fila.Cells[6].Value = usuario.Adicional.ToString();
                fila.Cells[7].Value = usuario.Fechaingreso.ToString();
                fila.Cells[8].Value = usuario.Activo.ToString();
                dataGridView_usuarios.Rows.Add(fila);
            }
        }

        /// <summary>
        /// Utilizado para la navegación
        /// </summary>
        /// <returns>Devuelve el usuario seleccionado en el momento</returns>
        override public Object Enviar()
        {
            if (devolver)
                return usuarioSeleccionado;
            else
                return null;
        }

        private void button_seccionBuscar_Click(object sender, EventArgs e)
        {
            // Cargamos el user control de busqueda
            CambiarFormularioBusqueda();
        }

        private void button_seccionCrear_Click(object sender, EventArgs e)
        {
            // Cargamos el user control de crear
            CambiarFormularioEdicion();
            formEdicion.CambiarNuevo();
        }

        private void dataGridView_usuarios_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {   
            CambiarFormularioEdicion();
            // Cargamos los datos en el formulario
            formEdicion.CambiarSeleccionado(int.Parse(dataGridView_usuarios.SelectedRows[0].Cells[0].Value.ToString()));
            usuarioSeleccionado = ENUsuario.Obtener(int.Parse(dataGridView_usuarios.SelectedRows[0].Cells[0].Value.ToString()));
        }

        private void button_editarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridView_usuarios.SelectedRows.Count > 0)
            {
                CambiarFormularioEdicion();
                formEdicion.CambiarSeleccionado(int.Parse(dataGridView_usuarios.SelectedRows[0].Cells[0].Value.ToString()));
                usuarioSeleccionado = ENUsuario.Obtener(int.Parse(dataGridView_usuarios.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }

        private void button_borrarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridView_usuarios.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection filas = dataGridView_usuarios.SelectedRows;
                if (DialogResult.Yes == MessageBox.Show("¿Está seguro de que desea borrar los usuarios seleccionados?", "Ventana de confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    foreach (DataGridViewRow i in filas)
                    {
                        // Se borra de la lista y de la base de datos.
                        if (ENUsuario.Borrar(int.Parse(i.Cells[0].Value.ToString())))
                        {
                            dataGridView_usuarios.Rows.Remove(i);
                        }
                        else
                        {
                            FormPanelAdministracion.Instancia.MensajeEstado("Error al borrar usuario.");
                        }
                    }
                }
            }

            formEdicion.CambiarNuevo();
        }

        private void dataGridView_usuarios_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (usuarioSeleccionado == null && devolver)
            {
                FormPanelAdministracion.Instancia.MostrarToolTip();
            }
            usuarioSeleccionado = ENUsuario.Obtener(int.Parse(dataGridView_usuarios.SelectedRows[0].Cells[0].Value.ToString()));
        }

        private void comboBox_cantidadPorPagina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tamañoPagina = int.Parse(comboBox_cantidadPorPagina.SelectedItem.ToString());
            numeroPagina = 1;
            CargarUsuarios();
        }

        private void comboBox_pagina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (numeroPagina == 1)
                button_paginaAnterior.Enabled = true;
            if (numeroPagina == totalPaginas)
                button_paginaSiguiente.Enabled = true;
          
            numeroPagina = int.Parse(comboBox_pagina.SelectedItem.ToString());
            CargarUsuarios();
        }

        private void button_paginaAnterior_Click(object sender, EventArgs e)
        {
            numeroPagina--;
            CargarUsuarios();
        }

        private void button_paginaSiguiente_Click(object sender, EventArgs e)
        {
            numeroPagina++;
            CargarUsuarios();
        }
    }
}
