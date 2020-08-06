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
});
/***************************************************************************************************************************************************
* INICIO - FUNCOES GENERICAS
***************************************************************************************************************************************************/

// Função responsavel a limpar um objeto do Tipo Table, usado quando alguma opção de combo for alterada apos aplicar filtro
function fnLimparDataTable(objTable) {
    $('#' + objTable +' tbody').empty();    
}
function fnLimparCombo(objCombo) {
    $('#' + objCombo).empty();    
    $('#' + objCombo).append($('<option></option>').val('0').text('*** SELECIONE ***'));
}
// função responsavel por popular combos, Pai e Filho. 
// É passado o objeto Pai no qual é pego valor selecionado e a URL Ajax que sera completada com o id selecionado do pai. 
// para poder popular objeto filho
function fnCarregaCombo(objPai, objFilho, objURL) {    
    var ddlFilho = $('#' + objFilho);
    ddlFilho.empty();    
    var URL = objURL + objPai.value;
    //alert('url : ' + URL);  
    if (objPai.value == '0') { ddlFilho.append($('<option></option>').val('0').text('*** SELECIONE ***')); }
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
                    ddlFilho.append($('<option></option>').val(item.Value).text(item.Text));
                });
            },
            error: function (e) { ddlFilho.append($('<option></option>').val('0').text('*** SELECIONE Error***'));
            }
        });
    }
};
//
function getParameterByName(name) {
    // Exemplo : alert(getParameterByName('idRegistro'));
    // Retornar o valor do parametro idRegistro da atual URL, caso nao tenha valor ou nao exista a propriedade retorna NULL
    var match = RegExp('[?&]' + name + '=([^&]*)').exec(window.location.search);
    return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
}
// Carrega objeto DataTable, com dados provenientes da URL (ajax) informada
function LoadDataTable(DataTable, sURL) {
    //alert('LoadDataTable : ' + sURL);
    var dtapp = $('#' + DataTable).DataTable({
        "destroy"         : true
        , "processing"      : true // mostrar a progress bar
      //,"serverSide"       : true // processamento no servidor
        , "filter"          : true // habilita o filtro(search box)
      //,"lengthMenu"       : [ [3, 5, 10, 25, 50, -1], [3, 5, 10, 25, 50, "Todos"] ]
        , "pageLength"      : 10 // define o tamanho da página
        ,"ajax"             : (sURL ?  { "url": sURL, "type": "GET", "dataType": "json" } : null)
        , "initComplete": function (settings, json) { document.getElementById(DataTable).style.width = "100%"; }
    });

    document.getElementById(DataTable).style.width = "100%";
    
    /* Esta aqui como exemplo, neste eu chamo a funcao [TableChildRowFormat], que inseri uma tabela dentro da linha onde foi efetuado o click
       NÃO APAGAR ESTE TRECHO COMENTADO
     */
    //if (DataTable == 'tbConsulta_Acessos_EXEMPLO') {
    //    $('#' + DataTable + ' tbody').on('click', 'tr', function () {
    //        var tr = $(this).closest('tr');
    //        var row = dtapp.row(tr);
    //        if (row.child.isShown()) {
    //            // This row is already open - close it
    //            row.child.hide();
    //            tr.removeClass('shown');
    //        }
    //        else {
    //            // Open this row
    //            row.child(TableChildRowFormat(row.data())).show();
    //            tr.addClass('shown');
    //        }
    //    });
    //}
};



/*****************
 * 
 * Inicio das Rotinas do AutoComplete :
 *   - TableChildRowFormat; validaData; TableChildRowFormat; showAutoComplete; isNotCaracterEspecial; isBackSpace; carregarAjaxDados; select;
 * 
 *****************/

function TableChildRowFormat(d) {
    /*NÃO APAGAR ESTE TRECHO */
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

function validaData(campo, valor) {    
    var date = valor;
    var ardt = new Array;
    var ExpReg = new RegExp("(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/[12][0-9]{3}");
    ardt = date.split("/");
    erro = false;
    if (date.search(ExpReg) == -1) {
        erro = true;
    }
    else if (((ardt[1] == 4) || (ardt[1] == 6) || (ardt[1] == 9) || (ardt[1] == 11)) && (ardt[0] > 30))
        erro = true;
    else if (ardt[1] == 2) {
        if ((ardt[0] > 28) && ((ardt[2] % 4) != 0))
            erro = true;
        if ((ardt[0] > 29) && ((ardt[2] % 4) == 0))
            erro = true;
    }
    if (erro) {
        alert('[ ' + valor + ' ] não é uma data válida!!!');
        campo.focus();
        campo.value = "";
        return false;
    }    
    return true;
}

function TableChildRowFormat(d) {
    /*NÃO APAGAR ESTE TRECHO */
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

function hideAutoComplete(sugestoes) {
    window.setTimeout(function () {
        $("#" + sugestoes).hide();
    }, 500);
}

function showAutoComplete(sugestoes) {
    window.setTimeout(function () {
        $("#" + sugestoes).show();
    }, 500);
}

function isNotCaracterEspecial(evt, campo) {
    $("#click_" + campo).val("");

    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode == 47 || charCode == 39 || charCode == 124 || charCode == 92)
        return false;
    else {
        var term = encodeURIComponent($("#" + campo).val() + evt.key);
        carregarAjaxDados(campo, term);
    }
    return true;
}

function isBackSpace(evt, campo) {
    $("#click_" + campo).val("");

    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 8)
        return false;
    else {
        var term = encodeURIComponent($("#" + campo).val());
        carregarAjaxDados(campo, term);
    }
    return true;
}

function carregarAjaxDados(campo, term) {
    $.ajax({
        dataType: "json",
        type: "GET",
        url: "/Util/AutoComplete?campo=" + campo + "&term=" + encodeURIComponent(term),
        beforeSend: function () {
            $("#" + campo).css("background", "#FFF url(/Content/images/LoaderIcon.gif) no-repeat 165px");
        },
        success: function (data) {
            $("#" + campo).css("background", "");
            if (data == "")
                $("#" + campo + "_Sugestoes").hide();
            else
                $("#" + campo + "_Sugestoes").show();

            $("#" + campo + "_Sugestoes").html(data);
            $("#" + campo + "_Sugestoes").css("background", "#FFF");
        }
    });
}

function select(campoid, id, campo, val) {
    $("#" + campoid).val(id);
    $("#" + campo).val(val);
    $("#" + campo + "_Sugestoes").hide();
    $("#click_" + campo).val("1");
    chamaFuncaoAuxiliar(campo);
}

/*****************
 * Termino das Rotinas do AutoComplete
 *****************/


/***************************************************************************************************************************************************
* TERMINO - FUNCOES GENERICAS
***************************************************************************************************************************************************/