using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Libreria;

namespace cacatUA
{
    public partial class FormMaterialesUpload : Form
    {
        ENMaterial material;
        private string error = "OK";
        public string Error
        {
            get { return error; }
        }

        private bool cancelar;
        int maxTamañoPaquete = 30000; // en bytes
        int maxTamañoFichero = 30; // en megabytes

        public enum modos { ACTUALIZAR = 0, CREAR = 1};
        private modos modo;
        public modos Modo
        {
            get { return modo; }
            set { modo = value; }
        }

        public FormMaterialesUpload(ENMaterial material,modos modo)
        {
            InitializeComponent();
            this.material = material;
            cancelar = false;
            this.modo = modo;
            Thread thread = new Thread(new ThreadStart(subirArchivo));
            thread.Start();
        }

        private void subirArchivo()
        {
            try
            {
                // Creamos una instancia del servicio web que nos permite subir el archivo
                Uploader.FileUploader fileUploader = new Uploader.FileUploader();

                // Obtenemos la ruta del archivo
                string rutaArchivo = material.Archivo;
                // Obtenemos únicamente el nombre del archivo (sin la ruta)
                string nombreArchivo = Path.GetFileName(rutaArchivo);
                // Creamos un nombre de archivo temporal para que no sobreescriba a otro añadiendo el id del usuario
                string nombreArchivoTemporal = nombreArchivo + "_" + material.Usuario.Id.ToString();

                // Obtenemos información del archivo
                FileInfo fileInfo = new FileInfo(rutaArchivo);

                // Obtenemos el tamaño del archivo
                long numBytes = fileInfo.Length;
                // Convertimos a megabytes
                int numMB = Convert.ToInt32(numBytes / 1048576);
                if (numMB < maxTamañoFichero)
                {
                    // Abrimos y leemos el fichero (binario)
                    FileStream fileStream = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader(fileStream);

                    // Inicializamos los contadores
                    long bytesRestantes = numBytes;
                    long bytesEnviados = 0;

                    // Mientras queden bytes por enviar y no se cancele la subida, enviamos más datos
                    while (bytesRestantes > 0 && cancelar == false)
                    {
                        // Vamos a enviar el número máximo de bytes que podamos
                        long bytesEnviar = maxTamañoPaquete;

                        // En caso de que el número de bytes restantes sea menor que el tamaño del paquete, cambiamos
                        if(bytesRestantes < maxTamañoPaquete)
                            bytesEnviar = bytesRestantes;

                        // Leemos del fichero los datos a enviar
                        byte[] datos = binaryReader.ReadBytes((int)bytesEnviar);

                        // Enviamos los datos
                        string mensaje = fileUploader.subirArchivo(datos, nombreArchivoTemporal);
                        if(mensaje == "OK")
                        {
                            // Decrementamos el número de bytes que faltan por enviar
                            bytesRestantes -= bytesEnviar;
                            // Incrementamos el número de bytes enviados
                            bytesEnviados += bytesEnviar;
                            // Actualizamos la barra de progreso
                            progressBar.Value = (int)((100 * bytesEnviados) / numBytes);
                        }
                        else
                        {
                            // Se ha producido un error al subir el archivo, cancelamos
                            error = "Ha habido un problema al subir el archivo: ";
                            error += mensaje;
                            cancelar = true;
                        }
                    }

                    // Cerramos los ficheros
                    binaryReader.Close();
                    fileStream.Close();
                    fileStream.Dispose();

                    // Comprobamos si se ha subido el archivo correctamente o bien se ha cancelado
                    if (cancelar == true)
                    {
                        if(error == "OK")
                            error = "Cancelado por el usuario";
                        // El archivo ha sido cancelado por algún motivo
                        // Comprobamos si se estaba subiendo un nuevo archivo o actualizando
                        if (modo == modos.CREAR)
                        {
                            // Se estaba creando un nuevo archivo, cancelamos la transacción para que no se guarde en la bd
                            material.CancelarGuardar();
                        }
                        // Borramos el fichero del servidor
                        if (fileUploader.existeFichero(nombreArchivoTemporal))
                        {
                            if (fileUploader.BorrarFichero(nombreArchivoTemporal) == false)
                                error = "Ha habido un problema al borrar el fichero en el servidor";
                        }
                    }
                    else
                    {
                        
                        // El archivo se ha subido correctamente
                        // Comprobamos si se estaba creando uno nuevo o actualizando
                        if (modo == modos.CREAR)
                        {
                            // Desactivamos el botón de cancelar
                            button_cancelar.Enabled = false;
                            // Completamos la transacción y obtenemos la id que va a tener el archivo
                            int id = material.CompletarGuardar();
                            if (id >= 0)
                            {                           
                                // Comprimimos el archivo con el id
                                if (fileUploader.ComprimirArchivo(nombreArchivoTemporal, id, nombreArchivo) != "OK")
                                    error = "Ha habido un problema al comprimir el fichero en el servidor";
                                // Borramos el archivo temporal
                                if (fileUploader.BorrarFichero(nombreArchivoTemporal) == false)
                                    error = "Ha habido un problema al borrar el fichero en el servidor";
                            }
                            else
                                error = "Ha habido un problema al crear el fichero en el servidor";
                        }
                        else
                        {
                            // Estamos actualizando el fichero, borramos el fichero que tenga esa id
                            if (fileUploader.BorrarFichero(material.Id + ".zip") == false)
                                error = "Ha habido un problema al borrar el fichero en el servidor";                         
                            // Comprimimos el archivo
                            if (fileUploader.ComprimirArchivo(nombreArchivoTemporal, material.Id, nombreArchivo) != "OK")
                                error = "Ha habido un problema al comprimir el fichero en el servidor";
                            // Borramos el archivo temporal
                            if (fileUploader.BorrarFichero(nombreArchivoTemporal) == false)
                                error = "Ha habido un problema al borrar el fichero en el servidor";
                        }
                    }
                }
                else
                {
                    error = "Fichero demasiado grande";
                }
                this.Close();
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
            }
            finally
            {
                this.Close();
                if (error != "OK")
                {
                    if(modo == modos.CREAR)
                        material.CancelarGuardar();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cancelamos la transacción
            cancelar = true;
        }
    }
}
