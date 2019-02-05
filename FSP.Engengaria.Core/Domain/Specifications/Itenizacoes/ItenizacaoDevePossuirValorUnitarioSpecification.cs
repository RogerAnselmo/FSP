using DomainValidation.Interfaces.Specification;
using FSP.Engengaria.Core.Domain.Entity;

namespace FSP.Engengaria.Core.Domain.Specifications.Itenizacoes
{
    public class ItenizacaoDevePossuirValorUnitarioSpecification : ISpecification<Itenizacao>
    {
        public bool IsSatisfiedBy(Itenizacao itenizacao)
        {
            return itenizacao.ValorUnitario != 0 && itenizacao.ValorUnitario > 0;
        }
    }
}
