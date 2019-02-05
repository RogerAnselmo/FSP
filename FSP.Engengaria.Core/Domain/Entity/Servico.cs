using DomainValidation.Validation;
using FSP.Engengaria.Core.Domain.Validations.Servicos;
using System.Collections.Generic;

namespace FSP.Engengaria.Core.Domain.Entity
{
    public class Servico
    {
        public int CodigoServico{ get; set; }
        public string DescricaoServico { get; set; }
        public decimal Percentual { get; set; }
        public decimal Valor { get; set; }
        public virtual ICollection<ItemServico> ItensServicos { get; set; }

        public ValidationResult ValidationResult { get; set; }
        public bool IsValid()
        {
            ValidationResult = new ServicoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public Servico()
        {
            ItensServicos = new List<ItemServico>();
        }
    }
}
