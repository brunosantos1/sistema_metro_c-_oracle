$(document).on("click", ".liberarNota", function () {
    var resposta = confirm("Deseja liberar a nota?");
    if (resposta) {
        alert("Nota liberada com sucesso!");
    }
})

$(document).on("click", ".cancelarNota", function () {
    var resposta = confirm("Deseja cancelar a nota?");
    if (resposta) {
        alert("Nota calcelada com sucesso!");
    }
})

$('.btn_mount').on('click', function () {
    var id = $(this).data('id');
    window.open('/Oficina/MontarSubequipamento/' + id, '_blank');
})