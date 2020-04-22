using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllCoreInOne.Data.Migrations
{
    public partial class Seed_departments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("28592590-89df-4f56-9ece-42f3f11f8055"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("7622c4fc-4b28-4c03-b103-f7ba170e5eba"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("fd2dc032-e4e1-4c6f-9301-9741efa271ea"));

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("664e2304-a162-4c61-831e-0775bcb4c593"), "Computer Science" });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("664e2304-a162-4c61-831e-0775bcb4c594"), "Business Administration" });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("664e2304-a162-4c61-831e-0775bcb4c595"), "Physics" });
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
                keyValue: new Guid("664e2304-a162-4c61-831e-0775bcb4c594"));

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: new Guid("664e2304-a162-4c61-831e-0775bcb4c595"));

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("7622c4fc-4b28-4c03-b103-f7ba170e5eba"), "Computer Science" });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("fd2dc032-e4e1-4c6f-9301-9741efa271ea"), "Business Administration" });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("28592590-89df-4f56-9ece-42f3f11f8055"), "Physics" });
        }
    }
}
