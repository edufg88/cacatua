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
    public partial class editarencuesta : InterfazWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String id = (String)Request["id"];
            if (id != null)
            {
                int idEnc = int.Parse(id);
                CargarEncuesta(ENEncuesta.Obtener(idEnc));
            }
        }

        private void CargarEncuesta(ENEncuesta encuesta)
        {
            String codigo;

            codigo = "Editando encuesta " + encuesta.Id + "<br/>";
            codigo += "<p>" + encuesta.Pregunta + "<br/><blockquote>";
            foreach (OpcionEncuesta opc in encuesta.Opciones())
            {
                codigo += "<li>" + opc.Opcion + "</li>";
            }
            codigo += "</blockquote></p>";
            Label_Texto.Text = codigo;

        }
    }
}
