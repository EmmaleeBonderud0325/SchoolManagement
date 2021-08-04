using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EssayStudentAnswer_EssayQuestionAnswer_EssayQuestionAnswerId",
                schema: "Lesson",
                table: "EssayStudentAnswer");

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 4, 5, 34, 35, 677, DateTimeKind.Utc).AddTicks(8822), new DateTime(2021, 8, 4, 5, 34, 35, 677, DateTimeKind.Utc).AddTicks(9180) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 4, 5, 34, 35, 678, DateTimeKind.Utc).AddTicks(590), new DateTime(2021, 8, 4, 5, 34, 35, 678, DateTimeKind.Utc).AddTicks(593) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 4, 5, 34, 35, 691, DateTimeKind.Utc).AddTicks(2435), new DateTime(2021, 8, 4, 5, 34, 35, 691, DateTimeKind.Utc).AddTicks(2782) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 4, 5, 34, 35, 691, DateTimeKind.Utc).AddTicks(4146), new DateTime(2021, 8, 4, 5, 34, 35, 691, DateTimeKind.Utc).AddTicks(4148) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EssayStudentAnswer_EssayQuestionAnswer_EssayQuestionAnswerId",
                schema: "Lesson",
                table: "EssayStudentAnswer");

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
    }
}
