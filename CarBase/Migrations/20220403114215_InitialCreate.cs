using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBase.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteVehicles_Users_UsersID",
                table: "FavoriteVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_RentedVehicles_Users_UsersID",
                table: "RentedVehicles");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "RentedVehicles");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "FavoriteVehicles");

            migrationBuilder.AlterColumn<int>(
                name: "UsersID",
                table: "RentedVehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsersID",
                table: "FavoriteVehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteVehicles_Users_UsersID",
                table: "FavoriteVehicles",
                column: "UsersID",
                principalTable: "Users",
                principalColumn: "UsersID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentedVehicles_Users_UsersID",
                table: "RentedVehicles",
                column: "UsersID",
                principalTable: "Users",
                principalColumn: "UsersID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteVehicles_Users_UsersID",
                table: "FavoriteVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_RentedVehicles_Users_UsersID",
                table: "RentedVehicles");

            migrationBuilder.AlterColumn<int>(
                name: "UsersID",
                table: "RentedVehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "RentedVehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UsersID",
                table: "FavoriteVehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "FavoriteVehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteVehicles_Users_UsersID",
                table: "FavoriteVehicles",
                column: "UsersID",
                principalTable: "Users",
                principalColumn: "UsersID");

            migrationBuilder.AddForeignKey(
                name: "FK_RentedVehicles_Users_UsersID",
                table: "RentedVehicles",
                column: "UsersID",
                principalTable: "Users",
                principalColumn: "UsersID");
        }
    }
}
