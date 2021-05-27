using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rooster.Storing.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Errands",
                keyColumn: "EntityId",
                keyValue: 1,
                column: "ErrandStart",
                value: new DateTime(2021, 5, 26, 19, 22, 41, 950, DateTimeKind.Local).AddTicks(9928));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Errands",
                keyColumn: "EntityId",
                keyValue: 1,
                column: "ErrandStart",
                value: new DateTime(2021, 5, 26, 19, 7, 4, 677, DateTimeKind.Local).AddTicks(6118));
        }
    }
}
