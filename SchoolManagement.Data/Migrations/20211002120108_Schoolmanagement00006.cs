using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentYear",
                schema: "Master",
                table: "AcademicYear",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 2, 12, 1, 6, 130, DateTimeKind.Utc).AddTicks(9524), new DateTime(2021, 10, 2, 12, 1, 6, 131, DateTimeKind.Utc).AddTicks(183) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 2, 12, 1, 6, 131, DateTimeKind.Utc).AddTicks(2195), new DateTime(2021, 10, 2, 12, 1, 6, 131, DateTimeKind.Utc).AddTicks(2200) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 2, 12, 1, 6, 158, DateTimeKind.Utc).AddTicks(994), new DateTime(2021, 10, 2, 12, 1, 6, 158, DateTimeKind.Utc).AddTicks(1828) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 10, 2, 12, 1, 6, 158, DateTimeKind.Utc).AddTicks(5653), new DateTime(2021, 10, 2, 12, 1, 6, 158, DateTimeKind.Utc).AddTicks(5658) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCurrentYear",
                schema: "Master",
                table: "AcademicYear");

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 30, 13, 22, 38, 933, DateTimeKind.Utc).AddTicks(3424), new DateTime(2021, 9, 30, 13, 22, 38, 933, DateTimeKind.Utc).AddTicks(3666) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 30, 13, 22, 38, 933, DateTimeKind.Utc).AddTicks(4318), new DateTime(2021, 9, 30, 13, 22, 38, 933, DateTimeKind.Utc).AddTicks(4320) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 30, 13, 22, 38, 943, DateTimeKind.Utc).AddTicks(9385), new DateTime(2021, 9, 30, 13, 22, 38, 943, DateTimeKind.Utc).AddTicks(9707) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 30, 13, 22, 38, 944, DateTimeKind.Utc).AddTicks(933), new DateTime(2021, 9, 30, 13, 22, 38, 944, DateTimeKind.Utc).AddTicks(935) });
        }
    }
}
