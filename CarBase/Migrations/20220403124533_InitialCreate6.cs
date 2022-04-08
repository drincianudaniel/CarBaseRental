using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBase.Migrations
{
    public partial class InitialCreate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_makes_makeID",
                table: "vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_makes",
                table: "makes");

            migrationBuilder.RenameTable(
                name: "makes",
                newName: "make");

            migrationBuilder.AddPrimaryKey(
                name: "PK_make",
                table: "make",
                column: "makeID");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_make_makeID",
                table: "vehicles",
                column: "makeID",
                principalTable: "make",
                principalColumn: "makeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_make_makeID",
                table: "vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_make",
                table: "make");

            migrationBuilder.RenameTable(
                name: "make",
                newName: "makes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_makes",
                table: "makes",
                column: "makeID");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_makes_makeID",
                table: "vehicles",
                column: "makeID",
                principalTable: "makes",
                principalColumn: "makeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
