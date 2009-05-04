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
        protected void Page_Load(object sender, EventArgs e)
        {

            ArrayList fotos = new ArrayList();
            fotos = ENImagen.Obtener();

            Table1.Attributes.Add("widht", "90%");
            TableRow r = new TableRow();
            TableCell c = new TableCell();

            c.Controls.Add(new LiteralControl("<img src=\"/imagenes/botonanterioresfotos.png\" alt=\"\" />"));
            r.Controls.Add(c);
            int cont=1;
            foreach(ENImagen i in fotos)
            {
            
                c = new TableCell();
                c.Controls.Add(new LiteralControl("<img onclick=\"funcion(" + i.Id + ")\" height=\"38px\" src=\""+ i.Archivo +"\".jpg\" alt=\"" + i.Titulo + "\" />"));
                r.Controls.Add(c);

                if(cont%10==0)
                {
                    Table1.Controls.Add(r);
                r = new TableRow();
                }

                cont++;
                
            }
            
            //c = new TableCell();
            //c.Controls.Add(new LiteralControl("<td><img src=\"/imagenes/botonsiguientesfotos.png\" alt=\"\" /></td>"));
            r.Controls.Add(c);

            Table1.Controls.Add(r);

        }
    }
}
