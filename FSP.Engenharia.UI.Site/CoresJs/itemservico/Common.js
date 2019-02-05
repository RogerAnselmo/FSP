let _CodigoObra = $('#CodigoObra');
let _CodigoServico = $('#CodigoServico');
let _CodigoItemServico = $('#CodigoItemServico');
let _ValorUnitario = $('#ValorUnitario');
let _NumeroItem = $('#NumeroItem');
let _NumeroOrdem = $('#NumeroOrdem');
let _TabelaItemServico = $('#myTableItemServico');
let _TbodyTabelaItemServico = $('#tbodyTabelaItemServico');
let _DescricaoItem = $('#DescricaoItem');
let _DescricaoUnidade = $('#DescricaoUnidade');
let _btSalvarItemServico = $('#btSalvarItemServico');
/*
    Autor   : Pedro Carvalho
    Data    : 05/08/2018
    Objeto  :
*/
$(document).ready(function () {
    ConfiguraControlesItemServico();
    _CodigoServico.change(function () {
        if (_CodigoObra.val() !== '0' && this.value !== '0') {
            ObterProximoNumeroItemDoServico();
        }
    });
});

function ConfiguraControlesItemServico() {
    _ValorUnitario.setMask({ mask: '99,999.999.99', type: 'reverse' });
    _NumeroItem.attr('readonly', true);
}

function ObterProximoNumeroItemDoServico() {
    ExecutarComandoConsulta('/Gerenciar-ItemServico/Obter-Proximo-Valor-Item/', _CodigoObra.val() + '/' + _CodigoServico.val(),
        function (retorno) {
            console.log(retorno);
            _NumeroOrdem.val(retorno);
            _NumeroItem.val(_CodigoServico.val() + '.' + retorno);
            ObterItemServicoPorCodigoObraECodigoServico();
        },
        function (erro) { erro });
}

function ObterItemServicoPorCodigoObraECodigoServico() {
    $('#myTableItemServico').dataTable().fnClearTable();
    $('#myTableItemServico').dataTable().fnDraw();
    $('#myTableItemServico').dataTable().fnDestroy();;

    var conteudo = '';
    ExecutarComandoConsulta('/Gerenciar-ItemServico/Obter-ItemServico/', _CodigoObra.val() + '/' + _CodigoServico.val(),
        function (retorno) {
            if (retorno.length !== 0) {
                $.each(retorno.data, function (i, item) {
                    conteudo += '  <tr>';
                    conteudo += '   <td>' + item.NumeroItem + '</td>';
                    conteudo += '   <td style="text-align:left">' + item.DescricaoItem + '</td>';
                    conteudo += '   <td>' + item.DescricaoUnidade + '</td>';
                    conteudo += '   <td class="largura15 direita">' + formatNumber(item.ValorUnitario) + '</td>';
                    conteudo += '   <td>';
                    conteudo += '       <a href="javascript:void(0)" onclick="EditarItemServico(' + item.CodigoItemServico + ',' + "'" + item.NumeroItem + "'" + ',' + "'" + item.DescricaoItem + "'" + ',' + "'" + item.DescricaoUnidade + "'" + ',' + "'" + formatNumber(item.ValorUnitario) + "'" + ',' + "'" + item.NumeroOrdem + "'" + ')" title="Editar" class="btn btn-warning">';
                    conteudo += '           <span class="glyphicon glyphicon-pencil"></span>';
                    conteudo += '       </a>';
                    conteudo += '       <a href="javascript:void(0)" onclick="ExcluirItemServico(' + item.CodigoItemServico + ')" title="Excluir" class="btn btn-danger">';
                    conteudo += '           <span class="glyphicon glyphicon-trash"></span>';
                    conteudo += '       </a>';
                    conteudo += '</td > ';
                    conteudo += '  </tr>';
                    _TbodyTabelaItemServico.html(conteudo);
                });

                $('#myTableItemServico').DataTable({
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
                _TbodyTabelaItemServico.html('');
            }
        },
        function (erro) { erro });
}


function ValidationResultItemServico(retorno) {
    if (retorno.erro == 0) { //Inclusão
        swal("Atenção!", retorno.mensagem, "success");
        ObterItemServicoPorCodigoObraECodigoServico();
        //$('#FrmCadastroItemServico')[0].reset();
        LimpaCampos();
    }
    else {
        if (retorno.erro == 1) { //Alteração
            swal({ title: 'Atenção!', text: retorno.mensagem, type: 'success' },
                function () {
                    window.location.href = '/Gerenciar-ItemServico/Consultar';
                });
        }
        else {
            if (retorno.erro == 2) { //Exclusao
                swal({ title: 'Atenção!', text: retorno.mensagem, type: 'success' },
                    function () {
                        ObterTodasItemServicos();
                    });
            }
            else {
                swal("Atenção!", retorno.mensagem, "warning")
            }
        }
    }
}
function EditarItemServico(codigoItemServico, numeroItem, descricaoItem, descricaoUnidade, valorUnitario, numeroOrdem) {
    _CodigoItemServico.val(codigoItemServico);
    _NumeroItem.val(numeroItem)
    _DescricaoItem.val(descricaoItem);
    _DescricaoUnidade.val(descricaoUnidade);
    _NumeroOrdem.val(numeroOrdem);
    _ValorUnitario.val(valorUnitario);
    _CodigoObra.attr('disabled',true);
    _CodigoServico.attr('disabled', true);
    _btSalvarItemServico.html('Salvar');
}

function ExcluirItemServico(codigoItemServico) {
    alert('Ainda faltar fazer');
}

function LimpaCampos() {
    _NumeroItem.val('');
    _DescricaoItem.val('');
    _DescricaoUnidade.val('');
    _ValorUnitario.val('0,00');
    _NumeroOrdem.val('');
    ObterProximoNumeroItemDoServico();
    _btSalvarItemServico.html('Cadastrar');
}