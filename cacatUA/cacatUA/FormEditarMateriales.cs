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
    public partial class FormEditarMateriales : UserControl
    {

        public enum modos { EDITAR = 0, CREAR = 1, BORRAR = 2};
        public modos modo;
        public FormEditarMateriales(modos modo)
        {
            InitializeComponent();
            this.modo = modo;
            switch (modo)
            {
                case modos.CREAR:
                    {
                        button_accion.Text = "Crear";
                        break;
                    }
                case modos.EDITAR:
                    {
                        button_accion.Text = "Editar";
                        break;
                    }
                case modos.BORRAR:
                    {
                        button_accion.Text = "Borrar";
                        break;
                    }
            }
        }

        private void button_accion_Click(object sender, EventArgs e)
        {
            switch (modo)
            {
                case modos.CREAR:
                    {
                        // Creamos el nuevo material
                        ENMaterialCRUD material = new ENMaterialCRUD();
                        material.Nombre = textBox_nombre.Text.ToString();
                        material.Descripcion = richTextBox_descripcion.Text.ToString();

                        //material.Descripcion = "aaaaaa";
                        // Comprobamos que 
                        // Añadimos el material a la base de datos
                        material.crearMaterial();

                        break;
                    }
                case modos.EDITAR:
                    {
                        button_accion.Text = "Editar";
                        break;
                    }
                case modos.BORRAR:
                    {
                        button_accion.Text = "Borrar";
                        break;
                    }
            }
        }
    }
}
