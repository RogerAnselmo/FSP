using FSP.Engengaria.Core.Domain.Entity;
using System.Linq;

namespace FSP.Engengaria.Core.Domain.Interface.Repository
{
    public interface IServicoRepository : IRepository<Servico>
    {
        IQueryable<Servico> ObterServicoDaObraRelacionadosNaItenizacao(int codigoObra);
    }
}
