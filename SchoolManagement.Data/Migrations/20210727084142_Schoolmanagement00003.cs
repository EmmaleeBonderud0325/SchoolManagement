using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 27, 8, 41, 39, 696, DateTimeKind.Utc).AddTicks(2598), new DateTime(2021, 7, 27, 8, 41, 39, 696, DateTimeKind.Utc).AddTicks(2859) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 27, 8, 41, 39, 696, DateTimeKind.Utc).AddTicks(3970), new DateTime(2021, 7, 27, 8, 41, 39, 696, DateTimeKind.Utc).AddTicks(3973) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 27, 8, 41, 39, 709, DateTimeKind.Utc).AddTicks(7913), new DateTime(2021, 7, 27, 8, 41, 39, 709, DateTimeKind.Utc).AddTicks(8255) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 27, 8, 41, 39, 709, DateTimeKind.Utc).AddTicks(9539), new DateTime(2021, 7, 27, 8, 41, 39, 709, DateTimeKind.Utc).AddTicks(9541) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 25, 17, 56, 49, 458, DateTimeKind.Utc).AddTicks(1572), new DateTime(2021, 7, 25, 17, 56, 49, 458, DateTimeKind.Utc).AddTicks(1830) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 25, 17, 56, 49, 458, DateTimeKind.Utc).AddTicks(2560), new DateTime(2021, 7, 25, 17, 56, 49, 458, DateTimeKind.Utc).AddTicks(2563) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 25, 17, 56, 49, 468, DateTimeKind.Utc).AddTicks(3479), new DateTime(2021, 7, 25, 17, 56, 49, 468, DateTimeKind.Utc).AddTicks(3820) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 25, 17, 56, 49, 468, DateTimeKind.Utc).AddTicks(5038), new DateTime(2021, 7, 25, 17, 56, 49, 468, DateTimeKind.Utc).AddTicks(5041) });
        }
    }
}
