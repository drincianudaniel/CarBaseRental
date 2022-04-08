using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBase.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteVehicles_vehicles_VehicleID",
                table: "FavoriteVehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteVehicles",
                table: "FavoriteVehicles");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteVehicles_VehicleID",
                table: "FavoriteVehicles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FavoriteVehicles");

            migrationBuilder.RenameColumn(
                name: "VehicleID",
                table: "FavoriteVehicles",
                newName: "vehicleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteVehicles",
                table: "FavoriteVehicles",
                columns: new[] { "vehicleID", "UsersID" });

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteVehicles_vehicles_vehicleID",
                table: "FavoriteVehicles",
                column: "vehicleID",
                principalTable: "vehicles",
                principalColumn: "vehicleID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteVehicles_vehicles_vehicleID",
                table: "FavoriteVehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteVehicles",
                table: "FavoriteVehicles");

            migrationBuilder.RenameColumn(
                name: "vehicleID",
                table: "FavoriteVehicles",
                newName: "VehicleID");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FavoriteVehicles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteVehicles",
                table: "FavoriteVehicles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteVehicles_VehicleID",
                table: "FavoriteVehicles",
                column: "VehicleID");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteVehicles_vehicles_VehicleID",
                table: "FavoriteVehicles",
                column: "VehicleID",
                principalTable: "vehicles",
                principalColumn: "vehicleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
