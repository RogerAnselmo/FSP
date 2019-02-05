using FSP.Engengaria.Core.Domain.Entity;
using System;
using System.Linq;

namespace FSP.Engengaria.Core.Domain.Interface.Service
{
    public interface IObraService : IDisposable
    {
        Obra Salvar(Obra obra);
        Obra Alterar(Obra obra);
        void Excluir(int id);
        Obra ObterPorId(int id);
        IQueryable<Obra> ObterTodasObras();
        IQueryable<Obra> ObterObraPorDescricao(string nomeObra);
    }
}
