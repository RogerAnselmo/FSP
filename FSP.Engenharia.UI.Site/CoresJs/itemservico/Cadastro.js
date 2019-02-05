/*
    Autor   : Pedro Carvalho
    Data    : 05/08/2018
    Objeto  :
*/

$(document).ready(function () {
    ConfiguraFormularioitemservico();
    CongiguraBotoesitemservico();

    $.getScript('/CoresJs/itemservico/Common.js', function () {
        if (_CodigoItemServico.val() === 0) {
            _ValorUnitario.val('0,00');
        }
    });
});

/*
    Autor   : Pedro Carvalho
    Data    : 05/08/2018
    Objeto  :
*/
function ConfiguraFormularioitemservico() {
    configuraFormulario('#FrmCadastroItemServico',
        function (retorno) { ValidationResultItemServico(retorno); },
        function (error) { swal("Atenção!", error, "danger") });

    configuraFormulario('#FrmAlteracaoitemservico',
        function (retorno) { ValidationResultitemservico(retorno); },
        function (error) { swal("Atenção!", error, "danger") });
}

/*
    Autor   : Pedro Carvalho
    Data    : 05/08/2018
    Objeto  :
*/
function CongiguraBotoesitemservico() {
    $('#btSalvarItemServico').click(function () {
        var _valor = $('#ValorUnitario').val().toString().replace(/[\.-]/g, "");
        _CodigoObra.attr('disabled', false);
        _CodigoServico.attr('disabled', false);

        $('#ValorUnitario').val(_valor);
        $('#FrmCadastroItemServico').submit();
    });

    $('#btAlterarItemServico').click(function () {
        var _valor = $('#ValorUnitario').val().toString().replace(/[\.-]/g, "");
        $('#ValorUnitario').val(_valor);
        $('#FrmAlteracaoitemservico').submit();
    });

    $('#btLimparItemServico').click(function () {
        //$('#FrmCadastroitemservico')[0].reset();
        //$('#DescricaoItem').focus();
        LimpaCampos();
        //console.log(_Tabelaitemservico);
    });
}

