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

public partial class crearhilo : WebCacatUA.InterfazWeb
{
    private ENCategoria categoria;

    private void escribir(string cadena)
    {
        const string fic = @"C:\log.txt";
        System.IO.StreamWriter sw = new System.IO.StreamWriter(fic, true);
        sw.WriteLine(cadena);
        sw.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("foro.aspx");
        }
    }

    private bool validarFormulario()
    {
        bool correcto = true;

        Label_tituloError.Visible = false;
        Label_textoError.Visible = false;

        if (TextBox_titulo.Text.Length <= 0 || TextBox_titulo.Text.Length >= 200)
        {
            Label_tituloError.Visible = true;
            correcto = false;
        }

        if (TextBox_texto.Text.Length <= 0 || TextBox_texto.Text.Length >= 5000)
        {
            Label_textoError.Visible = true;
            correcto = false;
        }

        return correcto;
    }

    protected void Button_enviar_Click(object sender, EventArgs e)
    {
        string rutaRedireccion = "";

        categoria = null;
        try
        {
            categoria = ENCategoria.Obtener(int.Parse(Request["categoria"].ToString()));

            // Comprobamos si se ha pulsado el botón "Enviar".
            if (Page.IsPostBack)
            {
                TextBox_titulo.Text = filtrarCadena(TextBox_titulo.Text);
                TextBox_texto.Text = filtrarCadena(TextBox_texto.Text);
                if (validarFormulario())
                {
                    ENHilo hilo = new ENHilo();
                    hilo.Texto = TextBox_texto.Text;
                    hilo.Titulo = TextBox_titulo.Text;
                    hilo.Categoria = categoria;

                    hilo.Autor = ENUsuario.Obtener(Session["usuario"].ToString());
                    if (hilo.Guardar())
                    {
                        rutaRedireccion = "hilo.aspx?id=" + hilo.Id;
                    }
                    else
                    {
                        Panel_noCreado.Visible = true;
                        Panel_contenidoCrearHilo.Visible = false;
                    }
                }
            }
        }
        catch (Exception)
        {
            Response.Redirect("foro.aspx");
        }
        finally
        {
            if (rutaRedireccion != "")
                Response.Redirect(rutaRedireccion);
        }
    }
}