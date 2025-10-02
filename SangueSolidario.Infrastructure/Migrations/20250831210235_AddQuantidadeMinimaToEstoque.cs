using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SangueSolidario.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantidadeMinimaToEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
               name: "QuantidadeMinimaML",
               table: "EstoquesSangue",
               type: "int",
               nullable: false,
               defaultValue: 0); // valor padrão para registros existentes
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeMinimaML",
                table: "EstoquesSangue");
        }
    }
}
