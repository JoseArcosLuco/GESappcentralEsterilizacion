<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="admarticulo.aspx.cs" Inherits="ges.data.presentation.admArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./css/jquery.dataTables.min.css" rel="stylesheet" />
    
    <script src="./js/jquery-3.3.1.js"></script>
    <script src="./js/jquery.dataTables.min.js"></script>
    <script src="./js/ia.core.js"></script>
    <script src="./js/mantenedores/admarticulos.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-2">Mantenedor Articulos</h1>
    
    <button type="button" class="btn btn-primary btn-fw" title="Agregar Nuevo Articulo" data-toggle="modal" data-target="#modalAgregar">Agregar</button>
    <asp:Label ID="datos" runat="server" Text="-"></asp:Label>


    <!-- Inicio Modal Agregar -->
            <div class="modal fade" id="modalAgregar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title titulomodal" id="myModalLabel">Agregar Articulo</h4>
                        </div>
                        <div class="modal-body">
                            <div class="formulario">
                                <form id="formularioAgregar" name="formularioAgregar" method="post" runat="server">
                                    <asp:hiddenfield runat="server" id="idArticulo"></asp:hiddenfield>
                                    <asp:hiddenfield runat="server" id="estadoArticulo"></asp:hiddenfield>
                                    <asp:hiddenfield runat="server" id="accionAProcesar"></asp:hiddenfield>
                                    <div class="row">
                                        <div class="col-md-4">
                                            
                                            <label for="cmpnombre">Nombre Articulo</label>
                                        </div>
                                        <div class="col-md-4">
                                            <input runat="server" type="text" class="form-control" name="cmpnombre" id="cmpnombre" placeholder="Nombre Articulo" maxlength="150" onkeypress="return soloLetrasVariado(event)" aria-required="True" required="required"/>
                                        </div>
                                        
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            
                                            <label for="cmpnombre">Nombre Comercial</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpnombrecomercial" id="cmpnombrecomercial" placeholder="Nombre Comercial" maxlength="150" onkeypress="return soloLetrasVariado(event)" aria-required="True" required="required"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label for="cmpvalor">Codigo Articulo</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpcodigoarticulo" id="cmpcodigoarticulo" placeholder="Codigo Articulo" maxlength="9" onkeypress="return soloNumeros(event)" aria-required="True" required="required"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label for="cmpvalor">Codigo Barra (Opcional)</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpcodigobarra" id="cmpcodigobarra" placeholder="Codigo Barra" maxlength="45" onkeypress="return soloLetrasVariado(event)"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label for="cmpvalor">Codigo Externo (Opcional)</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpcodigoexterno" id="cmpcodigoexterno" placeholder="Codigo Externo" maxlength="45" onkeypress="return soloLetrasVariado(event)"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label for="cmpvalor">Ancho (Opcional)</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpancho" id="cmpancho" placeholder="Ancho" maxlength="15" onkeypress="return soloNumeros(event)"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label for="cmpvalor">Alto (Opcional)</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpalto" id="cmpalto" placeholder="Alto" maxlength="15" onkeypress="return soloNumeros(event)"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label for="cmpvalor">Profundidad (Opcional)</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpprofundidad" id="cmpprofundidad" placeholder="Profundidad" maxlength="15" onkeypress="return soloNumeros(event)"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label for="cmpvalor">Stock Minimo</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpstockminimo" id="cmpstockminimo" placeholder="Stock Minimo" maxlength="15" onkeypress="return soloNumeros(event)"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label for="cmpvalor">Stock Maximo</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpstockmaximo" id="cmpstockmaximo" placeholder="Stock Maximo" maxlength="15" onkeypress="return soloNumeros(event)"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label for="cmpvalor">Stock Critico</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpstockcritico" id="cmpstockcritico" placeholder="Stock Critico" maxlength="15" onkeypress="return soloNumeros(event)"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label for="cmpvalor">Costo (Opcional)</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpcosto" id="cmpcosto" placeholder="Costo" maxlength="15" onkeypress="return soloNumeros(event)"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label for="cmpvalor">Precio (Opcional)</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmpprecio" id="cmpprecio" placeholder="Precio" maxlength="15" onkeypress="return soloNumeros(event)"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label for="cmpvalor">Rotacion Veces</label>
                                        </div>
                                        <div class="col-md-8">
                                            <input runat="server" type="text" class="form-control" name="cmprotacion" id="cmprotacion" placeholder="Rotacion" maxlength="15" onkeypress="return soloNumeros(event)"/>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label for="cmpancho">Tiene Vencimiento</label>
                                        </div>
                                        <div class="col-md-8">
                                            
                                            <select runat="server" class="form-control form-control-sm" name="cmpvencimiento" id="cmpvencimiento" onkeypress="return soloNumeros(event)" required="required">
                                              <option value="1">SI</option>
                                              <option value="0">NO</option>
                                            </select>
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
