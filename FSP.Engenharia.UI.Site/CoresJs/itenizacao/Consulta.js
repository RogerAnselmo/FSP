/*
    Autor   : Pedro Carvalho
    Data    : 04/08/2018
    Objeto  : 
*/


$(document).ready(function () {
    ObterTodasServicos();
    $.getScript('/CoresJs/servico/Common.js', function () { });
});

/*
    Autor   : Pedro Carvalho
    Data    : 04/08/2018
    Objeto  : Lista de Servicos
*/
function ObterTodasServicos() {
    $('#myTable').dataTable().fnClearTable();
    $('#myTable').dataTable().fnDraw();
    $('#myTable').dataTable().fnDestroy();;

    var conteudo = '';
    ExecutarComandoConsulta('/Gerenciar-Servico/ObterServicos', undefined,
        function (retorno) {
            if (retorno.length !== 0) {
                $.each(retorno.data, function (i, item) {
                    conteudo += '  <tr>';
                    conteudo += '   <td>' + item.DescricaoServico + '</td>';
                    conteudo += '   <td class="largura15 direita">' + item.Percentual + '</td>';
                    conteudo += '   <td class="largura15 direita">' + item.Valor + '</td>';
                    conteudo += '   <td>';
                    conteudo += '       <a href="/Gerenciar-Servico/Alterar/' + item.CodigoServico + '" title="Editar" class="btn btn-warning">';
                    conteudo += '           <span class="glyphicon glyphicon-pencil"></span>';
                    conteudo += '       </a>';
                    conteudo += '       <a href="javascript:void(0)" onclick="ExcluirServico(' + item.CodigoServico + ')" title="Editar" class="btn btn-danger">';
                    conteudo += '           <span class="glyphicon glyphicon-trash"></span>';
                    conteudo += '       </a>';
                    conteudo += '</td > ';
                    conteudo += '  </tr>';
                    $('#tbodyTabelaServicos').html(conteudo);
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
                _tbodyTabelaServicos.html('');
            }
        },
        function (erro) { erro });
}

/*
    Autor   : Pedro Carvalho
    Data    : 02/08/2018
    Objeto  : Excluir de Servico
*/
function ExcluirServico(codigoServico) {
    PerguntaExclusao("Deseja excluir essa Serviço.", function (isConfirm) {
        if (isConfirm) {
            ExecutarComandoDelete('/Gerenciar-Servico/Excluir-Servico/', codigoServico,
                function (retorno) { ValidationResultServico(retorno) },
                function (error) { swal("Atenção!", error, "danger") }
            );
        }
    });
};

