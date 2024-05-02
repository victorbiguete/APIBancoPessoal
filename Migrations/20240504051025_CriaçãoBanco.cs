using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIBanco.Migrations
{
    /// <inheritdoc />
    public partial class CriaçãoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    cpf = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    renda = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: true),
                    dataNascimento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    dataObito = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    email = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false),
                    password = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarifa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    agencia = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    saldo = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    TitularId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conta_Cliente_TitularId",
                        column: x => x.TitularId,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Qtde = table.Column<int>(type: "int", nullable: false),
                    TarifaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicos_Tarifa_TarifaId",
                        column: x => x.TarifaId,
                        principalTable: "Tarifa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conta_TitularId",
                table: "Conta",
                column: "TitularId",
                unique: true,
                filter: "[TitularId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_TarifaId",
                table: "Servicos",
                column: "TarifaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Tarifa");
        }
    }
}
