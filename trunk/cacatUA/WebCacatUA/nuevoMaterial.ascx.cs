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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Panel_errorNombre.Visible = false;

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
            servicioUploader.Uploader fileUploader = new servicioUploader.Uploader();
            string resultado = fileUploader.subirArchivo(FileUpload1.FileBytes,FileUpload1.FileName + "_jose");
            if (resultado == "OK")
            {
                // Creamos el material en la base de datos para obtener el id
                ENMaterial material = new ENMaterial();
                material.Nombre = TextBox_nombre.Text;
                material.Usuario = ENUsuario.Obtener("jose");
                material.Categoria = ENCategoria.Obtener(int.Parse(Hidden_categoria.Value.ToString()));
                material.Descripcion = TextBox_descripcion.Text;
                material.Referencia = TextBox_referencia.Text;
                material.Tamaño = (int)FileUpload1.FileBytes.Length;

                // Validamos el material
                if (validarMaterial(material) == true)
                {
                    if (material.Guardar() == true)
                    {
                        int id = material.CompletarGuardar();
                        // Comprimimos el archivo con la id
                        fileUploader.ComprimirArchivo(material.Archivo + "_jose", id, material.Archivo);
                        // Borramos el fichero temporal
                        fileUploader.BorrarFichero(FileUpload1.FileName + "_jose");
                        // Recargamos la página
                        Response.Redirect("materiales.aspx?categoria=" + material.Categoria.Id.ToString());
                    }
                }
            }
            else
                Response.Write(resultado);
        }

        private bool validarMaterial(ENMaterial material)
        {
            // Validamos el nombre
            if (material.Nombre.Length > ENMaterial.maxTamNombre || material.Nombre.Length < ENMaterial.minTamNombre)
            {
                Panel_errorNombre.Visible = true;
                Label_errorNombre.Text = "Nombre: Debe tener entre " + ENMaterial.minTamNombre.ToString() + " y " + ENMaterial.maxTamNombre + " caracteres";
            }
            return false;
        }
    }
}