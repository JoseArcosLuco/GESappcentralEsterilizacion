function CambiarEstadoArticulo(identificador, estado) {
    //var idBodega = $("input[id*='IdBodega']").val();
    //var estadoBodega = $("input[id*='EstadoBodega']").val();
    $("input[id*='idArticulo']").val(identificador);
    $("input[id*='estadoArticulo']").val(estado);
    $("input[id*='accionAProcesar']").val("CambiarEstado");

    console.log(identificador);
    console.log(estado);
    console.log($("input[id*='accionAProcesar']").val());

    document.getElementById("formularioAgregar").submit();
}

function EliminarArticulo(identificador) {

    $("input[id*='idArticulo']").val(identificador);
    $("input[id*='accionAProcesar']").val("EliminarArticulo");

    console.log(identificador);
    console.log($("input[id*='accionAProcesar']").val());

    document.getElementById("formularioAgregar").submit();
}