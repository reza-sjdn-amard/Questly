using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Questly.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameToTitleOfSurveyTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SurveyTemplates",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "SurveyTemplates",
                newName: "Name");
        }
    }
}
