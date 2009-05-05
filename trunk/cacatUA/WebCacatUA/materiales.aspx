<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeFile="materiales.aspx.cs" Inherits="materiales" Title="Materiales - CacatUA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_titulo" Runat="Server">
    <p>Materiales</p>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_contenido" Runat="Server">

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

function realizarBusqueda()
{
    var texto = document.getElementById("<%= TextBox_buscar.ClientID %>").value;
    var id = document.getElementById("<%= Hidden_opcionBusqueda.ClientID %>").value;
    var busqueda = "materiales.aspx?categoria=" + id + "&buscar=" + texto; 
    window.location=busqueda;
}

function cambiarOpcionMateriales()
{
    document.getElementById("<%= Hidden_opcionBusqueda.ClientID %>").value = "0";
}

function cambiarOpcionCategoria()
{
    var aux = document.getElementById("<%= Hidden_idCategoria.ClientID %>").value;
    document.getElementById("<%= Hidden_opcionBusqueda.ClientID %>").value = aux;
}

</script>

<style type="text/css">
    

hr {
    color: #000000;
    font-size: 10px;
    margin:5px;
}

#contenedor_materiales
{
	
}

#navegacion_materiales
{
	margin-top: 5px;
	margin-bottom: 10px;
}

#categorias_materiales
{
	float:left;
    width: 15%;
    padding: 2%;
    border-bottom: 1px solid #999999;
    border-right: 1px solid #aaaaaa;
    border-left: 1px solid #bbbbbb;
    border-top: 1px solid #cccccc;
	background-color: #ffffff;
	font-weight: bold;
}

#tituloCategorias_materiales
{
    padding-bottom: 20px;
    font-weight: bold;	
}

#contenidoCategorias_materiales
{
	margin:0px;
    font-size: small; 
    
}


#contenido_materiales
{
	float:right;
	width:79%;
	text-align:center;
}

.linkCategoria
{
	color:Black;
	text-decoration:none;
}

.linkCategoria:hover
{
	color:#1e6393;
}



#buscar
{
	background-color:#1e6393;
	-moz-border-radius: 5px;
	-webkit-border-radius: 5px;
	padding:5px;
}

#opcionesBusqueda
{
	color:Silver;
	width:100%;
}

#textBox_buscar_materiales
{
	padding-bottom:5px;
	padding-top:5px;
}

#boton_buscar_materiales
{
	margin-top:3px;
}

#material
{
	text-align:left;	
	width:100%;
}

#ctl00_ContentPlaceHolder_contenido_tabla_materiales
{
	
	width:100%;
}
#ctl00_ContentPlaceHolder_contenido_tabla_materiales tr
{
	
	width:100%;
}

#ordenar_materiales
{
	text-align:right;
}

#ctl00_ContentPlaceHolder_contenido_ordenar_materiales
{
	text-align:right;
}

#titulo_ordenar_materiales
{
	font-weight:bold;
	text-align:right;
}

#propiedades_ordenar_materiales
{
	font-weight:normal;
	width:100%;
}

#resultados_materiales
{
	text-align:left;
	padding-top:10px;
	width:100%;
}

#numero_resultados_materiales
{
	font-weight:bold;
	text-align:left;
	width:100%;
}

#tabla_resultados_materiales
{
	width:100%;
}



#tabla_paginacion_materiales
{
	color:White;
	margin-top:10px;
	text-align:left;
	width:100%;
}

#botones_paginacion_materiales
{
	text-align:right;
	
}



#panel_nuevoMaterial_materiales
{
	text-align:left;	
	
}


#contenidoDescripcion_nuevoMaterial
{
	margin-top:5px;	
	width:100%;
}

#referencia_nuevoMaterial
{
	margin-top:5px;
}

#archivo_materiales
{
	margin-top:5px;	
}

#tabla_paginacion_materiales
{
	padding:5px;
    background-color:#1e6393;	
	-moz-border-radius: 5px;
	-webkit-border-radius: 5px;
}

#ctl00_ContentPlaceHolder_contenido_tabla_materiales
{
    
}

/*
-moz-border-radius-bottomleft:5px;
-moz-border-radius-bottomright:5px;
-moz-border-radius-topleft:5px;
-moz-border-radius-topright:5px;
background-color:#777777;
border:1px solid #888888;
margin-bottom:20px;
margin-top:5px;
padding:4px;*/
   
</style>

<div id="contenedor_materiales">

    <div id="navegacion_materiales">
        <asp:Label ID="Label1" runat="server" Text="Estás aquí:"></asp:Label>
        <asp:Label ID="Label_ruta" runat="server" Text="Label"></asp:Label>
        <input id="Hidden_idCategoria" type="hidden" runat="server" />
    </div>

    <div id="categorias_materiales">
        <div id="tituloCategorias_materiales">
            <asp:Label ID="Label_categoria" runat="server" Text="Categorías"></asp:Label>
        </div>
        <div id="contenidoCategorias_materiales">
            <asp:Panel ID="Panel_categorias" runat="server"></asp:Panel>
        </div>   
    </div>
    
    <div id="contenido_materiales">
    
        <div id="buscar">
            <div id="textBox_buscar_materiales">
                    <asp:TextBox ID="TextBox_buscar" runat="server" Width="80%"></asp:TextBox> 
                    <input id="Button1" type="button" value="Buscar" onclick="realizarBusqueda()"/>
            </div>

            <div id="opcionesBusqueda">
                <input id="Radio_materiales" name="opciones" runat="server" type="radio" 
                    onclick="cambiarOpcionMateriales()" value="Materiales"/>
                <asp:Label ID="Label_radioMateriales" runat="server" Text="Materiales"></asp:Label>
                <input id="Radio_categoria" name="opciones" runat="server" checked="true" type="radio" onclick="cambiarOpcionCategoria()"/>        
                <asp:Label ID="Label_radioCategorias" runat="server" Text="categoria"></asp:Label>
                <input id="Hidden_opcionBusqueda" type="hidden" runat="server"/>  
            </div>
        </div>

        <div id="resultados_materiales">
            <table id="tabla_resultados_materiales">
                <tr>
                    <td>
                        <div id="numero_resultados_materiales">
                            <asp:Label ID="Label_resultados" runat="server" Text="resultados"></asp:Label>
                        </div>
                    </td>
                    <td>
                         <div id="ordenar_materiales" runat="server">
                            <span id="titulo_ordenar_materiales">
                                <asp:Label ID="Label3" runat="server" Text="Ordenar por:"></asp:Label>
                            </span>
                            <span id="propiedades_ordenar_materiales">
                                <asp:DropDownList ID="DropDownList_propiedadesOrdenar" runat="server" 
                                 AutoPostBack="True">
                                    <asp:ListItem Selected="True">fecha</asp:ListItem>
                                    <asp:ListItem>nombre</asp:ListItem>
                                    <asp:ListItem>descargas</asp:ListItem>
                                    <asp:ListItem>usuario</asp:ListItem>
                                    <asp:ListItem>puntuacion</asp:ListItem>
                             </asp:DropDownList>        
                            </span>
                        </div>                     
                    </td>
                </tr>
            </table>
        </div>
        <hr />
        <asp:Panel ID="Panel_contenido" runat="server"></asp:Panel>

        <div id="paginacion_materiales" runat="server">
            <table id="tabla_paginacion_materiales">
                <tr>  
                    <td>
                        <asp:Label ID="Label_cantidadPorPaginaAnterior" runat="server" Text="5"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="Cantidad por página:"></asp:Label>
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
                        <div id="botones_paginacion_materiales">
                            <asp:Button ID="Button_anterior" runat="server" OnClientClick="decrementarCantidad()" Text="Anterior" />
                            <asp:DropDownList ID="DropDownList_pagina" runat="server" AutoPostBack="True">
                                <asp:ListItem Selected="True">1</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="Button_siguiente" runat="server" OnClientClick="incrementarCantidad()" Text="Siguiente"/>                       
                        </div>                          
                    </td>
                </tr>
            </table>
        </div>
        
        <div id="panel_nuevoMaterial_materiales">
            <asp:Panel ID="Panel_nuevoMaterial" runat="server"></asp:Panel>   
        </div>

    </div>
     </div>
</asp:Content>
