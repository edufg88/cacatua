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
        private ENCategoriaCRUD categoria;
        private UserControl volver;
        private CategoriaCAD seleccionada;

        public FormCategorias()
        {
            InitializeComponent();
        }

        public FormCategorias(ENCategoriaCRUD categoria, UserControl formVolver)
        {
            InitializeComponent();
            this.categoria = categoria;
            volver = formVolver;

            button_Seleccionar.Visible = true;
            button_Cancelar.Visible = true;
        }

        private void treeViewCategorias_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBox_Raiz.Text = treeViewCategorias.SelectedNode.FullPath;
            textBox_descripcion.Text = treeViewCategorias.SelectedNode.Tag.ToString();
            //seleccionada = int.Parse(treeViewCategorias.SelectedNode.Name);

            button_Seleccionar.Enabled = true;
        }

        private void button_verUsuario_Click(object sender, EventArgs e)
        {
            /*FormUsuario form = new FormUsuario();
            panel1.Controls.Clear();
            panel1.Controls.Add(form);
            form.Dock = DockStyle.Fill;*/
        }

        private void button_Hilos_Click(object sender, EventArgs e)
        {
            FormForo form = new FormForo();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        private void button_Materiales_Click(object sender, EventArgs e)
        {
            FormMateriales form = new FormMateriales();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            TreeNode cacatua = new TreeNode();
            cacatua.Name = "0";
            cacatua.Text = "CacatUA";
            cacatua.Tag = "Categoria general.";
            treeViewCategorias.Nodes.Add(cacatua);


            foreach (ENCategoriaCRUD categoria in CategoriaCAD.obtenerCategoriasSuperiores())
            {
                TreeNode nodo = new TreeNode();
                nodo.Name = categoria.Id.ToString();
                nodo.Text = categoria.Nombre;
                nodo.Tag = categoria.Descripcion;

                treeViewCategorias.Nodes.Add(nodo);
            }
        }

        private void button_crearSubcategoria_Click(object sender, EventArgs e)
        {
            textBox_descripcion.ReadOnly = false;
            textBox_descripcion.Clear();
            textBox_Raiz.ReadOnly = false;
            textBox_Raiz.Clear();
                
        }
    }
}
