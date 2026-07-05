using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Questly.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSurveyTemplateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOfficial = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyTemplateQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    SurveyTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyTemplateQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyTemplateQuestions_SurveyTemplates_SurveyTemplateId",
                        column: x => x.SurveyTemplateId,
                        principalTable: "SurveyTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyTemplateOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    SurveyTemplateQuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyTemplateOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyTemplateOptions_SurveyTemplateQuestions_SurveyTemplateQuestionId",
                        column: x => x.SurveyTemplateQuestionId,
                        principalTable: "SurveyTemplateQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyTemplateOptions_SurveyTemplateQuestionId",
                table: "SurveyTemplateOptions",
                column: "SurveyTemplateQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyTemplateQuestions_SurveyTemplateId",
                table: "SurveyTemplateQuestions",
                column: "SurveyTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyTemplateOptions");

            migrationBuilder.DropTable(
                name: "SurveyTemplateQuestions");

            migrationBuilder.DropTable(
                name: "SurveyTemplates");
        }
    }
}
