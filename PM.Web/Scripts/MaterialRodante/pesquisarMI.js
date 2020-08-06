var tblPesquisar;
var pesquisa_idFrota;
var pesquisa_idTrem;
var pesquisa_idCarro;
var pesquisa_cdSap;
var pesquisa_dataInicial;
var pesquisa_dataFinal;
var pesquisa_rgNotificador;
var pesquisa_idNotificador;
var pesquisa_idStatus;

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
                        pesquisarNotas();
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

$("#btn_filtrar").on("click", function () {
    pesquisarNotasForm();
});

$("#id_frota_fk").on("change", function () {
    var idFrota = $("#id_frota_fk").val();

    if (idFrota) {
        $.ajax({
            method: "GET",
            url: "/MR/NotaInspecao/GetTrens?id=" + idFrota,
            success: function (data) {
                var html = "<option value=''>Selecione um item</option>";

                for (var i = 0; i < data.length; i++) {
                    html += "<option value='" + data[i].IdTrem + "'>" + data[i].NmTrem + "</option>";
                }
                
                $("#id_trem_fk").html(html);
                $("#id_trem_fk").val("").trigger('change');
            },
            error: function () {
                alert('erro 1');
            }
        })
    } else {
        $("#id_trem_fk").val("").trigger("change");
        $("#id_trem_fk").html("<option value=''>Selecione um item</option>");
    }
});

$("#id_trem_fk").on("change", function () {
    var idTrem = $("#id_trem_fk").val();

    if (idTrem) {
        $.ajax({
            method: "GET",
            url: "/MR/NotaInspecao/GetCarros?id=" + idTrem,
            success: function (data) {
                
                var html = "<option value=''>Selecione um item</option>"
                
                for (var i = 0; i < data.length; i++) {
                    html += "<option value='" + data[i].IdCarro + "'>" + data[i].NmCarro + "</option>";
                }
                
                $("#id_carro_fk").html(html);

                $("#id_carro_fk").val("").trigger('change');
                
            },
            error: function () {
                alert('erro 2');
            }
        });
    } else {
        $("#id_carro_fk").val("").trigger("change");
        $("#id_carro_fk").html("<option value=''>Selecione um item</option>");
    }
});

function pesquisarNotasForm() {
    pesquisa_idFrota = $("#id_frota_fk").val();
    pesquisa_idTrem = $("#id_trem_fk").val();
    pesquisa_idCarro = $("#id_carro_fk").val();
    pesquisa_cdSap = $("#cd_sap").val();
    pesquisa_dataInicial = $("#dt_inicial").val();
    pesquisa_dataFinal = $("#dt_final").val();
    pesquisa_rgNotificador = $("#rg_notificador").val();
    pesquisa_idStatus = $("#id_status_usuario").val();
    pesquisa_idNotificador = $("#id_notificador_fk").val();

    pesquisarNotas();
}

function pesquisarNotas() {
    var queryUrl = "";

    if (pesquisa_idFrota) {
        if (queryUrl) {
            queryUrl += "&";
        }

        queryUrl += "idFrota=" + pesquisa_idFrota;
    }

    if (pesquisa_idTrem) {
        if (queryUrl) {
            queryUrl += "&";
        }

        queryUrl += "idTrem=" + pesquisa_idTrem;
    }

    if (pesquisa_idCarro) {
        if (queryUrl) {
            queryUrl += "&";
        }

        queryUrl += "idCarro=" + pesquisa_idCarro;
    }

    if (pesquisa_cdSap) {
        if (queryUrl) {
            queryUrl += "&";
        }

        queryUrl += "cdSap=" + pesquisa_cdSap;
    }

    if (pesquisa_dataInicial) {
        if (queryUrl) {
            queryUrl += "&";
        }

        var parts1 = pesquisa_dataInicial.split('/');
        var dtIni = parts1[2] + "-" + parts1[1] + "-" + parts1[0]+" 00:00:00";

        queryUrl += "dataInicial=" + dtIni;
    }

    if (pesquisa_dataFinal) {
        if (queryUrl) {
            queryUrl += "&";
        }

        var parts2 = pesquisa_dataFinal.split('/');
        var dtFin = parts2[2] + "-" + parts2[1] + "-" + parts2[0]+" 23:59:59";

        queryUrl += "dataFinal=" + dtFin;
    }

    if (pesquisa_idNotificador) {
        if (queryUrl) {
            queryUrl += "&";
        }

        queryUrl += "idNotificador=" + pesquisa_idNotificador;
    }

    if (pesquisa_idStatus) {
        if (queryUrl) {
            queryUrl += "&";
        }

        queryUrl += "idStatus=" + pesquisa_idStatus;
    }

    if (!queryUrl) {
        alert("Informe ao menos um filtro");
        return false;
    } else {
        //queryUrl = encodeURI(queryUrl);
    }

    if ($.fn.dataTable.isDataTable('#tblPesquisaNotas')) {
        tblPesquisar.ajax.url('/MR/PesquisarNotaMI/GetData?' + queryUrl).load();
    } else {
        carregarDataTable(queryUrl);
    }
}

function carregarDataTable(qrUrl) {
    tblPesquisar = $('#tblPesquisaNotas').DataTable({
        "ajax": '/MR/PesquisarNotaMI/GetData?' + qrUrl,
        "columnDefs": [
            {
                "render": function (data, type, row) {
                    var buttons = '<i class="material-icons btn_details" data-id="' + row[0] + '" style="cursor:pointer;display:inline">search</i>' +
                        '<i class="material-icons btn_edit" data-id="' + row[0] + '" style="cursor:pointer;display:inline">edit</i>' +
                        '<i class="material-icons btn_cancel" data-id="' + row[0] + '" style="cursor:pointer;display:inline">close</i>' +
                        '<i class="material-icons btn_train" data-id="' + row[0] + '" style="cursor:pointer;display:inline">train</i>'

                    return buttons
                },
                "targets": 11
            },
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            }
        ],
    });
}

function getStatusUsuario() {
    $.ajax({
        method: "GET",
        url: "/MR/PesquisarNotaMI/GetStatusUsuario",
        success: function (data) {
            $("#id_status_usuario").html("");

            var html = "<option value=''>Selecione um item</option>";
            for (var i = 0; i < data.length; i++) {
                html += "<option value='" + data[i].IdStUsuario + "'>" + data[i].DsStUsuario + "</option>";
            }
            $("#id_status_usuario").html(html);
            $("#id_status_usuario").val("").trigger("");
        },
        error: function (a, b, c) {
            alert('erro 6');
        }
    });
}

function setupDatePickers() {
    $('#dt_inicial').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        locale: 'pt-br',
        uiLibrary: 'bootstrap4',
        maxDate: function () {
            return $('#dt_final').val();
        }
    });

    $('#dt_final').datepicker({
        changeMonth: true,
        changeYear: true,
        format: 'dd/mm/yyyy',
        locale: 'pt-br',
        uiLibrary: 'bootstrap4',
        minDate: function () {
            return $('#dt_inicial').val();
        }
    });
}

$(document).on("click", ".btn_details", function (e) {
    var idNota = $(this).attr("data-id");
    window.open("/MR/NotaInspecao/Consultar/"+idNota, "_blank");
});

$(document).on("click", ".btn_edit", function (e) {
    var idNota = $(this).attr("data-id");
    window.open("/MR/NotaInspecao/Cadastro/" + idNota, "_blank");
});

$(document).on("click", ".btn_cancel", function () {
    var tr = $(this).closest("tr")[0];
    var valores = tblPesquisar.row(tr).data();

    modalCancelarNota(valores[0]);
});

$("#btn_limpar_filtro").on("click", function () {
    window.location.href = "/MR/PesquisarNotaMI/Pesquisar";
});

$(document).ready(function () {
    getStatusUsuario();
    setupDatePickers();
    carregarDataTable("");
    showModalEmpregados("modalNotificadores_container", "btnNotificador", "id_notificador_fk", "nm_notificador");
});