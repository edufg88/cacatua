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
        private ENCategoriaCRUD categoria;
        private UserControl volver;

        public FormCategorias()
        {
            InitializeComponent();
        }

        public FormCategorias(ENCategoriaCRUD categoria, UserControl formVolver)
        {
            InitializeComponent();
            this.categoria = categoria;
            volver = formVolver;
            button_Volver.Visible = true;
        }

        private void treeViewCategorias_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBoxRaiz.Text = treeViewCategorias.SelectedNode.FullPath;
            button_Volver.Enabled = true;
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
