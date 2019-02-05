using FSP.Engengaria.Core.Infra.Data.Interface;
using System.Data;

namespace FSP.Engengaria.Core.Application
{
    public class ApplicationServiceTransaction
    {
        private readonly IUnitOfWorkTransaction _uow;

        public ApplicationServiceTransaction(IUnitOfWorkTransaction uow)
        {
            _uow = uow;
        }
        public void OpenConnection()
        {
            _uow.OpenConnection();
        }
        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void SaveChange()
        {
            _uow.SaveChange();
        }
        public void Commit()
        {
            _uow.Commit();
        }
        public void Rollback()
        {
            _uow.Rollback();
        }

        public void CloseConnection()
        {
            _uow.CloseConnection();
        }
    }
}
