
using System.Data;

namespace FSP.Engengaria.Core.Infra.Data.Interface
{
    public interface IUnitOfWorkTransaction
    {
        void OpenConnection();
        void BeginTransaction();
        void SaveChange();
        void Commit();
        void Rollback();
        void CloseConnection();
    }
}
