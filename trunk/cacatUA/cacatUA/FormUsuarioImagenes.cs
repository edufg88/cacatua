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
        private ENUsuario us;
        private ENImagen imagen;

        public FormUsuarioImagenes(ENUsuario usuario)
        {
            InitializeComponent();

            us = ENUsuario.Obtener(usuario.Id);
            imagen = new ENImagen();
        }

        public void CargarImagenes()
        {
            ArrayList datos = new ArrayList();
            datos = imagen.Buscar(us.Id);
            cargarDatos(datos);
        }

        // Este método carga los datos en el DataGridView
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

        private void cambiarSeleccionado(int id)
        {
            ENImagen imagen = new ENImagen();
            bool correcto = imagen.Obtener(id);

            if (correcto == false)
            {
                MessageBox.Show("Error al cargar la imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBox_id.Text = imagen.Id.ToString();
                textBox_titulo.Text = imagen.Titulo;
                textBox_descripcion.Text = imagen.Descripcion;
                textBox_archivo.Text = imagen.Archivo;
                dateTimePicker_fecha.Value = imagen.Fecha;
            }
        }

        private void cambiarNuevo()
        {
            textBox_id.Text = "";
            textBox_titulo.Text = "";
            textBox_descripcion.Text = "";
            textBox_archivo.Text = "";
            dateTimePicker_fecha.Value = DateTime.Now;
        }

        public void InsertarImagenes()
        {
            for (int i = 0; i < 10; i++)
            {
                ENImagen im = new ENImagen();
                im.Titulo = "titulo " + i.ToString();
                im.Descripcion = "descripcion " + i.ToString();
                im.Fecha = DateTime.Now;
                im.Usuario = ENUsuario.Obtener(3);
                im.Archivo = "fichero " + i.ToString();
                im.Guardar();
            }
        }

        private void button_guardarCambios_Click(object sender, EventArgs e)
        {
            ENImagen nueva = new ENImagen(int.Parse(textBox_id.Text));
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
                        ENImagen.Borrar(int.Parse(i.Cells[0].Value.ToString()));
                        dataGridView_imagenes.Rows.Remove(i);
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
        }

        private void dataGridView_imagenes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cambiarSeleccionado(int.Parse(dataGridView_imagenes.SelectedRows[0].Cells[0].Value.ToString()));
        }
    }
}
