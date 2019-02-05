using DomainValidation.Interfaces.Specification;
using FSP.Engengaria.Core.Domain.Entity;

namespace FSP.Engengaria.Core.Domain.Specifications.Itenizacoes
{
    public class ItemServicoDevePossuirUmServicoSpecification : ISpecification<ItemServico>
    {
        public bool IsSatisfiedBy(ItemServico itemServico)
        {
            return itemServico.CodigoServico != 0 && itemServico.CodigoServico > 0;
        }
    }
}
