using APIBanco.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIBanco.Infrastructure.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<EnderecoCliente>
    {
        public void Configure(EntityTypeBuilder<EnderecoCliente> builder)
        {
            builder.ToTable("EnderecoCliente");

            builder.HasKey(x=>x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.CEP)
                .HasColumnType("int")
                .HasColumnName("cep")
                .IsRequired();

            builder.Property(x => x.Bairro)
                .IsRequired()
                .HasColumnName("bairro")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.UF)
                .IsRequired()
                .HasColumnName("uf")
                .HasColumnType("varchar(2)")
                .HasMaxLength(2);

            builder.Property(x => x.Cidade)
                .IsRequired()
                .HasColumnName("cidade")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(x => x.Endereco)
                .IsRequired()
                .HasColumnName("endereco")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.tipoCEP)
                .IsRequired()
                .HasColumnType("varchar(20)")
                .HasColumnName("tipocep")
                .HasMaxLength(20);
            
        }
    }
}
