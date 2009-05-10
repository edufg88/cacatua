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
using Libreria;

public partial class PaginaMaestra : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Label_infoLogin.Text = "";

        if (Session["usuario"] != null)
        {
            CargarFormaLogout();
        }
        else
        {
            CargarFormaLogin();
        }
    }

    protected void CargarFormaLogout()
    {
        Label_infoLogin.Text = "";

        // Escondemos los botones y textbox
        TextBox_usuario.Visible = false;
        TextBox_contrasena.Visible = false;
        Button_entrar.Visible = false;
        Button_registrarse.Visible = false;

        // Mostramos el boton de logout y la información del login
        Label_infoLogin.Text = "Usuario conectado:  " + Session["usuario"];
        Label_infoLogin.ForeColor = System.Drawing.Color.Chocolate;
        Label_iniciarSesion.Visible = false;
        Button_logout.Visible = true;
    }

    protected void CargarFormaLogin()
    {
        // Volvemos a mostrar los campos para el login
        Button_logout.Visible = false;
        TextBox_usuario.Visible = true;
        TextBox_contrasena.Visible = true;
        Button_entrar.Visible = true;
        Button_registrarse.Visible = true;
        Label_iniciarSesion.Visible = true;
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
    protected bool ValidarLogin()
    {
        string usuario = TextBox_usuario.Text;
        string contrasena = TextBox_contrasena.Text;

        if (ENUsuario.ComprobarUsuario(usuario, contrasena))
        {
            // Metemos el usuario en una variable de sesión
            Session["usuario"] = usuario;
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void Button_entrar_Click(object sender, EventArgs e)
    {
        if (ValidarLogin())
        {
            // Mostramos el usuario y la opción de logout
            CargarFormaLogout();
           
            //Aquí vamos a la página de inicio del usuario que ha hecho login
            Response.Redirect("index.aspx");
        }
        else
        {
            Label_infoLogin.Text = "ERROR: usuario o contraseña incorrectos";
            Label_infoLogin.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void Button_registrarse_Click(object sender, EventArgs e)
    {
        // Accedemos a la página de registro de usuarios
        Response.Redirect("registroUsuario.aspx");
    }
    protected void Button_logout_Click(object sender, EventArgs e)
    {
        // Borramos la variable de sesión del usuario
        Session.Remove("usuario");

        // Habilitamos los formularios para login
        CargarFormaLogin();

        Response.Redirect("index.aspx");
    }
}
