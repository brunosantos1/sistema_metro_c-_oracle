$(".cancelarEmpregado").on("click", function () {
    var resposta = confirm("Cancelar a inclusão do empregado no Centro de Trabalho?");
    if (resposta) {
        alert("Cancelado com sucesso!");
    }
})

$(".incluirEmpregado").on("click", function () {
    var resposta = confirm("Incluir o empregado no Centro de Trabalho?");
    if (resposta) {
        alert("Incluído com sucesso!");
    }
})