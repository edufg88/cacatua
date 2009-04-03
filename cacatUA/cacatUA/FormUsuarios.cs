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
    public partial class FormUsuarios : UserControl
    {
        private FormUsuarioBusqueda formBusqueda;
        private FormUsuarioEdicion formEdicion;
        private bool ocultoP1;
        private bool ocultoP2;
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
            // Indican si los paneles están ocultos o no
            ocultoP1 = false;
            ocultoP2 = false;
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

        private void InsertarUsuariosPrueba()
        {
            for (int i = 0; i < 10; i++)
            {
                ENUsuario usuario = new ENUsuario("edu" + i.ToString(), i.ToString(), "edu" + i.ToString(), "1111111" + i.ToString(), "edu@prueba.com" + i.ToString(), false, "hola");
                usuario.CrearUsuario();
                //CrearUsuario(string usuario, string contrasena, string nombre, string dni, string correo, bool activo, string adicional)
            }
        }

        private void BorrarUsuariosPrueba()
        {
            ENUsuario usuario = new ENUsuario();
            usuario.BorrarUsuarios();
        }

        private void CargarUsuarios()
        {
            ENUsuario usuario = new ENUsuario();
            ArrayList al = new ArrayList();
            al = usuario.ObtenerUsuarios();

            dataGridView_usuarios.DataSource = al;
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
            BorrarUsuariosPrueba();
            InsertarUsuariosPrueba(); // Insertamos algunos usuarios
            CargarUsuarios();// Los cargamos en el DataGridView
        }

        private void button_ocultarP1_Click(object sender, EventArgs e)
        {
            label_seccion1.Text += " (Oculto)";
            if (!ocultoP1)
            {
                tableLayoutPanel_principal.RowStyles[3].Height = 0;
                ocultoP1 = true;
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

                ocultoP1 = false;
            }
        }

        private void button_ocultarP2_Click(object sender, EventArgs e)
        {
            label_seccion2.Text += " (Oculto)";
            if (!ocultoP2)
            {
                tableLayoutPanel_principal.RowStyles[5].Height = 0;
                ocultoP2 = true;
            }
            else
            {
                label_seccion2.Text = "Resultados de la búsqueda";
                tableLayoutPanel_principal.RowStyles[5].Height = panel_DataGridViewUsuarios.Height;
                ocultoP2 = false;
            }
        }
    }
}
