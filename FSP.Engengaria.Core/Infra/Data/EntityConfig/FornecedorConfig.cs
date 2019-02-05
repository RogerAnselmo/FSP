using FSP.Engengaria.Core.Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace EP.CrudModalDDD.Infra.Data.EntityConfig
{
    // Fluent API
    public class FornecedorConfig : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfig()
        {
            ToTable("fornecedor", "dbo");

            HasKey(e => e.CodigoFornecedor);
            Property(t => t.CodigoFornecedor)
                .HasColumnName("idfornecedor")
                .IsRequired();

            Property(e => e.RazaoSocial)
                .HasColumnName("nmrazaosocial")
                .HasMaxLength(100)
                .IsRequired();

            Property(e => e.CNPJ)
                .HasColumnName("nocnpj")
                .HasMaxLength(20);

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

            Property(e => e.NomeResponsavel)
                .HasColumnName("nmresponsavel")
                .HasMaxLength(100);

            Property(e => e.Fone)
                .HasColumnName("nofone")
                .HasMaxLength(20);

            Property(e => e.Celular)
                .HasColumnName("nocelular")
                .HasMaxLength(20);

            Property(e => e.Banco)
                .HasColumnName("nmbanco")
                .HasMaxLength(20);

            Property(e => e.Agencia)
                .HasColumnName("noagencia")
                .HasMaxLength(20);

            Property(e => e.ContaCorrente)
                .HasColumnName("nocontacorrente")
                .HasMaxLength(20);

            Property(e => e.TipoContaCorrente)
                .HasColumnName("tpcontacorrente")
                .HasMaxLength(20);

            Ignore(c => c.ValidationResult);
        }
    }
}