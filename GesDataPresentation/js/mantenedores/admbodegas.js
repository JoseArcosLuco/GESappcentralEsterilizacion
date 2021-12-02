var dataSet = [
    ["Tiger Nixon", "System Architect", "Edinburgh", "5421", "2011/04/25", "$320,800"],
    ["Garrett Winters", "Accountant", "Tokyo", "8422", "2011/07/25", "$170,750"],
    ["Ashton Cox", "Junior Technical Author", "San Francisco", "1562", "2009/01/12", "$86,000"],
    ["Unity Butler", "Marketing Designer", "San Francisco", "5384", "2009/12/09", "$85,675"]
];

$(document).ready(function () {

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


    $('#example').DataTable({
        data: dataSet,
        columns: [
            { title: "Name" },
            { title: "Position" },
            { title: "Office" },
            { title: "Extn." },
            { title: "Start date" },
            { title: "Salary" }
        ]
    });
});

function Grabar() {
    try {
        $('#formularioAgregar').validate({
            onkeyup: false,
            errorClass: 'cerror',
            rules: {
                cmpnombre: { required: true },
                cmpcodigo: { required: true },
                cmplayaout: { required: true },
                cmpcentrocosto: { required: true },
                cmpnivel: { required: true },
                cmporden: { required: true }
            },
            messages: {
                cmpnombre: "Ingrese el Nombre",
                cmpcodigo: "Ingrese Codigo",
                cmplayaout: "Ingrese Layaout",
                cmpcentrocosto: "Ingrese Centro Costo",
                cmpnivel: "Ingrese Nivel",
                cmporden: "Ingrese Orden"
            }
        });
        console.log('paso aqui');
        if ($('#formularioAgregar').valid()) {

            var cmpnombre = $("#cmpnombre").val();
            var cmpcodigo = $.trim($("#cmpcodigo").val());
            var cmplayaout = $.trim($("#cmplayaout").val());
            var cmpcentrocosto = $.trim($("#cmpcentrocosto").val());
            var cmpnivel = $.trim($("#cmpnivel").val());
            var cmporden = $.trim($("#cmporden").val());
            

            var datos = [
                { variable: 'cmpnombre', valor: cmpnombre },
                { variable: 'cmpcodigo', valor: cmpcodigo },
                { variable: 'cmplayaout', valor: cmplayaout },
                { variable: 'cmpcentrocosto', valor: cmpcentrocosto },
                { variable: 'cmpnivel', valor: cmpnivel },
                { variable: 'cmporden', valor: cmporden }
            ];
            console.log('paso aqui 2');
            //block();
            
            $.ajax({
                type: "POST",
                url: "admbodegas.aspx/Grabar",
                contentType: "application/json; charset=utf-8",
                data: "{'datos':" + JSON.stringify(datos) + "}",
                dataType: "json",
                success: function (data) {
                    //unblock();
                    $('#modalAgregar').modal('hide');
                    jsdata = data.d;
                    if (jsdata.length > 1) {
                        rsp_articulo = jsdata[0];
                        rsp_asignacion = jsdata[1];
                        
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
                    //unblock();
                    $('#modalAgregar').modal('hide');
                    mensajeria("#mensaje", "paggrab", "", ERROR_SYSTEM, "ERROR");
                    limpiarAlertas('paggrab');
                }
            });
        }
    } catch (e) {
        //unblock();
        alert("Ha ocurrido el siguiente Error : " + e.message);
    }

}

function CambiarEstadoBodegas(identificador, estado){
    //var idBodega = $("input[id*='IdBodega']").val();
    //var estadoBodega = $("input[id*='EstadoBodega']").val();
    $("input[id*='idBodega']").val(identificador);
    $("input[id*='estadoBodega']").val(estado);
    $("input[id*='accionAProcesar']").val("CambiarEstado");

    console.log(identificador);
    console.log(estado);
    console.log($("input[id*='accionAProcesar']").val());
    
    document.getElementById("formularioAgregar").submit();
}

function EliminarBodegas(identificador) {
    
    $("input[id*='idBodega']").val(identificador);
    $("input[id*='accionAProcesar']").val("EliminarBodega");

    console.log(identificador);
    console.log($("input[id*='accionAProcesar']").val());

    document.getElementById("formularioAgregar").submit();
}