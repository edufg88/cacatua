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
                if (Request.Params["categoria"] != null)
                {
                    int idCategoria = int.Parse(Request.Params["categoria"].ToString());
                    Hidden_categoria.Value = idCategoria.ToString();
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
            TextBox_archivo.Text = "";
            TextBox_referencia.Text = "";
            TextArea_descripcion.Value = "";
        }

        protected void Uploader1_FileUploaded(object sender, CuteWebUI.UploaderEventArgs args)
        {
            Response.Write("fichero subido" + args.FileName + args.FileSize);
            TextBox_archivo.Text = args.FileName;
            args.CopyTo("~/materiales/" + args.FileName + "_jose");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Comprobamos si existe el fichero
            FileInfo info = new FileInfo(MapPath("~/materiales/") + TextBox_archivo.Text + "_jose");
            if (info.Exists)
            {
                // Creamos el material en la base de datos para obtener el id
                ENMaterial material = new ENMaterial();
                material.Nombre = TextBox_nombre.Text;
                material.Usuario = ENUsuario.Obtener("jose");
                material.Categoria = ENCategoria.Obtener(int.Parse(Hidden_categoria.Value.ToString()));
                material.Descripcion = TextArea_descripcion.Value;
                material.Referencia = TextBox_referencia.Text;
                material.Archivo = TextBox_archivo.Text;
                material.Tamaño = (int)info.Length;
                Response.Write(material.Nombre);
                if (material.Guardar() == true)
                {
                    int id = material.CompletarGuardar();
                    // Comprimimos el archivo con la id
                    ComprimirArchivo(material.Archivo + "_jose", id, material.Archivo);
                    // Borramos el fichero temporal
                    info.Delete();
                    // Recargamos la página
                    Response.Redirect("materiales.aspx?categoria=" + material.Categoria.Id.ToString());
                }
            }
            else
                Response.Write("No existe el fichero");
        }

        public string ComprimirArchivo(string ficheroComprimir, int id, string nombreFichero)
        {
            string directorioFicheros = MapPath("~/materiales/");
            string error = "OK";
            ZipOutputStream zipOutputStream = null;
            try
            {
                // Obtenemos la ruta completa que va a tener el nuevo fichero
                string rutaZip = directorioFicheros + id.ToString() + ".zip";
                // Creamos el zip
                zipOutputStream = new ZipOutputStream(File.Create(rutaZip));
                // Especificamos el nivel de compresión (entre 0 - 9(máxima compresión))
                zipOutputStream.SetLevel(6);

                // Abrimos el fichero que vamos a comprimir
                FileStream fileStream = File.OpenRead(directorioFicheros + ficheroComprimir);
                // Creamos un buffer donde vamos a guardar el contenido del fichero
                byte[] buffer = new byte[(Convert.ToInt32(fileStream.Length))];
                // Cargamos el fichero en el buffer
                fileStream.Read(buffer, 0, buffer.Length);
                // Cerramos el fichero
                fileStream.Close();

                // Añadimos el fichero al zip con el nombre que se pasa por parámetro
                ZipEntry theEntry = new ZipEntry(nombreFichero);
                theEntry.DateTime = DateTime.Now;
                zipOutputStream.PutNextEntry(theEntry);
                zipOutputStream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                error = ex.ToString();
            }
            finally
            {
                if (zipOutputStream != null)
                {
                    zipOutputStream.Finish();
                    zipOutputStream.Close();
                }
            }
            return error;
        }
    }
}