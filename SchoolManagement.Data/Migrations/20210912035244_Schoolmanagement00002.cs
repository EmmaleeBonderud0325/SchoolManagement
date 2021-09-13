using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Master",
                table: "Class",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 12, 3, 52, 42, 402, DateTimeKind.Utc).AddTicks(9177), new DateTime(2021, 9, 12, 3, 52, 42, 402, DateTimeKind.Utc).AddTicks(9854) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 12, 3, 52, 42, 403, DateTimeKind.Utc).AddTicks(1878), new DateTime(2021, 9, 12, 3, 52, 42, 403, DateTimeKind.Utc).AddTicks(1882) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 12, 3, 52, 42, 427, DateTimeKind.Utc).AddTicks(3358), new DateTime(2021, 9, 12, 3, 52, 42, 427, DateTimeKind.Utc).AddTicks(4163) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 12, 3, 52, 42, 427, DateTimeKind.Utc).AddTicks(7427), new DateTime(2021, 9, 12, 3, 52, 42, 427, DateTimeKind.Utc).AddTicks(7432) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Master",
                table: "Class");

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 9, 15, 30, 39, 214, DateTimeKind.Utc).AddTicks(2715), new DateTime(2021, 9, 9, 15, 30, 39, 214, DateTimeKind.Utc).AddTicks(2953) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 9, 15, 30, 39, 214, DateTimeKind.Utc).AddTicks(3645), new DateTime(2021, 9, 9, 15, 30, 39, 214, DateTimeKind.Utc).AddTicks(3647) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 9, 15, 30, 39, 225, DateTimeKind.Utc).AddTicks(6309), new DateTime(2021, 9, 9, 15, 30, 39, 225, DateTimeKind.Utc).AddTicks(6757) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 9, 15, 30, 39, 225, DateTimeKind.Utc).AddTicks(8312), new DateTime(2021, 9, 9, 15, 30, 39, 225, DateTimeKind.Utc).AddTicks(8315) });
        }
    }
}
