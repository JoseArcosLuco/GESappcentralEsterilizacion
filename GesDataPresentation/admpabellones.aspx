<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="admpabellones.aspx.cs" Inherits="ges.data.presentation.admpabellones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="./js/jquery-3.3.1.js"></script>
    <script src="./js/jquery.dataTables.min.js"></script>
    <script src="./js/ia.core.js"></script>
    <script src="./js/mantenedores/admpabellones.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="display-2">Mantenedor Pabellón</h1>

    <button type="button" class="btn btn-primary btn-fw" title="Agregar Nuevo Pabellon" data-toggle="modal" data-target="#modalAgregar">Agregar</button>
    <button type="button" class="btn btn-primary btn-fw" title="Ir a Servicios" onclick="javascript:DynamicForm('admservicios.aspx');">Ir a Servicios</button>
    
    <br /><br />
    <div class="row">
        <div class="col-md-2 display-4">Servicios:</div>
        <div class="col-md-4">
            <asp:Label ID="comboServicios" runat="server" class="display-4" Text="Servicios"></asp:Label>
        </div>
        <div>
            <button id="buttonBuscar" type="button" runat="server" class="btn btn-primary btn-fw" onclick="javascript:CambioServicio()">Buscar</button>
        </div>
    </div>

    <asp:Label ID="datos" runat="server" Text="-"></asp:Label>
    
    <!-- Inicio Modal Agregar -->
            <div class="modal fade" id="modalAgregar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title titulomodal" id="myModalLabel">Agregar Pabellon</h4>
                        </div>
                        <div class="modal-body">
                            <div class="formulario">
                                <form id="formularioAgregar" name="formularioAgregar" method="post" runat="server">
                                    <asp:hiddenfield runat="server" id="idServicio"></asp:hiddenfield>
                                    <asp:hiddenfield runat="server" id="nombreServicio"></asp:hiddenfield>
                                    <asp:hiddenfield runat="server" id="idPabellon"></asp:hiddenfield>
                                    <asp:hiddenfield runat="server" id="estadoPabellon"></asp:hiddenfield>
                                    <asp:hiddenfield runat="server" id="accionAProcesar"></asp:hiddenfield>
                                    <div class="row">
                                        <div class="col-md-4 text-left">
                                            <span class="glyphicon glyphicon-asterisk red"></span>
                                            <label for="cmpnombre">Servicios</label>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:Label ID="comboServiciosAgregar" runat="server" Text="Servicios"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4 text-left">
                                            <span class="glyphicon glyphicon-asterisk red"></span>
                                            <label for="cmpnombre">Nombre Pabellón</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpnombre" id="cmpnombre" placeholder="Nombre Pabellon" maxlength="150" onkeypress="return soloLetrasVariado(event)" aria-required="True" required="required"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4 text-left">
                                            <span class="glyphicon glyphicon-asterisk red"></span>
                                            <label for="cmpnombre">Descripción</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpdescripcion" id="cmpdescripcion" placeholder="Descripción" maxlength="500" onkeypress="return soloLetrasVariado(event)" aria-required="True" required="required"/>
                                        </div>
                                    </div>
                                    <div class="row"></div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                        <asp:button id="Button1" runat="server" text="Grabar" class="btn btn-primary btn-fw" onclick="Button1_Click"/>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Final Modal -->
</asp:Content>
