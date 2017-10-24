using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CosmeticFinder.Migrations
{
    public partial class addCosmeticBagController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CosmeticBag_Items_CosmeticBag_CosmeticBagID",
                table: "CosmeticBag_Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CosmeticBag",
                table: "CosmeticBag");

            migrationBuilder.RenameTable(
                name: "CosmeticBag",
                newName: "CosmeticBags");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CosmeticBags",
                table: "CosmeticBags",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CosmeticBag_Items_CosmeticBags_CosmeticBagID",
                table: "CosmeticBag_Items",
                column: "CosmeticBagID",
                principalTable: "CosmeticBags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CosmeticBag_Items_CosmeticBags_CosmeticBagID",
                table: "CosmeticBag_Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CosmeticBags",
                table: "CosmeticBags");

            migrationBuilder.RenameTable(
                name: "CosmeticBags",
                newName: "CosmeticBag");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CosmeticBag",
                table: "CosmeticBag",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CosmeticBag_Items_CosmeticBag_CosmeticBagID",
                table: "CosmeticBag_Items",
                column: "CosmeticBagID",
                principalTable: "CosmeticBag",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
