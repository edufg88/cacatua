<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="nuevoMaterial.ascx.cs" Inherits="WebCacatUA.nuevoMaterial1" %>

<style type="text/css">
    
hr {
    color: #000000;
    font-size: 10px;
    margin:5px;
}

#ctl00_ContentPlaceHolder_contenido_Panel_nuevoMaterial
{
    width:730px;	
}

.boton_nuevoMaterial
{
	background-color:White;
	-moz-border-radius: 5px;
	-webkit-border-radius: 5px;
	width: 500px;
}

#contenido_nuevoMaterial
{
	margin-top:20px;
	background-color:#1e6393;
	-moz-border-radius: 5px;
	-webkit-border-radius: 5px;
}

#titulo_nuevoMaterial
{
	color:White;
	margin-left:10px;
	padding-top:10px;
}

#nombre_nuevoMaterial
{
	color:White;
	margin-left:10px;
	padding-top:10px;
}

#descripcion_nuevoMaterial
{
	color:White;
	margin-left:10px;
	padding-top:10px;
	width:100%;
}

#referencia_nuevoMaterial
{
	color:White;
	margin-left:10px;
	padding-top:10px;	
}

#archivo_materiales
{
	color:White;
	margin-left:10px;
	padding-top:10px;		
}

#botonCrearMaterial_materiales
{
	padding-top:10px;		
	margin-left:10px;
	padding-bottom:10px;	
}

</style>


<div id="contenido_nuevoMaterial">
    <div id="titulo_nuevoMaterial">
        <asp:Label ID="Label4" runat="server" Text="Subir un material"></asp:Label>
        <input id="Hidden_categoria" type="hidden" runat="server" />
        <a name="marcadorNuevoMaterial"></a>
    </div>
    <hr />
    <div id="nombre_nuevoMaterial">
        <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="TextBox_nombre" class="boton_nuevoMaterial" runat="server" Width="500px"></asp:TextBox>
    </div>
    
    <div id="descripcion_nuevoMaterial">
        <asp:Label ID="Label2" runat="server" Text="Descripción:"></asp:Label>
        <div id="contenidoDescripcion_nuevoMaterial">
            <textarea id="TextArea_descripcion" style="width:580px;" class="boton_nuevoMaterial" runat="server" 
                name="S1" rows="5"></textarea>
        </div>
    </div>
        
    <div id="referencia_nuevoMaterial">
        <asp:Label ID="Label_referencia" runat="server" Text="Referencia:"></asp:Label>
        <asp:TextBox ID="TextBox_referencia" runat="server" class="boton_nuevoMaterial" Width="480px"></asp:TextBox>   
    </div>
    
    <div id="archivo_materiales">
        <asp:Label ID="Label3" runat="server" Text="Archivo:"></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" Width="215px" />
    </div>
    
    <div id="botonCrearMaterial_materiales">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Crear material" />
    </div>
</div>