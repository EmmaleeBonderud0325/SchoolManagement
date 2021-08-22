using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Subject_SubjectId",
                schema: "Lesson",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_SubjectId",
                schema: "Lesson",
                table: "Lesson");

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

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_SubjectId_AcademicLevelId",
                schema: "Lesson",
                table: "Lesson",
                columns: new[] { "SubjectId", "AcademicLevelId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_SubjectAcademicLevel_SubjectId_AcademicLevelId",
                schema: "Lesson",
                table: "Lesson",
                columns: new[] { "SubjectId", "AcademicLevelId" },
                principalSchema: "Master",
                principalTable: "SubjectAcademicLevel",
                principalColumns: new[] { "SubjectId", "AcademicLevelId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_SubjectAcademicLevel_SubjectId_AcademicLevelId",
                schema: "Lesson",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_SubjectId_AcademicLevelId",
                schema: "Lesson",
                table: "Lesson");

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 22, 15, 35, 12, 28, DateTimeKind.Utc).AddTicks(923), new DateTime(2021, 8, 22, 15, 35, 12, 28, DateTimeKind.Utc).AddTicks(1394) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 22, 15, 35, 12, 28, DateTimeKind.Utc).AddTicks(2998), new DateTime(2021, 8, 22, 15, 35, 12, 28, DateTimeKind.Utc).AddTicks(3001) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 22, 15, 35, 12, 57, DateTimeKind.Utc).AddTicks(8686), new DateTime(2021, 8, 22, 15, 35, 12, 57, DateTimeKind.Utc).AddTicks(9369) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 8, 22, 15, 35, 12, 58, DateTimeKind.Utc).AddTicks(1721), new DateTime(2021, 8, 22, 15, 35, 12, 58, DateTimeKind.Utc).AddTicks(1724) });

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_SubjectId",
                schema: "Lesson",
                table: "Lesson",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Subject_SubjectId",
                schema: "Lesson",
                table: "Lesson",
                column: "SubjectId",
                principalSchema: "Master",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
