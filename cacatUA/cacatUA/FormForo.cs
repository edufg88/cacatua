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
        private FormForoEdicion formEdicion;
        private FormForoBusqueda formBusqueda;

        public FormForo()
        {
            InitializeComponent();

            // Se crean los formularios que se van a utilizar.
            formEdicion = new FormForoEdicion();
            formBusqueda = new FormForoBusqueda();
            formEdicion.Dock = DockStyle.Top;
            formBusqueda.Dock = DockStyle.Top;

            // Se oculta la fila del TableLayoutEditor que contiene el botón "Volver".
            tableLayoutPanel_principal.RowStyles[6].Height = 0;

            formularioBusqueda();

            anadirAlgunosHilos();
        }

        private void formularioBusqueda()
        {
            label_seccion1.Text = "Búsqueda";
            panel_contenedor.Controls.Clear();
            panel_contenedor.Controls.Add(formBusqueda);
            tableLayoutPanel_principal.RowStyles[3].Height = formBusqueda.Height;
        }

        private void formularioEdicion()
        {
            label_seccion1.Text = "Edición";
            panel_contenedor.Controls.Clear();
            panel_contenedor.Controls.Add(formEdicion);
            tableLayoutPanel_principal.RowStyles[3].Height = formEdicion.Height;
        }

        public void Limpiar()
        {

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

        private void button_seccionBuscar_Click(object sender, EventArgs e)
        {
            formularioBusqueda();
        }

        private void button_seccionCrear_Click(object sender, EventArgs e)
        {
            formularioEdicion();
        }

        private void dataGridView_resultados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /* FALTA CREAR LA CLASE ENHiloNoseque Y AÑADIR UN MÉTODO A FormForoEdicion QUE RECIBA UN OBJETO DE ESE TIPO.
             * DataGridViewRow filaSeleccionada = dataGridView_resultados.SelectedRows[0];
            formEdicion.textBox_id.Text = filaSeleccionada.Cells[0].Value.ToString();
            formEdicion.textBox_titulo.Text = filaSeleccionada.Cells[1].Value.ToString();
            formEdicion.textBox_texto.Text = filaSeleccionada.Cells[2].Value.ToString();
            formEdicion.textBox_autor.Text = filaSeleccionada.Cells[3].Value.ToString();
            //dateTimePicker_fecha.Text = filaSeleccionada.Cells[4].Value.ToString();
            formEdicion.textBox_respuestas.Text = filaSeleccionada.Cells[5].Value.ToString();*/

            formularioEdicion();
        }

        private void button_borrarHilo_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection filas = dataGridView_resultados.SelectedRows;
            if (DialogResult.Yes == MessageBox.Show("¿Está seguro de que desea borrar los hilos seleccionados?", "Ventana de confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
            {
                foreach (DataGridViewRow i in filas)
                {
                    // Borrarlo de la lista y borrarlo de la BD.
                    dataGridView_resultados.Rows.Remove(i);
                }
            }
        }

        private void butto_editarHilo_Click(object sender, EventArgs e)
        {
            formularioEdicion();
        }
    }
}
