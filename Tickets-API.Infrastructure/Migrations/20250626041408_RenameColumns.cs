using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tickets_API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nomeSolicitante",
                table: "Tickets",
                newName: "NomeSolicitante");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tickets",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeSolicitante",
                table: "Tickets",
                newName: "nomeSolicitante");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tickets",
                newName: "id");
        }
    }
}
