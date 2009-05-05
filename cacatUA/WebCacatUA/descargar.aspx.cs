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
    public partial class descargar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] != null)
            {
                int id = int.Parse(Request.Params["id"].ToString());
                Descargar(id);
            }
        }

        private int Descargar(int id)
        {
            // Obtenemos el material a descargar
            ENMaterial material = ENMaterial.Obtener(id);
            if (material != null)
            {
                string url = @"materiales\" + material.Archivo;
                // Incrementamos el número de descargas
                material.Descargas++;
                // Actualizamos el material en la base de datos
                material.Actualizar();
                Response.Redirect(url);
                return material.Descargas;
            }
            return 0;
        }
    }
}
