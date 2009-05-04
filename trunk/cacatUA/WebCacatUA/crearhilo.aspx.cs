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
        Panel_sinCategoria.Visible = false;
        Panel_contenidoCrearHilo.Visible = false;
        Panel_creadoCorrectamente.Visible = false;
        Panel_noCreado.Visible = false;

        categoria = null;
        try
        {
            categoria = ENCategoria.Obtener(int.Parse(Request["categoria"].ToString()));
            
            if (!Page.IsPostBack)
            {
                Panel_contenidoCrearHilo.Visible = true;
            }
            else
            {
                ENHilo hilo = new ENHilo();
                hilo.Texto = TextBox_texto.Text;
                hilo.Titulo = TextBox_titulo.Text;
                hilo.Categoria = categoria;

                hilo.Autor = ENUsuario.Obtener((DateTime.Now.Millisecond % 7)+1);
                if (hilo.Guardar())
                {
                    Panel_creadoCorrectamente.Visible = true;
                }
                else
                {
                    Panel_noCreado.Visible = true;
                }
            }
        }
        catch (Exception)
        {
            Panel_sinCategoria.Visible = true;
        }
    }
}