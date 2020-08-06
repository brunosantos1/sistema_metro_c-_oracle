$(document).ready(function () {
    LoadDataTable("tbFiltroEntrega");
    LoadDataTable("tbGravar_Ocorrencia");
    LoadDataTable("tbGravar_Inspecao");
    LoadDataTable("tbGravar_Programacao");
});

function fnCarregaDataTable(objTable, objLinha, objPatio, objTrens, objMotivo, objInicial, objFinal)
{
    var idLinha = window.document.getElementById(objLinha).value;
    var idPatio = window.document.getElementById(objPatio).value;
    var idTrem = window.document.getElementById(objTrens).value;
    var idMotivo = window.document.getElementById(objMotivo).value;    
    var dtInicio = window.document.getElementById(objInicial).value;
    var dtFinal = window.document.getElementById(objFinal).value;
    //alert('Preparando para buscar Entrega de Trem');
    if (dtInicio == '' || dtFinal == '') {        
        alert('Necessario campos data');
    }
    else {        
        if (validaData(objInicial, dtInicio) && validaData(objFinal, dtFinal)) {
            var URL = '/PesquisarEntregaTrem/PesquisarEntrega?idLinha=' + idLinha + '&idPatio=' + idPatio + '&idTrem=' + idTrem + '&idMotivo=' + idMotivo + '&dtInicio=' + dtInicio + '&dtFinal=' + dtFinal;
            LoadDataTable(objTable, URL);
        }        
    }
};

function fnCarregaNotasVinculadas(objLink, idEntrega) {
    
    var URL_Ocorrencia  = '/PesquisarEntregaTrem/BuscarNotas?idEntrega=' + idEntrega + '&idTipo=01';
    var URL_Inspecao    = '/PesquisarEntregaTrem/BuscarNotas?idEntrega=' + idEntrega + '&idTipo=04';
    var URL_Programacao = '/PesquisarEntregaTrem/BuscarNotas?idEntrega=' + idEntrega + '&idTipo=25';
    
    LoadDataTable('tbGravar_Ocorrencia' , URL_Ocorrencia);
    LoadDataTable('tbGravar_Inspecao'   , URL_Inspecao);
    //LoadDataTable('tbGravar_Programacao', URL_Inspecao);
    
    window.document.getElementById('tbGravar_Ocorrencia').width = "100%";
    window.document.getElementById('tbGravar_Inspecao').width = "100%";
    window.document.getElementById('tbGravar_Programacao').width = "100%";
}

function fnCarregaHeaderEntrega(Prefixo,Entrega, Linha, Patio, Trem, DtEntrega, DtLiberacao, DtCancelamento, Status) {
    document.getElementById(Prefixo + "Entrega").innerHTML          = Entrega;
    document.getElementById(Prefixo + "Linha").innerHTML            = Linha;
    document.getElementById(Prefixo + "Patio").innerHTML            = Patio;
    document.getElementById(Prefixo + "Trem").innerHTML             = Trem;
    document.getElementById(Prefixo + "DtEntrega").innerHTML        = DtEntrega;
    document.getElementById(Prefixo + "DtLiberacao").innerHTML      = DtLiberacao;
    document.getElementById(Prefixo + "DtCancelamento").innerHTML   = DtCancelamento;
    document.getElementById(Prefixo + "Status").innerHTML           = Status;
};

function fnLiberarEntregaTrem(Entrega, MotivoEntrega) {
    var $modal = $(this);
    var idEntrega = document.getElementById(Entrega).innerText;
    var idMotivoEntrega = document.getElementById(MotivoEntrega).value;
    var objURL = '/EntregaTrens/LiberarEntregaTrem?idEntrega=' + idEntrega + '&idMotivoEntrega=' + idMotivoEntrega    
    $.ajax({
        cache: false,
        type: 'GET',
        url: objURL,
        success: function (data) {
            $modal.html(data);
            alert(data["data"]);
            fnFiltrar();
        },
        error: function (e) {
            alert(data["data"]);
        }
    });
}

function fnCancelaEntregaTrem(Entrega, MotivoCancelamento) {
    var $modal = $(this);
    var idEntrega = document.getElementById(Entrega).innerText;
    var dsMotivoEntrega = document.getElementById(MotivoCancelamento).value;
    var objURL = '/EntregaTrens/CancelaEntregaTrem?idEntrega=' + idEntrega + '&MotivoCancelamento=' + dsMotivoEntrega
    $.ajax({
        cache: false,
        type: 'GET',
        url: objURL,
        success: function (data) {
            $modal.html(data);
            alert(data["data"]);
            fnFiltrar();
        },
        error: function (e) {
            alert(data["data"]);
        }
    });
}

function fnMudarLocalEntregaTrem(Entrega, Linha, Patio) {
    var $modal  = $(this);
    var idEntrega = document.getElementById(Entrega).innerText;
    var idLinha = document.getElementById(Linha).value;
    var idPatio = document.getElementById(Patio).value;
    var objURL = '/EntregaTrens/MudarLocalEntregaTrem?idEntrega=' + idEntrega + '&idLinha=' + idLinha + '&idPatio=' + idPatio;
    $.ajax({
        cache: false,
        type: 'GET',
        url: objURL,
        success: function (data) {
            $modal.html(data);
            alert(data["data"]);
            fnFiltrar();
        },
        error: function (e) {
            alert(data["data"]);
        }
    });
}

function fnFiltrar() {
    fnLimparDataTable('tbFiltroEntrega');
    fnLimparDataTable('tbGravar_Ocorrencia');
    fnLimparDataTable('tbGravar_Inspecao');
    fnLimparDataTable('tbGravar_Programacao');
    fnCarregaDataTable('tbFiltroEntrega', 'linha', 'patio', 'trens', 'motivo', 'data_entrega_inicial', 'data_entrega_final');
}
function fnCancelar() {
    window.document.getElementById("linha").value = 0;
    fnLimparCombo('patio');
    fnLimparCombo('trens');
    fnLimparCombo('motivo');

    window.document.getElementById("data_entrega_inicial").value = "";
    window.document.getElementById("data_entrega_final").value = "";
    
    fnLimparDataTable('tbFiltroEntrega');
    fnLimparDataTable('tbGravar_Ocorrencia');
    fnLimparDataTable('tbGravar_Inspecao');
    fnLimparDataTable('tbGravar_Programacao');
}

$('#popup-cancelamento-entrega-trem').on('show.bs.modal', function (e) {
    var $modal = $(this);
    var RegistroId = $(e.relatedTarget).data('id'); //get data-id attribute of the clicked element

    //$.ajax({
    //    cache: false,
    //    type: 'GET',
    //    url: '/home/MostrarAlerta?ID=' + RegistroId,
    //    success: function (data) {
    //        //$modal.find('.edit-content').html(data);
    //        $modal.html(data);
    //    }
    //});
});

$('.popup_mudarlocalentregatrem').click(function (e) {
    alert('teste oficial - popup_mudarlocalentregatrem');
    $('#alerta-modal').on('show.bs.modal', function (e) {
        var $modal = $(this);
        var RegistroId = $(e.relatedTarget).data('id'); //get data-id attribute of the clicked element
        $.ajax({
            cache: false,
            type: 'GET',
            url: 'MaterialRodante/PesquisarTrens/MudarLocalEntregaTrem?idEntrega=' + RegistroId,
            success: function (data) {
                //$modal.find('.edit-content').html(data);
                $modal.html(data);
            }
        });
    });
});

$('.popup_desvinvularnotaentregatrem').click(function (e) {
    alert('teste oficial - popup_desvinvularnotaentregatrem');
    $('#alerta-modal').on('show.bs.modal', function (e) {
        var $modal = $(this);
        var RegistroId = $(e.relatedTarget).data('id'); //get data-id attribute of the clicked element
        $.ajax({
            cache: false,
            type: 'GET',
            url: '/PesquisarTrens/DesvinvularNotaEntregaTrem?idEntrega=' + RegistroId,
            success: function (data) {
                //$modal.find('.edit-content').html(data);
                $modal.html(data);
            }
        });
    });
});
