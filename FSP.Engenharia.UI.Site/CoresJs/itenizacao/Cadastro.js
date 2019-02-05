/*
    Autor   : Pedro Carvalho
    Data    : 05/08/2018
    Objeto  :
*/

$(document).ready(function () {
    ConfiguraFormularioItenizacao();
    CongiguraBotoesItenizacao();

    $.getScript('/CoresJs/itenizacao/Common.js', function () {
        if (_CodigoItenizacao.val() === 0) {
            _ValorUnitario.val('0,00');
        }
    });
});

/*
    Autor   : Pedro Carvalho
    Data    : 05/08/2018
    Objeto  :
*/
function ConfiguraFormularioItenizacao() {
    configuraFormulario('#FrmCadastroItenizacao',
        function (retorno) { ValidationResultItenizacao(retorno); },
        function (error) { swal("Atenção!", error, "danger") });

    configuraFormulario('#FrmAlteracaoItenizacao',
        function (retorno) { ValidationResultItenizacao(retorno); },
        function (error) { swal("Atenção!", error, "danger") });
}

/*
    Autor   : Pedro Carvalho
    Data    : 05/08/2018
    Objeto  :
*/
function CongiguraBotoesItenizacao() {
    $('#btSalvarItenizacao').click(function () {
        var _valor = $('#ValorUnitario').val().toString().replace(/[\.-]/g, "");
        _CodigoObra.attr('disabled', false);
        _CodigoServico.attr('disabled', false);

        $('#ValorUnitario').val(_valor);
        $('#FrmCadastroItenizacao').submit();
    });

    $('#btAlterarItenizacao').click(function () {
        var _valor = $('#ValorUnitario').val().toString().replace(/[\.-]/g, "");
        $('#ValorUnitario').val(_valor);
        $('#FrmAlteracaoItenizacao').submit();
    });

    $('#btLimparItenizacao').click(function () {
        //$('#FrmCadastroItenizacao')[0].reset();
        //$('#DescricaoItem').focus();
        LimpaCampos();
        //console.log(_TabelaItenizacao);
    });
}

