using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Libreria;

namespace cacatUA
{
    public partial class FormGruposEdicion : UserControl
    {
        public FormGruposEdicion()
        {
            InitializeComponent();
        }

        public void Nuevo()
        {
            ENGruposCRUD grupo;
            grupo = null;
            textBox_nombre.Text = "";
            textBox_id.Text = "";
            textBox_descripcion.Text = "";
            numericUpDown_numUsuarios1.Value = 0;
            listBox_usuarios.Items.Clear();
        }

        public void Editar(int id)
        {
            ENGruposCRUD grupo = new ENGruposCRUD(id);
            textBox_nombre.Text = grupo.Nombre;
            textBox_id.Text = grupo.Id.ToString();
            textBox_descripcion.Text = grupo.Descripcion;
            dateTimePicker_fecha.Value = grupo.Fecha;
            numericUpDown_numUsuarios1.Value = grupo.NumUsuarios;
            /*foreach (object ob in grupo.Usuarios)
            {
                listBox_usuarios.Items.Add(ob);
            }*/
        }

        private void linkLabel_usuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button_eliminar_Click(object sender, EventArgs e)
        {
            
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            ArrayList usuarios=new ArrayList();
            if (listBox_usuarios.Items.Count != 0)
            {
                foreach (object ob in listBox_usuarios.Items)
                {
                    usuarios.Add(ob);
                }
            }
            ENGruposCRUD grupo = new ENGruposCRUD(textBox_nombre.Text,textBox_descripcion.Text,dateTimePicker_fecha.Value,usuarios);
            
            if (grupo.crearGrupo())
            {
                MessageBox.Show("Grupo creado correctamente");
            }
            else
            {
                MessageBox.Show("Error al crear elgrupo");
            }
        }
    }
}
