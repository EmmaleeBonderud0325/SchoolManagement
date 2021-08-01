using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedByOn",
                schema: "Lesson",
                table: "LessonAssignment",
                newName: "CreatedOn");

            migrationBuilder.AlterColumn<int>(
                name: "ParentBasketSubjectId",
                schema: "Master",
                table: "Subject",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageStream",
                schema: "Master",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "Master",
                table: "Class",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 1, 6, 56, 11, 600, DateTimeKind.Utc).AddTicks(7162), new DateTime(2021, 8, 1, 6, 56, 11, 600, DateTimeKind.Utc).AddTicks(7541) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 1, 6, 56, 11, 600, DateTimeKind.Utc).AddTicks(8883), new DateTime(2021, 8, 1, 6, 56, 11, 600, DateTimeKind.Utc).AddTicks(8887) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 1, 6, 56, 11, 619, DateTimeKind.Utc).AddTicks(3554), new DateTime(2021, 8, 1, 6, 56, 11, 619, DateTimeKind.Utc).AddTicks(4067) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 1, 6, 56, 11, 619, DateTimeKind.Utc).AddTicks(6016), new DateTime(2021, 8, 1, 6, 56, 11, 619, DateTimeKind.Utc).AddTicks(6019) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "Master",
                table: "Class");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                schema: "Lesson",
                table: "LessonAssignment",
                newName: "CreatedByOn");

            migrationBuilder.AlterColumn<int>(
                name: "ParentBasketSubjectId",
                schema: "Master",
                table: "Subject",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LanguageStream",
                schema: "Master",
                table: "Class",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 27, 9, 29, 18, 863, DateTimeKind.Utc).AddTicks(9758), new DateTime(2021, 7, 27, 9, 29, 18, 863, DateTimeKind.Utc).AddTicks(9987) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 27, 9, 29, 18, 864, DateTimeKind.Utc).AddTicks(641), new DateTime(2021, 7, 27, 9, 29, 18, 864, DateTimeKind.Utc).AddTicks(643) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 27, 9, 29, 18, 873, DateTimeKind.Utc).AddTicks(7133), new DateTime(2021, 7, 27, 9, 29, 18, 873, DateTimeKind.Utc).AddTicks(7455) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 27, 9, 29, 18, 873, DateTimeKind.Utc).AddTicks(8707), new DateTime(2021, 7, 27, 9, 29, 18, 873, DateTimeKind.Utc).AddTicks(8709) });
        }
    }
}
