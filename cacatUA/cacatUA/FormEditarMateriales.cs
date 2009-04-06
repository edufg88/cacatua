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
using Libreria;


namespace cacatUA
{
    public partial class FormEditarMateriales : UserControl
    {
        string[] controlesCrear = { "nombre","descripcion","usuario","categoria","archivo","idioma","referencia" };
        string[] controlesEditar = { "nombre", "descripcion", "fecha","usuario", "categoria", "archivo", "descargas","idioma","puntuacion","votos","referencia" };
        
        public enum modos { EDITAR = 0, CREAR = 1, BORRAR = 2};
        private modos modo;
        public modos Modo
        {
            get { return modo; }
            set { modo = value; }
        }

        public FormEditarMateriales(modos modo, string id)
        {
            InitializeComponent();
            this.modo = modo;
            inicializarControles();
            actualizarFormulario(id);
            
        }

        Dictionary<string, Control> controles = null;
        private void inicializarControles()
        {
            controles = new Dictionary<string, Control>();
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
                    control.Enabled = false;
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
        }

        public void actualizarFormulario(string id)
        {
            switch (modo)
            {
                case modos.CREAR:
                    {
                        prepararControles(controlesCrear);
                        button_accion.Text = "Crear";
                        break;
                    }
                case modos.EDITAR:
                    {
                        prepararControles(controlesEditar);
                        // Obtenemos toda la información del material
                        ENMaterial material = new ENMaterial(int.Parse(id));
                        if (material.Id != 0)
                        {
                            controles["nombre"].Text = material.Nombre;
                            controles["descripcion"].Text = material.Descripcion;
                            // fecha

                            controles["usuario"].Text = material.Usuario.Nombre;
                            controles["categoria"].Text = material.Categoria;
                            controles["archivo"].Text = material.Archivo;
                            controles["tamaño"].Text = material.Tamaño.ToString();
                            controles["descargas"].Text = material.Descargas.ToString();
                            // idioma
                            controles["puntuacion"].Text = material.Puntuacion.ToString();
                            controles["votos"].Text = material.Votos.ToString();
                            controles["referencia"].Text = material.Referencia;
                            
                        }
                        else
                        {
                            MessageBox.Show("Problema al obtener los datos del material", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        material.Usuario = new ENUsuario(textBox_usuario.Text.ToString());
                        material.Categoria = textBox_categoria.Text.ToString();
                        material.Archivo = textBox_archivo.Text.ToString();
                        material.Tamaño = convertirTamaño(textBox_tamaño.Text.ToString());
                        material.Referencia = textBox_referencia.Text.ToString();
                        // Validamos los datos
                        if (validarDatos(controlesCrear,material) == true)
                        {
                            // Guardamos el material a la base de datos
                            if (material.Guardar() == false)
                            {
                                // Se ha producido algún error, mostramos un mensaje
                                MessageBox.Show("No se ha podido crear el material", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
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




    }
}
