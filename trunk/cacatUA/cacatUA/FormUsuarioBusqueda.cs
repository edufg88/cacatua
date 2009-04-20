using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Libreria;

namespace cacatUA
{
    public partial class FormUsuarioBusqueda : UserControl
    {
        /// <summary>
        /// Puntero al formulario padre
        /// </summary>
        private FormUsuarios padre;

        /// <summary>
        /// Constructor del formulario de búsqueda
        /// </summary>
        /// <param name="padre">Recibe un puntero al formulario padre</param>
        public FormUsuarioBusqueda(FormUsuarios padre)
        {
            InitializeComponent();
            textBox_email.Clear();
            textBox_nombreUsuario.Clear();

            this.padre = padre;
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            BuscarUsuarios();
        }

        public void BuscarUsuarios()
        {
            ArrayList usuarios;
            if (textBox_email.Text != "" || textBox_nombreUsuario.Text != "")
            {
                padre.TotalPaginas = ((ENUsuario.NumUsuarios(textBox_nombreUsuario.Text, textBox_email.Text, dateTimePicker_fechaIngreso.Value) - 1) / padre.TamañoPagina) + 1;
                usuarios = ENUsuario.Buscar(textBox_nombreUsuario.Text, textBox_email.Text, dateTimePicker_fechaIngreso.Value,padre.NumeroPagina,padre.TamañoPagina);
                // Aquí tenemos que llevar el resultado al datagrid de formUsuario.    
            }
            else
            {
               padre.TotalPaginas = ((ENUsuario.NumUsuarios() - 1) / padre.TamañoPagina) + 1;
                //Llevamos al grid todos los usuarios
               usuarios = ENUsuario.Obtener(padre.NumeroPagina, padre.TamañoPagina);
            }
            padre.CargarDatos(usuarios);
        }

        private void FormUsuarioBusqueda_Load(object sender, EventArgs e)
        {
            textBox_nombreUsuario.Text = "";
            textBox_email.Text = "";
            dateTimePicker_fechaIngreso.Value = DateTime.Now;
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_nombreUsuario.Text = "";
            textBox_email.Text = "";
            dateTimePicker_fechaIngreso.Value = DateTime.Now;
        }
    }
}
