using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetInfra.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_AgTips_AgTipId1",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_AgTipId1",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "AgTipId1",
                table: "Computers");

            migrationBuilder.AlterColumn<int>(
                name: "AgTipId",
                table: "Computers",
                nullable: true,
                oldClrType: typeof(byte),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computers_AgTipId",
                table: "Computers",
                column: "AgTipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_AgTips_AgTipId",
                table: "Computers",
                column: "AgTipId",
                principalTable: "AgTips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_AgTips_AgTipId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_AgTipId",
                table: "Computers");

            migrationBuilder.AlterColumn<byte>(
                name: "AgTipId",
                table: "Computers",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgTipId1",
                table: "Computers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computers_AgTipId1",
                table: "Computers",
                column: "AgTipId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_AgTips_AgTipId1",
                table: "Computers",
                column: "AgTipId1",
                principalTable: "AgTips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
