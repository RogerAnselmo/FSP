using EP.CrudModalDDD.Infra.Data.EntityConfig;
using FSP.Engengaria.Core.Domain.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FSP.Engengaria.Core.Infra.Data.Context
{
    public class FSPContext : DbContext
    {
        static FSPContext()
        {
            Database.SetInitializer<FSPContext>(null);
        }

        public FSPContext()
            : base("Name=FSPContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Obra> Obra { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<ItemServico> ItemServico { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ObraConfig());
            modelBuilder.Configurations.Add(new ServicoConfig());
            modelBuilder.Configurations.Add(new FornecedorConfig());
            modelBuilder.Configurations.Add(new ItemServicoConfig());
        }
    }
}
