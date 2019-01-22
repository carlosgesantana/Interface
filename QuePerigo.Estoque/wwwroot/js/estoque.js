$(document).ready(function () {

    NovoProduto();

});

$('#btn-add-produto').on('click', function (e) {

    noReload(e);
    NovoProduto();

});

$('#btn-pesquisar-produto').on('click', function (e) {

    noReload(e);
    PesquisarProduto();

});

var divConteudo = $('#div-conteudo');

//var campos = ['id', 'descricaoCurta', 'fornecedor.nome', 'quantidade', 'preco', 'custo'];


function NovoProduto() {

    beginLoading();

    $.get(urlFormulario, function (data) {
        divConteudo.html(data);
    });

    endLoading();

}

function PesquisarProduto() {

    beginLoading();

    var columns =
        [
            { data: 'id', title: 'Id Produto' },
            { data: 'descricaoCurta', title: 'Descricao' },
            { data: 'fornecedor.nome', title: 'Fornecedor' },
            { data: 'quantidade', title: 'Quantidade' },
            { data: 'custo', title: 'Custo' },
            { data: 'preco', title: 'Preco' }
        ];

    $.ajax({
        url: urlResultados,
        data: { descricaoCurta: $('#txt-pesquisa').val() },
        type: 'POST',
        success: function (data) {

            var campos = getCamposFromColumns(columns);
            
            data = filtrarCampos(data, campos);

            var tableResultados = getTabela('table-resultados');
            var tableResponsive = getTabelaResponsiva();

            $(tableResponsive).append(tableResultados);

            divConteudo.html(tableResponsive);

            $(tableResultados).DataTable({
                data: data,
                columns: columns,
                rowId: 'id',
                "searching": false,
                select: { style: 'os' }
            });

        },
        error: function (data) {
        }
    });

    endLoading();

}

function getTabelaResponsiva() {

    //Tabela responsiva - Redimensiona a tabela automaticamente em telas menores que 768px

    var tableResponsive = document.createElement('div');
    $(tableResponsive).addClass('table-responsive');


    return tableResponsive;
}

function getCamposFromColumns(columns) {

    var campos = [];

    for (var i = 0; i < columns.length; i++)
        campos.push(columns[i].data);

    return campos;

}

function getTabela(id) {

    
    //Tabela de Dados - Cria a estrutura de uma tabela de dados

    var table = document.createElement('table');
    $(table).attr('id', id);
    $(table).addClass('table table-striped table-bordered table-hover');
    var thead = document.createElement('thead');
    var tbody = document.createElement('tbody');

    //Append - Cria a hierarquia correta de elementos da tabela

    $(table).append(thead);
    $(table).append(tbody);

    return table;

}

function filtrarCampos(data, campos) {

    var filtered = data.map(function (obj) {

        var temp = {};

        var campo;

        for (var i = 0; i < campos.length; i++) {

            campo = campos[i];

            if (campo.includes('.'))
                campo = campo.substr(0, campo.indexOf('.'));
            
            temp[campo] = obj[campo];
        }

        return temp;
    });

    return filtered;
}

function obterValorComplexo(campo, obj) {

    if (!campo.includes('.')) {

        obj = obj[campo];

    }
    else {

        var campos = campo.split('.', 2);
        var campoPai = campos[0];
        var campoFilho = campos[1];

        obj = obj[campoPai];
        obj = obterValorComplexo(campoFilho, obj);
    }

    return obj;
}