$('.btn_edit').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/NotaEC/' + id, '_blank');
})

$('.btn_cancel').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/CancelarNota/' + id, 'CancelarNotaEC', 'width=800, height=600');
})

$('.btn_details').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/DetalhesNota/' + id, '_blank');
})

$('.btn_copese').on('click', function () {
    var id = $(this).data('id');
    window.open('/CopesePericia/ConsultarNotaCopeseEF/' + id, '_blank');
})

$('.btn_pericia').on('click', function () {
    var id = $(this).data('id');
    window.open('/CopesePericia/ConsultarNotaPericiaEF/' + id, '_blank');
})