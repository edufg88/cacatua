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

public partial class usuarios : WebCacatUA.InterfazWeb
{
    private int pagina;
    private int cantidad;
    private int totalResultados;   
    private string busqueda;

    protected void Page_Load(object sender, EventArgs e)
    {
        mostrarUsuarios();
    }
    /*
    private void insertarCabecera()
    {
        // Columna del usuario
        TableCell c1 = new TableCell();
        //c1.CssClass = "";
        Label l1 = new Label();
        l1.Text = Resources.I18N.Usuario;
        Panel p1 = new Panel();
        p1.Controls.Add(l1);
        c1.Controls.Add(p1);

        // Columna del nombre
        TableCell c2 = new TableCell();
        Label l3 = new Label();
        l3.Text = Resources.I18N.Nombre;
        Panel p3 = new Panel();
        p3.Controls.Add(l3);
        c2.Controls.Add(p3);

        // Columna del email
        TableCell c3 = new TableCell();
        Label l4 = new Label();
        l4.Text = Resources.I18N.CorreoElectronico;
        Panel p4 = new Panel();
        p4.Controls.Add(l4);
        c3.Controls.Add(p4);

        // Columna con cantidad de imagenes
        TableCell c4 = new TableCell();
        Label l5 = new Label();
        l5.Text = Resources.I18N.NumeroImagenes;
        Panel p5 = new Panel();
        p5.Controls.Add(l5);
        c4.Controls.Add(p5);

        // Insertamos las columnas en la fila e insertamos la fila en la tabla.
        TableRow fila = new TableRow();
        fila.CssClass = "hiloForo";
        fila.Controls.Add(c1);
        fila.Controls.Add(c2);
        fila.Controls.Add(c3);
        fila.Controls.Add(c4);
        Table_usuarios.Controls.Add(fila);
        
    }
    */

    private void mostrarUsuarios()
    {
        foreach (ENUsuario us in ENUsuario.Obtener(1, 20))
        {
            if (us != null)
            {
                // Columna de la imágen activa del usuario
                TableCell c1 = new TableCell();
                c1.CssClass = "columna1Usuarios";
                Label l1 = new Label();
                if (us.Imagen == -1) // Comprobamos si tiene imagen activa el usuario
                {
                    l1.Text = "<img src=\"imagenes/sinImagen.png\" width=\"150\" height=\"100\" alt=\"Foto de usuario\"/>";
                }
                else
                {
                    l1.Text = "<img src=\"galeria/1.png\" width=\"150\" height=\"100\" alt=\"Foto de usuario\"/>";
                }
                Panel p1 = new Panel();
                p1.Controls.Add(l1);
                c1.Controls.Add(p1);

                // Columna de datos personales
                TableCell c2 = new TableCell();
                c2.CssClass = "columna2Usuarios";
                Label l2 = new Label();
                l2.Text = "<p><span class=\"tituloDato\">" + Resources.I18N.Usuario + ": </span><a href=\"usuario.aspx?usuario=" + us.Usuario + "\" class=\"usuario\">" + us.Usuario + "</a></p>";
                l2.CssClass = "usuario";
                Label l3 = new Label();
                l3.Text = "<p><span class=\"tituloDato\">" + Resources.I18N.Nombre + ": </span>" + us.Nombre + "</p>";
                l3.CssClass = "datoMenor";
                Label l4 = new Label();
                l4.Text = "<p><span class=\"tituloDato\">" + Resources.I18N.CorreoElectronico + ": </span>" + us.Correo + "</p>";
                l4.CssClass = "datoMenor";
                Label l5 = new Label();
                l5.Text = "<p><span class=\"tituloDato\">" + Resources.I18N.FechaIngreso + ": </span>" + us.Fechaingreso.Day.ToString() + "/" + us.Fechaingreso.Month.ToString() + "/" + us.Fechaingreso.Year.ToString() + "</p>";
                l5.CssClass = "datoMenor";
                Label l6 = new Label();
                l6.Text = "<p><span class=\"tituloDato\">" + Resources.I18N.InformacionAdicional + ": </span>" + us.Adicional + "</p>";
                l6.CssClass = "datoMenor";
                Panel p2 = new Panel();
                p2.Controls.Add(l2);
                p2.Controls.Add(l3);
                p2.Controls.Add(l4);
                p2.Controls.Add(l5);
                p2.Controls.Add(l6);
                c2.Controls.Add(p2);

                // Columna de información adicional
                TableCell c3 = new TableCell();
                c3.CssClass = "columna3Usuarios";
                Label l7 = new Label();
                l7.Text = "<p><span class=\"tituloDato\">" + Resources.I18N.CantidadImagenes + ": </span>" + us.CantidadImagenes().ToString() + "</p>";
                l7.CssClass = "datoMenor";
                Label l8 = new Label();
                l8.Text = "<p><span class=\"tituloDato\">" + Resources.I18N.CantidadFirmas + ": </span>" + us.CantidadFirmas().ToString() + "</p>";
                l8.CssClass = "datoMenor";
                Label l9 = new Label();
                l9.Text = "<p><span class=\"tituloDato\">" + Resources.I18N.CantidadEncuestas + ": </span>" + us.CantidadEncuestas().ToString() + "</p><br/>";
                l9.CssClass = "datoMenor";
                Label l10 = new Label();
                l10.Text = "<a href=\"\" class=\"enlaceMenor\">" + Resources.I18N.MensajePrivado + "</a>";
                Panel p3 = new Panel();
                p3.Controls.Add(l7);
                p3.Controls.Add(l8);
                p3.Controls.Add(l9);
                p3.Controls.Add(l10);
                c3.Controls.Add(p3);

                // Insertamos las columnas en la fila e insertamos la fila en la tabla.
                TableRow fila = new TableRow();
                fila.Controls.Add(c1);
                fila.Controls.Add(c2);
                fila.Controls.Add(c3);
                Table_usuarios.Controls.Add(fila);
            }
        }
    }

    public int Pagina
    {
        get { return pagina; }
        set { pagina = value; }
    }
    public int Cantidad
    {
        get { return cantidad; }
        set { cantidad = value; }
    }
    public int TotalResultados
    {
        get { return totalResultados; }
        set { totalResultados = value; }
    }
    public string Busqueda
    {
        get { return busqueda; }
        set { busqueda = value; }
    }
}
