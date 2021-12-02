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
    
    $("input[id*='id']").val(identificador);
    $("input[id*='estadoMaquinaEsterilizacion']").val(estado);
    $("input[id*='accionAProcesar']").val("CambiarEstado");

    console.log(identificador);
    console.log(estado);
    console.log($("input[id*='accionAProcesar']").val());

    document.getElementById("formularioAgregar").submit();
}

function Eliminar(identificador) {

    $("input[id*='id']").val(identificador);
    $("input[id*='accionAProcesar']").val("EliminarMaquinaEsterilizacion");

    console.log(identificador);
    console.log($("input[id*='accionAProcesar']").val());

    document.getElementById("formularioAgregar").submit();
}

function AsignarMetodoEsterilizacion(identificador, nombre) {

    $("input[id*='idMaquinaEsterilizacion']").val(identificador);
    $("input[id*='nombreMaquina']").val(nombre);
    $("input[id*='accionAProcesar']").val("AsignarMetodo");

    //console.log(identificador);
    //console.log($("input[id*='accionAProcesar']").val());
    document.getElementById("formularioAgregar").action = "admmetodoesterilizacion.aspx";
    document.getElementById("formularioAgregar").submit();
}