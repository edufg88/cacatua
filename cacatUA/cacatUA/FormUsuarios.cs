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
    public partial class FormUsuarios : InterfazForm
    {
        private FormUsuarioBusqueda formBusqueda;
        private FormUsuarioEdicion formEdicion;
        private ENUsuario usuarioSeleccionado;
        private bool ocultoP1;
        private bool ocultoP2;
        private int formulario; // 0 = formBusqueda, 1 = formEdicion;

        public FormUsuarios()
        {
            InitializeComponent();
            formBusqueda = new FormUsuarioBusqueda(this);
            formEdicion = new FormUsuarioEdicion(this);
            formEdicion.Dock = DockStyle.Top;
            formBusqueda.Dock = DockStyle.Top;

            usuarioSeleccionado = null;
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
                usuario.Guardar();                
            }
        }

        private void BorrarUsuariosPrueba()
        {
            ENUsuario usuario = new ENUsuario();
            usuario.BorrarUsuarios();
        }

        public void CargarUsuarios()
        {
            ArrayList al = new ArrayList();
            al = ENUsuario.Obtener();

            CargarDatos(al);
        }

        // Este método carga los datos en el DataGridView
        public void CargarDatos(ArrayList datos)
        {
            // Borramos los elementos previos
            dataGridView_usuarios.Rows.Clear();

            // Obtenemos todos los materiales que hay en la base de datos
            for (int i = 0; i < datos.Count; i++)
            {
                ENUsuario usuario = (ENUsuario)datos[i];
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView_usuarios);

                fila.Cells[0].Value = usuario.Id.ToString();
                fila.Cells[1].Value = usuario.Usuario.ToString();
                fila.Cells[2].Value = usuario.Contrasena.ToString();
                fila.Cells[3].Value = usuario.Nombre.ToString();
                fila.Cells[4].Value = usuario.Dni.ToString();
                fila.Cells[5].Value = usuario.Correo.ToString();
                fila.Cells[6].Value = usuario.Adicional.ToString();
                fila.Cells[7].Value = usuario.Fechaingreso.ToString();
                fila.Cells[8].Value = usuario.Activo.ToString();
                dataGridView_usuarios.Rows.Add(fila);
            }
        }

        override public Object Enviar()
        {
            return usuarioSeleccionado;
        }

        private void button_seccionBuscar_Click(object sender, EventArgs e)
        {
            // Cargamos el user control de busqueda
            CambiarFormularioBusqueda();
        }

        private void button_seccionCrear_Click(object sender, EventArgs e)
        {
            // Cargamos el user control de crear
            CambiarFormularioEdicion();
            formEdicion.CambiarNuevo();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CambiarFormularioBusqueda();
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
                dataGridView_usuarios.Hide();
                button_borrarUsuario.Hide();
                button_editarUsuario.Hide();
                tableLayoutPanel_principal.RowStyles[5].Height = 0;
                ocultoP2 = true;
            }
            else
            {
                dataGridView_usuarios.Show();
                label_seccion2.Text = "Resultados de la búsqueda";
                tableLayoutPanel_principal.RowStyles[5].Height = panel_DataGridViewUsuarios.Height;
                ocultoP2 = false;
            }
        }

        private void dataGridView_usuarios_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {   
            CambiarFormularioEdicion();
            // Cargamos los datos en el formulario
            formEdicion.CambiarSeleccionado(int.Parse(dataGridView_usuarios.SelectedRows[0].Cells[0].Value.ToString()));
            usuarioSeleccionado.Obtener(int.Parse(dataGridView_usuarios.SelectedRows[0].Cells[0].Value.ToString()));
        }

        private void button_editarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridView_usuarios.SelectedRows.Count > 0)
            {
                CambiarFormularioEdicion();
                formEdicion.CambiarSeleccionado(int.Parse(dataGridView_usuarios.SelectedRows[0].Cells[0].Value.ToString()));
                usuarioSeleccionado.Obtener(int.Parse(dataGridView_usuarios.SelectedRows[0].Cells[0].Value.ToString()));
            }
        }

        private void button_borrarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridView_usuarios.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection filas = dataGridView_usuarios.SelectedRows;
                if (DialogResult.Yes == MessageBox.Show("¿Está seguro de que desea borrar los usuarios seleccionados?", "Ventana de confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    foreach (DataGridViewRow i in filas)
                    {
                        // Se borra de la lista y de la base de datos.
                        ENUsuario.Borrar(int.Parse(i.Cells[0].Value.ToString()));
                        dataGridView_usuarios.Rows.Remove(i);
                    }
                }
            }

            formEdicion.CambiarNuevo();
        }

    }
}
