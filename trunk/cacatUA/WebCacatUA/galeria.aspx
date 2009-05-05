<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeBehind="galeria.aspx.cs" Inherits="WebCacatUA.Formulario_web11" Title="Página sin título" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" runat="server">
    <link rel="stylesheet" type="text/css" href="estilos/galeria.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" runat="server">
    <p><asp:Label ID="Label_nombreUsuario" runat="server" Text="Galeria de fotos"></asp:Label></p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" runat="server">

    <p style="text-align:right;width:90%;" ><a href="" id="verImagen" >Ver Imagen</a></p>
    <br />
    <asp:Panel ID="Panel1" runat="server">
        <img id="imagenPrincipal" width="600px" src="" alt=""/>
    </asp:Panel>
    
    <asp:Table ID="Table1" runat="server">
    </asp:Table>
    
    <asp:Table ID="Table2" runat="server">
    </asp:Table>    
    
    <script type="text/javascript" language="javascript">

        
        

        function funcion(archivo){
        
           
            var elemento = document.getElementById("imagenPrincipal")
            elemento.setAttribute("src","/galeria/" + archivo + ".jpg");
            var link = document.getElementById("verImagen");
            link.setAttribute("href","/galeriaDetalle.aspx?imagen=" + archivo);           
        }
        
        funcion(id);
                
   </script>
      
</asp:Content>
