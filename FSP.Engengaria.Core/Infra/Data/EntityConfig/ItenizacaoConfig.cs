using FSP.Engengaria.Core.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace EP.CrudModalDDD.Infra.Data.EntityConfig
{
    // Fluent API
    public class ItenizacaoConfig : EntityTypeConfiguration<Itenizacao>
    {
        public ItenizacaoConfig()
        {
            ToTable("itenizacao", "dbo");

            HasKey(e => e.CodigoItenizacao);

            Property(t => t.CodigoItenizacao)
                .HasColumnName("iditenizacao")
                .IsRequired();

            Property(t => t.CodigoObra)
                .HasColumnName("idobra")
                .IsRequired();

            Property(t => t.CodigoServico)
                .HasColumnName("idservico")
                .IsRequired();

            Property(e => e.NumeroItem)
                .HasColumnName("noitem")
                .HasMaxLength(20)
                .IsRequired();

            Property(e => e.DescricaoItem)
                .HasColumnName("dsitem")
                .HasMaxLength(200)
                .IsRequired();

            Property(e => e.DescricaoUnidade)
                .HasColumnName("dsunidade")
                .HasMaxLength(10)
                .IsRequired();

            Property(e => e.ValorUnitario)
                .HasColumnName("vlvalorunitario")
                .HasPrecision(18, 2)
                .IsRequired();

            Property(e => e.NumeroOrdem)
                .HasColumnName("noordem");

            HasRequired(e => e.Obra)
                .WithMany(c => c.Itenizacoes)
                .HasForeignKey(e => e.CodigoObra);

            HasRequired(e => e.Servico)
                .WithMany(c => c.Itenizacoes)
                .HasForeignKey(e => e.CodigoServico);

            Ignore(c => c.ValidationResult);
        }
    }
}