namespace FSP.Engengaria.Core.Application.Validation
{
    public class ValidationResultViewModel
    {
        public int Erro { get; private set; }
        public string Mensagem { get; private set; }
        public int Id { get; set; }

        public ValidationResultViewModel() { }

        public ValidationResultViewModel(int Erro, string Mensagem, int Id = 0)
        {
            this.Erro = Erro;
            this.Mensagem = Mensagem;
            this.Id = Id;
        }

        public void AdicionarMensagemRetorno(int erro, string mensagem, int id = 0)
        {
            Erro = erro;
            Mensagem = mensagem;
            Id = id;
        }
    }
}
