using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Interface.Repository;
using FSP.Engengaria.Core.Infra.Data.Context;
using FSP.Engengaria.Core.Infra.Data.Repository.SQL;
using System.Linq;

namespace FSP.Engengaria.Core.Infra.Data.Repository
{
    public class ObraRepository : Repository<Obra>, IObraRepository
    {
        public ObraRepository(FSPContext context)
            : base(context)
        {

        }

        public IQueryable<Obra> ObterObraPorDescricao(string nomeObra)
        {
            var NomeObra = "%" + nomeObra + "%";
            return base.Obter<Obra>(ComandoSqlObra.Instrucao.ObterObraPorDescricao, new { NomeObra }).AsQueryable();
        }
    }
}
