$(document).ready(function () {
    $('#btCadastroUsuario').click(function (e) {
       // e.preventDefault();
        // window.history.pushState({ url: "" + $(this).attr('href') + "" }, $(this).attr('title'), $(this).attr('href'));
        CarregaModulo('#modulo', $('#tbRoot').val() + $('#tbUrl').val() + '/Usuario/ListaUsuario', {});
    });

    $('#btCadastroPerfil').click(function (e) {
        CarregaModulo('#modulo', $('#tbRoot').val() + $('#tbUrl').val() + '/Perfil/ListaPerfil', {});
    });

    $('#btCadastroPerfilConcedido').click(function (e) {
        CarregaModulo('#modulo', $('#tbRoot').val() + $('#tbUrl').val() + '/PerfilConcedido/ListaPerfilConcedido', {});
    });


    $('#btCadastroModulo').click(function (e) {
        CarregaModulo('#modulo', $('#tbRoot').val() + $('#tbUrl').val() + '/Modulo/ListaModulo', {});
    });

    $('#btCadastroSubModulo').click(function (e) {
        CarregaModulo('#modulo', $('#tbRoot').val() + $('#tbUrl').val() + '/SubModulo/ListaSubModulo', {});
    });

    $('#btCadastroPermissao').click(function (e) {
        CarregaModulo('#modulo', $('#tbRoot').val() + $('#tbUrl').val() + '/Permissao/ListaPermissao', {});
    });

    $('#btCadastroVistoria').click(function (e) {
        CarregaModulo('#modulo', $('#tbRoot').val() + $('#tbUrl').val() + '/Vistoria/ListaVistoria', {});
    });  
});
