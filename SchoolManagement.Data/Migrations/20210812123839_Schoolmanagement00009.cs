using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "Master",
                table: "AcademicLevel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 12, 12, 38, 36, 556, DateTimeKind.Utc).AddTicks(7000), new DateTime(2021, 8, 12, 12, 38, 36, 556, DateTimeKind.Utc).AddTicks(7624) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 12, 12, 38, 36, 556, DateTimeKind.Utc).AddTicks(9656), new DateTime(2021, 8, 12, 12, 38, 36, 556, DateTimeKind.Utc).AddTicks(9662) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 12, 12, 38, 36, 586, DateTimeKind.Utc).AddTicks(7244), new DateTime(2021, 8, 12, 12, 38, 36, 586, DateTimeKind.Utc).AddTicks(8351) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 12, 12, 38, 36, 587, DateTimeKind.Utc).AddTicks(2736), new DateTime(2021, 8, 12, 12, 38, 36, 587, DateTimeKind.Utc).AddTicks(2747) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "Master",
                table: "AcademicLevel");

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 58, 30, 356, DateTimeKind.Utc).AddTicks(4637), new DateTime(2021, 8, 5, 10, 58, 30, 356, DateTimeKind.Utc).AddTicks(4882) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 58, 30, 356, DateTimeKind.Utc).AddTicks(5834), new DateTime(2021, 8, 5, 10, 58, 30, 356, DateTimeKind.Utc).AddTicks(5836) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 58, 30, 366, DateTimeKind.Utc).AddTicks(6081), new DateTime(2021, 8, 5, 10, 58, 30, 366, DateTimeKind.Utc).AddTicks(6383) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 5, 10, 58, 30, 366, DateTimeKind.Utc).AddTicks(7575), new DateTime(2021, 8, 5, 10, 58, 30, 366, DateTimeKind.Utc).AddTicks(7577) });
        }
    }
}
