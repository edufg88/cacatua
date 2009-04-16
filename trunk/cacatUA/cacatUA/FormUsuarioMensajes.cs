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
    public partial class FormUsuarioMensajes : InterfazForm
    {
        private ENUsuario usuario;
        private ENMensaje mensaje;

        public FormUsuarioMensajes(ENUsuario usuario)
        {
            InitializeComponent();

            this.usuario = new ENUsuario();
            this.usuario = usuario;
            this.mensaje = new ENMensaje();
        }

        public void InsertarMensajes()
        {
            for (int i = 0; i < 10; i++)
            {
                ENMensaje m = new ENMensaje();
                m.Emisor = ENUsuario.Obtener(3);
                m.Receptor = ENUsuario.Obtener(4);
                m.Texto = "mensaje " + i.ToString();
                m.Fecha = DateTime.Now;
                m.Guardar();
            }
        }

        public void CargarMensajes()
        {
            ArrayList datos = new ArrayList();
            datos = mensaje.Buscar(usuario.Usuario, "", DateTime.Now);
            cargarDatos(datos);
        }

        // Este método carga los datos en el DataGridView
        private void cargarDatos(ArrayList datos)
        {
            // Borramos los elementos previos
            dataGridView_mensajes.Rows.Clear();

            for (int i = 0; i < datos.Count; i++)
            {
                ENMensaje mensaje = (ENMensaje)datos[i];
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView_mensajes);

                fila.Cells[0].Value = mensaje.Id.ToString();
                fila.Cells[1].Value = mensaje.Texto.ToString();
                fila.Cells[2].Value = mensaje.Emisor.Usuario.ToString();
                fila.Cells[3].Value = mensaje.Receptor.Usuario.ToString();
                fila.Cells[4].Value = mensaje.Fecha.ToString();

                dataGridView_mensajes.Rows.Add(fila);
            }
        }

        private void cambiarSeleccionado(int id)
        {
            ENMensaje mensaje = ENMensaje.Obtener(id);
            
            if (mensaje == null)
            {
                MessageBox.Show("Error al cargar el mensaje", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                errorProvider1.Clear();
                textBox_id.Text = mensaje.Id.ToString();
                textBox_emisor.Text = mensaje.Emisor.Usuario;
                textBox_receptor.Text = mensaje.Receptor.Usuario;
                textBox_texto.Text = mensaje.Texto;
                dateTimePicker_fecha.Value = mensaje.Fecha;
            }
        }

        private void cambiarNuevo()
        {
            errorProvider1.Clear();
            textBox_id.Text = "";
            textBox_emisor.Text = "";
            textBox_receptor.Text = "";
            textBox_texto.Text = "";
            dateTimePicker_fecha.Value = DateTime.Now;
        }

        private bool validarFormulario()
        {
            // Validamos uno a uno todos los campos
            bool correcto = true;
            string error = "";
            // El campo de texto
            error = ENUsuario.ValidarFormulario("textoFirma", textBox_texto.Text);
            if (error != "")
            {
                errorProvider1.SetError(textBox_texto, error);
                error = "";
                correcto = false;
            }
            return correcto;
        }

        private void button_editarMensaje_Click(object sender, EventArgs e)
        {
            if (dataGridView_mensajes.SelectedRows.Count > 0)
            {
                cambiarSeleccionado(int.Parse(dataGridView_mensajes.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }

        private void FormUsuarioMensajes_Load(object sender, EventArgs e)
        {
            // Cargamos en el DataGridView los mensajes del usuario
            CargarMensajes();
        }

        private void button_borrarMensaje_Click(object sender, EventArgs e)
        {
            if (dataGridView_mensajes.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection filas = dataGridView_mensajes.SelectedRows;
                if (DialogResult.Yes == MessageBox.Show("¿Está seguro de que desea borrar los mensajes seleccionados?", "Ventana de confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    foreach (DataGridViewRow i in filas)
                    {
                        // Se borra de la lista y de la base de datos.
                        ENMensaje.Borrar(int.Parse(i.Cells[0].Value.ToString()));
                        dataGridView_mensajes.Rows.Remove(i);
                    }
                }
            }

            cambiarNuevo();
        }

        private void dataGridView_mensajes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cambiarSeleccionado(int.Parse(dataGridView_mensajes.SelectedRows[0].Cells[0].Value.ToString()));
        }

        private void button_guardarCambios_Click(object sender, EventArgs e)
        {
            if (validarFormulario() && textBox_id.Text != "")
            {
                ENMensaje nuevo = ENMensaje.Obtener(int.Parse(textBox_id.Text));
                nuevo.Emisor = ENUsuario.Obtener(textBox_emisor.Text);
                nuevo.Receptor = ENUsuario.Obtener(textBox_receptor.Text);
                nuevo.Texto = textBox_texto.Text;
                nuevo.Fecha = dateTimePicker_fecha.Value;

                if (textBox_id.Text == "")
                {
                    if (nuevo.Guardar())
                    {
                        cambiarSeleccionado(nuevo.Id);
                        MessageBox.Show("Mensaje guardado correctamente.");
                        CargarMensajes();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el mensaje");
                    }
                }
                else
                {
                    nuevo.Id = int.Parse(textBox_id.Text);
                    if (nuevo.Actualizar())
                    {
                        MessageBox.Show("Mensaje actualizado correctamente.");
                        CargarMensajes();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar la firma.");
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
    }
}
