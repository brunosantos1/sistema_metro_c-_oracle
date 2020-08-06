$(document).ready(function () {
    if (location.href.indexOf('cd_sap') > -1) {
        document.getElementById("btnPesquisar").style.visibility = "hidden";
        $('#cd_nota_sap_Ref').attr("readonly", true).addClass("disabled");
    }
});

$(document).on("click", ".salvar", function () {
    var resposta = confirm("Salvar Nota?");
    if (resposta) {
        alert("Salva com sucesso!");
    }
})


$(document).on("click", ".cancelar", function () {
    var resposta = confirm("Confirma o cancelamento da Nota " + $("#id_nota").val() + "?");
    if (resposta) {
        $(function () {
            $.ajax({
                dataType: "json",
                type: "GET",
                url: "/CopesePericia/SalvarCancelar",
                data: { 'id': $("#id_nota").val() },
                success: function (dados) {
                    alert("Cancelamento realizado com sucesso");
                }
            });
        });
    }
})

$(document).on("click", ".encerrar", function () {
    var resposta = confirm("Confirma o encerramento da Nota " + $("#id_nota").val() + "?");
    if (resposta) {
        $(function () {
            $.ajax({
                dataType: "json",
                type: "GET",
                url: "/CopesePericia/SalvarEncerrarCopeseMR",
                data: { 'id': $("#id_nota").val() },
                success: function (dados) {
                    alert("Encerramento realizado com sucesso");
                }
            });
        });
    }
})


$(document).on("click", ".descaracterizar", function () {
    var resposta = confirm("Confirma a descaracterização da Nota " + $("#id_nota").val() + "?");
    if (resposta) {
        $(function () {
            $.ajax({
                dataType: "json",
                type: "GET",
                url: "/CopesePericia/SalvarDescaracterizar",
                data: { 'id': $("#id_nota").val() },
                success: function (dados) {
                    alert("Descaracterizada com sucesso!");
                }
            });
        });
    }
})


function BuscarNotaRef() {
    $(function () {
        $.ajax({
            dataType: "json",
            type: "GET",
            url: "/CopesePericia/BuscarNotaRefLcInst",
            data: { 'nr_nota_sap': $("#cd_nota_sap_Ref").val() },
            success: function (dados) {
                $("#id_nota_Ref").val(dados.IdNota);
                $("#ds_descricao_Ref").val(dados.DsDescricao);

                if (dados.LocalInstalacao != null) {
                    $("#cd_local_inst_sap_Ref").val(dados.LocalInstalacao.DsLcInstalacao);
                    $("#id_local_inst_Ref").val(dados.LocalInstalacao.IdLcInstalacao);

                    if (dados.LocalInstalacao.Linha != null) {
                        $("#nm_linha").val(dados.LocalInstalacao.Linha.NmLinha);
                        $("#id_linha").val(dados.LocalInstalacao.Linha.IdLinha);
                    }
                }
                if (dados.Empregado != null) {
                    $("#rg_notificador").val(dados.Empregado.RgEmpregado);
                    $("#id_notificador_fk").val(dados.Empregado.IdEmpregado);
                }
                if (dados.CentroTrabalho != null) {
                    $("#ds_ct_trabalho").val(dados.CentroTrabalho.DsCtTrabalho);
                    $("#id_ct_trabalho").val(dados.CentroTrabalho.IdCtTrabalho);
                }
                if (dados.CodeSintoma != null) {
                    $("#ds_breve_code_Ref").val(dados.CodeSintoma.DsCode);
                    $("#id_code_Ref").val(dados.CodeSintoma.IdCode);
                }
            }
        });
    });
}

function showEmpregados(modal, botao, idTxt, nmTxt) {
    $('#tblEmpregados').hide();
    $('#modalEmpregados').show(1);
    $('#idTxt').val(idTxt);
    $('#nmTxt').val(nmTxt);

}

function BuscaEmpregados(nome_rg) {
    if ($.fn.dataTable.isDataTable('#tblEmpregados')) {
        tblEmpregados = $('#tblEmpregados').DataTable();
        tblEmpregados.destroy();
    }

    tblEmpregados = $('#tblEmpregados').DataTable({
        "ajax": {
            "dataType": "JSON",
            "type": "POST",
            "url": "/MR/NotaInspecao/GetEmpregados",
            "data": {
                "nome_rg": nome_rg
            },
            "error": function (xhr, error, code) {
                //alert(xhr);
                //alert(code);
            }
        },
        "lengthChange": false,
        "bFilter": false,
        "bInfo": false,
        "language": {
            "paginate": {
                "previous": "Anterior",
                "next": "Próxima",
                "first": "Primeira",
                "last": "Última"
            },
            "emptyTable": "",
            "zeroRecords": "Nenhum registro encontrado",
            "scrollX": true
        },
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
        ],
        "pageLength": 6,
        "autoWidth": false
    });

    tblEmpregados.on('click', 'tr', function () {
        var data = tblEmpregados.row(this).data();
        var id_empregado = data[0];
        var nm_empregado = data[2];

        if (id_empregado) {
            selectEmpregado(id_empregado, nm_empregado);

            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
            }
            else {
                tblEmpregados.$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
            }
        }
    });

    $('#tblEmpregados').show();
}
$('.close').click(function () {

    closeModalEmpregados();

});

$(document).on('click', '#btnPesquisarEmpregados', function () {
    var nome_rg = $("#txtEmpregadosEntrada").val();
    BuscaEmpregados(nome_rg);
})


function selectEmpregado(id_empregado, nm_empregado) {
    $("#txtEmpregadosEntrada").val()
    $("#" + $('#idTxt').val()).val(id_empregado);
    $("#" + $('#nmTxt').val()).val(nm_empregado);
    closeModalEmpregados();
}

function closeModalEmpregados() {
    $("#txtEmpregadosEntrada").val('');
    $("#modalEmpregados").hide(1);
}