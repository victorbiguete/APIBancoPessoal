using APIBanco.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIBanco.Infrastructure.Mappings
{
    public class ClienteMap:IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(x=>x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("cpf")
                .HasColumnType("VARCHAR(11)");

            builder.Property(x => x.Renda)
                .IsRequired(false)
                .HasColumnName("renda")
                .HasColumnType("DECIMAL");

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("password")
                .HasColumnType("VARCHAR(30)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(180)");

            builder.Property(x=>x.DataNascimento)
                .IsRequired()
                .HasColumnName("dataNascimento")
                .HasColumnType("DATETIME");

            builder.Property(x => x.DataObito)
                .IsRequired(false)
                .HasColumnName("dataObito")
                .HasColumnType("DATETIME");

            
        }

        
    }
}
