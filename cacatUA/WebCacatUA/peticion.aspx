<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="peticion.aspx.cs" Inherits="WebCacatUA.peticion"  Title="Petición - CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="stylesheet" type="text/css" href="estilos/peticion.css" media="screen" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_titulo" Runat="Server">
    <p><asp:Label ID="Label_paginaInicio" runat="server" Text="<%$ Resources: I18N, Peticiones %>"></asp:Label></p>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_contenido" Runat="Server">  
    
    <asp:Panel ID="Panel_peticion" runat="server">
        <div id="div_infopeticion">
            <%= Resources.I18N.PeticionInfo %>
        </div>
    
        <div id="div_formpeticion">
        <asp:Panel ID="Panel_mensaje" runat="server"></asp:Panel>
        <table id="tablapeticion" cellpadding="0" cellspacing="0">
                <tr class="fila"> 
                    <td class="columna1"><%= Resources.I18N.Asunto %>:</td>
                    <td class="columna2">
                        <asp:TextBox ID="TextBox_Asunto" runat="server" MaxLength="200" Width="80%"></asp:TextBox>
                    </td>
                </tr>
                <tr class="fila">
                    <td class="columna1"><%= Resources.I18N.Peticion %>:</td>
                    <td class="columna2">
                        <asp:TextBox ID="TextBox_Peticion" runat="server" TextMode="MultiLine" 
                        Width="80%" Height="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="fila">
                    <td class="columna1">
                        <asp:Button ID="Button_enviar" runat="server" Text="<%$ Resources: I18N, Enviar %>" 
                            onclick="Button_enviar_Click" />
                    </td>
                    <td class="columna2"></td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    
    <asp:Label ID="Label_peticion" runat="server" Text="<%$ Resources: I18N, DebesIdentificarteContactar %>" Visible="False"></asp:Label>
    
</asp:Content>



