$(document).ready(function () {
    showModalEmpregados("modalNotificadores_container", "btnNotificador", "id_notificador_fk", "nm_notificador");
    $('#ds_descricao').attr("readonly", true).addClass("disabled");
})

function BuscarNotaRef() {
    $(function () {
        $.ajax({
            dataType: "json",
            type: "GET",
            url: "/CopesePericia/PericiaBuscarNotaRef",
            data: { 'nr_nota_sap': $("#cd_nota_sap_Ref").val() },
            success: function (dados) {
                $("#id_nota_referencia_fk").val(dados.id_nota);
                $("#id_local_inst_Ref").val(dados.id_local_inst);
                $("#id_frota_fk").empty();

                if (dados.id_nota == 0) {
                    $.each(dados.listaFrota, function (index, optiondata) {
                        $("#id_frota_fk").append("<option value='" + optiondata.Value + "'>" + optiondata.Text + "</option>");
                    });
                    document.getElementById("ds_descricao").readonly = true;
                    alert('Nota de Referência não encontrada.')
                    $("#cd_nota_sap_Ref").val('');
                }
                else {
                    $("#id_frota_fk").append("<option value='" + dados.id_frota + "'>" + dados.nm_frota + "</option>");
                    document.getElementById("ds_descricao").readonly = false;
                }

                $("#id_trem_fk").empty();
                $("#id_trem_fk").append("<option value='" + dados.id_trem + "'>" + dados.nm_trem + "</option>");

                $("#id_carro").empty();
                $("#id_carro").append("<option value='" + dados.id_carro + "'>" + dados.nm_carro + "</option>");

                //$("#id_linha").empty();
                //$("#id_linha").append("<option value='" + dados.id_linha + "'>" + dados.nm_linha + "</option>");

                //$("#id_centro_trabalho_fk").val(dados.id_ct_trabalho);
                //$("#ds_ct_trabalho").val(dados.ds_ct_trabalho);

                $("#id_notificador_fk").val(dados.id_notificador_fk);
                $("#nm_notificador").val(dados.nm_notificador);
                $("#ds_descricao").val(dados.ds_descricao);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
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

function habilitaNotaReferencia_change(el) {
    if (el.checked == true) {
        $('#cd_nota_sap_Ref').attr("readonly", false).removeClass("disabled");
        document.getElementById("btnPesquisar").style.display = "inline-block";
        $('#id_frota_fk').attr("disabled", "disabled").addClass("disabled");
        $('#id_trem_fk').attr("disabled", "disabled").addClass("disabled");
        $('#id_carro').attr("disabled", "disabled").addClass("disabled");
        $('#ds_descricao').attr("readonly", true).addClass("disabled");

        //document.getElementById("id_frota_fk").value = 0;
        //document.getElementById("id_trem_fk").value = 0;
        //document.getElementById("id_carro").value = 0;
    }
    else {
        $('#cd_nota_sap_Ref').attr("readonly", true).addClass("disabled");
        document.getElementById("btnPesquisar").style.display = "none";

        $('#id_frota_fk').attr("disabled", false).removeClass("disabled");
        $('#id_trem_fk').attr("disabled", false).removeClass("disabled");
        $('#id_carro').attr("disabled", false).removeClass("disabled");
        $('#ds_descricao').attr("readonly", false).removeClass("disabled");
        //document.getElementById("cd_nota_sap_Ref").value = '';

        $(function () {
            $.ajax({
                dataType: "json",
                type: "GET",
                url: "/Util/GetFrota",
                data: {},
                success: function (dados) {
                    $("#id_frota_fk").empty();

                    $.each(dados, function (index, optiondata) {
                        $("#id_frota_fk").append("<option value='" + optiondata.Value + "'>" + optiondata.Text + "</option>");
                    });
                    $("#id_trem_fk").empty();
                    $("#id_trem_fk").append("<option value='0'>*** SELECIONE ***</option>");

                    $("#id_carro").empty();
                    $("#id_carro").append("<option value='0'>*** SELECIONE ***</option>");
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.status);
                    alert(thrownError);
                }
            });
        });
    }
}