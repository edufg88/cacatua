<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeBehind="galeria.aspx.cs" Inherits="WebCacatUA.Formulario_web11" Title="Galería - CacatUA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" runat="server">
    <link rel="stylesheet" type="text/css" href="estilos/galeria.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" runat="server">
    <p><a name="comienzoGaleria"><asp:Label ID="Label_nombreUsuario" runat="server" Text="<%$ Resources: I18N, GaleriaFotos %>"></asp:Label></a></p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" runat="server">
    
    <div id="divContenidoGaleria">
    
        <p style="text-align:center;width:100%;" ><a href="" id="verImagen"><%= Resources.I18N.VerDetalles %></a></p>
        
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
        <asp:HyperLink ID="subirImagen" runat="server" NavigateUrl="/galeriaUpload.aspx" ><%= Resources.I18N.SubirImagen %></asp:HyperLink>
        <asp:Table ID="Table2" runat="server">
        </asp:Table>    
    
    </div>
    
    <script type="text/javascript" language="javascript">

        
        var link = document.getElementById("verImagen");
        link.className = "oculto";

        function funcion(archivo,id){
        
           
            var elemento = document.getElementById("imagenPrincipal")
            elemento.setAttribute("src","/galeria/" + archivo);
            var link = document.getElementById("verImagen");
            link.setAttribute("href","/galeriaDetalle.aspx?usuario=<%= us.Usuario %>&imagen=" + id); 
            link.className = "visible";  
             
          
        }
        if(archivo!="" || id!=""){
            funcion(archivo,id);
        }
        
                        
   </script>
      
</asp:Content>
