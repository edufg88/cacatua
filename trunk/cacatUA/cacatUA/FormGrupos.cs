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
        /// <summary>
        /// Función para ver solo las opciones de búsqueda
        /// </summary>
        private void Busqueda()
        {
            label_seccion1.Text = "Búsqueda";
            tableLayoutPanel_secundario.RowStyles.Insert(0, new RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel_secundario.Controls[0].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(1, new RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            tableLayoutPanel_secundario.Controls[1].Visible = false;
            tableLayoutPanel_secundario.RowStyles.Insert(2, new RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel_secundario.Controls[2].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(3, new RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            tableLayoutPanel_secundario.Controls[3].Visible = false;
            tableLayoutPanel_secundario.RowStyles.Insert(4, new RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel_secundario.Controls[4].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(5, new RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel_secundario.Controls[5].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(6, new RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            tableLayoutPanel_secundario.Controls[6].Visible = false;
            panel_numUsuarioBuscar.Visible = true;
            label_numUsuarios.Text = "Nº Usuarios entre:";
            numericUpDown_numUsuarios1.Enabled = true;

            button_buscar.Enabled = true;
            button_seleccionar.Enabled = false;
            button_guardar.Enabled = false;
            button_eliminar.Enabled = false;
        }

        /// <summary>
        /// Función para ver solo las opciones de edición
        /// </summary>
        private void Edicion() 
        {
            label_seccion1.Text = "Edición";
            tableLayoutPanel_secundario.RowStyles.Insert(0, new RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            tableLayoutPanel_secundario.Controls[0].Visible = false;
            tableLayoutPanel_secundario.RowStyles.Insert(1, new RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel_secundario.Controls[1].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(2, new RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel_secundario.Controls[2].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(3, new RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            tableLayoutPanel_secundario.Controls[3].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(4, new RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel_secundario.Controls[4].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(5, new RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel_secundario.Controls[5].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(6, new RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            tableLayoutPanel_secundario.Controls[6].Visible = true;
            panel_numUsuarioBuscar.Visible = false;
            label_numUsuarios.Text = "Nº Usuarios:";
            numericUpDown_numUsuarios1.Enabled = false;

            button_buscar.Enabled = false;
            button_seleccionar.Enabled = false;
            button_guardar.Enabled = true;
            button_eliminar.Enabled = true;
        
        }


        private void button_seccionBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }

        private void button_seccionCrear_Click(object sender, EventArgs e)
        {
            Edicion();
        }

        private void button_eliminar_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection filas = dataGridView_grupos.SelectedRows;
            String mensaje;
            if (filas.Count > 0)
            {
                if (filas.Count > 1)
                {
                    mensaje = "¿Está seguro de que desea eliminar los grupos seleccionados?";
                }
                else
                {
                    mensaje = "¿Está seguro de que desea eliminar el grupo seleccionado?";
                }

                DialogResult resultado = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    for (int i = 0; i < filas.Count; i++)
                    {
                        // Obtenemos la fila
                        DataGridViewRow fila = filas[i];
                        // Eliminamos la fila
                        dataGridView_grupos.Rows.Remove(fila);
                    }
                }
            }
        }
    }
}
