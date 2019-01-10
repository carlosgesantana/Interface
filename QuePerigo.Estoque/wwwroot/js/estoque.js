
$('#btn-add-produto').on('click', function (e) {

    noReload(e);

    var divProduto = $('#div-produto');

    LoadingPage();

    $.get(urlFormulario, function(data) {
        divProduto.html(data);
    });
});

$('#btn-pesquisar-produto').on('click', function (e) {

    noReload(e);

    var divProduto = $('#div-produto');

    LoadingPage();

    $.ajax({
        url: urlFormulario,
        data: { descricaoCurta: $('#txt-pesquisa').val() },
        type: 'POST',
        success: function (data) {
            divProduto.html(data);
        },
        error: function (data) {
            
        }
    });
});

function LoadingPage() {

    $("#modal-loading").modal({
        backdrop: "static",
        keyboard: false,
        show: true //Display loader!
    });
    setTimeout(function() {
        $("#modal-loading").modal("hide");
    }, 1300);

}

function noReload(e) {

    e.preventDefault();
    e.stopPropagation();
}