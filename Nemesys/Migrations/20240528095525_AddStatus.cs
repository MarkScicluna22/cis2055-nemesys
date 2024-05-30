using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Migrations
{
    public partial class AddStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReprotStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReprotStatus", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2ef1044-d4ad-4933-881f-840f734f6fa5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f95211e-4e32-42d2-a563-f344c58ba5d1", "AQAAAAEAACcQAAAAEKEdpvwDLfES0cvgB6vD8Y1FhUxgBBWQOFlkhZiqgjKYPSykj8/vDXP9kmhdN+0hSg==", "e758a774-e1ac-47e7-9f0f-f15943792654" });

            migrationBuilder.InsertData(
                table: "ReprotStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "Being Investigated" },
                    { 3, "Closed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_StatusId",
                table: "Reports",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_ReprotStatus_StatusId",
                table: "Reports",
                column: "StatusId",
                principalTable: "ReprotStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_ReprotStatus_StatusId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "ReprotStatus");

            migrationBuilder.DropIndex(
                name: "IX_Reports_StatusId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Reports");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2ef1044-d4ad-4933-881f-840f734f6fa5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff9f2db6-3ed0-48b6-9a94-9fd2d74a5ec8", "AQAAAAEAACcQAAAAEC6bPnaSNFWu436IJg3pGI7rVn4Z/CKpnCvp0I/LT9ittGLu7SB90Cr39FUKpQ6KSA==", "063f637f-dde8-4802-936b-54b3c1557e36" });
        }
    }
}
