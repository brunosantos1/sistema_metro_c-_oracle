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

$('#dateEntrada').datepicker({
    changeMonth: true,
    changeYear: true,
    format: 'dd/mm/yyyy',
    locale: 'pt-br',
    uiLibrary: 'bootstrap4',
});

$('#dateServico').datepicker({
    changeMonth: true,
    changeYear: true,
    format: 'dd/mm/yyyy',
    locale: 'pt-br',
    uiLibrary: 'bootstrap4',
});

$('.btn_point').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/ApontarNota/' + id, '_blank');
})

$('.btn_details').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/DetalhesNota/' + id, '_blank');
})

$('.btn_transfer').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/TransferirNota/' + id, '_blank');
})