using APIBanco.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIBanco.Infrastructure.Mappings
{
    public class ContaMap: IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("Conta");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.Numero)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("numero")
                .HasColumnType("VARCHAR(10)");

            builder.Property(x => x.Agencia)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnName("agencia")
                .HasColumnType("int");

            builder.Property(x => x.Saldo)
                .HasColumnName("saldo")
                .HasColumnType("DECIMAL");

            builder.Property<long?>("TitularId")
                .HasColumnType("bigint");

            builder.HasIndex("TitularId")
                .IsUnique();

            

            builder.Property(x => x.Status)
                .HasConversion<int>();
        }
    }
}
