/***************************************************************************************************************************************************
* INICIO - CONSULTALOG -
***************************************************************************************************************************************************/
function fn_Inicializando_daterangepicker(objEmpresa, objAplicacao, objUsuario, objModulo, objInativos, objDatas) {
    if (typeof ($.fn.daterangepicker) === 'undefined') { return; }
    console.log('fn_Inicializando_daterangepicker');

    var cb = function (start, end, label) {
        //alert('Aqui dentro irei chamar Web API | Inicio [' + start.toISOString() + '] até [' + end.toISOString() + '] Botao Pressionado foi [' + label + ']');
        //alert(start.toISOString() + ' ' + end.toISOString() + ' - ' + label);
        $('#' + objDatas + ' span').html(start.format('DD/MM/YYYY') + ' - ' + end.format('DD/MM/YYYY'));
    };

    var optionSet1 = {
        startDate: moment().subtract(29, 'days'),
        endDate: moment(),
        minDate: '01/01/2000',
        maxDate: moment().format('DD/MM/YYYY'), //'12/31/2030',
        dateLimit: { days: 60 },
        showDropdowns: true,
        showWeekNumbers: true,
        timePicker: false,
        timePickerIncrement: 1,
        timePicker12Hour: true,
        ranges: {
            'Dia Atual': [moment(), moment()],
            'Ontem': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Últimos 7 dias': [moment().subtract(6, 'days'), moment()],
            'Últimos 30 dias': [moment().subtract(29, 'days'), moment()],
            'Este mês': [moment().startOf('month'), moment().endOf('month')],
            'Mês passado': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
        },
        opens: 'left',
        buttonClasses: ['btn btn-default'],
        applyClass: 'btn-small btn-primary',
        cancelClass: 'btn-small',
        format: 'DD/MM/YYYY',
        separator: ' to ',
        locale: {
            applyLabel: 'Processar',
            cancelLabel: 'Limpar',
            fromLabel: 'From',
            toLabel: 'To',
            customRangeLabel: 'Personalizado',
            daysOfWeek: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb'],
            monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
            firstDay: 1
        }
    };

    $('#' + objDatas + ' span').html(moment().subtract(29, 'days').format('DD/MM/YYYY') + ' até ' + moment().format('DD/MM/YYYY'));
    $('#' + objDatas + '').daterangepicker(optionSet1, cb);
    $('#' + objDatas + '').on('show.daterangepicker', function () {
        console.log("show event fired");
    });
    $('#' + objDatas + '').on('hide.daterangepicker', function () {
        console.log("hide event fired");
    });
    $('#' + objDatas + '').on('apply.daterangepicker', function (ev, picker) {
        console.log("apply event fired, start/end dates are " + picker.startDate.format('DD/MM/YYYY') + " to " + picker.endDate.format('DD/MM/YYYY'));

        var ddlEmpresa = $('#' + objEmpresa);
        var ddlAplicacao = $('#' + objAplicacao);
        var ddlUsuario = $('#' + objUsuario);
        var ddlModulo = $('#' + objModulo);
        var ddlInativo = $('#' + objInativos);
        var flgprocessa = true;


        if ((ddlEmpresa.val() == 0 || ddlEmpresa.val() == null) || (ddlAplicacao.val() == 0 || ddlAplicacao.val() == null)) {

            if ((ddlEmpresa.val() > 0) && (ddlAplicacao.val() == 0 || ddlAplicacao.val() == null)) {
                alert(objEmpresa);
                alert(objAplicacao);
                fnCarregaAplicacao(objEmpresa, objAplicacao);
            }
            alert("É necessário selecionar uma Empresa e uma Aplicação");
            flgprocessa = false;
        }

        if (flgprocessa) {
            LoadDataTable('tbConsulta_Acessos', '/consultalog/getacessos?IdEmpresa=' + ddlEmpresa.val() + '&IdAplicacao=' + ddlAplicacao.val() + '&IdUsuario=0&IdModulo=0&isInativo=false&DataInicio=' + picker.startDate.format('DD/MM/YYYY') + '&DataTermino=' + picker.endDate.format('DD/MM/YYYY'));
            LoadDataTable('tbConsulta_CRUD', '/consultalog/getcrud?IdEmpresa=' + ddlEmpresa.val() + '&IdAplicacao=' + ddlAplicacao.val() + '&IdUsuario=0&IdModulo=0&isInativo=false&DataInicio=' + picker.startDate.format('DD/MM/YYYY') + '&DataTermino=' + picker.endDate.format('DD/MM/YYYY'));
            LoadDataTable('tbConsulta_Alertas', '/consultalog/getalertas?IdEmpresa=' + ddlEmpresa.val() + '&IdAplicacao=' + ddlAplicacao.val() + '&IdUsuario=0&IdModulo=0&isInativo=false&DataInicio=' + picker.startDate.format('DD/MM/YYYY') + '&DataTermino=' + picker.endDate.format('DD/MM/YYYY'));
            LoadDataTable('tbConsulta_Erro', '/consultalog/geterro?IdEmpresa=' + ddlEmpresa.val() + '&IdAplicacao=' + ddlAplicacao.val() + '&IdUsuario=0&IdModulo=0&isInativo=false&DataInicio=' + picker.startDate.format('DD/MM/YYYY') + '&DataTermino=' + picker.endDate.format('DD/MM/YYYY'));

            //init_flot_chart(picker.startDate.format('DD/MM/YYYY'), picker.endDate.format('DD/MM/YYYY'));
            //alert('Aqui dentro irei chamar Web API que monta o grafico \r\n| Inicio [' + picker.startDate.format('DD/MM/YYYY') + '] até [' + picker.endDate.format('DD/MM/YYYY') + ']');
        }
    });
    $('#' + objDatas + '').on('cancel.daterangepicker', function (ev, picker) {
        console.log("cancel event fired");
        alert('Botao Cancelar foi pressionado daterangepicker.js(67)');
    });
    $('#options1').click(function () {
        $('#' + objDatas + '').data('daterangepicker').setOptions(optionSet1, cb);
    });
    $('#options2').click(function () {
        $('#' + objDatas + '').data('daterangepicker').setOptions(optionSet2, cb);
    });
    $('#destroy').click(function () {
        $('#' + objDatas + '').data('daterangepicker').remove();
    });
}


$('#consulta-modal').on('show.bs.modal', function (e) {
    var $modal = $(this);
    var sTitulo = $(e.relatedTarget).data('title');         //get data-id attribute of the clicked element
    var sURL = $(e.relatedTarget).data('url');           //get data-id attribute of the clicked element
    var IDEmpresa = $(e.relatedTarget).data('idempresa');     //get data-id attribute of the clicked element
    var IDAplicacao = $(e.relatedTarget).data('idaplicacao');   //get data-id attribute of the clicked element
    var ID = $(e.relatedTarget).data('id');            //get data-id attribute of the clicked element
    $.ajax({
        cache: false,
        type: 'GET',
        url: sURL + '?idempresa=' + IDEmpresa + '&idaplicacao=' + IDAplicacao + '&id=' + ID + '&title=' + sTitulo,
        success: function (data) {
            $modal.html(data);
        }
    });
});
/***************************************************************************************************************************************************
* TERMINO - CONSULTALOG -
***************************************************************************************************************************************************/

$(document).ready(function () {
    fn_Inicializando_daterangepicker('ddlIdEmpresa', 'ddlIdAplicacao', 'ddlUsuario', 'ddlModulo', 'ddlInativo', 'dtPeriodoPesquisa');
});