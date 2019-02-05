using FSP.Engengaria.Core.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace EP.CrudModalDDD.Infra.Data.EntityConfig
{
    // Fluent API
    public class ServicoConfig : EntityTypeConfiguration<Servico>
    {
        public ServicoConfig()
        {
            ToTable("servico", "dbo");

            HasKey(e => e.CodigoServico);
            Property(t => t.CodigoServico)
                .HasColumnName("idservico")
                .IsRequired();

            Property(e => e.DescricaoServico)
                .HasColumnName("dsservico")
                .HasMaxLength(200)
                .IsRequired();

            Property(e => e.Percentual)
                .HasColumnName("percentual")
                .HasPrecision(18,2)
                .IsRequired();

            Property(e => e.Valor)
                .HasColumnName("valor")
                .HasPrecision(18, 2)
                .IsRequired();

            Ignore(c => c.ValidationResult);
        }
    }
}