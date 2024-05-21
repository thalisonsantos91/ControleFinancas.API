using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinancas.API.Migrations
{
    /// <inheritdoc />
    public partial class CriarEntidadeAreceber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "areceber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ValorRecebido = table.Column<double>(type: "double precision", nullable: false),
                    DataRecebimento = table.Column<DateTime>(type: "timestamp", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdLancamento = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(256)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Observacao = table.Column<string>(type: "VARCHAR(256)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorOriginal = table.Column<double>(type: "double precision", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "timestamp", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "timestamp", nullable: false),
                    DataInativacao = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DataReferencia = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_areceber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_areceber_Lancamento_IdLancamento",
                        column: x => x.IdLancamento,
                        principalTable: "Lancamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_areceber_usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_areceber_IdLancamento",
                table: "areceber",
                column: "IdLancamento");

            migrationBuilder.CreateIndex(
                name: "IX_areceber_IdUsuario",
                table: "areceber",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "areceber");
        }
    }
}
