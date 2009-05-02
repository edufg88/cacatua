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

        Label_migas.Controls.Clear();
        if (categoria != null)
        {
            ENCategoria categoriaAux = categoria;
            do
            {
                LinkButton labelCategoria = new LinkButton();
                labelCategoria.CssClass = "categoriaMigaForo";
                labelCategoria.Text = categoriaAux.Nombre;
                labelCategoria.PostBackUrl = "foro.aspx?categoria=" + categoriaAux.Id;
                if (Label_migas.Controls.Count > 0)
                {
                    Label labelSeparador = new Label();
                    labelSeparador.Text = " > ";
                    Label_migas.Controls.AddAt(0, labelSeparador);
                }
                Label_migas.Controls.AddAt(0, labelCategoria);

                categoriaAux = ENCategoria.Obtener(categoriaAux.Padre);
            }
            while (categoriaAux != null);
        }
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

        Label_hilos.Text = "";
        DateTime fechaInicio = DateTime.Now;
        DateTime fechaFin = fechaInicio;

        ArrayList hilos = ENHilo.Obtener(cantidad, pagina, ordenar, orden, busqueda, busqueda, ref usuario, ref fechaInicio, ref fechaFin, ref categoria);
        if (hilos != null)
        {
            for (int i = 0; i < hilos.Count; i++)
            {
                Label_hilos.Text += ((ENHilo)hilos[i]).Id.ToString() + " " + ((ENHilo)hilos[i]).Titulo.ToString() + " " + ((ENHilo)hilos[i]).FechaUltimaRespuesta.ToString() + @"<br />";
            }
        }
        else
        {
            Label_hilos.Text = "null";
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
