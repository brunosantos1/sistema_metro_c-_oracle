$('.btn_point').on('click', function () {
    var id = $(this).data('id');
    window.open('/MaterialRodante/ApontarNotasDocumentosVinculados/' + id, '_blank');
})
$('.btn_edit').on('click', function () {
    var id = $(this).data('id');
    window.open('/MaterialRodante/NotaMS/' + id, '_blank');
})
$('.btn_details').on('click', function () {
    var id = $(this).data('id');
    window.open('/MaterialRodante/ConsultarMS/' + id, '_blank');
})