﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cacatUA
{
    public partial class FormForoRespuestas : InterfazForm
    {
        public FormForoRespuestas()
        {
            InitializeComponent();
        }

        private void button_seccionCrear_Click(object sender, EventArgs e)
        {
            label_seccion1.Text = "Crear un nuevo hilo";
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
    }
}
