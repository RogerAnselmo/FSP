let _CodigoObra = $('#CodigoObra');
let _CodigoServico = $('#CodigoServico');
let _CodigoItenizacao = $('#CodigoItenizacao');
let _ValorUnitario = $('#ValorUnitario');
let _NumeroItem = $('#NumeroItem');
let _NumeroOrdem = $('#NumeroOrdem');
let _TabelaItenizacao = $('#myTableItenizacao');
let _TbodyTabelaItenizacao = $('#tbodyTabelaItenizacao');
let _DescricaoItem = $('#DescricaoItem');
let _DescricaoUnidade = $('#DescricaoUnidade');
let _btSalvarItenizacao = $('#btSalvarItenizacao');
/*
    Autor   : Pedro Carvalho
    Data    : 05/08/2018
    Objeto  :
*/
$(document).ready(function () {
    ConfiguraControlesItenizacao();
    _CodigoServico.change(function () {
        if (_CodigoObra.val() !== '0' && this.value !== '0') {
            ObterProximoNumeroItemDoServico();
        }
    });
});

function ConfiguraControlesItenizacao() {
    _ValorUnitario.setMask({ mask: '99,999.999.99', type: 'reverse' });
    _NumeroItem.attr('readonly', true);
}

function ObterProximoNumeroItemDoServico() {
    ExecutarComandoConsulta('/Gerenciar-Itenizacao/Obter-Proximo-Valor-Item/', _CodigoObra.val() + '/' + _CodigoServico.val(),
        function (retorno) {
            console.log(retorno);
            _NumeroOrdem.val(retorno);
            _NumeroItem.val(_CodigoServico.val() + '.' + retorno);
            ObterItenizacaoPorCodigoObraECodigoServico();
        },
        function (erro) { erro });
}

function ObterItenizacaoPorCodigoObraECodigoServico() {
    $('#myTableItenizacao').dataTable().fnClearTable();
    $('#myTableItenizacao').dataTable().fnDraw();
    $('#myTableItenizacao').dataTable().fnDestroy();;

    var conteudo = '';
    ExecutarComandoConsulta('/Gerenciar-Itenizacao/Obter-Itenizacao-Obra-Servico/', _CodigoObra.val() + '/' + _CodigoServico.val(),
        function (retorno) {
            if (retorno.length !== 0) {
                $.each(retorno.data, function (i, item) {
                    conteudo += '  <tr>';
                    conteudo += '   <td>' + item.NumeroItem + '</td>';
                    conteudo += '   <td style="text-align:left">' + item.DescricaoItem + '</td>';
                    conteudo += '   <td>' + item.DescricaoUnidade + '</td>';
                    conteudo += '   <td class="largura15 direita">' + formatNumber(item.ValorUnitario) + '</td>';
                    conteudo += '   <td>';
                    conteudo += '       <a href="javascript:void(0)" onclick="EditarItenizacao(' + item.CodigoItenizacao + ',' + "'" + item.NumeroItem + "'" + ',' + "'" + item.DescricaoItem + "'" + ',' + "'" + item.DescricaoUnidade + "'" + ',' + "'" + formatNumber(item.ValorUnitario) + "'" + ',' + "'" + item.NumeroOrdem + "'" + ')" title="Editar" class="btn btn-warning">';
                    conteudo += '           <span class="glyphicon glyphicon-pencil"></span>';
                    conteudo += '       </a>';
                    conteudo += '       <a href="javascript:void(0)" onclick="ExcluirItenizacao(' + item.CodigoItenizacao + ')" title="Excluir" class="btn btn-danger">';
                    conteudo += '           <span class="glyphicon glyphicon-trash"></span>';
                    conteudo += '       </a>';
                    conteudo += '</td > ';
                    conteudo += '  </tr>';
                    _TbodyTabelaItenizacao.html(conteudo);
                });

                $('#myTableItenizacao').DataTable({
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
                _TbodyTabelaItenizacao.html('');
            }
        },
        function (erro) { erro });
}


function ValidationResultItenizacao(retorno) {
    if (retorno.erro == 0) { //Inclusão
        swal("Atenção!", retorno.mensagem, "success");
        ObterItenizacaoPorCodigoObraECodigoServico();
        //$('#FrmCadastroItenizacao')[0].reset();
        LimpaCampos();
    }
    else {
        if (retorno.erro == 1) { //Alteração
            swal({ title: 'Atenção!', text: retorno.mensagem, type: 'success' },
                function () {
                    window.location.href = '/Gerenciar-Itenizacao/Consultar';
                });
        }
        else {
            if (retorno.erro == 2) { //Exclusao
                swal({ title: 'Atenção!', text: retorno.mensagem, type: 'success' },
                    function () {
                        ObterTodasItenizacaos();
                    });
            }
            else {
                swal("Atenção!", retorno.mensagem, "warning")
            }
        }
    }
}
function EditarItenizacao(codigoItenizacao, numeroItem, descricaoItem, descricaoUnidade, valorUnitario, numeroOrdem) {
    _CodigoItenizacao.val(codigoItenizacao);
    _NumeroItem.val(numeroItem)
    _DescricaoItem.val(descricaoItem);
    _DescricaoUnidade.val(descricaoUnidade);
    _NumeroOrdem.val(numeroOrdem);
    _ValorUnitario.val(valorUnitario);
    _CodigoObra.attr('disabled',true);
    _CodigoServico.attr('disabled', true);
    _btSalvarItenizacao.html('Salvar');
}

function ExcluirItenizacao(codigoItenizacao) {
    alert('Ainda faltar fazer');
}

function LimpaCampos() {
    _NumeroItem.val('');
    _DescricaoItem.val('');
    _DescricaoUnidade.val('');
    _ValorUnitario.val('0,00');
    _NumeroOrdem.val('');
    ObterProximoNumeroItemDoServico();
    _btSalvarItenizacao.html('Cadastrar');
}