<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="recepcionarealavadorevision.aspx.cs" Inherits="ges.data.presentation.recepcionarealavadorevision" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/datatables/jquery-3.3.1.js"></script>
    <link href="js/datatables/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <script src="js/datatables/jquery.dataTables.min.js"></script>
    <script src="js/datatables/dataTables.bootstrap4.min.js"></script>
    <script src="./js/ia.core.js"></script>
    <script src="./js/recepcioncontenedores/recepcionarealavadorevision.js"></script>
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
                <h1 class="display-6">Área Lavado / Revisión</h1>
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
                <label for="cmpnombre">Material a Lavar</label>
            </div>
            <div class="col-md-7">
                <asp:Label ID="comboarea" runat="server" Text="" ></asp:Label>
                <input runat="server" type="text" class="form-control"  name="cmpmaterialalavar" id="cmpmaterialalavar" placeholder="Material a Lavar" maxlength="50" onkeypress="return soloLetrasVariado(event)" />
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
                <label for="cmpnombre">Retiro de materia organica con chorro de agua</label>
            </div>
            <div class="col-md-7">
                <input runat="server" type="text" class="form-control"  name="cmpchorroagua" id="cmpchorroagua" placeholder="Retiro Materia" maxlength="50" onkeypress="return soloLetrasVariado(event)"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-5 text-left">
                <span class="glyphicon glyphicon-asterisk red"></span>
                <label for="cmpnombre">Desarme de piezas ensambladas</label>
            </div>
            <div class="col-md-7">
                <input runat="server" type="text" class="form-control"  name="cmpdesarmepiezas" id="cmpdesarmepiezas" placeholder="Desarme de piezas ensambladas" maxlength="50" onkeypress="return soloLetrasVariado(event)"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-5 text-left">
                <span class="glyphicon glyphicon-asterisk red"></span>
                <label for="cmpnombre">Metodo Lavado</label>
            </div>
            <div class="col-md-7">
                <input runat="server" type="text" class="form-control"  name="cmpmetodolavado" id="cmpmetodolavado" placeholder="Metodo Lavado" maxlength="50" onkeypress="return soloLetrasVariado(event)"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-5 text-left">
                <span class="glyphicon glyphicon-asterisk red"></span>
                <label for="cmpnombre">Carga con 25 piezas minimo</label>
            </div>
            <div class="col-md-7">
                <input runat="server" type="text" class="form-control"  name="cmpcargadepiezas" id="cmpcargadepiezas" placeholder="Carga de piezas" maxlength="50" onkeypress="return soloLetrasVariado(event)"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-5 text-left">
                <span class="glyphicon glyphicon-asterisk red"></span>
                <label for="cmpnombre">Numero Carga</label>
            </div>
            <div class="col-md-7">
                <input runat="server" type="text" class="form-control"  name="cmpnumerocarga" id="cmpnumerocarga" placeholder="Numero Carga" maxlength="9" onkeypress="return soloNumeros(event)"/>
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
