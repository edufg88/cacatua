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

        private String bNombre = "";
        private String bEmail = "";
        private DateTime bFecha;

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
            bNombre = textBox_nombreUsuario.Text;
            bEmail = textBox_email.Text;
            bFecha = dateTimePicker_fechaIngreso.Value;
            BuscarUsuarios();
        }

        public void BuscarUsuarios()
        {
            ArrayList usuarios;
            if (bNombre != "" || bEmail != "")
            {
                padre.TotalBusqueda = ENUsuario.NumUsuarios(bNombre, bEmail,bFecha);
                padre.TotalPaginas = ((padre.TotalBusqueda - 1) / padre.TamañoPagina) + 1;
                usuarios = ENUsuario.Buscar(bNombre, bEmail, bFecha, padre.NumeroPagina, padre.TamañoPagina);
                    
            }
            else
            {
               padre.TotalBusqueda = ENUsuario.NumUsuarios();
               padre.TotalPaginas = ((padre.TotalBusqueda - 1) / padre.TamañoPagina) + 1;
               
               usuarios = ENUsuario.Obtener(padre.NumeroPagina, padre.TamañoPagina);
            }
            // Aquí tenemos que llevar el resultado al datagrid de formUsuario.
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
