$('.btn_details').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/DetalhesNota/' + id, '_blank');
})

$('.btn_cancel').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/RecusarTransferencia/' + id, '_blank');
})

$('.btn_accept').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/AceitarTransferencia/' + id, '_blank');
})