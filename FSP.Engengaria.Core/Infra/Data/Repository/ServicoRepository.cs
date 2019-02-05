using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Interface.Repository;
using FSP.Engengaria.Core.Infra.Data.Context;
using FSP.Engengaria.Core.Infra.Data.Repository.SQL;
using System.Linq;

namespace FSP.Engengaria.Core.Infra.Data.Repository
{
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        public ServicoRepository(FSPContext context)
            : base(context)
        {

        }
        public override IQueryable<Servico> ObterTodos()
        {
            return base.Obter<Servico>(ComandoSqlServico.Instrucao.ObterTodosServico, null).AsQueryable();
        }

        public IQueryable<Servico> ObterServicoDaObraRelacionadosNaItenizacao(int codigoObra)
        {
            return base.Obter<Servico>(ComandoSqlServico.Instrucao.ObterServicoDaObraRelacionadosNaItenizacao, new { codigoObra }).AsQueryable();
        }
    }
}
