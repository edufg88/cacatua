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
        string[] controlesCrear = { "nombre","descripcion","usuario","archivo","referencia" };
        string[] controlesEditar = { "nombre", "descripcion","usuario", "archivo", "descargas","referencia","comentarios" };
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

            //this.modo = modo;
            
            //actualizarFormulario(id);
            
        }

        Dictionary<string, Control> controles = null;
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
                // Obtenemos el tipo del control
                Console.WriteLine(control.ToString());
                switch (obtenerTipo(control.ToString()))
                {
                    case "System.Windows.Forms.TextBox":
                        {
                            TextBox textBox = (TextBox)control;
                            // Validamos el dato
                            string msjError = material.validarDato(nombre);
                            if (msjError != "OK")
                            {
                                correcto = false;
                                errorProvider.SetError(control, msjError);
                            }
                            break;
                        }
                }
            }
            return correcto;
        }

        public void limpiarFormulario()
        {
            TextBox textBox;
            textBox = (TextBox)controles["id"];
            textBox.Clear();
            textBox = (TextBox)controles["nombre"];
            textBox.Clear();
            textBox = (TextBox)controles["descripcion"];
            textBox.Clear();
            //dateTimePicker_fecha
            textBox = (TextBox)controles["usuario"];
            textBox.Clear();
            textBox = (TextBox)controles["categoria"];
            textBox.Clear();
            textBox = (TextBox)controles["archivo"];
            textBox.Clear();
            textBox = (TextBox)controles["tamaño"];
            textBox.Clear();
            textBox = (TextBox)controles["descargas"];
            textBox.Clear();
            //comboBox_idioma.Clear();
            textBox = (TextBox)controles["puntuacion"];
            textBox.Clear();
            textBox = (TextBox)controles["votos"];
            textBox.Clear();
            textBox = (TextBox)controles["referencia"];
            textBox.Clear();
            textBox = (TextBox)controles["numComentarios"];
            textBox.Clear();

        }

        public void actualizarFormulario(modos modo, ENMaterial material)
        {           
            switch (modo)
            {
                case modos.CREAR:
                    {
                        seleccionado = null;
                        if (this.modo != modos.CREAR)
                        {
                            prepararControles(controlesCrear);
                            button_accion.Text = "Crear";
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
                            // Mostramos el nuevo material
                            if (material != null)
                            {
                                controles["id"].Text = material.Id.ToString();
                                controles["nombre"].Text = material.Nombre;
                                controles["descripcion"].Text = material.Descripcion;
                                // fecha

                                controles["usuario"].Text = material.Usuario.Usuario;
                                controles["categoria"].Text = material.Categoria.NombreCompleto();
                                controles["archivo"].Text = material.Archivo;
                                controles["tamaño"].Text = material.Tamaño.ToString();
                                controles["descargas"].Text = material.Descargas.ToString();
                                // idioma
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
                        button_accion.Text = "Editar";                       
                        break;
                    }
                case modos.BORRAR:
                    {
                        button_accion.Text = "Borrar";
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
                        material.Tamaño = convertirTamaño(textBox_tamaño.Text.ToString());
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
                                FormMaterialesUpload form = new FormMaterialesUpload(material);
                                form.ShowDialog();
                            }
                        }
                        //Uploader.FileUploader file = new Uploader.FileUploader();
                        // Subimos el archivo
                        //FormMaterialesUpload form = new FormMaterialesUpload(material);
                        //form.ShowDialog();
                        
                        //MessageBox.Show(subirArchivo(material));
                        //subirArchivo(material);
                        /*
                        // Validamos los datos
                        if (validarDatos(controlesCrear,material) == true)
                        {
                            // Guardamos el material a la base de datos
                            if (material.Guardar() == false)
                            {
                                // Se ha producido algún error, mostramos un mensaje
                                MessageBox.Show("No se ha podido crear el material", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }*/
                        break;
                    }
                case modos.EDITAR:
                    {
                        
                        break;
                    }
                case modos.BORRAR:
                    {
                        
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
                long tamaño = info.Length;
                if (tamaño > 1024)
                {
                    tamaño = tamaño / 1024;
                    controles["tamaño"].Text = tamaño.ToString() + " KB";
                }
                else
                {
                    controles["tamaño"].Text = tamaño.ToString() + " bytes";
                }
            }
        }

        private string obtenerTipo(string tipo)
        {
            Console.WriteLine(tipo);
            tipo = tipo.Remove(tipo.IndexOf(","));
            tipo.Trim();
            Console.WriteLine(tipo);
            return tipo;
        }

        private int convertirTamaño(string tamaño)
        {
            // Quitamos la medida
            if (tamaño != "")
            {
                tamaño = tamaño.Remove(tamaño.IndexOf(' '));
                tamaño.Trim();
                return int.Parse(tamaño);
            }
            else
                return 0;
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
    }
}
