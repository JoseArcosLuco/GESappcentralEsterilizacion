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

});

function CambiarEstadoPabellon(identificador, estado) {
    $("input[id*='idPabellon']").val(identificador);
    $("input[id*='estadoPabellon']").val(estado);
    $("input[id*='accionAProcesar']").val("CambiarEstado");
    //console.log(identificador);
    //console.log(estado);
    //console.log($("input[id*='accionAProcesar']").val());
    document.getElementById("formularioAgregar").submit();
}

function EliminarPabellon(identificador) {

    $("input[id*='idPabellon']").val(identificador);
    $("input[id*='accionAProcesar']").val("EliminarPabellon");

    console.log(identificador);
    console.log($("input[id*='accionAProcesar']").val());

    document.getElementById("formularioAgregar").submit();
}

function CambioServicio() {
    var codigoP = $("select[id*='cmpidservicio']").val();
    $("input[id*='idServicio']").val(codigoP);

    document.getElementById("formularioAgregar").submit();
}

function CambioServicioAgregar() {
    var codigoP = $("select[id*='cmpidservicio']").val();
    $("input[id*='idServicio']").val(codigoP);
}