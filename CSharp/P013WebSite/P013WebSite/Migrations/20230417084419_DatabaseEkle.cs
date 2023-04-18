using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P013WebSite.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseEkle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 17, 11, 44, 19, 528, DateTimeKind.Local).AddTicks(9823));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 4, 17, 11, 44, 19, 528, DateTimeKind.Local).AddTicks(9827));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 17, 11, 44, 19, 528, DateTimeKind.Local).AddTicks(9698));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
