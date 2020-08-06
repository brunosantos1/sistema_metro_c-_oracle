$(document).ready(function () {
    if ($('#dt_inicio').val() == "01/01/0001 00:00:00")
        $('#dt_inicio').val(null);
    if ($('#dt_fim').val() == "01/01/0001 00:00:00")
        $('#dt_fim').val(null);
    LoadDataTable("tblPericiaMR");
});

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
//    inline: true,
//    maxDate: function () {
//        return $('#dt_fim').val();
//    }
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
//    inline: true,
//    minDate: function () {
//        return $('#dt_inicio').val();
//    }
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

function BuscarLinha() {
    $(function () {
        $.ajax({
            dataType: "json",
            type: "GET",
            url: "/Util/BuscarLinha",
            data: { 'id_linha': $("#id_linha").val() },
            success: function (dados) {
                $("#id_centro_trabalho_fk").val(dados.IdCentroTrabalhoFk);
                $("#ds_ct_trabalho").val(dados.CentroTrabalho.DsCtTrabalho);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }
        });
    });
}

function CarregarSistema() {
    $(function () {
        $.ajax({
            dataType: "json",
            type: "GET",
            url: "/Util/GetSistema",
            data: { 'id_frota': encodeURIComponent(document.getElementById('id_frota_fk').options[document.getElementById('id_frota_fk').selectedIndex].value) },
            success: function (dados) {
                $("#id_sistema").empty();
                $.each(dados, function (index, optiondata) {
                    $("#id_sistema").append("<option value='" + optiondata.Value + "'>" + optiondata.Text + "</option>");
                });
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }
        });
    });
}

function CarregarTrens() {
    $(function () {
        $.ajax({
            dataType: "json",
            type: "GET",
            url: "/Util/GetTrem",
            data: { 'id_frota': encodeURIComponent(document.getElementById('id_frota_fk').options[document.getElementById('id_frota_fk').selectedIndex].value) },
            success: function (dados) {
                $("#id_trem_fk").empty();
                $.each(dados, function (index, optiondata) {
                    $("#id_trem_fk").append("<option value='" + optiondata.Value + "'>" + optiondata.Text + "</option>");
                });
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }
        });
    });
}

function CarregarCarros() {
    $(function () {
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
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }
        });
    });
}

//$('.consultarDetalhes').on('click', function () {
//    var id = $(this).data('id');
//    window.location.href = '/CopesePericia/ConsultarNotaPericiaMR?id=' + id + '&& operacao=2';
//})

$(document).on('click', '.btn_details', function () {
    var id = $(this).data('id');
    window.open('/CopesePericia/ConsultarNotaPericiaMR?id=' + id + '&&operacao=2', '_blank');
})

$(document).on('click', '.btn_add', function () {
    var id = $(this).data('id');
    window.open('/CopesePericia/CriarNotaPericiaMR/', '_blank');
})

$(document).on('click', '.btn_edit', function () {
    var id = $(this).data('id');
    window.open('/CopesePericia/EditarNotaPericiaMR?id=' + id, '_blank'); tbm
})

$(document).on('click', '.btn_libera', function () {
    var id = $(this).data('id');
    window.open('/CopesePericia/ConsultarNotaPericiaMR?id=' + id + '&&operacao=3', '_blank');
    window.close
})

$(document).on('click', '.btn_encerra', function () {
    var id = $(this).data('id');
    window.open('/CopesePericia/ConsultarNotaPericiaMR?id=' + id + '&&operacao=4', '_blank');
})

//$(document).on('click', '.btn_cancel', function () {
//    var id = $(this).data('id');
//    window.open('/CopesePericia/CancelarNotaPericiaMR/' + id, 'CancelarNota', 'width=800, height=600');
//})

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

    if ($(id_st_pericia_fk).val() > 0 ||
        $(id_frota_fk).val() > 0 ||
        $(id_carro).val() > 0 ||
        $(id_sistema).val() > 0 ||
        $(id_ev_gerador_fk).val() > 0 ||
        $(cd_bo_metro).val() != "" ||
        $(cd_bo_ssp).val() != "" ||
        $(cd_nota_sap).val() != "" ||
        $(cd_nota_sap_Ref).val() != "" ||
        (d1 <= d2)) {

        console.log($(dt_inicio).val());
        console.log($(dt_fim).val());

        var url = '/CopesePericia/FiltrarNotaPericiaMRjson/?id_st_pericia_fk=' + $(id_st_pericia_fk).val()
            + '&id_frota_fk=' + $(id_frota_fk).val()
            + '&id_trem_fk=' + $(id_trem_fk).val()
            + '&id_carro=' + $(id_carro).val()
            + '&id_sistema=' + $(id_sistema).val()
            + '&id_ev_gerador_fk=' + $(id_ev_gerador_fk).val()
            + '&cd_bo_metro=' + $(cd_bo_metro).val()
            + '&cd_bo_ssp=' + $(cd_bo_ssp).val()
            + '&cd_nota_sap=' + $(cd_nota_sap).val()
            + '&cd_nota_sap_Ref=' + $(cd_nota_sap_Ref).val()
            + '&dt_inicio=' + $(dt_inicio).val()
            + '&dt_fim=' + $(dt_fim).val();
        console.log(url);
        LoadDataTable("tblPericiaMR", url);
    }
    else {
        alert("Informe ao menos um filtro de pesquisa.");
    }
}