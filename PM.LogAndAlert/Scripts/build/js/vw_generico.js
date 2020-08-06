/***
* Abrir popup de visualização de mensagens
***/
$('#alerta-modal').on('show.bs.modal', function (e) {
    var $modal = $(this);
    var RegistroId = $(e.relatedTarget).data('id'); //get data-id attribute of the clicked element
    $.ajax({
        cache: false,
        type: 'GET',
        url: '/home/MostrarAlerta?ID=' + RegistroId,
        success: function (data) {
            //$modal.find('.edit-content').html(data);
            $modal.html(data);
        }
    });
    //$(e.currentTarget).find('input[name="bookId"]').val(bookId);    //populate the textbox
});

/***************************************************************************************************************************************************
* INICIO - FUNCOES GENERICAS
***************************************************************************************************************************************************/
function fnCarregaAplicacao(objPai, objFilho) {
    var ddlAplicacao = $('#' + objFilho);
    ddlAplicacao.empty();
    var URL = '/aplicacaotipolog/getaplicacao?iD=' + objPai.value;
    if (objPai.value == '0') {
        ddlAplicacao.append($('<option></option>').val('0').text('*** SELECIONE UMA EMPRESA ***'));
        fnCarregaTipoLog(document.getElementById('ddlIdAplicacao'), 'tbTipoLog')
    }
    else {

        $.ajax({
            type: 'GET',
            headers: { 'Accept': 'application/json', 'Content-Type': 'text/plain' },
            dataType: 'json',
            url: URL,
            success: function (data) {
                if (!data) { return; }
                ddlAplicacao.append($('<option></option>').val('0').text('*** SELECIONE ***'));
                $.each(data, function (index, item) {
                    ddlAplicacao.append($('<option></option>').val(item.IdAplicacao).text(item.DsDescricao));
                });
            },
            error: function (e) {
                ddlAplicacao.append($('<option></option>').val('0').text('*** SELECIONE UMA EMPRESA ***'));
            }
        });
    }
};

function fnCarregaUsuario(objPai, objFilho) {
    var ddlFilho = $('#' + objFilho);
    ddlFilho.empty();
    var URL = '/usuario/getusuario?iD=' + objPai.value;
    if (objPai.value == '0') {
        ddlFilho.append($('<option></option>').val('0').text('*** SELECIONE UMA APLICACAO ***'));
        fnCarregaTipoLog(document.getElementById('ddlIdAplicacao'), 'tbTipoLog')
    }
    else {

        $.ajax({
            type: 'GET',
            headers: { 'Accept': 'application/json', 'Content-Type': 'text/plain' },
            dataType: 'json',
            url: URL,
            success: function (data) {
                if (!data) { return; }
                ddlFilho.append($('<option></option>').val('0').text('*** SELECIONE ***'));
                $.each(data, function (index, item) {
                    ddlFilho.append($('<option></option>').val(item.IdAplicacao).text(item.DsDescricao));
                });
            },
            error: function (e) {
                ddlFilho.append($('<option></option>').val('0').text('*** SELECIONE UMA APLICACAO ***'));
            }
        });
    }
};

function fnCarregaModulo(objPai, objFilho) {
    var ddlFilho = $('#' + objFilho);
    ddlFilho.empty();
    var URL = '/aplicacaomodulo/getmodulo?iD=' + objPai.value;
    if (objPai.value == '0') {
        ddlFilho.append($('<option></option>').val('0').text('*** SELECIONE UMA APLICACAO ***'));
        fnCarregaTipoLog(document.getElementById('ddlIdAplicacao'), 'tbTipoLog')
    }
    else {

        $.ajax({
            type: 'GET',
            headers: { 'Accept': 'application/json', 'Content-Type': 'text/plain' },
            dataType: 'json',
            url: URL,
            success: function (data) {
                if (!data) { return; }
                ddlFilho.append($('<option></option>').val('0').text('*** SELECIONE ***'));
                $.each(data, function (index, item) {
                    ddlFilho.append($('<option></option>').val(item.IdAplicacao).text(item.DsDescricao));
                });
            },
            error: function (e) {
                ddlFilho.append($('<option></option>').val('0').text('*** SELECIONE UMA APLICACAO ***'));
            }
        });
    }
};

function fnCarregaDataTable_TipoLog(objPai, objFilho) {

    if (objPai.value == '0') {
        LoadDataTable(objFilho, '/aplicacaoTipoLog/GetTipoLog?IdAplicacao=-999');
    }
    else {
        LoadDataTable(objFilho, '/aplicacaoTipoLog/GetTipoLog?IdAplicacao=' + objPai.value);
    }
};

function fnCarregaDataTable_Aplicacao(objPai, objFilho) {
    if (objPai.value == '0') {
        LoadDataTable(objFilho, '/aplicacao/GetAplicacao?IdEmpresa=-999');
    }
    else {
        LoadDataTable(objFilho, '/aplicacao/GetAplicacao?IdEmpresa=' + objPai.value);
    }
};

function LoadDataTable(DataTable, sURL) {
    //alert('Objeto DataTable : ' + document.getElementById(DataTable));
    //alert('Objeto sURL : ' + sURL);

    var dtapp = $('#' + DataTable).DataTable({
        "language": {
            "lengthMenu": "Exibe _MENU_ Registros por página",
            "search": "Procurar",
            "paginate": { "previous": "Retorna", "next": "Avança" },
            "zeroRecords": "Nada foi encontrado",
            "info": "Exibindo página _PAGE_ de _PAGES_",
            "infoEmpty": "Sem registros",
            "infoFiltered": "(filtrado de _MAX_ regitros totais)"
        },
        "destroy": true,
        "processing": true, // mostrar a progress bar
        //"serverSide": true, // processamento no servidor
        "filter": true, // habilita o filtro(search box)
        //"lengthMenu": [ [3, 5, 10, 25, 50, -1], [3, 5, 10, 25, 50, "Todos"] ],
        //"pageLength": 3, // define o tamanho da página
        "ajax": { "url": sURL, "type": "GET", "dataType": "json" }
    });

    /* Esta aqui como exemplo, neste eu chamo a funcao [TableChildRowFormat], que inseri uma tabela dentro da linha onde foi efetuado o click*/
    if (DataTable == 'tbConsulta_Acessos_EXEMPLO') {
        $('#' + DataTable + ' tbody').on('click', 'tr', function () {
            var tr = $(this).closest('tr');
            var row = dtapp.row(tr);
            if (row.child.isShown()) {
                // This row is already open - close it
                row.child.hide();
                tr.removeClass('shown');
            }
            else {
                // Open this row
                row.child(TableChildRowFormat(row.data())).show();
                tr.addClass('shown');
            }
        });
    }
};

function TableChildRowFormat(d) {
    alert(d);
    // `d` is the original data object for the row
    return '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
        '<tr>' +
        '<td>Full name:</td>' +
        '<td> d.name </td>' +
        '</tr>' +
        '<tr>' +
        '<td>Extension number:</td>' +
        '<td> d.extn </td>' +
        '</tr>' +
        '<tr>' +
        '<td>Extra info:</td>' +
        '<td>And any further details here (images etc)...</td>' +
        '</tr>' +
        '</table>';
}

/***************************************************************************************************************************************************
* TERMINO - FUNCOES GENERICAS
***************************************************************************************************************************************************/