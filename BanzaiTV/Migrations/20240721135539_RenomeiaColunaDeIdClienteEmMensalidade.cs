using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanzaiTV.Migrations
{
    /// <inheritdoc />
    public partial class RenomeiaColunaDeIdClienteEmMensalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Mensalidades",
                newName: "ClienteId");

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

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Mensalidades",
                newName: "IdCliente");
        }
    }
}
