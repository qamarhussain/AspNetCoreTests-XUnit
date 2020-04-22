using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllCoreInOne.Data.Migrations
{
    public partial class SeedDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("664e2304-a162-4c61-831e-0775bcb4c593"), "Computer Science" });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("6bb48595-5017-4f06-a444-98df6998e6f8"), "Business Administration" });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a73b24bc-3fcd-4607-af1b-3c68caafd2c5"), "Physics" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("664e2304-a162-4c61-831e-0775bcb4c593"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("6bb48595-5017-4f06-a444-98df6998e6f8"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("a73b24bc-3fcd-4607-af1b-3c68caafd2c5"));
        }
    }
}
