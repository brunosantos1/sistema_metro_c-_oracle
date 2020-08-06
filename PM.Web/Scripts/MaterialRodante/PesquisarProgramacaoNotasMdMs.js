function fnCarregaDataTable(objTable, objTrem, objPatio, objLinha, objTipo_manutencao, objCentroTrabalho, objSolicitante, objInicial, objFinal) {
    var idTrem = window.document.getElementById(objTrem).value;
    var idPatio = window.document.getElementById(objPatio).value;
    var idLinha = window.document.getElementById(objLinha).value;
    var idTipoManutencao = window.document.getElementById(objTipo_manutencao).value;
    var idCentroTrabalho = window.document.getElementById(objCentroTrabalho).value;
    var Solicitante = window.document.getElementById(objSolicitante).value;
    var dtInicio    = window.document.getElementById(objInicial).value;
    var dtFinal     = window.document.getElementById(objFinal).value;
    
    //if (idTrem == 0 || idPatio == 0 || idLinha == 0 || idTipoManutencao == 0 || idCentroTrabalho == 0 || dtInicio == '' || dtFinal == '') {
    //    alert('Necessario preencher todos os campos');
    //}
    //else {
    var URL_Filtro  = '/SolicitarEntregaTrem/PesquisarLinhaPatioTremNota?idLinha=' + idLinha + '&idPatio=' + idPatio + '&idTrem=' + idTrem + '&cd_sap=MD';
    var URL_MD      = '/SolicitarEntregaTrem/PesquisarLinhaPatioTremNota?idLinha=' + idLinha + '&idPatio=' + idPatio + '&idTrem=' + idTrem + '&cd_sap=MD';
    var URL_MS      = '/SolicitarEntregaTrem/PesquisarLinhaPatioTremNota?idLinha=' + idLinha + '&idPatio=' + idPatio + '&idTrem=' + idTrem + '&cd_sap=MS';

    LoadDataTable('tbFiltro'                    , URL_Filtro);
    LoadDataTable('tbMS_DefeitoDetectado'       , URL_MD);
    LoadDataTable('tbMD_ServicosMaterialRodante', URL_MS);

    window.document.getElementById(objTable).width = "100%";
    window.document.getElementById('tbMS_DefeitoDetectado').width = "100%";
    window.document.getElementById('tbMD_ServicosMaterialRodante').width = "100%";
    //}
};

function fnFiltrar() {
    fnLimparDataTable('tbFiltro');
    fnLimparDataTable('tbMS_DefeitoDetectado');
    fnLimparDataTable('tbMD_ServicosMaterialRodante');
    fnCarregaDataTable('tbFiltro', 'idTrem', 'idPatio', 'idLinha', 'idTipo_manutencao', 'idCentroTrabalho', 'inputSolicitante', 'data_inicial', 'data_final');
}
function fnCancelar() {
    window.document.getElementById("idTrem").value = 0;
    fnLimparCombo('idPatio');
    fnLimparCombo('idLinha');
    fnLimparCombo('idTipo_manutencao');
    fnLimparCombo('idCentroTrabalho');
    
    window.document.getElementById("data_inicial").value = "";
    window.document.getElementById("data_final").value = "";
    window.document.getElementById("inputSolicitante").value = "";

    fnLimparDataTable('tbFiltro');
    fnLimparDataTable('tbMS_DefeitoDetectado');
    fnLimparDataTable('tbMD_ServicosMaterialRodante');
}

function fnGravaDadosEmBanco() {
    var idTrem              = window.document.getElementById(objTrem).value;
    var idPatio             = window.document.getElementById(objPatio).value;
    var idLinha             = window.document.getElementById(objLinha).value;
    var idTipoManutencao    = window.document.getElementById(objTipo_manutencao).value;
    var idCentroTrabalho    = window.document.getElementById(objCentroTrabalho).value;
    var Solicitante         = window.document.getElementById(objSolicitante).value;
    var dtInicio            = window.document.getElementById(objInicial).value;
    var dtFinal             = window.document.getElementById(objFinal).value;

    var URL = '/ProgramarMP/GravaDadosEmBanco?idTrem=' + idTrem + '&idPatio=' + idPatio + '&idLinha=' + idLinha + '&idTipoManutencao=' + idTipoManutencao + '&idCentroTrabalho=' + idCentroTrabalho + '&Solicitante=' + Solicitante + '&dtInicio=' + dtInicio + '&dtFinal=' + dtFinal;
    alert(URL);
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