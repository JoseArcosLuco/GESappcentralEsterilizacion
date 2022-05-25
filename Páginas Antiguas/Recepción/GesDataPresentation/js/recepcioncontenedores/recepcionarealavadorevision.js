function CambioPabellon() {

    var codigoP = $("select[id*='cmpnumeropabellon']").val();
    $("input[id*='idServicioPabellon']").val(codigoP);
    console.log(codigoP);
}
function CambioServicio() {

    var codigoServicio = $("select[id*='cmpnombreservicio']").val();
    $("input[id*='idServicio']").val(codigoServicio);

}
function CambioServicio() {

    var codigoServicio = $("select[id*='cmpnombreservicio']").val();
    $("input[id*='idServicio']").val(codigoServicio);

}
function Volver() {

    document.getElementById("formularioAgregar").action = "recepcionarealavado.aspx";
    document.getElementById("formularioAgregar").submit();;
}