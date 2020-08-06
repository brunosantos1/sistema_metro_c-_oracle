$(document).on("click", ".encerrarNota", function () {
    var resposta = confirm("Deseja encerrar a nota?");
    if (resposta) {
        alert("Nota encerrada com sucesso!");
    }
})

$(document).on("click", ".estornarNota", function () {
    var resposta = confirm("Deseja estornar a nota?");
    if (resposta) {
        alert("Nota estornada com sucesso!");
    }
})

$('#dateDe').datepicker({
    changeMonth: true,
    changeYear: true,
    format: 'dd/mm/yyyy',
    locale: 'pt-br',
    uiLibrary: 'bootstrap4',
});

$('#dateAte').datepicker({
    changeMonth: true,
    changeYear: true,
    format: 'dd/mm/yyyy',
    locale: 'pt-br',
    uiLibrary: 'bootstrap4',
});

$('.consultarDetalhes').on('click', function () {
    var id = $(this).data('id');
    window.location.href = '/CopesePericia/ConsultarNotaPericiaEF/' + id;
})