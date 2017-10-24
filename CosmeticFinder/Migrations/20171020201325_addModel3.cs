using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CosmeticFinder.Migrations
{
    public partial class addModel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rating");

            migrationBuilder.AddColumn<double>(
                name: "ratingScore",
                table: "Rating",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ColorID",
                table: "Cosmetics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FinishID",
                table: "Cosmetics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cosmetics_ColorID",
                table: "Cosmetics",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Cosmetics_FinishID",
                table: "Cosmetics",
                column: "FinishID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cosmetics_Color_ColorID",
                table: "Cosmetics",
                column: "ColorID",
                principalTable: "Color",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cosmetics_Finishs_FinishID",
                table: "Cosmetics",
                column: "FinishID",
                principalTable: "Finishs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cosmetics_Color_ColorID",
                table: "Cosmetics");

            migrationBuilder.DropForeignKey(
                name: "FK_Cosmetics_Finishs_FinishID",
                table: "Cosmetics");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropIndex(
                name: "IX_Cosmetics_ColorID",
                table: "Cosmetics");

            migrationBuilder.DropIndex(
                name: "IX_Cosmetics_FinishID",
                table: "Cosmetics");

            migrationBuilder.DropColumn(
                name: "ratingScore",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "ColorID",
                table: "Cosmetics");

            migrationBuilder.DropColumn(
                name: "FinishID",
                table: "Cosmetics");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rating",
                nullable: true);
        }
    }
}
