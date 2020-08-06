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

$('.btn_details').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/DetalhesNota/' + id, '_blank');
})

$('.btn_point').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/ApontarOrdem/' + id, '_blank');
})