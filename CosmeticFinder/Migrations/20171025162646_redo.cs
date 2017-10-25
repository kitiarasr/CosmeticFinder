using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CosmeticFinder.Migrations
{
    public partial class redo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SkinTypes");

            migrationBuilder.DropColumn(
                name: "ratingScore",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Formulations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Finishs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Colors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SkinTypes",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ratingScore",
                table: "Ratings",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Formulations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Finishs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Colors",
                nullable: true);
        }
    }
}
