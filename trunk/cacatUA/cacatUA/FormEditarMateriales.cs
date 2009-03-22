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
        string[] controlesEditar = { "nombre", "descripcion", "fecha","usuario", "categoria", "archivo", "descargas","idioma","valoracion","votos","referencia" };
        
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
            controles.Add("descripcion", richTextBox_descripcion);
            controles.Add("fecha", dateTimePicker_fecha);
            controles.Add("usuario", textBox_usuario);
            controles.Add("categoria", textBox_categoria);
            controles.Add("archivo", textBox_archivo);
            controles.Add("tamaño", textBox_tamaño);
            controles.Add("descargas", textBox_descargas);
            controles.Add("idioma", comboBox_idioma);
            controles.Add("valoracion", textBox_valoracion);
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

        private void validarDatos(string[] nombreControles)
        {
            foreach (KeyValuePair<string, Control> i in controles)
            {
                // Obtenemos el nombre
                string nombre = i.Key;
                // Obtenemos el control
                Control control = i.Value;
                if (nombre == "nombre")
                {


                }
            }
            /*
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
            }*/
        }

        public void limpiarFormulario()
        {
            TextBox textBox;
            textBox = (TextBox)controles["nombre"];
            textBox.Clear();
            RichTextBox richTextBox = (RichTextBox)controles["descripcion"];
            richTextBox.Clear();
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
            textBox = (TextBox)controles["valoracion"];
            textBox.Clear();
            textBox = (TextBox)controles["votos"];
            textBox.Clear();
            textBox = (TextBox)controles["referencia"];
            textBox.Clear();
        }

        public void actualizarFormulario(string id)
        {
            comboBox_idioma.SelectedIndex = 0;

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
                        ENMaterialCRUD material = MaterialCAD.obtenerMaterial(int.Parse(id));
                        controles["nombre"].Text = material.Nombre;
                        controles["descripcion"].Text = material.Descripcion;
                        // fecha
                        controles["usuario"].Text = material.Usuario;
                        controles["categoria"].Text = material.Categoria;
                        controles["archivo"].Text = material.Archivo;
                        controles["tamaño"].Text = material.Tamaño.ToString();
                        controles["descargas"].Text = material.Descargas.ToString();
                        // idioma
                        controles["valoracion"].Text = material.Valoracion.ToString();
                        controles["votos"].Text = material.Votos.ToString();
                        controles["referencia"].Text = material.Referencia;

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
                        // Comprobamos que los campos sean válidos
                        validarDatos(controlesCrear);

                        // Creamos el nuevo material
                        ENMaterialCRUD material = new ENMaterialCRUD();
                        material.Nombre = textBox_nombre.Text.ToString();
                        material.Descripcion = richTextBox_descripcion.Text.ToString();
                        material.Usuario = textBox_usuario.Text.ToString();
                        material.Categoria = textBox_categoria.Text.ToString();
                        material.Archivo = textBox_archivo.Text.ToString();
                        material.Tamaño = convertirTamaño(textBox_tamaño.Text.ToString());
                        material.Idioma = comboBox_idioma.SelectedItem.ToString();
                        material.Referencia = textBox_referencia.Text.ToString();
                        // Añadimos el material a la base de datos
                        material.crearMaterial();
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

        private int convertirTamaño(string tamaño)
        {
            // Quitamos la medida
            Console.WriteLine(tamaño.IndexOf(' '));
            tamaño = tamaño.Remove(tamaño.IndexOf(' '));
            tamaño.Trim();
            return int.Parse(tamaño);
        }

    }
}
