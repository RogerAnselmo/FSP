/*
Autor   : Pedro Carvalho
Data    : 22/08/2017
Objetivo: 
*/
$(document).ready(function () {
    $.getScript('/' + $('#tbUrl').val() + "/CoreJs/Permissao/PermissaoConcedida.js", function () {
        ObterPermissaoConcedidaModulo($('#LoginUsuario').val());
    });
});
