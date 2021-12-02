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

function CambiarEstadoKitArticulo(identificador, estado) {
    //var idKit = $("input[id*='IdKit']").val();
    //var estadoKit = $("input[id*='EstadoKit']").val();
    $("input[id*='idKitArticulo']").val(identificador);
    $("input[id*='estadoKitArticulo']").val(estado);
    $("input[id*='accionAProcesar']").val("CambiarEstado");

    console.log(identificador);
    console.log(estado);
    console.log($("input[id*='accionAProcesar']").val());

    document.getElementById("formularioAgregar").submit();
}

function EliminarKitArticulo(identificador) {

    $("input[id*='idKitArticulo']").val(identificador);
    $("input[id*='accionAProcesar']").val("EliminarKitArticulo");

    console.log(identificador);
    console.log($("input[id*='accionAProcesar']").val());

    document.getElementById("formularioAgregar").submit();
}