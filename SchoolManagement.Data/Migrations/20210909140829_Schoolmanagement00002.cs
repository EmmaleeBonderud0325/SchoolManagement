using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_AcademicLevel_AcademicYearId",
                schema: "Master",
                table: "SubjectTeacher");

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 9, 14, 8, 26, 996, DateTimeKind.Utc).AddTicks(3282), new DateTime(2021, 9, 9, 14, 8, 26, 996, DateTimeKind.Utc).AddTicks(3917) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 9, 14, 8, 26, 996, DateTimeKind.Utc).AddTicks(5949), new DateTime(2021, 9, 9, 14, 8, 26, 996, DateTimeKind.Utc).AddTicks(5955) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 9, 14, 8, 27, 27, DateTimeKind.Utc).AddTicks(481), new DateTime(2021, 9, 9, 14, 8, 27, 27, DateTimeKind.Utc).AddTicks(1325) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 9, 14, 8, 27, 27, DateTimeKind.Utc).AddTicks(4736), new DateTime(2021, 9, 9, 14, 8, 27, 27, DateTimeKind.Utc).AddTicks(4742) });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_AcademicLevelId",
                schema: "Master",
                table: "SubjectTeacher",
                column: "AcademicLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_AcademicLevel_AcademicLevelId",
                schema: "Master",
                table: "SubjectTeacher",
                column: "AcademicLevelId",
                principalSchema: "Master",
                principalTable: "AcademicLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_AcademicLevel_AcademicLevelId",
                schema: "Master",
                table: "SubjectTeacher");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTeacher_AcademicLevelId",
                schema: "Master",
                table: "SubjectTeacher");

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 7, 9, 26, 55, 127, DateTimeKind.Utc).AddTicks(8768), new DateTime(2021, 9, 7, 9, 26, 55, 127, DateTimeKind.Utc).AddTicks(9044) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 7, 9, 26, 55, 127, DateTimeKind.Utc).AddTicks(9781), new DateTime(2021, 9, 7, 9, 26, 55, 127, DateTimeKind.Utc).AddTicks(9784) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 7, 9, 26, 55, 138, DateTimeKind.Utc).AddTicks(7246), new DateTime(2021, 9, 7, 9, 26, 55, 138, DateTimeKind.Utc).AddTicks(7787) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 9, 7, 9, 26, 55, 138, DateTimeKind.Utc).AddTicks(9736), new DateTime(2021, 9, 7, 9, 26, 55, 138, DateTimeKind.Utc).AddTicks(9739) });

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_AcademicLevel_AcademicYearId",
                schema: "Master",
                table: "SubjectTeacher",
                column: "AcademicYearId",
                principalSchema: "Master",
                principalTable: "AcademicLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
