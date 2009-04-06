using System;
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

    public partial class FormCategorias : InterfazForm
    {
        private ENCategoria seleccionada = new ENCategoria();
        private bool editar;

        public FormCategorias()
        {
            InitializeComponent();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            //Resetear
            treeViewCategorias.Nodes.Clear();

            foreach (ENCategoria categoria in ENCategoria.CategoriasSuperiores())
            {
                MeterEnArbol(categoria, treeViewCategorias.Nodes);
            }

            textBox_Descripcion.Clear();
            textBox_Nombre.Clear();

        }
        
        private void MeterEnArbol(ENCategoria cat, TreeNodeCollection coleccion) {
            TreeNode nodo = new TreeNode();
            nodo.Name = cat.Id.ToString();
            nodo.Text = cat.Nombre;
            coleccion.Add(nodo);
            
            foreach (ENCategoria c in cat.obtenerHijos())
            {
                MeterEnArbol(c, nodo.Nodes);
            }
        }

        private void treeViewCategorias_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Obtenemos la instancia de la Categoria seleccionada
            seleccionada.Obtener(int.Parse(treeViewCategorias.SelectedNode.Name));

            //Llevar datos a los controles
            textBox_Nombre.Text = seleccionada.Nombre;
            textBox_Descripcion.Text = seleccionada.Descripcion;
            textBox_Ruta.Text = seleccionada.Ruta();
            textBox_nHilos.Text = seleccionada.NumHilos().ToString();
            textBox_nMateriales.Text = seleccionada.NumMateriales().ToString();

            dataGridView_Usuarios.Rows.Clear();
            foreach (ENUsuario u in seleccionada.usuariosSuscritos())
            {
                dataGridView_Usuarios.Rows.Add(u.Id, u.Usuario);
            }
        }

        private void button_crearCategoria_Click(object sender, EventArgs e)
        {
            //Activar/Desactivar controles
            ActivarEdicion();

            //Parametros
            editar = false;
        }

        private void button_editarCategoria_Click(object sender, EventArgs e)
        {
            if (!seleccionada.Instanciada())
            {
                MessageBox.Show("Debes seleccionar una categoria.", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Activar/Desactivar controles
                ActivarEdicion();

                //Quitar la ruta al nombre
                textBox_Nombre.Text = seleccionada.Nombre;

                //Parametros
                editar = true;
            }
        }

        private void button_borrarCategoria_Click(object sender, EventArgs e)
        {
            if (!seleccionada.Instanciada())
            {
                MessageBox.Show("Debes seleccionar una categoria.", "Error al borrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("¿Está seguro de borrar esta categoria? (Se borraran los materiales e hilos asociados y las subcategorias)", "Confirmación de borrado.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    if (seleccionada.Borrar())
                    {
                        MessageBox.Show("Categoria borrada correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al borrar categoria.");
                    }
                }
                FormCategorias_Load(sender, e);
            }           
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            //Activar/Desactivar controles
            DesactivarEdicion();

            //Comprobar accion a realizar
            if (editar == true)
            {
                //Actualizar
                seleccionada.Nombre = textBox_Nombre.Text;
                seleccionada.Descripcion = textBox_Descripcion.Text;
                
                if (seleccionada.Actualizar())
                {
                    MessageBox.Show("Categoria actualizada correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al actualizar categoria.");
                }
            }
            else
            {
                int padre = 0;

                //Crear objeto y almacenarlo en la BBDD
                if (!seleccionada.Instanciada())
                {     
                    padre = seleccionada.Id;
                }

                ENCategoria nCategoria = new ENCategoria(0, textBox_Nombre.Text, textBox_Descripcion.Text, padre);

                if (nCategoria.Guardar())
                {
                    MessageBox.Show("Categoria creada correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al crear categoria.");
                }
            }

            FormCategorias_Load(sender, e);
        }

        private void button_noGuardar_Click(object sender, EventArgs e)
        {
            //Activar/Desactivar controles
            DesactivarEdicion();

            if (!editar)
            {
                textBox_Descripcion.Clear();
                textBox_Nombre.Clear();
            }

            //Pasar el foco al arbol
            treeViewCategorias.Focus();
        }

        private void button_Hilos_Click(object sender, EventArgs e)
        {
        }

        private void button_Materiales_Click(object sender, EventArgs e)
        {
        }

        private void button_verUsuario_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Viendo usuario.", true, true);
        }

        private void ActivarEdicion()
        {
            textBox_Descripcion.ReadOnly = false;
            textBox_Nombre.ReadOnly = false;
            textBox_Ruta.ReadOnly = false;
            button_Guardar.Visible = true;
            button_noGuardar.Visible = true;
            button_seleccionarCategoria.Visible = true;
            treeViewCategorias.Enabled = false;
        }

        private void DesactivarEdicion()
        {
            textBox_Descripcion.ReadOnly = true;
            textBox_Nombre.ReadOnly = true;
            textBox_Ruta.ReadOnly = true;
            button_Guardar.Visible = false;
            button_noGuardar.Visible = false;
            button_seleccionarCategoria.Visible = false;
            treeViewCategorias.Enabled = true;
        }

        //Heredado de InterfazForm

        override public Object Enviar()
        {
            if (seleccionada.Instanciada())
                return seleccionada;
            else
                return null;
        }

        public override void Recibir(Object objeto)
        {
        }

        private void button_quitarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridView_Usuarios.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection filas = dataGridView_Usuarios.SelectedRows;
                if (DialogResult.Yes == MessageBox.Show("¿Está seguro de que desea dessuscribir estos usuarios?", "Ventana de confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    foreach (DataGridViewRow i in filas)
                    {
                        // Se borra de la lista y de la base de datos.
                        ENUsuario usuario = new ENUsuario(int.Parse(i.Cells[0].Value.ToString()));
                        seleccionada.DessuscribirUsuario(usuario);
                        dataGridView_Usuarios.Rows.Remove(i);
                    }
                }
            }
        }
    }
}
