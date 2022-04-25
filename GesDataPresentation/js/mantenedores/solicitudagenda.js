function CambioServicio() {
    var codigoP = $("select[id*='cmpidservicio']").val();
    $("input[id*='idServicio']").val(codigoP);

    document.getElementById("formularioAgregar").submit();
}