using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBase.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_engine_engineID",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_make_makeID",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_type_typeID",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "idengine",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "idmake",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "idtype",
                table: "vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "typeID",
                table: "vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "makeID",
                table: "vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "engineID",
                table: "vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_engine_engineID",
                table: "vehicles",
                column: "engineID",
                principalTable: "engine",
                principalColumn: "engineID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_make_makeID",
                table: "vehicles",
                column: "makeID",
                principalTable: "make",
                principalColumn: "makeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_type_typeID",
                table: "vehicles",
                column: "typeID",
                principalTable: "type",
                principalColumn: "typeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_engine_engineID",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_make_makeID",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_type_typeID",
                table: "vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "typeID",
                table: "vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "makeID",
                table: "vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "engineID",
                table: "vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "idengine",
                table: "vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idmake",
                table: "vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idtype",
                table: "vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_engine_engineID",
                table: "vehicles",
                column: "engineID",
                principalTable: "engine",
                principalColumn: "engineID");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_make_makeID",
                table: "vehicles",
                column: "makeID",
                principalTable: "make",
                principalColumn: "makeID");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_type_typeID",
                table: "vehicles",
                column: "typeID",
                principalTable: "type",
                principalColumn: "typeID");
        }
    }
}
