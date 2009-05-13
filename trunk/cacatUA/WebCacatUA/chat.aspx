<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="chat.aspx.cs" Inherits="WebCacatUA.chat" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
#mensajesChat
{
	width:100%;
	height:300px;
	padding:10px;
	background-color:White;
}


</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenido" runat="server">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Timer ID="Timer2" runat="server" interval="2000" ontick="actualizarChat" /></asp:Timer>
                <asp:Panel ID="Panel_chat" CssClass="chat" runat="server" Visible="true">
                    <asp:Label ID="Label_ultimoMensaje" runat="server" Visible=true Text="0"></asp:Label>
                    <div id="usuariosConectados">
                        <asp:ListBox ID="ListBox_usuarios" width="300px" Height="100px" runat="server"></asp:ListBox>
                    </div>
                    
                    
                    <div id="mensajesChat">
                        <asp:Panel ID="Panel_mensajes" runat="server"></asp:Panel>
                    </div>
                </asp:Panel>
            </ContentTemplate>
             
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button_enviar" EventName="click" /> 
            </Triggers> 
           
        </asp:UpdatePanel>   
        <asp:TextBox ID="TextBox_mensaje" Width="100%" runat="server" TextMode="MultiLine"></asp:TextBox>
                         <asp:Button ID="Button_enviar" runat="server" Text="Button" 
                        onclick="Button_enviar_Click" />
        
        
</asp:Content>
