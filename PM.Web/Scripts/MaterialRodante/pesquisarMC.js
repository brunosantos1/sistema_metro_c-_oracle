var tblPesquisar;
$("#btn_filtrar").on("click", function () {
    PesquisarNotasForm();
});

$("#id_frota_fk").on("change", function () {
    var idFrota = $("#id_frota_fk").val();

    if (idFrota) {
        $.ajax({
            method: "GET",
            url: "/MR/NotaCorretiva/Trens?id=" + idFrota,
            success: function (data) {
                var html = "<option value=''></option>";
                for (var i = 0; i < data.length; i++) {
                    html += "<option value='" + data[i].IdTrem + "'>" + data[i].NmTrem + "</option>";
                }

                $("#id_trem_fk").html(html);

                $("#id_trem_fk").val("").trigger('change');

            },
            error: function () {
                alert('erro');
            }
        })
    } else {
        $("#id_trem_fk").val("").trigger("change");
        $("#id_trem_fk").html("<option value=''></option>");
    }
    checkLocalInstalacao();
});

$("#id_trem_fk").on("change", function () {
    var idTrem = $("#id_trem_fk").val();


    if (idTrem) {
        $.ajax({
            method: "GET",
            url: "/MR/NotaCorretiva/Carros?id=" + idTrem,
            success: function (data) {

                var html = "<option value=''></option>"

                for (var i = 0; i < data.length; i++) {
                    html += "<option value='" + data[i].IdCarro + "'>" + data[i].NmCarro + "</option>";
                }

                $("#id_carro_fk").html(html);

                $("#id_carro_fk").val("").trigger('change');

            },
            error: function () {
                alert('erro');
            }
        });

    } else {

        $("#id_carro_fk").val("").trigger("change");
        $("#id_carro_fk").html("<option value=''></option>");

    }
    checkLocalInstalacao();
});

$("#id_carro_fk").on("change", function () {
    checkLocalInstalacao();
});



var pesquisa_idFrota;
var pesquisa_idTrem;
var pesquisa_idCarro;
var pesquisa_cdSap;
var pesquisa_idSistema;
var pesquisa_idSintoma;
var pesquisa_dataInicial;
var pesquisa_dataFinal;
var pesquisa_idPrioridade;
var pesquisa_rgNotificador;
var pesquisa_idNotificador;
var pesquisa_idStatus;


// Pega valores do formulário e faz a pesquisa
function PesquisarNotasForm() {
    pesquisa_idFrota = $("#id_frota_fk").val();
    pesquisa_idTrem = $("#id_trem_fk").val();
    pesquisa_idCarro = $("#id_carro_fk").val();
    pesquisa_cdSap = $("#cd_sap").val();
    pesquisa_idSistema = $("#id_sistema_fk").val();
    pesquisa_idSintoma = $("#id_sintoma_fk").val();
    pesquisa_dataInicial = $("#dt_inicial").val();
    pesquisa_dataFinal = $("#dt_final").val();
    pesquisa_idPrioridade = $("#id_prioridade_fk").val();
    pesquisa_rgNotificador = $("#rg_notificador").val();
    pesquisa_idStatus = $("#id_status_usuario").val();
    pesquisa_idNotificador = $("#id_notificador_fk").val();
    PesquisarNotas();
}


// Apenas faz a pesquisa com os últimos filtros selecionados pelo usuário
function PesquisarNotasRefresh() {
    PesquisarNotas();
}

// Função que efetiva a pesquisa, deve ser chamada pelas funções PesquisarNotasForm ou PesquisarNotasRefresh
function PesquisarNotas() {
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
    if (pesquisa_idSistema) {
        if (queryUrl) {
            queryUrl += "&";
        }
        queryUrl += "idSistema=" + pesquisa_idSistema;
    }
    if (pesquisa_idSintoma) {
        if (queryUrl) {
            queryUrl += "&";
        }
        queryUrl += "idSintoma=" + pesquisa_idSintoma;
    }
    if (pesquisa_dataInicial) {
        if (queryUrl) {
            queryUrl += "&";
        }

        var parts1 = pesquisa_dataInicial.split('/');
        var dtIni = parts1[2] + "-" + parts1[1] + "-" + parts1[0] + " 00:00:00";

        queryUrl += "dataInicial=" + dtIni;

    }
    if (pesquisa_dataFinal) {
        if (queryUrl) {
            queryUrl += "&";
        }

        var parts2 = pesquisa_dataFinal.split('/');
        var dtFin = parts2[2] + "-" + parts2[1] + "-" + parts2[0] + " 23:59:59";

        queryUrl += "dataFinal=" + dtFin;
    }
    if (pesquisa_idPrioridade) {
        if (queryUrl) {
            queryUrl += "&";
        }
        queryUrl += "idPrioridade=" + pesquisa_idPrioridade;
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
        //tblPesquisar = $('#tblPesquisaNotas').DataTable(); tblPesquisar.destroy();
        tblPesquisar.ajax.url('/MR/PesquisarNotaMC/GetData?' + queryUrl).load();
    } else {
        carregarDataTable(queryUrl);
    }


}

function carregarDataTable(qrUrl) {
    tblPesquisar = $('#tblPesquisaNotas').DataTable({
        "ajax": '/MR/PesquisarNotaMC/GetData?' + qrUrl,
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                "render": function (data, type, row) {
                    var buttons = '<i class="material-icons btn_details" data-id="' + row[0] + '" style="cursor:pointer;display:inline">search</i>' +
                        '<i class="material-icons btn_edit" data-id="' + row[0] + '" style="cursor:pointer;display:inline">edit</i>' +
                        '<i class="material-icons btn_cancel" data-id="' + row[0] + '" style="cursor:pointer;display:inline">close</i>' +
                        '<i class="material-icons btn_train" data-id="' + row[0] + '" style="cursor:pointer;display:inline">train</i>'

                    return buttons
                },
                "targets": 11
            }
        ],
    });
}


function checkLocalInstalacao() {

    var idFrota = $("#id_frota_fk").val();
    var idTrem = $("#id_trem_fk").val();
    var idCarro = $("#id_carro_fk").val();


    if (idFrota && idTrem && idCarro) {

        $.ajax({
            method: "GET",
            url: "/MR/NotaCorretiva/LocalInstalacao?idFrota=" + idFrota + "&idTrem=" + idTrem + "&idCarro=" + idCarro,
            success: function (data) {
                if (data.length) {
                    var localInst = data[0];
                    if (localInst) {

                        //$("#id_local_instalacao_fk").val(localInst.IdLcInstalacao);
                        //$("#ds_local_instalacao").val(localInst.DsLcInstalacao);

                        $.ajax({
                            method: "GET",
                            url: "/MR/NotaCorretiva/GetSistemas?idPerfil=" + localInst.IdPerfilFk,
                            success: function (data) {

                                var html = "<option value=''></option>"

                                for (var i = 0; i < data.length; i++) {
                                    html += "<option value='" + data[i].IdGpCode + "'>" + data[i].DsGpCode + "</option>";
                                }
                                $("#id_sistema_fk").html(html);
                                $("#id_sistema_fk").val("").trigger('change');
                            },
                            error: function () {
                                alert('erro');
                            }
                        })
                    } else {
                        $("#id_sistema_fk").val("").trigger('change');
                    }
                } else {
                    $("#id_sistema_fk").val("").trigger('change');
                    $("#id_sistema_fk").html("<option value=''></option>");
                }
            },
            error: function () {
                alert('erro');
            }
        })
    } else {

        $("#id_sistema_fk").val("").trigger('change');
        $("#id_sistema_fk").html("<option value=''></option>");

    }
}

$("#id_sistema_fk").on("change", function () {
    var idSistema = $("#id_sistema_fk").val();
    if (idSistema) {
        $.ajax({
            method: "GET",
            url: "/MR/NotaCorretiva/GetSintomas?idSistema=" + idSistema,
            success: function (data) {

                var html = "<option value=''></option>"

                for (var i = 0; i < data.length; i++) {
                    html += "<option value='" + data[i].IdCode + "'>" + data[i].DsCode + "</option>";
                }

                $("#id_sintoma_fk").html(html);

                $("#id_sintoma_fk").val("").trigger('change');

            },
            error: function () {
                alert('erro');
            }
        })
    } else {
        $("#id_sintoma_fk").val("").trigger('change');
        $("#id_sintoma_fk").html("<option value=''></option>");
    }
})

$.ajax({
    method: "GET",
    url: "/MR/NotaCorretiva/GetPrioridades",
    success: function (data) {
        var html = "<option value=''></option>"

        for (var i = 0; i < data.length; i++) {
            html += "<option value='" + data[i].IdPrioridade + "'>" + data[i].DsPrioridade + "</option>";
        }

        $("#id_prioridade_fk").html(html);

        $("#id_prioridade_fk").val("").trigger('change');

    },
    error: function () {
        alert('erro');
    }
})

$.ajax({
    method: "GET",
    url: "/MR/PesquisarNotaMC/GetStatusUsuario",
    success: function (data) {
        $("#id_status_usuario").html("");

        var html = "<option value=''></option>";
        for (var i = 0; i < data.length; i++) {
            html += "<option value='" + data[i].IdStUsuario + "'>" + data[i].DsStUsuario + "</option>";
        }
        $("#id_status_usuario").html(html);
        $("#id_status_usuario").val("").trigger("");
    },
    error: function (a, b, c) {
        console.log(a);
        console.log(b);
        console.log(c);
        console.log('bruno');
        alert('erro');
    }
});

$(document).on("click", ".btn_details", function (e) {
    var idNota = $(this).attr("data-id");
    window.open("/MR/NotaCorretiva/Consultar/" + idNota, "_blank");
});
$(document).on("click", ".btn_edit", function (e) {
    var idNota = $(this).attr("data-id");
    window.open("/MR/NotaCorretiva/Cadastro/" + idNota, "_blank");
});

$("#btn_limpar_filtro").on("click", function () {
    window.location.reload();
});


$(document).on("click", ".btn_cancel", function () {
    var tr = $(this).closest("tr")[0];
    console.log(tblPesquisar.row(tr).data());
    var valores = tblPesquisar.row(tr).data();
    var idNota = valores[0];
    var cdSap = valores[1];
    modalCancelarNota(idNota, cdSap);

});

/*$('#tblPesquisaNotas tbody').on('click', 'tr', function () {
    console.log(tblPesquisar.row(this).data());
});*/

$("#btConfirmCancelamento").on("click", function () {
    var id = $("#id_cancel_nota").val();
    var cdsap = $("#cdsap_cancel_nota").val();
    var motivo = $("#motivoCancelamento").val();

    if (!id) {
        alert("Cód não informado");
        return false;
    }
    if (!motivo) {
        alert("Informe o motivo do cancelamento");
        return false;
    }


    var confirmar = confirm("Confirma o cancelamento da Nota " + cdsap + "?");

    if (confirmar) {
        $.ajax({
            method: "GET",
            url: "/MR/PesquisarNotaMC/Cancelar?id=" + id + "&motivo=" + motivo,
            success: function (data) {
                alert("Cancelamento realizado com sucesso.");
                $("#ExemploModalCentralizado").modal('hide')
                PesquisarNotasRefresh();
            },
            error: function () {
                alert('erro');
            }
        })


    } else {
        $("#ExemploModalCentralizado").modal('hide')
    }
});

function modalCancelarNota(id, cdsap) {
    $("#id_cancel_nota").val(id);
    $("#cdsap_cancel_nota").val(cdsap);
    $("#motivoCancelamento").val("")
    $("#motivoCancelamento").html("")
    $("#ExemploModalCentralizado").modal('show')
}

/*
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
});*/

$(document).ready(function () {
    carregarDataTable("");
    showModalEmpregados("modalNotificadores_container", "btnNotificador", "id_notificador_fk", "nm_notificador");
});