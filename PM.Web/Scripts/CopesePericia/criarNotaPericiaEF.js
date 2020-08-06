$(document).on("click", ".salvar", function () {
    var resposta = confirm("Tem certeza que deseja salvar?");
    if (resposta) {
        alert("Nota salva com sucesso!");
    }
})

$(document).on("click", ".cancelar", function () {
    var resposta = confirm("Tem certeza que deseja cancelar?");
    if (resposta) {
        alert("Nota cancelada com sucesso!");
    }
})