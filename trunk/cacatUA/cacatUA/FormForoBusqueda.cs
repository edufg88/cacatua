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
    public partial class FormForoBusqueda : InterfazForm
    {
        private FormForo formularioPadre = null;
        private ENCategoria categoria = null;
        private ENUsuario usuario = null;

        /// <summary>
        /// Es una lista de objetos:
        ///     string filtroBusqueda, ENUsuario autor, ENCategoria categoria, DateTime fechaInicio y DateTime fechaFin.
        /// </summary>
        private ArrayList ultimaBusqueda = null;

        public FormForoBusqueda(FormForo formularioPadre)
        {
            this.formularioPadre = formularioPadre;
            InitializeComponent();

            ultimaBusqueda = new ArrayList();
            ultimaBusqueda.Add("");
            ultimaBusqueda.Add((ENUsuario) null);
            ultimaBusqueda.Add((ENCategoria) null);
            ultimaBusqueda.Add(new DateTime(2008, 9, 1));
            ultimaBusqueda.Add(DateTime.Now);
        }

        public void Limpiar()
        {
            categoria = null;
            usuario = null;
            textBox_filtroBusqueda.Text = "";
            textBox_autor.Text = "";
            textBox_categoria.Text = "";
            dateTimePicker_fechaInicio.Value = new DateTime(2008, 9, 1);
            dateTimePicker_fechaFin.Value = DateTime.Now;
            errorProvider1.Clear();
        }

        public bool ValidarFormulario()
        {
            bool correcto = true;
            string errorUsuario = "";
            string errorFecha = "";

            if (textBox_autor.Text != "")
            {
                usuario = ENUsuario.Obtener(textBox_autor.Text);
                if (usuario==null)
                {
                    correcto = false;
                    errorUsuario = "Este usuario no existe.";
                }
            }

            if (dateTimePicker_fechaFin.Value < dateTimePicker_fechaInicio.Value)
            {
                correcto = false;
                errorFecha = "La fecha de inicio es posterior a la fecha de fin.";
            }

            errorProvider1.SetError(textBox_autor, errorUsuario);
            errorProvider1.SetError(dateTimePicker_fechaFin, errorFecha);

            return correcto;
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            Buscar(true);
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void button_seleccionarUsuario_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, true, "Volver al panel anterior seleccionando el usuario actual", "Cancelar la selección y volver al panel anterior");
        }

        private void button_seleccionarCategoria_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormCategorias(), "Seleccionando categoría", true, true, "Volver al panel anterior seleccionando la categoría actual", "Cancelar la selección y volver al panel anterior");
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
                    {
                        usuario = (ENUsuario)objeto;
                        textBox_autor.Text = usuario.Usuario;
                    }
                }
            }
        }

        public void Buscar(bool nueva)
        {
            bool buscar = true;
            // Si es una nueva búsqueda, validammos el formulario para guardar los datos en la ultimaBusqueda.
            if (nueva)
            {
                if (ValidarFormulario())
                {
                    // Obtenemos los valores del formulario.
                    ultimaBusqueda.Clear();
                    ultimaBusqueda.Add(textBox_filtroBusqueda.Text);
                    ultimaBusqueda.Add(ENUsuario.Obtener(textBox_autor.Text));
                    ultimaBusqueda.Add(categoria);
                    ultimaBusqueda.Add(dateTimePicker_fechaInicio.Value);
                    ultimaBusqueda.Add(dateTimePicker_fechaFin.Value);
                }
                else
                {
                    // Si era una nueva búsqueda y el formulario no era correcto, no buscamos.
                    buscar = false;
                }
            }

            if (buscar)
            {
                // Criterios de búsqueda.
                ENUsuario usuarioAux = (ENUsuario)ultimaBusqueda[1];
                ENCategoria categoriaAux = (ENCategoria)ultimaBusqueda[2];
                DateTime fechaInicio = (DateTime)ultimaBusqueda[3];
                DateTime fechaFin = (DateTime)ultimaBusqueda[4];

                if (nueva)
                {
                    // Calculamos cuántos resultados hay con esta búsqueda (necesarios para saber cuántas páginas hay).
                    // Sólo recalculamos los resultados totales si se trata de una nueva búsqueda.
                    formularioPadre.TotalResultados = ENHilo.Cantidad((string)ultimaBusqueda[0],
                        (string)ultimaBusqueda[0], ref usuarioAux, ref fechaInicio, ref fechaFin, ref categoriaAux);
                }

                // Atributos para la paginación.
                int cantidad = formularioPadre.CantidadPorPagina;
                string ordenar = formularioPadre.OrdenarPor;
                ENHilo ultimo = null;
                bool orden = formularioPadre.Orden;

                // Realizamos la búsqueda finalmente.
                formularioPadre.Resultados = ENHilo.Obtener(cantidad, ultimo, ordenar, orden, (string)ultimaBusqueda[0],
                    (string)ultimaBusqueda[0], ref usuarioAux, ref fechaInicio, ref fechaFin, ref categoriaAux);
            }
        }

        public void Siguiente()
        {
            // Criterios de búsqueda.
            ENUsuario usuarioAux = (ENUsuario)ultimaBusqueda[1];
            ENCategoria categoriaAux = (ENCategoria)ultimaBusqueda[2];
            DateTime fechaInicio = (DateTime)ultimaBusqueda[3];
            DateTime fechaFin = (DateTime)ultimaBusqueda[4];

            // Atributos para la paginación.
            int cantidad = formularioPadre.CantidadPorPagina;
            string ordenar = formularioPadre.OrdenarPor;
            ENHilo ultimo = formularioPadre.UltimoHilo;
            bool orden = formularioPadre.Orden;

            //if (ultimo != null) Console.WriteLine("         >>>>> " + ultimo.Titulo);

            // Realizamos la búsqueda finalmente.
            formularioPadre.Resultados = ENHilo.Obtener(cantidad, ultimo, ordenar, orden, (string)ultimaBusqueda[0],
                (string)ultimaBusqueda[0], ref usuarioAux, ref fechaInicio, ref fechaFin, ref categoriaAux);

            formularioPadre.ActualizarPaginacion();
        }

        public void Anterior()
        {
            // Criterios de búsqueda.
            ENUsuario usuarioAux = (ENUsuario)ultimaBusqueda[1];
            ENCategoria categoriaAux = (ENCategoria)ultimaBusqueda[2];
            DateTime fechaInicio = (DateTime)ultimaBusqueda[3];
            DateTime fechaFin = (DateTime)ultimaBusqueda[4];

            // Atributos para la paginación.
            int cantidad = formularioPadre.CantidadPorPagina;
            string ordenar = formularioPadre.OrdenarPor;
            ENHilo ultimo = formularioPadre.PrimerHilo;
            bool orden = formularioPadre.Orden;

            //if (ultimo != null) Console.WriteLine("         >>>>> " + ultimo.Titulo);

            // Realizamos la búsqueda finalmente.
            ArrayList resultados = ENHilo.Obtener(cantidad, ultimo, ordenar, !orden, (string)ultimaBusqueda[0],
               (string)ultimaBusqueda[0], ref usuarioAux, ref fechaInicio, ref fechaFin, ref categoriaAux);

            // Hay que invertir el resultado.
            resultados.Reverse();
            formularioPadre.Resultados = resultados;

            formularioPadre.ActualizarPaginacion();
        }
    }
}
