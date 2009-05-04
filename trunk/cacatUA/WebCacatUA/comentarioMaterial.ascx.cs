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
    public partial class comentarioMaterial : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void inicializar(ComentarioMaterial comentario)
        {
            Label_comentario.Text = comentario.Texto;
            Label_fecha.Text = comentario.Fecha.ToString();
            HyperLink_usuario.NavigateUrl = "usuario.aspx?id=" + comentario.Usuario.Id;
            HyperLink_usuario.Text = comentario.Usuario.Usuario;
            Image_perfil.ImageUrl = "~/imagenes/sinImagen.png";
        }
    }
}