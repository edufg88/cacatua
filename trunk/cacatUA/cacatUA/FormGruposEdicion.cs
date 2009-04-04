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
            textBox_nombre.Text = "";
            textBox_id.Text = "";
            textBox_descripcion.Text = "";
            dateTimePicker_fecha.Value = DateTime.Now;
            numericUpDown_numUsuarios1.Value = 0;
            listBox_usuarios.Items.Clear();
        }

        public void Editar(int id)
        {
            listBox_usuarios.Items.Clear();
            ENGrupos grupo = new ENGrupos(id);
            textBox_nombre.Text = grupo.Nombre;
            textBox_id.Text = grupo.Id.ToString();
            textBox_descripcion.Text = grupo.Descripcion;
            dateTimePicker_fecha.Value = grupo.Fecha;
            numericUpDown_numUsuarios1.Value = grupo.NumUsuarios;
            foreach (ENUsuario ob in grupo.Usuarios)
            {
                listBox_usuarios.Items.Add(ob.Usuario);
            }
        }

        private void linkLabel_usuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            ArrayList usuarios = new ArrayList();
            if (listBox_usuarios.Items.Count != 0)
            {
                foreach (Object ob in listBox_usuarios.Items)
                {
                    ENUsuario usuario = new ENUsuario();
                    usuarios.Add(ob);
                }
            }
            ENGrupos grupo = new ENGrupos(textBox_nombre.Text, textBox_descripcion.Text, dateTimePicker_fecha.Value, usuarios);
            if (textBox_id.Text == "")
            {
                if (grupo.Guardar())
                {
                    MessageBox.Show("Grupo creado correctamente", "Ventana de Información");
                }
                else
                {
                    MessageBox.Show("Error al crear el grupo", "Ventana de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                grupo.Id = int.Parse(textBox_id.Text);
                if (grupo.Actualizar())
                {
                    MessageBox.Show("Grupo editado correctamente", "Ventana de Información");
                }
                else
                {
                    MessageBox.Show("Error al editar el grupo", "Ventana de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_borrar_Click(object sender, EventArgs e)
        {
            if (listBox_usuarios.SelectedIndex != 0)
            {
                ENGrupos grupo = new ENGrupos(int.Parse(textBox_id.Text));
                foreach (ENUsuario ob in grupo.Usuarios)
                {
                    if (ob.Usuario == listBox_usuarios.SelectedItem.ToString())
                    {
                        if (grupo.BorrarMiembro(ob.Id))
                        {
                            MessageBox.Show("Miembro del grupo borrado correctamente", "Ventana de Información");
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Error al borrar el miembro del grupo", "Ventana de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                }
            }
        }
    }
}
