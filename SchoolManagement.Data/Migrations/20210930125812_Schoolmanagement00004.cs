using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                schema: "Lesson",
                table: "Lesson",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClassNameId",
                schema: "Lesson",
                table: "Lesson",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AcademicYearId",
                schema: "Lesson",
                table: "Lesson",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AcademicLevelId",
                schema: "Lesson",
                table: "Lesson",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                schema: "Lesson",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassNameId",
                schema: "Lesson",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AcademicYearId",
                schema: "Lesson",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AcademicLevelId",
                schema: "Lesson",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 12, 6, 10, 32, 65, DateTimeKind.Utc).AddTicks(7484), new DateTime(2021, 9, 12, 6, 10, 32, 65, DateTimeKind.Utc).AddTicks(8149) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 12, 6, 10, 32, 65, DateTimeKind.Utc).AddTicks(9372), new DateTime(2021, 9, 12, 6, 10, 32, 65, DateTimeKind.Utc).AddTicks(9377) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 12, 6, 10, 32, 76, DateTimeKind.Utc).AddTicks(7260), new DateTime(2021, 9, 12, 6, 10, 32, 76, DateTimeKind.Utc).AddTicks(7582) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 12, 6, 10, 32, 76, DateTimeKind.Utc).AddTicks(8791), new DateTime(2021, 9, 12, 6, 10, 32, 76, DateTimeKind.Utc).AddTicks(8793) });
        }
    }
}
