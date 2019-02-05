using FSP.Engengaria.Core.Domain.Entity;
using System.Linq;

namespace FSP.Engengaria.Core.Domain.Interface.Repository
{
    public interface IObraRepository: IRepository<Obra>
    {
        IQueryable<Obra> ObterObraPorDescricao(string nomeObra);
    }
}
