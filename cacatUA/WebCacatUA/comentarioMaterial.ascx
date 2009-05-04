<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="comentarioMaterial.ascx.cs" Inherits="WebCacatUA.comentarioMaterial" %>

<style type="text/css">
    
#tabla_comentarioMaterial tr
{
    vertical-align:top;
}
    
#columna1_comentarioMaterial
{

}

#columna2_comentarioMaterial
{
	width:100%;
}

.usuario_comentarioMaterial
{
	color:#1e6393;
	text-align:center;
	text-decoration:none;
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
            <div id="imagen_comentarioMaterial">
                <asp:Image ID="Image_perfil" runat="server" Height="100px" />
            </div>
            <div class="usuario_comentarioMaterial">
                <asp:HyperLink ID="HyperLink_usuario" runat="server" Text="nombre_usuario" CssClass="usuario_comentarioMaterial"></asp:HyperLink>
            </div>
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