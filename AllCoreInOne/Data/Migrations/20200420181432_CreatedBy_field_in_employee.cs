using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllCoreInOne.Data.Migrations
{
    public partial class CreatedBy_field_in_employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: false);

        }
    }
}
