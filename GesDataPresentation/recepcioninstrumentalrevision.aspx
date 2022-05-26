<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="recepcioninstrumentalrevision.aspx.cs" Inherits="ges.data.presentation.recepcioninstrumentalrevision" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="./js/jquery-3.3.1.js"></script>
    <script src="./js/jquery.dataTables.min.js"></script>
    <script src="./js/ia.core.js"></script>
    <script src="./js/recepcioncontenedores/recepcioninstrumentalrevision.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="formularioAgregar" name="formularioAgregar" method="post" runat="server">
        <asp:hiddenfield runat="server" id="idUsuario"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="idServicio"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="nombreServicio"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="idPabellon"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="idCodigoTrazable"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="nombreArticulo"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="idBodega"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="nombreBodega"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="accionAProcesar"></asp:hiddenfield>
        <div class="row">
            <div class="col-md-6 col-xs-12">
                <div class="row">
                    <div class="col-md-12 text-left">
                        <h1 class="display-6"><asp:Label id="lblArea" runat="server" Text="Área ? / Revisión"></asp:Label></h1>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2">
                        &nbsp;
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 text-left">
                        <h1 class="display-5">Codigo: <asp:Label id="lblCodigoTrazable" runat="server" Text=""></asp:Label> </h1>
                    </div>
                    <div class="col-md-6 text-left">
                        <h1 class="display-5">Nombre: <asp:Label id="lblnombreArticulo" runat="server" Text=""></asp:Label></h1>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2">
                        &nbsp;
                    </div>
                </div>   
                <div class="row">
                    <div class="col-md-5 text-left">
                        <span class="glyphicon glyphicon-asterisk red"></span>
                        <label for="cmpnombre">Servicio:</label>
                    </div>
                    <div class="col-md-7">
                        <asp:Label id="comboServicios" runat="server" Text="Servicios"></asp:Label>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-5 text-left">
                        <span class="glyphicon glyphicon-asterisk red"></span>
                        <label for="cmpnombre">Cantidad Material a Lavar:</label>
                    </div>
                    <div class="col-md-7">
                        <input runat="server" type="text" class="form-control"  name="cmpcantmaterialalavar" id="cmpcantmaterialalavar" placeholder="Cantidad Material" maxlength="4" onkeypress="return soloNumeros(event)" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-5 text-left">
                        <span class="glyphicon glyphicon-asterisk red"></span>
                        <label for="cmpnombre">Observaciones</label>
                    </div>
                    <div class="col-md-7">
                        <input runat="server" type="text" class="form-control"  name="cmpobs" id="cmpobs" placeholder="Observaciones" maxlength="100" onkeypress="return soloLetrasVariado(event)"/>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-2">
                        &nbsp;
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 text-center">
                        <asp:Button ID="Button_Asignar_Punto_Control" runat="server" Text="Grabar Recepción" class="btn btn-success btn-fw" OnClick="Button_Asignar_Punto_Control_Click" />
                    </div>
                    <div class="col-md-4 text-center">
                        &nbsp;
                        <input type ="button" value ="Volver" onclick="Volver()" class="btn btn-info btn-fw" />
                    </div>
                    <div class="col-md-4 text-center">
                    </div>
                </div>
            </div>
            <div class="col-md-6 col-xs-12">
                <div class="row">
                    <div class="col-md-12">
                        <h1 class="display-4">Lista de Trazabilidad Por Tiempo </h1>           
                    </div>
                </div>
                <div class="row">
                    <div id="divHistorial" class="table-responsive">
                        <asp:Label ID="lblTrazabilidad" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
