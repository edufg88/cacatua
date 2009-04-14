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
        private ENCategoria seleccionada;
        private ENCategoria enrutada;
        private TreeNode sel;

        //Indica en que estado se encuentra el formulario
        // 0 => Normal, navegando
        // 1 => Editando una categoria
        // 2 => Creando una categoria
        private int estado = 0;

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
            
            foreach (ENCategoria c in cat.ObtenerHijos())
            {
                MeterEnArbol(c, nodo.Nodes);
            }
        }

        private void treeViewCategorias_AfterSelect(object sender, TreeViewEventArgs e)
        {
            groupBox_Informacion.Enabled = true;
            if (estado == 0)
            {
                //Obtenemos la instancia de la Categoria seleccionada
                seleccionada = ENCategoria.Obtener(int.Parse(treeViewCategorias.SelectedNode.Name));

                //Llevar datos a los controles
                textBox_Nombre.Text = seleccionada.Nombre;
                textBox_Descripcion.Text = seleccionada.Descripcion;
                textBox_Ruta.Text = seleccionada.Ruta();
                textBox_nHilos.Text = seleccionada.NumHilos().ToString();
                textBox_nMateriales.Text = seleccionada.NumMateriales().ToString();

                dataGridView_Usuarios.Rows.Clear();
                foreach (ENUsuario u in seleccionada.UsuariosSuscritos())
                {
                    dataGridView_Usuarios.Rows.Add(u.Id, u.Usuario, u.Nombre);
                }

                sel = treeViewCategorias.SelectedNode;

            }
            else
            {
                //Obtenemos la instancia de la Categoria seleccionada
                enrutada = ENCategoria.Obtener(int.Parse(treeViewCategorias.SelectedNode.Name));
                textBox_Ruta.Text = enrutada.NombreCompleto();
            }
        }

        private void button_crearCategoria_Click(object sender, EventArgs e)
        {
            //Activar/Desactivar controles
            ActivarEdicion();

            //Limpiar controles
            textBox_Nombre.Clear();
            textBox_Descripcion.Clear();

            //Controles activados
            enrutada = seleccionada;
            textBox_Ruta.Text = enrutada.NombreCompleto().ToString();
            
            //Parametros
            estado = 2;
        }

        private void button_editarCategoria_Click(object sender, EventArgs e)
        {
            if (seleccionada == null)
            {
                MessageBox.Show("Debes seleccionar una categoria.", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (treeViewCategorias.SelectedNode.Level != 0)
                {
                    enrutada = ENCategoria.Obtener(int.Parse(treeViewCategorias.SelectedNode.Parent.Name));
                }

                //Activar/Desactivar controles
                ActivarEdicion();

                //Parametros
                estado = 1;
            }
        }

        private void button_borrarCategoria_Click(object sender, EventArgs e)
        {
            if (seleccionada == null)
            {
                MessageBox.Show("Debes seleccionar una categoria.", "Error al borrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("¿Está seguro de borrar esta categoria? (Se borraran los materiales e hilos asociados y las subcategorias)", "Confirmación de borrado.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    if (seleccionada.Borrar())
                    {
                        treeViewCategorias.Nodes.Remove(treeViewCategorias.SelectedNode);
                        MessageBox.Show("Categoria borrada correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al borrar categoria.");
                    }
                }
                textBox_Descripcion.Clear();
                textBox_Nombre.Clear();
                textBox_Ruta.Clear();
            }           
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {

            //Sea cual sea lo que estemos haciendo, el nombre no se puede dejar vacio
            if(textBox_Nombre.Text == "") {
                errorProvider_Categorias.SetError(textBox_Nombre, "Debes indicar un nombre");
            }
            else {
                //Comprobar accion a realizar
                if (estado == 1)
                {
                    bool validado = true;

                    //Actualizando
                    seleccionada.Nombre = textBox_Nombre.Text;
                    seleccionada.Descripcion = textBox_Descripcion.Text;

                    if (enrutada != null)
                    {
                        seleccionada.Padre = enrutada.Id;

                        if (enrutada.EsDescendienteDe(seleccionada) || enrutada.Id == seleccionada.Id)
                        {
                            MessageBox.Show("Error, go to bucle");
                            validado = false;
                        }
                    }

                    if (validado)
                    {
                        if (seleccionada.Actualizar())
                        {
                            MessageBox.Show("Categoria actualizada correctamente.");

                            sel.Text = seleccionada.Nombre;
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar categoria.");
                        }
                    }
                }
                else
                {
                    //Creando
                    int padre = 0;

                    //Crear objeto y almacenarlo en la BBDD
                    if (enrutada != null)
                    {
                        padre = enrutada.Id;
                    }


                    ENCategoria nCategoria = new ENCategoria(textBox_Nombre.Text, textBox_Descripcion.Text, padre);

                    if (nCategoria.Guardar())
                    {
                        MessageBox.Show("Categoria creada correctamente.");
                        
                        //Recargamos el arbol para que aparezca la nueva categoria
                        FormCategorias_Load(null,null);
                    }
                    else
                    {
                        MessageBox.Show("Error al crear categoria.");
                    }
                }
                //Activar/Desactivar controles
                DesactivarEdicion();

                enrutada = null;
                estado = 0;
            }
        }

        private void button_noGuardar_Click(object sender, EventArgs e)
        {
            //Activar/Desactivar controles
            DesactivarEdicion();

            enrutada = null;
            estado = 0;

            textBox_Descripcion.Text = seleccionada.Descripcion;
            textBox_Nombre.Text = seleccionada.Nombre;
            textBox_Ruta.Text = seleccionada.Ruta();
        }

        private void ActivarEdicion()
        {
            label_FuncionArbol.Text = "Seleccione una categoria para formar la ruta:";
            button_LimpiarRuta.Visible = true;

            textBox_Descripcion.ReadOnly = false;
            textBox_Nombre.ReadOnly = false;
            textBox_Ruta.BackColor = SystemColors.Window;
            button_Guardar.Visible = true;
            button_noGuardar.Visible = true;
        }
        
        private void DesactivarEdicion()
        {
            label_FuncionArbol.Text = "Seleccione una categoria para más informacion:";
            button_LimpiarRuta.Visible = false;
            errorProvider_Categorias.Clear();

            textBox_Descripcion.ReadOnly = true;
            textBox_Nombre.ReadOnly = true;
            textBox_Ruta.ReadOnly = true;
            textBox_Ruta.BackColor = SystemColors.Control;
            button_Guardar.Visible = false;
            button_noGuardar.Visible = false;
        }

        //Heredado de InterfazForm

        override public Object Enviar()
        {
            return seleccionada;
        }

        public override void Recibir(Object objeto)
        {
            if (objeto != null)
            {
                if (objeto is ENUsuario)
                {
                    if (seleccionada != null)
                    {
                        ENUsuario u = (ENUsuario)objeto;

                        seleccionada.SuscribirUsuario(u);
                        dataGridView_Usuarios.Rows.Add(u.Id, u.Usuario, u.Nombre);
                        
                    }
                }
            }
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

        private void linkLabel_verHilos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormForo(), "Viendo hilos", true, false, "Volver a las categorías", "");
        }

        private void button_verUsuario_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Viendo usuario", true, false, "Volver a las categorías", "");
        }

        private void button_AñadirUsuario_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, false, "Seleccionar usuario", "");
        }

        private void button_LimpiarRuta_Click(object sender, EventArgs e)
        {
            textBox_Ruta.Text = "";
            enrutada = new ENCategoria();
        }
    }
}
