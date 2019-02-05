using DomainValidation.Interfaces.Specification;
using FSP.Engengaria.Core.Domain.Entity;
using System.Linq;

namespace FSP.Engengaria.Core.Domain.Specifications.Obras
{
    public class ObraDeveTerUmaSituacaoSpecification : ISpecification<Obra>
    {
        public bool IsSatisfiedBy(Obra obra)
        {
            return obra.Status != null && obra.Status.Any();
        }
    }
}
