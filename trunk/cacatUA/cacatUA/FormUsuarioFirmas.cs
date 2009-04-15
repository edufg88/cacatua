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
        private ENUsuario usuario;
        private ENFirma firma;

        public FormUsuarioFirmas(ENUsuario us)
        {
            InitializeComponent();

            usuario = ENUsuario.Obtener(us.Id);
            firma = new ENFirma();
        }

        public void CargarFirmas()
        {
            ArrayList datos = new ArrayList();
            datos = firma.Buscar(usuario.Usuario, "", DateTime.Now);
            cargarDatos(datos);
        }

        // Este método carga los datos en el DataGridView
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

        private void cambiarSeleccionado(int id)
        {
            ENFirma firma = new ENFirma();
            bool correcto = firma.Obtener(id);

            if (correcto == false)
            {
                MessageBox.Show("Error al cargar la firma", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBox_id.Text = firma.Id.ToString();
                textBox_emisor.Text = firma.Emisor.Usuario;
                textBox_receptor.Text = firma.Receptor.Usuario;
                textBox_texto.Text = firma.Texto;
                dateTimePicker_fecha.Value = firma.Fecha;
            }
        }

        private void cambiarNuevo()
        {
            textBox_id.Text = "";
            textBox_emisor.Text = "";
            textBox_receptor.Text = "";
            textBox_texto.Text = "";
            dateTimePicker_fecha.Value = DateTime.Now;
        }

        public void InsertarFirmas()
        {
            for (int i = 0; i < 10; i++)
            {
                ENFirma f = new ENFirma();
                f.Emisor = ENUsuario.Obtener(13);
                f.Receptor = ENUsuario.Obtener(12);
                f.Texto = "hola" + i.ToString();
                f.Fecha = DateTime.Now;
                f.Guardar();
            }
        }

        private void FormUsuarioFirmas_Load(object sender, EventArgs e)
        {
            // Cargamos en el DataGridView las firmas del usuario
            CargarFirmas();
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
                        ENFirma.Borrar(int.Parse(i.Cells[0].Value.ToString()));
                        dataGridView_firmas.Rows.Remove(i);
                    }
                }
            }

            cambiarNuevo();
        }

        private void button_guardarCambios_Click(object sender, EventArgs e)
        {
            ENFirma nueva = new ENFirma(int.Parse(textBox_id.Text));
            nueva.Emisor = ENUsuario.Obtener(textBox_emisor.Text);
            nueva.Receptor = ENUsuario.Obtener(textBox_receptor.Text);
            nueva.Texto = textBox_texto.Text;
            nueva.Fecha = dateTimePicker_fecha.Value;

            if (textBox_id.Text == "")
            {
                if (nueva.Guardar())
                {
                    cambiarSeleccionado(nueva.Id);
                    MessageBox.Show("Firma guardada correctamente.");
                    CargarFirmas();
                }
                else
                {
                    MessageBox.Show("Error al guardar la firma");
                }
            }
            else
            {
                nueva.Id = int.Parse(textBox_id.Text);
                if (nueva.Actualizar())
                {
                    MessageBox.Show("Firma actualizada correctamente.");
                    CargarFirmas();
                }
                else
                {
                    MessageBox.Show("Error al actualizar la firma.");
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
