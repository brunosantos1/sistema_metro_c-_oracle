$('.btn_edit').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/NotaED/' + id, '_blank');
})

$('.btn_cancel').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/CancelarNota/' + id, 'CancelarNotaED', 'width=800, height=600');
})