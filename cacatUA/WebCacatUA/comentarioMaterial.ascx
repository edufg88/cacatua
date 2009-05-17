<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="comentarioMaterial.ascx.cs" Inherits="WebCacatUA.comentarioMaterial" %>

<style type="text/css">
    
#tabla_comentarioMaterial tr
{
    vertical-align:top;
}
    
#columna1_comentarioMaterial
{
	padding-left:8px;
    width: 110px;
    border-right: 1px solid #ddd;	
}

#columna2_comentarioMaterial
{

}

.imagen_comentarioMaterial
{
    display: block;
    margin-bottom: 10px;
    max-width: 100px;
    max-height: 100px;
}

.usuario_comentarioMaterial
{
	color:#1e6393;
	text-decoration:none;
	padding-bottom:5px;
}

.usuario_comentarioMaterial:visited
{
	color:#1e6393;
}

.usuario_comentarioMaterial:hover
{
	color:#1e6393;
	text-decoration:underline;
}

#fecha_comentarioMaterial
{
	margin-left:5px;
	font-weight:bold;
}

#texto_comentarioMaterial
{
	margin-left:5px;
    margin-top:10px;	
}

</style>

<table id="tabla_comentarioMaterial">
    <tr>
        <td id="columna1_comentarioMaterial">
            <div class="usuario_comentarioMaterial">
                <asp:HyperLink ID="HyperLink_usuario" runat="server" Text="nombre_usuario" CssClass="usuario_comentarioMaterial"></asp:HyperLink>
            </div>
            <asp:Image ID="Image_perfil" runat="server" Height="100px" />
        </td>
        <td id="columna2_comentarioMaterial">
            <div id="fecha_comentarioMaterial">
                <asp:Label ID="Label_fecha" runat="server" Text="fecha"></asp:Label>
            </div>
            <div id="texto_comentarioMaterial">
                <asp:Label ID="Label_comentario" runat="server" Text="comentario"></asp:Label>
            </div>
        </td>
    </tr>
</table>