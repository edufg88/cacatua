using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cacatUA
{
    public partial class FormPanelAdministracion : Form
    {
        public FormPanelAdministracion()
        {
            InitializeComponent();
        }

        private void button_usuarios_Click(object sender, EventArgs e)
        {
            FormUsuarios form = new FormUsuarios();
            panel1.Controls.Clear();
            panel1.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        private void button_foro_Click(object sender, EventArgs e)
        {
            FormForo form = new FormForo();
            panel1.Controls.Clear();
            panel1.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        private void button_peticiones_Click(object sender, EventArgs e)
        {
            FormPeticiones form = new FormPeticiones();
            panel1.Controls.Clear();
            panel1.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        private void button_grupos_Click(object sender, EventArgs e)
        {
            FormGrupos form = new FormGrupos();
            panel1.Controls.Clear();
            panel1.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        private void button_materiales_Click(object sender, EventArgs e)
        {
            FormMateriales form = new FormMateriales();
            panel1.Controls.Clear();
            panel1.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        private void button_general_Click(object sender, EventArgs e)
        {
            FormGeneral form = new FormGeneral();
            panel1.Controls.Clear();
            panel1.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        private void button_categorias_Click(object sender, EventArgs e)
        {
            FormCategorias form = new FormCategorias();
            panel1.Controls.Clear();
            panel1.Controls.Add(form);
            form.Dock = DockStyle.Fill;
        }

        private void FormPanelAdministracion_Load(object sender, EventArgs e)
        {
          //  this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
