using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Hosting;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace WebCacatUA
{
    /// <summary>
    /// Summary description for Uploader
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Uploader : System.Web.Services.WebService
    {
        private string directorioFicheros = HostingEnvironment.MapPath("~/materiales/");

        /// <summary>
        /// Sube un archivo al servidor iis. Es posible que para subir un archivo se llame a esta función x veces,
        /// y en cada llamada enviar x datos. Por tanto, en las siguientes llamadas si existe ya un archivo con ese
        /// nombre, no se creará uno nuevo, si no que se continuará escribiendo al final de este.
        /// En la aplicación cacatua, debido a que el nombre del fichero es el id, nunca sucederá que haya dos archivos
        /// con el mismo nombre. 
        /// Hay ciertos casos que debemos de controlar con respecto al proyecto cacatua:
        ///     1- En caso de que un usuario suba un archivo que se llame 1.zip y en el servidor haya otro archivo
        ///     que se llame 1.zip, lo sobreescribirá. Para solucionar esto lo que se debe hacer es que cuando se
        ///     sube un archivo, se le ponga la extensión 1.zip_temp de forma que ya no se sobreescribe a ninguno.
        ///     2- Puede darse el caso de que se suban dos ficheros temporales 1.zip_temp y 1.zip_temp a la vez
        ///     por dos usuarios distintos, con lo que obtendriamos un fichero defectuoso.
        /// Para solucionar los problemas 1 y 2, lo que se va a hacer es en vez de añadir la extensión _temp,
        /// añadir el id del usuario en la extensión. 1.zip_12
        /// Con esta solución sólo habría problemas en caso de que un mismo usuario, subiera el mismo archivo en 
        /// distintas ejecuciones del programa al mismo tiempo, pero es una cosa que no vamos a controlar porque
        /// no se va a permitir que ejecute distintas instancias del programa.
        /// </summary>
        /// <param name="datos">Array de bytes con los datos del archivo a subir.</param>
        /// <param name="nombreFichero">Nombre del fichero que se va a crear en el servidor y donde se van a escribir
        /// los datos del array.</param>
        /// <returns>Devuelve "OK" si se ha subido correctamente o un mensaje con el error</returns>
        [WebMethod]
        public string subirArchivo(byte[] datos, string nombreFichero)
        {
            string error = "OK";
            try
            {
                // Cargamos los datos en memoria
                MemoryStream memoryStream = new MemoryStream(datos);
                // Abrimos el fichero (en caso de que exista, escribiremos al final)
                FileStream fileStream = new FileStream(directorioFicheros + nombreFichero, FileMode.Append);
                // Escribimos en el fichero los datos
                memoryStream.WriteTo(fileStream);
                // Cerramos el fichero y la memoryStream
                memoryStream.Close();
                fileStream.Close();
                fileStream.Dispose();
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
            }
            return error;
        }

        /// <summary>
        /// Comprime un archivo que está alojado en el servidor iis.
        /// </summary>
        /// <param name="ficheroComprimir">Nombre del fichero que vamos a comprimir y que debe existir en el servidor.</param>
        /// <param name="id">Nombre que va a tener el zip. Se emplea el id del material para que no haya ningún zip repetido.</param>
        /// <param name="nombreFichero">Nombre del fichero que va a contener el zip. Es posible que el fichero a comprimir se llame
        /// hola.zip_2, pero queremos que dentro del zip aparezca hola.zip o cualquier otro nombre.</param>
        /// <returns>Devuelve "OK" si se ha comprimido correctamente o un mensaje con el error</returns>
        [WebMethod]
        public string ComprimirArchivo(string ficheroComprimir, int id, string nombreFichero)
        {
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

        /// <summary>
        /// Borra un fichero que esté alojado en el servidor iis.
        /// </summary>
        /// <param name="nombreFichero">Nombre del fichero que vamos a borrar.</param>
        /// <returns>Devuelve true si se ha borrado o false en caso contrario</returns>
        [WebMethod]
        public bool BorrarFichero(string nombreFichero)
        {
            bool borrado = false;
            // Localizamos el fichero en el servidor
            try
            {
                FileInfo info = new FileInfo(directorioFicheros + nombreFichero);
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

        /// <summary>
        /// Comprueba si existe un fichero en el servidor iis.
        /// </summary>
        /// <param name="nombreFichero">Nombre del fichero que queremos comprobar si existe.</param>
        /// <returns>Devuelve true si existe o false en caso contrario</returns>
        [WebMethod]
        public bool existeFichero(string nombreFichero)
        {
            bool existe = false;
            try
            {
                FileInfo info = new FileInfo(directorioFicheros + nombreFichero);
                existe = info.Exists;
            }
            catch (Exception)
            {

            }
            return existe;

        }

        /// <summary>
        /// Obtenemos la ruta completa del directorio donde se pueden subir los archivos en el servidor
        /// </summary>
        public string DirectorioFicheros
        {
            get { return directorioFicheros; }
        }
    }
}
