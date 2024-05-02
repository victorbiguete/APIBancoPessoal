﻿// <auto-generated />
using System;
using APIBanco.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIBanco.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIBanco.Domain.Model.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR(14)")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATETIME")
                        .HasColumnName("dataNascimento");

                    b.Property<DateTime?>("DataObito")
                        .HasColumnType("DATETIME")
                        .HasColumnName("dataObito");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("VARCHAR(180)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR(80)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR(30)")
                        .HasColumnName("password");

                    b.Property<decimal?>("Renda")
                        .HasColumnType("DECIMAL")
                        .HasColumnName("renda");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("APIBanco.Domain.Model.Conta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Agencia")
                        .HasMaxLength(1)
                        .HasColumnType("int")
                        .HasColumnName("agencia");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR(10)")
                        .HasColumnName("numero");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("DECIMAL")
                        .HasColumnName("saldo");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long?>("TitularId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TitularId")
                        .IsUnique()
                        .HasFilter("[TitularId] IS NOT NULL");

                    b.ToTable("Conta", (string)null);
                });

            modelBuilder.Entity("APIBanco.Domain.Model.Servicos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Qtde")
                        .HasColumnType("int");

                    b.Property<int?>("TarifaId")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TarifaId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("APIBanco.Domain.Model.Tarifa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Tarifa");
                });

            modelBuilder.Entity("APIBanco.Domain.Model.Conta", b =>
                {
                    b.HasOne("APIBanco.Domain.Model.Cliente", "Titular")
                        .WithOne("Contas")
                        .HasForeignKey("APIBanco.Domain.Model.Conta", "TitularId");

                    b.Navigation("Titular");
                });

            modelBuilder.Entity("APIBanco.Domain.Model.Servicos", b =>
                {
                    b.HasOne("APIBanco.Domain.Model.Tarifa", null)
                        .WithMany("Servicos")
                        .HasForeignKey("TarifaId");
                });

            modelBuilder.Entity("APIBanco.Domain.Model.Cliente", b =>
                {
                    b.Navigation("Contas")
                        .IsRequired();
                });

            modelBuilder.Entity("APIBanco.Domain.Model.Tarifa", b =>
                {
                    b.Navigation("Servicos");
                });
#pragma warning restore 612, 618
        }
    }
}
