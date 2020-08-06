$(document).on("click", ".btn_cancel", function () {
    $("#motivoCancelamento").val("")
    $("#motivoCancelamento").html("")
    $("#ExemploModalCentralizado").modal('show')
})
$("#btConfirmCancelamento").on("click", function () {
    var confirmar = confirm("Tem certeza que deseja cancelar?")
    if (confirmar) {
        alert("Nota cancelada com sucesso");
        $("#ExemploModalCentralizado").modal('hide')
    } else {
        $("#ExemploModalCentralizado").modal('hide')
    }
})

$('.btn_edit').on('click', function () {
    var id = $(this).data('id');
    window.open('/MaterialRodante/NotaMS/' + id, '_blank');
})
$('.btn_details').on('click', function () {
    var id = $(this).data('id');
    window.open('/MaterialRodante/ConsultarMS/' + id, '_blank');
})
$('.btn_train').on('click', function () {
    var id = $(this).data('id');
    window.open('/MaterialRodante/PesquisarEntregaTrem', '_blank');
})