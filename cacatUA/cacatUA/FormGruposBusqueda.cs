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
    public partial class FormGruposBusqueda : UserControl
    {
        private FormGrupos formularioPadre = null;
        public FormGruposBusqueda(FormGrupos formularioPadre)
        {
            this.formularioPadre = formularioPadre;
            InitializeComponent();
        }

        public void inicio()
        {
            textBox_filtroBusqueda.Text = "";
            textBox_usuario.Text = "";
            numericUpDown_numUsuarios1.Value = 0;
            numericUpDown_numUsuarios2.Value = 0;
            DateTime inicio = new DateTime(2006, 01, 01);
            dateTimePicker_fecha.Value = inicio;
            dateTimePicker_hasta.Value = DateTime.Now;


        }
        private bool ValidarFormulario()
        {
            string errorFecha="";
            string errorNum="";
            string errorUsuario="";
            bool correcto = true;

            if (numericUpDown_numUsuarios1.Value > numericUpDown_numUsuarios2.Value)
            {
                errorNum = "El primer valor de usuarios debe ser menor que el segundo";
                correcto = false;
            }
            if (dateTimePicker_fecha.Value > dateTimePicker_hasta.Value)
            {
                errorFecha = "La primera fecha tiene que ser menor que la segunda";
                correcto = false;
            }
            if (textBox_usuario.Text != "")
            {
                ENUsuario usuario = ENUsuario.Obtener(textBox_usuario.Text);
                if (usuario.Id == 0)
                {
                    correcto = false;
                    errorUsuario = "Este usuario no existe.";
                }
            }

            errorProvider1.SetError(dateTimePicker_fecha, errorFecha);
            errorProvider1.SetError(numericUpDown_numUsuarios1, errorNum);
            errorProvider1.SetError(textBox_usuario, errorUsuario);

            return correcto;
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                int a = int.Parse(numericUpDown_numUsuarios1.Value.ToString());
                int b = int.Parse(numericUpDown_numUsuarios2.Value.ToString());
                ENUsuario usuario = null;
                if (textBox_usuario.Text != "")
                {
                    usuario = ENUsuario.Obtener(textBox_usuario.Text);
                }
                ENGrupos grupo = new ENGrupos(textBox_filtroBusqueda.Text, textBox_usuario.Text, dateTimePicker_fecha.Value);
                formularioPadre.Resultado = grupo.Buscar(a, b,dateTimePicker_hasta.Value,ref usuario);
            }
        }

        private void button_seleccionarUsuario_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, true, "Volver al panel anterior seleccionando el usuario actual", "Cancelar la selección y volver al panel anterior");
        }
    }
}
