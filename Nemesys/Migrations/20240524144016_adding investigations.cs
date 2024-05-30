using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Migrations
{
    public partial class addinginvestigations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportInvestigation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportInvestigation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportInvestigation_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2ef1044-d4ad-4933-881f-840f734f6fa5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fcf7068-d914-4338-9388-f6e770b11c78", "AQAAAAEAACcQAAAAEDdJlqYtGzTI5/rdGpevDjhBWyxEPu5sNC6hXK3HmzQMlh3MQRDWMdwzpk3ZxSdP1A==", "10b0e49c-3532-4074-ab77-9d0bbd3006c2" });

            migrationBuilder.CreateIndex(
                name: "IX_ReportInvestigation_ReportId",
                table: "ReportInvestigation",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportInvestigation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2ef1044-d4ad-4933-881f-840f734f6fa5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8b57df3-82f0-4f38-865a-e755d1f20f03", "AQAAAAEAACcQAAAAEGjSWsh7mtZjFm7G6+RgTks1sy4h3siZ5+zUEYsLs1tOymn/MKQVt4poWWEUKw39Xg==", "32336314-d619-4ea6-b9af-cf0628b77021" });
        }
    }
}
