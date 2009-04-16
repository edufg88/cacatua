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
    public partial class FormUsuarioEncuestas : InterfazForm
    {
        /// <summary>
        /// Usuario de las encuestas
        /// </summary>
        private ENUsuario us;
        /// <summary>
        /// Encuesta activa
        /// </summary>
        private ENEncuesta encuesta;

        /// <summary>
        /// Constructor del formulario FormUsuarioEncuestas
        /// </summary>
        /// <param name="us">Recibe el usuario de las encuestas</param>
        public FormUsuarioEncuestas(ENUsuario us)
        {
            InitializeComponent();
            this.us = ENUsuario.Obtener(us.Id);
            this.encuesta = new ENEncuesta();
        }

        /// <summary>
        /// Carga todas las encuestas en el DataGridView del formulario
        /// </summary>
        public void CargarEncuestas()
        {
            ArrayList datos = new ArrayList();
            datos = encuesta.Buscar(us.Id);
            cargarDatos(datos);
        }

        /// <summary>
        /// Este método carga los datos recibidos en el DataGridView del formulario
        /// </summary>
        /// <param name="datos">Recibe un ArrayList con los datos que cargará</param>
        private void cargarDatos(ArrayList datos)
        {
            // Borramos los elementos previos
            dataGridView_encuestas.Rows.Clear();

            for (int i = 0; i < datos.Count; i++)
            {
                ENEncuesta encuesta = (ENEncuesta)datos[i];
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView_encuestas);
                fila.Cells[0].Value = encuesta.Id;
                fila.Cells[1].Value = encuesta.Usuario.Usuario;
                fila.Cells[2].Value = encuesta.Pregunta;
                fila.Cells[3].Value = encuesta.Fecha.ToString();
                fila.Cells[4].Value = encuesta.Activa;

                dataGridView_encuestas.Rows.Add(fila);
            }
        }

        /// <summary>
        /// Carga en el formulario los datos de la encuesta recibida
        /// </summary>
        /// <param name="id">Recibe el id de la encuesta cuyos datos cargará</param>
        private void cambiarSeleccionado(int id)
        {
            ENEncuesta encuesta = ENEncuesta.Obtener(id);

            if (encuesta == null)
            {
                MessageBox.Show("Error al cargar la encuesta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                errorProvider1.Clear();
                textBox_id.Text = encuesta.Id.ToString();
                textBox_pregunta.Text = encuesta.Pregunta;
                dateTimePicker_fecha.Value = encuesta.Fecha;
                checkBox_activa.Checked = encuesta.Activa;
            }
        }

        /// <summary>
        /// Vacía el contenido del formulario
        /// </summary>
        private void cambiarNuevo()
        {
            errorProvider1.Clear();
            textBox_id.Text = "";
            textBox_pregunta.Text = "";
            dateTimePicker_fecha.Value = DateTime.Now;
            checkBox_activa.Checked = false;
        }
        
        /*
        public void InsertarEncuestas()
        {
            for (int i = 0; i < 10; i++)
            {
                ENEncuesta e = new ENEncuesta();
                e.Pregunta = "encuesta " + i.ToString();
                e.Usuario = ENUsuario.Obtener(3);
                e.Fecha = DateTime.Now;
                e.Activa = false;

                e.Guardar();
            }
        }
        */

        /// <summary>
        /// Valida los campos del formulario
        /// </summary>
        /// <returns>Devuelve true si la validación es correcta, false en caso contrario</returns>
        private bool validarFormulario()
        {
            // Validamos uno a uno todos los campos
            bool correcto = true;
            string error = "";
            // El campo de texto
            error = ENUsuario.ValidarFormulario("pregunta", textBox_pregunta.Text);
            if (error != "")
            {
                errorProvider1.SetError(textBox_pregunta, error);
                error = "";
                correcto = false;
            }
            return correcto;
        }

        private void button_guardarCambios_Click(object sender, EventArgs e)
        {
            if (validarFormulario() && textBox_id.Text != "")
            {
                ENEncuesta nueva = ENEncuesta.Obtener(int.Parse(textBox_id.Text));
                nueva.Pregunta = textBox_pregunta.Text;
                nueva.Usuario = ENUsuario.Obtener(this.us.Id);
                nueva.Fecha = dateTimePicker_fecha.Value;
                nueva.Activa = checkBox_activa.Checked;

                if (textBox_id.Text == "")
                {
                    if (nueva.Guardar())
                    {
                        cambiarSeleccionado(nueva.Id);
                        MessageBox.Show("Encuesta guardada correctamente.");
                        CargarEncuestas();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar la encuesta");
                    }
                }
                else
                {
                    nueva.Id = int.Parse(textBox_id.Text);
                    if (nueva.Actualizar())
                    {
                        MessageBox.Show("Encuesta actualizada correctamente");
                        CargarEncuestas();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar la encuesta");
                    }
                }
            }
        }

        private void button_descartarCambios_Click(object sender, EventArgs e)
        {
            if (textBox_id.Text == "")
            {
                cambiarNuevo();
            }
            else
            {
                cambiarSeleccionado(int.Parse(textBox_id.Text));
            }
        }

        private void button_editarImagen_Click(object sender, EventArgs e)
        {
            if (dataGridView_encuestas.SelectedRows.Count > 0)
            {
                cambiarSeleccionado(int.Parse(dataGridView_encuestas.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }

        private void button_borrarImagen_Click(object sender, EventArgs e)
        {
            if (dataGridView_encuestas.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection filas = dataGridView_encuestas.SelectedRows;
                if (DialogResult.Yes == MessageBox.Show("¿Está seguro de que desea borrar las encuestas seleccionadas?", "Ventana de confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    foreach (DataGridViewRow i in filas)
                    {
                        // Se borra de la lista y de la base de datos.
                        ENEncuesta.Borrar(int.Parse(i.Cells[0].Value.ToString()));
                        dataGridView_encuestas.Rows.Remove(i);
                    }
                }
            }

            cambiarNuevo();
        }

        private void dataGridView_encuestas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cambiarSeleccionado(int.Parse(dataGridView_encuestas.SelectedRows[0].Cells[0].Value.ToString()));
        }

        private void FormUsuarioEncuestas_Load(object sender, EventArgs e)
        {
            // Cargamos en el DataGridView las encuestas del usuario
            CargarEncuestas();
        }
    }
}
