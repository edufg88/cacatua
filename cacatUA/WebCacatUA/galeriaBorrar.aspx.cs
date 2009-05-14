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
using System.IO;

namespace WebCacatUA
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["usuario"] != null && Request.Params["imagen"]!=null)
            {
                int id = int.Parse(Request.Params["imagen"].ToString());
                ENImagen img = ENImagen.Obtener(id);

                if (img.Usuario.Usuario == Session["usuario"].ToString())
                {
                    FileInfo info = new FileInfo("/galeria/" + img.Archivo);
                    if (info.Exists)
                    {
                        info.Delete();
                        
                    }
                    img.Borrar();
                    Response.Redirect("galeria.aspx?");
                }
                else
                {
                    Response.Redirect("/index.aspx");
                }
            }
            else
            {
                Response.Redirect("/index.aspx");
            }
        }
    }
}
