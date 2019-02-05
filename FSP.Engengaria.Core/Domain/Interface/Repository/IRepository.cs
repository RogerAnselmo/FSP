using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FSP.Engengaria.Core.Domain.Interface.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(Int32 id);
        IQueryable<TEntity> ObterTodos();
        TEntity Atualizar(TEntity obj);
        void Remover(int id);
        IQueryable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
