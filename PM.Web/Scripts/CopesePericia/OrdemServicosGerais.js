$(document).on("click", ".criar", function () {
    var resposta = confirm("Deseja criar a ordem?");
    if (resposta) {
        alert("Ordem criada com sucesso!");
    }
})

$(document).on("click", ".cancelar", function () {
    var resposta = confirm("Deseja cancelar a ordem?");
    if (resposta) {
        alert("Ordem cancelada com sucesso!");
    }
})

$('#inputData').datepicker({
    changeMonth: true,
    changeYear: true,
    format: 'dd/mm/yyyy',
    locale: 'pt-br',
    uiLibrary: 'bootstrap4',
});

$('#inputHora').timepicker({
    locale: 'pt-br',
    uiLibrary: 'bootstrap4',
});