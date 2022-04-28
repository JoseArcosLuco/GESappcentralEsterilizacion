<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="admsolicitudes.aspx.cs" Inherits="ges.data.presentation.admsolicitudes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="./js/jquery-3.3.1.js"></script>
    <script src="./js/jquery.dataTables.min.js"></script>
    <script src="./js/ia.core.js"></script>
    <script src="./js/mantenedores/admagenda.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="display-2">Solicitudes</h1>

    <asp:Label ID="datos" runat="server" Text="-"></asp:Label>

    <form id="formularioAgregar" name="formularioAgregar" method="post" runat="server">
        <asp:hiddenfield runat="server" id="idAgenda"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="idUsuario"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="idUsuaruioProfesional"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="idUsuarioPaciente"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="idArea"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="estadoAgenda"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="accionAProcesar"></asp:hiddenfield>
    </form>

</asp:Content>
