using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Data.Migrations
{
    public partial class Schoolmanagement00002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Master");

            migrationBuilder.EnsureSchema(
                name: "Lesson");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                schema: "Account",
                table: "User",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Account",
                table: "User",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AcademicLevel",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelHeadId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicLevel_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicLevel_User_LevelHeadId",
                        column: x => x.LevelHeadId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicLevel_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AcademicYear",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYear", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicYear_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicYear_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassName",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassName_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassName_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AdmissionNo = table.Column<int>(type: "int", nullable: false),
                    EmegencyContactNo1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmegencyContactNo2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_User_Id",
                        column: x => x.Id,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectStream",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectStream", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectStream_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectStream_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                schema: "Master",
                columns: table => new
                {
                    ClassNameId = table.Column<int>(type: "int", nullable: false),
                    AcademicLevelId = table.Column<int>(type: "int", nullable: false),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassCategory = table.Column<int>(type: "int", nullable: false),
                    LanguageStream = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => new { x.ClassNameId, x.AcademicLevelId, x.AcademicYearId });
                    table.ForeignKey(
                        name: "FK_Class_AcademicLevel_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalSchema: "Master",
                        principalTable: "AcademicLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalSchema: "Master",
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_ClassName_ClassNameId",
                        column: x => x.ClassNameId,
                        principalSchema: "Master",
                        principalTable: "ClassName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectCategory = table.Column<int>(type: "int", nullable: false),
                    IsParentBasketSubject = table.Column<bool>(type: "bit", nullable: false),
                    IsBuscketSubject = table.Column<bool>(type: "bit", nullable: false),
                    ParentBasketSubjectId = table.Column<int>(type: "int", nullable: false),
                    SubjectStreamId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.UniqueConstraint("AK_Subject_Name", x => x.Name);
                    table.UniqueConstraint("AK_Subject_SubjectCode", x => x.SubjectCode);
                    table.ForeignKey(
                        name: "FK_Subject_Subject_ParentBasketSubjectId",
                        column: x => x.ParentBasketSubjectId,
                        principalSchema: "Master",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subject_SubjectStream_SubjectStreamId",
                        column: x => x.SubjectStreamId,
                        principalSchema: "Master",
                        principalTable: "SubjectStream",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subject_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subject_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassTeacher",
                schema: "Master",
                columns: table => new
                {
                    ClassNameId = table.Column<int>(type: "int", nullable: false),
                    AcademicLevelId = table.Column<int>(type: "int", nullable: false),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTeacher", x => new { x.ClassNameId, x.AcademicLevelId, x.AcademicYearId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_ClassTeacher_Class_ClassNameId_AcademicLevelId_AcademicYearId",
                        columns: x => new { x.ClassNameId, x.AcademicLevelId, x.AcademicYearId },
                        principalSchema: "Master",
                        principalTable: "Class",
                        principalColumns: new[] { "ClassNameId", "AcademicLevelId", "AcademicYearId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassTeacher_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassTeacher_User_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassTeacher_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentClass",
                schema: "Master",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClassNameId = table.Column<int>(type: "int", nullable: false),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    AcademicLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClass", x => new { x.StudentId, x.ClassNameId, x.AcademicLevelId, x.AcademicYearId });
                    table.ForeignKey(
                        name: "FK_StudentClass_Class_ClassNameId_AcademicLevelId_AcademicYearId",
                        columns: x => new { x.ClassNameId, x.AcademicLevelId, x.AcademicYearId },
                        principalSchema: "Master",
                        principalTable: "Class",
                        principalColumns: new[] { "ClassNameId", "AcademicLevelId", "AcademicYearId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentClass_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Master",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                schema: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    AcademicLevelId = table.Column<int>(type: "int", nullable: false),
                    ClassNameId = table.Column<int>(type: "int", nullable: false),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    VersionNo = table.Column<int>(type: "int", nullable: false),
                    LearningOutcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlannedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lesson_Class_AcademicLevelId_ClassNameId_AcademicYearId",
                        columns: x => new { x.AcademicLevelId, x.ClassNameId, x.AcademicYearId },
                        principalSchema: "Master",
                        principalTable: "Class",
                        principalColumns: new[] { "ClassNameId", "AcademicLevelId", "AcademicYearId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lesson_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "Master",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lesson_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lesson_User_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lesson_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectAcademicLevel",
                schema: "Master",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    AcademicLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectAcademicLevel", x => new { x.SubjectId, x.AcademicLevelId });
                    table.ForeignKey(
                        name: "FK_SubjectAcademicLevel_AcademicLevel_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalSchema: "Master",
                        principalTable: "AcademicLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectAcademicLevel_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "Master",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTeacher",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicLevelId = table.Column<int>(type: "int", nullable: false),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_AcademicLevel_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalSchema: "Master",
                        principalTable: "AcademicLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalSchema: "Master",
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "Master",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_User_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LessonAssignment",
                schema: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripstion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonAssignment_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Lesson",
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonAssignment_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonAssignment_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentLesson",
                schema: "Lesson",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentLessonStatus = table.Column<int>(type: "int", nullable: false),
                    JoinedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLesson", x => new { x.LessonId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentLesson_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Lesson",
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentLesson_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Master",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                schema: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SequenceNo = table.Column<int>(type: "int", nullable: false),
                    LearningExperience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topic_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Lesson",
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentClassSubject",
                schema: "Master",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClassNameId = table.Column<int>(type: "int", nullable: false),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    AcademicLevelId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClassSubject", x => new { x.StudentId, x.ClassNameId, x.AcademicLevelId, x.AcademicYearId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_StudentClassSubject_StudentClass_StudentId_ClassNameId_AcademicLevelId_AcademicYearId",
                        columns: x => new { x.StudentId, x.ClassNameId, x.AcademicLevelId, x.AcademicYearId },
                        principalSchema: "Master",
                        principalTable: "StudentClass",
                        principalColumns: new[] { "StudentId", "ClassNameId", "AcademicLevelId", "AcademicYearId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentClassSubject_SubjectAcademicLevel_SubjectId_AcademicLevelId",
                        columns: x => new { x.SubjectId, x.AcademicLevelId },
                        principalSchema: "Master",
                        principalTable: "SubjectAcademicLevel",
                        principalColumns: new[] { "SubjectId", "AcademicLevelId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassSubjectTeacher",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassNameId = table.Column<int>(type: "int", nullable: false),
                    AcademicLevelId = table.Column<int>(type: "int", nullable: false),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    SubjectTeacherId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubjectTeacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassSubjectTeacher_Class_ClassNameId_AcademicLevelId_AcademicYearId",
                        columns: x => new { x.ClassNameId, x.AcademicLevelId, x.AcademicYearId },
                        principalSchema: "Master",
                        principalTable: "Class",
                        principalColumns: new[] { "ClassNameId", "AcademicLevelId", "AcademicYearId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassSubjectTeacher_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "Master",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassSubjectTeacher_SubjectTeacher_SubjectTeacherId",
                        column: x => x.SubjectTeacherId,
                        principalSchema: "Master",
                        principalTable: "SubjectTeacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassSubjectTeacher_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassSubjectTeacher_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeadOfDepartment",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    AcademicLevelId = table.Column<int>(type: "int", nullable: false),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadOfDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadOfDepartment_AcademicLevel_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalSchema: "Master",
                        principalTable: "AcademicLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeadOfDepartment_AcademicYear_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalSchema: "Master",
                        principalTable: "AcademicYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeadOfDepartment_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "Master",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeadOfDepartment_SubjectTeacher_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "Master",
                        principalTable: "SubjectTeacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeadOfDepartment_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HeadOfDepartment_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LessonAssignmentSubmission",
                schema: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonAssignmentId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubmissionPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Marks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TeacherComments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonAssignmentSubmission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonAssignmentSubmission_LessonAssignment_LessonAssignmentId",
                        column: x => x.LessonAssignmentId,
                        principalSchema: "Lesson",
                        principalTable: "LessonAssignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonAssignmentSubmission_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Master",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentLessonTopic",
                schema: "Lesson",
                columns: table => new
                {
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentLessonTopicStatus = table.Column<int>(type: "int", nullable: false),
                    JoinedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLessonTopic", x => new { x.TopicId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentLessonTopic_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Master",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentLessonTopic_Topic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "Lesson",
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TopicContent",
                schema: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicContent_Topic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "Lesson",
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentLessonTopicContenet",
                schema: "Lesson",
                columns: table => new
                {
                    TopicContentId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentLessonTopicStatus = table.Column<int>(type: "int", nullable: false),
                    JoinedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLessonTopicContenet", x => new { x.TopicContentId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentLessonTopicContenet_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Master",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentLessonTopicContenet_TopicContent_TopicContentId",
                        column: x => x.TopicContentId,
                        principalSchema: "Lesson",
                        principalTable: "TopicContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EssayStudentAnswer",
                schema: "Lesson",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    AnswerText = table.Column<int>(type: "int", nullable: false),
                    TeacherComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EssayQuestionAnswerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EssayStudentAnswer", x => new { x.QuestionId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_EssayStudentAnswer_User_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                schema: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: true),
                    SequnceNo = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: false),
                    QuestionType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: false),
                    StudentMCQQuestionQuestionId = table.Column<int>(type: "int", nullable: true),
                    StudentMCQQuestionStudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Lesson_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Lesson",
                        principalTable: "Lesson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Question_Topic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "Lesson",
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Question_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Question_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Account",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EssayQuestionAnswer",
                schema: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EssayQuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EssayQuestionAnswer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Lesson",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MCQAnswer",
                schema: "Lesson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SequenceNo = table.Column<int>(type: "int", nullable: false),
                    IsCorrectAnswer = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCQAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MCQAnswer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Lesson",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentMCQQuestion",
                schema: "Lesson",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TeacherComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsCorrectAnswer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMCQQuestion", x => new { x.QuestionId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentMCQQuestion_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Lesson",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentMCQQuestion_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Master",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MCQQuestionStudentAnswer",
                schema: "Lesson",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    MCQQuestionAnswerId = table.Column<int>(type: "int", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SequnceNo = table.Column<int>(type: "int", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCQQuestionStudentAnswer", x => new { x.QuestionId, x.StudentId, x.MCQQuestionAnswerId });
                    table.ForeignKey(
                        name: "FK_MCQQuestionStudentAnswer_MCQAnswer_MCQQuestionAnswerId",
                        column: x => x.MCQQuestionAnswerId,
                        principalSchema: "Lesson",
                        principalTable: "MCQAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MCQQuestionStudentAnswer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "Lesson",
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MCQQuestionStudentAnswer_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Master",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MCQQuestionStudentAnswer_StudentMCQQuestion_QuestionId_StudentId",
                        columns: x => new { x.QuestionId, x.StudentId },
                        principalSchema: "Lesson",
                        principalTable: "StudentMCQQuestion",
                        principalColumns: new[] { "QuestionId", "StudentId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "Account",
                table: "User",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                schema: "Account",
                table: "User",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicLevel_CreatedById",
                schema: "Master",
                table: "AcademicLevel",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicLevel_LevelHeadId",
                schema: "Master",
                table: "AcademicLevel",
                column: "LevelHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicLevel_UpdatedById",
                schema: "Master",
                table: "AcademicLevel",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYear_CreatedById",
                schema: "Master",
                table: "AcademicYear",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYear_UpdatedById",
                schema: "Master",
                table: "AcademicYear",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Class_AcademicLevelId",
                schema: "Master",
                table: "Class",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_AcademicYearId",
                schema: "Master",
                table: "Class",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_CreatedById",
                schema: "Master",
                table: "Class",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Class_UpdatedById",
                schema: "Master",
                table: "Class",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ClassName_CreatedById",
                schema: "Master",
                table: "ClassName",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ClassName_UpdatedById",
                schema: "Master",
                table: "ClassName",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectTeacher_ClassNameId_AcademicLevelId_AcademicYearId",
                schema: "Master",
                table: "ClassSubjectTeacher",
                columns: new[] { "ClassNameId", "AcademicLevelId", "AcademicYearId" });

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectTeacher_CreatedById",
                schema: "Master",
                table: "ClassSubjectTeacher",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectTeacher_SubjectId",
                schema: "Master",
                table: "ClassSubjectTeacher",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectTeacher_SubjectTeacherId",
                schema: "Master",
                table: "ClassSubjectTeacher",
                column: "SubjectTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjectTeacher_UpdatedById",
                schema: "Master",
                table: "ClassSubjectTeacher",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacher_CreatedById",
                schema: "Master",
                table: "ClassTeacher",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacher_TeacherId",
                schema: "Master",
                table: "ClassTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeacher_UpdatedById",
                schema: "Master",
                table: "ClassTeacher",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EssayQuestionAnswer_QuestionId",
                schema: "Lesson",
                table: "EssayQuestionAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_EssayStudentAnswer_EssayQuestionAnswerId",
                schema: "Lesson",
                table: "EssayStudentAnswer",
                column: "EssayQuestionAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_EssayStudentAnswer_StudentId",
                schema: "Lesson",
                table: "EssayStudentAnswer",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadOfDepartment_AcademicLevelId",
                schema: "Master",
                table: "HeadOfDepartment",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadOfDepartment_AcademicYearId",
                schema: "Master",
                table: "HeadOfDepartment",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadOfDepartment_CreatedById",
                schema: "Master",
                table: "HeadOfDepartment",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_HeadOfDepartment_SubjectId",
                schema: "Master",
                table: "HeadOfDepartment",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadOfDepartment_TeacherId",
                schema: "Master",
                table: "HeadOfDepartment",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadOfDepartment_UpdatedById",
                schema: "Master",
                table: "HeadOfDepartment",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_AcademicLevelId_ClassNameId_AcademicYearId",
                schema: "Lesson",
                table: "Lesson",
                columns: new[] { "AcademicLevelId", "ClassNameId", "AcademicYearId" });

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_CreatedById",
                schema: "Lesson",
                table: "Lesson",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_OwnerId",
                schema: "Lesson",
                table: "Lesson",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_SubjectId",
                schema: "Lesson",
                table: "Lesson",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_UpdatedById",
                schema: "Lesson",
                table: "Lesson",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LessonAssignment_CreatedById",
                schema: "Lesson",
                table: "LessonAssignment",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LessonAssignment_LessonId",
                schema: "Lesson",
                table: "LessonAssignment",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonAssignment_UpdatedById",
                schema: "Lesson",
                table: "LessonAssignment",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LessonAssignmentSubmission_LessonAssignmentId",
                schema: "Lesson",
                table: "LessonAssignmentSubmission",
                column: "LessonAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonAssignmentSubmission_StudentId",
                schema: "Lesson",
                table: "LessonAssignmentSubmission",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_MCQAnswer_QuestionId",
                schema: "Lesson",
                table: "MCQAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_MCQQuestionStudentAnswer_MCQQuestionAnswerId",
                schema: "Lesson",
                table: "MCQQuestionStudentAnswer",
                column: "MCQQuestionAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_MCQQuestionStudentAnswer_StudentId",
                schema: "Lesson",
                table: "MCQQuestionStudentAnswer",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_CreatedById",
                schema: "Lesson",
                table: "Question",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Question_LessonId",
                schema: "Lesson",
                table: "Question",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_StudentMCQQuestionQuestionId_StudentMCQQuestionStudentId",
                schema: "Lesson",
                table: "Question",
                columns: new[] { "StudentMCQQuestionQuestionId", "StudentMCQQuestionStudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Question_TopicId",
                schema: "Lesson",
                table: "Question",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_UpdatedById",
                schema: "Lesson",
                table: "Question",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Student_AdmissionNo",
                schema: "Master",
                table: "Student",
                column: "AdmissionNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_CreatedById",
                schema: "Master",
                table: "Student",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UpdatedById",
                schema: "Master",
                table: "Student",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_ClassNameId_AcademicLevelId_AcademicYearId",
                schema: "Master",
                table: "StudentClass",
                columns: new[] { "ClassNameId", "AcademicLevelId", "AcademicYearId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassSubject_SubjectId_AcademicLevelId",
                schema: "Master",
                table: "StudentClassSubject",
                columns: new[] { "SubjectId", "AcademicLevelId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentLesson_StudentId",
                schema: "Lesson",
                table: "StudentLesson",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLessonTopic_StudentId",
                schema: "Lesson",
                table: "StudentLessonTopic",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLessonTopicContenet_StudentId",
                schema: "Lesson",
                table: "StudentLessonTopicContenet",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMCQQuestion_StudentId",
                schema: "Lesson",
                table: "StudentMCQQuestion",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_CreatedById",
                schema: "Master",
                table: "Subject",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_ParentBasketSubjectId",
                schema: "Master",
                table: "Subject",
                column: "ParentBasketSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_SubjectStreamId",
                schema: "Master",
                table: "Subject",
                column: "SubjectStreamId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_UpdatedById",
                schema: "Master",
                table: "Subject",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectAcademicLevel_AcademicLevelId",
                schema: "Master",
                table: "SubjectAcademicLevel",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectStream_CreatedById",
                schema: "Master",
                table: "SubjectStream",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectStream_UpdatedById",
                schema: "Master",
                table: "SubjectStream",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_AcademicYearId",
                schema: "Master",
                table: "SubjectTeacher",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_CreatedById",
                schema: "Master",
                table: "SubjectTeacher",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_SubjectId",
                schema: "Master",
                table: "SubjectTeacher",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeacherId",
                schema: "Master",
                table: "SubjectTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_UpdatedById",
                schema: "Master",
                table: "SubjectTeacher",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_LessonId",
                schema: "Lesson",
                table: "Topic",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicContent_TopicId",
                schema: "Lesson",
                table: "TopicContent",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_EssayStudentAnswer_EssayQuestionAnswer_EssayQuestionAnswerId",
                schema: "Lesson",
                table: "EssayStudentAnswer",
                column: "EssayQuestionAnswerId",
                principalSchema: "Lesson",
                principalTable: "EssayQuestionAnswer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EssayStudentAnswer_Question_QuestionId",
                schema: "Lesson",
                table: "EssayStudentAnswer",
                column: "QuestionId",
                principalSchema: "Lesson",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_StudentMCQQuestion_StudentMCQQuestionQuestionId_StudentMCQQuestionStudentId",
                schema: "Lesson",
                table: "Question",
                columns: new[] { "StudentMCQQuestionQuestionId", "StudentMCQQuestionStudentId" },
                principalSchema: "Lesson",
                principalTable: "StudentMCQQuestion",
                principalColumns: new[] { "QuestionId", "StudentId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_AcademicLevel_AcademicLevelId",
                schema: "Master",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Class_AcademicYear_AcademicYearId",
                schema: "Master",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Class_ClassName_ClassNameId",
                schema: "Master",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Class_AcademicLevelId_ClassNameId_AcademicYearId",
                schema: "Lesson",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Subject_SubjectId",
                schema: "Lesson",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentMCQQuestion_Question_QuestionId",
                schema: "Lesson",
                table: "StudentMCQQuestion");

            migrationBuilder.DropTable(
                name: "ClassSubjectTeacher",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "ClassTeacher",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "EssayStudentAnswer",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "HeadOfDepartment",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "LessonAssignmentSubmission",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "MCQQuestionStudentAnswer",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "StudentClassSubject",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "StudentLesson",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "StudentLessonTopic",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "StudentLessonTopicContenet",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "EssayQuestionAnswer",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "SubjectTeacher",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "LessonAssignment",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "MCQAnswer",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "StudentClass",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "SubjectAcademicLevel",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "TopicContent",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "AcademicLevel",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "AcademicYear",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "ClassName",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Class",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Subject",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "SubjectStream",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "StudentMCQQuestion",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "Topic",
                schema: "Lesson");

            migrationBuilder.DropTable(
                name: "Student",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Lesson",
                schema: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                schema: "Account",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Username",
                schema: "Account",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                schema: "Account",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Account",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
