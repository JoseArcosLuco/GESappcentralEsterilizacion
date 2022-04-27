function CambioServicio() {
    var codigoP = $("select[id*='cmpidservicio']").val();
    $("input[id*='idServicio']").val(codigoP);
    $("input[id*='idPabellon']").val("");
    $("input[id*='accionAProcesar']").val("generarComboPabellones");

    document.getElementById("formularioAgregar").submit();
}

function CambioPabellon() {
    var codigoP = $("select[id*='cmpidpabellon']").val();
    $("input[id*='idPabellon']").val(codigoP);

    document.getElementById("formularioAgregar").submit();
}