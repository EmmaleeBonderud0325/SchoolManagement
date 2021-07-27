using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentLessonTopicContenet_Student_StudentId",
                schema: "Lesson",
                table: "StudentLessonTopicContenet");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLessonTopicContenet_TopicContent_TopicContentId",
                schema: "Lesson",
                table: "StudentLessonTopicContenet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentLessonTopicContenet",
                schema: "Lesson",
                table: "StudentLessonTopicContenet");

            migrationBuilder.RenameTable(
                name: "StudentLessonTopicContenet",
                schema: "Lesson",
                newName: "StudentLessonTopicContent",
                newSchema: "Lesson");

            migrationBuilder.RenameIndex(
                name: "IX_StudentLessonTopicContenet_StudentId",
                schema: "Lesson",
                table: "StudentLessonTopicContent",
                newName: "IX_StudentLessonTopicContent_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentLessonTopicContent",
                schema: "Lesson",
                table: "StudentLessonTopicContent",
                columns: new[] { "TopicContentId", "StudentId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLessonTopicContent_Student_StudentId",
                schema: "Lesson",
                table: "StudentLessonTopicContent",
                column: "StudentId",
                principalSchema: "Master",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLessonTopicContent_TopicContent_TopicContentId",
                schema: "Lesson",
                table: "StudentLessonTopicContent",
                column: "TopicContentId",
                principalSchema: "Lesson",
                principalTable: "TopicContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentLessonTopicContent_Student_StudentId",
                schema: "Lesson",
                table: "StudentLessonTopicContent");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLessonTopicContent_TopicContent_TopicContentId",
                schema: "Lesson",
                table: "StudentLessonTopicContent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentLessonTopicContent",
                schema: "Lesson",
                table: "StudentLessonTopicContent");

            migrationBuilder.RenameTable(
                name: "StudentLessonTopicContent",
                schema: "Lesson",
                newName: "StudentLessonTopicContenet",
                newSchema: "Lesson");

            migrationBuilder.RenameIndex(
                name: "IX_StudentLessonTopicContent_StudentId",
                schema: "Lesson",
                table: "StudentLessonTopicContenet",
                newName: "IX_StudentLessonTopicContenet_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentLessonTopicContenet",
                schema: "Lesson",
                table: "StudentLessonTopicContenet",
                columns: new[] { "TopicContentId", "StudentId" });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 27, 8, 41, 39, 696, DateTimeKind.Utc).AddTicks(2598), new DateTime(2021, 7, 27, 8, 41, 39, 696, DateTimeKind.Utc).AddTicks(2859) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 27, 8, 41, 39, 696, DateTimeKind.Utc).AddTicks(3970), new DateTime(2021, 7, 27, 8, 41, 39, 696, DateTimeKind.Utc).AddTicks(3973) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 27, 8, 41, 39, 709, DateTimeKind.Utc).AddTicks(7913), new DateTime(2021, 7, 27, 8, 41, 39, 709, DateTimeKind.Utc).AddTicks(8255) });

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2021, 7, 27, 8, 41, 39, 709, DateTimeKind.Utc).AddTicks(9539), new DateTime(2021, 7, 27, 8, 41, 39, 709, DateTimeKind.Utc).AddTicks(9541) });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLessonTopicContenet_Student_StudentId",
                schema: "Lesson",
                table: "StudentLessonTopicContenet",
                column: "StudentId",
                principalSchema: "Master",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLessonTopicContenet_TopicContent_TopicContentId",
                schema: "Lesson",
                table: "StudentLessonTopicContenet",
                column: "TopicContentId",
                principalSchema: "Lesson",
                principalTable: "TopicContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
