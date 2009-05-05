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
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        private ENImagen imagen = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList fotos = new ArrayList();

            if (Request.Params["usuario"] != null)
            {
                ENUsuario us = ENUsuario.Obtener(Request.Params["usuario"]);
                Label_nombreUsuario.Text = "Galeria de fotos de " + Request.Params["usuario"];
                fotos = ENImagen.ObtenerPorUsuario(us.Id);
            }
            else
            {
                fotos = ENImagen.Obtener();
            }

            Table1.Attributes.Add("widht", "90%");
            TableRow r = new TableRow();
            TableCell c = new TableCell();

            int cont=1;
            foreach(ENImagen i in fotos)
            {
                if (cont == 1)
                {
                    imagen = i;
                }                        
                c = new TableCell();
                c.Controls.Add(new LiteralControl("<img onclick=\"funcion(" + i.Id + ")\" height=\"38px\" src=\"/galeria/"+ i.Id +".jpg\" alt=\"" + i.Titulo + "\" />"));
                r.Controls.Add(c);

                if(cont%10==0)
                {
                    Table1.Controls.Add(r);
                    r = new TableRow();
                }

                cont++;
                
            }
            
            r.Controls.Add(c);

            Table1.Controls.Add(r);
            if (fotos.Count > 0)
            {
                ENImagen img = (ENImagen)fotos[0];
                Response.Write("<script type=\"text/javascript\" language=\"javascript\">var id=" + img.Id + ";</script>");
            }
            else{
                Label lab = new Label();
                lab.Text = "No hay imagenes";
                Panel1.Controls.Add(lab);
                
            }

            

        }

    }
}
