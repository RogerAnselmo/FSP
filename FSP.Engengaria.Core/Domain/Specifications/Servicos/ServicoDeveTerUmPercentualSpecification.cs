using DomainValidation.Interfaces.Specification;
using FSP.Engengaria.Core.Domain.Entity;

namespace FSP.Engengaria.Core.Domain.Specifications.Servicos
{
    public class ServicoDeveTerUmPercentualSpecification : ISpecification<Servico>
    {
        public bool IsSatisfiedBy(Servico servico)
        {
            return servico.Percentual != 0 && servico.Percentual > 0;
        }
    }
}
