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


public partial class enviarmensaje : WebCacatUA.InterfazWeb
{
    bool usuario = true;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] != null && Request.QueryString["usuario"].ToString()!=Session["usuario"].ToString())
        {
            if (Request.QueryString["usuario"] != null)
            {
                Label_para.Text = Request.QueryString["usuario"];
            }
            else
            {
                Label_para.Text = Request.QueryString["grupo"];
                usuario = false;
            }
        }
        else if (Session["usuario"] == null)
        {
            Response.Redirect("confirmacion.aspx?mensajeerror=1");
        }
        else
        {
            Response.Redirect("confirmacion.aspx?mensajeerror=2");
        }
    }

    protected void Button_borrar_Click(object sender, EventArgs e)
    {
        TextBox_mensaje.Text = "";
    }

    protected void Button_enviar_Click(object sender, EventArgs e)
    {
        string text = TextBox_mensaje.Text;
        string emisor = Session["usuario"].ToString();
        if (usuario)
        {
            string receptor = Request.QueryString["usuario"];
            ENMensaje mensaje = new ENMensaje(emisor, text, DateTime.Now, receptor);
            mensaje.Guardar();
            Response.Redirect("confirmacion.aspx?mensajeusuario=" + receptor);
        }
        else
        {
            ENGrupos grupo = ENGrupos.Obtener(int.Parse(Request.QueryString["grupo"]));
            foreach (ENUsuario user in grupo.Usuarios)
            {
                string receptor = user.Usuario;
                ENMensaje mensaje = new ENMensaje(emisor, text, DateTime.Now, receptor);
                mensaje.Guardar();
            }
            Response.Redirect("confirmacion.aspx?mensajegrupo=" + grupo.Id);
        }        
    }
}

