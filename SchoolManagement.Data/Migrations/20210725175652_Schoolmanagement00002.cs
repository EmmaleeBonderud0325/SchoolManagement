using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 23, 7, 50, 20, 841, DateTimeKind.Utc).AddTicks(3741), new DateTime(2021, 7, 23, 7, 50, 20, 841, DateTimeKind.Utc).AddTicks(4380) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 23, 7, 50, 20, 841, DateTimeKind.Utc).AddTicks(6370), new DateTime(2021, 7, 23, 7, 50, 20, 841, DateTimeKind.Utc).AddTicks(6376) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 23, 7, 50, 20, 866, DateTimeKind.Utc).AddTicks(2754), new DateTime(2021, 7, 23, 7, 50, 20, 866, DateTimeKind.Utc).AddTicks(3569) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 23, 7, 50, 20, 866, DateTimeKind.Utc).AddTicks(6809), new DateTime(2021, 7, 23, 7, 50, 20, 866, DateTimeKind.Utc).AddTicks(6814) });
        }
    }
}
