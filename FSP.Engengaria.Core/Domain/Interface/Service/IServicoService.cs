using FSP.Engengaria.Core.Domain.Entity;
using System;
using System.Linq;

namespace FSP.Engengaria.Core.Domain.Interface.Service
{
    public interface IServicoService : IDisposable
    {
        Servico Salvar(Servico Servico);
        Servico Alterar(Servico Servico);
        void Excluir(int id);
        Servico ObterPorId(int id);
        IQueryable<Servico> ObterTodosServicos();
        IQueryable<Servico> ObterServicoDaObraRelacionadosNaItenizacao(int codigoObra);
    }
}
