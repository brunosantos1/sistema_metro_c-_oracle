$(document).ready(function () {
    if ($('#dateDe').val() == "01/01/0001 00:00:00")
        $('#dateDe').val(null);
    if ($('#dateAte').val() == "01/01/0001 00:00:00")
        $('#dateAte').val(null);
});

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

$('.consultarDetalhes').on('click', function () {
    var id = $(this).data('id');
    window.location.href = '/CopesePericia/ConsultarNotaCopeseEF/' + id;
})

$('#dateDe').datepicker({
    showOn: "button",
    showButtonPanel: true,
    changeMonth: true,
    changeYear: true,
    format: 'dd/mm/yyyy',
    locale: 'pt-br',
    uiLibrary: 'bootstrap4',
    yearRange: '2000:2030',
    minDate: new Date(2000, 1 - 1, 1),
    maxDate: new Date(new Date().getFullYear(), 12 - 1, 31),
    inline: true
    //defaultDate: "+1w"
});

$('#dateAte').datepicker({
    showOn: "button",
    showButtonPanel: true,
    changeMonth: true,
    changeYear: true,
    format: 'dd/mm/yyyy',
    locale: 'pt-br',
    uiLibrary: 'bootstrap4',
    yearRange: '2000:2030',
    minDate: new Date(2000, 1 - 1, 1),
    maxDate: new Date(new Date().getFullYear(), 12 - 1, 31),
    inline: true
});
