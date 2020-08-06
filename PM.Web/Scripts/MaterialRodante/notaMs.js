var tblAbertasPendentes = null;
var formStatus = "";


if (vwAction == "Consultar") {
    $("input").prop("disabled", "disabled");
    $("select").prop("disabled", "disabled");
    $("input[type='checkbox']").prop("disabled", "disabled");
    $("textarea").prop("disabled", "disabled");
    $("#btnSolicitante").prop("disabled", "disabled");
}
$("#dt_programada").on("change", function () {
    //alert($("#dt_programada").val());

    var dtProgramada = $("#dt_programada").val();
    var hrProgramada = $("hr_programada").val();
    var newDt;

    if (dtProgramada) {
        var parts1 = dtProgramada.split('/');
        newDt = parts1[2] + "-" + parts1[1] + "-" + parts1[0];// + " 00:00:00";

        if (hrProgramada) {
            newDt += " " + hrProgramada;
        }
    } else {
        newDt = "";
    }
    $("#dt_hora_programada").val(newDt);
});

$("#hr_programada").on("change", function () {
    var dtProgramada = $("#dt_programada").val();
    var hrProgramada = $("#hr_programada").val();
    var newDt;
    //debugger;
    if (dtProgramada) {
        var parts1 = dtProgramada.split('/');
        newDt = parts1[2] + "-" + parts1[1] + "-" + parts1[0];// + " 00:00:00";

        if (hrProgramada) {
            newDt += " " + hrProgramada;
        }
    } else {
        newDt = "";
    }
    $("#dt_hora_programada").val(newDt);
});
$("#target1").submit(function (event) {
    return true;
    var idfrota = $("#id_frota_fk").val();
    var idtrem = $("#id_trem_fk").val();
    var idcarro = $("#id_carro_fk").val();

    if (formStatus == "ok") {
        return true;
    }
    if (formStatus == "processing") {
        event.preventDefault();
        return false;
    }

    if (!idfrota || !idtrem || !idcarro) {
        alert("Selecione frota, trem e carro");
        event.preventDefault();
        return false;
    }



    $.ajax({
        "method": "GET",
        "url": "/MR/NotaServico/GetByFrotaTremCarro?idFrota=" + idfrota + "&idTrem=" + idtrem + "&idCarro=" + idcarro,
        "success": function (data) {
            if (data && data.total && data.total > 0) {
                var confirm1 = confirm("Já existe nota para esta Frota/Trem/Carro. Deseja continuar?");
                if (confirm1) {
                    formStatus = "ok";
                    $("#target1").submit();
                    return true;
                } else {
                    formStatus = "";
                    event.preventDefault();
                    $("#btn_salvar_mc").prop("disabled", false);
                    return false;
                }
            } else {
                formStatus = "ok";
                $("#target1").submit();
                return true;
            }
        },
        "error": function () {
            console.log("Não foi possível verificar se já existe nota para esta frota/trem/carro");
            formStatus = "ok";
            $("#target1").submit();
            return true;
        }
    });
    formStatus = "processing";
    $("#btn_salvar_mc").prop("disabled", true);
    event.preventDefault();
    return false;
});

$(document).on("click", ".btn_cancel", function () {
    var tr = $(this).closest("tr")[0];
    console.log(tblAbertasPendentes.row(tr).data());
    var valores = tblAbertasPendentes.row(tr).data();

    modalCancelarNota(valores[0]);
});


$("#btConfirmCancelamento").on("click", function () {
    var id = $("#id_cancel_nota").val();
    var motivo = $("#motivoCancelamento").val();

    if (!id) {
        alert("Cód não informado");
        return false;
    }
    if (!motivo) {
        alert("Informe o motivo do cancelamento");
        return false;
    }


    var confirmar = confirm("Tem certeza que deseja cancelar?")

    if (confirmar) {
        $.ajax({
            method: "GET",
            url: "/MR/PesquisarNotaMC/Cancelar?id=" + id + "&motivo=" + motivo,
            success: function (data) {
                alert("Nota cancelada com sucesso");
                $("#ExemploModalCentralizado").modal('hide')
                //PesquisarNotasRefresh();
                checkAbertasPendentes();
            },
            error: function () {
                alert('erro');
            }
        })


    } else {
        $("#ExemploModalCentralizado").modal('hide')
    }
});

$(document).on("click", ".btn_details", function (e) {
    var idNota = $(this).attr("data-id");
    window.open("/MR/NotaServico/Consultar/" + idNota, "_blank");
});
$(document).on("click", ".btn_edit", function (e) {
    var idNota = $(this).attr("data-id");
    window.open("/MR/NotaServico/Cadastro/" + idNota, "_blank");
});

$('.btn_train').on('click', function () {
    var id = $(this).data('id');
    window.open('/MaterialRodante/PesquisarEntregaTrem', '_blank');
})


function checkAbertasPendentes() {
    if (vwAction == "Consultar") {
        return false;
    }
    var idFrota = $("#id_frota_fk").val();
    var idTrem = $("#id_trem_fk").val();
    if (idFrota && idTrem) {
        loadAbertasPendentes(idFrota, idTrem);
    } else {
        if (tblAbertasPendentes != null && $.fn.dataTable.isDataTable('#tblNotasAbertasPendentes')) {
            tblAbertasPendentes.clear().draw();
        }
    }
}

function checkLocalInstalacao() {

    var idFrota = $("#id_frota_fk").val();
    var idTrem = $("#id_trem_fk").val();
    var idCarro = $("#id_carro_fk").val();


    if (idFrota && idTrem && idCarro) {

        $.ajax({
            method: "GET",
            url: "/MR/NotaServico/LocalInstalacao?idFrota=" + idFrota + "&idTrem=" + idTrem + "&idCarro=" + idCarro,
            success: function (data) {
                if (data.length) {
                    var localInst = data[0];
                    if (localInst) {

                        $("#local_ftc").val(localInst.IdLcInstalacao);

                        $.ajax({
                            method: "GET",
                            url: "/MR/NotaServico/GetSistemas?idPerfil=" + localInst.IdPerfilFk,
                            success: function (data) {

                                var html = "<option value=''></option>"

                                for (var i = 0; i < data.length; i++) {
                                    html += "<option value='" + data[i].IdGpCode + "'>" + data[i].DsGpCode + "</option>";
                                }

                                var idsistema = $("#hidden_id_sistema_fk").val();

                                $("#id_sistema_fk").html(html);
                                if (idsistema) {
                                    $("#id_sistema_fk").val(idsistema).trigger('change');
                                } else {
                                    $("#id_sistema_fk").val("").trigger('change');
                                }
                            },
                            error: function () {
                                alert('erro');
                            }
                        })
                    } else {
                        //debugger;
                        //$("#hidden_id_sistema_fk").val("");
                        $("#id_sistema_fk").html("<option value=''></option>");
                        $("#id_sistema_fk").val("").trigger('change');
                        $("#local_ftc").val("");

                    }
                } else {

                    $("#local_ftc").val("");

                    //debugger;
                    //$("#hidden_id_sistema_fk").val("");
                    $("#id_sistema_fk").html("<option value=''></option>");
                    $("#id_sistema_fk").val("").trigger('change');
                }
            },
            error: function () {
                alert('erro');
            }
        })
    } else {
        //debugger;
        //$("#hidden_id_sistema_fk").val("");
        $("#id_sistema_fk").html("<option value=''></option>");
        $("#id_sistema_fk").val("").trigger('change');

        $("#local_ftc").val("");

    }
}

$("#id_posicao_fk").on("change", function () {
    checkLocalInstalacao2();
});

function checkLocalInstalacao2() {

    var idFrota = $("#id_frota_fk").val();
    var idTrem = $("#id_trem_fk").val();
    var idCarro = $("#id_carro_fk").val();
    var idSistema = $("#id_sistema_fk").val();
    var idComplemento = $("#id_complemento_fk").val();
    var idPosicao = $("#id_posicao_fk").val();



    if (idFrota && idTrem && idCarro && idSistema) {
        var urlPath = "/MR/NotaServico/LocalInstalacaoMS?idFrota=" + idFrota + "&idTrem=" + idTrem + "&idCarro=" + idCarro + "&idSistema=" + idSistema;

        if (idComplemento) {
            urlPath += "&idComplemento=" + idComplemento;
        }

        if (idPosicao) {
            urlPath += "&idPosicao=" + idPosicao;
        }

        $.ajax({
            method: "GET",
            url: urlPath,
            success: function (data) {
                if (data.length) {
                    var localInst = data[0];
                    if (localInst) {

                        $("#id_local_instalacao_fk").val(localInst.IdLcInstalacao);
                        $("#ds_local_instalacao").val(localInst.DsLcInstalacao);


                    } else {
                        //debugger;
                        //$("#hidden_id_sistema_fk").val("");

                        $("#id_local_instalacao_fk").val("").trigger('change');
                        $("#ds_local_instalacao").val("");
                    }
                } else {

                    $("#id_local_instalacao_fk").val("");
                    $("#ds_local_instalacao").val("");
                    //debugger;
                    //$("#hidden_id_sistema_fk").val("");
                    //$("#id_sistema_fk").val("").trigger('change');
                    //$("#id_sistema_fk").html("<option value=''></option>");
                }
            },
            error: function () {
                alert('erro');
            }
        })
    } else {
        //debugger;
        //$("#hidden_id_sistema_fk").val("");
        //$("#id_sistema_fk").val("").trigger('change');
        //$("#id_sistema_fk").html("<option value=''></option>");

        $("#id_local_instalacao_fk").val("");
        $("#ds_local_instalacao").val("");
    }
}

$.ajax({
    method: "GET",
    url: "/MR/NotaServico/Frotas",
    success: function (data) {
        console.log(data);
        var html = "<option value=''></option>"
        console.log(data.length);

        for (var i = 0; i < data.length; i++) {
            html += "<option value='" + data[i].IdFrota + "'>" + data[i].NmFrota + "</option>";
        }
        console.log(html)
        var idfrota = $("#hidden_id_frota_fk").val();
        $("#id_frota_fk").html(html);
        if (idfrota) {
            $("#id_frota_fk").val(idfrota).trigger('change');
        } else {
            $("#id_frota_fk").val(idfrota);
        }
    },
    error: function () {
        alert('erro');
    }
})


$("#id_frota_fk").on("change", function () {
    var idFrota = $("#id_frota_fk").val();

    checkAbertasPendentes();
    if (idFrota) {
        $.ajax({
            method: "GET",
            url: "/MR/NotaServico/Trens?id=" + idFrota,
            success: function (data) {
                var html = "<option value=''></option>";
                for (var i = 0; i < data.length; i++) {
                    html += "<option value='" + data[i].IdTrem + "'>" + data[i].NmTrem + "</option>";
                }
                var idtrem = $("#hidden_id_trem_fk").val();
                $("#id_trem_fk").html(html);
                if (idtrem) {
                    $("#id_trem_fk").val(idtrem).trigger('change');
                } else {
                    $("#id_trem_fk").val("").trigger('change');
                }
            },
            error: function () {
                alert('erro');
            }
        })
    } else {
        $("#hidden_id_trem_fk").val("");
        $("#id_trem_fk").val("").trigger("change");
        $("#id_trem_fk").html("<option value=''></option>");
    }
    checkLocalInstalacao();
    checkLocalInstalacao2();
});




$("#id_trem_fk").on("change", function () {
    var idTrem = $("#id_trem_fk").val();


    if (idTrem) {
        $.ajax({
            method: "GET",
            url: "/MR/NotaServico/Carros?id=" + idTrem,
            success: function (data) {
                console.log(data);
                var html = "<option value=''></option>"
                console.log(data.length);
                for (var i = 0; i < data.length; i++) {
                    html += "<option value='" + data[i].IdCarro + "'>" + data[i].NmCarro + "</option>";
                }
                console.log(html)
                var idcarro = $("#hidden_id_carro_fk").val();
                $("#id_carro_fk").html(html);
                if (idcarro) {
                    $("#id_carro_fk").val(idcarro).trigger('change');
                } else {
                    $("#id_carro_fk").val("").trigger('change');
                }
            },
            error: function () {
                alert('erro');
            }
        });
        /*$.ajax({
            method: "GET",
            url: "/MR/NotaCorretiva/LinhaByTrem?idTrem=" + idTrem,
            success: function (data) {
                if (data && data.IdLinha) {
                    $("#id_linha_fk").val(data.IdLinha).trigger('change');
                    $("#hidden_id_linha_fk").val(data.IdLinha);
                }
            },
            error: function () {
                alert('erro');
            }
        })*/


    } else {
        $("#hidden_id_carro_fk").val("");
        $("#id_carro_fk").val("").trigger("change");
        $("#id_carro_fk").html("<option value=''></option>");

        $("#hidden_id_linha_fk").val("");
        $("#id_linha_fk").val("").trigger("change");
    }
    checkAbertasPendentes();
    checkLocalInstalacao();
    checkLocalInstalacao2();
});

$("#id_carro_fk").on("change", function () {
    checkLocalInstalacao();
    checkLocalInstalacao2();
});

$("#id_sistema_fk").on("change", function () {
    var idSistema = $("#id_sistema_fk").val();

    checkLocalInstalacao2();

    if (idSistema) {
        $("#hidden_id_sistema_fk").val(idSistema);
        $.ajax({
            method: "GET",
            url: "/MR/NotaServico/GetComplementosBySistema?idSistema=" + idSistema,
            success: function (data) {
                console.log(data);
                var html = "<option value=''></option>"
                console.log(data.length);
                for (var i = 0; i < data.length; i++) {
                    html += "<option value='" + data[i].IdComplemento + "'>" + data[i].DsComplemento + "</option>";
                }
                console.log(html)
                var idcomplemento = $("#hidden_id_complemento_fk").val();
                $("#id_complemento_fk").html(html);
                if (idcomplemento) {
                    $("#id_complemento_fk").val(idcomplemento).trigger('change');
                } else {
                    $("#id_complemento_fk").val("").trigger('change');
                }
            },
            error: function () {
                alert('erro');
            }
        })
    } else {
        //debugger;
        //$("#hidden_id_sintoma_fk").val("");
        $("#id_complemento_fk").val("").trigger('change');
        $("#id_complemento_fk").html("<option value=''></option>");
    }
})


$("#id_complemento_fk").on("change", function () {
    var idComplemento = $("#id_complemento_fk").val();

    checkLocalInstalacao2();

    if (idComplemento) {
        $("#hidden_id_complemento_fk").val(idComplemento);
        $.ajax({
            method: "GET",
            url: "/MR/NotaServico/GetPosicoesByComplemento?idComplemento=" + idComplemento,
            success: function (data) {
                console.log(data);
                var html = "<option value=''></option>"
                console.log(data.length);
                for (var i = 0; i < data.length; i++) {
                    html += "<option value='" + data[i].IdPosicao + "'>" + data[i].DsPosicao + "</option>";
                }
                console.log(html)
                var idposicao = $("#hidden_id_posicao_fk").val();
                $("#id_posicao_fk").html(html);
                if (idposicao) {
                    $("#id_posicao_fk").val(idposicao).trigger('change');
                } else {
                    $("#id_posicao_fk").val("").trigger('change');
                }
            },
            error: function () {
                alert('erro');
            }
        })
    } else {
        //debugger;
        //$("#hidden_id_sintoma_fk").val("");
        $("#id_posicao_fk").val("").trigger('change');
        $("#id_posicao_fk").html("<option value=''></option>");
    }
})

$.ajax({
    method: "GET",
    url: "/MR/NotaServico/GetLinhas",
    success: function (data) {
        var html = "<option value=''></option>"
        for (var i = 0; i < data.length; i++) {
            html += "<option value='" + data[i].IdLinha + "'>" + data[i].NmLinha + "</option>";
        }
        var idlinha = $("#hidden_id_linha_fk").val();
        $("#id_linha_fk").html(html);
        if (idlinha) {
            $("#id_linha_fk").val(idlinha).trigger('change');
        } else {
            $("#id_linha_fk").val("").trigger('change');
        }
    },
    error: function () {
        alert('erro');
    }
})

$.ajax({
    method: "GET",
    url: "/MR/NotaServico/GetCentroTrabalho",
    success: function (data) {
        var html = "<option value=''></option>"
        for (var i = 0; i < data.length; i++) {
            html += "<option value='" + data[i].IdCtTrabalho + "'>" + data[i].DsCtTrabalho + "</option>";
        }
        var idcentrotrabalho = $("#hidden_id_centro_trabalho_fk").val();
        $("#id_centro_trabalho_fk").html(html);
        if (idcentrotrabalho) {
            $("#id_centro_trabalho_fk").val(idcentrotrabalho).trigger('change');
        } else {
            $("#id_centro_trabalho_fk").val("").trigger('change');
        }
    },
    error: function () {
        alert('erro');
    }
})

$.ajax({
    method: "GET",
    url: "/MR/NotaServico/GetTipoServico",
    success: function (data) {
        var html = "<option value=''></option>"
        for (var i = 0; i < data.length; i++) {
            html += "<option value='" + data[i].IdCode + "'>" + data[i].DsCode + "</option>";
        }
        var idtpserv = $("#hidden_id_code_tp_servico_fk").val();
        $("#id_code_tp_servico_fk").html(html);
        if (idtpserv) {
            $("#id_code_tp_servico_fk").val(idtpserv).trigger('change');
        } else {
            $("#id_code_tp_servico_fk").val("").trigger('change');
        }
    },
    error: function () {
        alert('erro');
    }
})
/*
$.ajax({
    method: "GET",
    url: "/MR/NotaCorretiva/GetCentroTrabalho",
    success: function (data) {
        console.log(data);
        var html = "<option value=''></option>"
        console.log(data.length);

        for (var i = 0; i < data.length; i++) {
            html += "<option value='" + data[i].IdCtTrabalho + "'>" + data[i].DsCtTrabalho + "</option>";
        }
        console.log(html)
        $("#selectCentroTrabalho").html(html);
    },
    error: function () {
        alert('erro');
    }
})
*/


function loadAbertasPendentes(idFrota, idTrem) {

    if (vwAction == "Consultar") {
        return false;
    }

    if ($.fn.dataTable.isDataTable('#tblNotasAbertasPendentes')) {
        //tblAbertasPendentes = $('#tblNotasAbertasPendentes').DataTable(); tblAbertasPendentes.destroy();
        tblAbertasPendentes.ajax.url('/MR/NotaServico/GetAbertasPendentes?idFrota=' + idFrota + "&idTrem=" + idTrem).load();

    } else {
        tblAbertasPendentes = $('#tblNotasAbertasPendentes').DataTable({
            "ajax": '/MR/NotaServico/GetAbertasPendentes?idFrota=' + idFrota + "&idTrem=" + idTrem,
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
            ]
        });
    }
}




$("#btn_carregar_ultima").on("click", function () {
    window.location.href = "/MR/NotaServico/Cadastro?acao=carregarUltima";
});




function modalCancelarNota(id) {
    $("#id_cancel_nota").val(id);
    $("#motivoCancelamento").val("")
    $("#motivoCancelamento").html("")
    $("#ExemploModalCentralizado").modal('show')
}




$(document).ready(function () {
    showModalEmpregados("modalSolicitante_container", "btnSolicitante", "id_solicitante_fk", "nm_solicitante");
    loadAbertasPendentes(0, 0);
});

$('#dt_programada').datepicker({
    changeMonth: true,
    changeYear: true,
    format: 'dd/mm/yyyy',
    locale: 'pt-br',
    uiLibrary: 'bootstrap4',
});


$('#hr_programada').timepicker({
    uiLibrary: 'bootstrap4'
});