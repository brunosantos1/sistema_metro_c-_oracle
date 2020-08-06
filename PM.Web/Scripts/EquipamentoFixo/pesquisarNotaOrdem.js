$('#dateDe').datepicker({
    changeMonth: true,
    changeYear: true,
    format: 'dd/mm/yyyy',
    locale: 'pt-br',
    uiLibrary: 'bootstrap4',
});

$('#dateAte').datepicker({
    format: 'dd/mm/yyyy',
    locale: 'pt-br',
    uiLibrary: 'bootstrap4',
    startDate: '#dateDe'
});

$('.btn_edit').on('click', function () {
    var id = $(this).data('id');
    //ToDo: Identificar o tipo da nota para definir qual tela chamar (NotaEC, NotaED ou NotaEI)
    window.open('/EquipamentoFixo/NotaEC/' + id, '_blank');
})

$('.btn_cancel').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/CancelarNota/' + id, 'CancelarNota', 'width=800, height=600');
})

$('.btn_details').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/DetalhesNota/' + id, '_blank');
})

$('.btn_point').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/' + (viewbag_tipo == 'nota' ? 'ApontarNota' : 'ApontarOrdem') + '/' + id, '_blank');
})

$('.btn_transfer').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/TransferirNota/' + id, '_blank');
})