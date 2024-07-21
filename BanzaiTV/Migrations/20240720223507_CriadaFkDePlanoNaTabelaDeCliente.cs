using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanzaiTV.Migrations
{
    /// <inheritdoc />
    public partial class CriadaFkDePlanoNaTabelaDeCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPagamento",
                table: "Mensalidades",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PlanoId",
                table: "Clientes",
                column: "PlanoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Planos_PlanoId",
                table: "Clientes",
                column: "PlanoId",
                principalTable: "Planos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Planos_PlanoId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_PlanoId",
                table: "Clientes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPagamento",
                table: "Mensalidades",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);
        }
    }
}
