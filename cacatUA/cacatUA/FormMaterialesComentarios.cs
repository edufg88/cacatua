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
    public partial class FormMaterialesComentarios : InterfazForm
    {
        public enum modos { EDITAR = 0, CREAR = 1 };

        private ENMaterial material;
        private modos modo;
        
        // Para que se produzca un cambio en el formulario, esto debe estar a true, si es falso, se ignora
        bool cambioProducido;

        public modos Modo
        {
            get { return modo; }
            set { modo = value; }
        }

        public FormMaterialesComentarios(ENMaterial material)
        {
            InitializeComponent();
            this.material = material;
            cambioProducido = true;
            label_comentarioMaterial.Text = "Comentarios del material nº " + material.Id;
            // Mostramos en el datagridview los comentarios
            mostrarComentarios();
            // Actualizamos el formulario
            ActualizarFormulario(modos.CREAR);
        }

        public void mostrarComentarios()
        {
            // Guardamos el comentario seleccionado actualmente
            int idComentarioSeleccionado = -1;
            DataGridViewSelectedRowCollection filas = dataGridView_comentarios.SelectedRows;
            if (filas.Count == 1)
            {
                DataGridViewRow fila = fila = filas[0];
                idComentarioSeleccionado = int.Parse(fila.Cells["dataGridViewTextBoxColumn_id"].Value.ToString());
            }
            // Obtenemos todos los comentarios del material
            ArrayList comentarios = material.ObtenerComentarios();
            dataGridView_comentarios.Rows.Clear();
            // Obtenemos todos los materiales que hay en la base de datos
            for (int i = 0; i < comentarios.Count; i++)
            {
                ComentarioMaterial comentario = (ComentarioMaterial)comentarios[i];
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView_comentarios);
                int posicion = dataGridView_comentarios.Columns["dataGridViewTextBoxColumn_id"].Index;
                fila.Cells[posicion].Value = comentario.Id.ToString();
                posicion = dataGridView_comentarios.Columns["dataGridViewTextBoxColumn_texto"].Index;
                fila.Cells[posicion].Value = comentario.Texto;
                posicion = dataGridView_comentarios.Columns["dataGridViewTextBoxColumn_usuario"].Index;
                fila.Cells[posicion].Value = comentario.Usuario.Usuario;
                posicion = dataGridView_comentarios.Columns["dataGridViewTextBoxColumn_fecha"].Index;
                fila.Cells[posicion].Value = (DateTime) comentario.Fecha;
                dataGridView_comentarios.Rows.Add(fila);
                // Comprobamos si era el comentario seleccionado anteriormente
                if (comentario.Id == idComentarioSeleccionado)
                {
                    dataGridView_comentarios.ClearSelection();
                    dataGridView_comentarios.Rows[fila.Index].Selected = true;
                }
            }
        }

        private void mostrarComentario(ComentarioMaterial comentario)
        {
            cambioProducido = false;
            if (comentario != null)
            {
                textBox_id.Text = comentario.Id.ToString();
                textBox_texto.Text = comentario.Texto;
                textBox_usuario.Text = comentario.Usuario.Usuario;
                dateTimePicker_fecha.Value = (DateTime)comentario.Fecha;
            }
            cambioProducido = true;
        }



        private void ActualizarFormulario(modos modo)
        {
            // Limpiamos el formulario
            LimpiarFormulario();

            this.modo = modo;
            switch (modo)
            {
                case modos.CREAR:
                    {
                        label_modo.Text = "Crear un nuevo comentario";
                        dateTimePicker_fecha.Enabled = false;
                        button_accion1.Text = "Crear";
                        button_accion2.Text = "Limpiar";
                        break;
                    }
                case modos.EDITAR:
                    {
                        label_modo.Text = "Editar comentario";
                        dateTimePicker_fecha.Enabled = true;
                        button_accion1.Enabled = false;
                        button_accion2.Enabled = false;
                        button_accion1.Text = "Guardar cambios";
                        button_accion2.Text = "Descartar cambios";
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Modo no válido");
                        break;
                    }
            }
        }

        private void crearComentario(object sender, EventArgs e)
        {
            // Actualizamos el formulario
            ActualizarFormulario(modos.CREAR);
        }

        private void editarComentario(object sender, EventArgs e)
        {
            // Actualizamos el formulario
            ActualizarFormulario(modos.EDITAR);
            // Obtenemos el id del comentario a editar
            DataGridViewSelectedRowCollection filas = dataGridView_comentarios.SelectedRows;
            if (filas.Count == 0)
            {
                // No hay ningún comentario seleccionado, mostramos un aviso
                MessageBox.Show("Debes seleccionar un comentario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataGridViewRow fila = fila = filas[0];
                // Comprobamos si hay un comentario seleccionado únicamente
                if (filas.Count > 1)
                {
                    // Deseleccionamos el resto de elementos
                    dataGridView_comentarios.ClearSelection();
                    dataGridView_comentarios.Rows[fila.Index].Selected = true;
                }

                // Obtenemos el id del comentario que vamos a editar
                string id = fila.Cells["dataGridViewTextBoxColumn_id"].Value.ToString();

                // Obtenemos el comentario
                try
                {
                    ComentarioMaterial comentario = ENMaterial.ObtenerComentario(int.Parse(id));
                    mostrarComentario(comentario);
                }
                catch (Exception)
                {
                    
                }
            }
        }

        private void LimpiarFormulario()
        {
            textBox_id.Clear();
            textBox_texto.Clear();
            textBox_usuario.Clear();
        }

        private bool validar(ComentarioMaterial comentario)
        {
            errorProvider.Clear();
            bool valido = true;
            // Validamos el usuario
            string error = ComentarioMaterial.Validar(comentario, "usuario");
            if (error != "OK")
            {
                valido = false;
                errorProvider.SetError(textBox_usuario, error);
            }
            // Validamos el texto
            error = ComentarioMaterial.Validar(comentario, "texto");
            if (error != "OK")
            {
                valido = false;
                errorProvider.SetError(textBox_texto, error);
            }
            return valido;
        }

        private void realizarAccion1(object sender, EventArgs e)
        {
            switch (modo)
            {
                case modos.CREAR:
                    {
                        // Creamos el nuevo comentario
                        ComentarioMaterial comentario = new ComentarioMaterial();
                        comentario.Texto = textBox_texto.Text;
                        comentario.Usuario = ENUsuario.ObtenerPorNombre(textBox_usuario.Text);
                        comentario.Fecha = dateTimePicker_fecha.Value;
                        comentario.Material = material;
                        // Validamos el comentario
                        if(validar(comentario) == true)
                        {
                            material.GuardarComentario(comentario);
                            // Actualizamos el datagridview
                            mostrarComentarios();
                            // Limpiamos el formulario
                            LimpiarFormulario();
                        }
                        break;
                    }
                case modos.EDITAR:
                    {
                        // Editamos el comentario
                        ComentarioMaterial comentario = new ComentarioMaterial();
                        comentario.Texto = textBox_texto.Text;
                        comentario.Usuario = ENUsuario.ObtenerPorNombre(textBox_usuario.Text);
                        comentario.Fecha = dateTimePicker_fecha.Value;
                        comentario.Material = material;
                        comentario.Id = int.Parse(textBox_id.Text.ToString());
                        // Validamos el comentario
                        if (validar(comentario) == true)
                        {
                            bool actualizado = material.ActualizarComentario(comentario);
                            if (actualizado == true)
                            {
                                // Actualizamos el datagridview
                                mostrarComentarios();
                                // Desactivamos los botones
                                button_accion1.Enabled = false;
                                button_accion2.Enabled = false;
                            }
                            else
                                Console.WriteLine("mal");
                            
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Modo no válido");
                        break;
                    }
            }
        }

        private void realizarAccion2(object sender, EventArgs e)
        {
            switch (modo)
            {
                case modos.CREAR:
                    {
                        // Limpiamos el formulario
                        LimpiarFormulario();
                        break;
                    }
                case modos.EDITAR:
                    {
                        // Obtenemos el comentario que estamos editando
                        int id = int.Parse(textBox_id.Text.ToString());
                        // Deshacemos los cambios
                        ComentarioMaterial comentario = ENMaterial.ObtenerComentario(id);
                        mostrarComentario(comentario);
                        // Desactivamos los botones
                        button_accion1.Enabled = false;
                        button_accion2.Enabled = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Modo no válido");
                        break;
                    }
            }
        }

        private void formularioModificado(object sender, EventArgs e)
        {
            // Se ha modificado el formulario
            if (modo == modos.EDITAR && cambioProducido == true)
            {
                button_accion1.Enabled = true;
                button_accion2.Enabled = true;
            }
        }

        private void borrarComentario(object sender, EventArgs e)
        {
            // Comprobamos que haya algún comentario seleccionado
            DataGridViewSelectedRowCollection filas = dataGridView_comentarios.SelectedRows;
            if (filas.Count == 0)
            {
                // No hay ningún comentario seleccionado, mostramos un aviso
                MessageBox.Show("Debes seleccionar un comentario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult resultado;
                // Mostramos un mensaje de aviso para que el usuario confirme que quiere borrar el comentario
                if (filas.Count == 1)
                {
                    string mensaje = "¿Está seguro de que desea eliminar el comentario " + filas[0].Cells["dataGridViewTextBoxColumn_id"].Value.ToString() + "?";
                    resultado = MessageBox.Show(mensaje, "Confirmar eliminación del comentario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    string mensaje = "¿Está seguro que desea eliminar estos " + filas.Count + " comentarios?";
                    resultado = MessageBox.Show(mensaje, "Confirmar la eliminación de múltiples comentarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                // Comprobamos cual ha sido el resultado
                if (resultado == DialogResult.Yes)
                {
                    for (int i = 0; i < filas.Count; i++)
                    {
                        // Obtenemos la fila
                        DataGridViewRow fila = filas[i];
                        // Eliminamos el comentario de la base de datos
                        int id = int.Parse(fila.Cells["dataGridViewTextBoxColumn_id"].Value.ToString());
                        ComentarioMaterial comentario = ENMaterial.ObtenerComentario(id);
                        bool borrado = ENMaterial.BorrarComentario(comentario);
                        if (borrado == false)
                        {
                            string mensaje = "ERROR: No se ha podido borrar el comentario " + id;
                            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        // Eliminamos la fila
                        dataGridView_comentarios.Rows.Remove(fila);
                    }
                }
            }
        }

        public override void Recibir(object objeto)
        {
            if (objeto != null)
            {
                if (objeto is ENUsuario)
                {
                    textBox_usuario.Text = ((ENUsuario)objeto).Usuario;
                }
            }
        }

        private void seleccionarUsuario(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, true,
                "Volver al panel anterior seleccionando el usuario actual",
                "Cancelar la selección y volver al panel anterior");
        }
    }
}