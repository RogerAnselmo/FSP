using FSP.Engengaria.Core.Domain.Entity;
using FSP.Engengaria.Core.Domain.Interface.Repository;
using FSP.Engengaria.Core.Infra.Data.Context;
using FSP.Engengaria.Core.Infra.Data.Repository.SQL;
using System.Linq;

namespace FSP.Engengaria.Core.Infra.Data.Repository
{
    public class ItenizacaoRepository : Repository<Itenizacao>, IItenizacaoRepository
    {
        public ItenizacaoRepository(FSPContext context)
            : base(context)
        {

        }

        public int ObterProximoNumeroItemDoServico(int codigoObra, int codigoServico)
        {
            return base.Obter<Itenizacao>(ComandoSqlItenizacao.Instrucao.ObterProximoValorItemDoServico, new { codigoObra, codigoServico }).FirstOrDefault().NumeroOrdem;
        }

        public IQueryable<Itenizacao> ObterItenizacaoPorCodigoObraECodigoServico(int codigoObra, int codigoServico)
        {
            return Buscar(ex => ex.CodigoObra == codigoObra && ex.CodigoServico == codigoServico);
        }

        public IQueryable<Itenizacao> ObterItenizacaoDaObraEDoServicoParaPedidoMaterial(int codigoObra, int codigoServico)
        {
            return base.Obter<Itenizacao>(ComandoSqlItenizacao.Instrucao.ObterItenizacaoDaObraEDoServicoParaPedidoMaterial, new { codigoObra, codigoServico }).AsQueryable();
        }
    }
}
