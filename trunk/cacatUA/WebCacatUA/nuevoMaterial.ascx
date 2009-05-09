<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="nuevoMaterial.ascx.cs" Inherits="WebCacatUA.nuevoMaterial1" %>

<style type="text/css">
    
hr {
    color: #000000;
    font-size: 10px;
    margin:5px;
}

#tabla_nuevoMaterial
{
    color:White;
    font-size:normal;
    width:100%;
    padding:5px;
}

#tabla_nuevoMaterial tr
{
    padding:5px;
}

.columna1_nuevoMaterial
{
	padding-left:10px;
	vertical-align:super;
    width:120px;	
}

.columna2_nuevoMaterial
{
	text-align:left;
	padding-right:15px;
}

#contenido_nuevoMaterial
{
	margin-top:20px;
	background-color:#1e6393;
	width:100%;
	-moz-border-radius: 5px;
	-webkit-border-radius: 5px;		
}

#titulo_nuevoMaterial
{
	color:White;
	margin-left:10px;
	padding-top:8px;
}

#botonCrearMaterial_materiales
{	

}

.mensajeError_nuevoMaterial
{
    color:Red;
}

.filaMensajeError
{
	padding:0px;
	margin:0px;
}

</style>


<div id="contenido_nuevoMaterial">

    <div id="titulo_nuevoMaterial">
        <asp:Label ID="Label4" runat="server" Text="<%$ Resources: I18N, NuevoMaterial %>"></asp:Label>
        <input id="Hidden_categoria" type="hidden" runat="server" />
    </div>
    <hr />
    
    <table cellpadding="5px" id="tabla_nuevoMaterial">
        <tr>
            <td class="columna1_nuevoMaterial"> <%= Resources.I18N.Nombre + ":" %> </td>
            <td class="columna2_nuevoMaterial"><asp:TextBox ID="TextBox_nombre" runat="server" Width="100%"></asp:TextBox></td>
        </tr>
        <tr class="filaMensajeError">
            <asp:Panel ID="Panel_errorNombre" runat="server">
            <td></td>
            <td>
                <div class="mensajeError_nuevoMaterial">
                    <asp:Label ID="Label_errorNombre" runat="server" Text="error_nombre"></asp:Label>
                </div>
            </td>
            </asp:Panel>
        </tr>
        
        <tr>
            <td class="columna1_nuevoMaterial"><%= Resources.I18N.Descripcion + ":" %></asp:Label></td>
            <td class="columna2_nuevoMaterial"><asp:TextBox ID="TextBox_descripcion" TextMode="MultiLine" Rows=4 Width="100%" runat="server"></asp:TextBox></td>
        </tr>
        
        <asp:Panel ID="Panel_errorDescripcion" runat="server">
        <tr class="filaMensajeError">
            <td></td>
            <td>
                <div class="mensajeError_nuevoMaterial">
                    <asp:Label ID="Label_errorDescripcion" runat="server" Text="error_descripcion"></asp:Label>
                </div>
            </td>
        </tr>   
        </asp:Panel>
        
        <tr>
            <td class="columna1_nuevoMaterial"><%= Resources.I18N.Referencia + ":" %></asp:Label></td>
            <td class="columna2_nuevoMaterial"> <asp:TextBox ID="TextBox_referencia" runat="server" Width="100%"></asp:TextBox></td>
        </tr>
        <asp:Panel ID="Panel_errorReferencia" runat="server">
            <tr class="filaMensajeError">
                <td></td>
                <td>
                    <div class="mensajeError_nuevoMaterial">
                        <asp:Label ID="Label_errorReferencia" runat="server" Text="error_referencia"></asp:Label>
                    </div>
                </td>
            </tr>     
        </asp:Panel>        
        
        <tr>
            <td class="columna1_nuevoMaterial"><%= Resources.I18N.Archivo + ":" %></asp:Label></td>
            <td class="columna2_nuevoMaterial"><asp:FileUpload ID="FileUpload1" runat="server" Width="100%" size="84%" /></td>
        </tr>
        <asp:Panel ID="Panel_errorArchivo" runat="server">
            <tr class="filaMensajeError">
                <td></td>
                <td>
                    <div class="mensajeError_nuevoMaterial">
                        <asp:Label ID="Label_errorArchivo" runat="server" Text="error_archivo"></asp:Label>
                    </div>
                </td>
            </tr>     
        </asp:Panel> 
            
        <tr>
            <td>
                <div id="botonCrearMaterial_materiales">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="<%$ Resources: I18N, EnviarMaterial %>" />
                </div>
            </td>
            <td>
               <div class="mensajeError_nuevoMaterial">
                   <asp:Panel ID="Panel_mensajeError" runat="server" Visible="false">
                        <%= Resources.I18N.DebesIdentificarte %>
                   </asp:Panel>
               </div>         
            </td>
        </tr>
    </table>
</div>