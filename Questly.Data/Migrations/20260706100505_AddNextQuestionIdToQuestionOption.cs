using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Questly.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNextQuestionIdToQuestionOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NextQuestionId",
                table: "QuestionOptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOptions_NextQuestionId",
                table: "QuestionOptions",
                column: "NextQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionOptions_Questions_NextQuestionId",
                table: "QuestionOptions",
                column: "NextQuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionOptions_Questions_NextQuestionId",
                table: "QuestionOptions");

            migrationBuilder.DropIndex(
                name: "IX_QuestionOptions_NextQuestionId",
                table: "QuestionOptions");

            migrationBuilder.DropColumn(
                name: "NextQuestionId",
                table: "QuestionOptions");
        }
    }
}
