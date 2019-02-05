using DomainValidation.Validation;
using FSP.Engengaria.Core.Domain.Validations.Itenizacoes;

namespace FSP.Engengaria.Core.Domain.Entity
{
    public class Itenizacao
    {
        public int CodigoItenizacao { get; set; }
        public int CodigoObra { get; set; }
        public int CodigoServico { get; set; }
        public string NumeroItem { get; set; }
        public string DescricaoItem { get; set; }
        public string DescricaoUnidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public int NumeroOrdem { get; set; }

        public virtual Obra Obra { get; set; }
        public virtual Servico Servico { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new ItenizacaoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
