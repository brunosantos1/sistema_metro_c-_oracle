$("#btn_notas_vinculadas").on("click", function () {
    var id = $(this).data('id');
    window.location.href = '/EquipamentoFixo/ConsultarNotaVinculada/' + id;
})

$("#btn_documentos_vinculados").on("click", function () {
    var id = $(this).data('id');
    alert(id);
})