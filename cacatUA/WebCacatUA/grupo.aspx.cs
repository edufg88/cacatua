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


public partial class grupo : WebCacatUA.InterfazWeb
{
    ENGrupos group = null;
    ENUsuario user = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        bool miembro = false;
        if (Request.QueryString["id"] != "")
        {
            group = ENGrupos.Obtener(int.Parse(Request.QueryString["id"]));
            if (Session["usuario"] != null)
            {
                user = ENUsuario.Obtener(Session["usuario"].ToString());
                foreach (ENUsuario usuario in group.Usuarios)
                {
                    if (usuario.Usuario == user.Usuario)
                    {
                        miembro = true;
                        break;
                    }
                }
                if (miembro)
                {
                    Button_desapuntarse.Visible = true;
                }
                else
                {
                    Button_apuntarse.Visible = true;
                }
            }
            else
            {
                Button_enviarmensaje.Visible = false;
                Button_apuntarse.Visible = false;
            }
            ObtenerDatos();
        }
    }

    private void ObtenerDatos()
    {
        Label_nombre.Text = group.Nombre;
        Label_Desc.Text = group.Descripcion;

        Panel_miembros.Controls.Clear();
        HtmlTable tabla = new HtmlTable();
        foreach (ENUsuario usuario in group.Usuarios)
        {
            HtmlTableRow fila = new HtmlTableRow();
            HtmlTableCell celda = new HtmlTableCell();
            HyperLink link = new HyperLink();
            link.Text = usuario.Usuario;
            link.NavigateUrl = "usuario.aspx?usuario=" + usuario.Usuario;
            celda.Controls.Add(link);
            fila.Cells.Add(celda);
            tabla.Rows.Add(fila);
        }
        Panel_miembros.Controls.Add(tabla);
    }

    protected void Button_apuntarse_Click(object sender, EventArgs e)
    {
        group.InsertarMiembro(user.Id);
        Response.Redirect("confirmacion.aspx?inscribir=" + group.Id);
    }

    protected void Button_desapuntarse_Click(object sender, EventArgs e)
    {
        group.BorrarMiembro(user.Id);
        Response.Redirect("confirmacion.aspx?desapuntar=" + group.Id);
    }

    protected void Button_enviarmensaje_Click(object sender, EventArgs e)
    {
        string ruta = "enviarmensaje.aspx?grupo=" + group.Id;
        Response.Redirect(ruta);
    }
}