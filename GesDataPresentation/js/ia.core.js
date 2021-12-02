var TIEMPO_REFRESCO = 2000;
var UrlIACORE = "http://localhost:50282/"
$(document).ready(function () {
    //if ($('.glyphicon-exclamation-sign').length) {
    //    $('.glyphicon-exclamation-sign').powerTip({ placement: 'w', smartPlacement: true });
    //}
    //try {
    //    if ($('.btn').length) {
    //        $('.btn').powerTip({ placement: 'w', smartPlacement: true });
    //    }
    //} catch (e) {
    //    console.log("no existe objeto Powertip");
    //}

    if ($(".tipofecha").length) {
        $('.tipofecha').datetimepicker({
            format: 'DD/MM/YYYY',
            locale: 'es',
        });
    }

    if ($('.tipohora').length) {
        $('.tipohora').datetimepicker({
            format: 'HH:mm'
        });
    }

    try {
        if ($('#datos').length) {
            $('#datos').DataTable({
                responsive: true,
                "order": [[ 0, "desc" ]],
                "language": { "url": UrlIACORE + "js/Spanish.js" },
                "iDisplayLength": 15,
                dom: 'Bfrtip',
                buttons: ['csv', 'excel', 'print']
            });
            $("#datos").prop("style", "width:100%");
        }
    } catch (e) {
        alert("HA ocurrido el siguiente Error DataTable : " + e.message);
    }

    $('#btnlogout').blur();
    $("#btncerrar").blur();
});
function mensajeria(capa, identificador, titulo, texto, tipo) {
    /// <summary>
    /// Permite mostrar un mensaje de alerta o informativo. 
    /// Ejemplo : mensajeria("#contenedor", "paggrab", "", "temporal", "ERROR");
    /// </summary>
    /// <param name="capa">Identificador de la capa Div donde se creara el mensaje</param>
    /// <param name="identificador">Identificador del Mensaje</param>
    /// <param name="titulo">Titulo </param>
    /// <param name="texto">Texto</param>
    /// <param name="tipo">valores a enviar: ERROR / INFOMACION / ALERTA </param>
    /// <returns></returns>
    if ($("#msgn_" + identificador).length) {
        $("#msgn_" + identificador).remove();
    }
    if (tipo == "ERROR") {
        clase = "alert alert-danger";
    }
    if (tipo == "INFORMACION" || tipo == "INFO") {
        clase = "alert alert-info";
    }
    if (tipo == "ALERTA") {
        clase = "alert alert-warning";
    }
    $(capa).prepend('<div id="msgn_' + identificador + '" class="' + clase + '" role="alert">' + titulo + '<br>' + texto + '</div>');
}

function limpiarAlertas(identificador, tiempo, nombremodal, actualizar) {
    /// <summary>
    /// Permite limpiar las alertas creadas por la funcion mensajeria() 
    /// </summary>
    /// <param name="identificador">Identificador de la capa Div donde se creo el mensaje</param>
    /// <param name="tiempo">Opcional. Tiempo de espera por defecto 2000 Milisegundos</param>
    /// <param name="nombremodal">Opcional. Cierre del ventana modal.</param>
    /// <param name="actualizar">Opcional. permite refrescar la pagina valores a enviar: true/ false</param>
    /// <returns></returns>
    if (tiempo == null) {
        tiempo = TIEMPO_REFRESCO
    }
    var swclosemodal = true
    if (nombremodal == null) {
        swclosemodal = false
    }
    var swactualizar = true
    if (actualizar == null) {
        var swactualizar = false
    }
    setTimeout(function () {
        if ($("#msgn_" + identificador).length) {
            $("#msgn_" + identificador).remove();
            if (swclosemodal) {
                $("#" + nombremodal).modal('hide');
            }
            if (swactualizar) {
                location.reload();
            }
        }
    },
    tiempo
    );
}

function ejecutaBtn(nameboton) {
    /// <summary>
    /// ejecuta el evento click de un btn
    /// </summary>
    /// <param name="nameboton">nombre identificador del boton</param>
    var obj = document.getElementById(nameboton);
    obj.click();
}

function soloNumeros(e) {
    /// <summary>
    /// filtra caracteres ingresados "1234567890"; Modo de utilizacion :  onkeypress="return soloNumeros(event)"
    /// </summary>
    /// <param name="e">The e.</param>
    cadena = "1234567890";
    return revisor(e, cadena);
}
function soloLetrasNumeros(e) {
    /// <summary>
    /// filtra caracteres ingresados " áéíóúabcdefghijklmnñopqrstuvwxyz1234567890" ; Modo de utilizacion :  onkeypress="return soloLetrasNumeros(event)"
    /// </summary>
    /// <param name="e">The e.</param>
    cadena = " áéíóúabcdefghijklmnñopqrstuvwxyz1234567890";
    return revisor(e, cadena);
}
function soloLetrasVariado(e) {
    /// <summary>
    /// filtra caracteres ingresados " %áéíóúabcdefghijklmnñopqrstuvwxyz1234567890._-()&/" ; Modo de utilizacion :  onkeypress="return soloLetrasVariado(event)"
    /// </summary>
    /// <param name="e">The e.</param>
    cadena = " %áéíóúabcdefghijklmnñopqrstuvwxyz1234567890._-()&/#,|";
    return revisor(e, cadena);
}
function soloLetras(e) {
    /// <summary>
    /// filtra caracteres ingresados " áéíóúabcdefghijklmnñopqrstuvwxyz" ; Modo de utilizacion :  onkeypress="return soloLetras(event)"
    /// </summary>
    /// <param name="e">The e.</param>
    cadena = " áéíóúabcdefghijklmnñopqrstuvwxyz";
    return revisor(e, cadena);
}
function soloLetrasArchivo(e) {
    /// <summary>
    /// filtra caracteres ingresados "  ñabcdefghijklmnopqrstuvwxyz1234567890._#&?=" ; Modo de utilizacion :  onkeypress="return soloLetrasArchivo(event)"
    /// </summary>
    /// <param name="e">The e.</param>
    cadena = " ñabcdefghijklmnopqrstuvwxyz1234567890._#&?=";
    return revisor(e, cadena);
}
function soloRut(e) {
    /// <summary>
    /// filtra caracteres ingresados "1234567890k-." ; Modo de utilizacion :  onkeypress="return soloRut(event)"
    /// </summary>
    /// <param name="e">The e.</param>
    cadena = "1234567890k-.";
    return revisor(e, cadena);
}
function soloEmail(e) {
    /// <summary>
    /// filtra caracteres ingresados " 1234567890.-_@abcdefghijklmnñopqrstuvwxyz" ; Modo de utilizacion :  onkeypress="return soloEmail(event)"
    /// </summary>
    /// <param name="e">The e.</param>
    cadena = " 1234567890.-_@abcdefghijklmnñopqrstuvwxyz";
    return revisor(e, cadena);
}
function soloFono(e) {
    /// <summary>
    /// filtra caracteres ingresados "+1234567890" ; Modo de utilizacion :  onkeypress="return soloFono(event)"
    /// </summary>
    /// <param name="e">The e.</param>
    cadena = "+1234567890";
    return revisor(e, cadena);
}
function soloFecha(e) {
    /// <summary>
    /// filtra caracteres ingresados "-/1234567890" ; Modo de utilizacion :  onkeypress="return soloFecha(event)"
    /// </summary>
    /// <param name="e">The e.</param>
    cadena = "-/1234567890";
    return revisor(e, cadena);
}
function soloWeb(e) {
    /// <summary>
    /// filtra caracteres ingresados ":w.-_abcdefghijklmnñopqrstuvwxyz/?&" ; Modo de utilizacion :  onkeypress="return soloWeb(event)"
    /// </summary>
    /// <param name="e">The e.</param>
    cadena = ":w.-_abcdefghijklmnñopqrstuvwxyz/?&";
    return revisor(e, cadena);
}
function soloNumeroPuntoDecimal(e) {
    /// <summary>
    /// filtra caracteres ingresados ".1234567890" ; Modo de utilizacion :  onkeypress="return soloNumeroPuntoDecimal(event)"
    /// </summary>
    /// <param name="e">The e.</param>
    cadena = ".1234567890";
    return revisor(e, cadena);
}
function soloNumeroComaDecimal(e) {
    /// <summary>
    /// filtra caracteres ingresados ",1234567890" ; Modo de utilizacion :  onkeypress="return soloNumeroComaDecimal(event)"
    /// </summary>
    /// <param name="e">The e.</param>
    cadena = ",1234567890";
    return revisor(e, cadena);
}
function soloHora(e) {
    /// <summary>
    /// filtra caracteres ingresados ":1234567890" ; Modo de utilizacion :  onkeypress="return soloHora(event)"
    /// </summary>
    /// <param name="e">The e.</param>
    cadena = ":1234567890";
    return revisor(e, cadena);
}
function notipea(e) {
    /// <summary>
    /// No deja ingresar caracteres a campo texto ; Modo de utilizacion :  onkeypress="return notipea(event)"
    /// </summary>
    /// <param name="e">The e.</param>
    cadena = "";
    return revisor(e, cadena);
}
function aplicaEnter(e, ejecutar) {
    /// <summary>
    /// ejecuta el evento click sobre evento enter; Modo de utilizacion donde el nombre id del elemento es btnbuscar : onkeydown="aplicaEnter(event,'btnbuscar')"
    /// </summary>
    /// <param name="e">The e.</param>
    key = e.keyCode || e.which;
    if (key == 13) {
        $("#" + ejecutar).click();
    }
}

function revisor(e, cadena) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    especiales = [8, 9, 189, 13];
    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (cadena.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}
function block() {

    //$.blockUI(
    //    { message: '<h1><img src="' + UrlIACORE + './images/loading.gif" border="0" /> <br>Espere un momento...</h1>' }
    //);
}
function unblock() {
    //$.unblockUI();
}
function refresh() {
    setTimeout(function () { location.reload(); }, TIEMPO_REFRESCO);
}
function DynamicForm(pagina, valor) {
    if (valor != null) {
        var htmlform = '<form action="' + pagina + '" method="POST" id="tmpform" name="tmpform">';
        htmlform += '<input type="hidden" name="identificador" id="identificador" value="' + valor + '">';
        htmlform += "</form>";
        $("#contenedor").append(htmlform);
        $("#tmpform").submit();
    } else {
        location.href = pagina;
    }
}

function SalirApp(pagina, valor) {
    if (valor != null) {
        var htmlform = '<form action="' + pagina + '" method="POST" id="tmpform" name="tmpform">';
        htmlform += '<input type="hidden" name="identificador" id="identificador" value="' + valor + '">';
        htmlform += "</form>";
        $("#contenedor").append(htmlform);
        $("#tmpform").submit();
    } else {
        location.href = pagina;
    }
}