document.onkeydown = function (evt) {
    var keyCode = evt ? (evt.which ? evt.which : evt.keyCode) : event.keyCode;
    if (keyCode == 13) {
        loadFiltros();
        return false;
    }
}

$(document).ready(function () {
    if ($('#dt_inicio').val() == "01/01/0001 00:00:00")
        $('#dt_inicio').val(null);
    if ($('#dt_fim').val() == "01/01/0001 00:00:00")
        $('#dt_fim').val(null);
    LoadDataTable("tblCopeseMR");
});

$(document).on("click", ".encerrarNota", function () {
    var resposta = confirm("Encerrar a Nota?");
    if (resposta) {
        alert("Encerrada com Sucesso!");
    }
})

$(document).on("click", ".estornarNota", function () {
    var resposta = confirm("Estornar a nota?");
    if (resposta) {
        alert("Estornada com sucesso!");
    }
})

$('.consultarDetalhes').on('click', function () {
    var id = $(this).data('id');
    window.location.href = '/CopesePericia/ConsultarNotaCopeseMR/?id=' + id;
})

//$('#dt_inicio').datepicker({
//    showOn: "button",
//    showButtonPanel: true,
//    changeMonth: true,
//    changeYear: true,
//    format: 'dd/mm/yyyy',
//    locale: 'pt-br',
//    uiLibrary: 'bootstrap4',
//    yearRange: '2000:2030',
//    minDate: new Date(2000, 1 - 1, 1),
//    maxDate: new Date(new Date().getFullYear(), 12 - 1, 31),
//    inline: true
//    //defaultDate: "+1w"
//});

//$('#dt_fim').datepicker({
//    showOn: "button",
//    showButtonPanel: true,
//    changeMonth: true,
//    changeYear: true,
//    format: 'dd/mm/yyyy',
//    locale: 'pt-br',
//    uiLibrary: 'bootstrap4',
//    yearRange: '2000:2030',
//    minDate: new Date(2000, 1 - 1, 1),
//    maxDate: new Date(new Date().getFullYear(), 12 - 1, 31),
//    inline: true
//});

function BuscarNotaRef() {
    $(function () {
        $.ajax({
            dataType: "json",
            type: "GET",
            url: "/Oficina2/NotaRefFrotaTremCarro",
            data: { 'nr_nota_sap': $("#cd_nota_sap_Ref").val() },
            success: function (dados) {
                $("#id_local_inst_Ref").val(dados.id_local_inst);

                if (dados.id_local_inst != 0) {
                    $("#id_frota_fk").empty();
                    $("#id_frota_fk").append("<option value='" + dados.id_frota + "'>" + dados.nm_frota + "</option>");

                    $("#id_trem_fk").empty();
                    $("#id_trem_fk").append("<option value='" + dados.id_trem + "'>" + dados.nm_trem + "</option>");

                    $("#id_carro").empty();
                    $("#id_carro").append("<option value='" + dados.id_carro + "'>" + dados.nm_carro + "</option>");
                }
                else {
                    $("#id_frota_fk").empty();
                    $.each(dados.listaFrota, function (index, optiondata) {
                        $("#id_frota_fk").append("<option value='" + optiondata.Value + "'>" + optiondata.Text + "</option>");
                    });

                    $("#id_trem_fk").empty();
                    $("#id_trem_fk").append("<option value='" + dados.id_trem + "'>" + dados.nm_trem + "</option>");

                    $("#id_carro").empty();
                    $("#id_carro").append("<option value='" + dados.id_carro + "'>" + dados.nm_carro + "</option>");
                }
            }
        });
    });
}



function CarregarTrens() {
    $(function () {
        $("#id_trem_fk").empty();
        $.ajax({
            dataType: "json",
            type: "GET",
            url: "/Util/GetTrem",
            data: { 'id_frota': encodeURIComponent(document.getElementById('id_frota_fk').options[document.getElementById('id_frota_fk').selectedIndex].value) },
            success: function (dados) {
                $("#id_trem_fk").empty();
                $("#id_carro").empty();
                $.each(dados, function (index, optiondata) {
                    $("#id_trem_fk").append("<option value='" + optiondata.Value + "'>" + optiondata.Text + "</option>");
                });
            }
        });
    });
}

function CarregarCarros() {
    $(function () {
        $("#id_carro").empty();
        $.ajax({
            dataType: "json",
            type: "GET",
            url: "/Util/GetCarro",
            data: { 'id_trem': encodeURIComponent(document.getElementById('id_trem_fk').options[document.getElementById('id_trem_fk').selectedIndex].value) },
            success: function (dados) {
                $("#id_carro").empty();
                $.each(dados, function (index, optiondata) {
                    $("#id_carro").append("<option value='" + optiondata.Value + "'>" + optiondata.Text + "</option>");
                });
            }
        });
    });
}

$(document).on('click', '.btn_details', function () {
    var id = $(this).data('id');
    window.open('/CopesePericia/ConsultarNotaCopeseMR/?id=' + id, '_blank');
})

$(document).on('click', '.btn_edit', function () {
    var id = $(this).data('id');
    //ToDo: Identificar o tipo da nota para definir qual tela chamar 
    window.open('/CopesePericia/EditarNotaCopeseEFMR?id=' + id, '_blank'); tbm
})

$(document).on('click', '.btn_add', function () {
    var id = $(this).data('id');
    window.open('/CopesePericia/CriarNotaCopeseEFMR/', '_blank');
})

$(document).on('click', '.btn_encerrar', function () {
    var id = $(this).data('id');
    window.open('/CopesePericia/EncerrarCopeseMR?id=' + id);
})

$(document).on('click', '.btn_descaracterizar', function () {
    var id = $(this).data('id');
    window.open('/CopesePericia/Descaracterizar?id=' + id);
})


function loadFiltros() {
    var d1;
    var d2;

    if ($(dt_inicio).val() != null) {
        var parts1 = ($(dt_inicio).val()).split('/');
        d1 = new Date(parts1[1] + "/" + parts1[0] + "/" + parts1[2]);
    }
    if ($(dt_fim).val() != null) {
        var parts2 = ($(dt_fim).val()).split('/');
        d2 = new Date(parts2[1] + "/" + parts2[0] + "/" + parts2[2]);
    }

    if ($(id_st_copese_fk).val() > 0 || $(id_frota_fk).val() > 0 || $(id_carro).val() > 0 || $(id_sintoma).val() > 0
        || $(nr_copese).val() != "" || $(nr_nota_ref).val() != "" || (d1 < d2)) {

        console.log($(dt_inicio).val());
        console.log($(dt_fim).val());

        var url = '/CopesePericia/FiltrarNotaCopeseMRjson/?id_st_copese_fk=' + $(id_st_copese_fk).val()
            + '&id_frota_fk=' + $(id_frota_fk).val()
            + '&id_trem_fk=' + $(id_trem_fk).val()
            + '&id_carro=' + $(id_carro).val()
            + '&id_sintoma=' + $(id_sintoma).val()
            + '&nr_copese=' + $(nr_copese).val()
            + '&nr_nota_ref=' + $(nr_nota_ref).val()
            + '&dt_inicio=' + $(dt_inicio).val()
            + '&dt_fim=' + $(dt_fim).val();
        console.log(url);
        LoadDataTable("tblCopeseMR", url);
    }
    else {
        alert("Informe ao menos um filtro de pesquisa.");
    }
    //tblCopeseMR = $('#tblCopeseMR').DataTable({

    //    "ajax": '/CopesePericia/FiltrarNotaCopeseMRjson/?id_st_copese_fk=' + $(id_st_copese_fk).val()
    //        + '&id_frota_fk =' + $(id_frota_fk).val()
    //        + '&id_trem_fk=' + $(id_trem_fk).val()
    //        + '&id_carro=' + $(id_carro).val()
    //        + '&id_sintoma=' + $(id_sintoma).val()
    //        + '&nr_copese=' + $(nr_copese).val()
    //        + '&nr_nota_ref=' + $(nr_nota_ref).val()
    //        + '&dt_inicio=' + $(dt_inicio).val()
    //        + '&dt_fim=' + $(dt_fim).val(),
    //    "columnDefs": [
    //        {
    //            "render": function (data, type, row) {
    //                var buttons = 
    //                    '<a href="#" data-id="' + row[11] + '" class="btn_details"><i class="material-icons">search</i></a>' +
    //                    '<a href="#" data-id="' + row[11] + '" class="btn_add"><i class="material-icons">add</i></a>' +
    //                    '<a href="#" data-id="' + row[11] + '" class="btn_edit"><i class="material-icons">edit</i></a>'+
    //                    '<a href="#" data-id="' + row[11] + '" class="btn_cancel"><i class="material-icons" style="color:#FF0000">close</i></a>';

    //                return buttons
    //            },
    //            "targets": 11
    //        }
    //    ],
    //    "lengthChange": false,
    //    "bFilter": false,
    //    "bInfo": false,
    //    "language": {
    //        "paginate": {
    //            "previous": "Próxima",
    //            "next": "Anterior",
    //            "first": "Primeira",
    //            "last": "Última"
    //        }
    //    }
    //});

}
