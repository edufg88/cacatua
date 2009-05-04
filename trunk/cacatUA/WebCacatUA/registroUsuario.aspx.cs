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

public partial class registroUsuario : WebCacatUA.InterfazWeb
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        foreach(ENUsuario us in ENUsuario.Obtener(1,20))
        {
            Response.Write(us.Usuario);
            Response.Write("\n ");
        }
        */
    }

    protected void LimpiarErrores()
    {
        Label_infoGeneral.Text = "";
        Label_infoUsuario.Text = "";
        Label_infoContrasena.Text = "";
        Label_infoConfContrasena.Text = "";
        Label_infoNombre.Text = "";
        Label_infoCorreo.Text = "";
        Label_infoDni.Text = "";
        Label_infoAdicional.Text = "";
    }

    protected void LimpiarCampos()
    {
        TextBox_usuario.Text = "";
        TextBox_contrasena.Text = "";
        TextBox_confirmarContrasena.Text = "";
        TextBox_nombre.Text = "";
        TextBox_correo.Text = "";
        TextBox_dni.Text = "";
        TextBox_adicional.Text = "";
    }

    protected bool ValidarCampos()
    {
        bool valido = true;
        string error = "";

        LimpiarErrores();

        error = ENUsuario.ValidarFormulario("usuario", TextBox_usuario.Text);
        Label_infoUsuario.Text = ENUsuario.ValidarFormulario("usuario", TextBox_usuario.Text);
        error = ENUsuario.ValidarFormulario("contrasena", TextBox_contrasena.Text);
        Label_infoContrasena.Text = ENUsuario.ValidarFormulario("contrasena", TextBox_contrasena.Text);
        error = ENUsuario.ValidarFormulario("nombre", TextBox_nombre.Text); 
        Label_infoNombre.Text = ENUsuario.ValidarFormulario("nombre", TextBox_nombre.Text);
        error = ENUsuario.ValidarFormulario("correo", TextBox_correo.Text);
        Label_infoCorreo.Text = ENUsuario.ValidarFormulario("correo", TextBox_correo.Text);
        error = ENUsuario.ValidarFormulario("dni", TextBox_dni.Text);
        Label_infoDni.Text = ENUsuario.ValidarFormulario("dni", TextBox_dni.Text);
        error = ENUsuario.ValidarFormulario("adicional", TextBox_adicional.Text);
        Label_infoAdicional.Text = ENUsuario.ValidarFormulario("adicional", TextBox_adicional.Text);

        // Comprobamos que la confirmación de la contraseña está bien
        if (TextBox_contrasena.Text != TextBox_confirmarContrasena.Text)
        {
            Label_infoConfContrasena.Text = "La contraseña y su confirmación no coinciden";
            valido = false;
        }
        else
        {
            if (error != "")
            {
                valido = false;
            }
        }

        return valido;
    }

    protected void Button_confirmar_Click(object sender, EventArgs e)
    {
        if (ValidarCampos())
        {
            ENUsuario us = ENUsuario.Obtener(TextBox_usuario.Text);

            if (us == null)
            {
                us = new ENUsuario();

                us.Usuario = TextBox_usuario.Text;
                us.Contrasena = TextBox_contrasena.Text;
                us.Nombre = TextBox_nombre.Text;
                us.Dni = TextBox_dni.Text;
                us.Correo = TextBox_correo.Text;
                us.Adicional = TextBox_adicional.Text;

                if (us.Guardar())
                {
                    LimpiarErrores();
                    LimpiarCampos();
                    Label_infoGeneral.Text = "Usuario registrado correctamente";
                    Label_infoGeneral.ForeColor = System.Drawing.Color.DarkGreen;
                }
            }
            else // El usuario ya existe
            {
                Label_infoUsuario.Text = "El nombre de usuario ya existe";
            }
        }
    }

    protected void Button_limpiar_Click(object sender, EventArgs e)
    {
        LimpiarErrores();
        LimpiarCampos();
    }
}

