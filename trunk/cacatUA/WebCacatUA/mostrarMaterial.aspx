<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="mostrarMaterial.aspx.cs" Inherits="WebCacatUA.mostrarMaterial" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    
#navegacion_mostrarMaterial
{
	font-size:normal;
    padding-bottom:10px;	
}

#nombreMaterial_mostrarMaterial
{
    font-size:x-large;
    padding-bottom:5px;
    padding-left:2px;
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

#referencia_mostrarMaterial
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


#tabla_nombreMaterial
{
	width:100%;
}


#columna_valoracion
{
    text-align:center;	
    background-color:White;
    width:30px;
}

#descargar_mostrarMaterial
{
	font-size:x-large;
}

#nuevoComentarioAux_mostrarMaterial
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

.botonesPaginacion_mostrarMaterial
{
	text-align:right;
}

.tablaPaginacion_mostrarMaterial
{
	color:White;
	margin-top:10px;
	text-align:left;
	width:100%;
	padding:5px;
    background-color:#777777;	
	-moz-border-radius: 5px;
	-webkit-border-radius: 5px;
}

#mensajeError_mostrarMaterial
{   
	color:Red;
	margin-left:5px;
}

#votar_mostrarMaterial
{
    font-weight:normal;
    font-size:large;
}

.columnaPuntuacion
{
	padding-left:15px;
    padding-top:10px;
}

.enlaceDescargar
{
    color:White;	
    font-weight:normal;
}

/****************************************************
#####################################################
#####################################################
****************************************************/

.tabla_mostrarComentatios
{
    width: 100%;
    background-color: #fff;    
}

.columnaTabla_mostrarComentatios
{
	border-bottom: 1px solid #ddd;	
}

#resultados_mostrarMaterial
{
	text-align:left;
	width:100%;
}

#tabla_resultados_mostrarMaterial
{
	width:100%;
}

#contenidoTabla_mostrarMaterial
{
    margin-top: 5px;
    background-color: #777;
    border: 1px solid #888;
    padding: 4px 4px 4px 4px;
    -moz-border-radius: 5px;
    -webkit-border-radius: 5px;
    -ms-border-radius: 5px;
    -khtml-border-radius: 5px;
}

#contenido_mostrarMaterial
{
    margin-top: 5px;
    background-color: #777;
    border: 1px solid #888;
    padding: 4px 4px 4px 4px;
    -moz-border-radius: 5px;
    -webkit-border-radius: 5px;
    -ms-border-radius: 5px;
    -khtml-border-radius: 5px;	
    padding-left:10px;
    padding-right:10px;
}

#tabla_mostrarMaterial
{
    background-color:#DCD9CD;
    width:100%;	
}

#tabla_mostrarMaterial td
{
	padding-left:5px;
	padding-top:2px;
	padding-bottom:2px;
}

#tablaDescargar_mostrarMaterial
{
	width:100%;
}

.columnaDescargar
{
	
}

.columnaPuntuacion
{
	text-align:right;
}

#votar_mostrarMaterial
{
    color:White;	
}

</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_titulo" runat="server">
    <p><%= Resources.I18N.Materiales %></p>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenido" runat="server">
    
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

</script>

<div id="navegacion_mostrarMaterial">
    <%= Resources.I18N.EstasAqui + ":"%>
    <asp:Label ID="Label_ruta" runat="server" Text="ruta"></asp:Label>
</div>
    
<div id="contenido_mostrarMaterial">

    <div id="nombreMaterial_mostrarMaterial">
        <asp:Label ID="Label_nombre" runat="server" Text="nombre_material"></asp:Label>
    </div>   
        
    <table id="tabla_mostrarMaterial">
        <tr>
            <td class="titulo_mostrarMaterial">
                <div id="usuario_mostrarMaterial">
                    <%= Resources.I18N.Usuario + ":"%>             
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
                    <%= Resources.I18N.Fecha + ":"%>  
                </div>
            </td>
            <td class="columnaContenido_mostrarMaterial">
                <asp:Label ID="Label_fecha" runat="server" Text="fecha"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="titulo_mostrarMaterial">
                <div id="descargas_mostrarMaterial">
                    <%= Resources.I18N.Descargas + ":"%>  
                </div>
            </td>
            <td class="columnaContenido_mostrarMaterial">
                <asp:Label ID="Label_descargas" runat="server" Text="descargas"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="titulo_mostrarMaterial">
                <div id="tamaño_mostrarMaterial">
                    <%= Resources.I18N.Tamaño + ":"%>  
                </div>
            </td>
            <td class="columnaContenido_mostrarMaterial">
                <asp:Label ID="Label_tamaño" runat="server" Text="tamaño"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="titulo_mostrarMaterial">
                <div id="valoracion_mostrarMaterial">
                    <%= Resources.I18N.Puntuacion + ":"%>  
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
                    <%= Resources.I18N.Descripcion + ":"%>  
                </div>            
            </td>
            <td class="columnaContenido_mostrarMaterial">
                <asp:Label ID="Label_descripcion" runat="server" Text="descripcion_material"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="titulo_mostrarMaterial">
                <div id="referencia_mostrarMaterial">
                    <%= Resources.I18N.Referencia + ":"%> 
                </div>
            </td>
            <td class="columnaContenido_mostrarMaterial">
                <asp:Label ID="Label_referencia" runat="server" Text="referencia_material"></asp:Label>   
            </td>
        </tr>
    </table>

    <div id="descargar_mostrarMaterial">
        <table id="tablaDescargar_mostrarMaterial">
            <tr>
                <td class="columnaDescargar">
                    <asp:ImageButton ID="ImageButton1" ImageUrl="~/imagenes/descargar.png" runat="server" />
                    <asp:HyperLink ID="HyperLink_descargar" CssClass="enlaceDescargar" runat="server" Text="<%$ Resources: I18N, Descargar %>"></asp:HyperLink>  
                </td>
                <td class="columnaPuntuacion">
                    <asp:Panel ID="Panel_votar" runat="server">            
                        <div id="votar_mostrarMaterial">
                            <%= Resources.I18N.Puntuacion + ":"%> 
                            <asp:DropDownList ID="DropDownList_votar" runat="server">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem Selected="True">5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="Button_votar" runat="server" Text="<%$ Resources: I18N, Votar %>" onclick="Button_votar_Click" />
                        </div>   
                    </asp:Panel>    
                </td>
            </tr>
        </table>
    </div>

</div>
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
                        <div id="botonNuevoComentarioAux_mostrarMaterial" runat="server">
                            <div id="botonNuevoComentario_mostrarMaterial">
                                <input id="Button_nuevoMaterial" type="button" value="<%= Resources.I18N.AñadirComentario %>" onclick="window.location = '#nuevoComentario';" />
                            </div> 
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        
        <div id="contenidoTablaAux_mostrarMaterial" runat="server">
            <div id="contenidoTabla_mostrarMaterial">
                <asp:Panel
                    ID="Panel_comentarios" runat="server">
                </asp:Panel>  
            </div>       
        </div>

        <div id="paginacion_mostrarMaterial" runat="server">
            <table class="tablaPaginacion_mostrarMaterial">
                <tr> 
                    <td>
                        <%= Resources.I18N.CantidadPorPagina + ":" %>
                        <asp:DropDownList ID="DropDownList_cantidadPorPagina" runat="server" 
                            AutoPostBack="True">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem Selected="True">5</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>40</asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                                <asp:ListItem>60</asp:ListItem>
                                <asp:ListItem>70</asp:ListItem>
                                <asp:ListItem>80</asp:ListItem>
                                <asp:ListItem>90</asp:ListItem>
                                <asp:ListItem>100</asp:ListItem>
                        </asp:DropDownList>                       
                    </td>
                    <td>
                        <div class="botonesPaginacion_mostrarMaterial">     
                            <asp:Button ID="Button_anterior" runat="server" Text="<%$ Resources: I18N, Anterior %>" OnClientClick='decrementarCantidad()' />
                            <asp:DropDownList ID="DropDownList_pagina" runat="server" AutoPostBack="True">
                                <asp:ListItem Selected="True">1</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="Button_siguiente" Text="<%$ Resources: I18N, Siguiente %>" OnClientClick="incrementarCantidad()" runat="server" />                                
                        </div>                
                    </td>
                </tr>
            </table>
        </div>
  
    <asp:Panel ID="Panel_nuevoComentario" runat="server">
        <div id="nuevoComentario_mostrarMaterial" runat="server">
            <div id="nuevoComentarioAux_mostrarMaterial">
                 <div id="tituloComentario_mostrarMaterial">
                    <asp:Label ID="Label4" runat="server" Text="<%$ Resources: I18N, AñadirUnComentario %>"></asp:Label>
                </div>
                <hr />
                <div id="comentario_mostrarMaterial">
                    <a name="nuevoComentario"></a>
                    <asp:TextBox ID="TextBox_comentario" TextMode="MultiLine" Rows="2" Width="100%" runat="server"></asp:TextBox>
                </div>
                <div id="enviarComentario_mostrarMaterial">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="<%$ Resources: I18N, EnviarComentario %>" onclick="Button1_Click" />
                            </td>
                            <td>
                                <asp:Panel ID="Panel_mensajeError" runat="server" Visible="false">
                                    <div id="mensajeError_mostrarMaterial">     
                                        <asp:Label ID="Label_mensajeError" runat="server" Text="mensaje_error"></asp:Label>                             
                                    </div>     
                                </asp:Panel>               
                            </td>
                        </tr>
                    </table>
                </div>       
            </div>
        </div>
    </asp:Panel>
</asp:Content>
