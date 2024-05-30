using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Migrations
{
    public partial class Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2ef1044-d4ad-4933-881f-840f734f6fa5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f053d1e1-1364-4f83-8bcf-0883b10cd3a4", "AQAAAAEAACcQAAAAEPOzGiTAI8G6nRNkFPIpxnOazupnsMpsSB4/FqO9SO+Q7ua59yTuWpPE8I2EPCZRBA==", "f2da644e-0421-4865-bce6-d932b0f0734e" });

            migrationBuilder.InsertData(
                table: "ReprotStatus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "No Action Needed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReprotStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2ef1044-d4ad-4933-881f-840f734f6fa5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f95211e-4e32-42d2-a563-f344c58ba5d1", "AQAAAAEAACcQAAAAEKEdpvwDLfES0cvgB6vD8Y1FhUxgBBWQOFlkhZiqgjKYPSykj8/vDXP9kmhdN+0hSg==", "e758a774-e1ac-47e7-9f0f-f15943792654" });
        }
    }
}
