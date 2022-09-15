using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevFreela.Infrastructure.Persistence.Migrations
{
    public partial class updateColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_IdCliente",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Projects",
                newName: "IdClient");

            migrationBuilder.RenameColumn(
                name: "FinisheAt",
                table: "Projects",
                newName: "FinishedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_IdCliente",
                table: "Projects",
                newName: "IX_Projects_IdClient");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_IdClient",
                table: "Projects",
                column: "IdClient",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_IdClient",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "IdClient",
                table: "Projects",
                newName: "IdCliente");

            migrationBuilder.RenameColumn(
                name: "FinishedAt",
                table: "Projects",
                newName: "FinisheAt");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_IdClient",
                table: "Projects",
                newName: "IX_Projects_IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_IdCliente",
                table: "Projects",
                column: "IdCliente",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
