var modalContainer;
var tblEmpregados;
var btnShowModal;
var txtIdEmpregado;
var txtNmEmpregado;

function showModalEmpregados(_modalContainer, _btnShowModal, _txtIdEmpregado, _txtNmEmpregado) {
    modalContainer = $("#" + _modalContainer);
    btnShowModal = $("#" + _btnShowModal);
    txtIdEmpregado = $("#" + _txtIdEmpregado);
    txtNmEmpregado = $("#" + _txtNmEmpregado);

    modalContainer.load("/Util/SelecionarEmpregado", function () {
        $("#txtEmpregadosEntrada").val('');
        loadEmpregados(null);
        $('#txtEmpregadosEntrada').focus();
    });

    modalContainer.on('hidden.bs.modal', function () {
        closeModalEmpregados();
    })

    $(document).on('input', '#txtEmpregadosEntrada', function () {
        //var nome_rg = $(this).val();
        //loadEmpregados(nome_rg);
    })

    $(document).on("click", "#btnLimparEmpregado", function () {
        txtIdEmpregado.val("");
        txtNmEmpregado.val("");
        $("#modalEmpregados").modal('hide');
    });

    $(document).on('keydown', '#txtEmpregadosEntrada', function (e) {
        var code = e.keyCode || e.which;
        if (code == 13) {
            var nome_rg = $("#txtEmpregadosEntrada").val();
            loadEmpregados(nome_rg);
        }
    })

    $(document).on('click', '#btnPesquisarEmpregados', function () {
        var nome_rg = $("#txtEmpregadosEntrada").val();
        loadEmpregados(nome_rg);
    })

    $(document).on("click", "#" + btnShowModal.attr('id'), function () {
        $("#modalEmpregados").modal('show');
    })
}

function loadEmpregados(nome_rg) {
    if ($.fn.dataTable.isDataTable('#tblEmpregados')) {
        tblEmpregados = $('#tblEmpregados').DataTable();
        tblEmpregados.destroy();
    }

    if (nome_rg) {
        $('#tblEmpregados').show();

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
    } else {
        $('#tblEmpregados').hide();
    }
}

function closeModalEmpregados() {
    $("#txtEmpregadosEntrada").val('');
    loadEmpregados(null);
    $("#modalEmpregados").modal('hide');
}

function selectEmpregado(id_empregado, nm_empregado) {
    $("#" + txtIdEmpregado.attr('id')).val(id_empregado);
    $("#" + txtNmEmpregado.attr('id')).val(nm_empregado);
    closeModalEmpregados();
}