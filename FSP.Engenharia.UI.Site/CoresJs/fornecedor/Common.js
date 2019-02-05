var _CEP = $('#CEP');
var _CNPJ = $('#CNPJ');
var _Fone = $('#Fone');
var _Celular = $('#Celular');

$(document).ready(function () {
    ConfiguraControlesFornecedor();
    $('.select2').select2();
});

function ConfiguraControlesFornecedor() {
    _CEP.setMask({ mask: "99999-999" });
    _CNPJ.setMask({ mask: "99.999.999/9999-99" });
    _Fone.setMask({ mask: "(99) 9999-9999" });
    _Celular.setMask({ mask: "(99) 99999-9999" });
}
function ValidationResultFornecedor(retorno) {
    console.log(retorno);
    if (retorno.erro == 0) { //Inclusão
        swal("Atenção!", retorno.mensagem, "success");
        $('#FrmCadastroFornecedor')[0].reset();
    }
    else {
        if (retorno.erro == 1) { //Alteração
            swal({ title: 'Atenção!', text: retorno.mensagem, type: 'success' },
                function () {
                    window.location.href = '/Gerenciar-Fornecedor/Consultar';
                });
        }
        else {
            if (retorno.erro == 2) { //Exclusao
                swal({ title: 'Atenção!', text: retorno.mensagem, type: 'success' },
                    function () {
                        ObterTodosFornecedores();
                    });
            }
            else {
                swal("Atenção!", retorno.mensagem, "warning")
            }
        }
    }
}
