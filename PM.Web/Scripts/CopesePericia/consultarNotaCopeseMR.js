$('.voltar').on('click', function () {
    var id = $(this).data('id');
    window.location.href = '/CopesePericia/PesquisarNotaCopeseMR/' + id;
})



$(document).on("click", ".cancelar", function () {
    var resposta = confirm("Confirma o cancelamento da Nota " + $("#id_nota").val() + "?");
    if (resposta) {
        $(function () {
            $.ajax({
                dataType: "json",
                type: "GET",
                url: "/CopesePericia/SalvarCancelar",
                data: { 'id': $("#id_nota").val() },
                success: function (dados) {
                    alert("Cancelamento realizado com sucesso");
                }
            });
        });
    }
})

$(document).on("click", ".encerrar", function () {
    var resposta = confirm("Confirma o encerramento da Nota " + $("#id_nota").val() + "?");
    if (resposta) {
        $(function () {
            $.ajax({
                dataType: "json",
                type: "GET",
                url: "/CopesePericia/SalvarEncerrarCopeseMR",
                data: { 'id': $("#id_nota").val() },
                success: function (dados) {
                    alert("Encerramento realizado com sucesso");
                }
            });
        });
    }
})


$(document).on("click", ".descaracterizar", function () {
    var resposta = confirm("Confirma a descaracterização da Nota " + $("#id_nota").val() + "?");
    if (resposta) {
        $(function () {
            $.ajax({
                dataType: "json",
                type: "GET",
                url: "/CopesePericia/SalvarDescaracterizar",
                data: { 'id': $("#id_nota").val() },
                success: function (dados) {
                    alert("Descaracterizada com sucesso!");
                }
            });
        });
    }
})
