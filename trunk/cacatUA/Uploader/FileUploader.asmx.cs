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
using ICSharpCode.SharpZipLib.Zip;

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
                return "OK";
            }
            catch (Exception ex)
            {
                return "error: " + ex.Message.ToString();
            }
        }

        [WebMethod]
        public string ComprimirArchivo(string nombreFichero, int id)
        {
            string error = "OK";
            ZipOutputStream zipOutputStream = null;
            try
            {
                string nombreZip = System.Web.Hosting.HostingEnvironment.MapPath("~/ficheros/") + id.ToString() + ".zip";
                zipOutputStream = new ZipOutputStream(File.Create(nombreZip));
                zipOutputStream.SetLevel(6);

                FileStream fs = File.OpenRead(System.Web.Hosting.HostingEnvironment.MapPath("~/ficheros/") + nombreFichero);
                byte[] buffer = new byte[(Convert.ToInt32(fs.Length))];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                ZipEntry theEntry = new ZipEntry(nombreFichero);
                zipOutputStream.PutNextEntry(theEntry);
                zipOutputStream.Write(buffer, 0, buffer.Length);
                // se guarda con el path completo
                

                //strmFile.Close();

                //zipOutputStream.PutNextEntry(theEntry);
                //zipOutputStream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                error = ex.ToString();
            }
            finally
            {
                zipOutputStream.Finish();
                zipOutputStream.Close();
            }
            return error;
            /*
            // comprimir los ficheros del array en el zip indicado
            // si crearAuto = True, zipfile será el directorio en el que se guardará
            // y se generará automáticamente el nombre con la fecha y hora actual
            Crc32 objCrc32 = new Crc32();
            ZipOutputStream strmZipOutputStream;
            //
            if (zipFic == "")
            {
                zipFic = ".";
                crearAuto = true;
            }
            if (crearAuto)
            {
                // si hay que crear el nombre del fichero
                // éste será el path indicado y la fecha actual
                zipFic += @"\ZIP" + DateTime.Now.ToString("yyMMddHHmmss") + ".zip";
            }
            strmZipOutputStream = new ZipOutputStream(File.Create(zipFic));
            // Compression Level: 0-9
            // 0: no(Compression)
            // 9: maximum compression
            strmZipOutputStream.SetLevel(6);
            //
            foreach (string strFile in fileNames)
            {
                FileStream strmFile = File.OpenRead(strFile);
                byte[] abyBuffer = new byte[(Convert.ToInt32(strmFile.Length))];
                //
                strmFile.Read(abyBuffer, 0, abyBuffer.Length);
                //
                //              //-------------------------------------------------------------
                //              // para guardar sin el primer path
                //              string sFile = strFile;
                //              int i = sFile.IndexOf(@"\");
                //              if( i > -1)
                //              {
                //                  sFile = sFile.Substring(i + 1).TrimStart();
                //              }
                //              //-------------------------------------------------------------
                //              //
                //              //-------------------------------------------------------------
                //              // para guardar sólo el nombre del fichero
                //              // esto sólo se debe hacer si no se procesan directorios
                //              // que puedan contener nombres repetidos
                //              string sFile = Path.GetFileName(strFile);
                //              ZipEntry theEntry = new ZipEntry(sFile);
                //              //-------------------------------------------------------------
                //
                // se guarda con el path completo
                ZipEntry theEntry = new ZipEntry(strFile);
                //
                // guardar la fecha y hora de la última modificación
                FileInfo fi = new FileInfo(strFile);
                theEntry.DateTime = fi.LastWriteTime;
                //theEntry.DateTime = DateTime.Now;
                //
                theEntry.Size = strmFile.Length;
                strmFile.Close();
                objCrc32.Reset();
                objCrc32.Update(abyBuffer);
                theEntry.Crc = objCrc32.Value;
                strmZipOutputStream.PutNextEntry(theEntry);
                strmZipOutputStream.Write(abyBuffer, 0, abyBuffer.Length);
            }
            strmZipOutputStream.Finish();
            strmZipOutputStream.Close();
            */

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
