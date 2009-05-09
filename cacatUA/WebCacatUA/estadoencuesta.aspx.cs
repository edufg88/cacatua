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
    public partial class estadoencuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String id = (String)Request["id"];
            String u = (String)Session["usuario"];

            if (id != null && u != null)
            {
                int idEnc = int.Parse(id);
                ENEncuesta encuesta = ENEncuesta.Obtener(idEnc);

                if (encuesta.DeUsuario(ENUsuario.Obtener(u)))
                {
                    encuesta.Activa = !encuesta.Activa;
                    encuesta.Actualizar();
                }
            }
            else
            {
                Response.Redirect("index.aspx");
            }

            Response.Redirect("encuestas.aspx");
        }
    }
}
