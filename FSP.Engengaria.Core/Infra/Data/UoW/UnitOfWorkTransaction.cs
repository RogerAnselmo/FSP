using FSP.Engengaria.Core.Infra.Data.Context;
using FSP.Engengaria.Core.Infra.Data.Interface;
using System.Data;
using System.Data.Common;
using System.Data.Entity;

namespace FSP.Engengaria.Core.Infra.Data.UoW
{
    public class UnitOfWorkTransaction : IUnitOfWorkTransaction
    {
        private readonly FSPContext _db;
        public DbConnection DataBaseConnection { get; set; }
        public DbContextTransaction Transaction { get; set; }

        public UnitOfWorkTransaction(FSPContext db)
        {
            _db = db;
        }

        public void OpenConnection()
        {
            //_db.Database.Connection.Open();
        }

        public void BeginTransaction()
        {
            Transaction = _db.Database.BeginTransaction();
        }

        public void SaveChange()
        {
            _db.SaveChanges();
        }

        public void Commit()
        {
            Transaction.Commit();
        }

        public void Rollback()
        {
            if (Transaction != null)
                Transaction.Rollback();
        }

        public void CloseConnection()
        {
            //_db.Database.Connection.Close();
        }
    }
}
