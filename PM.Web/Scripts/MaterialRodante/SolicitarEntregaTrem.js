$(document).ready(function () {
    fnAtualiza();
});

function CarregaComboTrem(objLinha, objPatio, objTrem) {    
    var url = 'GetLinhaPatioTrem?idLinha=' + window.document.getElementById(objLinha).value + '&idPatio=';
    fnCarregaCombo(window.document.getElementById(objPatio), 'trens', url );
};

function fnCarregaDataTable(objLinha, objPatio, objTrem) {

    try {
        var idLinha = window.document.getElementById(objLinha).value;
        var idPatio = window.document.getElementById(objPatio).value;
        var idTrem = window.document.getElementById(objTrem).value;

        if (idLinha == 0 || idPatio == 0 || idTrem == 0) {
            alert("Necessário preencher todos os campos !!!");
        }
        else {
            var URL_Ocorrencia  = '/SolicitarEntregaTrem/PesquisarLinhaPatioTremNota?idLinha=' + idLinha + '&idPatio=' + idPatio + '&idTrem=' + idTrem + '&cd_sap=MC';
            var URL_Inspecao    = '/SolicitarEntregaTrem/PesquisarLinhaPatioTremNota?idLinha=' + idLinha + '&idPatio=' + idPatio + '&idTrem=' + idTrem + '&cd_sap=MI';
            var URL_Programacao = '/SolicitarEntregaTrem/PesquisarLinhaPatioTremNota?idLinha=' + idLinha + '&idPatio=' + idPatio + '&idTrem=' + idTrem + '&cd_sap=PR';

            LoadDataTable('tbOcorrencia', URL_Ocorrencia);
            LoadDataTable('tbInspecao', URL_Inspecao);
            //LoadDataTable('tbprogramacao' , URL_Programacao);
            window.document.getElementById('tbOcorrencia').width = "100%";
            window.document.getElementById('tbInspecao').width = "100%";
            //window.document.getElementById('tbprogramacao').width = "100%";
        }
    }
    catch{
        //alert('Xiiii Marquinhos - Deu Erro MESMO');
    }
};

function fnAtualizaDataTemp(objChk, idRegistro, cd_sap) {    
    var URL_Ocorrencia = '/EntregaTrens/AtualizaDadosGravacao?cd_sap=' + cd_sap + '&idRegistro=' + idRegistro;
    var NomeGrid = "";    
    if (cd_sap.toUpperCase() == "MC") { NomeGrid = 'tbGravar_Ocorrencia'; }
    if (cd_sap.toUpperCase() == "MI") { NomeGrid = 'tbGravar_Inspecao'; }

    LoadDataTable(NomeGrid, URL_Ocorrencia);
};

function fnGravaDadosEmBanco(objLinha, objPatio, objTrem) {
    var idLinha = window.document.getElementById(objLinha).value;
    var idPatio = window.document.getElementById(objPatio).value;
    var idTrem = window.document.getElementById(objTrem).value;
    var idEntrega = '';
    if (getParameterByName('idEntrega') != null) {
        idEntrega = '&idEntrega=' + getParameterByName('idEntrega');
    }
    var URL = '/EntregaTrens/GravaDadosEmBanco?idLinha=' + idLinha + '&idPatio=' + idPatio + '&idTrem=' + idTrem + idEntrega;
    

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
};

function fnCancelar() {
    window.document.getElementById("linha").value = 0;
    fnLimparCombo('patio');
    fnLimparCombo('trens');
    fnLimparDataTable('tbOcorrencia');
    fnLimparDataTable('tbInspecao');
    fnLimparDataTable('tbProgramacao');
    fnLimparDataTable('tbGravar_Ocorrencia');
    fnLimparDataTable('tbGravar_Inspecao');
    fnLimparDataTable('tbGravar_Programacao');
    //window.document.getElementById("tab-ocorrencia").focus();
}

function fnAtualiza() {
    LoadDataTable("tbOcorrencia");
    LoadDataTable("tbInspecao");
    LoadDataTable("tbProgramacao");
    LoadDataTable("tbGravar_Ocorrencia");
    LoadDataTable("tbGravar_Inspecao");
    LoadDataTable("tbGravar_Programacao");
}