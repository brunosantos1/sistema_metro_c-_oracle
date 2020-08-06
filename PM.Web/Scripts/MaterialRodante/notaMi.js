var tblDocumentosVinculados = null;

switch (vwAction) {
    case 'Consultar':
        $("input").prop("disabled", "disabled");
        $("select").prop("disabled", "disabled");
        $("input[type='checkbox']").prop("disabled", "disabled");
        $("textarea").prop("disabled", "disabled");
        $("#btnNotificador").prop("disabled", "disabled");
        $("button[type='submit']").css("display", "none");
        $("#btnCancelar").css("display", "none");
        $("#btnCarregarUltima").css("display", "none");
        $("#tblNotasAbertasPendentes").css("display", "none");
        break;
    case 'Editar':
        $("#btnCancelar").css("display", "none");
        break;
    case 'Criar':
        break;
}

$(document).on("click", ".btn_details", function () {
    var id = $(this).data('id');
    window.open('/MR/NotaInspecao/Consultar?id=' + id, '_blank');
})

$(document).on("click", ".btn_edit", function () {
    var id = $(this).data('id');
    window.open('/MR/NotaInspecao/Cadastro?id=' + id, '_blank');
})

$(document).on("click", ".btn_cancel", function () {
    var id = $(this).data('id');

    $("#modalCancelarNota_container").modal('show');
    $("#idCancelamento").val(id);
    $("#motivoCancelamento").val("");
    $("#motivoCancelamento").html("");
})

$(document).on("click", "#btnCancelar", function () {
    window.location.href = "/MR/NotaInspecao/Cadastro";
})

$(document).on("click", "#btnConfirmarCancelamento", function () {
    var confirmar = confirm("Tem certeza que deseja cancelar?")

    if (confirmar) {
        var cancelamentoId = $("#idCancelamento").val();
        var cancelamentoMotivo = $("#motivoCancelamento").val();

        if (cancelamentoId) {
            if (cancelamentoMotivo) {
                $.ajax({
                    method: "POST",
                    url: "/MR/NotaInspecao/Cancelar",
                    data: {
                        "id": $("#idCancelamento").val(),
                        "motivo": $("#motivoCancelamento").val()
                    },
                    success: function (data) {
                        alert(data.BaseModel.Erro);
                        $("#modalCancelarNota_container").modal('hide');

                        var frota_id = $("#id_frota_fk").val();
                        var trem_id = $("#id_trem_fk").val();
                        loadNotasAbertasPendentes(frota_id, trem_id);
                    },
                    error: function () {
                        //alert('erro');
                        $("#modalCancelarNota_container").modal('hide');
                    }
                });
            } else {
                alert("Informe o motivo do cancelamento");
            }
        }
    } else {
        $("#modalCancelarNota_container").modal('hide')
    }
})

$(document).on("click", "#btnCarregarUltima", function () {
    window.location.href = "/MR/NotaInspecao/Cadastro?copiarUltima=true";
})

//$('.btn_train').on('click', function () {
//    var id = $(this).data('id');
//    window.open('/MaterialRodante/PesquisarEntregaTrem', '_blank');
//})

$("#id_frota_fk").on("change", function () {
    var frota_id = $("#id_frota_fk").val();
    $("#hidden_id_frota_fk").val(frota_id);
    
    loadTrens(frota_id);

    var trem_id = $("#id_trem_fk").val();
    var carro_id = $("#id_carro_fk").val();

    loadLocalInstalacao(frota_id, trem_id, carro_id);
})

$("#id_trem_fk").on("change", function () {
    var frota_id = $("#id_frota_fk").val();
    var trem_id = $("#id_trem_fk").val();

    $("#hidden_id_trem_fk").val(trem_id);

    loadCarros(trem_id);
    loadNotasAbertasPendentes(frota_id, trem_id);

    var carro_id = $("#id_carro_fk").val();
   
    loadLocalInstalacao(frota_id, trem_id, carro_id);
    getLinhaAtual(trem_id);
})

$("#id_carro_fk").on("change", function () {
    var frota_id = $("#id_frota_fk").val();
    var trem_id = $("#id_trem_fk").val();

    var carro_id = $("#id_carro_fk").val();
    $("#hidden_id_carro_fk").val(carro_id);

    loadLocalInstalacao(frota_id, trem_id, carro_id);
})

$("#id_linha_fk").on("change", function () {
    var linha_id = $("#id_linha_fk").val();
    $("#hidden_id_linha_fk").val(linha_id);

    loadCentroTrabalho(linha_id);
})

function loadFrotas() {
    $("#id_frota_fk").html("<option value=''>Selecione um item</option>");

    $.ajax({
        method: "GET",
        url: "/MR/NotaInspecao/GetFrotas",
        success: function (data) {
            var html = "";

            for (var i = 0; i < data.length; i++) {
                html += "<option value='" + data[i].IdFrota + "'>" + data[i].NmFrota + "</option>";
            }

            var frota_id = $("#hidden_id_frota_fk").val();

            $("#id_frota_fk").append(html);
            $("#id_frota_fk").val(frota_id);

            $("#id_frota_fk").trigger('change');
        },
        error: function () {
            //alert('erro');
            $("#id_frota_fk").trigger('change');
        }
    })
}

function loadTrens(frota_id) {
    $("#id_trem_fk").html("<option value=''>Selecione um item</option>");

    if (frota_id) {
        $.ajax({
            method: "GET",
            url: "/MR/NotaInspecao/GetTrens?id_frota=" + frota_id,
            success: function (data) {
                var html = "";

                for (var i = 0; i < data.length; i++) {
                    html += "<option value='" + data[i].IdTrem + "'>" + data[i].NmTrem + "</option>";
                }

                var trem_id = $("#hidden_id_trem_fk").val();

                $("#id_trem_fk").append(html);
                $("#id_trem_fk").val(trem_id);

                $("#id_trem_fk").trigger('change');
            },
            error: function () {
                //alert('erro');
                $("#id_trem_fk").trigger('change');
            }
        })
    } else {
        $("#id_trem_fk").trigger('change');
    }
}

function loadCarros(trem_id) {
    $("#id_carro_fk").html("<option value=''>Selecione um item</option>");

    if (trem_id) {
        $.ajax({
            method: "GET",
            url: "/MR/NotaInspecao/GetCarros?id=" + trem_id,
            success: function (data) {
                var html = "";

                for (var i = 0; i < data.length; i++) {
                    html += "<option value='" + data[i].IdCarro + "'>" + data[i].NmCarro + "</option>";
                }

                var carro_id = $("#hidden_id_carro_fk").val();

                $("#id_carro_fk").append(html);
                $("#id_carro_fk").val(carro_id);

                $("#id_carro_fk").trigger('change');
            },
            error: function () {
                //alert('erro');
                $("#id_carro_fk").trigger('change');
            }
        })
    } else {
        $("#id_carro_fk").trigger('change');
    }
}

function loadLinhas(linha_id) {
    $("#id_linha_fk").html("<option value=''>Selecione um item</option>");

    $.ajax({
        method: "GET",
        url: "/MR/NotaInspecao/GetLinhas",
        success: function (data) {
            var html = "";

            for (var i = 0; i < data.length; i++) {
                html += "<option value='" + data[i].IdLinha + "'>" + data[i].NmLinha + "</option>";
            }

            if (linha_id) {
                $("#hidden_id_linha_fk").val(linha_id);
            }

            var id_linha = $("#hidden_id_linha_fk").val();

            $("#id_linha_fk").append(html);
            $("#id_linha_fk").val(id_linha);
        },
        error: function () {
            //alert('erro');
        }
    })
}

function getLinhaAtual(trem_id) {
    if (trem_id) {
        $.ajax({
            method: "GET",
            url: "/MR/NotaInspecao/GetTrem?id=" + trem_id,
            success: function (data) {
                if (data) {
                    var id_linha_atual = data.IdLinhaAtualFk;

                    if (id_linha_atual) {
                        $("#id_linha_fk").val(id_linha_atual);
                        $("#hidden_linha_fk").val(id_linha_atual);
                    } else {
                        $("#id_linha_fk").val('');
                        $("#hidden_linha_fk").val('');
                    }

                    $("#id_linha_fk").trigger('change');
                }
            },
            error: function () {
                //alert('erro');
                $("#id_linha_fk").trigger('change');
            }
        })
    } else {
        //$("#id_linha_fk").val('');
        //$("#hidden_linha_fk").val('');
        $("#id_linha_fk").trigger('change');
    }
}

function loadLocalInstalacao(frota_id, trem_id, carro_id) {
    $("#id_local_instalacao_fk").val("");
    $("#ds_local_instalacao").val("");

    if (frota_id && trem_id && carro_id) {
        $.ajax({
            method: "GET",
            url: "/MR/NotaInspecao/GetLocalInstalacao?idFrota=" + frota_id + "&idTrem=" + trem_id + "&idCarro=" + carro_id,
            success: function (data) {
                if (data.length) {
                    var local_inst = data[0];

                    if (local_inst) {
                        $("#id_local_instalacao_fk").val(local_inst.IdLcInstalacao);
                        $("#ds_local_instalacao").val(local_inst.DsLcInstalacao);
                    }
                }
            },
            error: function () {
                //alert('erro');
            }
        })
    }
}

function loadCentroTrabalho(linha_id) {
    if (linha_id) {
        $.ajax({
            method: "GET",
            url: "/MR/NotaInspecao/GetCentroTrabalho?linha_id=" + linha_id,
            success: function (data) {
                if (data) {
                    console.log('carregando centro de trabalho');

                    if (data.IdCtTrabalho) {
                        $("#ds_centro_trabalho_fk").val(data.DsCtTrabalho);
                        $("#id_centro_trabalho_fk").val(data.IdCtTrabalho);
                    } else {
                        $("#ds_centro_trabalho_fk").val('');
                        $("#id_centro_trabalho_fk").val('');
                    }
                }

                var centro_trabalho_id = $("#id_centro_trabalho_fk").val();
                $("#id_centro_trabalho_fk").val(centro_trabalho_id);
            },
            error: function () {
                console.log('erro');
                //alert('erro');
            }
        })
    } else {
        $("#ds_centro_trabalho_fk").val('');
        $("#id_centro_trabalho_fk").val('');
    }
}

function loadNotasAbertasPendentes(frota_id, trem_id) {
    if (vwAction == "Consultar") {
        return false;
    }

    var url;

    if (frota_id && trem_id) {
        url = '/MR/NotaInspecao/GetNotasAbertasPendentes?idFrota=' + frota_id + "&idTrem=" + trem_id;
    } else {
        url = '/MR/NotaInspecao/GetNotasAbertasPendentes';
    }

    if ($.fn.dataTable.isDataTable('#tblNotasAbertasPendentes')) {
        tblDocumentosVinculados.ajax.url(url).load();
    } else {
        tblDocumentosVinculados = $('#tblNotasAbertasPendentes').DataTable({
            "ajax": url,
            "columnDefs": [
                {
                    "render": function (data, type, row) {
                        var buttons = '<i class="material-icons btn_details" data-id="' + row[0] + '" style="cursor:pointer;display:inline">search</i>' +
                            '<i class="material-icons btn_edit" data-id="' + row[0] + '" style="cursor:pointer;display:inline">edit</i>' +
                            '<i class="material-icons btn_cancel" data-id="' + row[0] + '" style="cursor:pointer;display:inline">close</i>' +
                            '<i class="material-icons btn_train" data-id="' + row[0] + '" style="cursor:pointer;display:inline">train</i>';

                        return buttons;
                    },
                    "targets": 11
                },
                {
                    "targets": [0],
                    "visible": false,
                    "searchable": false
                }
            ]
        });
    }
}

$(document).ready(function () {
    loadLinhas();
    loadFrotas();
    showModalEmpregados("modalNotificadores_container", "btnNotificador", "id_notificador_fk", "nm_notificador");
    loadNotasAbertasPendentes();
})