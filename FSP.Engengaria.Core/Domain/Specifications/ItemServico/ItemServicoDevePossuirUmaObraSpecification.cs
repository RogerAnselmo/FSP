using DomainValidation.Interfaces.Specification;
using FSP.Engengaria.Core.Domain.Entity;

namespace FSP.Engengaria.Core.Domain.Specifications.Itenizacoes
{
    public class ItemServicoDevePossuirUmaObraSpecification : ISpecification<ItemServico>
    {
        public bool IsSatisfiedBy(ItemServico itemServico)
        {
            return itemServico.CodigoObra != 0 && itemServico.CodigoObra > 0;
        }
    }
}
