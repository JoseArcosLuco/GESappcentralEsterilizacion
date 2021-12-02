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

function CambiarEstadoKit(identificador, estado) {
    //var idKit = $("input[id*='IdKit']").val();
    //var estadoKit = $("input[id*='EstadoKit']").val();
    $("input[id*='idKit']").val(identificador);
    $("input[id*='estadoKit']").val(estado);
    $("input[id*='accionAProcesar']").val("CambiarEstado");

    console.log(identificador);
    console.log(estado);
    console.log($("input[id*='accionAProcesar']").val());

    document.getElementById("formularioAgregar").submit();
}

function EliminarKit(identificador) {

    $("input[id*='idKit']").val(identificador);
    $("input[id*='accionAProcesar']").val("EliminarKit");

    console.log(identificador);
    console.log($("input[id*='accionAProcesar']").val());

    document.getElementById("formularioAgregar").submit();
}
function AsignarKit(identificador,nombreKit) {

    $("input[id*='idKit']").val(identificador);
    $("input[id*='nombreKit']").val(nombreKit);
    $("input[id*='accionAProcesar']").val("AsignarKit");

    //console.log(identificador);
    //console.log($("input[id*='accionAProcesar']").val());
    document.getElementById("formularioAgregar").action = "admkitarticulo.aspx";
    document.getElementById("formularioAgregar").submit();
}