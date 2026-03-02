using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPages25P3A.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FormIMs",
                table: "FormIMs");

            migrationBuilder.RenameTable(
                name: "FormIMs",
                newName: "FormModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormModels",
                table: "FormModels",
                column: "FormModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FormModels",
                table: "FormModels");

            migrationBuilder.RenameTable(
                name: "FormModels",
                newName: "FormIMs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormIMs",
                table: "FormIMs",
                column: "FormModelId");
        }
    }
}
