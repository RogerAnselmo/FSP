using FSP.Engengaria.Core.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace EP.CrudModalDDD.Infra.Data.EntityConfig
{
    // Fluent API
    public class ObraConfig : EntityTypeConfiguration<Obra>
    {
        public ObraConfig()
        {
            ToTable("obra", "dbo");
            HasKey(e => e.CodigoObra);
            Property(t => t.CodigoObra)
                .HasColumnName("idobra")
                .IsRequired();

            Property(e => e.DescricaoObjeto)
                .HasColumnName("dsobjeto")
                .HasMaxLength(300);

            Property(e => e.NomeObra)
                .HasColumnName("nmobra")
                .HasMaxLength(300);

            Property(e => e.Endereco)
                .HasColumnName("dsendereco")
                .HasMaxLength(100);

            Property(e => e.Bairro)
                .HasColumnName("dsbairro")
                .HasMaxLength(100);

            Property(e => e.Cidade)
                .HasColumnName("dscidade")
                .HasMaxLength(100);

            Property(e => e.UF)
                .HasColumnName("dsuf")
                .HasMaxLength(10);

            Property(e => e.CEP)
                .HasColumnName("nocep")
                .HasMaxLength(20);

            Property(e => e.Status)
                .HasColumnName("dsstatus")
                .HasMaxLength(30);

            Property(e => e.DataInicio)
                .HasColumnName("datainicio");

            Property(e => e.DataFim)
                .HasColumnName("datafim");

            Ignore(c => c.ValidationResult);

        }
    }
}