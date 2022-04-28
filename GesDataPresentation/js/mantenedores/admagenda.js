function CambiarEstadoAgenda(identificador, estado) {
    $("input[id*='idAgenda']").val(identificador);
    $("input[id*='estadoAgenda']").val(estado);
    $("input[id*='accionAProcesar']").val("CambiarEstado");
    //$().button('toggle')
    document.getElementById("formularioAgregar").submit();
}