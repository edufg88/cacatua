<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="chat.aspx.cs" Inherits="WebCacatUA.chat" Title="Chat - CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="estilos/chat.css" media="screen" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_titulo" runat="server">
    <p>Chat</p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenido" runat="server">

<script type="text/javascript">

function limpiar()
{
    var mensaje = document.getElementById("<%= TextBox_mensaje.ClientID %>").value;
    document.getElementById("<%= TextBox_mensaje.ClientID %>").value = '';
    document.getElementById("<%= TextBox_textoEnviado.ClientID %>").value = mensaje;
    document.getElementById("<%= TextBox_mensajes.ClientID %>").value += "<%= NombreUsuario %>: " + mensaje + "\n";
}

function bajarScroll()
{
    document.getElementById("<%= TextBox_mensajes.ClientID %>").scrollTop = document.getElementById("<%= TextBox_mensajes.ClientID %>").scrollHeight;
    return false;
}

function anadirMensaje(autor, texto)
{
    var autorSpan = document.createElement('span');
    autorSpan.setAttribute('class', 'autorMensajeChat');
    autorSpan.appendChild(document.createTextNode(autor));
    
    var textoSpan = document.createElement('span');
    textoSpan.setAttribute('class', 'textoMensajeChat');
    textoSpan.appendChild(document.createTextNode(texto));
    
    var mensaje = document.createElement('div');
    mensaje.setAttribute('class', 'mensajeChat');
    mensaje.appendChild(autorSpan);
    mensaje.appendChild(textoSpan);
    
    var mensajes = document.getElementById("mensajesChat");
    mensajes.appendChild(mensaje);
    mensajes.scrollTop = 999999;
}

</script>

    <div id="chat">
    
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                
                <asp:Timer ID="Timer2" runat="server" interval="1000" ontick="actualizarChat" />
                <asp:TextBox ID="TextBox_textoEnviado" runat="server" CssClass="ocultoChat"></asp:TextBox>
                <asp:Label ID="Label_ultimoMensaje" runat="server" Text="0" Visible="False"></asp:Label>
                <div id="usuariosConectados">
                    <asp:ListBox ID="ListBox_usuarios" Width="100%" Height="100%" runat="server"></asp:ListBox>
                </div>

                <asp:TextBox ID="TextBox_mensajes" CssClass="mensajesChat" Width="100%" runat="server" TextMode="MultiLine"></asp:TextBox>
                
            </ContentTemplate>
             
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button_enviar" EventName="click" /> 
            </Triggers> 
           
        </asp:UpdatePanel>
        
        <div id="mensajesChat"></div>
                
        <table id="anadirMensaje" cellpadding="0" cellspacing="0">
            <tr>
                <td class="columna1AnadirMensaje"><asp:TextBox ID="TextBox_mensaje" CssClass="areaMensajeChat" runat="server"></asp:TextBox></td>
                <td class="columna2AnadirMensaje"><asp:Button ID="Button_enviar" CssClass="botonMensajeChat" OnClientClick="limpiar()" runat="server" Text="<%$ Resources: I18N, Enviar %>" onclick="Button_enviar_Click" /></td>
            </tr>
        </table>
        
    </div>
        
</asp:Content>
