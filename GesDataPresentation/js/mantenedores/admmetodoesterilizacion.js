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

function CambiarEstado(identificador, estado) {
    //var idKit = $("input[id*='IdKit']").val();
    //var estadoKit = $("input[id*='EstadoKit']").val();
    $("input[id*='idMetodoEsterilizacion']").val(identificador);
    $("input[id*='estadoMetodoEsterilizacion']").val(estado);
    $("input[id*='accionAProcesar']").val("CambiarEstado");

    //console.log(identificador);
    //console.log(estado);
    //console.log($("input[id*='accionAProcesar']").val());

    document.getElementById("formularioAgregar").submit();
}

function Eliminar(identificador) {

    $("input[id*='idMetodoEsterilizacion']").val(identificador);
    $("input[id*='accionAProcesar']").val("EliminarMetodo");

    //console.log(identificador);
    //console.log($("input[id*='accionAProcesar']").val());

    document.getElementById("formularioAgregar").submit();
}
