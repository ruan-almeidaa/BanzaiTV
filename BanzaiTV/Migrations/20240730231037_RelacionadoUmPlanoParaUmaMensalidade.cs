using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanzaiTV.Migrations
{
    /// <inheritdoc />
    public partial class RelacionadoUmPlanoParaUmaMensalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanoId",
                table: "Mensalidades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mensalidades_PlanoId",
                table: "Mensalidades",
                column: "PlanoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensalidades_Planos_PlanoId",
                table: "Mensalidades",
                column: "PlanoId",
                principalTable: "Planos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensalidades_Planos_PlanoId",
                table: "Mensalidades");

            migrationBuilder.DropIndex(
                name: "IX_Mensalidades_PlanoId",
                table: "Mensalidades");

            migrationBuilder.DropColumn(
                name: "PlanoId",
                table: "Mensalidades");
        }
    }
}
