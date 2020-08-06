$(".incluirEmpregado").on("click", function () {
    var resposta = confirm("Incluir novo empregado no Centro de Trabalho?");
    if (resposta) {
        alert("Incluído com sucesso!");
    }
})

$(".excluirEmpregado").on("click", function () {
    var resposta = confirm("Excluir empregado do Centro de Trabalho?");
    if (resposta) {
        alert("Excluído com sucesso!");
    }
})