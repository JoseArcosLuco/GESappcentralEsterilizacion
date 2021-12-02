<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="recepcionsalidapabellonrevision.aspx.cs" Inherits="ges.data.presentation.recepcionsalidapabellonrevision" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
        
    <script src="js/datatables/jquery-3.3.1.js"></script>
    <link href="./js/datatables/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <script src="./js/datatables/jquery.dataTables.min.js"></script>
    <script src="./js/datatables/dataTables.bootstrap4.min.js"></script>
    <link href="./js/datatables/bootstrap.css" rel="stylesheet" />

    
    <script src="./js/ia.core.js"></script>
    <script src="./js/recepcioncontenedores/recepcionsalidapabellonrevision.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="formularioAgregar" name="formularioAgregar" method="post" runat="server">
    <asp:HiddenField ID="idServicio" runat="server" />
    <asp:HiddenField ID="idServicioPabellon" runat="server" />
    <asp:HiddenField ID="idCodigoTrazable" runat="server" />
    <asp:HiddenField ID="nombreArticulo" runat="server" />
    <asp:HiddenField ID="idUsuario" runat="server" />
    <asp:HiddenField ID="acciones" runat="server" />
<div class="row">
    <div class="col-md-6 col-xs-12">
        <div class="row">
            <div class="col-md-12 text-left">
                <h1 class="display-6">Recepción Salida Pabellon / Revisión</h1>
            </div>
            
        </div>
        <div class="row">
            <div class="col-md-2">
                &nbsp;
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 text-left">
                <h1 class="display-5">Codigo: <asp:Label ID="lblCodigoTrazable" runat="server" Text=""></asp:Label> </h1>
            </div>
            <div class="col-md-6 text-left">
                <h1 class="display-5">Nombre: <asp:Label ID="lblnombreArticulo" runat="server" Text=""></asp:Label></h1>
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
                <asp:Label ID="comboservicios" runat="server" Text="Servicios"></asp:Label>
            </div>
            
            
        </div>
        <div class="row">
            <div class="col-md-5 text-left">
                <span class="glyphicon glyphicon-asterisk red"></span>
                <label for="cmpnombre">N° Pabellón</label>
            </div>
            <div class="col-md-7">
                <asp:Label ID="comboarea" runat="server" Text="" ></asp:Label>
            </div>
            
        </div>
        <div class="row">
            <div class="col-md-5 text-left">
                <span class="glyphicon glyphicon-asterisk red"></span>
                <label for="cmpnombre">Nombre Arsenalera:</label>
            </div>
            <div class="col-md-7">
                <input runat="server" type="text" class="form-control"  name="cmpnombrearsenalera" id="cmpnombrearsenalera" placeholder="Nombre Arsenalera" maxlength="150" onkeypress="return soloLetrasVariado(event)" aria-required="True" required="required"/>
            </div>
            
        </div>
        <div class="row">
            <div class="col-md-5 text-left">
                <span class="glyphicon glyphicon-asterisk red"></span>
                <label for="cmpnombre">Hora Término Cirugía</label>
            </div>
            <div class="col-md-7">
                <input runat="server" type="text" class="form-control"  name="cmphoraterminocirugia" id="cmphoraterminocirugia" placeholder="Hora Término Cirugía" maxlength="150" onkeypress="return soloLetrasVariado(event)"/>
            </div>
            
        </div>
        <div class="row">
            <div class="col-md-5 text-left">
                <span class="glyphicon glyphicon-asterisk red"></span>
                <label for="cmpnombre">Nombre Cirugía</label>
            </div>
            <div class="col-md-7">
                <input runat="server" type="text" class="form-control"  name="cmpnombrecirugia" id="cmpnombrecirugia" placeholder="Nombre Cirugía" maxlength="150" onkeypress="return soloLetrasVariado(event)"/>
            </div>
            
        </div>
        <div class="row">
            
            <!--div class="col-md-12">
                <div class="form-grup">
                     <div class="input-group">
                         <div class="input-group-prepend">
                            <div class="input-group-text gb-white">
                                <i class="mdi-clock-fast fa-key"></i>
                            </div>
                         </div>
                         <input type="email" name="testpruebas" class="form-control" placeholder="Test" />
                     </div>
                </div>
            </div-->
            
            <div class="col-md-5 text-left">
                <span class="glyphicon glyphicon-asterisk red"></span>
                <label for="cmpnombre">Nombre Paciente</label>
            </div>
            <div class="col-md-7">
                <input runat="server" type="text" class="form-control"  name="cmpnombrepaciente" id="cmpnombrepaciente" placeholder="Nombre Paciente" maxlength="150" onkeypress="return soloLetrasVariado(event)"/>
            </div>
            
        </div>
        <div class="row">
            <div class="col-md-5 text-left">
                <span class="glyphicon glyphicon-asterisk red"></span>
                <label for="cmpnombre">Observación Recepción</label>
            </div>
            <div class="col-md-7">
                <input runat="server" type="text" class="form-control"  name="cmpobs" id="cmpobs" placeholder="Observación Recepción" maxlength="150" onkeypress="return soloLetrasVariado(event)"/>
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
