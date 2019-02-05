/*
    Autor   : Pedro Carvalho
    Data    : 04/08/2018
    Objeto  :
*/

$(document).ready(function () {
    //ConfiguraFormularioServico();
    //CongiguraBotoesServico();
    $.getScript('/CoresJs/pedidomaterial/Common.js', function () {
    });

});

/*
    Autor   : Pedro Carvalho
    Data    : 04/08/2018
    Objeto  :
*/
function ConfiguraFormularioServico() {
    configuraFormulario('#FrmCadastroServico',
        function (retorno) { ValidationResultServico(retorno); },
        function (error) { swal("Atenção!", error, "danger") });

    configuraFormulario('#FrmAlteracaoServico',
        function (retorno) { ValidationResultServico(retorno); },
        function (error) { swal("Atenção!", error, "danger") });
}

/*
    Autor   : Pedro Carvalho
    Data    : 04/08/2018
    Objeto  :
*/
function CongiguraBotoesServico() {
    $('#btSalvarServico').click(function () {
        var _valor = $('#Valor').val().toString().replace(/[\.-]/g, "");
        $('#Valor').val(_valor);
        $('#FrmCadastroServico').submit();
    });

    $('#btAlterarServico').click(function () {
        var _valor = $('#Valor').val().toString().replace(/[\.-]/g, "");
        $('#Valor').val(_valor);
        $('#FrmAlteracaoServico').submit();
    });

    $('#btLimparServico').click(function () {
        $('#FrmCadastroServico')[0].reset();
        $('#DescricaoServico').focus();
    });
}

