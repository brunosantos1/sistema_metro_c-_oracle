function fnPrepararTela() {
    fnMudaGrid();
    fnLimpaGrid();
    fnLimparCombo('idPatio');
    fnLimparCombo('idTrens');
    window.document.getElementById("idLinha").value = 0;
    window.document.getElementById("idMotivo").value = 0;
    window.document.getElementById("data_entrega_inicio").value = "";
    window.document.getElementById("data_entrega_final").value = "";
}

function fnLimpaGrid() {
    fnLimparDataTable('tbFiltro');
}

function fnFiltrar() {
    var idLinha = window.document.getElementById("idLinha").value;
    var idPatio = window.document.getElementById("idPatio").value;
    var idTrens = window.document.getElementById("idTrens").value;
    var idMotivo = window.document.getElementById("idMotivo").value;
    var data_entrega_inicio = window.document.getElementById("data_entrega_inicio").value;
    var data_entrega_final = window.document.getElementById("data_entrega_final").value;


    
    if (/*idLinha != 0 && idPatio != 0 && idTrens != 0 && idTrens != 0 && idMotivo != 0 && */ data_entrega_inicio != '' && data_entrega_final != '') {
        var URL = '/ProgramarMP/BuscarProgramacao?idLinha=' + idLinha + '&idPatio=' + idPatio + '&idTrens=' + idTrens + '&idMotivo=' + idMotivo + '&data_entrega_inicio=' + data_entrega_inicio + '&data_entrega_final=' + data_entrega_final;
        alert('url: ' + URL);
        LoadDataTable('tbFiltro', URL);

    }
    else {
        var mensagem = "";
        //if (idLinha == 0) {
        //    window.document.getElementById('idLinha').focus();
        //    mensagem = "Necessário selecionar uma Linha";
        //}
        //else if (idPatio == 0) {
        //    window.document.getElementById('idPatio').focus();
        //    mensagem = "Necessário selecionar uma Patio";
        //}
        //else if (idTrens == 0) {
        //        window.document.getElementById('idTrens').focus();
        //        mensagem = "Necessário selecionar um Trem";
        //}
        //else if (idMotivo == 0) {
        //    window.document.getElementById('idMotivo').focus();
        //    mensagem = "Necessário selecionar um Motivo";
        //}
        //else
        if (data_entrega_inicio == '') {
                window.document.getElementById('data_entrega_inicio').focus();
                mensagem = "Necessário informar data do periodo de Entrega Inicial";
            }
        else if (data_entrega_final == '') {
                window.document.getElementById('data_entrega_final').focus();
                mensagem = "Necessário informar data do periodo de Entrega Final";
        }        
        alert(mensagem);
    }
}

function fnCancelar() {    
    window.document.getElementById("idLinha").value             = 0;
    window.document.getElementById("idPatio").value             = 0;
    window.document.getElementById("idTrens").value             = 0;
    window.document.getElementById("idMotivo").value            = 0;    
    window.document.getElementById("data_entrega_inicio").value = "";
    window.document.getElementById("data_entrega_final").value  = "";
    window.document.getElementById("idLinha").focus();
}



$(document).ready(function () {
    LoadDataTable('tbFiltro');
    $('[data-toggle="tooltip"]').tooltip();

    $('#data_entrega_inicial').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        locale: 'pt-br',
        uiLibrary: 'bootstrap4',
        minDate: function () { return fnDataAtual(); /*$('.FormatDateAte').val();*/ }
    });
    $('#data_entrega_final').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        locale: 'pt-br',
        uiLibrary: 'bootstrap4',
        minDate: function () { return mdate(); /*return $('#data_entrega').val();*/ }
    });
});

function mdate() {
    var from = $("#data_entrega_inicio").val().split("/");
    var data = new Date();
    var novadata = new Date(from[2], from[1], from[0]);

    var dia = novadata.getDate();           // 1-31
    var mes = novadata.getMonth();          // 0-11 (zero=janeiro)
    var ano4 = novadata.getFullYear();       // 4 dígitos
    var hora = data.getHours();          // 0-23
    var min = data.getMinutes();        // 0-59
    var seg = data.getSeconds();        // 0-59
    if (mes < 10) {
        mes = "0" + mes
    }

    var str_data = (dia + 1) + '/' + mes + '/' + ano4;
    return str_data;
}

function fnDataAtual() {
    // Obtém a data/hora atual
    var data = new Date();

    // Guarda cada pedaço em uma variável
    var dia = data.getDate();           // 1-31
    var dia_sem = data.getDay();            // 0-6 (zero=domingo)
    var mes = data.getMonth();          // 0-11 (zero=janeiro)
    var ano2 = data.getYear();           // 2 dígitos
    var ano4 = data.getFullYear();       // 4 dígitos
    var hora = data.getHours();          // 0-23
    var min = data.getMinutes();        // 0-59
    var seg = data.getSeconds();        // 0-59
    var mseg = data.getMilliseconds();   // 0-999
    var tz = data.getTimezoneOffset(); // em minutos

    // Formata a data e a hora (note o mês + 1)
    var str_data = dia + '/' + (mes+ 0 ) + '/' + ano4;
    var str_hora = hora + ':' + min + ':' + seg;

    window.document.getElementById("data_entrega_final").value = "";

    return str_data + ' ' + str_hora;
}


$(document).ready(function () {

    $('#data_entrega_inicio').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        locale: 'pt-br',
        uiLibrary: 'bootstrap4',
        minDate: function () { return fnDataAtual(); /*$('.FormatDateAte').val();*/ }
    });

    $('#data_entrega_final').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        locale: 'pt-br',
        uiLibrary: 'bootstrap4',
        minDate: function () { return mdate(); /*return $('#data_entrega').val();*/ }
    });
});