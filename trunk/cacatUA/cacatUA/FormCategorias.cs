using System;
using System.Collections.Generic;
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
        private ENCategoria categoria;
        private UserControl volver;

        public FormCategorias()
        {
            InitializeComponent();
        }

        public FormCategorias(ENCategoriaCRUD categoria, UserControl formVolver)
        {
            this.categoria = categoria;
            volver = formVolver;
        }

        private void treeViewCategorias_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBoxRaiz.Text = treeViewCategorias.SelectedNode.FullPath;
        }

        private void button_verUsuario_Click(object sender, EventArgs e)
        {
            FormUsuario form = new FormUsuario();
            panel1.Controls.Clear();
            panel1.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        private void button_Hilos_Click(object sender, EventArgs e)
        {
            FormForo form = new FormForo();
            panel1.Controls.Clear();
            panel1.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        private void button_Materiales_Click(object sender, EventArgs e)
        {
            FormMateriales form = new FormMateriales();
            panel1.Controls.Clear();
            panel1.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }
    }
}
