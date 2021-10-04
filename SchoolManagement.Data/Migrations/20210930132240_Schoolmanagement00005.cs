using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PlannedDate",
                schema: "Lesson",
                table: "Lesson",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletedDate",
                schema: "Lesson",
                table: "Lesson",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PlannedDate",
                schema: "Lesson",
                table: "Lesson",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletedDate",
                schema: "Lesson",
                table: "Lesson",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 30, 12, 58, 9, 940, DateTimeKind.Utc).AddTicks(2024), new DateTime(2021, 9, 30, 12, 58, 9, 940, DateTimeKind.Utc).AddTicks(2670) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 30, 12, 58, 9, 940, DateTimeKind.Utc).AddTicks(4727), new DateTime(2021, 9, 30, 12, 58, 9, 940, DateTimeKind.Utc).AddTicks(4732) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 30, 12, 58, 9, 965, DateTimeKind.Utc).AddTicks(8872), new DateTime(2021, 9, 30, 12, 58, 9, 965, DateTimeKind.Utc).AddTicks(9696) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 30, 12, 58, 9, 966, DateTimeKind.Utc).AddTicks(3215), new DateTime(2021, 9, 30, 12, 58, 9, 966, DateTimeKind.Utc).AddTicks(3224) });
        }
    }
}
