<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeBehind="galeria.aspx.cs" Inherits="WebCacatUA.Formulario_web11" Title="Página sin título" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" runat="server">
    <link rel="stylesheet" type="text/css" href="estilos/galeria.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" runat="server">
    <p><a name="comienzoGaleria"><asp:Label ID="Label_nombreUsuario" runat="server" Text="Galeria de fotos"></asp:Label></a></p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" runat="server">

    <div id="divContenidoGaleria">
    
        <p style="text-align:center;width:100%;" ><a href="" id="verImagen" >Ver detalles</a></p>
        <br />
        <asp:Panel ID="panelImagenPrincipal" runat="server">
            <img id="imagenPrincipal" width="600px" src="" alt=""/>
        </asp:Panel>
        <asp:Table ID="tablaPaginacion" runat="server">
        </asp:Table>
        <div id="divTablaImagenes" >
        <asp:Table ID="tablaImagenes" runat="server" HorizontalAlign="Center">
        </asp:Table>
        </div>
        
        <asp:Table ID="Table2" runat="server">
        </asp:Table>    
    
    </div>
    
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
