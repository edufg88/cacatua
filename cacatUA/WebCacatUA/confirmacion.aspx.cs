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

public partial class confirmacion : WebCacatUA.InterfazWeb
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["inscribir"] != null)
        {
            ENGrupos grupo = ENGrupos.Obtener(int.Parse(Request.QueryString["inscribir"]));
            Label_confirmacion.Text = Resources.I18N.InscribirGrupo + " " + grupo.Nombre;
            HyperLink_confirmacion.Text = Resources.I18N.PulsarVolver;
            HyperLink_confirmacion.NavigateUrl = "grupo.aspx?id=" + grupo.Id;
        }
        else if (Request.QueryString["desapuntar"] != null)
        {
            ENGrupos grupo = ENGrupos.Obtener(int.Parse(Request.QueryString["desapuntar"]));
            Label_confirmacion.Text = Resources.I18N.DesapuntarGrupo + " " + grupo.Nombre;
            HyperLink_confirmacion.Text = Resources.I18N.PulsarVolver;
            HyperLink_confirmacion.NavigateUrl = "grupo.aspx?id=" + grupo.Id;
        }
        else if (Request.QueryString["mensajegrupo"] != null)
        {
            ENGrupos grupo = ENGrupos.Obtener(int.Parse(Request.QueryString["mensajegrupo"]));
            Label_confirmacion.Text = Resources.I18N.MensajeEnviadoGrupo + " " + grupo.Nombre;
            HyperLink_confirmacion.Text = Resources.I18N.PulsarVolver;
            HyperLink_confirmacion.NavigateUrl = "grupo.aspx?id=" + grupo.Id;
        }
        else if (Request.QueryString["mensajeusuario"] != null)
        {
            ENUsuario usuario = ENUsuario.Obtener(Request.QueryString["mensajeusuario"].ToString());
            Label_confirmacion.Text = Resources.I18N.MensajeEnviadoUsuario + " " + usuario.Usuario;
            HyperLink_confirmacion.Text = Resources.I18N.PulsarVolver;
            HyperLink_confirmacion.NavigateUrl = "usuario.aspx?usuario=" + usuario.Usuario;
        }
        else if (Request.QueryString["creargrupo"] != null)
        {
            Label_confirmacion.Text = Resources.I18N.GrupoCreado;
            HyperLink_confirmacion.Text = Resources.I18N.PulsarVolver;
            HyperLink_confirmacion.NavigateUrl = "grupos.aspx";
        }
        else if (Request.QueryString["registrousuario"] != null)
        {
            Label_confirmacion.Text = Resources.I18N.UsuarioRegistrado;
            HyperLink_confirmacion.Text = Resources.I18N.PulsarVolver;
            HyperLink_confirmacion.NavigateUrl = "index.aspx";
        }
        else if (Request.QueryString["mensajeerror"] != null)
        {
            if (int.Parse(Request.QueryString["mensajeerror"].ToString()) == 1)
            {
                Label_confirmacion.Text = Resources.I18N.MensajeErrorLogeado;
                HyperLink_confirmacion.Text = Resources.I18N.PulsarVolver;
                HyperLink_confirmacion.NavigateUrl = "index.aspx";
            }
            else
            {
                Label_confirmacion.Text = Resources.I18N.MensajeErrorMismoUsuario;
                HyperLink_confirmacion.Text = Resources.I18N.PulsarVolver;
                HyperLink_confirmacion.NavigateUrl = "usuario.aspx";
            }
        }
        else
        {
            Response.Redirect("index.aspx");
        }
    }
}

