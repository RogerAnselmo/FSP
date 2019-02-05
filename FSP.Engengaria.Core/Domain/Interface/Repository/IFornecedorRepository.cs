using FSP.Engengaria.Core.Domain.Entity;
using System.Linq;

namespace FSP.Engengaria.Core.Domain.Interface.Repository
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Fornecedor ObterFornecedorPorCNPJ(string cnpj);
    }
}
