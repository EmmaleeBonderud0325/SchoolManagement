using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EssayStudentAnswer_EssayQuestionAnswer_EssayQuestionAnswerId",
                schema: "Lesson",
                table: "EssayStudentAnswer");

            migrationBuilder.RenameColumn(
                name: "SequnceNo",
                schema: "Lesson",
                table: "Question",
                newName: "SequenceNo");

            migrationBuilder.AlterColumn<int>(
                name: "EssayQuestionAnswerId",
                schema: "Lesson",
                table: "EssayStudentAnswer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerText",
                schema: "Lesson",
                table: "EssayStudentAnswer",
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
                values: new object[] { new DateTime(2021, 8, 3, 14, 21, 29, 969, DateTimeKind.Utc).AddTicks(1473), new DateTime(2021, 8, 3, 14, 21, 29, 969, DateTimeKind.Utc).AddTicks(1991) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 3, 14, 21, 29, 969, DateTimeKind.Utc).AddTicks(4216), new DateTime(2021, 8, 3, 14, 21, 29, 969, DateTimeKind.Utc).AddTicks(4220) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 3, 14, 21, 29, 989, DateTimeKind.Utc).AddTicks(2927), new DateTime(2021, 8, 3, 14, 21, 29, 989, DateTimeKind.Utc).AddTicks(3460) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 3, 14, 21, 29, 989, DateTimeKind.Utc).AddTicks(5623), new DateTime(2021, 8, 3, 14, 21, 29, 989, DateTimeKind.Utc).AddTicks(5626) });

            migrationBuilder.AddForeignKey(
                name: "FK_EssayStudentAnswer_EssayQuestionAnswer_EssayQuestionAnswerId",
                schema: "Lesson",
                table: "EssayStudentAnswer",
                column: "EssayQuestionAnswerId",
                principalSchema: "Lesson",
                principalTable: "EssayQuestionAnswer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EssayStudentAnswer_EssayQuestionAnswer_EssayQuestionAnswerId",
                schema: "Lesson",
                table: "EssayStudentAnswer");

            migrationBuilder.RenameColumn(
                name: "SequenceNo",
                schema: "Lesson",
                table: "Question",
                newName: "SequnceNo");

            migrationBuilder.AlterColumn<int>(
                name: "EssayQuestionAnswerId",
                schema: "Lesson",
                table: "EssayStudentAnswer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerText",
                schema: "Lesson",
                table: "EssayStudentAnswer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_EssayStudentAnswer_EssayQuestionAnswer_EssayQuestionAnswerId",
                schema: "Lesson",
                table: "EssayStudentAnswer",
                column: "EssayQuestionAnswerId",
                principalSchema: "Lesson",
                principalTable: "EssayQuestionAnswer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
