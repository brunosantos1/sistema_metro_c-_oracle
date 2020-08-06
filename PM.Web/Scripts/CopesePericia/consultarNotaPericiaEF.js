$('.voltar').on('click', function () {
    var id = $(this).data('id');
    window.location.href = '/CopesePericia/PesquisarNotaPericiaEF/' + id;
})