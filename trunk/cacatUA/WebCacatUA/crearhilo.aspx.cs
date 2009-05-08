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

        Panel_creadoCorrectamente.Visible = false;
        Panel_noCreado.Visible = false;

        categoria = null;
        try
        {
            categoria = ENCategoria.Obtener(int.Parse(Request["categoria"].ToString()));
            
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

                    hilo.Autor = ENUsuario.Obtener((DateTime.Now.Millisecond % 7) + 1);
                    if (hilo.Guardar())
                    {
                        Panel_contenidoCrearHilo.Visible = false;
                        Panel_creadoCorrectamente.Visible = true;
                        HyperLink_verHilo.NavigateUrl = "hilo.aspx?id=" + hilo.Id;
                    }
                    else
                    {
                        Panel_noCreado.Visible = true;
                    }
                }
            }
        }
        catch (Exception)
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
}