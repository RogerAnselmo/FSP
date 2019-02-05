using FSP.Engengaria.Core.Domain.Entity;
using System;
using System.Linq;

namespace FSP.Engengaria.Core.Domain.Interface.Service
{
    public interface IItenizacaoService : IDisposable
    {
        Itenizacao Salvar(Itenizacao itenizacao);
        Itenizacao Alterar(Itenizacao itenizacao);
        void Excluir(int id);
        Itenizacao ObterPorId(int id);
        IQueryable<Itenizacao> ObterTodosItenizacao();
        int ObterProximoNumeroItemDoServico(int codigoObra, int codigoServico);
        IQueryable<Itenizacao> ObterItenizacaoPorCodigoObraECodigoServico(int codigoObra, int codigoServico);
        IQueryable<Itenizacao> ObterItenizacaoDaObraEDoServicoParaPedidoMaterial(int codigoObra, int codigoServico);
    }
}
