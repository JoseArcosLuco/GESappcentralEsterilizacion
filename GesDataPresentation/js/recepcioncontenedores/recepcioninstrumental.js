function CambioRecepcion() {
    var codigoB = $("select[id*='cmpAreaRecepcion']").val();
    $("input[id*='idBodega']").val(codigoB);

    document.getElementById("formularioAgregar").submit();
}

function AsignarABodega(identificador, nombreArticulo) {

    $("input[id*='idCodigoTrazable']").val(identificador);
    $("input[id*='nombreArticulo']").val(nombreArticulo);

    document.getElementById("formularioAgregar").action = "recepcioninstrumentalrevision.aspx";
    document.getElementById("formularioAgregar").submit();
}