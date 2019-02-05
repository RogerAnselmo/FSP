using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Interface.Repository;
using FSP.Engengaria.Core.Infra.Data.Context;
using System.Linq;

namespace FSP.Engengaria.Core.Infra.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(FSPContext context)
            : base(context)
        {

        }

        public Fornecedor ObterFornecedorPorCNPJ(string cnpj)
        {
            return Buscar(f => f.CNPJ == cnpj).FirstOrDefault();
        }
    }
}
