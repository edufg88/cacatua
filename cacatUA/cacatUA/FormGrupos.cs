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
            form.Size = new Size(900, 500);
            form.Show();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            FormGrupo form = new FormGrupo();
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.Size = new Size(900, 500);
            form.Show();
            form.Modificar();
        }

        private void checkBoxNumUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNumUsuario.Checked == true)
            {
                numericUpDownUsuarios1.Enabled = true;
                numericUpDownUsuarios2.Enabled = true;
            }
            else
            {
                numericUpDownUsuarios1.Enabled = false;
                numericUpDownUsuarios2.Enabled = false;
            }
        }

        private void checkBoxCreador_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCreador.Checked == true)
            {
                textBoxCreador.Enabled = true;
            }
            else
            {
                textBoxCreador.Enabled = false;
            }
        }

        private void checkBoxFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFecha.Checked == true)
            {
                dateTimePickerDesde.Enabled = true;
                dateTimePickerHasta.Enabled = true;
            }
            else
            {
                dateTimePickerDesde.Enabled = false;
                dateTimePickerHasta.Enabled = false;
            }
        }

    }
}
