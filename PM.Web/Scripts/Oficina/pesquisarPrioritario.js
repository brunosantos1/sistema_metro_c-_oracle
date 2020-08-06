$('#btn_imprimir').on('click', function () {
    var id = $(this).data('id');
    window.open('/Oficina/RelatorioPrioritario/' + id, 'PesquisarPrioritario', 'width=1300, height=600');
})