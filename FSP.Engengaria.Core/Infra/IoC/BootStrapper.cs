using FSP.Engengaria.Core.Application.Interface;
using FSP.Engengaria.Core.Application.Services;
using FSP.Engengaria.Core.Domain.Interface.Repository;
using FSP.Engengaria.Core.Domain.Interface.Service;
using FSP.Engengaria.Core.Domain.Services;
using FSP.Engengaria.Core.Infra.Data.Context;
using FSP.Engengaria.Core.Infra.Data.Interface;
using FSP.Engengaria.Core.Infra.Data.Repository;
using FSP.Engengaria.Core.Infra.Data.UoW;
using SimpleInjector;

namespace FSP.Engengaria.Core.Infra.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // App
            container.Register<IFSPAppService, FSPAppService>(Lifestyle.Scoped);
            // Domain
            container.Register<IObraService, ObraService>(Lifestyle.Scoped);
            container.Register<IServicoService, ServicoService>(Lifestyle.Scoped);
            container.Register<IFornecedorService, FornecedorService>(Lifestyle.Scoped);
            container.Register<IItemServicoService, ItemServicoService>(Lifestyle.Scoped);

            // Infra Dados
            container.Register<IObraRepository, ObraRepository>(Lifestyle.Scoped);
            container.Register<IServicoRepository, ServicoRepository>(Lifestyle.Scoped);
            container.Register<IFornecedorRepository, FornecedorRepository>(Lifestyle.Scoped);
            container.Register<IItemServicoRepository, ItemServicoRepository>(Lifestyle.Scoped);

            container.Register<IUnitOfWorkTransaction, UnitOfWorkTransaction>(Lifestyle.Scoped);
            container.Register<FSPContext>(Lifestyle.Scoped);

            // Logging
            //container.Register<ILogAuditoria, LogAuditoriaHelper>(Lifestyle.Scoped);
            //container.Register<LogginContext>(Lifestyle.Scoped);
        }
    }
}