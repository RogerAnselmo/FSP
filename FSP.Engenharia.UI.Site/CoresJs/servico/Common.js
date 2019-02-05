var _CodigoServico = $('#CodigoServico');
var _Percentual = $('#Percentual');
var _Valor = $('#Valor');

/*
    Autor   : Pedro Carvalho
    Data    : 04/08/2018
    Objeto  :
*/
$(document).ready(function () {
    ConfiguraControlesServico();
});

function ConfiguraControlesServico() {
    _Percentual.setMask({ mask: '99,99', type: 'reverse' });
    _Valor.setMask({ mask: '99,999.999.99', type: 'reverse' });
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
