using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CosmeticFinder.Migrations
{
    public partial class addQuiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    choiceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionsID);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswersID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    QuestionsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswersID);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionsID",
                        column: x => x.QuestionsID,
                        principalTable: "Questions",
                        principalColumn: "QuestionsID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionsID",
                table: "Answers",
                column: "QuestionsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
