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
    public partial class FormUsuarioFirmas : InterfazForm
    {
        /// <summary>
        /// Puntero al usuario de las firmas
        /// </summary>
        private ENUsuario usuario;
        /// <summary>
        /// Firma actual
        /// </summary>
        private ENFirma firma;

        /// <summary>
        /// Constructor del formulario FormUsuarioFirmas
        /// </summary>
        /// <param name="us">Recibe el usuario de las firmas</param>
        public FormUsuarioFirmas(ENUsuario us)
        {
            InitializeComponent();

            usuario = ENUsuario.Obtener(us.Id);
            firma = new ENFirma();
        }

        /// <summary>
        /// Carga todas las firmas en el DataGridView del formulario
        /// </summary>
        public void CargarFirmas()
        {
            ArrayList datos = new ArrayList();
            datos = firma.Buscar("", usuario.Usuario, DateTime.Now);
            cargarDatos(datos);
        }

        /// <summary>
        /// Carga los datos que recibe en el DataGridView
        /// </summary>
        /// <param name="datos">Recibe un ArrayList de datos que carga</param>
        private void cargarDatos(ArrayList datos)
        {
            // Borramos los elementos previos
            dataGridView_firmas.Rows.Clear();

            for (int i = 0; i < datos.Count; i++)
            {
                ENFirma firma = (ENFirma)datos[i];
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView_firmas);

                fila.Cells[0].Value = firma.Id.ToString();
                fila.Cells[1].Value = firma.Texto.ToString();
                fila.Cells[2].Value = firma.Emisor.Usuario.ToString();
                fila.Cells[3].Value = firma.Receptor.Usuario.ToString();
                fila.Cells[4].Value = firma.Fecha.ToString();

                dataGridView_firmas.Rows.Add(fila);
            }
        }

        /// <summary>
        /// Carga en el formulario los datos de la firma recibida
        /// </summary>
        /// <param name="id">Recibe el id de la firma que carga en el formulario</param>
        private void cambiarSeleccionado(int id)
        {
            ENFirma firma = ENFirma.Obtener(id);

            if (firma == null)
            {
                MessageBox.Show("Error al cargar la firma", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                activarBotones();
                errorProvider1.Clear();
                textBox_id.Text = firma.Id.ToString();
                textBox_emisor.Text = firma.Emisor.Usuario;
                textBox_receptor.Text = firma.Receptor.Usuario;
                textBox_texto.Text = firma.Texto;
                dateTimePicker_fecha.Value = firma.Fecha;
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

        private void FormUsuarioFirmas_Load(object sender, EventArgs e)
        {
            // Cargamos en el DataGridView las firmas del usuario
            CargarFirmas();

            // Si no hay ninguna firma seleccionada desactivamos los botones
            if (textBox_id.Text == "")
            {
                desactivarBotones();
            }
        }

        private void button_editarFirma_Click(object sender, EventArgs e)
        {
            if (dataGridView_firmas.SelectedRows.Count > 0)
            {
                cambiarSeleccionado(int.Parse(dataGridView_firmas.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }

        private void dataGridView_firmas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cambiarSeleccionado(int.Parse(dataGridView_firmas.SelectedRows[0].Cells[0].Value.ToString()));
        }

        private void button_borrarFirma_Click(object sender, EventArgs e)
        {
            if (dataGridView_firmas.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection filas = dataGridView_firmas.SelectedRows;
                if (DialogResult.Yes == MessageBox.Show("¿Está seguro de que desea borrar las firmas seleccionadas?", "Ventana de confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    foreach (DataGridViewRow i in filas)
                    {
                        // Se borra de la lista y de la base de datos.
                        if (ENFirma.Borrar(int.Parse(i.Cells[0].Value.ToString())))
                        {
                            dataGridView_firmas.Rows.Remove(i);
                        }
                        else
                        {
                            FormPanelAdministracion.Instancia.MensajeEstado("Error al borrar la firma");
                        }
                    }
                }
            }

            cambiarNuevo();
        }

        private void button_guardarCambios_Click(object sender, EventArgs e)
        {
            if (validarFormulario() && textBox_id.Text != "")
            {
                ENFirma nueva = ENFirma.Obtener(int.Parse(textBox_id.Text));
                nueva.Emisor = ENUsuario.Obtener(textBox_emisor.Text);
                nueva.Receptor = ENUsuario.Obtener(textBox_receptor.Text);
                nueva.Texto = textBox_texto.Text;
                nueva.Fecha = dateTimePicker_fecha.Value;

                if (textBox_id.Text == "")
                {
                    if (nueva.Guardar())
                    {
                        // Si se ha creado, mostramos el mensaje en la barra de estado
                        FormPanelAdministracion.Instancia.MensajeEstado("Firma guardada correctamente.");
                        // Cambiamos al formulario vacío
                        cambiarNuevo();
                        // Recargamos las encuestas
                        CargarFirmas();
                    }
                    else
                    {
                        FormPanelAdministracion.Instancia.MensajeEstado("Error al guardar la firma");
                    }
                }
                else
                {
                    nueva.Id = int.Parse(textBox_id.Text);
                    if (nueva.Actualizar())
                    {
                        FormPanelAdministracion.Instancia.MensajeEstado("Firma actualizada correctamente.");
                        CargarFirmas();
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
