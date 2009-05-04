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
    public partial class materialBusqueda : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void inicializar(ENMaterial material)
        {
            HyperLink_material.Text = material.Nombre;
            HyperLink_material.NavigateUrl = "mostrarMaterial.aspx?id=" + material.Id;
            Label_descripcion.Text = material.Descripcion;
            Label_fecha.Text = material.Fecha.ToString();
            Label_usuario.Text = material.Usuario.Usuario;
            Label_descargas.Text = material.Descargas.ToString();
            Label_puntuacion.Text = material.Puntuacion.ToString();
            Label_votos.Text = material.Votos.ToString() + " votos";
            HyperLink_categoria.Text = material.Categoria.Nombre;
            HyperLink_categoria.NavigateUrl = "materiales.aspx?categoria=" + material.Categoria.Id;
        }
    }
}