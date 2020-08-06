$(document).ready(function () {
    LoadDataTable("tbFiltroTrem");
});

$('.btn_atualizarkm').on('click', function () {
    var id = $(this).data('id');
    window.open('/MaterialRodante/DocumentoMedicao/' + id, '_blank');
})
$('.btn_entregatrem').on('click', function () {
    var id = $(this).data('id');
    window.open('/MaterialRodante/SolicitarEntregaTrem/' + id, '_blank');
})
$('.btn_manobratrem').on('click', function () {
    var id = $(this).data('id');
    window.open('/MaterialRodante/SolicitarManobra/' + id, '_blank');
})

function fnCarregaDataTable(objTable, objLinha, objPatio, objStatus, objManobra)
{
    //alert('fnCarregaDataTable : ' + window.document.getElementById(objLinha).value);
    var idLinha     = window.document.getElementById(objLinha).value;
    var idPatio     = window.document.getElementById(objPatio).value;
    var idStatus    = window.document.getElementById(objStatus).value;
    var Manobra     = 1; //$('#' + objManobra).value;
    var URL = '/PesquisarTrens/PesquisarTrensFiltro?idLinha=' + idLinha + '&idPatio=' + idPatio + '&idStatus=' + idStatus + '&isManobra=' + Manobra;        
    LoadDataTable(objTable, URL);
};


