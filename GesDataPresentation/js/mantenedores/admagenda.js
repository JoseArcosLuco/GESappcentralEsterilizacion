function CambiarEstadoAgenda(identificador, estado) {
    $("input[id*='idAgenda']").val(identificador);
    $("input[id*='estadoAgenda']").val(estado);
    $("input[id*='accionAProcesar']").val("CambiarEstado");
    //$().button('toggle')
    document.getElementById("formularioBuscar").submit();
} 

setInterval(function () {
    $("input[id*='accionAProcesar']").val("Refresh");

    document.getElementById("formularioBuscar").submit();
}, 60000); // Intervalo de refresco de la página en miliseconds: 300000ms = 300s = 5 min, 60000ms = 60s = 1 min

function Buscar() {
    var codigoP = $("select[id*='cmpidpabellon']").val();
    $("input[id*='idPabellon']").val(codigoP);
    var codigoE = $("select[id*='cmpidestado']").val();
    $("input[id*='estadoAgenda']").val(codigoE);

   document.getElementById("formularioBuscar").submit();
}