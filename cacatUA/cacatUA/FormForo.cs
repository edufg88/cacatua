using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cacatUA
{
    public partial class FormForo : cacatUA.FormPanelAdministracion
    {
        public FormForo()
        {
            InitializeComponent();
        }

        private void bCrearHilo_Click(object sender, EventArgs e)
        {
            FormHilo form = new FormHilo();
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.Size = new Size(900, 500);
            form.Show();
        }
    }
}
