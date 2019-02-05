using DomainValidation.Interfaces.Specification;
using FSP.Engengaria.Core.Domain.Entity;

namespace FSP.Engengaria.Core.Domain.Specifications.Itenizacoes
{
    public class ItemServicoDevePossuirValorUnitarioSpecification : ISpecification<ItemServico>
    {
        public bool IsSatisfiedBy(ItemServico itemServico)
        {
            return itemServico.ValorUnitario != 0 && itemServico.ValorUnitario > 0;
        }
    }
}
