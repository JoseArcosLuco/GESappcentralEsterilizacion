function AsignarABodega(identificador, nombreArticulo) {

    $("input[id*='idCodigoTrazable']").val(identificador);
    $("input[id*='nombreArticulo']").val(nombreArticulo);

    document.getElementById("formularioAgregar").action = "recepcionpreparacionempaquerevision.aspx";
    document.getElementById("formularioAgregar").submit();
}