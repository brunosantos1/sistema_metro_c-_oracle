$(document).ready(function () {

    /***************************************************************************************************************************************************
     * INICIO - CONTROLLER APLICACAO -
     ***************************************************************************************************************************************************/
    $('.controler_aplicao_testar_conexao').click(function (e) {
        /* Testando conexao com banco de dados, de acordo com o protocolo escolhido */
        var ServerIP = window.document.getElementById("NmBancohost").value;
        var ServerPort = window.document.getElementById("NuBancoporta").value;
        var DbCatalog = window.document.getElementById("NmBanconome").value;
        var DbUser = window.document.getElementById("NmBancousuario").value;
        var DbPassword = window.document.getElementById("DsBancosenha").value;
        var DbProtocolo = window.document.getElementById("DsBancoprotocolo").value;
        var URL = '/aplicacao/TestarConexao?ServerIP=' + ServerIP + '&ServerPort=' + ServerPort + '&DbCatalog=' + DbCatalog + '&DbUser=' + DbUser + '&DbPassword=' + DbPassword + '&DbProtocolo=' + DbProtocolo;
        $.ajax({
            cache: false,
            type: 'POST',
            url: URL,
            success: function (data) {
                if (data.toUpperCase() == "TRUE") {
                    alert('Conexão com servidor de dados efetuada com sucesso !!!');
                    window.document.getElementById("btnSalvar").style.visibility = "visible";
                    window.document.getElementById("btnSalvar").style.display = "";
                }
                else {
                    alert('Falha ao conectar com servidor de dados!!!');
                }
            }
        });
    });

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

    $('#modalpopup').on('show.bs.modal', function (e) {
        var $modal = $(this);
        var RegistroId = $(e.relatedTarget).data('id'); //get data-id attribute of the clicked element
        $.ajax({
            cache: false,
            type: 'GET',
            url: '/aplicacao/implementacao_codigo?ID=' + RegistroId,
            success: function (data) {
                //if (data == true) { $("#modalpopup").load('@Url.Action("Implementacao_Codigo", "aplicacao")'); }
                $modal.html(data);
            }
        });
        //$(e.currentTarget).find('input[name="bookId"]').val(bookId);    //populate the textbox
    });



    /***************************************************************************************************************************************************
     * TERMINO - CONTROLLER APLICACAO -
     ***************************************************************************************************************************************************/
});