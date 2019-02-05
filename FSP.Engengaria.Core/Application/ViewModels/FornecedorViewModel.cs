using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FSP.Engengaria.Core.Application.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        [DisplayName("Código")]
        public int CodigoFornecedor { get; set; }

        [DisplayName("Razão Social")]
        public string RazaoSocial { get; set; }

        [DisplayName("CNPJ")]
        public string CNPJ { get; set; }

        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [DisplayName("Bairro")]
        public string Bairro { get; set; }

        [DisplayName("Cidade")]
        public string Cidade { get; set; }

        [DisplayName("Estado")]
        public string UF { get; set; }

        [DisplayName("CEP")]
        public string CEP { get; set; }

        [DisplayName("Nome do Responsável")]
        public string NomeResponsavel { get; set; }

        [DisplayName("Fone")]
        public string Fone { get; set; }

        [DisplayName("Celular")]
        public string Celular { get; set; }

        [DisplayName("Banco")]
        public string Banco { get; set; }

        [DisplayName("Agência")]
        public string Agencia { get; set; }

        [DisplayName("Conta Corrente")]
        public string ContaCorrente { get; set; }

        [DisplayName("Tipo de Conta Corrente")]
        public string TipoContaCorrente { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
