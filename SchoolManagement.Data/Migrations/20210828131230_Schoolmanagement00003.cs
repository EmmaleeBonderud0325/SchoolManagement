using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripstion",
                schema: "Lesson",
                table: "LessonAssignment",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "DuetDate",
                schema: "Lesson",
                table: "LessonAssignment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                schema: "Lesson",
                table: "LessonAssignment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 28, 13, 12, 28, 481, DateTimeKind.Utc).AddTicks(9001), new DateTime(2021, 8, 28, 13, 12, 28, 481, DateTimeKind.Utc).AddTicks(9405) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 28, 13, 12, 28, 482, DateTimeKind.Utc).AddTicks(1251), new DateTime(2021, 8, 28, 13, 12, 28, 482, DateTimeKind.Utc).AddTicks(1261) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 28, 13, 12, 28, 493, DateTimeKind.Utc).AddTicks(7542), new DateTime(2021, 8, 28, 13, 12, 28, 493, DateTimeKind.Utc).AddTicks(7847) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 28, 13, 12, 28, 493, DateTimeKind.Utc).AddTicks(8994), new DateTime(2021, 8, 28, 13, 12, 28, 493, DateTimeKind.Utc).AddTicks(8996) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuetDate",
                schema: "Lesson",
                table: "LessonAssignment");

            migrationBuilder.DropColumn(
                name: "StartDate",
                schema: "Lesson",
                table: "LessonAssignment");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "Lesson",
                table: "LessonAssignment",
                newName: "Descripstion");

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 22, 16, 11, 13, 103, DateTimeKind.Utc).AddTicks(8924), new DateTime(2021, 8, 22, 16, 11, 13, 103, DateTimeKind.Utc).AddTicks(9833) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 22, 16, 11, 13, 104, DateTimeKind.Utc).AddTicks(2531), new DateTime(2021, 8, 22, 16, 11, 13, 104, DateTimeKind.Utc).AddTicks(2543) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 22, 16, 11, 13, 147, DateTimeKind.Utc).AddTicks(9455), new DateTime(2021, 8, 22, 16, 11, 13, 148, DateTimeKind.Utc).AddTicks(339) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 22, 16, 11, 13, 148, DateTimeKind.Utc).AddTicks(5312), new DateTime(2021, 8, 22, 16, 11, 13, 148, DateTimeKind.Utc).AddTicks(5321) });
        }
    }
}
