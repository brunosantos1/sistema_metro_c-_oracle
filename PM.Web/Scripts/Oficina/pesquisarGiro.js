$('#btn_imprimir').on('click', function () {
    var id = $(this).data('id');
    window.open('/Oficina/RelatorioGiro/' + id, 'PesquisarGiro', 'width=1300, height=600');
})