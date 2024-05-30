using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Migrations
{
    public partial class statusId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ReportInvestigation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2ef1044-d4ad-4933-881f-840f734f6fa5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd350483-a547-434d-aa70-28854998ccf3", "AQAAAAEAACcQAAAAEPyOl7/cFpnQHlwZw+6ysuxcbuAYeNY0LnxDDhBH5TcThagBSAVtWfJ0+lvJxAdssg==", "4211f9a0-43fc-4c3e-8e6c-c4d7ae20ef6f" });

            migrationBuilder.CreateIndex(
                name: "IX_ReportInvestigation_StatusId",
                table: "ReportInvestigation",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportInvestigation_ReprotStatus_StatusId",
                table: "ReportInvestigation",
                column: "StatusId",
                principalTable: "ReprotStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportInvestigation_ReprotStatus_StatusId",
                table: "ReportInvestigation");

            migrationBuilder.DropIndex(
                name: "IX_ReportInvestigation_StatusId",
                table: "ReportInvestigation");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ReportInvestigation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2ef1044-d4ad-4933-881f-840f734f6fa5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f053d1e1-1364-4f83-8bcf-0883b10cd3a4", "AQAAAAEAACcQAAAAEPOzGiTAI8G6nRNkFPIpxnOazupnsMpsSB4/FqO9SO+Q7ua59yTuWpPE8I2EPCZRBA==", "f2da644e-0421-4865-bce6-d932b0f0734e" });
        }
    }
}
