using FSP.Engengaria.Core.Domain.Entity;
using System.Linq;

namespace FSP.Engengaria.Core.Domain.Interface.Repository
{
    public interface IItenizacaoRepository : IRepository<Itenizacao>
    {
        int ObterProximoNumeroItemDoServico(int codigoObra, int codigoServico);
        IQueryable<Itenizacao> ObterItenizacaoPorCodigoObraECodigoServico(int codigoObra, int codigoServico);
        IQueryable<Itenizacao> ObterItenizacaoDaObraEDoServicoParaPedidoMaterial(int codigoObra, int codigoServico);

    }
}
