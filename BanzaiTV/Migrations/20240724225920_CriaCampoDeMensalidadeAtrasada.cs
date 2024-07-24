using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanzaiTV.Migrations
{
    /// <inheritdoc />
    public partial class CriaCampoDeMensalidadeAtrasada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Atrasada",
                table: "Mensalidades",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Atrasada",
                table: "Mensalidades");
        }
    }
}
