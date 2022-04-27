<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="solicitudagenda.aspx.cs" Inherits="ges.data.presentation.solicitudagenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="./js/jquery-3.3.1.js"></script>
    <script src="./js/jquery.dataTables.min.js"></script>
    <script src="./js/ia.core.js"></script>
    <script src="./js/mantenedores/solicitudagenda.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-2">Ingreso Nueva Solicitud</h1>
    <br /><br />
    <div class="formulario" role="document">
        <form id="formularioAgregar" name="formularioAgregar" method="post" runat="server">
            <asp:hiddenfield runat="server" id="idUsuario"></asp:hiddenfield>
            <asp:hiddenfield runat="server" id="idUsuaruioProfesional"></asp:hiddenfield>
            <asp:hiddenfield runat="server" id="idUsuarioPaciente"></asp:hiddenfield>
            <asp:hiddenfield runat="server" id="idServicio"></asp:hiddenfield>
            <asp:hiddenfield runat="server" id="idArea"></asp:hiddenfield>
            <asp:hiddenfield runat="server" id="idPabellon"></asp:hiddenfield>
            <asp:hiddenfield runat="server" id="accionAProcesar"></asp:hiddenfield>
            <div class="row">
                <div class="col-md-2 text-left">
                    <span class="glyphicon glyphicon-asterisk red"></span>
                    <label for="cmpservicios">Servicios</label>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="comboServicios" runat="server" Text="Servicios"></asp:Label>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-2 text-left">
                    <span class="glyphicon glyphicon-asterisk red"></span>
                    <label for="cmppabellon">Pabellón</label>
                </div>
                <div class="col-md-8">
                    <asp:Label ID="comboPabellon" runat="server" Text="">
                        <select runat="server" class="form-control" aria-required="True" required="required"><option value="">Seleccione</option></select>
                    </asp:Label>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-2 text-left">
                    <span class="glyphicon glyphicon-asterisk red"></span>
                    <label for="cmpasunto">Asunto</label>
                </div>
                <div class="col-md-8">
                    <input runat="server" type="text" class="form-control" name="cmpasunto" id="cmpasunto" placeholder="Asunto" maxlength="120" onkeypress="return soloLetrasVariado(event)" aria-required="True" required="required"/>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-2 text-left">
                    <span class="glyphicon glyphicon-asterisk red"></span>
                    <label for="cmpdescripcion">Descripción</label>
                </div>
                <div class="col-md-8">
                    <input runat="server" type="text" class="form-control" name="cmpdescripcion" id="cmpdescripcion" placeholder="Descripción" maxlength="255" onkeypress="return soloLetrasVariado(event)" aria-required="True" required="required"/>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-2 text-left">
                    <span class="glyphicon glyphicon-asterisk red"></span>
                    <label for="cmpfecha">Fecha</label>
                </div>
                <div class="col-md-8">
                    <input runat="server" type="date" class="form-control" name="cmpfecha" id="cmpfecha" placeholder="Fecha" min="" onkeypress="return soloFecha(event)" aria-required="True" required="required"/>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-2 text-left">
                    <span class="glyphicon glyphicon-asterisk red"></span>
                    <label for="cmphora">Hora</label>
                </div>
                <div class="col-md-8">
                    <input runat="server" type="time" class="form-control" name="cmphora" id="cmphora" placeholder="Hora" onkeypress="return soloHora(event)" aria-required="True" required="required"/>
                </div>
            </div>
            <div class="col-md-10 footer" align="right">
                <asp:Button ID="Button1" runat="server" Text="Ingresar" class="btn btn-primary btn-fw" OnClick="Button1_Click"/>
            </div>
        </form>
    </div>
</asp:Content>
