/*
    Autor   : Pedro Carvalho
    Data    : 01/08/2018
    Objeto  : 
*/


$(document).ready(function () {
    ObterTodasObras();

    $('#btPesquisarObra').click(function () {
        ObterObrasPorDescricao();
    });

    $.getScript('/CoresJs/obra/Common.js', function () { });
});

/*
    Autor   : Pedro Carvalho
    Data    : 01/08/2018
    Objeto  : Lista de Obras
*/
function ObterTodasObras() {
    $('#myTable').dataTable().fnClearTable();
    $('#myTable').dataTable().fnDraw();
    $('#myTable').dataTable().fnDestroy();;

    var conteudo = '';
    ExecutarComandoConsulta('/Gerenciar-Obra/ObterObras', undefined,
        function (retorno) {
            if (retorno.length !== 0) {
                $.each(retorno.data, function (i, item) {
                    conteudo += '  <tr>';
                    conteudo += '   <td>' + item.DescricaoObjeto + '</td>';
                    conteudo += '   <td>' + item.NomeObra + '</td>';
                    conteudo += '   <td>' + item.Endereco + '</td>';
                    conteudo += '   <td class="largura10 centro">' + item.UF + '</td>';
                    conteudo += '   <td class="largura10 centro">' + item.Status + '</td>';
                    conteudo += '   <td>' + item.DataInicio + '</td>';
                    conteudo += '   <td>';
                    conteudo += '       <a href="/Gerenciar-Obra/Alterar/' + item.CodigoObra + '" title="Editar" class="btn btn-warning">';
                    conteudo += '           <span class="glyphicon glyphicon-pencil"></span>';
                    conteudo += '       </a>';
                    conteudo += '       <a href="javascript:void(0)" onclick="ExcluirObra(' + item.CodigoObra + ')" title="Editar" class="btn btn-danger">';
                    conteudo += '           <span class="glyphicon glyphicon-trash"></span>';
                    conteudo += '       </a>';
                    conteudo += '</td > ';
                    conteudo += '  </tr>';
                    $('#tbodyTabelaObras').html(conteudo);
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

                //MontarTabela(retorno.data);
            }
            else {
                _tbodyTabelaObras.html('');
            }
        },
        function (erro) { erro });
}

/*
    Autor   : Pedro Carvalho
    Data    : 02/08/2018
    Objeto  : Excluir de Obra
*/
function ExcluirObra(codigoObra) {
    PerguntaExclusao("Deseja excluir essa Obra.", function (isConfirm) {
        if (isConfirm) {
            ExecutarComandoDelete('/Gerenciar-Obra/Excluir-Obra/', codigoObra,
                function (retorno) { ValidationResultObra(retorno) },
                function (error) { swal("Atenção!", error, "danger") }
            );
        }
    });
};

/*
    Autor   : Pedro Carvalho
    Data    : 01/08/2018
    Objeto  : Lista de Obras
*/
function ObterObrasPorDescricao() {
    $('#myTable').dataTable().fnClearTable();
    $('#myTable').dataTable().fnDraw();
    $('#myTable').dataTable().fnDestroy();;
    var conteudo = '';

    var params = new Object();
    params.nomeObra = $('#tbNomeObra').val();

    ExecutarComandoPost('/Gerenciar-Obra/ObterObrasPorDescricao', params,
        function (retorno) {
            if (retorno.length !== 0) {
                $.each(retorno.data, function (i, item) {
                    conteudo += '  <tr>';
                    conteudo += '   <td>' + item.DescricaoObjeto + '</td>';
                    conteudo += '   <td>' + item.NomeObra + '</td>';
                    conteudo += '   <td>' + item.Endereco + '</td>';
                    conteudo += '   <td>' + item.Estado + '</td>';
                    conteudo += '   <td>' + item.Status + '</td>';
                    conteudo += '   <td>' + item.DataInicio + '</td>';
                    conteudo += '   <td>';
                    conteudo += '       <a href="/Gerenciar-Obra/Alterar/' + item.CodigoObra + '" title="Editar" class="btn btn-warning">';
                    conteudo += '           <span class="glyphicon glyphicon-pencil"></span>';
                    conteudo += '       </a>';
                    conteudo += '       <a href="javascript:void(0)" onclick="ExcluirObra(' + item.CodigoObra + ')" title="Editar" class="btn btn-danger">';
                    conteudo += '           <span class="glyphicon glyphicon-trash"></span>';
                    conteudo += '       </a>';
                    conteudo += '</td > ';
                    conteudo += '  </tr>';
                    $('#tbodyTabelaObras').html(conteudo);
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
                $('#tbodyTabelaObras').html('');
            }
        },
        function (erro) { erro });
}


function MontarTabela(res) {
    //$('#myTable').dataTable().fnClearTable();
    //$('#myTable').dataTable().fnDraw();
    //$('#myTable').dataTable().fnDestroy();;

    criaTabela(
        'MontaTabelaObra',
        ['Descrição do Objeto', 'Nome da Obra', 'Endereço', 'Ação'],
        res,
        ['DescricaoObjeto', 'NomeObra', 'Endereco', 'linha'], ['Editar', 'Excluir'],
        'EditarUsuario', 'ExcluirUsuario'
    );

    //$('#myTable').DataTable({
    //    ordering: true,
    //    "language": {
    //        "sEmptyTable": "Nenhum registro encontrado",
    //        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
    //        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
    //        "sInfoFiltered": "(Filtrados de _MAX_ registros)",
    //        "sInfoPostFix": "",
    //        "sInfoThousands": ".",
    //        "sLengthMenu": "_MENU_ resultados por página",
    //        "sLoadingRecords": "Carregando...",
    //        "sProcessing": "Processando...",
    //        "sZeroRecords": "Nenhum registro encontrado",
    //        "sSearch": "Filtrar",
    //        "oPaginate": {
    //            "sNext": "Próximo",
    //            "sPrevious": "Anterior",
    //            "sFirst": "Primeiro",
    //            "sLast": "Último"
    //        },
    //        "oAria": {
    //            "sSortAscending": ": Ordenar colunas de forma ascendente",
    //            "sSortDescending": ": Ordenar colunas de forma descendente"
    //        }
    //    },
    //    destroy: true
    //});    
}
