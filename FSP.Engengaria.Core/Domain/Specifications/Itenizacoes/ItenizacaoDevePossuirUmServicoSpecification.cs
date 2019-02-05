using DomainValidation.Interfaces.Specification;
using FSP.Engengaria.Core.Domain.Entity;

namespace FSP.Engengaria.Core.Domain.Specifications.Itenizacoes
{
    public class ItenizacaoDevePossuirUmServicoSpecification : ISpecification<Itenizacao>
    {
        public bool IsSatisfiedBy(Itenizacao itenizacao)
        {
            return itenizacao.CodigoServico != 0 && itenizacao.CodigoServico > 0;
        }
    }
}
