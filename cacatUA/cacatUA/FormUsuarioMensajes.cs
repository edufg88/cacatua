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
        /// <summary>
        /// Puntero al usuario de los mensajes
        /// </summary>
        private ENUsuario usuario;

        /// <summary>
        /// Mensaje actual
        /// </summary>
        private ENMensaje mensaje;

        /// <summary>
        /// Constructor del formulario FromUsuarioMensajes
        /// </summary>
        /// <param name="usuario"></param>
        public FormUsuarioMensajes(ENUsuario usuario)
        {
            InitializeComponent();

            this.usuario = new ENUsuario();
            this.usuario = usuario;
            this.mensaje = new ENMensaje();
        }

        /// <summary>
        /// Carga todos los mensajes en el DataGridView del formulario
        /// </summary>
        public void CargarMensajes()
        {
            ArrayList datos = new ArrayList();
            datos = mensaje.Buscar("", usuario.Usuario, DateTime.Now);
            cargarDatos(datos);
        }

        /// <summary>
        /// Carga los datos recibidos en el DataGridView del formulario
        /// </summary>
        /// <param name="datos">Recibie un ArrayList con los datos que cargará</param>
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

        /// <summary>
        /// Carga en el formulario los datos del mensaje recibido
        /// </summary>
        /// <param name="id">Recibe el id del mensaje a cargar</param>
        private void cambiarSeleccionado(int id)
        {
            ENMensaje mensaje = ENMensaje.Obtener(id);
            
            if (mensaje == null)
            {
                FormPanelAdministracion.Instancia.MensajeEstado("Error al cargar el mensaje");
            }
            else
            {
                activarBotones();
                errorProvider1.Clear();
                textBox_id.Text = mensaje.Id.ToString();
                textBox_emisor.Text = mensaje.Emisor.Usuario;
                textBox_receptor.Text = mensaje.Receptor.Usuario;
                textBox_texto.Text = mensaje.Texto;
                dateTimePicker_fecha.Value = mensaje.Fecha;
            }
        }

        /// <summary>
        /// Vacía los campos del formulario
        /// </summary>
        private void cambiarNuevo()
        {
            desactivarBotones();
            errorProvider1.Clear();
            textBox_id.Text = "";
            textBox_emisor.Text = "";
            textBox_receptor.Text = "";
            textBox_texto.Text = "";
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

            // Si no hay ningún mensaje desactivamos los botones
            if (textBox_id.Text == "")
            {
                desactivarBotones();
            }
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
                        if (ENMensaje.Borrar(int.Parse(i.Cells[0].Value.ToString())))
                        {
                            dataGridView_mensajes.Rows.Remove(i);
                        }
                        else
                        {
                            FormPanelAdministracion.Instancia.MensajeEstado("Error al borrar el mensaje");
                        }
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
                        // Si se ha creado, mostramos el mensaje en la barra de estado
                        FormPanelAdministracion.Instancia.MensajeEstado("Mensaje guardado correctamente.");
                        // Cambiamos al formulario vacío
                        cambiarNuevo();
                        // Recargamos las encuestas
                        CargarMensajes();
                    }
                    else
                    {
                        FormPanelAdministracion.Instancia.MensajeEstado("Error al guardar el mensaje");
                    }
                }
                else
                {
                    nuevo.Id = int.Parse(textBox_id.Text);
                    if (nuevo.Actualizar())
                    {
                        FormPanelAdministracion.Instancia.MensajeEstado("Mensaje actualizado correctamente.");
                        CargarMensajes();
                    }
                    else
                    {
                        FormPanelAdministracion.Instancia.MensajeEstado("Error al actualizar la firma.");
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
