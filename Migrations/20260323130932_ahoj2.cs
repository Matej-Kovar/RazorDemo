using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPages25P3A.Migrations
{
    /// <inheritdoc />
    public partial class ahoj2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash" },
                values: new object[] { "7e83db0a-9d17-4806-97db-1a75a30f114b", false, "AQAAAAIAAYagAAAAEIsl7p1YFKZDZnGS5G+Y1vPifQ9UmAFIOdcGMeVYN2BsByrwuTucElf2SuyQFj7V3A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash" },
                values: new object[] { "b21da04f-785c-42d6-b806-64dd56660bca", true, "AQAAAAIAAYagAAAAEDb3/0jluAsRCgBH5G+C3Qzdu5/6056r5OcO6bk6xan2htrMvLi0Q1DBnoJEZOoHjg==" });
        }
    }
}
