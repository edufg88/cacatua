using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Libreria;

namespace WebCacatUA
{
    public partial class encuestasEdicion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String u = (String)Session["usuario"];
            if (u != null)
            {
                ENUsuario usuario = ENUsuario.Obtener(u);
                Label_Texto.Text = "Bienvenido " + usuario.Usuario;
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}
