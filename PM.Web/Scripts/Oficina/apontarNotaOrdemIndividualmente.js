$(document).on("click", ".cancelarNota", function () {
    var resposta = confirm("Deseja cancelar a nota?");
    if (resposta) {
        alert("Nota cancelada com sucesso!");
    }
})

$(document).on("click", ".encerrarNota", function () {
    var resposta = confirm("Deseja encerrar a nota?");
    if (resposta) {
        alert("Nota encerrada com sucesso!");
    }
})

$(document).on("click", ".salvarNota", function () {
    var resposta = confirm("Deseja salvar a nota?");
    if (resposta) {
        alert("Nota salva com sucesso!");
    }
})