<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="mostrarMaterial.aspx.cs" Inherits="WebCacatUA.mostrarMaterial" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_titulo" runat="server">
<p>Materiales</p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenido" runat="server">

<style type="text/css">
    
#navegacion_mostrarMaterial
{
	font-size:small;
    padding-bottom:10px;	
}

#nombreMaterial_mostrarMaterial
{
    font-size:x-large;
    background-color:#1e6393;
    padding:5px;
}

#usuario_mostrarMaterial
{
	font-weight:bold;
}

#fecha_mostrarMaterial
{
	font-weight:bold;
}

#descargas_mostrarMaterial
{
	font-weight:bold;
}

#tamaño_mostrarMaterial
{
	font-weight:bold;
}

#valoracion_mostrarMaterial
{
	font-weight:bold;
}

#descripcion_mostrarMaterial
{
	font-weight:bold;
}

.columnaContenido_mostrarMaterial
{
    
}

.titulo_mostrarMaterial
{
	width:130px;
}


#ctl00_ContentPlaceHolder_contenido_tabla_mostrarComentatios
{
    width:100%;
    border-color:Black;
    border-width:2px;
}

#tabla_nombreMaterial
{
	width:100%;
}

#columna_titulo
{
	
}

#columna_valoracion
{
    text-align:center;	
    background-color:White;
    width:30px;
}

#contenido_mostrarMaterial
{

}

#descargar_mostrarMaterial
{
	font-size:x-large;
}

#nuevoComentario_mostrarMaterial
{
	margin-top:15px;
	-moz-border-radius: 5px;
	-webkit-border-radius: 5px;
	background-color:#1e6393;
}

hr {
    color: #000000;
    font-size: 10px;
    margin:5px;
}

#tituloComentario_mostrarMaterial
{
	padding-top:10px;
    margin-left:10px;	
    color:White;
}

#comentario_mostrarMaterial
{
    margin-right:15px;
    margin-left:10px;
}

#enviarComentario_mostrarMaterial
{
    margin-top:10px;
    padding-bottom:5px;	
    margin-left:10px;
}

#tabla_paginacion_mostrarMaterial
{
    width:100%;	
}

#cantidad_paginacion_mostrarMaterial
{
    text-align:right;	
}

#botones_paginacion_mostrarMaterial
{
    text-align:right;	
}

#tabla_resultados_mostrarMaterial
{
	width:100%;
}

#ordenar_mostrarMaterial
{
	text-align:right;
}

#titulo_ordenar_mostrarMaterial
{
	font-weight:bold;
	text-align:right;
}

#propiedades_ordenar_mostrarMaterial
{
	font-weight:normal;
	width:100%;
}

#resultados_mostrarMaterial
{
	text-align:left;
	width:100%;
}

#numero_resultados_mostrarMaterial
{
	font-weight:bold;
	text-align:left;
	width:100%;
}

#botonNuevoComentario_mostrarMaterial
{
    text-align:right;	
}

</style>
    
<script  type="text/javascript">

function decrementarCantidad()
{
    var cantidad = document.getElementById("<%= DropDownList_pagina.ClientID %>").value;
    cantidad = parseInt(cantidad);
    cantidad = cantidad-1;
    document.getElementById("<%= DropDownList_pagina.ClientID %>").value = cantidad;
}

function incrementarCantidad()
{
    var cantidad = document.getElementById("<%= DropDownList_pagina.ClientID %>").value;
    cantidad = parseInt(cantidad);
    cantidad = cantidad+1;
    document.getElementById("<%= DropDownList_pagina.ClientID %>").value = cantidad;
}

function prueba()
{
    alert("hola");
}

</script>


<div id="contenido_mostrarMaterial">


<div id="navegacion_mostrarMaterial">
    <asp:Label ID="Label6" runat="server" Text="Estas aquí: "></asp:Label>
    <asp:Label ID="Label_ruta" runat="server" Text="ruta"></asp:Label>
</div>

<div id="nombreMaterial_mostrarMaterial">
    <table id="tabla_nombreMaterial">
        <tr>
            <td id="columna_titulo">
                <asp:Label ID="Label_nombre" runat="server" Text="nombre_material"></asp:Label>
            </td>
        </tr>
    </table>
    
</div>   


    
<table id="tabla_mostrarMaterial">
    <tr>
        <td class="titulo_mostrarMaterial">
            <div id="usuario_mostrarMaterial">
                <asp:Label ID="Label5" runat="server" Text="Usuario:"></asp:Label>               
            </div>
        </td>
        <td class="columnaContenido_mostrarMaterial">
            <asp:HyperLink ID="HyperLink_usuario" Text="nombre_usuario" runat="server"></asp:HyperLink> |
            <asp:HyperLink ID="HyperLink_otrosMateriales" Text="otros materiales" runat="server"></asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td class="titulo_mostrarMaterial">
            <div id="fecha_mostrarMaterial">
                <asp:Label ID="Label1" runat="server" Text="Fecha:"></asp:Label>
            </div>
        </td>
        <td class="columnaContenido_mostrarMaterial">
            <asp:Label ID="Label_fecha" runat="server" Text="fecha"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="titulo_mostrarMaterial">
            <div id="descargas_mostrarMaterial">
                <asp:Label ID="Label3" runat="server" Text="Descargas:"></asp:Label>
            </div>
        </td>
        <td class="columnaContenido_mostrarMaterial">
            <asp:Label ID="Label_descargas" runat="server" Text="descargas"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="titulo_mostrarMaterial">
            <div id="tamaño_mostrarMaterial">
                <asp:Label ID="Label2" runat="server" Text="Tamaño:"></asp:Label>
            </div>
        </td>
        <td class="columnaContenido_mostrarMaterial">
            <asp:Label ID="Label_tamaño" runat="server" Text="tamaño"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="titulo_mostrarMaterial">
            <div id="valoracion_mostrarMaterial">
                <asp:Label ID="Label9" runat="server" Text="Valoración:"></asp:Label>
            </div>
        </td>
        <td class="columnaContenido_mostrarMaterial">
            <asp:Label ID="Label_valoracion" runat="server" Text="valoracion"></asp:Label>
            <asp:Label ID="Label_votos" runat="server" Text="num_votos"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="titulo_mostrarMaterial">
            <div id="descripcion_mostrarMaterial">
                <asp:Label ID="Label7" runat="server" Text="Descripcion:"></asp:Label>
            </div>            
        </td>
        <td class="columnaContenido_mostrarMaterial">
            <asp:Label ID="Label_descripcion" runat="server" Text="descripcion_material"></asp:Label>
        </td>
    </tr>
</table>

<div id="descargar_mostrarMaterial">
    <asp:ImageButton ID="ImageButton1" ImageUrl="~/imagenes/descargar.png" runat="server" />
    <asp:HyperLink ID="HyperLink_descargar" runat="server" Text="Descargar"></asp:HyperLink>
</div>

</div>
<br />
<br />
        <div id="resultados_mostrarMaterial" runat="server">
            <table id="tabla_resultados_mostrarMaterial">
                <tr>
                    <td>
                        <div id="numero_resultados_mostrarMaterial">
                            <asp:Label ID="Label_resultados" runat="server" Text="resultados"></asp:Label>
                        </div>
                    </td>
                    <td>
                        <div id="botonNuevoComentario_mostrarMaterial">
                            <asp:Button ID="Button_nuevoMaterial" runat="server" Text="Nuevo comentario" 
                                PostBackUrl="#marcadorComentario" />
                        </div> 
                    </td>
                </tr>
            </table>
        </div>
        <hr />
        <asp:Panel
            ID="Panel_comentarios" runat="server">
        </asp:Panel>  
        
        
        <div id="paginacion_mostrarMaterial" runat="server">
            <table id="tabla_paginacion_mostrarMaterial">
                <tr> 
                    <td>
                        <div id="cantidad_paginacion_mostrarMaterial">
                            <asp:Label ID="Label8" runat="server" Text="Cantidad por página:"></asp:Label>
                            <asp:DropDownList ID="DropDownList_cantidadPorPagina" runat="server" 
                                AutoPostBack="True" 
                                onselectedindexchanged="DropDownList_cantidadPorPagina_SelectedIndexChanged">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem Selected="True">4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                            </asp:DropDownList>       
                                    
                            <span id="botones_paginacion_mostrarMaterial">
                                <asp:Button ID="Button_anterior" runat="server" Text="Anterior" OnClientClick='decrementarCantidad()' />
                                <asp:DropDownList ID="DropDownList_pagina" runat="server" AutoPostBack="True">
                                    <asp:ListItem Selected="True">1</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="Button_siguiente" Text="Siguiente" OnClientClick="incrementarCantidad()" runat="server" />                       
                            </span>             
                        </div>                
                    </td>
                </tr>
            </table>
        </div>
  
<div id="nuevoComentario_mostrarMaterial">
    <div id="tituloComentario_mostrarMaterial">
        <asp:Label ID="Label4" runat="server" Text="Escribir un comentario"></asp:Label>
    </div>
    
    <hr />
    <div id="comentario_mostrarMaterial">
        <a name="marcadorComentario"></a>
        <textarea id="TextArea1" style="width:100%;" cols="20" runat="server" rows="2"></textarea>
    </div>
    <div id="enviarComentario_mostrarMaterial">
        <asp:Button ID="Button1" runat="server" Text="Enviar comentario" 
            onclick="Button1_Click" />
    </div>
        
    
    
</div>
</asp:Content>
