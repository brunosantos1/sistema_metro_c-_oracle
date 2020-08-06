function fnCarregaDataTable(objTable, objLinha, objPatio, objTrem, objTipo_manutencao, objCentroTrabalho, objStatus, objSolicitante, objInicial, objFinal) {
    var idLinha             = window.document.getElementById(objLinha).value;
    var idPatio             = window.document.getElementById(objPatio).value;
    var idTrem              = window.document.getElementById(objTrem).value;
    var idTipoManutencao    = window.document.getElementById(objTipo_manutencao).value;
    var idCentroTrabalho    = window.document.getElementById(objCentroTrabalho).value;
    var idStatus            = window.document.getElementById(objStatus).value;
    var solicitante         = window.document.getElementById(objSolicitante).value;
    var dtInicio            = window.document.getElementById(objInicial).value;
    var dtFinal             = window.document.getElementById(objFinal).value;
    //alert('Preparando para buscar Entrega de Trem');
    if (dtInicio == '' || dtFinal == '') {
        alert('Necessario campos data');
    }
    else {
        
        if (validaData(objInicial, dtInicio) && validaData(objFinal, dtFinal)) {            
            var URL = '/PesquisarProgramacaoNotasMP/PesquisarEntrega?idLinha=' + idLinha + '&idPatio=' + idPatio + '&idTrem=' + idTrem + '&idTipoManutencao=' + idTipoManutencao + '&idCentroTrabalho=' + idCentroTrabalho + '&idStatus=' + idStatus + '&solicitante=' + solicitante + '&dtInicio=' + dtInicio + '&dtFinal=' + dtFinal;
            //LoadDataTable(objTable, URL);
            alert('Verificar com a Cris, de onde vem os dados da Pesquisar Programação de Trens - Notas MP ');
        }
    }
};

function fnCarregaNotasVinculadas(objLink, idEntrega) {

    alert('Criar Tabelas em nossa base para armazenar as notas do tipo MP do SAP');
    //var URL_Ocorrencia  = '/PesquisarEntregaTrem/BuscarNotas?idEntrega=' + idEntrega + '&idTipo=01';
    //var URL_Inspecao    = '/PesquisarEntregaTrem/BuscarNotas?idEntrega=' + idEntrega + '&idTipo=04';
    //var URL_Programacao = '/PesquisarEntregaTrem/BuscarNotas?idEntrega=' + idEntrega + '&idTipo=25';

    //LoadDataTable('tbGravar_Ocorrencia', URL_Ocorrencia);
    //LoadDataTable('tbGravar_Inspecao', URL_Inspecao);
    

    //window.document.getElementById('tbGravar_Ocorrencia').width = "100%";
    //window.document.getElementById('tbGravar_Inspecao').width = "100%";
    //window.document.getElementById('tbGravar_Programacao').width = "100%";
}

function fnCarregaHeaderEntrega(Prefixo, Entrega, Linha, Patio, Trem, DtEntrega, DtLiberacao, DtCancelamento, Status) {
    document.getElementById(Prefixo + "Entrega").innerHTML = Entrega;
    document.getElementById(Prefixo + "Linha").innerHTML = Linha;
    document.getElementById(Prefixo + "Patio").innerHTML = Patio;
    document.getElementById(Prefixo + "Trem").innerHTML = Trem;
    document.getElementById(Prefixo + "DtEntrega").innerHTML = DtEntrega;
    document.getElementById(Prefixo + "DtLiberacao").innerHTML = DtLiberacao;
    document.getElementById(Prefixo + "DtCancelamento").innerHTML = DtCancelamento;
    document.getElementById(Prefixo + "Status").innerHTML = Status;
};

function fnFiltrar() {
    fnLimparDataTable('tbFiltro');
    fnLimparDataTable('tbGravar_Ocorrencia');
    fnLimparDataTable('tbGravar_Inspecao');
    fnLimparDataTable('tbGravar_Programacao');
    fnCarregaDataTable('tbFiltro', 'idLinha', 'idPatio', 'idTrem', 'idTipo_manutencao', 'idCentroTrabalho', 'idStatus', 'Solicitante', 'data_inicial', 'data_final');
}
function fnCancelar() {
    window.document.getElementById("idLinha").value             = 0;
    window.document.getElementById("idTipo_manutencao").value   = 0;
    window.document.getElementById("idCentroTrabalho").value    = 0;
    window.document.getElementById("idTipo_manutencao").value   = 0;
    window.document.getElementById("data_inicial").value = "";
    window.document.getElementById("data_final").value = "";
    fnLimparCombo('idPatio');
    fnLimparCombo('idTrem');

    fnLimparDataTable('tbFiltro');
    fnLimparDataTable('tbGravar_Ocorrencia');
    fnLimparDataTable('tbGravar_Inspecao');
    fnLimparDataTable('tbGravar_Programacao');
}

