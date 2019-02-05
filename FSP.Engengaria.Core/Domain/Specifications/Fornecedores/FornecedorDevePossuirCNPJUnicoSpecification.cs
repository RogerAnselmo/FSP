using DomainValidation.Interfaces.Specification;
using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Interface.Repository;

namespace FSP.Engengaria.Core.Domain.Specifications.Fornecedores
{
    public class FornecedorDevePossuirCNPJUnicoSpecification : ISpecification<Fornecedor>
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorDevePossuirCNPJUnicoSpecification(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }
        public bool IsSatisfiedBy(Fornecedor fornecedor)
        {
            return _fornecedorRepository.ObterFornecedorPorCNPJ(fornecedor.CNPJ) == null;
        }
    }
}
