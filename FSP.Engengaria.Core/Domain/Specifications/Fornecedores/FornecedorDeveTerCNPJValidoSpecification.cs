using DomainValidation.Interfaces.Specification;
using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Validations.Documentos;

namespace FSP.Engengaria.Core.Domain.Specifications.Fornecedores
{
    public class FornecedorDeveTerCNPJValidoSpecification : ISpecification<Fornecedor>
    {
        public bool IsSatisfiedBy(Fornecedor fornecedor)
        {
            return CNPJValidation.Validar(fornecedor.CNPJ);
        }
    }
}
