
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

    $('#lblTrazabilidad').DataTable({
        "pagingType": "simple"
    });
    $('.lblTrazabilidad_length').addClass('bs-select');

    var codigo = $("select[id*='cmpnombreservicio']").val();
    $("input[id*='idServicio']").val(codigo);
});

function AsignarServicio() {
    var codigo = $("select[id*='cmpnombreservicio']").val();
    $("input[id*='idServicio']").val(codigo);
    console.log(codigo);
}
function CambioServicio() {
    AsignarServicio();
    document.getElementById("formularioAgregar").action = "recepcionsalidapabellonrevision.aspx";
    $("input[id*='acciones']").val("buscararea");
    document.getElementById("formularioAgregar").submit();
}
function CambioPabellon() {
    
    var codigoP = $("select[id*='cmpnumeropabellon']").val();
    $("input[id*='idServicioPabellon']").val(codigoP);
    console.log(codigoP);
}
function Volver() {

    document.getElementById("formularioAgregar").action = "recepcionsalidapabellon.aspx";
    document.getElementById("formularioAgregar").submit();;
}