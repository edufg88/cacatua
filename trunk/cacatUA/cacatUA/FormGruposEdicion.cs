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
    public partial class FormGruposEdicion : InterfazForm
    {
        const int kMAXNombre = 100;
        const int kMAXDesc = 5000;
        private ENGrupos grupo = null;
        private ENUsuario usuario = null;
        private FormGrupos formularioPadre = null;
        private ArrayList insertados = null;
        private ArrayList borrados = null;

        public FormGruposEdicion(FormGrupos formularioPadre)
        {
            this.formularioPadre = formularioPadre;
            InitializeComponent();
            insertados = new ArrayList();
            borrados = new ArrayList();
        }

        public void Nuevo()
        {
            insertados.Clear();
            borrados.Clear();
            textBox_nombre.Text = "";
            textBox_id.Text = "";
            textBox_descripcion.Text = "";
            dateTimePicker_fecha.Value = DateTime.Now;
            textBox_numUsuarios.Text = "0";
            button_descartarCambios.Text = "Limpiar";
            listBox_usuarios.Items.Clear();
            desactivarBotones();
            errorProvider1.Clear();
        }

        public void Editar(int id)
        {
            insertados.Clear();
            borrados.Clear();
            listBox_usuarios.Items.Clear();
            grupo = ENGrupos.Obtener(id);
            textBox_nombre.Text = grupo.Nombre;
            textBox_id.Text = grupo.Id.ToString();
            textBox_descripcion.Text = grupo.Descripcion;
            dateTimePicker_fecha.Value = grupo.Fecha;
            textBox_numUsuarios.Text = grupo.NumUsuarios.ToString();
            button_descartarCambios.Text = "Descartar Cambios";
            errorProvider1.Clear();
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
            else if (textBox_nombre.Text.Length >= kMAXNombre)
            {
                errorNombre = "El nombre debe tener menos de "+kMAXNombre+" carácteres";
                correcto = false;
            }

            if (textBox_descripcion.Text == "")
            {
                errorDesc = "Debes introducir una descripción.";
                correcto = false;
            }
            else if (textBox_descripcion.Text.Length >= kMAXDesc)
            {
                errorDesc = "La descripción debe tener menos de "+kMAXDesc+" caracteres.";
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
                ENUsuario usuario = ENUsuario.Obtener(listBox_usuarios.SelectedItem.ToString());
                FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(usuario), "Viendo usuario", true, false, "Volver al panel anterior", "");
            }
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                ArrayList usuarios = new ArrayList();
                if (listBox_usuarios.Items.Count != 0)
                {
                    foreach (String ob in listBox_usuarios.Items)
                    {
                        ENUsuario usuario = ENUsuario.Obtener(ob);
                        usuarios.Add(usuario);
                    }
                }
                ENGrupos grupo = new ENGrupos(textBox_nombre.Text, textBox_descripcion.Text, dateTimePicker_fecha.Value, usuarios);
                if (textBox_id.Text == "")
                {
                    if (grupo.Guardar())
                    {
                        FormPanelAdministracion.Instancia.MensajeEstado("Grupo guardado correctamente.");
                        formularioPadre.ReiniciarResultados();
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    grupo.Id = int.Parse(textBox_id.Text);
                    if (grupo.Actualizar() && insertarUsuarios() && borrarUsuarios())
                    {
                        FormPanelAdministracion.Instancia.MensajeEstado("Grupo actualizado correctamente.");
                        formularioPadre.ReiniciarResultados();
                    }
                    else
                    {
                        MessageBox.Show("Error al editar el grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        private bool insertarUsuarios()
        {
            if (insertados.Count > 0)
            {
                foreach (ENUsuario ob in insertados)
                {
                    if (!grupo.InsertarMiembro(ob.Id))
                    {
                        //MessageBox.Show("Error al borrar algun miembro del grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private bool borrarUsuarios()
        {
            if (borrados.Count > 0)
            {
                foreach (ENUsuario ob in borrados)
                {
                    if (!grupo.BorrarMiembro(ob.Id))
                    {
                        //MessageBox.Show("Error al borrar algun miembro del grupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }
        
        private void button_borrar_Click(object sender, EventArgs e)
        {
            if (listBox_usuarios.SelectedItem != null)
            {
                ENUsuario usuario = ENUsuario.Obtener(listBox_usuarios.SelectedItem.ToString());
                borrados.Add(usuario);
                listBox_usuarios.Items.Remove(usuario.Usuario);
                activarBotones();
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

        public override void Recibir(object objeto)
        {
            if (objeto != null)
            {
                if (objeto is ENUsuario)
                {
                    usuario = (ENUsuario)objeto;
                    if (!listBox_usuarios.Items.Contains(usuario.Usuario))
                    {
                        listBox_usuarios.Items.Add(usuario.Usuario);
                        insertados.Add(usuario);
                        activarBotones();
                    }
                    else
                    {
                        FormPanelAdministracion.Instancia.MensajeEstado("El usuario ya existe, escoja otro.");
                    }
                }
            }
        }

        private void button_addUsuario_Click(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, true, "Volver al panel anterior seleccionando el usuario actual", "Cancelar la selección y volver al panel anterior");
        }
    }
}
