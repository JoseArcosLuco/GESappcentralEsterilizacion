<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="admsolicitudes.aspx.cs" Inherits="ges.data.presentation.admsolicitudes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./css/jquery.dataTables.min.css" rel="stylesheet" />
    <!-- <meta http-equiv="refresh" content="5" /> -->
    <script src="./js/jquery-3.3.1.js"></script>
    <script src="./js/jquery.dataTables.min.js"></script>
    <script src="./js/ia.core.js"></script>
    <script src="./js/mantenedores/admagenda.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="display-2">Solicitudes</h1>

    <form id="formularioBuscar" name="formularioBuscar" method="post" runat="server">
        <asp:hiddenfield runat="server" id="idAgenda"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="idUsuario"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="idUsuaruioProfesional"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="idUsuarioPaciente"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="idArea"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="idPabellon"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="idEstado"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="estadoAgenda"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="accionAProcesar"></asp:hiddenfield>
        <div class="row">
            <div class="col-md-2 text-left">
                <label for="cmpidpabellon">Pabellón:</label>
            </div>
            <div class="col-md-4">
                <asp:Label ID="comboPabellon" runat="server" class="display-4" Text="Pabellon">
                </asp:Label>
            </div>
            <div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2 text-left">
                <label for="cmpidestado">Estado:</label>
            </div>
            <div class="col-md-4">
                <asp:Label ID="comboEstado" runat="server" class="display-4" Text="Estado">
                </asp:Label>
            </div>
            <div>
                <button id="buttonBuscar2" type="button" runat="server" class="btn btn-primary btn-fw" onclick="javascript:Buscar()">Buscar</button>
            </div>
        </div>
    </form>

    <asp:Label ID="datos" runat="server" Text="-"></asp:Label>

</asp:Content>
