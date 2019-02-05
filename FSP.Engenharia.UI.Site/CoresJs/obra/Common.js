var _DataInicio = $('#DataInicio');
var _DataFim = $('#DataFim');
var _CEP = $('#CEP');

$(document).ready(function () {
    ConfiguraControlesObra();
    $('.select2').select2();
//    ConverteTextoMinusculoParaMaiusculo();
});

function ConfiguraControlesObra() {
    _DataInicio.setMask({ mask: "99/99/9999" });
    _DataFim.setMask({ mask: "99/99/9999" });
    _CEP.setMask({ mask: "99999-999" });

    _DataInicio.datepicker({
        dateFormat: 'dd/mm/yy',
        dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
        dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
        monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        nextText: 'Próximo',
        prevText: 'Anterior'
    });

    _DataFim.datepicker({
        dateFormat: 'dd/mm/yy',
        dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
        dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
        monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        nextText: 'Próximo',
        prevText: 'Anterior'
    });
}
function ValidationResultObra(retorno) {
    console.log(retorno);
    if (retorno.erro == 0) { //Inclusão
        swal("Atenção!", retorno.mensagem, "success");
        $('#FrmCadastroObra')[0].reset();
    }
    else {
        if (retorno.erro == 1) { //Alteração
            swal({ title: 'Atenção!', text: retorno.mensagem, type: 'success' },
                function () {
                    window.location.href = '/Gerenciar-Obra/Consultar';
                });
        }
        else {
            if (retorno.erro == 2) { //Exclusao
                swal({ title: 'Atenção!', text: retorno.mensagem, type: 'success' },
                    function () {
                       // window.location.href = '/Gerenciar-Obra/Consultar';
                        ObterTodasObras();
                    });
            }
            else {
                swal("Atenção!", retorno.mensagem, "warning")
            }
        }
    }
}
