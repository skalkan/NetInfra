using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetInfra.Data.Migrations
{
    public partial class AddLatLonToComputer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Lat",
                table: "Computers",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Lon",
                table: "Computers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "Lon",
                table: "Computers");
        }
    }
}
