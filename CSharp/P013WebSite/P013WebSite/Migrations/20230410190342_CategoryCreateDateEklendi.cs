using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P013WebSite.Migrations
{
    /// <inheritdoc />
    public partial class CategoryCreateDateEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 10, 22, 3, 42, 327, DateTimeKind.Local).AddTicks(6156));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 4, 10, 22, 3, 42, 327, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 10, 22, 3, 42, 327, DateTimeKind.Local).AddTicks(6034));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 10, 21, 37, 14, 926, DateTimeKind.Local).AddTicks(1310));
        }
    }
}
