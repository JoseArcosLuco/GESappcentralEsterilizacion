<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="admkit.aspx.cs" Inherits="ges.data.presentation.admkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./css/jquery.dataTables.min.css" rel="stylesheet" />
    
    <script src="./js/jquery-3.3.1.js"></script>
    <script src="./js/jquery.dataTables.min.js"></script>
    <script src="./js/ia.core.js"></script>
    <script src="./js/mantenedores/admkit.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--form id="doomreformat" name="doomreformat"></!--form-->
    <h1 class="display-2">Mantenedor Kit</h1>
    
    <button type="button" class="btn btn-primary btn-fw" title="Agregar Nueva Bodega" data-toggle="modal" data-target="#modalAgregar">Agregar</button>
    
    <!--table id="example" class="display" width="100%"></!--table-->
    <asp:Label ID="datos" runat="server" Text="-"></asp:Label>
    

    <!-- Inicio Modal Agregar -->
            <div class="modal fade" id="modalAgregar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title titulomodal" id="myModalLabel">Agregar Kit</h4>
                        </div>
                        <div class="modal-body">
                            <div class="formulario">
                                <form id="formularioAgregar" name="formularioAgregar" method="post" runat="server">
                                    <asp:hiddenfield runat="server" id="idKit"></asp:hiddenfield>
                                    <asp:hiddenfield runat="server" id="nombreKit"></asp:hiddenfield>
                                    <asp:hiddenfield runat="server" id="estadoKit"></asp:hiddenfield>
                                    <asp:hiddenfield runat="server" id="accionAProcesar"></asp:hiddenfield>
                                    <div class="row">
                                        
                                        <div class="col-md-4 text-left">
                                            <span class="glyphicon glyphicon-asterisk red"></span>
                                            <label for="cmpnombre">Nombre Kit</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpnombre" id="cmpnombre" placeholder="Nombre Kit" maxlength="150" onkeypress="return soloLetrasVariado(event)" aria-required="True" required="required"/>
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
