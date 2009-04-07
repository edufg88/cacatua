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
            desactivarBotones();
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
            desactivarBotones();
        }

        public bool ValidarFormulario()
        {
            bool correcto = true;
            string errorNombre = "";
            string errorDesc = "";


            if (textBox_nombre.Text == "")
            {
                errorNombre = "Debes introducir un nombre.";
                correcto = false;
            }

            if (textBox_descripcion.Text == "")
            {
                errorDesc = "Debes introducir una descripción.";
                correcto = false;
            }

            errorProvider1.SetError(textBox_nombre, errorNombre);
            errorProvider1.SetError(textBox_descripcion, errorDesc);

            return correcto;
        }


        private void linkLabel_usuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listBox_usuarios.SelectedItem != null)
            {

            }
            else
            {
                MessageBox.Show("Seleccione un usuario para ver", "Ventana de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
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
        }

        private void button_borrar_Click(object sender, EventArgs e)
        {
            if (listBox_usuarios.SelectedItem != null)
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
            else
            {
                MessageBox.Show("Seleccione un usuario para borrar", "Ventana de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void activarBotones()
        {
            button_guardar.Enabled = true;
            button_descartarCambios.Enabled = true;
        }

        private void desactivarBotones()
        {
            button_guardar.Enabled = false;
            button_descartarCambios.Enabled = false;
        }

        private void button_descartarCambios_Click(object sender, EventArgs e)
        {
            if (textBox_id.Text == "")
            {
                Nuevo();
            }
            else
            {
                Editar(int.Parse(textBox_id.Text));
            }
        }

        private void textBox_Modificado(object sender, EventArgs e)
        {
            activarBotones();
        }

        private void button_seccionCrear_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, true, "Volver al panel anterior seleccionando el usuario actual", "Cancelar la selección y volver al panel anterior");
        }
    }
}
