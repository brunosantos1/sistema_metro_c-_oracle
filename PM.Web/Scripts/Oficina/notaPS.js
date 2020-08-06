$(document).on("click", ".salvarNota", function () {
    var resposta = confirm("Deseja salvar a nota?");
    if (resposta) {
        alert("Nota salva com sucesso!");
    }
})

$(document).on("click", ".cancelarNota", function () {
    var id = $(this).data('id');

    $("#motivoCancelamento").val("");
    $("#motivoCancelamento").html("");
    $("#modal_center").modal('show');
})

$("#btConfirmCancelamento").on("click", function () {
    var confirmar = confirm("Tem certeza que deseja cancelar?")
    if (confirmar) {
        alert("Nota cancelada com sucesso");
        $("#modal_center").modal('hide')
    } else {
        $("#modal_center").modal('hide')
    }
})