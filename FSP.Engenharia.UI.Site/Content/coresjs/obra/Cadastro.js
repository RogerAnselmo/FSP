/*
    Autor   : Pedro Carvalho
    Data    : 01/08/2018
    Objeto  :
*/

$(document).ready(function () {
    ConfiguraFormularioObra();
    CongiguraBotoesObra();
    $.getScript('/Content/coresjs/obra/Common.js', function () { });
});

/*
    Autor   : Pedro Carvalho
    Data    : 01/08/2018
    Objeto  :
*/
function ConfiguraFormularioObra() {
    configuraFormulario('#FrmCadastroObra',
        function (retorno) { ValidationResultObra(retorno); },
        function (error) { swal("Atenção!", error, "danger") });

    configuraFormulario('#FrmAlteracaoObra',
        function (retorno) { ValidationResultObra(retorno); },
        function (error) { swal("Atenção!", error, "danger") });
}

/*
    Autor   : Pedro Carvalho
    Data    : 01/08/2018
    Objeto  :
*/
function CongiguraBotoesObra() {
    $('#btSalvarObra').click(function () {
        $('#FrmCadastroObra').submit();
    });

    $('#btAlterarObra').click(function () {
        $('#FrmAlteracaoObra').submit();
    });

    $('#btLimparObra').click(function () {
        $('#FrmCadastroObra')[0].reset();
        $('#DescricaoObjeto').focus();
    });
}

