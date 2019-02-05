function configuraFormulario(_nameform, _success, _error) {
    $(_nameform).on("submit", function (event) {
        event.preventDefault();
        var url = $(this).attr("action");
        var formData = $(this).serialize();

        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            dataType: "json",
            success: _success,
            error: _error
        })
    });
}

function ExecutarComandoConsulta(_controller, _parametros, _sucesso, _erro) {
    var _url;

    if (_parametros != undefined)
        _url = _controller + _parametros;
    else
        _url = _controller;

    $.ajax({
        type: 'GET',
        url: _url,
        data: {},
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        sync: false,
        success: _sucesso,
        error: _erro
    });
}

function ExecutarComandoSalvar(_controller, _parametros, _sucesso, _erro) {
    $.ajax({
        type: 'POST',
        url: _controller,
        data: JSON.stringify(_parametros),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        sync: false,
        success: _sucesso,
        error: _erro
    });
}

function ExecutarComandoPost(_controller, _parametros, _sucesso, _erro) {
    $.ajax({
        type: 'POST',
        url: _controller,
        data: JSON.stringify(_parametros),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        sync: false,
        success: _sucesso,
        error: _erro
    });
}
function ExecutarComandoDelete(_controller, _parametros, _sucesso, _erro) {
    $.ajax({
        type: 'GET',
        url: _controller + _parametros,
        data: {},
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        sync: false,
        success: _sucesso,
        error: _erro
    });
}

CarregaModulo = function (target, url, parametro) {
    $.ajax({
        type: "GET",
        url: url + parametro,
        data: {},
        success: function (resposta) {
            var div = document.createElement("div");
            div.setAttribute("id", target);
            document.body.appendChild(div);
            $(target).html(resposta);
        }
    });
};

function PerguntaExclusao(_mensamge, _isConfirm) {
    swal({
        title: _mensamge,
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Sim",
        cancelButtonText: "Não",
        closeOnConfirm: false,
        closeOnCancel: true
    },
        _isConfirm
    );
}
function fIsDate(data) {
    if (data.length == 10) {
        er = /(0[0-9]|[12][0-9]|3[01])[-\.\/](0[0-9]|1[012])[-\.\/][0-9]{4}/;
        if (er.exec(data)) {
            return true;
        } else {
            return false;
        }

    } else {
        return false;
    }
}

//valida Celular
function IsValidaCelular(cel) {
    exp = /\(\d{2}\)\ \d{5}\-\d{4}/

    if (!exp.test(cel)) {
        return false;
    }
    else {
        return true;
    }
}

function IsValidaTelefone(tel) {
    exp = /\(\d{2}\)\ \d{4}\-\d{4}/

    if (!exp.test(tel)) {
        return false;
    }
    else {
        return true;
    }
}

//valida CEP
function IsValidaCep(cep) {
    exp = /\d{2}\.\d{3}\-\d{3}/

    if (!exp.test(cep)) {
        return false;
    }
    else {
        return true;
    }
}

function IsValidarCPF2(Objcpf) {
    var cpf = Objcpf;

    exp = /\.|\-/g
    cpf = cpf.toString().replace(exp, "");
    var digitoDigitado = eval(cpf.charAt(9) + cpf.charAt(10));
    var soma1 = 0, soma2 = 0;
    var vlr = 11;

    for (i = 0; i < 9; i++) {
        soma1 += eval(cpf.charAt(i) * (vlr - 1));
        soma2 += eval(cpf.charAt(i) * vlr);
        vlr--;
    }
    soma1 = (((soma1 * 10) % 11) == 10 ? 0 : ((soma1 * 10) % 11));
    soma2 = (((soma2 + (2 * soma1)) * 10) % 11);

    var digitoGerado = (soma1 * 10) + soma2;
    if (digitoGerado != digitoDigitado) {
        return false;
    }
    else {
        return true;
    }
}

function IsValidarCPF(value) {
    value = value.replace('.', '');
    value = value.replace('.', '');
    cpf = value.replace('-', '');
    while (cpf.length < 11) cpf = "0" + cpf;
    var expReg = /^0+$|^1+$|^2+$|^3+$|^4+$|^5+$|^6+$|^7+$|^8+$|^9+$/;
    var a = [];
    var b = new Number;
    var c = 11;
    for (i = 0; i < 11; i++) {
        a[i] = cpf.charAt(i);
        if (i < 9) b += (a[i] * --c);
    }
    if ((x = b % 11) < 2) { a[9] = 0 } else { a[9] = 11 - x }
    b = 0;
    c = 11;
    for (y = 0; y < 10; y++) b += (a[y] * c--);
    if ((x = b % 11) < 2) { a[10] = 0; } else { a[10] = 11 - x; }

    var retorno = true;

    if ((cpf.charAt(9) != a[9]) || (cpf.charAt(10) != a[10]) || cpf.match(expReg)) retorno = false;

    return retorno;
};

//Datepicker
function configuraDatePicker(_target) {

    _target = '#' + _target;

    if ($(_target).val() === "") {
        $(_target).val('dd/mm/aaaa');
    }

    $(_target).datepicker({
        dateFormat: 'dd/mm/yy',
        dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
        dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
        monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        nextText: 'Próximo',
        prevText: 'Anterior'
    });


    //não permite digitar na caixa de texto
    $(_target).keypress(function (e) {
        e = e || window.event;
        var charCode = (typeof e.which == "undefined") ? e.keyCode : e.which;
        var charStr = String.fromCharCode(charCode);
        if (/\d/.test(charStr)) {
            return false;
        }
    });
}

function appendOption(_Value, _Text, _target) {
    var option = document.createElement("option");
    option.value = _Value;
    option.text = _Text;
    _target.append(option);
};

function configuraFileUpload(_target, _render, maximoArquivos, extensoesPermitidas, tamanhoMaximo) {

    _target = '#' + _target;

    $(_target).change(function (e) {
        if (e.target.files.length > 1) {
            swal('Atenção!', 'Favor selecione somente ' + maximoArquivos + ' arquivo(s)!', 'warning');
            $('#FotoForm').val('');
            return;
        };

        var extensao = $(_target).val().substr(($(_target).val().lastIndexOf('.') + 1));
        var extensaoOK = extensoesPermitidas.filter(function (ext) { if (ext === extensao.toUpperCase()) return ext; }).length;

        if (extensaoOK === 0) {
            var texto = "Estensões permitidas: ";
            for (var i = 0; i < extensoesPermitidas.length; i++) {
                texto += ((i === 0) ? " " : ",") + extensoesPermitidas[i];
            }

            swal("Atenção!", texto, "warning");
            $(_target).val('');
            return;
        }

        if (((e.target.files[0].size / 1024) / 1024).toFixed(4) > tamanhoMaximo) {
            swal('Atenção!', 'Favor selecione um arquivo com menos de ' + tamanhoMaximo + 'MB!', 'warning');
            $(_target).val('');
            return;
        }

        var input = document.querySelector(_target);

        var reader = new FileReader();
        reader.onload = function () {
            $("#" + _render).attr("src", reader.result)
        };
        reader.readAsDataURL(input.files[0]);
    });
}

function ValidaDataInicialEDataFinalMaiorEMenor(_DataInicio, _DataFim, _Mensagem) {
    var _DataHoraInicio = new Date();
    var _DataHoraFim = new Date();

    _DataHoraInicio.setYear(_DataInicio.val().split("/")[2]);
    _DataHoraInicio.setMonth(_DataInicio.val().split("/")[1] - 1);
    _DataHoraInicio.setDate(_DataInicio.val().split("/")[0]);

    _DataHoraFim.setYear(_DataFim.val().split("/")[2]);
    _DataHoraFim.setMonth(_DataFim.val().split("/")[1] - 1);
    _DataHoraFim.setDate(_DataFim.val().split("/")[0]);

    if (_DataHoraInicio.getTime() > _DataHoraFim.getTime()) {
        swal('Atenção!', _Mensagem, 'warning');
        return false;
    }

    return true;
}

function ValidaDataInicialEDataFinalSaoIguais(_DataInicio, _DataFim, _Mensagem) {
    var _DataHoraInicio = new Date();
    var _DataHoraFim = new Date();

    _DataHoraInicio.setYear(_DataInicio.val().split("/")[2]);
    _DataHoraInicio.setMonth(_DataInicio.val().split("/")[1] - 1);
    _DataHoraInicio.setDate(_DataInicio.val().split("/")[0]);

    _DataHoraFim.setYear(_DataFim.val().split("/")[2]);
    _DataHoraFim.setMonth(_DataFim.val().split("/")[1] - 1);
    _DataHoraFim.setDate(_DataFim.val().split("/")[0]);

    if (_DataHoraInicio.getTime() == _DataHoraFim.getTime()) {
        swal('Atenção!', _Mensagem, 'warning');
        return false;
    }

    return true;
}

function criaTabela(_Target, _Titulo, _Colunas, _Campos, _Botoes, _Funcoes) {
    var _TabelaInicio = '<table id="myTable" class=\"table table-striped jambo_table bulk_action\">';
    var _TabelaFim = '</table>';
    var _trinicio = '<thead><tr>';
    var _trfim = '</thead></tr>'
    var _thinicio = '<th>';

    var _MontaTabela = null;

    $.each(_Titulo, function (i, val) {
        var _value = '<th>' + val + '</th>';
        _trinicio += _value;
    });

    _trinicio += _trfim + '<tbody>';
    _trinicio += '<tr>';

    var quebra = false;
    var id = 0;

    var _NomeBotoes = ' ';
    var _NomeFuncoes = [];

    _NomeFuncoes = _Funcoes.toString().split('#');

    $.each(_Colunas, function (i, val) {
        $.each(_Campos, function (j, field) {
            if (field != 'linha') {
                if (!quebra) {
                    var _value = '<td>' + val[field] + '</td>';
                    _trinicio += _value;

                    if (j == 0) {
                        id = val[field]
                    };
                }
                else {
                    quebra = false;
                    _NomeBotoes = '';

                    $.each(_Botoes, function (i, botoes) {
                        console.log(botoes);
                        _NomeBotoes += ConfiguraBotao(_NomeFuncoes[i], id, botoes);
                    });

                    _trinicio += '<td>' + _NomeBotoes + '</td></tr>';

                    var _value = '<tr><td>' + val[field] + '</td>';
                    _trinicio += _value;
                    id = val[field];
                }
            }
            else {
                quebra = true;
            }
        });
    });

    _NomeBotoes = '';
    $.each(_Botoes, function (i, botoes) {
        console.log(botoes);
        _NomeBotoes += ConfiguraBotao(_NomeFuncoes[i], id, botoes);
    });

    _trinicio += '<td>' + _NomeBotoes + '</td></tr></tbody>';

    _MontaTabela = _TabelaInicio;
    _MontaTabela += _trinicio;
    _MontaTabela += _thinicio;
    _MontaTabela += _trfim;
    _MontaTabela += _TabelaFim;

    console.log(_MontaTabela);

    $('#' + _Target).html(_MontaTabela);
}

function ConfiguraBotao(_value, id, _Nome) {
    var icone = '';
    switch (_Nome) {
        case 'Editar':
            icone = '<a href=\'#\' id=' + _value + ' onclick=' + _value + '()' +' class="btn btn-warning"> <span class="glyphicon glyphicon-pencil"></span></a>';
            break;
        case 'Excluir':
            icone = ' <a href=\'#\' id=' + _value + ' onclick=' + _value + '(' + id + '") class="btn btn-danger"> <span class="glyphicon glyphicon-trash"></span></a>';
            break;
    }
    return icone;
}