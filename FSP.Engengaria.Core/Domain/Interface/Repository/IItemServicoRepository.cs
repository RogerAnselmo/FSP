using FSP.Engengaria.Core.Domain.Entity;
using System.Linq;

namespace FSP.Engengaria.Core.Domain.Interface.Repository
{
    public interface IItemServicoRepository : IRepository<ItemServico>
    {
        int ObterProximoNumeroItemDoServico(int codigoObra, int codigoServico);
        IQueryable<ItemServico> ObterItemServicoPorCodigoObraECodigoServico(int codigoObra, int codigoServico);
        IQueryable<ItemServico> ObterItemServicoDaObraEDoServicoParaPedidoMaterial(int codigoObra, int codigoServico);

    }
}
