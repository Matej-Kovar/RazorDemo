using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPages25P3A.Migrations
{
    /// <inheritdoc />
    public partial class ahoj3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "1b02e3d9-c6aa-44df-9182-bebeb240d69c", true, "A@B.C", "AQAAAAIAAYagAAAAEARDV/JhVEdWagEwdQh690q8CsTUjYGvAARRI6q0oCNFEpO+Ye+sIZgv6jtERd9zMw==", "a@b.c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "7e83db0a-9d17-4806-97db-1a75a30f114b", false, "ADMIN", "AQAAAAIAAYagAAAAEIsl7p1YFKZDZnGS5G+Y1vPifQ9UmAFIOdcGMeVYN2BsByrwuTucElf2SuyQFj7V3A==", "admin" });
        }
    }
}
