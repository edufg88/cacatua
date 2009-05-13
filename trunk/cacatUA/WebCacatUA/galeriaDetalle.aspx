<%@ Page Language="C#" MasterPageFile="~/PaginaMaestraUsuario.Master" AutoEventWireup="true" CodeBehind="galeriaDetalle.aspx.cs" Inherits="WebCacatUA.Formulario_web1" Title="Página sin título" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_headUsuario" runat="server">
    <link rel="stylesheet" type="text/css" href="estilos/galeria.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_tituloUsuario" runat="server">
    <p><asp:Label ID="Label_nombreUsuario" runat="server" Text="Galeria de fotos"></asp:Label></p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_contenidoUsuario" runat="server">

    <div id="contenidoGaleriaDetalle">
        <p id="tituloImagen"><a name="tituloImagen"><asp:Label ID="labelTitulo" runat="server" Text="Titulo"></asp:Label></a></p><br />
        <br />
        <asp:Label ID="labelFecha" runat="server" Text="Fecha"></asp:Label><br />
        <asp:Label ID="labelUsuario" runat="server" Text="Usuario"></asp:Label><br />
        <br />
        <br />
        <asp:Panel ID="panelImagen" runat="server" >
            <asp:Table ID="tablaNavegarImagenes" runat="server">
            </asp:Table>
            <asp:Image ID="imagenPrincipal" runat="server" Width="600px" ImageUrl=""/>
        </asp:Panel>
        <br />
        <br />
        <asp:Label ID="labelDescripcion" runat="server" Text="Descripcion"></asp:Label>
        <br />
        <br />
        <h2><a name="comienzoComentariosImagenes">Comentarios</a></h2>
        <br />
        
        <table id="tablaPaginacionSuperior">
                <tr>  
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Cantidad por página:"></asp:Label>
                        <asp:DropDownList ID="DropDownList_cantidadPorPaginaSuperior" runat="server" 
                        AutoPostBack="True" OnSelectedIndexChanged="cambioCantidadSuperior">
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
                        <div id="botonesPaginacionSuperior">
                            <input id="Hidden_paginaAnterior" type="hidden" runat="server" />
                            <asp:Button ID="Button_anteriorSuperior" runat="server" OnClientClick="decrementarCantidadInferior()" Text="Anterior" />
                            <asp:DropDownList ID="DropDownList_paginaSuperior" runat="server" AutoPostBack="True">
                                <asp:ListItem Selected="True">1</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="Button_siguienteSuperior" runat="server" OnClientClick="incrementarCantidadInferior()" Text="Siguiente"/>                       
                        </div>                          
                    </td>
                </tr>
            </table>
        <asp:Table ID="tablaComentarios" runat="server" Width="100%">
        </asp:Table>
        <table id="tablaPaginacionInferior">
                <tr>  
                    <td>
                        <asp:Label ID="Label_cantidadPorPaginaAnterior" runat="server" Text="5"></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text="Cantidad por página:"></asp:Label>
                        <asp:DropDownList ID="DropDownList_cantidadPorPaginaInferior" runat="server" 
                        AutoPostBack="true" OnSelectedIndexChanged="cambioCantidadInferior">
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
                        <div id="divBotonesPaginacionInferior">
                            <input id="Hidden1" type="hidden" runat="server" />
                            <asp:Button ID="Button1" runat="server" OnClientClick="decrementarCantidadInferior()" Text="Anterior" />
                            <asp:DropDownList ID="DropDownList_paginaInferior" runat="server" AutoPostBack="True">
                                <asp:ListItem Selected="True">1</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="Button2" runat="server" OnClientClick="incrementarCantidadInferior()" Text="Siguiente"/>                       
                        </div>                          
                    </td>
                </tr>
            </table>
        <br />
        <br />
        <h3>Añadir comentario</h3>
        <asp:TextBox ID="TextBoxComentario" runat="server" Rows="5" TextMode="MultiLine" Width="100%"></asp:TextBox>
        <p style="width: 100%; text-align: center;"><asp:Button ID="botonComentar" runat="server" Text="Comentar" OnClick="guardarComentario" /></p>
   
   </div>
   <script  type="text/javascript">


        function decrementarCantidadInferior()
        {
            var cantidad = document.getElementById("<%= DropDownList_paginaSuperior.ClientID %>").value;
            cantidad = parseInt(cantidad);
            cantidad = cantidad-1;
            document.getElementById("<%= DropDownList_paginaSuperior.ClientID %>").value = cantidad;
        }

        function incrementarCantidadInferior()
        {
            var cantidad = document.getElementById("<%= DropDownList_paginaSuperior.ClientID %>").value;
            cantidad = parseInt(cantidad);
            cantidad = cantidad+1;
            document.getElementById("<%= DropDownList_paginaSuperior.ClientID %>").value = cantidad;
        }
        
        function cambioCantidadSuperior()
        {
            var cantidad = document.getElementById("<%= DropDownList_cantidadPorPaginaSuperior.ClientID %>").value;
            cantidad = parseInt(cantidad);
            document.getElementById("<%= DropDownList_cantidadPorPaginaInferior.ClientID %>").value = cantidad;
            
        }

        

    </script>
    
</asp:Content>
