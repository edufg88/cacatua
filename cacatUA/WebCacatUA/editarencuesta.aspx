﻿<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeBehind="editarencuesta.aspx.cs" Inherits="WebCacatUA.editarencuesta" Title="Edición encuestas - CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" runat="server">
    <link rel="stylesheet" type="text/css" href="estilos/encuestasEdicion.css" media="screen" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" runat="server">
    <p><asp:Label ID="Label_nombreSeccion" runat="server" Text="Encuestas"></asp:Label></p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" runat="server">
    <asp:Label ID="Label_Texto" runat="server" Text=""></asp:Label>
     <div id="div_encuestas">
        <asp:Table ID="Table_encuesta" runat="server" CssClass="tabla_encuestas" 
            CellPadding="0" CellSpacing="0"></asp:Table>        
    </div>
    <div id="div_opciones">
        Nueva opción:
        <asp:TextBox ID="TextBox_crearopcion" runat="server" />
        <asp:Button ID="Button_crearopcion" runat="server" Text="Añadir" 
            onclick="Button_crearopcion_Click" />
    </div>     
</asp:Content>


