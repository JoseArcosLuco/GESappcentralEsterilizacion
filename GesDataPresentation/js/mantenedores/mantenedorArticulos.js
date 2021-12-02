var IDARTICULO = 0;
$(document).ready(function () {
    /*inicializa el objeto radio button slide*/
    if ($("#modalAgregar").length) {
        $('#modalAgregar').on('shown.bs.modal', function (e) {
            //$(":checkbox").iButton("destroy");
            //$(":checkbox").iButton();
        });
    }
    if ($('#modalEditar').length) {
        $('#modalEditar').on('shown.bs.modal', function (e) {
            $(":checkbox").iButton("destroy");
            $(":checkbox").iButton();
        })
    }
});


function Grabar() {
    try {
        $('#formularioAgregar').validate({
            onkeyup: false,
            errorClass: 'cerror',
            rules: {
                cmpnombre: { required: true },
                cmbTipoArticulo: { required: true },
                cmbClasificacion: { required: true },
                cmpmaximo: { required: true },
                cmpminimo: { required: true },
                cmpcritico: { required: true }
            },
            messages: {
                cmpnombre: "Ingrese el nombre",
                cmbTipoArticulo: "Seleccione el tipo de articulo u opcion No aplica",
                cmbClasificacion: "Seleccione la clasificacion u opcion No aplica",
                cmpmaximo: "Ingrese niveles de stock",
                cmpminimo: "Ingrese niveles de stock",
                cmpcritico: "Ingrese niveles de stock"
            }
        });
        if ($("#cmpMandante").val() != "1") {
            $("#cmpcodint").rules("add", { required: true, messages: { required: "Ingrese el codigo" } });
        }
        if ($('#formularioAgregar').valid()) {
            var mandante = $("#cmpMandante").val();
            var cmpcodbar = $.trim($("#cmpcodbar").val());
            var cmpcodint = $.trim($("#cmpcodint").val());
            var cmpcodext = $.trim($("#cmpcodext").val());
            var cmpnombre = $.trim($("#cmpnombre").val());
            var cmpnombrecom = $.trim($("#cmpnombrecom").val());
            var cmbTipoArticulo = $.trim($("#cmbTipoArticulo").val());
            var cmbClasificacion = $.trim($("#cmbClasificacion").val());
            var chkvencimiento = $("#chkvencimiento").prop("checked") ? true : false;
            var cmprotacion = $.trim($("#cmprotacion").val());
            var cmpcosto = $.trim($("#cmpcosto").val());
            var cmpprecio = $.trim($("#cmpprecio").val());
            var cmpancho = $.trim($("#cmpancho").val());
            var cmpalto = $.trim($("#cmpalto").val());
            var cmpprof = $.trim($("#cmpprof").val());
            var cmpmaximo = $.trim($("#cmpmaximo").val());
            var cmpminimo = $.trim($("#cmpminimo").val());
            var cmpcritico = $.trim($("#cmpcritico").val());

            var datos = [
                { variable: 'sysmandante', valor: mandante },
                { variable: 'codbar', valor: cmpcodbar },
                { variable: 'codint', valor: cmpcodint },
                { variable: 'codext', valor: cmpcodext },
                { variable: 'nombre', valor: cmpnombre },
                { variable: 'nombrecom', valor: cmpnombrecom },
                { variable: 'tipoarticulo', valor: cmbTipoArticulo },
                { variable: 'clasificacion', valor: cmbClasificacion },
                { variable: 'vencimiento', valor: chkvencimiento },
                { variable: 'rotacion', valor: cmprotacion },
                { variable: 'costo', valor: cmpcosto },
                { variable: 'precio', valor: cmpprecio },
                { variable: 'ancho', valor: cmpancho },
                { variable: 'alto', valor: cmpalto },
                { variable: 'prof', valor: cmpprof },
                { variable: 'maximo', valor: cmpmaximo },
                { variable: 'minimo', valor: cmpminimo },
                { variable: 'critico', valor: cmpcritico }
            ];

            block();
            $.ajax({
                type: "POST",
                url: "mantenedorArticulos.aspx/Grabar",
                contentType: "application/json; charset=utf-8",
                data: "{'datos':" + JSON.stringify(datos) + "}",
                dataType: "json",
                success: function (data) {
                    unblock();
                    $('#modalAgregar').modal('hide');
                    jsdata = data.d;
                    if (jsdata.length > 1) {
                        rsp_articulo = jsdata[0];
                        rsp_asignacion = jsdata[1];
                        if (rsp_asignacion.estado == 1) {
                            mensajeria("#mensaje", "pagrel2", "RELACION DE ARTICULOS EXITOSA", INFO_RELACION_REGISTRO, "INFORMACION");
                        } else if (rsp_asignacion == 0) {
                            mensajeria("#mensaje", "pagrel2", "ATENCION RELACION DE ARTICULOS ", rsp_asignacion.descripcion, "ALERTA");
                        } else if (rsp_asignacion > 0) {
                            mensajeria("#mensaje", "pagrel2", ERROR_GRABAR_REGISTRO, rsp_asignacion.descripcion, "ERROR");
                        }

                        if (rsp_articulo.estado == 1) {
                            mensajeria("#mensaje", "paggrab", "GRABACION EXITOSA", INFO_GRABAR_REGISTRO, "INFORMACION");
                        }
                        else {
                            mensajeria("#mensaje", "paggrab", ERROR_GRABAR_REGISTRO, rsp_articulo.descripcion, "ERROR");
                        }
                        refresh();
                    } else if (jsdata.length == 1) {
                        rsp_articulo = jsdata[0];
                        mensajeria("#mensaje", "paggrab", ERROR_GRABAR_REGISTRO, rsp_articulo.descripcion, "ERROR");
                        refresh();
                    }
                },
                error: function () {
                    unblock();
                    $('#modalAgregar').modal('hide');
                    mensajeria("#mensaje", "paggrab", "", ERROR_SYSTEM, "ERROR");
                    limpiarAlertas('paggrab');
                }
            });
        }
    } catch (e) {
        unblock();
        alert("Ha ocurrido el siguiente Error : " + e.message);
    }

}

function Eliminar(identificador) {
    try {
        bootbox.confirm("¿Desea Eliminar el Registro?, \nRecuerde que se eliminarán todos los stock relacionados a este articulo.", function (result) {
            if (result) {
                block();
                $.ajax({
                    type: "POST",
                    url: "mantenedorArticulos.aspx/Eliminar",
                    contentType: "application/json; charset=utf-8",
                    data: "{'identificador':'" + identificador + "'}",
                    dataType: "json",
                    success: function (data) {
                        unblock();
                        jsdata = data.d;
                        if (jsdata.estado == 1) {
                            $("#fila" + identificador).remove();
                            mensajeria("#mensaje", "paggrab", "", INFO_ELIMINAR_REGISTRO, "INFORMACION");
                            limpiarAlertas('paggrab');
                        } else {
                            mensajeria("#mensaje", "paggrab", "", jsdata.descripcion, "ERROR");
                            limpiarAlertas('paggrab');
                        }
                    },
                    error: function () {
                        unblock();
                        mensajeria("#mensaje", "paggrab", "", ERROR_SYSTEM, "ERROR");
                        limpiarAlertas('paggrab');
                    }
                });
            }
        });
    } catch (e) {
        unblock();
        alert("Ha ocurrido el siguiente Error : " + e.message);
    }

}

function Estado(identificador) {
    try {
        estadoactual = $("#valestado_" + identificador).attr("rel");
        block();
        $.ajax({
            type: "POST",
            url: "mArticulo.aspx/CambiarEstado",
            contentType: "application/json; charset=utf-8",
            data: "{'identificador':'" + identificador + "','estadoactual':'" + estadoactual + "'}",
            dataType: "json",
            success: function (data) {
                unblock();
                jsdata = data.d;
                if (jsdata.estado == 1) {
                    if (estadoactual == "0") {
                        $("#btnEstado_" + identificador + " span").removeClass("glyphicon-remove").addClass("glyphicon-ok");
                        $("#valestado_" + identificador).html("Activo");
                        $("#valestado_" + identificador).attr("rel", "1");
                    } else {
                        $("#btnEstado_" + identificador + " span").removeClass("glyphicon-ok").addClass("glyphicon-remove");
                        $("#valestado_" + identificador).html("Inactivo");
                        $("#valestado_" + identificador).attr("rel", "0");
                    }
                } else {
                    mensajeria("#mensaje", "paggrab", "", jsdata.descripcion, "ERROR");
                    limpiarAlertas('paggrab');
                }
            },
            error: function () {
                unblock();
                mensajeria("#mensaje", "paggrab", "", ERROR_SYSTEM, "ERROR");
                limpiarAlertas('paggrab');
            }
        });
    } catch (e) {
        unblock();
        alert("Ha ocurrido el siguiente Error : " + e.message);
    }

}

function Editar(identificador) {
    try {
        $("#modalEditar").modal('show');
        $("#identificador").val("");
        $("#cmpedcodbar").val("");
        $("#cmpedcodint").val("");
        $("#cmpedcodext").val("");
        $("#cmpednombre").val("");
        $("#cmpednombrecom").val("");
        $('#cmbedTipoArticulo option[value=""]').prop('selected', true);
        $('#cmbedClasificacion option[value=""]').prop('selected', true);
        $("#chkedvencimiento").attr("checked", false);
        $("#cmpedrotacion").val("");
        $("#cmpedcosto").val("");
        $("#cmpedprecio").val("");
        $("#cmpedancho").val("");
        $("#cmpedalto").val("");
        $("#cmpedprof").val("");
        $("#cmpedmaximo").val("");
        $("#cmpedminimo").val("");
        $("#cmpedcritico").val("");
        block();
        $.ajax({
            type: "POST",
            url: "mArticulo.aspx/ObtenerDatos",
            contentType: "application/json; charset=utf-8",
            data: "{'identificador':'" + identificador + "'}",
            dataType: "json",
            success: function (data) {
                unblock();
                jsdata = data.d;
                if (jsdata.nombreArticulo == null && jsdata.respuesta.estado == 0) {
                    mensajeria("#mensaje", "paggrab", "", jsdata.respuesta.descripcion, "ERROR");
                    limpiarAlertas('paggrab');
                } else {
                    $("#modalEditar").modal('show');
                    $("#identificador").val(identificador);
                    $("#cmpedcodbar").val(jsdata.codigoBarra);
                    if ($("#cmpMandante").val() == "1") {
                        $("#cmpedcodint").attr("disabled", "disabled");
                    }
                    $("#cmpedcodint").val(jsdata.codigoArticulo);
                    $("#cmpedcodext").val(jsdata.codigoExterno);
                    $("#cmpednombre").val(jsdata.nombreArticulo);
                    $("#cmpednombrecom").val(jsdata.nombreComercial);
                    $('#cmbedTipoArticulo option[value="' + jsdata.idTipoArticulo + '"]').prop('selected', true);
                    $('#cmbedClasificacion option[value="' + jsdata.idClasificacion + '"]').prop('selected', true);
                    if (jsdata.vencimiento) { $("#chkedvencimiento").attr("checked", true); }
                    $("#cmpedrotacion").val(jsdata.defaultRotacionMantencion);
                    $("#cmpedcosto").val(jsdata.defaultCosto);
                    $("#cmpedprecio").val(jsdata.defaultPrecio);
                    $("#cmpedancho").val(jsdata.ancho);
                    $("#cmpedalto").val(jsdata.alto);
                    $("#cmpedprof").val(jsdata.profundidad);
                    $("#cmpedmaximo").val(jsdata.defaultStockMaximo);
                    $("#cmpedminimo").val(jsdata.defaultStockMinimo);
                    $("#cmpedcritico").val(jsdata.defaultStockCritico);
                }
            },
            error: function () {
                unblock();
                mensajeria("#mensaje", "paggrab", "", ERROR_SYSTEM, "ERROR");
                limpiarAlertas('paggrab');
            }
        });
    } catch (e) {
        unblock();
        alert("Ha ocurrido el siguiente Error : " + e.message);
    }

}

function Modificar() {
    try {
        $('#formularioEditar').validate({
            onkeyup: false,
            errorClass: 'cerror',
            rules: {
                cmpednombre: { required: true },
                cmbedTipoArticulo: { required: true },
                cmbedClasificacion: { required: true },
                cmpedmaximo: { required: true },
                cmpedminimo: { required: true },
                cmpedcritico: { required: true }
            },
            messages: {
                cmpednombre: "Ingrese el nombre",
                cmbedTipoArticulo: "Seleccione el tipo de articulo u opcion No aplica",
                cmbedClasificacion: "Seleccione la clasificacion u opcion No aplica",
                cmpedmaximo: "Ingrese niveles de stock",
                cmpedminimo: "Ingrese niveles de stock",
                cmpedcritico: "Ingrese niveles de stock"
            }
        });
        if ($("#cmpMandante").val() != "1") {
            $("#cmpedcodint").rules("add", { required: true, messages: { required: "Ingrese el codigo" } });
        }
        if ($('#formularioEditar').valid()) {
            block();
            var mandante = $("#cmpMandante").val();
            var identificador = $("#identificador").val();
            var cmpcodbar = $.trim($("#cmpedcodbar").val());
            var cmpcodint = $.trim($("#cmpedcodint").val());
            var cmpcodext = $.trim($("#cmpedcodext").val());
            var cmpnombre = $.trim($("#cmpednombre").val());
            var cmpnombrecom = $.trim($("#cmpednombrecom").val());
            var cmbTipoArticulo = $.trim($("#cmbedTipoArticulo").val());
            var cmbClasificacion = $.trim($("#cmbedClasificacion").val());
            var chkvencimiento = $("#chkedvencimiento").prop("checked") ? true : false;
            var cmprotacion = $.trim($("#cmpedrotacion").val());
            var cmpcosto = $.trim($("#cmpedcosto").val());
            var cmpprecio = $.trim($("#cmpedprecio").val());
            var cmpancho = $.trim($("#cmpedancho").val());
            var cmpalto = $.trim($("#cmpedalto").val());
            var cmpprof = $.trim($("#cmpedprof").val());
            var cmpmaximo = $.trim($("#cmpedmaximo").val());
            var cmpminimo = $.trim($("#cmpedminimo").val());
            var cmpcritico = $.trim($("#cmpedcritico").val());
            var estado = $('input[name=cmpedactivo]:checked').val();

            var datos = [
                { variable: 'sysmandante', valor: mandante },
                { variable: 'identificador', valor: identificador },
                { variable: 'codbar', valor: cmpcodbar },
                { variable: 'codint', valor: cmpcodint },
                { variable: 'codext', valor: cmpcodext },
                { variable: 'nombre', valor: cmpnombre },
                { variable: 'nombrecom', valor: cmpnombrecom },
                { variable: 'tipoarticulo', valor: cmbTipoArticulo },
                { variable: 'clasificacion', valor: cmbClasificacion },
                { variable: 'vencimiento', valor: chkvencimiento },
                { variable: 'rotacion', valor: cmprotacion },
                { variable: 'costo', valor: cmpcosto },
                { variable: 'precio', valor: cmpprecio },
                { variable: 'ancho', valor: cmpancho },
                { variable: 'alto', valor: cmpalto },
                { variable: 'prof', valor: cmpprof },
                { variable: 'maximo', valor: cmpmaximo },
                { variable: 'minimo', valor: cmpminimo },
                { variable: 'critico', valor: cmpcritico },
                { variable: 'estado', valor: estado }
            ];

            $.ajax({
                type: "POST",
                url: "mArticulo.aspx/Modificar",
                contentType: "application/json; charset=utf-8",
                data: "{'datos':" + JSON.stringify(datos) + "}",
                dataType: "json",
                success: function (data) {
                    unblock();
                    jsdata = data.d;
                    if (jsdata.estado == 1) {
                        $('#modalEditar').modal('hide');
                        mensajeria("#mensaje", "paggrab", "", INFO_GRABAR_REGISTRO, "INFO");
                        refresh();
                    } else {
                        $('#modalEditar').modal('hide');
                        mensajeria("#mensaje", "paggrab", "", jsdata.descripcion, "ERROR");
                        limpiarAlertas('paggrab');
                    }
                },
                error: function () {
                    unblock();
                    $('#modalEditar').modal('hide');
                    mensajeria("#mensaje", "paggrab", "", ERROR_SYSTEM, "ERROR");
                    limpiarAlertas('paggrab');
                }
            });
        }
    } catch (e) {
        unblock();
        alert("Ha ocurrido el siguiente Error : " + e.message);
    }

}