function CambioPabellon() {
    var codigoP = $("select[id*='cmpnumeropabellon']").val();
    $("input[id*='idServicioPabellon']").val(codigoP);
}

function CambioServicio() {
    var codigoS = $("select[id*='cmpidservicio']").val();
    $("input[id*='idServicio']").val(codigoS);
}

function Volver() {
    document.getElementById("formularioAgregar").action = "recepcioninstrumental.aspx";
    document.getElementById("formularioAgregar").submit();;
}