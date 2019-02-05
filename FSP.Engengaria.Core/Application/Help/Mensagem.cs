namespace FSP.Engengaria.Core.Application.Help
{
    public class Mensagem
    {
        public static string Inclusao => "Registro incluído com sucesso.";
        public static string Alteracao => "Registro alterado com sucesso.";
        public static string Exclusao => "Registro excluído com sucesso.";
        public static string Erro => "Erro na execução da operação.";
    }

    public enum CodigoMensagem
    {
        Inclusao = 0,
        Alteracao = 1,
        Exclusao = 2,
        Erro = 901
    }
}
