using DomainValidation.Validation;
using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Interface.Repository;
using FSP.Engengaria.Core.Domain.Specifications.Fornecedores;

namespace FSP.Engengaria.Core.Domain.Validations.Servicos
{
    public class FornecedorAptoParaCadastroValidation : Validator<Fornecedor>
    {
        public FornecedorAptoParaCadastroValidation(IFornecedorRepository fornecedorRepository)
        {
            var cnpJaCadastrado = new FornecedorDevePossuirCNPJUnicoSpecification(fornecedorRepository);
            base.Add("cnpJaCadastrado", new Rule<Fornecedor>(cnpJaCadastrado, "CNPJ já cadastrado."));
        }
    }
}
