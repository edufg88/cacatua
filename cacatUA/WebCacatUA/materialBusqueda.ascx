<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="materialBusqueda.ascx.cs" Inherits="WebCacatUA.materialBusqueda" %>

<style type="text/css">
    
#nombre_material
{
	margin-top:5px;
}

#descripcion_material
{
	margin-top:10px;
}

#categoria
{
	margin-top:10px;
	font-size:small;
	font-weight:bold;		
}

#categoria_material
{
	font-weight:normal;
	font-size:medium;	
}

#usuario
{
	margin-top:10px;
	font-size:small;
	font-weight:bold;
}

#nombre_usuario
{
	font-weight:normal;
	font-size:medium;
}

#fecha
{
	margin-top:10px;
	font-size:small;
	font-weight:bold;
	margin-bottom:5px;
}

#fecha_material
{
	font-weight:normal;
	font-size:small;
}

#descargas
{
	margin-top: 10px;
}  

#numeroVotos_materiales
{
	font-size:small;
	font-weight:normal;	
	color:Blue;
}

#columna1
{
	float:left;
	width: auto;
}

#columna2
{
	float: right;
	width: 130px;        
	text-align:center;
}

#titulo_descargas_materiales
{
	margin-top:15px;
	font-size:small;
	font-weight:normal;	
}
 
#numero_descargas_materiales
{
	font-weight:bold;
	font-size:medium;	
}

#titulo_puntuacion_materiales
{
	margin-top:10px;
	font-size:small;
	font-weight:normal;		
}

#contenido_puntuacion_materiales
{
	font-weight:bold;
	font-size:medium;		
}

</style>

<div id="material">
    <div id = "columna1">
         <div id = "nombre_material">
            <asp:HyperLink ID="HyperLink_material" runat="server">HyperLink_material</asp:HyperLink>
        </div>
        
        <div id = "descripcion_material">
            <asp:Label ID="Label_descripcion" runat="server" Text="descripcion_material"></asp:Label>
        </div>
        
        <div id="categoria">
            <%= Resources.I18N.Categoria + ":" %>
            <span id = "categoria_material">
            <asp:HyperLink ID="HyperLink_categoria" runat="server" Text="categoria_material"></asp:HyperLink>
            </span>
        </div>
        
        <div id = "usuario">
            <%= Resources.I18N.Usuario + ":" %>
            <span id = "nombre_usuario">
                <asp:Label ID="Label_usuario" runat="server" Text="nombre_usuario"></asp:Label>
            </span>
        </div>
        
        <div id = "fecha">
            <%= Resources.I18N.Fecha + ":" %>
            <span id = "fecha_material">
                <asp:Label ID="Label_fecha" runat="server" Text="fecha"></asp:Label>
            </span>
        </div>   
    </div>

    <div id = "columna2">
    
        <div id="titulo_puntuacion_materiales">
            <asp:Label ID="Label1" runat="server" Text="Puntuación"></asp:Label>
        </div>
        <div id="contenido_puntuacion_materiales">
            <asp:Label ID="Label_puntuacion" runat="server" Text="puntuacion"></asp:Label>
        </div>

        <div id="numeroVotos_materiales">
            <asp:Label ID="Label_votos" runat="server" Text="numero_votos"></asp:Label>
        </div>
    
        <div id = "titulo_descargas_materiales">
            <asp:Label ID="Label5" runat="server" Text="Descargas"></asp:Label>
            <div id="numero_descargas_materiales">
                <asp:Label ID="Label_descargas" runat="server" Text="descargas"></asp:Label>
            </div>
        </div>

    </div>
    

</div>


