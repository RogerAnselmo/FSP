/*
    Autor   : Pedro Carvalho
    Data    : 01/08/2018
    Objeto  :
*/

$(document).ready(function () {
    ConfiguraFormularioFornecedor();
    CongiguraBotoesFornecedor();
    $.getScript('/CoresJs/fornecedor/Common.js', function () { });
});

/*
    Autor   : Pedro Carvalho
    Data    : 01/08/2018
    Objeto  :
*/
function ConfiguraFormularioFornecedor() {
    configuraFormulario('#FrmCadastroFornecedor',
        function (retorno) { ValidationResultFornecedor(retorno); },
        function (error) { swal("Atenção!", error, "danger") });

    configuraFormulario('#FrmAlteracaoFornecedor',
        function (retorno) { ValidationResultFornecedor(retorno); },
        function (error) { swal("Atenção!", error, "danger") });
}

/*
    Autor   : Pedro Carvalho
    Data    : 01/08/2018
    Objeto  :
*/
function CongiguraBotoesFornecedor() {
    $('#btSalvarFornecedor').click(function () {
        $('#FrmCadastroFornecedor').submit();
    });

    $('#btAlterarFornecedor').click(function () {
        $('#FrmAlteracaoFornecedor').submit();
    });

    $('#btLimparFornecedor').click(function () {
        $('#FrmCadastroFornecedor')[0].reset();
        $('#RazaoSocial').focus();
    });
}

