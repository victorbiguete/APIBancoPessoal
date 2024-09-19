using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIBanco.Migrations
{
    /// <inheritdoc />
    public partial class AddEnderecosMIgration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnderecoCliente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cep = table.Column<int>(type: "int", nullable: false),
                    tipocep = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    uf = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    cidade = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    bairro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    endereco = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lista_Endereco_Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<long>(type: "BIGINT", nullable: false),
                    EnderecoId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lista_Endereco_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lista_Endereco_Clientes_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lista_Endereco_Clientes_EnderecoCliente_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "EnderecoCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lista_Endereco_Clientes_ClienteId",
                table: "Lista_Endereco_Clientes",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lista_Endereco_Clientes_EnderecoId",
                table: "Lista_Endereco_Clientes",
                column: "EnderecoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lista_Endereco_Clientes");

            migrationBuilder.DropTable(
                name: "EnderecoCliente");
        }
    }
}
