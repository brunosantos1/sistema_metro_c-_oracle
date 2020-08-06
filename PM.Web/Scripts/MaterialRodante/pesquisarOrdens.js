$('.btn_point').on('click', function () {
    var id = $(this).data('id');
    window.open('/MaterialRodante/ApontarOrdem/' + id, '_blank');
})