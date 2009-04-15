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
        FileStream fStream = null;
        string error = "";
        private bool cancelar;

        public FormMaterialesUpload(ENMaterial material)
        {
            InitializeComponent();
            this.material = material;
            cancelar = false;
            Thread thread = new Thread(new ThreadStart(subirArchivo));
            thread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cancelamos la transacción
            cancelar = true;

            this.Close();
        }

        private void subirArchivo()
        {
            String strFile = System.IO.Path.GetFileName(material.Archivo);
            Uploader.FileUploader fileUploader = new Uploader.FileUploader();
            try
            {               
                //strFile.Insert(0, material.Id.ToString() + "_" + material.Usuario.Usuario + "_");
                // Creamos una instacia del servicio web
                

                // Obtenemos información del fichero
                FileInfo fileInfo = new FileInfo(material.Archivo);

                // Obtenemos el tamaño del fichero
                long numBytes = fileInfo.Length;
                double dLen = Convert.ToDouble(fileInfo.Length / 1000000);

                if (dLen < 16)
                {

                    /*
                    fStream = new FileStream(material.Archivo, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);

                    // Convertimos el fichero en un array de bytes
                    byte[] data = br.ReadBytes((int)numBytes);
                    br.Close();
                    */

                    // Pasamos el array de bytes y el nombre del fichero al servicio web
                    Console.WriteLine("Tiene: " + numBytes.ToString() + " bytes");
                    fStream = new FileStream(material.Archivo, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);

                    string sTmp = "";
                    long bytesRestantes = numBytes;
                    long bytesEscritos = 0;
                    while (bytesRestantes > 0 && cancelar == false)
                    {
                        // Convertimos el fichero en un array de bytes
                        if (bytesRestantes > 10024)
                        {
                            byte[] data = br.ReadBytes((int)10024);
                            sTmp = fileUploader.subirArchivo(data, strFile);
                            bytesRestantes -= 10024;
                            bytesEscritos += 10024;
                        }
                        else
                        {
                            byte[] data = br.ReadBytes((int)bytesRestantes);
                            sTmp = fileUploader.subirArchivo(data, strFile);
                            MessageBox.Show(sTmp);
                            bytesRestantes = 0;
                            bytesEscritos = numBytes;
                        }
                        // Actualizamos el progressbar
                        progressBar.Value = (int)((100 * bytesEscritos) / numBytes);
                        Console.WriteLine(progressBar.Value);
                    }
                    br.Close();
                    fStream.Close();
                    fStream.Dispose();
                    if (cancelar == true)
                    {
                        // Cancelamos la transacción
                        material.CancelarGuardar();
                        // Borramos el fichero del servidor
                        if (fileUploader.BorrarFichero(strFile) == false)
                            MessageBox.Show("ERROR: No se ha podido borrar el archivo");
                    }
                    else
                    {
                        // Comprimimos el archivo
                        MessageBox.Show(fileUploader.ComprimirArchivo(strFile));
                        // Completamos la transacción
                        material.CompletarGuardar();
                    }
                }
                else
                {
                    error = "Fichero demasiado grande";
                }
            }
            catch (Exception ex)
            {
                // display an error message to the user
                error = "ERROR";
                MessageBox.Show(ex.Message.ToString(), "Upload Errorr");
            } 
            finally
            {
                this.Close();
                if (error != "")
                {
                    material.CancelarGuardar();
                }
            }
        }
    }
}
