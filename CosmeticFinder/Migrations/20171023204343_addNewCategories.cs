using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CosmeticFinder.Migrations
{
    public partial class addNewCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cosmetics_Color_ColorID",
                table: "Cosmetics");

            migrationBuilder.DropForeignKey(
                name: "FK_Cosmetics_Rating_RatingID",
                table: "Cosmetics");

            migrationBuilder.DropForeignKey(
                name: "FK_Cosmetics_SkinType_SkinTypeID",
                table: "Cosmetics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkinType",
                table: "SkinType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                table: "Color");

            migrationBuilder.RenameTable(
                name: "SkinType",
                newName: "SkinTypes");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameTable(
                name: "Color",
                newName: "Colors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkinTypes",
                table: "SkinTypes",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "CosmeticBag",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CosmeticBag", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CosmeticBag_Items",
                columns: table => new
                {
                    CosmeticID = table.Column<int>(type: "int", nullable: false),
                    CosmeticBagID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CosmeticBag_Items", x => new { x.CosmeticID, x.CosmeticBagID });
                    table.ForeignKey(
                        name: "FK_CosmeticBag_Items_CosmeticBag_CosmeticBagID",
                        column: x => x.CosmeticBagID,
                        principalTable: "CosmeticBag",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CosmeticBag_Items_Cosmetics_CosmeticID",
                        column: x => x.CosmeticID,
                        principalTable: "Cosmetics",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CosmeticBag_Items_CosmeticBagID",
                table: "CosmeticBag_Items",
                column: "CosmeticBagID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cosmetics_Colors_ColorID",
                table: "Cosmetics",
                column: "ColorID",
                principalTable: "Colors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cosmetics_Ratings_RatingID",
                table: "Cosmetics",
                column: "RatingID",
                principalTable: "Ratings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cosmetics_SkinTypes_SkinTypeID",
                table: "Cosmetics",
                column: "SkinTypeID",
                principalTable: "SkinTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cosmetics_Colors_ColorID",
                table: "Cosmetics");

            migrationBuilder.DropForeignKey(
                name: "FK_Cosmetics_Ratings_RatingID",
                table: "Cosmetics");

            migrationBuilder.DropForeignKey(
                name: "FK_Cosmetics_SkinTypes_SkinTypeID",
                table: "Cosmetics");

            migrationBuilder.DropTable(
                name: "CosmeticBag_Items");

            migrationBuilder.DropTable(
                name: "CosmeticBag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkinTypes",
                table: "SkinTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.RenameTable(
                name: "SkinTypes",
                newName: "SkinType");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rating");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "Color");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkinType",
                table: "SkinType",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                table: "Color",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cosmetics_Color_ColorID",
                table: "Cosmetics",
                column: "ColorID",
                principalTable: "Color",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cosmetics_Rating_RatingID",
                table: "Cosmetics",
                column: "RatingID",
                principalTable: "Rating",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cosmetics_SkinType_SkinTypeID",
                table: "Cosmetics",
                column: "SkinTypeID",
                principalTable: "SkinType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
