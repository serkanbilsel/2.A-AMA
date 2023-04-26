using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P013WebSite.Migrations
{
    /// <inheritdoc />
    public partial class SerkanBilselGorev7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 24, 20, 47, 42, 294, DateTimeKind.Local).AddTicks(6238));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 4, 24, 20, 47, 42, 294, DateTimeKind.Local).AddTicks(6245));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 24, 20, 47, 42, 294, DateTimeKind.Local).AddTicks(5866));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 10, 22, 5, 32, 880, DateTimeKind.Local).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 4, 10, 22, 5, 32, 880, DateTimeKind.Local).AddTicks(342));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 10, 22, 5, 32, 880, DateTimeKind.Local).AddTicks(150));
        }
    }
}
