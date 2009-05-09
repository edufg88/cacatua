using System;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Libreria;
using ICSharpCode.SharpZipLib.Zip;

namespace WebCacatUA
{
    public partial class nuevoMaterial1 : System.Web.UI.UserControl
    {
        public ENUsuario usuarioSesion;
        int maxTamañoFichero = 30; // en megabytes

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Panel_errorNombre.Visible = false;
                Panel_errorDescripcion.Visible = false;
                Panel_errorReferencia.Visible = false;
                Panel_errorArchivo.Visible = false;

                if (Request.Params["categoria"] != null)
                {
                    int idCategoria = int.Parse(Request.Params["categoria"].ToString());
                    Hidden_categoria.Value = idCategoria.ToString();
                }

                // Comprobamos si el usuario no está logueado
                if (Session["usuario"] == null)
                {
                    // Desactivamos todo
                    Button1.Enabled = false;
                    TextBox_nombre.Enabled = false;
                    TextBox_referencia.Enabled = false;
                    FileUpload1.Enabled = false;
                    TextBox_descripcion.Enabled = false;
                    Panel_mensajeError.Visible = true;
                    usuarioSesion = null;
                }
                else
                {
                    usuarioSesion = ENUsuario.Obtener(Session["usuario"].ToString());
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        private void LimpiarFormulario()
        {
            TextBox_nombre.Text = "";
            TextBox_referencia.Text = "";
            TextBox_descripcion.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Creamos el material en la base de datos para obtener el id
            ENMaterial material = new ENMaterial();
            material.Nombre = TextBox_nombre.Text;
            material.Usuario = usuarioSesion;
            material.Categoria = ENCategoria.Obtener(int.Parse(Hidden_categoria.Value.ToString()));
            material.Descripcion = TextBox_descripcion.Text;
            material.Referencia = TextBox_referencia.Text;
            material.Tamaño = (int)FileUpload1.FileBytes.Length;
            material.Archivo = FileUpload1.FileName;

            // Validamos el material
            if (validarMaterial(material) == true)
            {
                // Comprobamos el tamaño del fichero
                int numMB = Convert.ToInt32(FileUpload1.FileBytes.Length / 1048576);
                if (numMB < maxTamañoFichero)
                {
                    servicioUploader.Uploader fileUploader = new servicioUploader.Uploader();

                    string resultado = fileUploader.subirArchivo(FileUpload1.FileBytes, FileUpload1.FileName + "_" + material.Usuario.Usuario);
                    if (resultado == "OK")
                    {
                        if (material.Guardar() == true)
                        {
                            int id = material.CompletarGuardar();
                            // Comprimimos el archivo con la id
                            fileUploader.ComprimirArchivo(material.Archivo + "_" + material.Usuario.Usuario, id, material.Archivo);
                            // Borramos el fichero temporal
                            fileUploader.BorrarFichero(material.Archivo + "_" + material.Usuario.Usuario);
                            // Recargamos la página
                            Response.Redirect("materiales.aspx?categoria=" + material.Categoria.Id.ToString());
                        }
                    }
                }
                else
                {
                    Panel_errorArchivo.Visible = true;
                    Label_errorArchivo.Text = "Archivo: Debe tener un tamaño máximo de " + maxTamañoFichero.ToString() + " MB";
                    Button1.Focus();
                }
            }
            else
            {
                Button1.Focus();
            }
        }

        private bool validarMaterial(ENMaterial material)
        {
            bool correcto = true;
            // Validamos el nombre
            if (material.Nombre.Length > ENMaterial.maxTamNombre || material.Nombre.Length < ENMaterial.minTamNombre)
            {
                correcto = false;
                Panel_errorNombre.Visible = true;
                //Label_errorNombre.Text = Resources.I18N.Nombre + ":" + 
                Label_errorNombre.Text = "Nombre: Debe tener entre " + ENMaterial.minTamNombre.ToString() + " y " + ENMaterial.maxTamNombre + " caracteres";
            }
            // Validamos la descripción
            if (material.Descripcion.Length > ENMaterial.maxTamDescripcion || material.Descripcion.Length < ENMaterial.minTamDescripcion)
            {
                correcto = false;
                Panel_errorDescripcion.Visible = true;
                Label_errorDescripcion.Text = "Descripción: Debe tener entre " + ENMaterial.minTamDescripcion.ToString() + " y " + ENMaterial.maxTamDescripcion + " caracteres";
            }
            // Validamos la referencia
            if (material.Referencia != "")
            {
                if (material.Referencia.Length > ENMaterial.maxTamReferencia || material.Referencia.Length < ENMaterial.minTamReferencia)
                {
                    correcto = false;
                    Panel_errorReferencia.Visible = true;
                    Label_errorReferencia.Text = "Referencia: Debe tener entre " + ENMaterial.minTamReferencia.ToString() + " y " + ENMaterial.maxTamReferencia + " caracteres";
                }
            }
            // Validamos el archivo
            if (material.Archivo.Length > ENMaterial.maxTamArchivo || material.Archivo.Length < ENMaterial.minTamArchivo)
            {
                correcto = false;
                Panel_errorArchivo.Visible = true;
                Label_errorArchivo.Text = "Archivo: Debe tener entre " + ENMaterial.minTamArchivo.ToString() + " y " + ENMaterial.maxTamArchivo + " caracteres";
            }
            return correcto;
        }
    }
}