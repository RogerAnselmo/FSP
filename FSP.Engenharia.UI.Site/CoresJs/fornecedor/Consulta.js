/*
    Autor   : Pedro Carvalho
    Data    : 05/08/2018
    Objeto  : 
*/


$(document).ready(function () {
    ObterTodosFornecedores();

    $('#btPesquisarFornecedor').click(function () {
        ObterFornecedorsPorDescricao();
    });

    $.getScript('/CoresJs/fornecedor/Common.js', function () { });
});

/*
    Autor   : Pedro Carvalho
    Data    : 05/08/2018
    Objeto  : Lista de Fornecedors
*/
function ObterTodosFornecedores() {
    $('#myTable').dataTable().fnClearTable();
    $('#myTable').dataTable().fnDraw();
    $('#myTable').dataTable().fnDestroy();;

    var conteudo = '';
    ExecutarComandoConsulta('/Gerenciar-Fornecedor/ObterFornecedores', undefined,
        function (retorno) {
            if (retorno.length !== 0) {
                $.each(retorno.data, function (i, item) {
                    conteudo += '  <tr>';
                    conteudo += '   <td>' + item.RazaoSocial + '</td>';
                    conteudo += '   <td class="largura15 centro">' + item.Fone + '</td>';
                    conteudo += '   <td class="largura15 centro">' + item.Celular + '</td>';
                    conteudo += '   <td>' + item.NomeResponsavel + '</td>';
                    conteudo += '   <td>';
                    conteudo += '       <a href="/Gerenciar-Fornecedor/Alterar/' + item.CodigoFornecedor + '" title="Editar" class="btn btn-warning">';
                    conteudo += '           <span class="glyphicon glyphicon-pencil"></span>';
                    conteudo += '       </a>';
                    conteudo += '       <a href="javascript:void(0)" onclick="ExcluirFornecedor(' + item.CodigoFornecedor + ')" title="Editar" class="btn btn-danger">';
                    conteudo += '           <span class="glyphicon glyphicon-trash"></span>';
                    conteudo += '       </a>';
                    conteudo += '</td > ';
                    conteudo += '  </tr>';
                    $('#tbodyTabelaFornecedor').html(conteudo);
                });

                $('#myTable').DataTable({
                    ordering: true,
                    "language": {
                        "sEmptyTable": "Nenhum registro encontrado",
                        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
                        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
                        "sInfoFiltered": "(Filtrados de _MAX_ registros)",
                        "sInfoPostFix": "",
                        "sInfoThousands": ".",
                        "sLengthMenu": "_MENU_ resultados por página",
                        "sLoadingRecords": "Carregando...",
                        "sProcessing": "Processando...",
                        "sZeroRecords": "Nenhum registro encontrado",
                        "sSearch": "Filtrar",
                        "oPaginate": {
                            "sNext": "Próximo",
                            "sPrevious": "Anterior",
                            "sFirst": "Primeiro",
                            "sLast": "Último"
                        },
                        "oAria": {
                            "sSortAscending": ": Ordenar colunas de forma ascendente",
                            "sSortDescending": ": Ordenar colunas de forma descendente"
                        }
                    },
                    destroy: true
                });
            }
            else {
                _tbodyTabelaFornecedor.html('');
            }
        },
        function (erro) { erro });
}

/*
    Autor   : Pedro Carvalho
    Data    : 02/08/2018
    Objeto  : Excluir de Fornecedor
*/
function ExcluirFornecedor(codigoFornecedor) {
    PerguntaExclusao("Deseja excluir essa Fornecedor.", function (isConfirm) {
        if (isConfirm) {
            ExecutarComandoDelete('/Gerenciar-Fornecedor/Excluir-Fornecedor/', codigoFornecedor,
                function (retorno) { ValidationResultFornecedor(retorno) },
                function (error) { swal("Atenção!", error, "danger") }
            );
        }
    });
};

/*
    Autor   : Pedro Carvalho
    Data    : 05/08/2018
    Objeto  : Lista de Fornecedors
*/
function ObterFornecedorsPorDescricao() {
    $('#myTable').dataTable().fnClearTable();
    $('#myTable').dataTable().fnDraw();
    $('#myTable').dataTable().fnDestroy();;
    var conteudo = '';

    var params = new Object();
    params.nomeFornecedor = $('#tbNomeFornecedor').val();

    ExecutarComandoPost('/Gerenciar-Fornecedor/ObterFornecedorsPorDescricao', params,
        function (retorno) {
            if (retorno.length !== 0) {
                $.each(retorno.data, function (i, item) {
                    conteudo += '  <tr>';
                    conteudo += '   <td>' + item.DescricaoObjeto + '</td>';
                    conteudo += '   <td>' + item.NomeFornecedor + '</td>';
                    conteudo += '   <td>' + item.Endereco + '</td>';
                    conteudo += '   <td>' + item.Estado + '</td>';
                    conteudo += '   <td>' + item.Status + '</td>';
                    conteudo += '   <td>' + item.DataInicio + '</td>';
                    conteudo += '   <td>';
                    conteudo += '       <a href="/Gerenciar-Fornecedor/Alterar/' + item.CodigoFornecedor + '" title="Editar" class="btn btn-warning">';
                    conteudo += '           <span class="glyphicon glyphicon-pencil"></span>';
                    conteudo += '       </a>';
                    conteudo += '       <a href="javascript:void(0)" onclick="ExcluirFornecedor(' + item.CodigoFornecedor + ')" title="Editar" class="btn btn-danger">';
                    conteudo += '           <span class="glyphicon glyphicon-trash"></span>';
                    conteudo += '       </a>';
                    conteudo += '</td > ';
                    conteudo += '  </tr>';
                    $('#tbodyTabelaFornecedors').html(conteudo);
                });

                $('#myTable').DataTable({
                    ordering: true,
                    "language": {
                        "sEmptyTable": "Nenhum registro encontrado",
                        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
                        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
                        "sInfoFiltered": "(Filtrados de _MAX_ registros)",
                        "sInfoPostFix": "",
                        "sInfoThousands": ".",
                        "sLengthMenu": "_MENU_ resultados por página",
                        "sLoadingRecords": "Carregando...",
                        "sProcessing": "Processando...",
                        "sZeroRecords": "Nenhum registro encontrado",
                        "sSearch": "Filtrar",
                        "oPaginate": {
                            "sNext": "Próximo",
                            "sPrevious": "Anterior",
                            "sFirst": "Primeiro",
                            "sLast": "Último"
                        },
                        "oAria": {
                            "sSortAscending": ": Ordenar colunas de forma ascendente",
                            "sSortDescending": ": Ordenar colunas de forma descendente"
                        }
                    },
                    destroy: true
                });
            }
            else {
                aleert('adsasd');
                $('#tbodyTabelaFornecedors').html('');
            }
        },
        function (erro) { erro });
}
