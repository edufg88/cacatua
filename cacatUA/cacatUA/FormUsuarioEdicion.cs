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
    public partial class FormUsuarioEdicion : UserControl
    {
        // Puntero al formulario padre
        private FormUsuarios padre;


        public FormUsuarioEdicion(FormUsuarios padre)
        {
            InitializeComponent();

            this.padre = padre;
        }

        public void CambiarSeleccionado(int id)
        { 
            // Cargamos los datos del usuario con esa id en los campos
            ENUsuario usuario = new ENUsuario(id);

            textBox_nombre.Text = usuario.Usuario;
            textBox_email.Text = usuario.Correo;
            dateTimePicker_fechaDeIngreso.Value = usuario.Fechaingreso;
            checkBox_esAdmin.Checked = usuario.EsAdministrador();
        }

        private void CargarFirmas()
        {
            ArrayList al = new ArrayList();
            al = ENFirma.Obtener();

            CargarDatosFirmas(al);
        }

        // Este método carga los datos en el DataGridView
        public void CargarDatosFirmas(ArrayList datos)
        {
            // Borramos los elementos previos
            dataGridView_firmas.Rows.Clear();

            // Obtenemos todos los materiales que hay en la base de datos
            for (int i = 0; i < datos.Count; i++)
            {
                ENFirma firma = (ENFirma)datos[i];
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView_firmas);

                fila.Cells[0].Value = firma.Id.ToString();
                fila.Cells[1].Value = firma.Emisor.Usuario.ToString();
                fila.Cells[2].Value = firma.Texto.ToString();
                fila.Cells[3].Value = firma.Fecha.ToString();
                fila.Cells[4].Value = firma.Receptor.Usuario.ToString();

                dataGridView_firmas.Rows.Add(fila);
            }
        }

        ////////////////////////////////////
        // MÉTODOS DE INSERCIÓN DE PRUEBA //
        ////////////////////////////////////

        private void insertarFirmasPrueba()
        {
            for (int i = 0; i < 10; i++)
            {
                ENFirma firma = new ENFirma("edu8", "que tal tio" + i.ToString(), DateTime.Now, "edu" + i.ToString());
                firma.Guardar();
            }
        }

        // ---------------------------------


        private void button_buscarFirma_Click(object sender, EventArgs e)
        {
            // Cogemos los datos de los formularios
            bool realizada = radioButton_realizadasPorUsuario.Checked;
            DateTime fechaFirma = dateTimePicker_fechaFirma.Value;
            string autor = textBox_autorFirma.Text;
            ArrayList resultado = new ArrayList();

            if (realizada)
            {
                resultado = ENFirma.Buscar(autor, "", fechaFirma);
            }
            else 
            {
                resultado = ENFirma.Buscar("", autor, fechaFirma);
            }

            // Aquí cargamos el DataGridView
            CargarDatosFirmas(resultado);
        }

        private void button_buscarGaleria_Click(object sender, EventArgs e)
        {
            // Código para buscar imagenes
            // Cogemos los datos de los formularios

            // Aquí cargamos el DataGridView
            
        }

        private void button_buscarMensaje_Click(object sender, EventArgs e)
        {
            // Código para buscar firmas
            // Aquí cargamos el DataGridView
        }

        private void button_buscarPeticion_Click(object sender, EventArgs e)
        {
            // Código para buscar firmas
            // Aquí cargamos el DataGridView
        }

        private void button_buscarEncuesta_Click(object sender, EventArgs e)
        {
            // Código para buscar firmas
            // Aquí cargamos el DataGridView
        }

        private void button_guardarCambios_Click(object sender, EventArgs e)
        {
            // Código para almacenar los cambios

            // Comprobamos si existe el usuario
                // Si existe actualizamos
                // Si no existe creamos
        }

        private void button_descartarCambios_Click(object sender, EventArgs e)
        {
            // Código para descartar los cambios
        }

        private void FormUsuarioEdicion_Load(object sender, EventArgs e)
        {
            // Al cargar cargamos en la base de datos algunas firmas
            CargarFirmas();
        }
    }
}
