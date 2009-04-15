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

        public void CambiarCrearNuevo()
        {

        }

        public void CambiarEdicion(int id)
        {

        }

        private void button_seccionCrear_Click(object sender, EventArgs e)
        {
            label_seccion1.Text = "Crear una nueva respuesta";
        }

        private void dataGridView_resultados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button_editarRespuesta_Click(object sender, EventArgs e)
        {

        }

        private void button_borrarRespuesta_Click(object sender, EventArgs e)
        {

        }

        private void button_seleccionarUsuario_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, true,
                "Volver al panel anterior seleccionando el usuario actual",
                "Cancelar la selección y volver al panel anterior");
        }

        private void button_guardarCambios_Click(object sender, EventArgs e)
        {

        }

        private void button_descartarCambios_Click(object sender, EventArgs e)
        {

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
    }
}
