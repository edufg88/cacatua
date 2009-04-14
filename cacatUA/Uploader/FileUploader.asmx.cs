using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO;

namespace Uploader
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://84.120.44.73")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FileUploader : System.Web.Services.WebService
    {

        [WebMethod]
        public string subirArchivo(byte[] datos, string fileName)
        {
            try
            {
                MemoryStream ms = new MemoryStream(datos);
                FileStream fs = new FileStream
                    (System.Web.Hosting.HostingEnvironment.MapPath("~/ficheros/") +
                    fileName, FileMode.Append);
  
                ms.WriteTo(fs);
                ms.Close();
                fs.Close();
                fs.Dispose();
                return "OKk";
            }
            catch (Exception ex)
            {
                return "error: " + ex.Message.ToString();
            }
        }

        [WebMethod]
        public string Hola()
        {
            return "hola";
        }

        [WebMethod]
        public bool BorrarFichero(string nombreFichero)
        {
            bool borrado = false;
            // Localizamos el fichero en el servidor
            try
            {
                FileInfo info = new FileInfo(System.Web.Hosting.HostingEnvironment.MapPath("~/ficheros/") + nombreFichero);
                if (info.Exists)
                {
                    info.Delete();
                    borrado = true;
                }
            }
            catch (Exception)
            {

            }
            return borrado;
        }
    }
}
