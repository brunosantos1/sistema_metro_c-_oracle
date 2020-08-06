$(document).on("click", "#btParalisar", function () {
    $("#motivoParalisacao").val("")
    $("#motivoParalisacao").html("")
    $("#ModalParalisar").modal('show')
})
$("#btConfirmParalisacao").on("click", function () {
    var confirmar = confirm("Tem certeza que deseja paralisar?")
    if (confirmar) {
        alert("Nota paralisada com sucesso");
        $("#ModalParalisar").modal('hide')
    } else {
        $("#ModalParalisar").modal('hide')
    }
})

$(document).on("click", "#btFinalizar", function () {

    $("#ModalFinalizar").modal('show')
})
$("#btConfirmParalisacao").on("click", function () {
    var confirmar = confirm("Tem certeza que deseja finalizar?")
    if (confirmar) {
        alert("Nota finalizada com sucesso");
        $("#ModalFinalizar").modal('hide')
    } else {
        $("#ModalFinalizar").modal('hide')
    }
})
$(".btn_abrirordem").on("click", function () {
    window.location.href ="/MaterialRodante/ApontarOrdem/"
})