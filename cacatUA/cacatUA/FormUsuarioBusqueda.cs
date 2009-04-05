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
        private FormUsuarios padre;

        public FormUsuarioBusqueda(FormUsuarios padre)
        {
            InitializeComponent();

            this.padre = padre;
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            ArrayList usuarios;
            usuarios = ENUsuario.Buscar(textBox_nombreUsuario.Text, textBox_email.Text, dateTimePicker_fechaIngreso.Value);

            // Aquí tenemos que llevar el resultado al datagrid de formUsuario.
            padre.CargarDatos(usuarios);
        }

        private void FormUsuarioBusqueda_Load(object sender, EventArgs e)
        {
            textBox_nombreUsuario.Text = "";
            textBox_email.Text = "";
        }
    }
}
