using Dapper;
using FSP.Engengaria.Core.Domain.Interface.Repository;
using FSP.Engengaria.Core.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace FSP.Engengaria.Core.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public FSPContext Db;
        public DbSet<TEntity> DbSet;

        public Repository(FSPContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objreturn = DbSet.Add(obj);
            return objreturn;
        }

        public virtual TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> ObterTodos()//(int s, int t)
        {
            return DbSet.AsQueryable(); //Take(t).Skip(s).ToList();
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return obj;
        }

        public virtual void Remover(int id)
        {
            var entity = DbSet.Find(id);
            DbSet.Remove(entity);
        }

        public IQueryable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        /// <summary>
        /// Execute Query Dapper
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="sqlString">string sqlString</param>
        /// <param name="objectParams">object objectParams</param>
        /// <returns>IEnumerable<T> ExecuteQuery<T></returns>
        public virtual IEnumerable<T> Obter<T>(string sqlString, object objectParams = null) where T : class
        {
            return Db.Database.Connection.Query<T>(sqlString, objectParams, commandType: CommandType.Text);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
