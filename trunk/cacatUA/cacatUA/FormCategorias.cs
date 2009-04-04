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

    public partial class FormCategorias : UserControl
    {
        private ENCategoria devolverCategoria;
        private UserControl volver;
        private ENCategoria seleccionada;
        private bool editar;

        public FormCategorias()
        {
            InitializeComponent();
        }

        public FormCategorias(ENCategoria categoria, UserControl formVolver)
        {
            InitializeComponent();
            this.devolverCategoria = categoria;
            volver = formVolver;

            button_Seleccionar.Visible = true;
            button_Cancelar.Visible = true;
        }

        private void treeViewCategorias_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Obtenemos la instancia de la Categoria seleccionada
            seleccionada = CategoriaCAD.obtenerCategoria(int.Parse(treeViewCategorias.SelectedNode.Name));

            //Llevar datos a los controles
            textBox_Raiz.Text = treeViewCategorias.SelectedNode.FullPath;
            textBox_descripcion.Text = treeViewCategorias.SelectedNode.Tag.ToString();
            textBox_nHilos.Text = seleccionada.NumHilos().ToString();
            textBox_nMateriales.Text = seleccionada.NumMateriales().ToString();

            listBox_usuarios.Items.Clear();
            foreach (String u in seleccionada.usuariosSuscritos())
            {
                listBox_usuarios.Items.Add(u);
            }

            //Opcion de volver
            devolverCategoria = seleccionada;
            button_Seleccionar.Enabled = true;
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            //Resetear
            treeViewCategorias.Nodes.Clear();
            seleccionada = null;

            TreeNode cacatua = new TreeNode();
            cacatua.Name = "0";
            cacatua.Text = "CacatUA";
            cacatua.Tag = "Categoria general.";
            treeViewCategorias.Nodes.Add(cacatua);


            foreach (ENCategoria categoria in CategoriaCAD.obtenerCategoriasSuperiores())
            {
                MeterEnArbol(categoria, cacatua);
            }
        }
        
        private void MeterEnArbol(ENCategoria cat, TreeNode padre) {
            TreeNode nodo = new TreeNode();
            nodo.Name = cat.Id.ToString();
            nodo.Text = cat.Nombre;
            nodo.Tag = cat.Descripcion;
            padre.Nodes.Add(nodo);
            
            foreach (ENCategoria c in cat.obtenerHijos())
            {
                MeterEnArbol(c, nodo);
            }
        }

        private void button_crearSubcategoria_Click(object sender, EventArgs e)
        {
            //Activar/Desactivar controles
            textBox_descripcion.ReadOnly = false;
            textBox_descripcion.Clear();
            textBox_Raiz.ReadOnly = false;
            textBox_Raiz.Clear();
            button_Guardar.Enabled = true;
            button_noGuardar.Enabled = true;
            treeViewCategorias.Enabled = false;

            //Parametros
            editar = false;
        }

        private void button_editarCategoria_Click(object sender, EventArgs e)
        {
            //Activar/Desactivar controles
            textBox_descripcion.ReadOnly = false;
            textBox_Raiz.ReadOnly = false;
            button_Guardar.Enabled = true;
            button_noGuardar.Enabled = true;
            treeViewCategorias.Enabled = false;

            //Quitar la ruta al nombre
            textBox_Raiz.Text = seleccionada.Nombre;

            //Parametros
            editar = true;
        }

        private void button_borrarCategoria_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de borrar esta categoria? (Se borraran los materiales e hilos asociados)", "Confirmación de borrado.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (seleccionada.borrar())
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

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            //Activar/Desactivar controles
            textBox_descripcion.ReadOnly = true;
            textBox_Raiz.ReadOnly = true;
            button_Guardar.Enabled = false;
            button_noGuardar.Enabled = false;
            treeViewCategorias.Enabled = true;

            //Comprobar accion a realizar
            if (editar == true)
            {
                //Actualizar
                seleccionada.Nombre = textBox_Raiz.Text;
                seleccionada.Descripcion = textBox_descripcion.Text;
                
                if (seleccionada.actualizar())
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
                if (seleccionada != null)
                {     
                    padre = seleccionada.Id;
                }

                ENCategoria nCategoria = new ENCategoria(0, textBox_Raiz.Text, textBox_descripcion.Text, padre);

                if (nCategoria.crear())
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
            textBox_descripcion.ReadOnly = true;
            textBox_Raiz.ReadOnly = true;
            button_Guardar.Enabled = false;
            button_noGuardar.Enabled = false;
            treeViewCategorias.Enabled = true;

            if (!editar)
            {
                textBox_descripcion.Clear();
                textBox_Raiz.Clear();
            }

            //Pasar el foco al arbol
            treeViewCategorias.Focus();
        }

        private void button_verUsuario_Click(object sender, EventArgs e)
        {
        }

        private void button_Hilos_Click(object sender, EventArgs e)
        {
        }

        private void button_Materiales_Click(object sender, EventArgs e)
        {
        }
    }
}
