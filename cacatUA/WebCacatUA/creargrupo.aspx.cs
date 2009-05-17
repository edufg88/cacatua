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

public partial class creargrupo : WebCacatUA.InterfazWeb
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
            Response.Redirect("grupos.aspx");
    }

    private void Limpiar()
    {
        TextBox_nombre.Text = "";
        TextBox_descripcion.Text = "";
        Label_infoGrupo.Text = "";
    }

    protected void Button_limpiar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }

    protected void Button_crear_Click(object sender, EventArgs e)
    {
        ENUsuario usuario = ENUsuario.Obtener(Session["usuario"].ToString());
        ArrayList aux = new ArrayList();
        aux.Add(usuario);
        ENGrupos grupo = new ENGrupos(TextBox_nombre.Text, TextBox_descripcion.Text, DateTime.Now, aux);

        if (!grupo.Existe())
        {
            grupo.Guardar();
            Response.Redirect("confirmacion.aspx?creargrupo=1");
        }
        else
            Label_infoGrupo.Text = Resources.I18N.GrupoExiste;
    }
}

