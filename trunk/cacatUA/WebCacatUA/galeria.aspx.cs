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

namespace WebCacatUA
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Table1.Attributes.Add("widht", "90%");
            TableRow r = new TableRow();
            TableCell c = new TableCell();

            c.Controls.Add(new LiteralControl("<img src=\"/imagenes/botonanterioresfotos.png\" alt=\"\" />"));
            r.Controls.Add(c);

            for (int i = 1; i <= 10; i++)
            {
                c = new TableCell();
                c.Controls.Add(new LiteralControl("<img onclick=\"funcion(" + i + ")\" height=\"38px\" src=\"/imagenes/" + i + ".jpg\" alt=\"\" />"));
                r.Controls.Add(c);
            }
            
            c = new TableCell();
            c.Controls.Add(new LiteralControl("<td><img src=\"/imagenes/botonsiguientesfotos.png\" alt=\"\" /></td>"));
            r.Controls.Add(c);

            Table1.Controls.Add(r);

        }
    }
}
