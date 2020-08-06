var tblDocumentosVinculados = null;
var formStatus = "";


if (vwAction == "Consultar") {
    $("input").prop("disabled","disabled");
    $("select").prop("disabled", "disabled");
    $("input[type='checkbox']").prop("disabled", "disabled");
    $("textarea").prop("disabled", "disabled");
}

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
        "url": "/MR/NotaMd/GetByFrotaTremCarro?idFrota=" + idfrota + "&idTrem=" + idtrem + "&idCarro=" + idcarro,
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
                    $("#btn_salvar_md").prop("disabled", false);
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
    $("#btn_salvar_md").prop("disabled", true);
    event.preventDefault();
    return false;
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
            url: "/MR/NotaMd/Cancelar?id=" + id + "&motivo=" + motivo,
            success: function (data) {
                alert("Nota cancelada com sucesso");
                $("#ExemploModalCentralizado").modal('hide')
                //PesquisarNotasRefresh();
            },
            error: function () {
                alert('erro');
            }
        })
    } else {
        $("#ExemploModalCentralizado").modal('hide')
    }
});

$(document).on('click', '.btn_edit', function () {
    var id = $(this).data('id');
    window.open('/MR/NotaMd/Cadastro/' + id, '_blank');
})
$(document).on('click', '.btn_details', function () {
    var id = $(this).data('id');
    window.open('/MR/NotaMd/Consultar/' + id, '_blank');
})
$(document).on('click', '.btn_train', function () {
    var id = $(this).data('id');
    window.open('/MaterialRodante/PesquisarEntregaTrem', '_blank');
})
$(document).on('click', '.btn_cancel', function () {
    var id = $(this).data('id');
    modalCancelarNota(id);
})

function modalCancelarNota(id) {
    $("#id_cancel_nota").val(id);
    $("#motivoCancelamento").val("")
    $("#motivoCancelamento").html("")
    $("#ExemploModalCentralizado").modal('show')
}

function checkAbertasPendentes() {
    if (vwAction == "Consultar") {
        return false;
    }
    var idFrota = $("#id_frota_fk").val();
    var idTrem = $("#id_trem_fk").val();

    if (idFrota && idTrem) {
        loadAbertasPendentes(idFrota, idTrem);
    } else {
        if (tblDocumentosVinculados!=null && $.fn.dataTable.isDataTable('#tblNotasAbertasPendentes')) {
            tblDocumentosVinculados.clear().draw();
        }
    }
}

function checkLocalInstalacao() {

    var idFrota = $("#id_frota_fk").val();
    var idTrem = $("#id_trem_fk").val();
    var idCarro = $("#id_carro_fk").val();
    var idSistema = $("#id_sistema_fk").val();
    var idComplemento = $("#id_complemento_fk").val();
    var idPosicao = $("#id_posicao_fk").val();

    if (idFrota && idTrem && idCarro && idSistema && idComplemento && idPosicao) {

        $.ajax({
            method: "GET",
            url: "/MR/NotaMd/LocalInstalacao?idFrota=" + idFrota + "&idTrem=" + idTrem + "&idCarro=" + idCarro + "&idSistema=" + idSistema + "&idComplemento=" + idComplemento + "&idPosicao=" + idPosicao,
            success: function (data) {
                if (data.length) {
                    var localInst = data[0];
                    if (localInst) {

                        $("#id_local_instalacao_fk").val(localInst.IdLcInstalacao);
                        $("#ds_local_instalacao").val(localInst.DsLcInstalacao);

                        //$.ajax({
                        //    method: "GET",
                        //    url: "/MR/NotaMd/GetSistemas?idPerfil=" + localInst.IdPerfilFk,
                        //    success: function (data) {
                                
                        //        var html = "<option value=''></option>"

                        //        for (var i = 0; i < data.length; i++) {
                        //            html += "<option value='" + data[i].IdGpCode + "'>" + data[i].DsGpCode + "</option>";
                        //        }
                                
                        //        var idsistema = $("#hidden_id_sistema_fk").val();
                                
                        //        $("#id_sistema_fk").html(html);
                        //        if (idsistema) {
                        //            $("#id_sistema_fk").val(idsistema).trigger('change');
                        //        } else {
                        //            $("#id_sistema_fk").val("").trigger('change');
                        //        }
                        //    },
                        //    error: function () {
                        //        alert('erro');
                        //    }
                        //})
                    } else {
                        //debugger;
                        //$("#hidden_id_sistema_fk").val("");
                        //$("#id_sistema_fk").val("").trigger('change');
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
    url: "/MR/NotaMd/Frotas",
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

$.ajax({
    method: "GET",
    url: "/MR/NotaMd/Complementos",
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
            $("#id_complemento_fk").val(idcomplemento);
        }
    },
    error: function () {
        alert('erro');
    }
})

$.ajax({
    method: "GET",
    url: "/MR/NotaMd/Posicoes",
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
            $("#id_posicao_fk").val(idposicao);
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
            url: "/MR/NotaMd/Trens?id=" + idFrota,
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
        });
        $.ajax({
            method: "GET",
            url: "/MR/NotaMd/Sistemas?id=" + idFrota,
            success: function (data) {
                var html = "<option value=''></option>";
                for (var i = 0; i < data.length; i++) {
                    html += "<option value='" + data[i].IdSistema + "'>" + data[i].NmSistema + "</option>";
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
        });
    } else {
        $("#hidden_id_trem_fk").val("");
        $("#id_trem_fk").val("").trigger("change");
        $("#id_trem_fk").html("<option value=''></option>");

        $("#hidden_id_sistema_fk").val("");
        $("#id_sistema_fk").val("").trigger("change");
        $("#id_sistema_fk").html("<option value=''></option>");
    }
    checkLocalInstalacao();
});

$("#id_trem_fk").on("change", function () {
    var idTrem = $("#id_trem_fk").val();
    
    if (idTrem) {
        $.ajax({
            method: "GET",
            url: "/MR/NotaMd/Carros?id=" + idTrem,
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
                checkAbertasPendentes();
            },
            error: function () {
                alert('erro');
            }
        });
        $.ajax({
            method: "GET",
            url: "/MR/NotaMd/LinhaByTrem?idTrem=" + idTrem,
            success: function (data) {
                if (data && data.IdLinha) {
                    $("#id_linha_fk").val(data.IdLinha).trigger('change');
                    $("#hidden_id_linha_fk").val(data.IdLinha);
                }
            },
            error: function () {
                alert('erro');
            }
        })

        
    } else {
        $("#hidden_id_carro_fk").val("");
        $("#id_carro_fk").val("").trigger("change");
        $("#id_carro_fk").html("<option value=''></option>");

        $("#hidden_id_linha_fk").val("");
        $("#id_linha_fk").val("").trigger("change");
    }
    checkLocalInstalacao();
});

$("#id_carro_fk").on("change", function () {
    checkLocalInstalacao();
});

$("#id_sistema_fk").on("change", function () {
    checkLocalInstalacao();
});

$("#id_complemento_fk").on("change", function () {
    checkLocalInstalacao();
});

$("#id_posicao_fk").on("change", function () {
    checkLocalInstalacao();
});

//$("#id_sistema_fk").on("change", function () {
//    var idSistema = $("#id_sistema_fk").val();
//    if (idSistema) {
//        $("#hidden_id_sistema_fk").val(idSistema);
//        $.ajax({
//            method: "GET",
//            url: "/MR/NotaMd/GetSintomas?idSistema=" + idSistema,
//            success: function (data) {
//                console.log(data);
//                var html = "<option value=''></option>"
//                console.log(data.length);
//                for (var i = 0; i < data.length; i++) {
//                    html += "<option value='" + data[i].IdCode + "'>" + data[i].DsCode + "</option>";
//                }
//                console.log(html)
//                var idsintoma = $("#hidden_id_sintoma_fk").val();
//                $("#id_sintoma_fk").html(html);
//                if (idsintoma) {
//                    $("#id_sintoma_fk").val(idsintoma).trigger('change');
//                } else {
//                    $("#id_sintoma_fk").val("").trigger('change');
//                }
//            },
//            error: function () {
//                alert('erro');
//            }
//        })
//    } else {
//        //debugger;
//        //$("#hidden_id_sintoma_fk").val("");
//        $("#id_sintoma_fk").val("").trigger('change');
//        $("#id_sintoma_fk").html("<option value=''></option>");
//    }
//})


//$.ajax({
//    method: "GET",
//    url: "/MR/NotaMd/GetPrioridades",
//    success: function (data) {
//        var html = "<option value=''></option>"

//        for (var i = 0; i < data.length; i++) {
//            html += "<option value='" + data[i].IdPrioridade + "'>" + data[i].DsPrioridade + "</option>";
//        }
//        var idprioridade = $("#hidden_id_prioridade_fk").val();
//        $("#id_prioridade_fk").html(html);
//        if (idprioridade) {
//            $("#id_prioridade_fk").val(idprioridade).trigger('change');
//        } else {
//            $("#id_prioridade_fk").val("").trigger('change');
//        }
//    },
//    error: function () {
//        alert('erro');
//    }
//})

$.ajax({
    method: "GET",
    url: "/MR/NotaMd/GetLinhas",
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

$("#id_linha_fk").on("change", function () {
    var idLinha = $("#id_linha_fk").val()
    if (idLinha) {
        $.ajax({
            method: "GET",
            url: "/MR/NotaMd/CentroTrabalhoByLinha?idLinha=" + idLinha,
            success: function (data) {
                if (data && data.IdCtTrabalho) {
                    $("#id_centro_trabalho_fk").val(data.IdCtTrabalho);
                    $("#ds_centro_trabalho").val(data.DsCtTrabalho);
                } else {
                    $("#id_centro_trabalho_fk").val('');
                    $("#ds_centro_trabalho").val('');
                }
            },
            error: function () {
                alert('erro');
            }
        })
    } else {
        $("#id_centro_trabalho_fk").val('');
        $("#ds_centro_trabalho").val('');
    }

})

//$("#id_sintoma_fk").on("change", function () {
//    var idSintoma = $("#id_sintoma_fk").val();

//    if (idSintoma) {
//        $("#hidden_id_sintoma_fk").val(idSintoma);
//        $.ajax({
//            method: "GET",
//            url: "/MR/NotaMd/PrioridadeBySintoma?idSintoma=" + idSintoma,
//            success: function (data) {
//                if (data && data.length && data.length > 0 && data[0].IdPrioridade) {
//                    $("#hidden_id_prioridade_fk").val(data[0].IdPrioridade);
//                    $("#id_prioridade_fk").val(data[0].IdPrioridade);
//                } else {

//                }
//            },
//            error: function () {
//                alert('erro');
//            }
//        })
//    } else {

//    }

//})
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
        tblDocumentosVinculados = $('#tblNotasAbertasPendentes').DataTable(); tblDocumentosVinculados.destroy();
    }

    tblDocumentosVinculados = $('#tblNotasAbertasPendentes').DataTable({
        "ajax": '/MR/NotaMd/GetAbertasPendentes?idFrota=' + idFrota + "&idTrem=" + idTrem,
        "scrollX": true,
        "columnDefs": [
            {
                "render": function (data, type, row) {
                    var buttons = '<i class="material-icons btn_details" data-id="' + row[0] + '" style="cursor:pointer;display:inline">search</i>' +
                        '<i class="material-icons btn_edit" data-id="' + row[0] + '" style="cursor:pointer;display:inline">edit</i>' +
                        '<i class="material-icons btn_cancel" data-id="' + row[0] + '" style="cursor:pointer;display:inline">close</i>' +
                        '<i class="material-icons btn_train" data-id="' + row[0] + '" style="cursor:pointer;display:inline">train</i>'

                    return buttons
                },
                "targets": 10
            }
        ]
    });
}
    
$("#btn_carregar_ultima").on("click", function () {
    window.location.href = "/MR/NotaMd/Cadastro?acao=carregarUltima";
});
$(document).ready(function () {
    showModalEmpregados("modalNotificadores_container", "btnNotificador", "id_notificador_fk", "nm_notificador");
    loadAbertasPendentes(0, 0);
});
