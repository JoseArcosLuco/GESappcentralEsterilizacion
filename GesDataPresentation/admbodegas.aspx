<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="admbodegas.aspx.cs" Inherits="ges.data.presentation.admbodegas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./css/jquery.dataTables.min.css" rel="stylesheet" />
    
    <script src="./js/jquery-3.3.1.js"></script>
    <script src="./js/jquery.dataTables.min.js"></script>
    <script src="./js/ia.core.js"></script>
    <script src="./js/mantenedores/admbodegas.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--form id="doomreformat" name="doomreformat"></!--form-->
    <h1 class="display-2">Mantenedor Bodegas</h1>
    
    <button type="button" class="btn btn-primary btn-fw" title="Agregar Nueva Bodega" data-toggle="modal" data-target="#modalAgregar">Agregar</button>
    
    <!--table id="example" class="display" width="100%"></!--table-->
    <asp:Label ID="datos" runat="server" Text="-"></asp:Label>
    

    <!-- Inicio Modal Agregar -->
            <div class="modal fade" id="modalAgregar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title titulomodal" id="myModalLabel">Agregar Bodega</h4>
                        </div>
                        <div class="modal-body">
                            <div class="formulario">
                                <form id="formularioAgregar" name="formularioAgregar" method="post" runat="server">
                                    <asp:hiddenfield runat="server" id="idBodega"></asp:hiddenfield>
                                    <asp:hiddenfield runat="server" id="estadoBodega"></asp:hiddenfield>
                                    <asp:hiddenfield runat="server" id="accionAProcesar"></asp:hiddenfield>
                                    <div class="row">
                                        
                                        <div class="col-md-4 text-left">
                                            <span class="glyphicon glyphicon-asterisk red"></span>
                                            <label for="cmpnombre">Nombre Bodega</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpnombre" id="cmpnombre" placeholder="Nombre Bodega" maxlength="150" onkeypress="return soloLetrasVariado(event)" aria-required="True" required="required"/>
                                        </div>
                                            
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label for="cmpvalor">Codigo Interno</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpcodigo" id="cmpcodigo" placeholder="Codigo" maxlength="9" onkeypress="return soloNumeros(event)" aria-required="True" required="required"/>
                                        </div>
                                        
                                    </div>
                                    
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label for="cmpancho">Layout</label>
                                        </div>
                                        <div class="col-md-8">
                                            
                                            <select runat="server" class="form-control form-control-sm" name="cmplayaout" id="cmplayaout" required="required">
                                              <option value="1">SI</option>
                                              <option value="0">NO</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label for="cmpalto">Centro Costo</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpcentrocosto" id="cmpcentrocosto" placeholder="Centro costo" maxlength="10" onkeypress="return soloNumeroPuntoDecimal(event)" aria-required="True" required="required"/>
                                        </div>
                                        
                                    </div>
                                    <div class="row">
                                        
                                        <div class="col-md-4">
                                            <label for="cmpprof">Nivel</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpnivel" id="cmpnivel" placeholder="Nivel" maxlength="10" onkeypress="return soloNumeroPuntoDecimal(event)" required="required"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <span class="glyphicon glyphicon-asterisk red"></span>
                                            <label for="cmpmaximo">Orden</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmporden" id="cmporden" placeholder="Orden" maxlength="2" onkeypress="return soloNumeros(event)" />
                                        </div>
                                    </div>
                                    
                                    <div class="row">
                                    </div>
                                
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="Button1" runat="server" Text="Grabar C#" class="btn btn-primary btn-fw" OnClick="Button1_Click"/>

                            <!--button type="button" class="btn btn-primary" onclick="Grabar()">Grabar</!--button-->
                        </div>
                        </form>
                    </div>
                </div>
            </div>

            <!-- Final Modal -->

    
</asp:Content>
