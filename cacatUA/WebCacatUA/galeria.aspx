<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeFile="usuario.aspx.cs" Inherits="usuario" Title="CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" Runat="Server">
<link rel="stylesheet" type="text/css" href="estilos/galeria.css" media="screen" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" Runat="Server">
<p><asp:Label ID="Label_nombreUsuario" runat="server" Text="Galeria de fotos"></asp:Label></p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" Runat="Server">
    <div id="fotoSeleccionada">
        <img id="imagenPrincipal" width="600px" src="/imagenes/1.jpg" />
    </div>
    <table id="tablaFotos" width="90%" >
        <tr>
            <td><img src="/imagenes/botonanterioresfotos.png" alt="" /></td>
            <td><img onclick="funcion(1)" height="40px" src="/imagenes/1.jpg" alt="" /></td>
            <td><img onclick="funcion(2)" height="40px" src="/imagenes/2.jpg" alt="" /></td>
            <td><img onclick="funcion(3)" height="40px" src="/imagenes/3.jpg" alt="" /></td>
            <td><img onclick="funcion(4)" height="40px" src="/imagenes/4.jpg" alt="" /></td>
            <td><img onclick="funcion(5)" height="40px" src="/imagenes/5.jpg" alt="" /></td>
            <td><img onclick="funcion(6)" height="40px" src="/imagenes/6.jpg" alt="" /></td>
            <td><img onclick="funcion(7)" height="40px" src="/imagenes/7.jpg" alt="" /></td>
            <td><img onclick="funcion(8)" height="40px" src="/imagenes/8.jpg" alt="" /></td>
            <td><img onclick="funcion(9)" height="40px" src="/imagenes/9.jpg" alt="" /></td>
            <td><img onclick="funcion(10)" height="40px" src="/imagenes/10.jpg" alt="" /></td>
            
            <td><img src="/imagenes/botonsiguientesfotos.png" alt="" /></td>
        </tr>
    </table>
    
    <script type="text/javascript" language="javascript">

        function funcion(foto){
        
            var elemento = document.getElementById("imagenPrincipal")
            elemento.setAttribute("src","/imagenes/" + foto + ".jpg");
            
        }
        
   </script>

    
</asp:Content>



