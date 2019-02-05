ShowWaitMe = function (msg) {
    if (!msg)
        msg = 'Carregando...';

    HideWaitMe();
    $(document.body).waitMe({ effect: "roundBounce", color: "#FF0000", text: msg });
}

HideWaitMe = function () {
    $(document.body).waitMe('hide');
}

exibirMensagem = function (msg, _type) {
    BootstrapDialog.show({
        type: (_type == null || typeof (_type) == "undefined") ? 'type-info' : 'type-' + _type,
        //animate: false,
        title: 'Mensagem do Servidor',
        message: msg,
        buttons: [
            {
                id: 'btFechar',
                icon: 'glyphicon glyphicon-check',
                label: 'Fechar',
                cssClass: 'btn-primary',
                autospin: false,
                action: function (dialogRef) {
                    dialogRef.close();
                }
            }
        ]
    });
}

exibirConfirmacao = function (msg, _callback) {
    BootstrapDialog.confirm({
        title: 'Confirmação',
        message: msg,
        type: BootstrapDialog.TYPE_WARNING, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
        draggable: true, // <-- Default value is false
        btnCancelLabel: 'Não', // <-- Default value is 'Cancel',
        btnOKLabel: 'Sim', // <-- Default value is 'OK',
        btnOKClass: 'btn-warning', // <-- If you didn't specify it, dialog type will be used,
        callback: _callback
    });
}

hideMensagemProcessamento = function () {
    if (_dialogGlobal != null) {
        _dialogGlobal.close();
        _dialogGlobal = null;// necessario anular a variavel apos fechar a dialog
    }
}

/*
 * Leandro - 02/07/2013
 * Função para tratar genericamente um erro de uma requisição ajax. 
 * Parametros e, exception: objetos retornados pelo jquery no evento de error.
*/
function tratarErrorAjax(e, exception) {
    var message;
    var statusErrorMap = {
        '400': "O servidor recebeu a requisicao, porem o conteudo era invalido.",
        '401': "Acesso nao autorizado.",
        '403': "Recurso proibido nao pode ser acessado.",
        '500': "Erro Interno do Servidor.",
        '503': "Servico Indisponivel."
    };

    if (e.status) {
        message = statusErrorMap[e.status];
        if (!message) {
            message = "Erro desconhecido!\nPor favor, contate um administrador do sistema.";
        } else {
            message = e.status + ": " + message;
        }

    } else if (exception == 'parsererror') {
        message = "Erro: Parsing JSON Request failed.";
    } else if (exception == 'timeout') {
        message = "Tempo limite da requisicao atingido. Tente novamente.";
    } else if (exception == 'abort') {
        message = "A Requisicao foi abortada pelo servidor. Tente novamente mais tarde.";
    } else {
        message = "Erro desconhecido!<br>Por favor, contate um administrador do sistema.";
    }

    swal("Atenção!", message, "danger");
}

