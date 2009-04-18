using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Libreria;

namespace cacatUA
{
    public partial class FormMaterialesBusqueda : InterfazForm
    {
        private FormMateriales formularioPadre = null;
        private ENCategoria categoria = null;
        private BusquedaMaterial busquedaActual = null;

        public FormMaterialesBusqueda(FormMateriales formularioPadre)
        {
            InitializeComponent();
            this.formularioPadre = formularioPadre;
            limpiarFormulario();
            busquedaActual = new BusquedaMaterial();
        }

        public override void Recibir(object objeto)
        {
            if (objeto != null)
            {
                if (objeto is ENCategoria)
                {
                    categoria = (ENCategoria)objeto;
                    textBox_categoria.Text = categoria.NombreCompleto();
                }
                else
                {
                    if (objeto is ENUsuario)
                        textBox_usuario.Text = ((ENUsuario)objeto).Usuario;
                }
            }
        }

        public ArrayList Buscar()
        {
            ArrayList materiales = null;
            // Obtenemos los datos introducidos por el usuario
            try
            {
                // Tipo de orden (ascendente o descendente)
                SortOrder orden = formularioPadre.Orden();
                bool ascendente = false;
                if (orden == SortOrder.Ascending)
                    ascendente = true;
                materiales = ENMaterial.Obtener(formularioPadre.PropiedadOrdenar, ascendente, formularioPadre.Pagina, formularioPadre.CantidadPorPagina, busquedaActual);
                
                // Obtenemos el número de materiales total de la búsqueda (contando todas las páginas)
                //MessageBox.Show(busquedaActual.NumResultados.ToString());
                formularioPadre.ActualizarPaginacion(busquedaActual.NumResultados);
                formularioPadre.mostrarMateriales(materiales);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return materiales;
        }

        public void NuevaBusqueda()
        {
            errorProvider.Clear();
            bool error = false;
            // Creamos una nueva búsqueda
            try
            {
                ENUsuario usuario = null;
                string str_usuario = textBox_usuario.Text;
                if (str_usuario != "")
                {
                    // Comprobamos si el usuario es válido
                    usuario = ENUsuario.Obtener(str_usuario);
                    if (usuario == null)
                    {
                        error = true;
                        errorProvider.SetError(textBox_usuario, "Usuario no válido");
                    }
                }
                string filtroBusqueda = textBox_filtroBusqueda.Text;
                DateTime fechaInicio = dateTimePicker_fechaInicio.Value;
                DateTime fechaFin = dateTimePicker_fechaFin.Value;
                if (error == false)
                {
                    busquedaActual = new BusquedaMaterial();
                    busquedaActual.Usuario = usuario;
                    busquedaActual.FiltroBusqueda = filtroBusqueda;
                    busquedaActual.FechaInicio = fechaInicio;
                    busquedaActual.FechaFin = fechaFin;
                    busquedaActual.Categoria = categoria;
                    // Ponemos la página a 1
                    formularioPadre.Pagina = 1;
                    Buscar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void buscarMaterial(object sender, EventArgs e)
        {
            NuevaBusqueda();
        }

        private void seleccionarCategoria(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormCategorias(), "Seleccionando categoría", true, true,
                "Volver al panel anterior seleccionando la categoría actual",
                "Cancelar la selección y volver al panel anterior");
        }

        private void seleccionarUsuario(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, true,
                "Volver al panel anterior seleccionando el usuario actual",
                "Cancelar la selección y volver al panel anterior");
        }

        private void limpiarFormulario(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        public void limpiarFormulario()
        {
            categoria = null;
            textBox_categoria.Clear();
            textBox_filtroBusqueda.Clear();
            textBox_usuario.Clear();
            dateTimePicker_fechaInicio.Value = new DateTime(2008, 9, 1);
            dateTimePicker_fechaFin.Value = DateTime.Now;
        }
    }
}
