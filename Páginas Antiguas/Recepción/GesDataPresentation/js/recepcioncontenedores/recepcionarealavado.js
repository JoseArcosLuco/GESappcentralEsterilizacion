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

    $('#datosTable').dataTable({
        paging: false,
        searching: false,
        dom: 'Bfrtip',
        buttons: [
            'pdf',
            'excel',
            'print'
        ]

    });

});
function AsignarABodega(identificador, nombreArticulo) {

    $("input[id*='idCodigoTrazable']").val(identificador);
    $("input[id*='nombreArticulo']").val(nombreArticulo);

    document.getElementById("formularioAgregar").action = "recepcionarealavadorevision.aspx";
    document.getElementById("formularioAgregar").submit();
}