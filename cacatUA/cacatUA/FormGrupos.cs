using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cacatUA
{
    public partial class FormGrupos : UserControl
    {
        public FormGrupos()
        {
            InitializeComponent();
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonVer_Click(object sender, EventArgs e)
        {
            FormGrupo form = new FormGrupo();
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.Size = new Size(900, 550);
            form.Show();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            FormGrupo form = new FormGrupo();
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.Size = new Size(900, 550);
            form.Show();
            form.Modificar();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            FormGrupo form = new FormGrupo();
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.Size = new Size(900, 550);
            form.Show();
            form.Anadir();
        }
    }
}
