using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Libreria;


namespace WebCacatUA
{
    public partial class Formulario_web12 : InterfazWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox_tituloNuevaImagen.Text != "")
            {
                if (TextBox_descripcionNuevaImagen.Text != "")
                {
                    if ((imagen.PostedFile != null) && (imagen.PostedFile.ContentLength > 0))
                    {
                        if (imagen.PostedFile.FileName.EndsWith(".JPG") || imagen.PostedFile.FileName.EndsWith(".jpg"))
                        {
                            if (imagen.PostedFile.ContentLength <= 3000000)
                            {

                                DateTime dt = DateTime.Now;
                                string fecha = dt.Day.ToString() + dt.Month.ToString() + dt.Year.ToString() + dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString();

                                string fn = fecha + "_" + Session["usuario"].ToString() + ".jpg";

                                string SaveLocation = Server.MapPath(@"~\galeria") + "\\" + fn;
                                try
                                {

                                    ENImagen img = new ENImagen(TextBox_tituloNuevaImagen.Text, TextBox_descripcionNuevaImagen.Text, Session["usuario"].ToString(), fn, DateTime.Now);
                                    img.Guardar();
                                    imagen.PostedFile.SaveAs(SaveLocation);

                                    this.lblmessage.Text = Resources.I18N.ArchivoCargado;

                                    Response.Redirect("galeria.aspx?usuario="+ Session["usuario"].ToString());

                                }
                                catch (Exception ex)
                                {
                                    Response.Write(ex.Message);

                                }
                            }
                            else
                                this.lblmessage.Text = Resources.I18N.ErrorTamano;

                        }
                        else
                            this.lblmessage.Text = Resources.I18N.ErrorArchivo;
                    }
                    else
                    {
                        this.lblmessage.Text = Resources.I18N.FaltaArchivo;
                    }
                }
                else
                {
                    this.lblmessage.Text = Resources.I18N.FaltaDescripcion;
                }
            }
            else
            {
                this.lblmessage.Text = Resources.I18N.FaltaTitulo;
            }
        }

    }
}
