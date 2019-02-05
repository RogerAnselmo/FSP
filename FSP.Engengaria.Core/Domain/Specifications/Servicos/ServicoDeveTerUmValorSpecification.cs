using DomainValidation.Interfaces.Specification;
using FSP.Engengaria.Core.Domain.Entity;

namespace FSP.Engengaria.Core.Domain.Specifications.Servicos
{
    public class ServicoDeveTerUmValorSpecification : ISpecification<Servico>
    {
        public bool IsSatisfiedBy(Servico servico)
        {
            return servico.Valor != 0 && servico.Valor > 0;
        }
    }
}
