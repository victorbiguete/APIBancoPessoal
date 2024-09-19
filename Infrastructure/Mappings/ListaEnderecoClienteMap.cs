using APIBanco.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIBanco.Infrastructure.Mappings
{
    public class ListaEnderecoClienteMap : IEntityTypeConfiguration<Lista_Endereco_Cliente>
    {
        public void Configure(EntityTypeBuilder<Lista_Endereco_Cliente> builder)
        {
            builder.ToTable("Lista_Endereco_Cliente");

            builder.HasKey(x=>x.Id);

            builder.Property(x=>x.Id)
                .UseIdentityColumn()
                .HasColumnType("bigint");

            builder.Property(x => x.ClienteId)
                .HasColumnType("bigint");
            builder.HasIndex("ClienteId")
                .IsUnique();

            builder.Property(x => x.EnderecoId)
                .HasColumnType("bigint");
            builder.HasIndex(x=>x.EnderecoId)
                .IsUnique();
        }
    }
}
