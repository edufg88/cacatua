﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cacatUA
{
    public partial class FormMateriales : UserControl
    {
        public FormMateriales()
        {
            InitializeComponent();
            /*
            // Inicializamos las secciones
            comboBox_seccion.Items.Add("Ingeniería Informática");
            // Inicializamos las categorías
            comboBox_categoria.Items.Add("Primer Curso");
            comboBox_categoria.Items.Add("Segundo Curso");
            comboBox_categoria.Items.Add("Tercer Curso");
            comboBox_categoria.Items.Add("Cuarto Curso");
            comboBox_categoria.Items.Add("Quinto Curso");
            // Inicializamos las subcategorías
            comboBox_subcategoria.Items.Add("Algebra");
            comboBox_subcategoria.Items.Add("Informática Básica");
            comboBox_subcategoria.Items.Add("Matemática discreta");
            comboBox_subcategoria.Items.Add("Fundamentos de programación I");
            comboBox_subcategoria.Items.Add("Fundamentos de programación II");
             */
            comboBox_tipoBusqueda.SelectedIndex = 0;
            comboBox_fecha.SelectedIndex = 0;    
            comboBox_unidad.SelectedIndex = 1;
            comboBox_idioma.SelectedIndex = 0;
            comboBox_valoracion.SelectedIndex = 0;
            // Añadimos unos cuantos materiales
            crearMateriales();
        }

        private void crearMateriales()
        {
            for (int i = 0; i < 10; i++)
            {
                string nombre = "material" + i.ToString();
                string descripcion = "descripcion material " + i.ToString();
                string añadido = "01/01/2009";
                string valoracion = "5";
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView1);
                fila.Cells[0].Value = nombre;
                fila.Cells[1].Value = descripcion;
                fila.Cells[2].Value = añadido;
                fila.Cells[3].Value = valoracion;
                dataGridViewMateriales.Rows.Add(fila);
            }
        }

        private void button_añadirMaterial_Click(object sender, EventArgs e)
        {
            FormMaterial form = new FormMaterial();
            form.setModo(FormMaterial.modos.NUEVO);
            form.Show();
        }

        private void butto_editarMaterial_Click(object sender, EventArgs e)
        {
            FormMaterial form = new FormMaterial();
            form.setModo(FormMaterial.modos.EDITAR);
            form.Show();
        }

        private void button_borrarMaterial_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro que deseas eliminar esos materiales?","Confirmación",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                // Obtenemos todas las filas seleccionada
                DataGridViewSelectedRowCollection filas = dataGridViewMateriales.SelectedRows;
                for (int i = 0; i < filas.Count; i++)
                {
                    // Obtenemos la fila
                    DataGridViewRow fila = filas[i];
                    // Eliminamos la fila
                    dataGridViewMateriales.Rows.Remove(fila);
                }
            }
        }

        private void button_buscarCategoria_Click(object sender, EventArgs e)
        {
            FormCategoria form = new FormCategoria();
            //form.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            //form.Location = new Point(button_buscarCategoria.Location.X, button_buscarCategoria.Location.Y);
            form.ShowDialog();
        }
    }
}