using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cacatUA
{
    public partial class FormUsuarios : UserControl
    {
        private FormUsuarioBusqueda formBusqueda;
        private FormUsuarioEdicion formEdicion;
        private bool oculto;
        private int formulario; // 0 = formBusqueda, 1 = formEdicion;

        public FormUsuarios()
        {
            InitializeComponent();
            formBusqueda = new FormUsuarioBusqueda();
            formEdicion = new FormUsuarioEdicion();
            formEdicion.Dock = DockStyle.Top;
            formBusqueda.Dock = DockStyle.Top;

            // Se oculta la fila del TableLayoutEditor que contiene el botón "Volver".
            tableLayoutPanel_principal.RowStyles[6].Height = 0;

            formulario = 0;
            oculto = false;
        }

        public void CambiarFormularioBusqueda()
        {
            label_seccion1.Text = "Búsqueda";
            panel_contenedor.Controls.Clear();
            panel_contenedor.Controls.Add(formBusqueda);
            tableLayoutPanel_principal.RowStyles[3].Height = formBusqueda.Height;
            // Marcamos el formulario activo
            formulario = 0;
        }

        public void CambiarFormularioEdicion()
        {
            label_seccion1.Text = "Edición";
            panel_contenedor.Controls.Clear();
            panel_contenedor.Controls.Add(formEdicion);
            tableLayoutPanel_principal.RowStyles[3].Height = formEdicion.Height;
            // Marcamos el formulario activo
            formulario = 1;
        }

        private void button_seccionBuscar_Click(object sender, EventArgs e)
        {
            // Cargamos el user control de busqueda
            CambiarFormularioBusqueda();
        }

        private void button_seccionCrear_Click(object sender, EventArgs e)
        {
            // Cargamso el user control de crear
            CambiarFormularioEdicion();
            //formEdicion.formularioVacio();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CambiarFormularioBusqueda();
        }

        private void button_ocultar_Click(object sender, EventArgs e)
        {
            label_seccion1.Text += " (Oculto)";
            if (!oculto)
            {
                tableLayoutPanel_principal.RowStyles[3].Height = 0;
                oculto = true;
            }
            else
            {
                switch (formulario)
                { 
                    case 0:
                        label_seccion1.Text = "Búsqueda";
                        tableLayoutPanel_principal.RowStyles[3].Height = formBusqueda.Height;
                        break;
                    case 1:
                        label_seccion1.Text = "Edición";
                        tableLayoutPanel_principal.RowStyles[3].Height = formEdicion.Height;
                        break;
                }

                oculto = false;
            }
        }


    }
}
