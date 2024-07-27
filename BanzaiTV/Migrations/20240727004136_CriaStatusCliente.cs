using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanzaiTV.Migrations
{
    /// <inheritdoc />
    public partial class CriaStatusCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Clientes",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Clientes");
        }
    }
}
