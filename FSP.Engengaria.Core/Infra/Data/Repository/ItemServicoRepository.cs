using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Interface.Repository;
using FSP.Engengaria.Core.Infra.Data.Context;
using FSP.Engengaria.Core.Infra.Data.Repository.SQL;
using System.Linq;

namespace FSP.Engengaria.Core.Infra.Data.Repository
{
    public class ItemServicoRepository : Repository<ItemServico>, IItemServicoRepository
    {
        public ItemServicoRepository(FSPContext context)
            : base(context)
        {

        }

        public int ObterProximoNumeroItemDoServico(int codigoObra, int codigoServico)
        {
            return base.Obter<ItemServico>(ComandoSqlItemServico.Instrucao.ObterProximoValorItemDoServico, new { codigoObra, codigoServico }).FirstOrDefault().NumeroOrdem;
        }

        public IQueryable<ItemServico> ObterItemServicoPorCodigoObraECodigoServico(int codigoObra, int codigoServico)
        {
            return Buscar(ex => ex.CodigoObra == codigoObra && ex.CodigoServico == codigoServico);
        }

        public IQueryable<ItemServico> ObterItemServicoDaObraEDoServicoParaPedidoMaterial(int codigoObra, int codigoServico)
        {
            return base.Obter<ItemServico>(ComandoSqlItemServico.Instrucao.ObterItemServicoDaObraEDoServicoParaPedidoMaterial, new { codigoObra, codigoServico }).AsQueryable();
        }
    }
}
