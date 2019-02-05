let _CodigoObra = $('#CodigoObra');
let _CodigoServico = $('#CodigoServico');
let _CodigoItenizacao = $('#CodigoItenizacao');
let _CodigoFornecedor = $('#CodigoFornecedor');

let _ValorTotal = $('#ValorTotal');
let _DescricaoUnidade = $('#DescricaoUnidade');
let _ValorUnitario = $('#ValorUnitario');
let _Quantidade = $('#Quantidade');

let _VetorItenizacao = [];
let _VetorPedidoMaterial = [];

let _btAdicionarItem = $('#btAdicionarItem');

/*
    Autor   : Pedro Carvalho
    Data    : 04/08/2018
    Objeto  :
*/
$(document).ready(function () {
    ConfiguraControlesPedidoMaterial();
});

function ConfiguraControlesPedidoMaterial() {
    _CodigoServico.empty();
    _CodigoServico.append('<option value="0">Selecione um Serviço</option>');

    _CodigoItenizacao.empty();
    _CodigoItenizacao.append('<option value="0">Selecione a descrição do item do serviço</option>');

    _ValorUnitario.setMask({ mask: '99,999.999.99', type: 'reverse' });
    _ValorTotal.setMask({ mask: '99,999.999.99', type: 'reverse' });

    _CodigoObra.change(function () {
        _CodigoServico.empty();
        _CodigoServico.append('<option value="0">Selecione um Serviço</option>');
        ExecutarComandoConsulta('/Gerenciar-Servico/Obter-Servico-Da-Obra-Relacionados-Na-Itenizacao/', this.value,
            function (retorno) {
                if (retorno.data.length !== 0) {
                    $.each(retorno.data, function (i, item) {
                        _CodigoServico.append('<option value="' + item.CodigoServico + '">' + item.DescricaoServico + '</option>');
                    });
                }
                else {
                    _CodigoServico.empty();
                    _CodigoServico.append('<option value="0">Selecione um Serviço</option>');
                }
            },
            function (erro) { erro });
    });


    _CodigoServico.change(function () {
        _CodigoItenizacao.empty();
        _CodigoItenizacao.append('<option value="0">Selecione a descrição do item do serviço</option>');
        ExecutarComandoConsulta('/Gerenciar-ItemServico/Obter-ItemServico-Obra-Servico-PedidoMaterial/', _CodigoObra.val() + '/' + this.value,
            function (retorno) {
                if (retorno.data.length !== 0) {
                    _VetorItenizacao = retorno.data;

                    console.log(_VetorItenizacao);

                    $.each(retorno.data, function (i, item) {
                        _CodigoItenizacao.append('<option value="' + item.CodigoItenizacao + '">' + item.DescricaoItem + '</option>');
                    });
                }
                else {
                    _CodigoItenizacao.empty();
                    _CodigoItenizacao.append('<option value="0">Selecione a descrição do item do serviço</option>');
                }
            },
            function (erro) { erro });
    });

    _CodigoItenizacao.change(function () {
        for (var i = 0; i < this.length; i++) {
            if (_VetorItenizacao[i].CodigoItemServico == this.value) {
                _DescricaoUnidade.val(_VetorItenizacao[i].DescricaoUnidade);
                _ValorUnitario.val(formatNumber(_VetorItenizacao[i].ValorUnitario));

                if (_Quantidade.val() !== '0') {
                    _ValorTotal.val(formatNumber(parseInt(_Quantidade.val()) * parseFloat(_ValorUnitario.val().replace('.',''))));
                }

                break;
            }
        }
    });

    _Quantidade.blur(function () {
        _ValorTotal.val(formatNumber(this.value * parseFloat(_ValorUnitario.val())));
    });

    _btAdicionarItem.click(function () {
        _VetorPedidoMaterial.push({
            CodigoObra: _CodigoObra.val(),
            CodigoServico: _CodigoServico.val(),
            CodigoItenizacao: _CodigoItenizacao.val(),
            CodigoFornecedor: _CodigoFornecedor.val(),
            Quantidade: _Quantidade.val(),
            DescricaoItem: $('#CodigoItenizacao option:selected').text(),
            DescricaoUnidade: _DescricaoUnidade.val(),
            ValorUnitario: _ValorUnitario.val(),
            RazaoSocial: $('#CodigoFornecedor option:selected').text(),
            ValorTotal: _ValorTotal.val(),
        });

        var _Conteudo = '';

        $.each(_VetorPedidoMaterial, function (i, item) {
            _Conteudo += '  <tr>';
            _Conteudo += '      <td>' + item.DescricaoItem + '</td>';
            _Conteudo += '      <td>' + item.DescricaoUnidade + '</td>';
            _Conteudo += '      <td>' + item.ValorUnitario + '</td>';
            _Conteudo += '      <td>' + item.RazaoSocial + '</td>';
            _Conteudo += '      <td>' + item.Quantidade + '</td>';
            _Conteudo += '      <td>' + item.ValorTotal + '</td>';
            _Conteudo += '  </tr>';
            $('#tbodyTabelaPedidoMaterial').html(_Conteudo);
                
        });
    });
}

function ValidationResultServico(retorno) {
    console.log(retorno);
    if (retorno.erro == 0) { //Inclusão
        swal("Atenção!", retorno.mensagem, "success");
        $('#FrmCadastroServico')[0].reset();
    }
    else {
        if (retorno.erro == 1) { //Alteração
            swal({ title: 'Atenção!', text: retorno.mensagem, type: 'success' },
                function () {
                    window.location.href = '/Gerenciar-Servico/Consultar';
                });
        }
        else {
            if (retorno.erro == 2) { //Exclusao
                swal({ title: 'Atenção!', text: retorno.mensagem, type: 'success' },
                    function () {
                        ObterTodasServicos();
                    });
            }
            else {
                swal("Atenção!", retorno.mensagem, "warning")
            }
        }
    }
}
