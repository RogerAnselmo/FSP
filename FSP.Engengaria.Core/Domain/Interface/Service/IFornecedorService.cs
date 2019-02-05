using FSP.Engengaria.Core.Domain.Entity;
using System;
using System.Linq;

namespace FSP.Engengaria.Core.Domain.Interface.Service
{
    public interface IFornecedorService : IDisposable
    {
        Fornecedor Salvar(Fornecedor fornecedor);
        Fornecedor Alterar(Fornecedor fornecedor);
        void Excluir(int id);
        Fornecedor ObterPorId(int id);
        IQueryable<Fornecedor> ObterTodosFornecedors();
    }
}
