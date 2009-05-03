<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="registroUsuario.aspx.cs" Inherits="registroUsuario" Title="Registro de usuario - CacatUA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="estilos/registroUsuario.css" media="screen" />
</asp:Content>
<script runat="server">

    /// <summary>
    /// Valida el nombre del lado del servidor
    /// </summary>
    void ValidarNombreS(object sender, ServerValidateEventArgs arguments)
    {
        string cadena = arguments.Value;
        
        if (cadena.Length >= 3 && cadena.Length <= 50)
        {
            arguments.IsValid = true;
        }
        else
        {
            arguments.IsValid = false;
        }  
    }
    /// <summary>
    /// Valida el DNI del lado del servidor
    /// </summary>
    void ValidarDNIS(object sender, ServerValidateEventArgs arguments)
    {
        string cadena = "";
        cadena = arguments.Value;
        
        if (cadena != "")
        {
            // Creamos una expresión regular para validar el DNI
            Regex er = new Regex(@"^\d{8}[a-zA-Z]$");

            if (er.IsMatch(cadena))
            {
                arguments.IsValid = true;
            }
            else
            {
                arguments.IsValid = false;
            }
        }
    }
    /// <summary>
    /// Valida el correo del lado del servidor
    /// </summary>
    void ValidarCorreoS(object sender, ServerValidateEventArgs arguments)
    {
        string cadena = "";
        cadena = arguments.Value;
        
        if (cadena != "")
        {
            // Creamos una expresión regular para validar el correo
            Regex er = new Regex(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");

            if (er.IsMatch(cadena))
            {
                arguments.IsValid = true;
            }
            else
            {
                arguments.IsValid = false;
            }
        }
    }
    /// <summary>
    /// Valida el campo adicional del lado del servidor
    /// </summary>
    void ValidarAdicionalS(object sender, ServerValidateEventArgs arguments)
    {
        string cadena = arguments.Value;
        
        if (cadena.Length <= 5000)
        {
            arguments.IsValid = true;
        }
        else
        {
            arguments.IsValid = false;
        } 
    }  
</script>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_titulo" runat="server">
    <div id="cabeceraRegistro">
        <p>
        Registro de usuario
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenido" runat="server">
    <div id="contenido">
        <p class="etiqueta">Nick de usuario</p>
        <p>    
            <asp:TextBox ID="TextBox_usuario" runat="server"></asp:TextBox>
            <asp:CustomValidator 
                    ID="CustomValidator_usuario" 
                    runat="server"
                    ClientValidationFunction="ValidarUsuarioC"
                    ServerValidationFunction="ValidarUsuarioS"
                    ControlToValidate="TextBox_nombre"
                    Display="Dynamic"
                    ErrorMessage="X">
            </asp:CustomValidator>
        </p>
        <p class="etiqueta">Contraseña</p>
        <p>
            <asp:TextBox ID="TextBox_contrasena" TextMode="Password" runat="server"></asp:TextBox>
            <asp:CustomValidator 
                    ID="CustomValidator_contrasena" 
                    runat="server"
                    ClientValidationFunction="ValidarContrasenaC"
                    ServerValidationFunction="ValidarContrasenaS"
                    ControlToValidate="TextBox_nombre"
                    Display="Dynamic"
                    ErrorMessage="X">
            </asp:CustomValidator>
        </p>
        <p class="etiqueta">Nombre</p>
        <p>
            <asp:TextBox ID="TextBox_nombre" runat="server"></asp:TextBox>
            <asp:CustomValidator 
                    ID="CustomValidator_nombre" 
                    runat="server"
                    ClientValidationFunction="ValidarNombreC"
                    ServerValidationFunction="ValidarNombreS"
                    ControlToValidate="TextBox_nombre"
                    Display="Dynamic"
                    ErrorMessage="X">
            </asp:CustomValidator>
        </p>
        <p class="etiqueta">DNI</p>
        <p>
            <asp:TextBox ID="TextBox_dni" runat="server"></asp:TextBox>
            <asp:CustomValidator 
                    ID="CustomValidator_dni" 
                    runat="server"
                    ClientValidationFunction="ValidarDNIC"
                    ServerValidationFunction="ValidarDNIS"
                    ControlToValidate="TextBox_dni"
                    Display="Dynamic"
                    ErrorMessage="X">
            </asp:CustomValidator>
        </p>
        <p class="etiqueta">Correo</p>
        <p>
            <asp:TextBox ID="TextBox_correo" runat="server"></asp:TextBox>
            <asp:CustomValidator 
                    ID="CustomValidator_correo" 
                    runat="server"
                    ClientValidationFunction="ValidarCorreoC"
                    ServerValidationFunction="ValidarCorreoS"
                    ControlToValidate="TextBox_correo"
                    Display="Dynamic"
                    ErrorMessage="X">
            </asp:CustomValidator>
        </p>
        <p class="etiqueta">Información Adicional</p>
        <p>
            <asp:TextBox ID="TextBox_adicional" TextMode="MultiLine" Columns="20" Rows="4" runat="server"></asp:TextBox>
            <asp:CustomValidator 
                    ID="CustomValidator_adicional" 
                    runat="server"
                    ClientValidationFunction="ValidarAdicionalC"
                    ServerValidationFunction="ValidarAdicionalS"
                    ControlToValidate="TextBox_adicional"
                    Display="Dynamic"
                    ErrorMessage="X">
            </asp:CustomValidator>  
        </p>
    
        <p class="pie">       
            <asp:Button ID="Button_confirmar" runat="server" Text="Confirmar" 
                CausesValidation="true" />
            <asp:Button ID="Button_limpiar" runat="server" Text="Limpiar" />   
        </p>

    </div>

<script type="text/javascript" language="javascript">
    // Valida el nombre del lado del cliente
    function ValidarNombreC(source, arguments)
    {
        var cadena = arguments.Value;
        
        if (cadena.length >= 3 && cadena.length <= 50)
        {
            arguments.IsValid = true;
        }
        else
        {
            arguments.IsValid = false;
        }  
    }
    // Valida el DNI del lado del cliente
    function ValidarDNIC(source, arguments)
    {
        var cadena = "";
        cadena = arguments.Value;
        
        if (cadena != "")
        {
            var regex = /(^([0-9]{8,8}[a-zA-Z])|^)$/;
            
            if (cadena.match(regex))
            {
                arguments.IsValid = true;
            }
            else
            {
                arguments.IsValid = false;
            }
        }
    }
    // Valida el correo del lado del cliente
    function ValidarCorreoC(source, arguments)
    {
        var cadena = "";
        cadena = arguments.Value;
        
        if (cadena != "")
        {
            var regex = /[\w-\.]{3,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;
            
            if (cadena.match(regex))
            {
                arguments.IsValid = true;
            }
            else
            {
                arguments.IsValid = false;
            }
        }
    }
    // Valida el campo adicional del lado del cliente
    function ValidarAdicionalC(source, arguments)
    {
        var cadena = arguments.Value;
        
        if (cadena.length <= 5000)
        {
            arguments.IsValid = true;
        }
        else
        {
            arguments.IsValid = false;
        } 
    }  
</script>

</asp:Content>
