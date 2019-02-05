using FSP.Engengaria.Core.Domain.Entity;
using System;
using System.Linq;

namespace FSP.Engengaria.Core.Domain.Interface.Service
{
    public interface IItemServicoService : IDisposable
    {
        ItemServico Salvar(ItemServico itemServico);
        ItemServico Alterar(ItemServico itemServico);
        void Excluir(int id);
        ItemServico ObterPorId(int id);
        IQueryable<ItemServico> ObterTodosItemServico();
        int ObterProximoNumeroItemDoServico(int codigoObra, int codigoServico);
        IQueryable<ItemServico> ObterItemServicoPorCodigoObraECodigoServico(int codigoObra, int codigoServico);
        IQueryable<ItemServico> ObterItemServicoDaObraEDoServicoParaPedidoMaterial(int codigoObra, int codigoServico);
    }
}
