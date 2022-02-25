<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="admkitarticulo.aspx.cs" Inherits="ges.data.presentation.admkitarticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="./js/jquery-3.3.1.js"></script>
    <script src="./js/jquery.dataTables.min.js"></script>
    <script src="./js/ia.core.js"></script>
    <script src="./js/mantenedores/admkitarticulo.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--form id="doomreformat" name="doomreformat"></!--form-->
    <h1 class="display-2">Mantenedor Kit Articulo</h1>
    
    <button type="button" class="btn btn-primary btn-fw" title="Agregar Nuevo" data-toggle="modal" data-target="#modalAgregar">Agregar</button>
    <button type="button" class="btn btn-primary btn-fw" title="Volver" onclick="javascript:DynamicForm('admkit.aspx');"><i class="mdi mdi-home-outline">Volver</i></button>
    
    <!--table id="example" class="display" width="100%"></!--table-->
    <h2 class="display-4">
        <asp:Label ID="lblIdKit" runat="server" Text=""></asp:Label>
    </h2>
    <h2 class="display-4">
        <asp:Label ID="lblNombreKit" runat="server" Text=""></asp:Label>
    </h2>
    <asp:Label ID="datos" runat="server" Text="-"></asp:Label>
    

    <!-- Inicio Modal Agregar -->
            <div class="modal fade" id="modalAgregar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title titulomodal" id="myModalLabel">Agregar Kit Articulo</h4>
                        </div>
                        <div class="modal-body">
                            <div class="formulario">
                                <form id="formularioAgregar" name="formularioAgregar" method="post" runat="server">
                                    <asp:hiddenfield runat="server" id="idKit"></asp:hiddenfield>
                                    <asp:hiddenfield runat="server" id="nombreKit"></asp:hiddenfield>
                                    <asp:hiddenfield runat="server" id="idKitArticulo"></asp:hiddenfield>
                                    <asp:hiddenfield runat="server" id="estadoKitArticulo"></asp:hiddenfield>
                                    <asp:hiddenfield runat="server" id="accionAProcesar"></asp:hiddenfield>
                                    <div class="row">
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4 text-left">
                                            <span class="glyphicon glyphicon-asterisk red"></span>
                                            <label for="cmpnombre">Id Articulo</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpidarticulo" id="cmpidarticulo" placeholder="Id Articulo" maxlength="9" onkeypress="return soloNumeros(event)" aria-required="True" required="required"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4 text-left">
                                            <span class="glyphicon glyphicon-asterisk red"></span>
                                            <label for="cmpnombre">Cantidad</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpcantidad" id="cmpcantidad" placeholder="Cantidad de Articulos" maxlength="9" onkeypress="return soloNumeros(event)" aria-required="True" required="required"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                    </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="Button1" runat="server" Text="Grabar" class="btn btn-primary btn-fw" OnClick="Button1_Click"/>
                        </div>
                        </form>
                    </div>
                </div>
            </div>

            <!-- Final Modal -->
</asp:Content>
