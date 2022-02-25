<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="recepcionsalidaesterilizacion.aspx.cs" Inherits="ges.data.presentation.recepcionsalidaesterilizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="./js/datatables/jquery-3.3.1.js"></script>
    <script src="./js/ia.core.js"></script>
    <script src="./js/recepcioncontenedores/recepcionsalidaesterilizacion.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="formularioAgregar" name="formularioAgregar" method="post" runat="server"> 
      <asp:hiddenfield runat="server" id="idBodega" Value="2"></asp:hiddenfield>
      <asp:hiddenfield runat="server" id="idCodigoTrazable"></asp:hiddenfield>
      <asp:hiddenfield runat="server" id="nombreArticulo"></asp:hiddenfield>
      <asp:hiddenfield runat="server" id="idUsuario"></asp:hiddenfield>
    <h3 class="display-4"><i class="mdi mdi-chart-histogram"></i> Recepción Bodega Central </h3>
    <div class="row">
        <div class="col-md-2">
            <label for="cmpvalor">Codigo Busqueda</label>
        </div>
        <div class="col-md-6">
            <input runat="server" type="text" class="form-control" name="cmpcodigobusqueda" id="cmpcodigobusqueda" placeholder="Codigo Busqueda" maxlength="15" onkeypress="return soloLetrasVariado(event)" aria-required="True" required="required"  style="background-color:lavender;"/>
        </div>
        <div class="col-md-4">
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <!--button type="button" class="btn btn-primary btn-fw" title="Buscar" data-toggle="modal" data-target="#modalAgregar">Buscar</button-->
            <asp:Button class="btn btn-primary btn-fw" ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
            Busqueda:
        </div>
        <div class="col-xs-8">
            <p class='text-info'><asp:Label ID="datosSalida" runat="server" Text="Debe ingresar un codigo de contenedor para ingresar a lavado."></asp:Label> </p>               
        </div>
        <div class="col-md-8">
            Articulos en Recepción Salida Material Esteril
        </div>
        <div class="col-md-12">
            <asp:Label ID="datosEnBodega" runat="server" Text="---"></asp:Label>                
        </div>
    </div>
 </form>
</asp:Content>
