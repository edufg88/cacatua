﻿using System;
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

public partial class PaginaMaestra : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
           
    }

    protected void RefrescarPagina()
    {
        string[] arrResult = HttpContext.Current.Request.RawUrl.Split('/');
        String result = arrResult[arrResult.GetUpperBound(0)];
        arrResult = result.Split('?');
        Response.Redirect(arrResult[arrResult.GetLowerBound(0)]);
    }

    protected void ImageButton_Español_Click(object sender, ImageClickEventArgs e)
    {
        Session["idioma"] = "es";
        RefrescarPagina();
    }

    protected void ImageButton_Ingles_Click(object sender, ImageClickEventArgs e)
    {
        Session["idioma"] = "en";
        RefrescarPagina();
    }

    /// <summary>
    /// Valida el usuario y la contraseña de un login en el lado del servidor
    /// </summary>
    protected void ValidarLogin()
    { 
    
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("registroUsuario.aspx");
    }
}
