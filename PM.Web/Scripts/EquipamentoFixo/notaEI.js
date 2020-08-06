$('.btn_edit').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/NotaEI/' + id, '_blank');
})

$('.btn_cancel').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/CancelarNota/' + id, 'CancelarNotaEI', 'width=800, height=600');
})