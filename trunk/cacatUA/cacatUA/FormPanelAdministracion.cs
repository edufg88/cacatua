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
            form.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            form.Location = new Point(this.Location.X, this.Location.Y);
            form.Size = new Size(this.Size.Width, this.Size.Height);
            form.Show();
            this.Hide(); 
        }

        private void button_foro_Click(object sender, EventArgs e)
        {
            FormForo form = new FormForo();
            form.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            form.Location = new Point(this.Location.X, this.Location.Y);
            form.Size = new Size(this.Size.Width, this.Size.Height);
            form.Show();
            this.Hide(); 
        }

        private void button_peticiones_Click(object sender, EventArgs e)
        {
            FormPeticiones form = new FormPeticiones();
            form.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            form.Location = new Point(this.Location.X, this.Location.Y);
            form.Size = new Size(this.Size.Width, this.Size.Height);
            form.Show();
            this.Hide(); 
        }

        private void button_grupos_Click(object sender, EventArgs e)
        {
            FormGrupos form = new FormGrupos();
            form.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            form.Location = new Point(this.Location.X, this.Location.Y);
            form.Size = new Size(this.Size.Width, this.Size.Height);
            form.Show();
            this.Hide(); 
        }

        private void button_materiales_Click(object sender, EventArgs e)
        {
            FormMateriales form = new FormMateriales();
            form.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            form.Location = new Point(this.Location.X, this.Location.Y);
            form.Size = new Size(this.Size.Width, this.Size.Height);
            form.Show();
            this.Hide();
        }

        private void button_general_Click(object sender, EventArgs e)
        {
            FormGeneral form = new FormGeneral();
            form.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            form.Location = new Point(this.Location.X, this.Location.Y);
            form.Size = new Size(this.Size.Width, this.Size.Height);
            form.Show();
            this.Hide(); 
        }

        private void button_categorias_Click(object sender, EventArgs e)
        {
            FormCategorias form = new FormCategorias();
            form.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            form.Location = new Point(this.Location.X, this.Location.Y);
            form.Size = new Size(this.Size.Width, this.Size.Height);
            form.Show();
            this.Hide(); 
        }

        private void FormPanelAdministracion_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }
    }
}
