using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Migrations
{
    public partial class addinglikefunctionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportLike",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportLike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportLike_Reports_ReportId",
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
                values: new object[] { "d8b57df3-82f0-4f38-865a-e755d1f20f03", "AQAAAAEAACcQAAAAEGjSWsh7mtZjFm7G6+RgTks1sy4h3siZ5+zUEYsLs1tOymn/MKQVt4poWWEUKw39Xg==", "32336314-d619-4ea6-b9af-cf0628b77021" });

            migrationBuilder.CreateIndex(
                name: "IX_ReportLike_ReportId",
                table: "ReportLike",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportLike");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2ef1044-d4ad-4933-881f-840f734f6fa5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40456200-b633-40c0-a225-b7d690ad8aea", "AQAAAAEAACcQAAAAEBXbInOjXgc26E+0cSC72m8X4lgtC6pRyXQYcSqajQoYPDAR+JgjeK15clC12ZbysA==", "e15ed93e-8332-4415-bbdc-1c69af1539fe" });
        }
    }
}
