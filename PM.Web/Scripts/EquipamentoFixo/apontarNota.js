$('.btn_details').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/DetalhesNota/' + id, '_blank');
})

$('.btn_edit').on('click', function () {
    var id = $(this).data('id');
    //ToDo: Identificar o tipo da nota para definir qual tela chamar 
    window.open('/EquipamentoFixo/NotaEC/' + id, '_blank');
})

$('.btn_add').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/CriarNotaEA/' + id, '_blank');
})

$('.btn_cancel').on('click', function () {
    var id = $(this).data('id');
    window.open('/EquipamentoFixo/CancelarNota/' + id, 'CancelarNota', 'width=800, height=600');
})