var tblDocumentosVinculados;
var tblOperacoesOrdem;
var nota_id;
var ordem_id;
var operacao_id;

var maodeobra_id;
var material_id;
var map_id;
var intervencao_id;

$(document).on('click', '.btn_details', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/DetalhesNota/' + id, '_blank');
})

$(document).on('click', '.btn_edit', function () {
    var id = $(this).data('id');
    //ToDo: Identificar o tipo da nota para definir qual tela chamar 
    window.open('/EquipamentoFixo/NotaEC/' + id, '_blank');tbm
})

$(document).on('click', '.btn_add', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/CriarNotaEA/' + id, '_blank');
})

$(document).on('click', '.btn_cancel', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/CancelarNota/' + id, 'CancelarNota', 'width=800, height=600');
})

$(document).on('click', '.btn_add_ordem', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/CriarOrdem/' + id, '_blank');
})

$(document).on('click', '.btn_add_documento', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/InserirDocumentoMedicao/' + id, '_blank');
})

$(document).on('click', 'btn_finalizar_nota', function () {
    var id = $(this).data('id');
    //ToDo: Identificar o tipo da nota para definir qual tela chamar (FinalizarNotaEP ou FinalizarNotaECED)
    window.open('/EquipamentoFixo/FinalizarNotaEP/' + id, '_blank');
})

$(document).on('click', 'btn_paralisar_nota', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/ParalisarNota/' + id, '_blank');
})

function loadDocumentosVinculados(notaId) {
    tblDocumentosVinculados = $('#tblDocumentosVinculados').DataTable({
        "ajax": '/EquipamentoFixo2/ApontarNotaOrdem/GetDocumentosVinculados/' + notaId,
        "columnDefs": [
            {
                "render": function (data, type, row) {
                    var buttons = '<a href="#" data-id="' + row[0] + '" class="btn_details"><i class="material-icons">search</i></a>' +
                        '<a href="#" data-id="' + row[0] + '" class="btn_add"><i class="material-icons">add</i></a>' +
                        '<a href="#" data-id="' + row[0] + '" class="btn_cancel"><i class="material-icons" style="color:#FF0000">close</i></a>';

                    return buttons
                },
                "targets": 3
            }
        ],
        "lengthChange": false,
        "bFilter": false,
        "bInfo": false,
        "language": {
            "paginate": {
                "previous": "Próxima",
                "next": "Anterior",
                "first": "Primeira",
                "last": "Última"
            }
        }
    });
}

function loadOperacoesOrdem(ordemId) {
    tblOperacoesOrdem = $('#tblOperacoesOrdem').DataTable({
        "ajax": '/EquipamentoFixo2/ApontarNotaOrdem/GetOperacoesOrdem/' + ordemId,
        "columnDefs": [
            {
                "render": function (data, type, row) {
                    var buttons = '<a href="#" data-id="' + row[0] + '" class="btn_details"><i class="material-icons">search</i></a>' +
                        '<a href="#" data-id="' + row[0] + '" class="btn_edit"><i class="material-icons">edit</i></a>' +
                        '<a href="#" data-id="' + row[0] + '" class="btn_add_ordem"><i class="material-icons">add</i></a>' +
                        '<a href="#" data-id="' + row[0] + '" class="btn_cancel"><i class="material-icons" style="color:#FF0000">close</i></a>';

                    return buttons
                },
                "targets": 10
            }
        ],
        "lengthChange": false,
        "bFilter": false,
        "bInfo": false,
        "language": {
            "paginate": {
                "previous": "Próxima",
                "next": "Anterior",
                "first": "Primeira",
                "last": "Última"
            }
        }
    });

    tblOperacoesOrdem.on('click', 'tr', function () {
        var data = tblOperacoesOrdem.row(this).data();
        operacao_id = data[1];

        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            tblOperacoesOrdem.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });
}

$(document).ready(function () {
    nota_id = $('#hdIdNota').val();
    ordem_id = $('#hdIdOrdem').val();

    loadDocumentosVinculados(nota_id);
    loadOperacoesOrdem(ordem_id);
});