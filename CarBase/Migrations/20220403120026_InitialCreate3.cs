using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBase.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentedVehicles_vehicles_VehicleID",
                table: "RentedVehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentedVehicles",
                table: "RentedVehicles");

            migrationBuilder.DropIndex(
                name: "IX_RentedVehicles_VehicleID",
                table: "RentedVehicles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RentedVehicles");

            migrationBuilder.RenameColumn(
                name: "VehicleID",
                table: "RentedVehicles",
                newName: "vehicleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentedVehicles",
                table: "RentedVehicles",
                columns: new[] { "vehicleID", "UsersID" });

            migrationBuilder.AddForeignKey(
                name: "FK_RentedVehicles_vehicles_vehicleID",
                table: "RentedVehicles",
                column: "vehicleID",
                principalTable: "vehicles",
                principalColumn: "vehicleID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentedVehicles_vehicles_vehicleID",
                table: "RentedVehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentedVehicles",
                table: "RentedVehicles");

            migrationBuilder.RenameColumn(
                name: "vehicleID",
                table: "RentedVehicles",
                newName: "VehicleID");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RentedVehicles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentedVehicles",
                table: "RentedVehicles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RentedVehicles_VehicleID",
                table: "RentedVehicles",
                column: "VehicleID");

            migrationBuilder.AddForeignKey(
                name: "FK_RentedVehicles_vehicles_VehicleID",
                table: "RentedVehicles",
                column: "VehicleID",
                principalTable: "vehicles",
                principalColumn: "vehicleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
