using DomainValidation.Validation;
using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Specifications.Fornecedores;

namespace FSP.Engengaria.Core.Domain.Validations.Servicos
{
    public class FornecedorEstaConsistenteValidation : Validator<Fornecedor>
    {
        public FornecedorEstaConsistenteValidation()
        {
            var CNPJFornecedor = new FornecedorDeveTerCNPJValidoSpecification();
            base.Add("CNPJFornecedor", new Rule<Fornecedor>(CNPJFornecedor, "Fornecedor informou um CPF inválido."));
        }
    }
}
