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
    public partial class FormForoRespuestas : InterfazForm
    {
        private ENHilo hilo;
        private ENUsuario usuario;

        public FormForoRespuestas(ENHilo hilo)
        {
            InitializeComponent();
            this.hilo = hilo;
            label_foro.Text = "Respuestas del hilo nº " + hilo.Id;
            usuario = null;

            Resultados = ENRespuesta.Obtener(hilo);

            CambiarCrearNuevo();
        }

        /// <summary>
        /// Se asiga una lista con las respuestas que hay que mostrar en el DataGridView.
        /// </summary>
        public ArrayList Resultados
        {
            set
            {
                dataGridView_resultados.Rows.Clear();
                ArrayList lista = value;
                if (lista != null)
                {
                    for (int i = 0; i < lista.Count; i++)
                    {
                        DataGridViewRow fila = new DataGridViewRow();
                        fila.CreateCells(dataGridView_resultados);

                        ENRespuesta auxiliar = (ENRespuesta)lista[i];
                        fila.Cells[0].Value = auxiliar.Id.ToString();
                        fila.Cells[1].Value = auxiliar.Texto.ToString();
                        fila.Cells[2].Value = auxiliar.Autor.Usuario.ToString();
                        fila.Cells[3].Value = auxiliar.Fecha.ToString();
                        dataGridView_resultados.Rows.Add(fila);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un error con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }             
            }
        }

        /// <summary>
        /// Establece el formulario de "Crear nueva respuesta".
        /// </summary>
        public void CambiarCrearNuevo()
        {
            label_seccion1.Text = "Crear nueva respuesta";
            usuario = null;
            textBox_autor.Text = "";
            textBox_id.Text = "";
            textBox_texto.Text = "";
            dateTimePicker_fecha.Value = DateTime.Now;

            desactivarBotones();
        }

        /// <summary>
        /// Establece el formulario de "Editar respuesta".
        /// </summary>
        /// <param name="id">Identificador de la respuesta que se va a editar.</param>
        public void CambiarEdicion(int id)
        {
            ENRespuesta respuesta = ENRespuesta.Obtener(id);
            if (respuesta != null)
            {
                label_seccion1.Text = "Editando respuesta";
                usuario = respuesta.Autor;
                textBox_autor.Text = respuesta.Autor.Usuario;
                textBox_id.Text = respuesta.Id.ToString();
                textBox_texto.Text = respuesta.Texto;
                dateTimePicker_fecha.Value = respuesta.Fecha;

                desactivarBotones();
            }
            else
            {
                MessageBox.Show("No se puede cambiar a la respuesta nº " + id);
            }
        }

        private void formulario_Modificado(object sender, EventArgs e)
        {
            activarBotones();
        }

        private void activarBotones()
        {
            button_guardarCambios.Enabled = true;
            button_descartarCambios.Enabled = true;
        }

        private void desactivarBotones()
        {
            button_guardarCambios.Enabled = false;
            button_descartarCambios.Enabled = false;
        }

        private void button_seccionCrear_Click(object sender, EventArgs e)
        {
            CambiarCrearNuevo();
        }

        private void dataGridView_resultados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView_resultados.SelectedRows.Count > 0)
            {
                DataGridViewRow seleccionada = dataGridView_resultados.SelectedRows[0];
                CambiarEdicion(int.Parse(seleccionada.Cells[0].Value.ToString()));
            }
        }

        private void button_editarRespuesta_Click(object sender, EventArgs e)
        {
            if (dataGridView_resultados.SelectedRows.Count > 0)
            {
                DataGridViewRow seleccionada = dataGridView_resultados.SelectedRows[0];
                CambiarEdicion(int.Parse(seleccionada.Cells[0].Value.ToString()));
            }
        }

        public bool ValidarFormulario()
        {
            bool correcto = true;

            if (ENUsuario.Obtener(textBox_autor.Text) == null)
            {
                errorProvider1.SetError(textBox_autor, "No existe el usuario");
                correcto = false;
            }
            else
            {
                errorProvider1.SetError(textBox_autor, "");
            }

            return correcto;
        }

        private void button_borrarRespuesta_Click(object sender, EventArgs e)
        {
            if (dataGridView_resultados.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection filas = dataGridView_resultados.SelectedRows;
                if (DialogResult.Yes == MessageBox.Show("¿Está seguro de que desea borrar las respuestas seleccionadas?", "Ventana de confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    if (dataGridView_resultados.SelectedRows.Count > 1)
                        FormPanelAdministracion.Instancia.MensajeEstado("Respuestas eliminadas correctamente.");
                    else
                        FormPanelAdministracion.Instancia.MensajeEstado("Respuesta eliminada correctamente.");

                    foreach (DataGridViewRow i in filas)
                    {
                        // Se borra de la lista y de la base de datos.
                        ENRespuesta.Borrar(int.Parse(i.Cells[0].Value.ToString()));
                        dataGridView_resultados.Rows.Remove(i);

                        // Comprobamos si éste era el hilo seleccionado en el formulario de edición.
                        if (textBox_id.Text.ToString() == i.Cells[0].Value.ToString())
                        {
                            CambiarCrearNuevo();
                        }
                    }
                }
            }
            else
            {
                FormPanelAdministracion.Instancia.MensajeEstado("No hay hilos seleccionados.");
            }
        }

        private void button_seleccionarUsuario_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, true,
                "Volver al panel anterior seleccionando el usuario actual",
                "Cancelar la selección y volver al panel anterior");
        }

        private void button_guardarCambios_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                ENRespuesta nueva = new ENRespuesta();
                nueva.Texto = textBox_texto.Text;
                nueva.Autor = ENUsuario.Obtener(textBox_autor.Text);
                nueva.Fecha = dateTimePicker_fecha.Value;
                nueva.Hilo = hilo;

                if (textBox_id.Text == "")
                {
                    if (nueva.Guardar())
                    {
                        CambiarCrearNuevo();
                        FormPanelAdministracion.Instancia.MensajeEstado("Respuesta guardada correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se puede guardar la respuesta.", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    nueva.Id = int.Parse(textBox_id.Text.ToString());
                    if (nueva.Guardar())
                    {
                        CambiarEdicion(nueva.Id);
                        FormPanelAdministracion.Instancia.MensajeEstado("Respuesta actualizada correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se puede actualizar la respuesta.", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button_descartarCambios_Click(object sender, EventArgs e)
        {
            if (textBox_id.Text == "")
            {
                CambiarCrearNuevo();
            }
            else
            {
                CambiarEdicion(int.Parse(textBox_id.Text.ToString()));
            }
        }

        public override void Recibir(object objeto)
        {
            if (objeto != null)
            {
                if (objeto is ENUsuario)
                {
                    usuario = (ENUsuario)objeto;
                    textBox_autor.Text = usuario.Usuario;
                }
            }
        }

        public override object Enviar()
        {
            return hilo;
        }
    }
}
