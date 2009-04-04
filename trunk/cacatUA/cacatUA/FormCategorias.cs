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
        private ENCategoria seleccionada;
        private ENCategoria buscada;
        private bool editar;
        private FormPanelAdministracion admin;

        public FormCategorias(FormPanelAdministracion admin)
        {
            this.admin = admin;
            InitializeComponent();
        }

        public FormCategorias(ENCategoria categoria, FormPanelAdministracion administracion)
        {
            InitializeComponent();

            devolverCategoria = categoria;
            admin = administracion;

            button_Seleccionar.Visible = true;
            button_Cancelar.Visible = true;
        }

        public void Vuelta()
        {
            MessageBox.Show("Has vuelto tras seleccionar la categoria: " + buscada.Id);
            seleccionada.Padre = buscada.Id;
            seleccionada.actualizar();
        }

        private void treeViewCategorias_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Obtenemos la instancia de la Categoria seleccionada
            seleccionada = ENCategoria.ObtenerCategoria(int.Parse(treeViewCategorias.SelectedNode.Name));

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
            if(devolverCategoria != null)
                devolverCategoria.Copiar(seleccionada);
            button_Seleccionar.Enabled = true;
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            //Resetear
            treeViewCategorias.Nodes.Clear();

            foreach (ENCategoria categoria in ENCategoria.CategoriasSuperiores())
            {
                MeterEnArbol(categoria, treeViewCategorias.Nodes);
            }
        }
        
        private void MeterEnArbol(ENCategoria cat, TreeNodeCollection coleccion) {
            TreeNode nodo = new TreeNode();
            nodo.Name = cat.Id.ToString();
            nodo.Text = cat.Nombre;
            nodo.Tag = cat.Descripcion;
            coleccion.Add(nodo);
            
            foreach (ENCategoria c in cat.obtenerHijos())
            {
                MeterEnArbol(c, nodo.Nodes);
            }
        }

        private void button_crearSubcategoria_Click(object sender, EventArgs e)
        {
            //Activar/Desactivar controles
            textBox_descripcion.ReadOnly = false;
            textBox_descripcion.Clear();
            textBox_Raiz.ReadOnly = false;
            textBox_Raiz.Clear();
            button_Guardar.Visible = true;
            button_noGuardar.Visible = true;
            checkBox_Superior.Visible = true;
            treeViewCategorias.Enabled = false;

            //Parametros
            editar = false;
        }

        private void button_editarCategoria_Click(object sender, EventArgs e)
        {
            //Activar/Desactivar controles
            textBox_descripcion.ReadOnly = false;
            textBox_Raiz.ReadOnly = false;
            button_Guardar.Visible = true;
            button_noGuardar.Visible = true;
            checkBox_Superior.Visible = true;
            button_Mover.Visible = true;
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
            button_Guardar.Visible = false;
            button_noGuardar.Visible = false;
            checkBox_Superior.Visible = false;
            button_Mover.Visible = false;
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
                if (seleccionada != null && !checkBox_Superior.Checked)
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
            button_Guardar.Visible = false;
            button_noGuardar.Visible = false;
            checkBox_Superior.Visible = false;
            button_Mover.Visible = false;
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

        private void button_Seleccionar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vas a devolver la categoria: " + devolverCategoria.Id);
            admin.volverCategoria();            
        }

        private void button_Mover_Click(object sender, EventArgs e)
        {
            buscada = new ENCategoria();
            admin.buscarCategoria(buscada, this);
        }

        private void FormCategorias_Paint(object sender, PaintEventArgs e)
        {
            MessageBox.Show("HOLA!");
        }

    }
}
