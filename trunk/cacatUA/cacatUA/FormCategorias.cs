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
        private int idSeleccionada;

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
            idSeleccionada = int.Parse(treeViewCategorias.SelectedNode.Name);

            ENCategoriaCRUD seleccionada = CategoriaCAD.obtenerCategoria(idSeleccionada);
            textBox_nHilos.Text = seleccionada.NumHilos().ToString();
            textBox_nMateriales.Text = seleccionada.NumMateriales().ToString();

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
                MeterEnArbol(categoria, cacatua);
            }
        }
        
        private void MeterEnArbol(ENCategoriaCRUD cat, TreeNode padre) {
            TreeNode nodo = new TreeNode();
            nodo.Name = cat.Id.ToString();
            nodo.Text = cat.Nombre;
            nodo.Tag = cat.Descripcion;
            padre.Nodes.Add(nodo);
            
            foreach (ENCategoriaCRUD c in cat.obtenerHijos())
            {
                MeterEnArbol(c, nodo);
            }
        }

        private void button_crearSubcategoria_Click(object sender, EventArgs e)
        {
            //Activar controles
            textBox_descripcion.ReadOnly = false;
            textBox_descripcion.Clear();
            textBox_Raiz.ReadOnly = false;
            textBox_Raiz.Clear();
            button_Guardar.Enabled = true;
            button_noGuardar.Enabled = true;
        }

        private void button_noGuardar_Click(object sender, EventArgs e)
        {
            //Desactivar controles
            textBox_descripcion.ReadOnly = true;
            textBox_descripcion.Clear();
            textBox_Raiz.ReadOnly = true;
            textBox_Raiz.Clear();
            button_Guardar.Enabled = false;
            button_noGuardar.Enabled = false;

            //Pasar el foco al arbol
            treeViewCategorias.Focus();
        }
    }
}
