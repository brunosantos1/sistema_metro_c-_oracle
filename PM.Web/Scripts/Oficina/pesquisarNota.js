$('.btn_details').on('click', function () {
    var id = $(this).data('id');
    //ToDo: Identificar o tipo da nota para definir qual tela chamar (ConsultarOCOPOL, ConsultarOI ou ConsultarPS)
    window.open('/Oficina/ConsultarNotaOCOPOL/' + id, '_blank');
})

$('.btn_edit').on('click', function () {
    var id = $(this).data('id');
    //ToDo: Identificar o tipo da nota para definir qual tela chamar (notaOCOPOL, notaOI ou notaPS)
    window.open('/Oficina/NotaOCOPOL/' + id, '_blank');
})

$('.btn_cancel').on('click', function () {
    var id = $(this).data('id');

    $("#motivoCancelamento").val("");
    $("#motivoCancelamento").html("");
    $("#modal_center").modal('show');
})

$('.btn_free').on('click', function () {
    var id = $(this).data('id');
    window.open('/Oficina/LiberarEquipamentoMaterialIndividualmente/' + id, '_blank');
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