using DomainValidation.Validation;
using FSP.Engengaria.Core.Domain.Validations.Servicos;

namespace FSP.Engengaria.Core.Domain.Entity
{
    public class Fornecedor
    {
        public int CodigoFornecedor{ get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string NomeResponsavel { get; set; }
        public string Fone { get; set; }
        public string Celular { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }
        public string TipoContaCorrente { get; set; }

        public ValidationResult ValidationResult { get; set; }
        public bool IsValid()
        {
            ValidationResult = new FornecedorEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
