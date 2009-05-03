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

public partial class foro : WebCacatUA.InterfazWeb
{
    private int pagina;
    private int cantidad;
    private int totalResultados;
    private ENCategoria categoria;
    private ENUsuario usuario;
    private bool orden;
    private string ordenar;
    private string busqueda;


    protected void Page_Load(object sender, EventArgs e)
    {
        extraerParametros();
        mostrarHilos();
        mostrarCategorias();
        actualizarPaginacion();
    }

    private void actualizarPaginacion()
    {
        Button_paginaAnterior.Enabled = false;
        Button_paginaSiguiente.Enabled = false;
        if (cantidad > 0)
        {
            DropDownList_pagina.Items.Clear();
            int cantidadPaginas = (int)Math.Ceiling(totalResultados / (float)cantidad);
            for (int i = 1; i < cantidadPaginas + 1; i++)
            {
                ListItem p = new ListItem(i.ToString(), i.ToString());
                DropDownList_pagina.Items.Add(p);
            }

            if (1 <= pagina && pagina <= cantidadPaginas)
            {
                DropDownList_pagina.SelectedIndex = pagina - 1;
            }

            if (cantidadPaginas > pagina)
                Button_paginaSiguiente.Enabled = true;

            if (pagina > 1)
                Button_paginaAnterior.Enabled = true;

            for (int i = 0; i < DropDownList_cantidadPagina.Items.Count; i++)
            {
                if (DropDownList_cantidadPagina.Items[i].Value == cantidad.ToString())
                {
                    DropDownList_cantidadPagina.SelectedIndex = i;
                    break;
                }
            }
        }
    }

    private void mostrarCategorias()
    {
        ArrayList categorias = null;
        if (categoria != null)
        {
            categorias = categoria.ObtenerHijos();
        }
        else
        {
            categorias = ENCategoria.CategoriasSuperiores();
        }

        Panel_categorias.Controls.Clear();
        foreach (ENCategoria c in categorias)
        {
            LinkButton labelCategoria = new LinkButton();
            labelCategoria.CssClass = "categoriaForo";
            labelCategoria.Text = c.Nombre;
            labelCategoria.ID = "categoria" + c.Id;
            labelCategoria.PostBackUrl = "foro.aspx?categoria=" + c.Id;

            Panel_categorias.Controls.Add(labelCategoria);
        }

        mostrarMigas();
    }

    private void mostrarMigas()
    {
        Label_migas.Controls.Clear();
        LinkButton labelCategoria = null;
        Label labelSeparador = null;

        if (categoria != null)
        {
            ENCategoria categoriaAux = categoria;
            do
            {
                if (Label_migas.Controls.Count > 0)
                {
                    labelSeparador = new Label();
                    labelSeparador.Text = " > ";
                    Label_migas.Controls.AddAt(0, labelSeparador);
                }
                labelCategoria = new LinkButton();
                labelCategoria.CssClass = "categoriaMigaForo";
                labelCategoria.Text = categoriaAux.Nombre;
                labelCategoria.PostBackUrl = "foro.aspx?categoria=" + categoriaAux.Id;
                Label_migas.Controls.AddAt(0, labelCategoria);

                categoriaAux = ENCategoria.Obtener(categoriaAux.Padre);
            }
            while (categoriaAux != null);
        }

        if (Label_migas.Controls.Count > 0)
        {
            labelSeparador = new Label();
            labelSeparador.Text = " > ";
            Label_migas.Controls.AddAt(0, labelSeparador);
        }
        labelCategoria = new LinkButton();
        labelCategoria.CssClass = "categoriaMigaForo";
        labelCategoria.Text = Resources.I18N.Foro;
        labelCategoria.PostBackUrl = "foro.aspx";
        Label_migas.Controls.AddAt(0, labelCategoria);

        labelSeparador = new Label();
        labelSeparador.Text = Resources.I18N.EstasAqui + ": ";
        Label_migas.Controls.AddAt(0, labelSeparador);
    }

    /// <summary>
    /// Muestra los hilos que toquen según los parámetros.
    /// </summary>
    private void mostrarHilos()
    {
        if (totalResultados > 0)
            Label_mostrandoForo.Text = "Resultados " + ((pagina - 1) * cantidad + 1) + " - " + Math.Min(pagina * cantidad, totalResultados) + " de " + totalResultados + " hilos encontrados.";
        else
            Label_mostrandoForo.Text = "No hay resultados con estas condiciones de búsqueda.";

        Table_hilosForo.Controls.Clear();
        insertarCabecera();

        DateTime fechaInicio = DateTime.Now;
        DateTime fechaFin = fechaInicio;

        ArrayList hilos = ENHilo.Obtener(cantidad, pagina, ordenar, orden, busqueda, busqueda, ref usuario, ref fechaInicio, ref fechaFin, ref categoria);
        if (hilos != null)
        {
            foreach (ENHilo i in hilos)
            {
                // Columna del título y del creado.
                TableCell c1 = new TableCell();
                c1.CssClass = "columna1HiloForo";
                Label l1 = new Label();
                l1.Text = "<a href=\"hilo.aspx?id=" + i.Id + "\" class=\"enlaceHiloForo\">" + i.Titulo + "</a>";
                Panel p1 = new Panel();
                p1.CssClass = "tituloHiloForo";
                p1.Controls.Add(l1);
                c1.Controls.Add(p1);
                Label l2 = new Label();
                l2.Text = Resources.I18N.creadoPor +" <a href=\"usuario.aspx?id=" + i.Autor.Id + "\" class=\"autorForo\">" + i.Autor.Usuario + "</a>, " + i.Fecha;
                Panel p2 = new Panel();
                p2.CssClass = "creadoHiloForo";
                p2.Controls.Add(l2);
                c1.Controls.Add(p2);

                // Columna del número de respuestas.
                TableCell c2 = new TableCell();
                c2.CssClass = "columna2HiloForo";
                Label l3 = new Label();
                l3.Text = i.NumRespuestas.ToString();
                Panel p3 = new Panel();
                p3.CssClass = "respuestasHiloForo";
                p3.Controls.Add(l3);
                c2.Controls.Add(p3);

                // Columna del número de visitas.
                TableCell c3 = new TableCell();
                c3.CssClass = "columna3HiloForo";
                Label l4 = new Label();
                l4.Text = i.NumVisitas.ToString();
                Panel p4 = new Panel();
                p4.CssClass = "visitasHiloForo";
                p4.Controls.Add(l4);
                c3.Controls.Add(p4);

                // Columna con la última respuesta.
                TableCell c4 = new TableCell();
                c4.CssClass = "columna4HiloForo";
                Label l5 = new Label();
                if (i.NumRespuestas > 0)
                    l5.Text = Resources.I18N.por + " <a href=\"usuario.aspx?id=" + i.AutorUltimaRespuesta.Id + "\" class=\"autorRespuesta\">" + i.AutorUltimaRespuesta.Usuario + "</a><br />" + i.FechaUltimaRespuesta;
                else
                    l5.Text = Resources.I18N.nadie;
                Panel p5 = new Panel();
                p5.CssClass = "ultimaRespuestaHiloForo";
                p5.Controls.Add(l5);
                c4.Controls.Add(p5);

                // Insertamos las columnas en la fila e insertamos la fila en la tabla.
                TableRow fila = new TableRow();
                fila.CssClass = "hiloForo";
                fila.Controls.Add(c1);
                fila.Controls.Add(c2);
                fila.Controls.Add(c3);
                fila.Controls.Add(c4);
                Table_hilosForo.Controls.Add(fila);
            }
        }
        else
        {
            Label_mostrandoForo.Text = "null";
        }
    }

    /// <summary>
    /// Extramos los parámetros de la URL.
    /// La página actual, la columna de ordenador, si es ascendente o descendente, el filtro de búsqueda ...
    /// </summary>
    private void extraerParametros()
    {
        pagina = 1;
        try
        {
            pagina = int.Parse(Request["pagina"].ToString());
        }
        catch (Exception) { }

        cantidad = 10; // debería ser común para todas secciones, debería estar en la sesión este valor y lo ideal es que se pudiera cambiar (pero pasando...)
        try
        {
            cantidad = int.Parse(Request["cantidad"].ToString());
        }
        catch (Exception) { }

        orden = false;
        try
        {
            if (Request["orden"].ToString() == "descendente")
                orden = false;
        }
        catch (Exception) { }

        ordenar = "fecharespuesta";
        try
        {
            ordenar = Request["ordenar"].ToString();
        }
        catch (Exception) { }

        busqueda = "";
        try
        {
            busqueda = Request["busqueda"].ToString();
        }
        catch (Exception) { }

        categoria = null;
        try
        {
            categoria = ENCategoria.Obtener(int.Parse(Request["categoria"].ToString()));
        }
        catch (Exception) { }

        usuario = null;
        try
        {
            usuario = ENUsuario.Obtener(int.Parse(Request["usuario"].ToString()));
        }
        catch (Exception) { }


        DateTime fechaInicio = DateTime.Now;
        DateTime fechaFin = fechaInicio;

        totalResultados = ENHilo.Cantidad(busqueda, busqueda, ref usuario, ref fechaInicio, ref fechaFin, ref categoria);
    }

    private void insertarCabecera()
    {
                // Columna del título y del creado.
                TableCell c1 = new TableCell();
                c1.CssClass = "columna1HiloForo cabeceraForo";
                Label l1 = new Label();
                l1.Text = Resources.I18N.Hilos;
                Panel p1 = new Panel();
                p1.CssClass = "tituloHiloForo";
                p1.Controls.Add(l1);
                c1.Controls.Add(p1);

                // Columna del número de respuestas.
                TableCell c2 = new TableCell();
                c2.CssClass = "columna2HiloForo cabeceraForo";
                Label l3 = new Label();
                l3.Text = Resources.I18N.Respuestas;
                Panel p3 = new Panel();
                p3.CssClass = "respuestasHiloForo";
                p3.Controls.Add(l3);
                c2.Controls.Add(p3);

                // Columna del número de visitas.
                TableCell c3 = new TableCell();
                c3.CssClass = "columna3HiloForo cabeceraForo";
                Label l4 = new Label();
                l4.Text = Resources.I18N.Visitas;
                Panel p4 = new Panel();
                p4.CssClass = "visitasHiloForo";
                p4.Controls.Add(l4);
                c3.Controls.Add(p4);

                // Columna con la última respuesta.
                TableCell c4 = new TableCell();
                c4.CssClass = "columna4HiloForo cabeceraForo";
                Label l5 = new Label();
                l5.Text = Resources.I18N.UltimaRespuesta;
                Panel p5 = new Panel();
                p5.CssClass = "ultimaRespuestaHiloForo";
                p5.Controls.Add(l5);
                c4.Controls.Add(p5);

                // Insertamos las columnas en la fila e insertamos la fila en la tabla.
                TableRow fila = new TableRow();
                fila.CssClass = "hiloForo";
                fila.Controls.Add(c1);
                fila.Controls.Add(c2);
                fila.Controls.Add(c3);
                fila.Controls.Add(c4);
                Table_hilosForo.Controls.Add(fila);
    }

    protected void Button_paginaAnterior_Click(object sender, EventArgs e)
    {
        pagina--;
        mostrarCategorias();
        actualizarPaginacion();
    }

    protected void Button_paginaSiguiente_Click(object sender, EventArgs e)
    {
        pagina++;
        mostrarHilos();
        actualizarPaginacion();
    }

    protected void DropDownList_pagina_SelectedIndexChanged(object sender, EventArgs e)
    {
        pagina = int.Parse(DropDownList_pagina.SelectedValue);
        mostrarHilos();
        actualizarPaginacion();
    }
}
