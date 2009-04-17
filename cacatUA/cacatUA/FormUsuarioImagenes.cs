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
    public partial class FormUsuarioImagenes : InterfazForm
    {
        /// <summary>
        /// Puntero al usuario de las imágenes
        /// </summary>
        private ENUsuario us;

        /// <summary>
        /// Imagen actual
        /// </summary>
        private ENImagen imagen;


        /// <summary>
        /// Constructor del formulario FormUsuarioImagenes
        /// </summary>
        /// <param name="usuario">Recibe un puntero al usuario de las imágenes</param>
        public FormUsuarioImagenes(ENUsuario usuario)
        {
            InitializeComponent();

            us = ENUsuario.Obtener(usuario.Id);
            imagen = new ENImagen();
        }

        /// <summary>
        /// Carga todas las imágenes en el DataGridView del formulario
        /// </summary>
        public void CargarImagenes()
        {
            ArrayList datos = new ArrayList();
            datos = imagen.Buscar(us.Id);
            cargarDatos(datos);
        }

        /// <summary>
        /// Carga los datos recibidos en el DataGridView del formulario
        /// </summary>
        /// <param name="datos">Recibe un ArrayList con los datos que carga</param>
        private void cargarDatos(ArrayList datos)
        {
            // Borramos los elementos previos
            dataGridView_imagenes.Rows.Clear();
            
            for (int i = 0; i < datos.Count; i++)
            {
                ENImagen imagen = (ENImagen)datos[i];
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView_imagenes);
                fila.Cells[0].Value = imagen.Id;
                fila.Cells[1].Value = imagen.Usuario.Usuario;
                fila.Cells[2].Value = imagen.Titulo;
                fila.Cells[3].Value = imagen.Descripcion;        
                fila.Cells[4].Value = imagen.Fecha.ToString();
                fila.Cells[5].Value = imagen.Archivo;

                dataGridView_imagenes.Rows.Add(fila);
            }
        }

        /// <summary>
        /// Carga en el formulario los datos de la imagen recibida
        /// </summary>
        /// <param name="id">Recibe el id de la imagen a cargar</param>
        private void cambiarSeleccionado(int id)
        {
            ENImagen imagen = null;
            imagen = ENImagen.Obtener(id);

            if (imagen == null)
            {
                MessageBox.Show("Error al cargar la imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                activarBotones();
                errorProvider1.Clear();
                textBox_id.Text = imagen.Id.ToString();
                textBox_titulo.Text = imagen.Titulo;
                textBox_descripcion.Text = imagen.Descripcion;
                textBox_archivo.Text = imagen.Archivo;
                dateTimePicker_fecha.Value = imagen.Fecha;
            }
        }
        
        /// <summary>
        /// Vacia los campos del formulario
        /// </summary>
        private void cambiarNuevo()
        {
            desactivarBotones();
            errorProvider1.Clear();
            textBox_id.Text = "";
            textBox_titulo.Text = "";
            textBox_descripcion.Text = "";
            textBox_archivo.Text = "";
            dateTimePicker_fecha.Value = DateTime.Now;
        }

        /// <summary>
        /// Valida los campos del formulario
        /// </summary>
        /// <returns>Devuelve true si la validación ha sido correcta, false en caso contrario</returns>
        private bool validarFormulario()
        {
            // Validamos uno a uno todos los campos
            bool correcto = true;
            string error = "";
            // El título
            error = ENUsuario.ValidarFormulario("tituloImagen", textBox_titulo.Text);
            if (error != "")
            {
                errorProvider1.SetError(textBox_titulo, error);
                error = "";
                correcto = false;
            }
            // La descripción
            error = ENUsuario.ValidarFormulario("descripcionImagen", textBox_descripcion.Text);
            if (error != "")
            {
                errorProvider1.SetError(textBox_descripcion, error);
                error = "";
                correcto = false;
            }
            return correcto;
        }

        /// <summary>
        /// Activa los botones
        /// </summary>
        private void activarBotones()
        {
            button_guardarCambios.Enabled = true;
            button_descartarCambios.Enabled = true;
        }

        /// <summary>
        /// Desactiva los botones
        /// </summary>
        private void desactivarBotones()
        {
            button_guardarCambios.Enabled = false;
            button_descartarCambios.Enabled = false;
        }

        private void button_guardarCambios_Click(object sender, EventArgs e)
        {
            if (validarFormulario() && textBox_id.Text != "")
            {
                ENImagen nueva = ENImagen.Obtener(int.Parse(textBox_id.Text));
                nueva.Titulo = textBox_titulo.Text;
                nueva.Descripcion = textBox_descripcion.Text;
                nueva.Fecha = dateTimePicker_fecha.Value;
                nueva.Archivo = textBox_archivo.Text;

                if (textBox_id.Text == "")
                {
                    if (nueva.Guardar())
                    {
                        cambiarSeleccionado(nueva.Id);
                        MessageBox.Show("Imagen guardada correctamente.");
                        CargarImagenes();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar la imagen");
                    }
                }
                else
                {
                    nueva.Id = int.Parse(textBox_id.Text);
                    if (nueva.Actualizar())
                    {
                        MessageBox.Show("Imagen actualizada correctamente.");
                        CargarImagenes();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar la imagen.");
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

        private void button_borrarImagen_Click(object sender, EventArgs e)
        {
            if (dataGridView_imagenes.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection filas = dataGridView_imagenes.SelectedRows;
                if (DialogResult.Yes == MessageBox.Show("¿Está seguro de que desea borrar las imagenes seleccionadas?", "Ventana de confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    foreach (DataGridViewRow i in filas)
                    {
                        // Se borra de la lista y de la base de datos.
                        if (ENImagen.Borrar(int.Parse(i.Cells[0].Value.ToString())))
                        {
                            dataGridView_imagenes.Rows.Remove(i);
                        }
                        else
                        {
                            MessageBox.Show("Error al borrar la imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            cambiarNuevo();
        }

        private void button_editarImagen_Click(object sender, EventArgs e)
        {
            if (dataGridView_imagenes.SelectedRows.Count > 0)
            {
                cambiarSeleccionado(int.Parse(dataGridView_imagenes.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }

        private void FormUsuarioImagenes_Load(object sender, EventArgs e)
        {
            // Cargamos en el DataGridView las imágenes del usuario
            CargarImagenes();
            // Si no hay imagen seleccionada desactivamos los botones
            if (textBox_id.Text == "")
            {
                desactivarBotones();
            }
        }

        private void dataGridView_imagenes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cambiarSeleccionado(int.Parse(dataGridView_imagenes.SelectedRows[0].Cells[0].Value.ToString()));
        }
    }
}
