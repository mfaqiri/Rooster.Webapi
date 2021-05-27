using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Rooster.Storing.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Errands",
                columns: table => new
                {
                    EntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ErrandStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ErrandEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    UserEntityId = table.Column<int>(type: "integer", nullable: true),
                    Descr = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errands", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Errands_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Errands",
                columns: new[] { "EntityId", "Descr", "Duration", "ErrandEnd", "ErrandStart", "Title", "UserEntityId" },
                values: new object[] { 1, null, new TimeSpan(0, 0, 0, 0, 0), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 26, 19, 7, 4, 677, DateTimeKind.Local).AddTicks(6118), "Meeting", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "EntityId", "Email", "Password" },
                values: new object[] { 1, "johndoe@example.com", null });

            migrationBuilder.CreateIndex(
                name: "IX_Errands_UserEntityId",
                table: "Errands",
                column: "UserEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Errands");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
