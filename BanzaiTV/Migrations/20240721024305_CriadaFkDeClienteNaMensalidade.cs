using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanzaiTV.Migrations
{
    /// <inheritdoc />
    public partial class CriadaFkDeClienteNaMensalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Mensalidades",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Mensalidades_ClienteId",
                table: "Mensalidades",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensalidades_Clientes_ClienteId",
                table: "Mensalidades",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensalidades_Clientes_ClienteId",
                table: "Mensalidades");

            migrationBuilder.DropIndex(
                name: "IX_Mensalidades_ClienteId",
                table: "Mensalidades");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Mensalidades");
        }
    }
}
