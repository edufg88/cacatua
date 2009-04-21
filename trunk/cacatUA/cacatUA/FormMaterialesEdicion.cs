using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Libreria;


namespace cacatUA
{
    public partial class FormMaterialesEdicion : InterfazForm
    {
        string[] controlesCrear = { "nombre","categoria","descripcion","usuario","archivo","referencia" };
        string[] controlesEditar = { "nombre","categoria","descripcion","usuario","archivo","descargas","referencia","comentarios" };
        private FormMateriales formularioPadre = null;
        private ENCategoria categoria = null;
        public enum modos { EDITAR = 0, CREAR = 1, BORRAR = 2};
        private modos modo;
        public modos Modo
        {
            get { return modo; }
            set { modo = value; }
        }

        private ENMaterial seleccionado = null;
        public ENMaterial Seleccionado
        {
            get { return seleccionado; }
            set { seleccionado = value; }
        }

        public override void Recibir(object objeto)
        {
            if (objeto != null)
            {
                if (objeto is ENCategoria)
                {
                    categoria = (ENCategoria)objeto;
                    controles["categoria"].Text = categoria.NombreCompleto();
                }
                else
                {
                    if (objeto is ENUsuario)
                        controles["usuario"].Text = ((ENUsuario)objeto).Usuario;
                }
            }
        }

        public FormMaterialesEdicion(FormMateriales formularioPadre)
        {
            InitializeComponent();
            this.formularioPadre = formularioPadre;
            inicializarControles();
        }

        private Dictionary<string, Control> controles = null;
        public Dictionary<string, Control> Controles
        {
            get { return controles; }
            set { controles = value; }
        }

        private void inicializarControles()
        {
            controles = new Dictionary<string, Control>();
            controles.Add("id", textBox_id);
            controles.Add("nombre", textBox_nombre);         
            controles.Add("descripcion", textBox_descripcion);
            controles.Add("fecha", dateTimePicker_fecha);
            controles.Add("usuario", textBox_usuario);
            controles.Add("categoria", textBox_categoria);
            controles.Add("archivo", textBox_archivo);
            controles.Add("tamaño", textBox_tamaño);
            controles.Add("descargas", textBox_descargas);
            controles.Add("puntuacion", textBox_puntuacion);
            controles.Add("votos", textBox_votos);
            controles.Add("referencia", textBox_referencia);
            controles.Add("numComentarios", textBox_numComentarios);
            controles.Add("comentarios", linkLabel_comentarios);
        }

        private void prepararControles(string[] nombreControles)
        {
            limpiarFormulario();
            // Activamos los controles que se indican y desactivamos el resto
            foreach (KeyValuePair<string, Control> i in controles)
            {
                // Obtenemos el nombre
                string nombre = i.Key;
                // Obtenemos el control
                Control control = i.Value;
                // Comprobamos si el control está en el array de controles a activar
                if (nombreControles.Contains(nombre) == true)
                {
                    // Lo activamos
                    control.Enabled = true;
                }
                else
                {
                    // Lo desactivamos
                    if (control is TextBox)
                    {
                        if (((TextBox)control).ReadOnly == false)
                            control.Enabled = false;
                    }
                    else
                    {
                        control.Enabled = false;
                    }
                }
            }
        }

        private bool validarDatos(string[] nombreControles, ENMaterial material)
        {
            errorProvider.Clear();
            bool correcto = true;
            // Comprobamos que todos los campos estén 
            foreach (KeyValuePair<string, Control> i in controles)
            {
                // Obtenemos el nombre
                string nombre = i.Key;
                // Obtenemos el control
                Control control = i.Value;
                // Comprobamos si está en la lista
                if (nombreControles.Contains(nombre))
                {
                    if (control is TextBox)
                    {
                        TextBox textBox = (TextBox)control;
                        string msjError = "";
                        if (textBox.Text == "" && nombre != "referencia")
                            msjError = "Campo obligatorio";
                        else
                            msjError = ENMaterial.validarDatos(material, nombre);

                        if (msjError != "OK")
                        {
                            correcto = false;
                            errorProvider.SetError(control, msjError);
                        }
                    }
                }
            }
            return correcto;
        }

        public void limpiarFormulario()
        {
            foreach (KeyValuePair<string, Control> i in controles)
            {
                Control control = i.Value;
                if(control is TextBox)
                    ((TextBox)control).Clear();
            }
        }

        public void actualizarFormulario(modos modo, ENMaterial material)
        {
            errorProvider.Clear();
            switch (modo)
            {
                case modos.CREAR:
                    {
                        seleccionado = null;
                        if (this.modo != modos.CREAR)
                        {
                            prepararControles(controlesCrear);
                            button_accion1.Text = "Crear";
                            button_accion2.Text = "Limpiar";
                        }
                        break;
                    }
                case modos.EDITAR:
                    {                    
                        // Comprobamos que el material a editar no sea el mismo que el que esta editandose
                        if (seleccionado == null || seleccionado.Id != material.Id)
                        {
                            prepararControles(controlesEditar);
                            seleccionado = material;
                            mostrarMaterial(material);
                            button_accion1.Enabled = false;
                            button_accion2.Enabled = false;
                        }
                        button_accion1.Text = "Guardar cambios";
                        button_accion2.Text = "Deshacer cambios";
                        break;
                    }
                case modos.BORRAR:
                    {
                        button_accion1.Text = "Borrar";
                        break;
                    }
            }
            this.modo = modo;
        }

        private void button_accion_Click(object sender, EventArgs e)
        {
            switch (modo)
            {
                case modos.CREAR:
                    {
                        // Creamos el nuevo material

                        ENMaterial material = new ENMaterial();
                        material.Nombre = textBox_nombre.Text.ToString();
                        material.Descripcion = textBox_descripcion.Text.ToString();
                        material.Usuario = ENUsuario.Obtener(textBox_usuario.Text.ToString());
                        material.Categoria = categoria;
                        material.Archivo = textBox_archivo.Text.ToString();
                        material.Tamaño = ENMaterial.convertirTamaño(textBox_tamaño.Text);
                        material.Referencia = textBox_referencia.Text.ToString();

                        if (validarDatos(controlesCrear, material) == true)
                        {
                            // Registramos el material en la base de datos mediante una transacción
                            // En caso de que luego no se pueda subir el archivo, se cancela la transacción
                            // Guardamos el material a la base de datos
                            if (material.Guardar() == false)
                            {
                                // Se ha producido algún error, mostramos un mensaje
                                MessageBox.Show("No se ha podido crear el material", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                // Subimos el material
                                FormMaterialesUpload form = new FormMaterialesUpload(material,FormMaterialesUpload.modos.CREAR);
                                form.ShowDialog();
                                if (form.Error == "OK")
                                {
                                    // Limpiamos el formulario de edición
                                    formularioPadre.formEditarMateriales.limpiarFormulario();
                                    // Volvemos al formulario de búsqueda y lo limpiamos para que salgan todos los materiales (includo el nuevo)
                                    formularioPadre.ActualizarFormulario(FormMateriales.estados.BUSCAR);
                                    formularioPadre.formMaterialesBusqueda.limpiarFormulario();
                                    formularioPadre.formMaterialesBusqueda.NuevaBusqueda();
                                }
                                else
                                {
                                    FormPanelAdministracion.Instancia.MensajeEstado(form.Error);
                                    if (form.Error == "Cancelado por el usuario")
                                        FormPanelAdministracion.Instancia.MensajeEstado("Creación del material cancelada por el usuario");
                                    else
                                        MessageBox.Show(form.Error,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                }
                            }
                        }
                        break;
                    }
                case modos.EDITAR:
                    {
                        // Creamos el material con los datos del formulario
                        ENMaterial material = new ENMaterial();
                        material.Id = int.Parse(textBox_id.Text.ToString());
                        material.Nombre = textBox_nombre.Text.ToString();
                        material.Descripcion = textBox_descripcion.Text.ToString();
                        material.Usuario = ENUsuario.Obtener(textBox_usuario.Text.ToString());
                        material.Categoria = categoria;
                        material.Archivo = textBox_archivo.Text.ToString();
                        material.Fecha = dateTimePicker_fecha.Value;
                        material.Tamaño = ENMaterial.convertirTamaño(textBox_tamaño.Text);
                        material.Referencia = textBox_referencia.Text.ToString();
                        material.Descargas = int.Parse(textBox_descargas.Text.ToString());
                        material.NumComentarios = int.Parse(textBox_numComentarios.Text.ToString());
                        if (validarDatos(controlesEditar, material) == true)
                        {
                            // Comprobamos si el material ha cambiado respecto al original
                            ENMaterial original = ENMaterial.Obtener(material.Id);
                            string error = "OK";
                            if (original.Archivo != material.Archivo)
                            {
                                // Actualizamos al material
                                FormMaterialesUpload form = new FormMaterialesUpload(material, FormMaterialesUpload.modos.ACTUALIZAR);
                                form.ShowDialog();
                                error = form.Error;
                            }
                            if (error == "OK")
                            {
                                if (material.Actualizar() == true)
                                {
                                    material = ENMaterial.Obtener(material.Id);
                                    // Actualizamos la fila del datagrid
                                    formularioPadre.ActualizarMaterial(material);
                                    // Actualizamos el formulario de edición
                                    mostrarMaterial(material);
                                    button_accion1.Enabled = false;
                                    button_accion2.Enabled = false;
                                    seleccionado = material;
                                }
                                else
                                {
                                    MessageBox.Show("No se ha podido actualizar el material en la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        break;
                    }
            }
        }

        private void seleccionarArchivo(object sender, EventArgs e)
        {
            // Creamos una ventana para que el usuario seleccione el material
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.InitialDirectory = "C:\\";
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                controles["archivo"].Text = dialogo.FileName;
                FileInfo info = new FileInfo(dialogo.FileName);
                int tamaño = (int)info.Length;
                controles["tamaño"].Text = ENMaterial.convertirTamaño(tamaño);
            }
        }

        private void mostrarComentarios(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Obtenemos el material seleccionado
            try
            {
                ENMaterial material = ENMaterial.Obtener(int.Parse(controles["id"].Text));
                if(material != null)
                    FormPanelAdministracion.Instancia.Apilar(new FormMaterialesComentarios(material), "Comentarios del material nº " + material.Id, true, false, "Volver al material", "");
            }
            catch (Exception)
            {
                Console.WriteLine("<FormMaterialesEdicion::mostrarComentarios> ERROR");
            }
        }

        private void seleccionarUsuario(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormUsuarios(), "Seleccionando usuario", true, true,
                "Volver al panel anterior seleccionando el usuario actual",
                "Cancelar la selección y volver al panel anterior");
        }

        private void seleccionarCategoria(object sender, EventArgs e)
        {
            FormPanelAdministracion.Instancia.Apilar(new FormCategorias(), "Seleccionando categoría", true, true, 
                "Volver al panel anterior seleccionando la categoría actual", 
                "Cancelar la selección y volver al panel anterior");
        }

        public void mostrarMaterial(ENMaterial material)
        {
            // Mostramos el nuevo material
            if (material != null)
            {
                controles["id"].Text = material.Id.ToString();
                controles["nombre"].Text = material.Nombre;
                controles["descripcion"].Text = material.Descripcion;
                ((DateTimePicker)controles["fecha"]).Value = material.Fecha;
                controles["usuario"].Text = material.Usuario.Usuario;
                controles["categoria"].Text = material.Categoria.NombreCompleto();
                categoria = material.Categoria;
                controles["archivo"].Text = material.Archivo;
                controles["tamaño"].Text = ENMaterial.convertirTamaño(material.Tamaño);
                controles["descargas"].Text = material.Descargas.ToString();
                controles["puntuacion"].Text = material.Puntuacion.ToString();
                controles["votos"].Text = material.Votos.ToString();
                controles["referencia"].Text = material.Referencia;
                controles["numComentarios"].Text = material.NumComentarios.ToString();
            }
            else
            {
                MessageBox.Show("Problema al obtener los datos del material", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_accion2_Click(object sender, EventArgs e)
        {
            switch (modo)
            {
                case modos.CREAR:
                    {
                        // Limpiamos el formulario
                        limpiarFormulario();
                        break;
                    }
                case modos.EDITAR:
                    {
                        // Volvemos a cargar el material
                        mostrarMaterial(seleccionado);
                        button_accion1.Enabled = false;
                        button_accion2.Enabled = false;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void formularioModificado(object sender, EventArgs e)
        {
            // Se ha modificado el formulario
            if (modo == modos.EDITAR)// && cambioProducido == true)
            {
                button_accion1.Enabled = true;
                button_accion2.Enabled = true;
            }
        }
    }
}
