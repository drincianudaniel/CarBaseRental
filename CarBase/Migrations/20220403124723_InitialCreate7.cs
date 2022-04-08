﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBase.Migrations
{
    public partial class InitialCreate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_engines_engineID",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_types_typeID",
                table: "vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_types",
                table: "types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_engines",
                table: "engines");

            migrationBuilder.RenameTable(
                name: "types",
                newName: "type");

            migrationBuilder.RenameTable(
                name: "engines",
                newName: "engine");

            migrationBuilder.AddPrimaryKey(
                name: "PK_type",
                table: "type",
                column: "typeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_engine",
                table: "engine",
                column: "engineID");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_engine_engineID",
                table: "vehicles",
                column: "engineID",
                principalTable: "engine",
                principalColumn: "engineID",
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
                name: "FK_vehicles_type_typeID",
                table: "vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_type",
                table: "type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_engine",
                table: "engine");

            migrationBuilder.RenameTable(
                name: "type",
                newName: "types");

            migrationBuilder.RenameTable(
                name: "engine",
                newName: "engines");

            migrationBuilder.AddPrimaryKey(
                name: "PK_types",
                table: "types",
                column: "typeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_engines",
                table: "engines",
                column: "engineID");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_engines_engineID",
                table: "vehicles",
                column: "engineID",
                principalTable: "engines",
                principalColumn: "engineID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_types_typeID",
                table: "vehicles",
                column: "typeID",
                principalTable: "types",
                principalColumn: "typeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
