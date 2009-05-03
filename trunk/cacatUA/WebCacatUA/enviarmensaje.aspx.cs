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
    protected void Page_Load(object sender, EventArgs e)
    {
        Label_para.Text = Request.QueryString["usuario"];
        TextBox_mensaje.Text = "";
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string emisor = Session["usuario"].ToString();
        ENMensaje mensaje = new ENMensaje(emisor, TextBox_mensaje.Text, DateTime.Now, Request.QueryString["usuario"]);
        mensaje.Guardar();
    }

    protected void Button_borar_Click(object sender, EventArgs e)
    {
        TextBox_mensaje.Text = "";
    }
}

