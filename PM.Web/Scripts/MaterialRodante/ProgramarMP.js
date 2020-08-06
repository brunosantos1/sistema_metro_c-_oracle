$(document).ready(function () {
    LoadDataTable("tbNotas_01");
    LoadDataTable("tbGravar_Notas");
});

function fnPrepararTela() {
    fnMudaGrid();
    fnLimpaGrid();
    fnLimparCombo('idPatio');
    fnLimparCombo('idTrens');
    window.document.getElementById("idLinha").value = 0;
}

function fnMudaGrid() {
    LoadDataTable("tbNotas_01");
    LoadDataTable("tbGravar_Notas_01");
    LoadDataTable("tbNotas_02");
    LoadDataTable("tbGravar_Notas_02");
    var idTipoProgramacao = window.document.getElementById('idTipoProgramacao').value;
    // Ocultar tudo    
    document.getElementById("dvNotas_01").style.visibility          = "hidden";
    document.getElementById("dvGravar_Notas_01").style.visibility   = "hidden";
    document.getElementById("dvNotas_02").style.visibility          = "hidden";
    document.getElementById("dvGravar_Notas_02").style.visibility   = "hidden";

    document.getElementById("dvNotas_01").style.display             = "none";
    document.getElementById("dvGravar_Notas_01").style.display      = "none";
    document.getElementById("dvNotas_02").style.display             = "none";
    document.getElementById("dvGravar_Notas_02").style.display      = "none";

    //var oTable = $('#tbNotas_01').dataTable(); oTable.hide();
    //    oTable = $('#tbGravar_Notas_01').dataTable(); oTable.hide();

    //    oTable = $('#tbNotas_02').dataTable(); oTable.hide();
    //    oTable = $('#tbGravar_Notas_02').dataTable(); oTable.hide();


    if (idTipoProgramacao == "0" || idTipoProgramacao == "1" || idTipoProgramacao == 0 || idTipoProgramacao == 1) {
        
        document.getElementById("spTipoProgramacao").innerText = "MP-Preventiva Material Rodante";
        document.getElementById("dvNotas_01").style.visibility          = "visible";
        document.getElementById("dvNotas_01").style.display             = "block";
        document.getElementById("dvGravar_Notas_01").style.visibility   = "visible";
        document.getElementById("dvGravar_Notas_01").style.display      = "block";

        
        document.getElementById("dvNotas_02").style.visibility          = "hidden";
        document.getElementById("dvNotas_02").style.display             = "none";
        document.getElementById("dvGravar_Notas_02").style.visibility   = "hidden";
        document.getElementById("dvGravar_Notas_02").style.display      = "none";
        
    }
    if (idTipoProgramacao == "2" || idTipoProgramacao == 2) {
        document.getElementById("spTipoProgramacao").innerText = "MS-Serviços Material Rodante / MD	Defeito Detectado pela Manutenção";
        document.getElementById("dvNotas_02").style.visibility          = "visible";
        document.getElementById("dvNotas_02").style.display             = "block";
        document.getElementById("dvGravar_Notas_02").style.visibility   = "visible";
        document.getElementById("dvGravar_Notas_02").style.display      = "block";

        document.getElementById("dvNotas_01").style.visibility          = "hidden";
        document.getElementById("dvNotas_01").style.display             = "none";
        document.getElementById("dvGravar_Notas_01").style.visibility   = "hidden";
        document.getElementById("dvGravar_Notas_01").style.display      = "none";
    }

    console.log(document.getElementById("tbNotas_02").classList);
}

function fnLimpaGrid() {
    fnLimparDataTable('tbNotas_01'); 
    fnLimparDataTable('tbNotas_02'); 
    fnLimparDataTable('tbGravar_Notas');
}

function fnFiltrar() {
    var idTipoProgramacao = window.document.getElementById("idTipoProgramacao").value;
    if (idTipoProgramacao == 0) {
        alert('Necessario selecionar o Tipo da Programação');
        window.document.getElementById("idTipoProgramacao").focus();
    }
    
    else {
        var idTipoProgramacao   = window.document.getElementById('idTipoProgramacao').value;
        var idLinha             = window.document.getElementById('idLinha').value;    
        var idPatio             = window.document.getElementById('idPatio').value;
        var idTrens             = window.document.getElementById('idTrens').value;   
        var idCentroTrabalho    = window.document.getElementById('idCentroTrabalho').value;
        var idTipo_manutencao   = window.document.getElementById('idTipo_manutencao').value;
        var data_entrega        = window.document.getElementById('data_entrega').value;    
        var hora_entrega        = window.document.getElementById('hora_entrega').value;
        var observacao          = window.document.getElementById('observacao').value;

        var ftCentroDeTrabalho  = window.document.getElementById('ftCentroDeTrabalho').value;
        var ftTipoManutencao    = window.document.getElementById('ftTipoManutencao').value;
        var ftLocalInstalacao   = window.document.getElementById('ftLocalInstalacao').value;
        var ftDataDe            = window.document.getElementById('ftDataDe').value;
        var ftDataAte           = window.document.getElementById('ftDataAte').value;

        if (idLinha != 0 && idPatio != 0 && idTrens != 0) {

            //if (ftCentroDeTrabalho == 0 && ftTipoManutencao == '' && ftLocalInstalacao == 0) {
            //    alert('Necessario preencher ao menos um campo');
            //    window.document.getElementById('ftCentroDeTrabalho').focus();
            //}
            //else {
            if (idTipoProgramacao == 1) {
                var URL = '/ProgramarMP/BuscarNotas?idTipoProgramacao=' + idTipoProgramacao + '&idLinha=' + idLinha + '&idPatio=' + idPatio + '&idTrens=' + idTrens + '&ftCentroDeTrabalho=' + ftCentroDeTrabalho + '&ftTipoManutencao=' + ftTipoManutencao + '&ftLocalInstalacao=' + ftLocalInstalacao + '&ftDataDe=' + ftDataDe + '&ftDataAte=' + ftDataAte;
                LoadDataTable('tbNotas_01', URL);
            }
            else if (idTipoProgramacao == 2) {
                var URL = '/ProgramarMP/BuscarNotas?idTipoProgramacao=' + idTipoProgramacao + '&idLinha=' + idLinha + '&idPatio=' + idPatio + '&idTrens=' + idTrens + '&ftCentroDeTrabalho=' + ftCentroDeTrabalho + '&ftTipoManutencao=' + ftTipoManutencao + '&ftLocalInstalacao=' + ftLocalInstalacao + '&ftDataDe=' + ftDataDe + '&ftDataAte=' + ftDataAte;
                LoadDataTable('tbNotas_02', URL);
            }
            //}
        }
        else {
            var mensagem = "";
            if (idLinha == 0)
            {
                window.document.getElementById('idLinha').focus();
                mensagem = "Necessário selecionar uma Linha";
            }
            else {
                if (idPatio == 0) {
                    window.document.getElementById('idPatio').focus();
                    mensagem = "Necessário selecionar um Patio";
                }
                else {
                    window.document.getElementById('idTrens').focus();
                    mensagem = "Necessário selecionar um Trem";
                }
            }            
            alert(mensagem);
        }
    }
}

function fnCancelar() {    
    window.document.getElementById("idTipoProgramacao").value   = 0;
    window.document.getElementById("idLinha").value             = 0;    
    window.document.getElementById("idCentroTrabalho").value    = 0;    
    window.document.getElementById("data_entrega").value        = "";
    window.document.getElementById("hora_entrega").value        = "";
    window.document.getElementById("data_liberacao").value      = "";
    window.document.getElementById("hora_liberacao").value      = "";
    window.document.getElementById("inputSolicitante").value    = "";
    window.document.getElementById("inputResp").value           = "";
    window.document.getElementById("observacao").value          = "";
    window.document.getElementById("ftCentroDeTrabalho").value  = 0;
    window.document.getElementById("ftLocalInstalacao").value   = 0;
    window.document.getElementById("ftTipoManutencao").value    = "";
    fnLimparCombo('idPatio');
    fnLimparCombo('idTrens');
    fnMudaGrid();
    window.document.getElementById("idTipoProgramacao").focus();
}

function fnGravaDadosEmBanco() {
    
    var idTipoProgramacao   = window.document.getElementById('idTipoProgramacao').value;
    var idLinha             = window.document.getElementById('idLinha').value;    
    var idPatio             = window.document.getElementById('idPatio').value;
    var idTrens             = window.document.getElementById('idTrens').value;   
    var idCentroTrabalho    = window.document.getElementById('idCentroTrabalho').value;
    var idTipo_manutencao   = window.document.getElementById('idTipo_manutencao').value;
    var data_entrega        = window.document.getElementById('data_entrega').value;    
    var hora_entrega        = window.document.getElementById('hora_entrega').value;
    var data_liberacao      = window.document.getElementById('data_liberacao').value;    
    var hora_liberacao      = window.document.getElementById('hora_liberacao').value;
    var observacao          = window.document.getElementById('observacao').value;

    if (idTipoProgramacao == 0 || idLinha == 0 || idPatio == 0 || idTrens == 0 || idCentroTrabalho == 0 || data_entrega == '' || hora_entrega == '') {
        alert('Necessario preencher todos os campos');
        window.document.getElementById('idTipoProgramacao').focus();
    }
    else {
        if (data_liberacao != '' && hora_liberacao == '') {
            alert('Necessario preencher informar Hora da Liberacao');
            window.document.getElementById('hora_entrega').focus();
        }
        else {
            var URL = '/ProgramarMP/GravaDadosEmBanco?IdProgramacao=0&idTipoProgramacao=' + idTipoProgramacao + '&idLinha=' + idLinha + '&idPatio=' + idPatio + '&idTrens=' + idTrens + '&idCentroTrabalho=' + idCentroTrabalho + '&idTipo_manutencao=' + idTipo_manutencao + '&data_entrega=' + data_entrega + '&hora_entrega=' + hora_entrega + '&data_liberacao=' + data_liberacao + '&hora_liberacao=' + hora_liberacao + '&observacao=' + observacao;
            $.ajax({
                type: 'GET',
                headers: { 'Accept': 'application/json', 'Content-Type': 'text/plain' },
                dataType: 'json',
                url: URL,
                success: function (data) {
                    alert(data["data"]);
                    fnCancelar();
                },
                error: function (e) {
                    alert(data["data"]);
                }
            });
        }
    }
}

function fnCarregaTrem() {
    var idLinha = window.document.getElementById('idLinha').value;
    var idPatio = window.document.getElementById('idPatio').value;
    var idTrens = window.document.getElementById('idTrens').value;   

    fnCarregaCombo(window.document.getElementById('idPatio'), 'idTrens', 'GetLinhaPatioTrem?idLinha=' + idLinha + 'idPatio=');
}

function fnAtualizaDataTemp(objChk, idNota, cd_sap) {
    var idTipoProgramacao = window.document.getElementById("idTipoProgramacao").value;
    var URL_Ocorrencia = '/ProgramarMP/AtualizaDadosGravacao?idProgramacao=0&idTipoProgramacao=' + idTipoProgramacao + '&idNota=' + idNota + '&cd_sap=' + cd_sap;    
    var NomeGrid = "";

    if (idTipoProgramacao == 1) {
        NomeGrid = 'tbGravar_Notas_01';
    } else if (idTipoProgramacao == 2) {
        NomeGrid = 'tbGravar_Notas_02';
    }
    LoadDataTable(NomeGrid, URL_Ocorrencia);
}

function mdate() {
    var from = $("#data_entrega").val().split("/");
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
    var str_data = dia + '/' + (mes + 1) + '/' + ano4;
    var str_hora = hora + ':' + min + ':' + seg;

    window.document.getElementById("data_liberacao").value = "";
    window.document.getElementById("hora_liberacao").value = "";

    return str_data + ' ' + str_hora;
}



function chamaFuncaoAuxiliar(campo) {
    //if (campo == 'ftTipoManutencao') {
    //    DadosEquipamento();
    //}
    //else if (campo == 'cd_sap_elementoPEP') {
    //    BuscarElementoPEP();
    //}
    //else if (campo == 'cd_sap_material') {
    //    BuscarMaterial();
    //}
    //else if (campo == 'ct_trabalho') {
    //    BuscarCentroTrabalho();
    //}
}


$(document).ready(function () {
    LoadDataTable("tbNotas_01");
    LoadDataTable("tbGravar_Notas_01");

    $('[data-toggle="tooltip"]').tooltip();

    $('#data_entrega').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        locale: 'pt-br',
        uiLibrary: 'bootstrap4',
        minDate: function () { return fnDataAtual(); /*$('.FormatDateAte').val();*/ }
    });
    $('#hora_entrega').timepicker({
        changeMonth: true,
        changeYear: true,
        format: 'HH:MM:ss',
        locale: 'pt-br',
        uiLibrary: 'bootstrap4',
    });

    $('#data_liberacao').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        locale: 'pt-br',
        uiLibrary: 'bootstrap4',
        minDate: function () { return mdate(); /*return $('#data_entrega').val();*/ }
    });
    $('#hora_liberacao').timepicker({
        changeMonth: true,
        changeYear: true,
        format: 'HH:MM:ss',
        locale: 'pt-br',
        uiLibrary: 'bootstrap4',
    });
});