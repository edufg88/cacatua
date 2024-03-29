﻿using System;
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
using System.Drawing;
using System.Xml.Linq;
using Libreria;

public partial class materiales : WebCacatUA.InterfazWeb
{
    private int cantidadPorPagina;
    public int CantidadPorPagina
    {
        get { return cantidadPorPagina; }
        set { cantidadPorPagina = value; }
    }

    private string propiedadOrdenar;
    public string PropiedadOrdenar
    {
        get { return propiedadOrdenar; }
        set { propiedadOrdenar = value; }
    }

    private int pagina;
    public int Pagina
    {
        get { return pagina; }
        set { pagina = value; }
    }

    ENCategoria categoria = null;
    ENUsuario usuarioSesion = null;
    HtmlTable tabla = null;

    private void Inicializar()
    {
        if (Request.Params["categoria"] != null)
        {
            int idCategoria = int.Parse(Request.Params["categoria"].ToString());
            categoria = ENCategoria.Obtener(idCategoria);
        }

        if (Session["usuario"] != null)
        {
            // Obtenemos el usuario de la sesión
            usuarioSesion = ENUsuario.Obtener(Session["usuario"].ToString());
        }

        // Actualizamos la suscripción
        ActualizarSuscripcion();

        Panel_cantidadPorPaginaSuperior.Visible = false;
        Label_cantidadPorPaginaAnterior.Visible = false;
        int cantidadPorPaginaSuperior = int.Parse(DropDownList_cantidadPorPaginaSuperior.Text.ToString());
        int cantidadPorPaginaInferior = int.Parse(DropDownList_cantidadPorPaginaInferior.Text.ToString());
        propiedadOrdenar = DropDownList_propiedadesOrdenar.SelectedValue;
        int paginaInferior = int.Parse(DropDownList_paginaInferior.Text.ToString());
        int paginaSuperior = int.Parse(DropDownList_paginaSuperior.Text.ToString());

        // Comprobamos si ha cambiado la página
        if (paginaInferior != paginaSuperior)
        {
            // Ha cambiado
            if (int.Parse(Hidden_paginaAnterior.Value.ToString()) == paginaSuperior)
                pagina = paginaInferior;
            else
                pagina = paginaSuperior;
        }
        else
            pagina = paginaSuperior;
        Hidden_paginaAnterior.Value = pagina.ToString();

        // Comprobamos si ha cambiado la cantidad por página
        if (cantidadPorPaginaInferior != cantidadPorPaginaSuperior)
        {
            // Ha cambiado
            pagina = 1;
            DropDownList_paginaInferior.Text = "1";
            DropDownList_paginaSuperior.Text = "1";
            if (int.Parse(Label_cantidadPorPaginaAnterior.Text) == cantidadPorPaginaSuperior)
                cantidadPorPagina = cantidadPorPaginaInferior;
            else
                cantidadPorPagina = cantidadPorPaginaSuperior;   
        }
        else
            cantidadPorPagina = cantidadPorPaginaSuperior;

        Label_cantidadPorPaginaAnterior.Text = cantidadPorPagina.ToString();
        DropDownList_cantidadPorPaginaInferior.Text = cantidadPorPagina.ToString();
        DropDownList_cantidadPorPaginaSuperior.Text = cantidadPorPagina.ToString();
    }

    /// <summary>
    /// Para realizar una búsqueda se debe pasar el texto a buscar
    /// y la categoría donde realizar la búsqueda
    /// Se tienen que pasar dos parámetros: categoria y texto a buscar
    /// Si la categoría no existe, se hace una búsqueda a nivel global de materiales
    /// </summary>
    /// <returns></returns>
    private bool ComprobarBusqueda()
    {
        bool correcto = false;
        // Comprobamos si se le pasan los parámetros adecuados
        if (Request.Params["categoria"] != null && Request.Params["buscar"] != null)
        {
            // Realizamos la búsqueda
            BusquedaMaterial busqueda = new BusquedaMaterial();
            string filtroBusqueda = Request.Params["buscar"].ToString();
            busqueda.FiltroBusqueda = filtroBusqueda;

            int idCategoria = int.Parse(Request.Params["categoria"].ToString());
            ENCategoria categoria = ENCategoria.Obtener(idCategoria);
            busqueda.Categoria = categoria;

            RealizarBusqueda(busqueda);
            // Actualizamos las categorias
            ActualizarCategorias(busqueda.Categoria);
            // Actualizamos la navegación
            ActualizarNavegacion(busqueda.Categoria);
            // Actualizamos la búsqueda
            ActualizarBusqueda(busqueda.Categoria);

            correcto = true;
        }
        return correcto;
    }

    private bool ComprobarBusquedaUsuario()
    {
        bool correcto = false;
        // Comprobamos si se le pasan los parámetros adecuados
        if (Request.Params["usuario"] != null)
        {
            // Realizamos la búsqueda
            BusquedaMaterial busqueda = new BusquedaMaterial();
            ENUsuario usuario = ENUsuario.Obtener(int.Parse(Request.Params["usuario"].ToString()));
            busqueda.Usuario = usuario;

            RealizarBusqueda(busqueda);
            // Actualizamos las categorias
            ActualizarCategorias(busqueda.Categoria);
            // Actualizamos la navegación
            ActualizarNavegacion(busqueda.Categoria);
            // Actualizamos la búsqueda
            ActualizarBusqueda(busqueda.Categoria);

            correcto = true;
        }
        return correcto;
    }

    private bool ComprobarMostrarMaterialesCategoria()
    {
        bool correcto = false;
        if (Request.Params["categoria"] != null)
        {
            int idCategoria = int.Parse(Request.Params["categoria"].ToString());
            ENCategoria categoria = ENCategoria.Obtener(idCategoria);
            // Mostramos todos los materiales que hay en esa categoría
            BusquedaMaterial busqueda = new BusquedaMaterial();
            busqueda.Categoria = categoria;
            RealizarBusqueda(busqueda);

            // Actualizamos las categorias
            ActualizarCategorias(busqueda.Categoria);
            // Actualizamos la navegación
            ActualizarNavegacion(busqueda.Categoria);
            // Actualizamos la búsqueda
            ActualizarBusqueda(busqueda.Categoria);
            // Comprobamos si se puede crear un nuevo material
            comprobarNuevoMaterial(busqueda.Categoria);
            correcto = true;
        }
        return correcto;
    }

    void ActualizarBusqueda(ENCategoria categoria)
    {
        if (categoria != null)
        {
            Radio_materiales.Visible = true;
            Radio_categoria.Visible = true;
            Label_radioCategorias.Visible = true;
            Label_radioMateriales.Visible = true;
            Label_radioCategorias.Text = categoria.Nombre;
            Hidden_opcionBusqueda.Value = categoria.Id.ToString();
        }
        else
        {
            Radio_materiales.Visible = false;
            Radio_categoria.Visible = false;
            Label_radioCategorias.Visible = false;
            Label_radioMateriales.Visible = false;
            Hidden_opcionBusqueda.Value = "0";
        }
    }

    void ActualizarCategorias(ENCategoria categoria)
    {
        if (categoria == null)
        {
            // Mostramos las categorías superiores
            mostrarCategorias(ENCategoria.CategoriasSuperiores());
        }
        else
        {
            ArrayList hijos = categoria.ObtenerHijos();
            if (hijos.Count > 0)
                mostrarCategorias(hijos);
            else
            {
                // Mostramos las categorías del mismo nivel
                if (categoria.Padre != 0)
                    mostrarCategorias(ENCategoria.Obtener(categoria.Padre).ObtenerHijos());
                else
                    mostrarCategorias(ENCategoria.CategoriasSuperiores());
            }
        }
    }

    private void ActualizarNavegacion(ENCategoria categoria)
    {
        Label_ruta.Controls.Clear();
        HyperLink link = new HyperLink();
        link.Text = Resources.I18N.Materiales;
        link.NavigateUrl = "materiales.aspx?categoria=0";
        Label_ruta.Controls.Add(link);
        if (categoria != null)
        {
            añadirRuta(categoria);
            Hidden_idCategoria.Value = categoria.Id.ToString();
        }
        else
        {
            Hidden_idCategoria.Value = "0";
            // No se puede crear un material en la categoria "Materiales"
            Panel_botonNuevoMaterial.Visible = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Inicializar();
            // Comprobamos si tenemos que realizar una búsqueda
            bool resultado = ComprobarBusqueda();
            if (resultado == false)
            {
                // Comprobamos si tenemos que mostrar los materiales de una categoría
                resultado = ComprobarMostrarMaterialesCategoria();
                if (resultado == false)
                {
                    // Comprobamos si se trata de mostrar todos los materiales de un usuario
                    resultado = ComprobarBusquedaUsuario();
                    if (resultado == false)
                        Response.Redirect("materiales.aspx?categoria=0");
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private void RealizarBusqueda(BusquedaMaterial busqueda)
    {
        Panel_contenido.Controls.Clear();
        tabla = new HtmlTable();
        tabla.Attributes.Add("class", "tabla_materiales");

        bool ascendente = false;

        ArrayList materiales = ENMaterial.Obtener(propiedadOrdenar, ascendente,
            pagina, cantidadPorPagina, busqueda);

        if (materiales.Count > 0)
        {
            foreach (ENMaterial material in materiales)
            {
                HtmlTableRow fila = new HtmlTableRow();
                HtmlTableCell celda = new HtmlTableCell();
                celda.Attributes.Add("class", "columnaTabla_materiales");
                Control control = Page.LoadControl("materialBusqueda.ascx");
                WebCacatUA.materialBusqueda control_material = (WebCacatUA.materialBusqueda)control;
                control_material.inicializar(material);
                celda.Controls.Add(control_material);
                fila.Cells.Add(celda);
                // Cambiamos el color de la fila
                if (tabla.Rows.Count % 2 == 0)
                    fila.BgColor = "#f5f5f5";
                tabla.Rows.Add(fila);
            }
            Panel_contenido.Controls.Add(tabla);
            ActualizarPaginacion(busqueda.NumResultados);
        }
        else
        {
            Label_resultados.Text = Resources.I18N.NoHayResultados;
            ordenar_materiales.Visible = false;
            paginacionInferior_materiales.Visible = false;
            paginacionSuperior_materiales.Visible = false;
            contenido_busquedaMaterialesAux.Visible = false;
        }
    }

    /// <summary>
    /// Comprobamos si hay que activar el botón de nuevo material o no.
    /// Sólo se permite crear materiales si se está en una categoría que
    /// es un nodo hoja, es decir, no tiene descendientes.
    /// </summary>
    /// <param name="categoria"></param>
    private void comprobarNuevoMaterial(ENCategoria categoria)
    {
        if (categoria != null)
        {
            Control control = Page.LoadControl("nuevoMaterial.ascx");
            WebCacatUA.nuevoMaterial1 control_material = (WebCacatUA.nuevoMaterial1)control;
            Panel_nuevoMaterial.Controls.Add(control_material);
        }
    }

    public void ActualizarPaginacion(int totalResultados)
    {
        if (totalResultados > 0)
        {
            int paginas = (int)Math.Ceiling(totalResultados / (float)CantidadPorPagina);
            // Añadimos las páginas al combo box
            string paginaActual = pagina.ToString();
            DropDownList_paginaInferior.Items.Clear();
            DropDownList_paginaSuperior.Items.Clear();

            for (int i = 1; i <= paginas; i++)
            {
                DropDownList_paginaInferior.Items.Add(i.ToString());
                DropDownList_paginaSuperior.Items.Add(i.ToString());
            }
            DropDownList_paginaInferior.Text = paginaActual;
            DropDownList_paginaSuperior.Text = paginaActual;

            int inicial = (pagina - 1) * CantidadPorPagina + 1;
            int final = inicial - 1 + CantidadPorPagina;
            if (final > totalResultados) final = totalResultados;

            Label_resultados.Text = Resources.I18N.Resultados + " " + inicial + " - " + final
                   + " " + Resources.I18N.Deminuscula + " " + totalResultados + " "
                   + Resources.I18N.Materiales.ToLower() + " " + Resources.I18N.EncontradosMin;

            if (DropDownList_paginaInferior.Text == "1")
                Button_anteriorInferior.Enabled = false;
            else
                Button_anteriorInferior.Enabled = true;

            if (DropDownList_paginaInferior.Text == paginas.ToString())
                Button_siguienteInferior.Enabled = false;
            else
                Button_siguienteInferior.Enabled = true;

            Button_anteriorSuperior.Enabled = Button_anteriorInferior.Enabled;
            Button_siguienteSuperior.Enabled = Button_siguienteInferior.Enabled;
        }
    }

    private void mostrarCategorias(ArrayList categorias)
    {
        Panel_categorias.Controls.Clear();
        foreach (ENCategoria categoria in categorias)
        {
            HyperLink link = new HyperLink();
            link.Text = categoria.Nombre;
            link.NavigateUrl = "materiales.aspx?categoria=" + categoria.Id.ToString();
            link.CssClass = "categoria_materiales";
            Panel_categorias.Controls.Add(link);
        }
    }

    private void añadirRuta(ENCategoria categoria)
    {
        // Añadimos primero la ruta del padre
        ENCategoria padre = ENCategoria.Obtener(categoria.Padre);
        if (padre != null)
        {
            // Obtenemos la ruta del padre
            añadirRuta(padre);
        }
        // Hemos llegado a la raíz
        Label label = new Label();
        label.Text = " > ";
        Label_ruta.Controls.Add(label);
        HyperLink link = new HyperLink();
        link.Text = categoria.Nombre;
        link.NavigateUrl = "materiales.aspx?categoria=" + categoria.Id.ToString();
        Label_ruta.Controls.Add(link);
    }

    protected void LinkButton_suscribirse_Click(object sender, EventArgs e)
    {
        if (usuarioSesion != null && categoria != null)
        {
            categoria.SuscribirUsuario(usuarioSesion);
            ActualizarSuscripcion();
        }
    }

    protected void LinkButton_dessuscribirse_Click(object sender, EventArgs e)
    {
        if (usuarioSesion != null && categoria != null)
        {
            categoria.InsuscribirUsuario(usuarioSesion);
            ActualizarSuscripcion();
        }
    }

    private void ActualizarSuscripcion()
    {
        // Comprobamos si el usuario está logueado y la categoría es válida
        if (categoria != null && usuarioSesion != null)
        {
            if (!categoria.EstaSuscrito(usuarioSesion))
            {
                LinkButton_suscribirse.Visible = true;
                LinkButton_dessuscribirse.Visible = false;
            }
            else
            {
                LinkButton_suscribirse.Visible = false;
                LinkButton_dessuscribirse.Visible = true;
            }
            Panel_suscribirse.Visible = true;
        }
        else
        {
            Panel_suscribirse.Visible = false;
        }
    }
    protected void Button_buscar_Click(object sender, EventArgs e)
    {
        string texto = TextBox_buscar.Text;
        string id = Hidden_opcionBusqueda.Value;
        string busqueda = "materiales.aspx?categoria=" + id + "&buscar=" + texto;
        Response.Redirect(busqueda);
    }
}
