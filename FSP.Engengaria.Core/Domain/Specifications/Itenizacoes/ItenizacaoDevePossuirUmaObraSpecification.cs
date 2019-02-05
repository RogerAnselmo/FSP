using DomainValidation.Interfaces.Specification;
using FSP.Engengaria.Core.Domain.Entity;

namespace FSP.Engengaria.Core.Domain.Specifications.Itenizacoes
{
    public class ItenizacaoDevePossuirUmaObraSpecification : ISpecification<Itenizacao>
    {
        public bool IsSatisfiedBy(Itenizacao itenizacao)
        {
            return itenizacao.CodigoObra != 0 && itenizacao.CodigoObra > 0;
        }
    }
}
