using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Migrations
{
    public partial class AddStatusIdToReportInvestigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2ef1044-d4ad-4933-881f-840f734f6fa5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a36a53b-e7e3-4d02-8bcc-0f0609efb92b", "AQAAAAEAACcQAAAAENzSGf6woVig4ryPOgEw1zQhFLBy2TvTuesu/wFxhHqwTs+TWaj8SHBQx69n/ZSgQw==", "e503f3c7-5afd-4c13-9399-68d68fbd572e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2ef1044-d4ad-4933-881f-840f734f6fa5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd350483-a547-434d-aa70-28854998ccf3", "AQAAAAEAACcQAAAAEPyOl7/cFpnQHlwZw+6ysuxcbuAYeNY0LnxDDhBH5TcThagBSAVtWfJ0+lvJxAdssg==", "4211f9a0-43fc-4c3e-8e6c-c4d7ae20ef6f" });
        }
    }
}
