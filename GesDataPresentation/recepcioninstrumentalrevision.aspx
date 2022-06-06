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
        <asp:hiddenfield runat="server" id="idCodigoTrazable"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="nombreArticulo"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="idBodega"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="nombreBodega"></asp:hiddenfield>
        <asp:hiddenfield runat="server" id="accionAProcesar"></asp:hiddenfield>
        <div class="row">
            <div class="col-md-10 col-xs-12">
                <div class="row">
                    <div class="col-md-12 text-left">
                        <h1 class="display-6"><asp:Label id="lblArea" runat="server" Text="Área ? / Revisión"></asp:Label></h1>
                    </div>
                </div>

                <br /> 
                <div class="row">
                    <div class="col-md-6 text-left">
                        <h1 class="display-5">Codigo: <asp:Label id="lblCodigoTrazable" runat="server" Text=""></asp:Label> </h1>
                    </div>
                    <div class="col-md-6 text-left">
                        <h1 class="display-5">Nombre: <asp:Label id="lblnombreArticulo" runat="server" Text=""></asp:Label></h1>
                    </div>
                </div>

                <br />
                <div class="row">
                    <div class="col-md-5 text-left">
                        <span class="glyphicon glyphicon-asterisk red"></span>
                        <label for="cmpnombre">Material Limpio:</label>
                    </div>
                    <div class="col-md-7">
                        <input runat="server" type="checkbox" class="form-control col-sm-1" name="cmpmateriallimpio" id="cmpmateriallimpio" placeholder="Material Limpio" value="1" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-5 text-left">
                        <span class="glyphicon glyphicon-asterisk red"></span>
                        <label for="cmpnombre">Material Organico Visible:</label>
                    </div>
                    <div class="col-md-7">
                        <input runat="server" type="checkbox" class="form-control col-md-1" name="cmpmaterialorganicovisible" id="cmpmaterialorganicovisible" placeholder="Material Organico Visible" value="1" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-5 text-left">
                        <span class="glyphicon glyphicon-asterisk red"></span>
                        <label for="cmpnombre">Desarme Piezas Ensambladas:</label>
                    </div>
                    <div class="col-md-7">
                        <input runat="server" type="checkbox" class="form-control col-md-1" name="cmpdesarmepiezasensambladas" id="cmpdesarmepiezasensambladas" placeholder="Desarme Piezas" value="Si" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-5 text-left">
                        <span class="glyphicon glyphicon-asterisk red"></span>
                        <label for="cmpnombre">Cantidad Material a Lavar:</label>
                    </div>
                    <div class="col-md-7">
                        <input runat="server" type="text" class="form-control" name="cmpcantidadmaterial" id="cmpcantidadmaterial" placeholder="Cantidad Material" maxlength="4" onkeypress="return soloNumeros(event)" required="required" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-5 text-left">
                        <label for="cmpnombre">Nombre Paciente:</label>
                    </div>
                    <div class="col-md-7">
                        <input runat="server" type="text" class="form-control" name="cmpnombrepaciente" id="cmpnombrepaciente" placeholder="Nombre Paciente" maxlength="350" onkeypress="return soloLetrasVariado(event)" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-5 text-left">
                        <label for="cmpnombre">Rut Paciente:</label>
                    </div>
                    <div class="col-md-7">
                        <input runat="server" type="text" class="form-control" name="cmprutpaciente" id="cmprutpaciente" placeholder="12345678-9" maxlength="10" onkeypress="return soloRut(event)" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-5 text-left">
                        <span class="glyphicon glyphicon-asterisk red"></span>
                        <label for="cmpnombre">Observaciones:</label>
                    </div>
                    <div class="col-md-7">
                        <input runat="server" type="text" class="form-control" name="cmpobservaciones" id="cmpobservaciones" placeholder="Observaciones" maxlength="250" onkeypress="return soloLetrasVariado(event)" required="required"/>
                    </div>
                </div>
                
                <br />
                <div class="row">
                    <div class="col-md-6 text-center">
                        <asp:Button ID="Button_Asignar_Punto_Control" runat="server" Text="Grabar Recepción" class="btn btn-success btn-fw" OnClick="Button_Asignar_Punto_Control_Click" />
                    </div>
                    <div class="col-md-6 text-center">
                        <input type ="button" value ="Volver" onclick="Volver()" class="btn btn-info btn-fw" />
                    </div>
                </div>
            </div>
        </div>

        <br /><br />
        <div class="col-md-12 col-xs-12">
            <div class="row">
                <h1 class="display-4">Lista de Trazabilidad Por Tiempo</h1>   
            </div>
            <div class="row">
                <div id="divHistorial" class="table-responsive">
                    <asp:Label ID="lblTrazabilidad" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
