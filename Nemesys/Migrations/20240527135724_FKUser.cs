using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Migrations
{
    public partial class FKUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reports",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2ef1044-d4ad-4933-881f-840f734f6fa5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff9f2db6-3ed0-48b6-9a94-9fd2d74a5ec8", "AQAAAAEAACcQAAAAEC6bPnaSNFWu436IJg3pGI7rVn4Z/CKpnCvp0I/LT9ittGLu7SB90Cr39FUKpQ6KSA==", "063f637f-dde8-4802-936b-54b3c1557e36" });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserId",
                table: "Reports",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_UserId",
                table: "Reports",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_UserId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_UserId",
                table: "Reports");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2ef1044-d4ad-4933-881f-840f734f6fa5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fcf7068-d914-4338-9388-f6e770b11c78", "AQAAAAEAACcQAAAAEDdJlqYtGzTI5/rdGpevDjhBWyxEPu5sNC6hXK3HmzQMlh3MQRDWMdwzpk3ZxSdP1A==", "10b0e49c-3532-4074-ab77-9d0bbd3006c2" });
        }
    }
}
