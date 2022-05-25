<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="recepcioninstrumental.aspx.cs" Inherits="ges.data.presentation.recepcioninstrumental" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="./js/jquery-3.3.1.js"></script>
    <script src="./js/jquery.dataTables.min.js"></script>
    <script src="./js/ia.core.js"></script>
    <script src="./js/recepcioncontenedores/recepcioninstrumental.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-2"><i class="mdi mdi-chart-histogram"></i>Recepción Instrumental</h1>

    <form id="formularioAgregar" name="formularioAgregar" method="post" runat="server"> 
        <asp:hiddenfield runat="server" id="idUsuario"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="idBodega" Value="2"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="nombreBodega"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="idCodigoTrazable"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="nombreArticulo"></asp:hiddenfield>
        
        <div class="row">
            <div class="col-md-2">Área de Recepción:</div>
            <div class="col-md-8">
                <asp:Label ID="comboAreaRecepcion" runat="server" text="-"></asp:Label>
            </div>
        </div>
        
        <br />
        <div class="row">
            <div class="col-md-2">
                <label for="cmpvalor">Código Búsqueda:</label>
            </div>
            <div class="col-md-4">
                <input runat="server" type="text" class="form-control" name="cmpcodigobusqueda" id="cmpcodigobusqueda" placeholder="Código Búsqueda" maxlength="15" onkeypress="return soloLetrasVariado(event)" aria-required="True" required="required"/>
            </div>
            <div class="col-md-6">
                <asp:Button class="btn btn-primary btn-fw" ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"/>
            </div>
        </div>
     </form>
    
    <br />
    <div class="row">
        <div class="col-md-8 display-5">
            Busqueda:
        </div>
    </div>
    <div class="col-md-12">
        <p class='text-info'>
            <asp:Label ID="datosSalida" runat="server" Text="Debe ingresar un codigo de contenedor para su ingreso."></asp:Label>
        </p>               
    </div>

    <div id="datosArea" class="col-md-8 display-5">
        Articulos en Área: 
    </div>
    <div class="col-md-12">
        <p class='text-info'>
            <asp:Label ID="datosEnBodega" runat="server" Text="Debe seleccionar un área de recepción."></asp:Label>
        </p>                 
    </div>
</asp:Content>
