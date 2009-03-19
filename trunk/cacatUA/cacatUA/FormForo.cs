using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace cacatUA
{
    public partial class FormForo : UserControl
    {
        public FormForo()
        {
            InitializeComponent();
            anadirAlgunosHilos();
        }

        private void anadirAlgunosHilos()
        {
            ArrayList lista = new ArrayList();
            String[] hilo1 = { "1235", "Asfgd f fgh fgh fgh", "As asd afiuiygjbn sd", "Eusebio", "2008", "87" };
            lista.Add(hilo1);
            String[] hilo2 = { "446", "Gfghfgkl kj lkf  bnmbnm hjk", "As asd asd askd alsdka sdlak sdlak skas dasd", "Alfredo", "2008", "87" };
            lista.Add(hilo2);
            String[] hilo3 = { "8867", "dfg gh yu m  nmbbn mbnmbdg nbbn", "ghjgjghjgh mnm   b bn bnd", "Maria", "2008", "87" };
            lista.Add(hilo3);
            String[] hilo4 = { "22", "¿ghfh fgh gh fgh fgh g fgfg ?", "As asd asd askd alsdka sdlak sdlak skas dasd", "Rodrigo", "2008", "87" };
            lista.Add(hilo4);
            String[] hilo5 = { "82", "sssaaqw  w ddffffkkj khjkff jku jhiuf fh", "As asd asd zzx zxzzxzxz xcv zx", "Andres", "2008", "87" };
            lista.Add(hilo5);
            for (int i = 0; i < lista.Count; i++)
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView_resultados);

                String[] h = (String[]) lista[i];
                fila.Cells[0].Value = h[0].ToString();
                fila.Cells[1].Value = h[1].ToString();
                fila.Cells[2].Value = h[2].ToString();
                fila.Cells[3].Value = h[3].ToString();
                fila.Cells[4].Value = h[4].ToString();
                fila.Cells[5].Value = h[5].ToString();
                dataGridView_resultados.Rows.Add(fila);
            }
        }

        private void button_anadirHilo_Click(object sender, EventArgs e)
        {
            FormHilo form = new FormHilo();
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            form.Show();
        }

        private void button_modificarHilo_Click(object sender, EventArgs e)
        {
            FormHilo form = new FormHilo();
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            // En este punto hay que pasarle el objeto del tipo Hilo que contiene los datos.
            form.Show();
        }

        private void button_seleccionarCategoria_Click(object sender, EventArgs e)
        {
            FormCategoria form = new FormCategoria();
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //int posX = button_Seleccionar_categoria.Location.X;
            //int posY = button_Seleccionar_categoria.Location.Y;
            //posX += this.ParentForm.Location.X;
            //posX += this.ParentForm.Location.Y;
            //form.Location = new Point(posX, posY);
            form.ShowDialog();
        }

        private void button_eliminarHilo_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection filas = dataGridView_resultados.SelectedRows;
            String mensaje;
            if (filas.Count > 1)
            {
                mensaje = "¿Está seguro de que desea eliminar los hilos seleccionados?";
            }
            else
            {
                mensaje = "¿Está seguro de que desea eliminar el hilo seleccionado?";
            }

            DialogResult resultado = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                for (int i = 0; i < filas.Count; i++)
                {
                    // Obtenemos la fila
                    DataGridViewRow fila = filas[i];
                    // Eliminamos la fila
                    dataGridView_resultados.Rows.Remove(fila);
                }
            }
        }

        private void button_seccionBuscar_Click(object sender, EventArgs e)
        {
            formularioBusqueda();
        }

        private void button_seccionCrear_Click(object sender, EventArgs e)
        {
            formularioEdicion();
        }

        private void formularioBusqueda()
        {
            label_seccion1.Text = "Búsqueda";
            tableLayoutPanel_secundario.RowStyles.Insert(0, new RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel_secundario.Controls[0].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(1, new RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            tableLayoutPanel_secundario.Controls[1].Visible = false;
            tableLayoutPanel_secundario.RowStyles.Insert(2, new RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel_secundario.Controls[2].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(3, new RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel_secundario.Controls[3].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(4, new RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            tableLayoutPanel_secundario.Controls[4].Visible = false;
            tableLayoutPanel_secundario.RowStyles.Insert(5, new RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            tableLayoutPanel_secundario.Controls[5].Visible = false;
            tableLayoutPanel_secundario.RowStyles.Insert(6, new RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel_secundario.Controls[6].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(7, new RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            tableLayoutPanel_secundario.Controls[7].Visible = false;

            button_buscar.Enabled = true;
            button_seleccionar.Enabled = false;
            button_guardar.Enabled = false;
            button_eliminar.Enabled = false;
        }

        private void formularioEdicion()
        {
            label_seccion1.Text = "Edición";
            tableLayoutPanel_secundario.RowStyles.Insert(0, new RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            tableLayoutPanel_secundario.Controls[0].Visible = false;
            tableLayoutPanel_secundario.RowStyles.Insert(1, new RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel_secundario.Controls[1].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(2, new RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel_secundario.Controls[2].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(3, new RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel_secundario.Controls[3].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(4, new RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            tableLayoutPanel_secundario.Controls[4].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(5, new RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel_secundario.Controls[5].Visible = true;
            tableLayoutPanel_secundario.RowStyles.Insert(6, new RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            tableLayoutPanel_secundario.Controls[6].Visible = false;
            tableLayoutPanel_secundario.RowStyles.Insert(7, new RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel_secundario.Controls[7].Visible = true;

            button_buscar.Enabled = false;
            button_seleccionar.Enabled = false;
            button_guardar.Enabled = true;
            button_eliminar.Enabled = true;
        }

        private void dataGridView_resultados_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow filaSeleccionada = dataGridView_resultados.SelectedRows[0];
            textBox_id.Text = filaSeleccionada.Cells[0].Value.ToString();
            textBox_titulo.Text = filaSeleccionada.Cells[1].Value.ToString();
            textBox_texto.Text = filaSeleccionada.Cells[2].Value.ToString();
            textBox_autor.Text = filaSeleccionada.Cells[3].Value.ToString();
            //dateTimePicker_fecha.Text = filaSeleccionada.Cells[4].Value.ToString();
            textBox_respuestas.Text = filaSeleccionada.Cells[5].Value.ToString();

            formularioEdicion();
        }
    }
}
