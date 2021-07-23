BEGIN TRANSACTION;
GO

IF SCHEMA_ID(N'Master') IS NULL EXEC(N'CREATE SCHEMA [Master];');
GO

IF SCHEMA_ID(N'Lesson') IS NULL EXEC(N'CREATE SCHEMA [Lesson];');
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Account].[User]') AND [c].[name] = N'Username');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Account].[User] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Account].[User] ALTER COLUMN [Username] nvarchar(450) NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Account].[User]') AND [c].[name] = N'Email');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Account].[User] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Account].[User] ALTER COLUMN [Email] nvarchar(450) NULL;
GO

CREATE TABLE [Master].[AcademicLevel] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [LevelHeadId] int NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdatedOn] datetime2 NOT NULL,
    [UpdatedById] int NOT NULL,
    CONSTRAINT [PK_AcademicLevel] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AcademicLevel_User_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AcademicLevel_User_LevelHeadId] FOREIGN KEY ([LevelHeadId]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AcademicLevel_User_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Master].[AcademicYear] (
    [Id] int NOT NULL IDENTITY,
    [IsActive] bit NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdatedOn] datetime2 NOT NULL,
    [UpdatedById] int NOT NULL,
    CONSTRAINT [PK_AcademicYear] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AcademicYear_User_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AcademicYear_User_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Master].[ClassName] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [IsActive] bit NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdatedOn] datetime2 NOT NULL,
    [UpdatedById] int NOT NULL,
    CONSTRAINT [PK_ClassName] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ClassName_User_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ClassName_User_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Master].[Student] (
    [Id] int NOT NULL,
    [AdmissionNo] int NOT NULL,
    [EmegencyContactNo1] nvarchar(max) NULL,
    [EmegencyContactNo2] nvarchar(max) NULL,
    [Gender] int NOT NULL,
    [DateOfBirth] datetime2 NULL,
    [IsActive] bit NOT NULL,
    [CreateOn] datetime2 NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdateOn] datetime2 NOT NULL,
    [UpdatedById] int NOT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Student_User_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Student_User_Id] FOREIGN KEY ([Id]) REFERENCES [Account].[User] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Student_User_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Master].[SubjectStream] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [IsActive] bit NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdatedOn] datetime2 NOT NULL,
    [UpdatedById] int NOT NULL,
    CONSTRAINT [PK_SubjectStream] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SubjectStream_User_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_SubjectStream_User_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Master].[Class] (
    [ClassNameId] int NOT NULL,
    [AcademicLevelId] int NOT NULL,
    [AcademicYearId] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [ClassCategory] int NOT NULL,
    [LanguageStream] nvarchar(max) NULL,
    [CreatedById] int NOT NULL,
    [UpdatedOn] datetime2 NOT NULL,
    [UpdatedById] int NOT NULL,
    CONSTRAINT [PK_Class] PRIMARY KEY ([ClassNameId], [AcademicLevelId], [AcademicYearId]),
    CONSTRAINT [FK_Class_AcademicLevel_AcademicLevelId] FOREIGN KEY ([AcademicLevelId]) REFERENCES [Master].[AcademicLevel] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Class_AcademicYear_AcademicYearId] FOREIGN KEY ([AcademicYearId]) REFERENCES [Master].[AcademicYear] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Class_ClassName_ClassNameId] FOREIGN KEY ([ClassNameId]) REFERENCES [Master].[ClassName] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Class_User_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Class_User_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Master].[Subject] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(450) NOT NULL,
    [SubjectCode] nvarchar(450) NOT NULL,
    [SubjectCategory] int NOT NULL,
    [IsParentBasketSubject] bit NOT NULL,
    [IsBuscketSubject] bit NOT NULL,
    [ParentBasketSubjectId] int NOT NULL,
    [SubjectStreamId] int NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdatedOn] datetime2 NOT NULL,
    [UpdatedById] int NOT NULL,
    CONSTRAINT [PK_Subject] PRIMARY KEY ([Id]),
    CONSTRAINT [AK_Subject_Name] UNIQUE ([Name]),
    CONSTRAINT [AK_Subject_SubjectCode] UNIQUE ([SubjectCode]),
    CONSTRAINT [FK_Subject_Subject_ParentBasketSubjectId] FOREIGN KEY ([ParentBasketSubjectId]) REFERENCES [Master].[Subject] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Subject_SubjectStream_SubjectStreamId] FOREIGN KEY ([SubjectStreamId]) REFERENCES [Master].[SubjectStream] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Subject_User_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Subject_User_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Master].[ClassTeacher] (
    [ClassNameId] int NOT NULL,
    [AcademicLevelId] int NOT NULL,
    [AcademicYearId] int NOT NULL,
    [TeacherId] int NOT NULL,
    [IsPrimary] bit NOT NULL,
    [IsActive] bit NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdatedOn] datetime2 NOT NULL,
    [UpdatedById] int NOT NULL,
    CONSTRAINT [PK_ClassTeacher] PRIMARY KEY ([ClassNameId], [AcademicLevelId], [AcademicYearId], [TeacherId]),
    CONSTRAINT [FK_ClassTeacher_Class_ClassNameId_AcademicLevelId_AcademicYearId] FOREIGN KEY ([ClassNameId], [AcademicLevelId], [AcademicYearId]) REFERENCES [Master].[Class] ([ClassNameId], [AcademicLevelId], [AcademicYearId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ClassTeacher_User_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ClassTeacher_User_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [Account].[User] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ClassTeacher_User_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Master].[StudentClass] (
    [StudentId] int NOT NULL,
    [ClassNameId] int NOT NULL,
    [AcademicYearId] int NOT NULL,
    [AcademicLevelId] int NOT NULL,
    CONSTRAINT [PK_StudentClass] PRIMARY KEY ([StudentId], [ClassNameId], [AcademicLevelId], [AcademicYearId]),
    CONSTRAINT [FK_StudentClass_Class_ClassNameId_AcademicLevelId_AcademicYearId] FOREIGN KEY ([ClassNameId], [AcademicLevelId], [AcademicYearId]) REFERENCES [Master].[Class] ([ClassNameId], [AcademicLevelId], [AcademicYearId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_StudentClass_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Master].[Student] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Lesson].[Lesson] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [OwnerId] int NOT NULL,
    [AcademicLevelId] int NOT NULL,
    [ClassNameId] int NOT NULL,
    [AcademicYearId] int NOT NULL,
    [SubjectId] int NOT NULL,
    [VersionNo] int NOT NULL,
    [LearningOutcome] nvarchar(max) NULL,
    [PlannedDate] datetime2 NOT NULL,
    [CompletedDate] datetime2 NOT NULL,
    [Status] int NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdatedOn] datetime2 NOT NULL,
    [UpdatedById] int NOT NULL,
    CONSTRAINT [PK_Lesson] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Lesson_Class_AcademicLevelId_ClassNameId_AcademicYearId] FOREIGN KEY ([AcademicLevelId], [ClassNameId], [AcademicYearId]) REFERENCES [Master].[Class] ([ClassNameId], [AcademicLevelId], [AcademicYearId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Lesson_Subject_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [Master].[Subject] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Lesson_User_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Lesson_User_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Lesson_User_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Master].[SubjectAcademicLevel] (
    [SubjectId] int NOT NULL,
    [AcademicLevelId] int NOT NULL,
    CONSTRAINT [PK_SubjectAcademicLevel] PRIMARY KEY ([SubjectId], [AcademicLevelId]),
    CONSTRAINT [FK_SubjectAcademicLevel_AcademicLevel_AcademicLevelId] FOREIGN KEY ([AcademicLevelId]) REFERENCES [Master].[AcademicLevel] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_SubjectAcademicLevel_Subject_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [Master].[Subject] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Master].[SubjectTeacher] (
    [Id] int NOT NULL IDENTITY,
    [AcademicLevelId] int NOT NULL,
    [AcademicYearId] int NOT NULL,
    [SubjectId] int NOT NULL,
    [TeacherId] int NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NULL,
    [IsActive] bit NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdatedOn] datetime2 NOT NULL,
    [UpdatedById] int NOT NULL,
    CONSTRAINT [PK_SubjectTeacher] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SubjectTeacher_AcademicLevel_AcademicYearId] FOREIGN KEY ([AcademicYearId]) REFERENCES [Master].[AcademicLevel] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_SubjectTeacher_AcademicYear_AcademicYearId] FOREIGN KEY ([AcademicYearId]) REFERENCES [Master].[AcademicYear] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_SubjectTeacher_Subject_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [Master].[Subject] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_SubjectTeacher_User_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_SubjectTeacher_User_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_SubjectTeacher_User_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Lesson].[LessonAssignment] (
    [Id] int NOT NULL IDENTITY,
    [LessonId] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [Descripstion] nvarchar(max) NULL,
    [IsActive] bit NOT NULL,
    [CreatedByOn] datetime2 NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdatedOn] datetime2 NOT NULL,
    [UpdatedById] int NOT NULL,
    CONSTRAINT [PK_LessonAssignment] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_LessonAssignment_Lesson_LessonId] FOREIGN KEY ([LessonId]) REFERENCES [Lesson].[Lesson] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_LessonAssignment_User_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_LessonAssignment_User_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Lesson].[StudentLesson] (
    [LessonId] int NOT NULL,
    [StudentId] int NOT NULL,
    [StudentLessonStatus] int NOT NULL,
    [JoinedOn] datetime2 NULL,
    [CompletedOn] datetime2 NULL,
    CONSTRAINT [PK_StudentLesson] PRIMARY KEY ([LessonId], [StudentId]),
    CONSTRAINT [FK_StudentLesson_Lesson_LessonId] FOREIGN KEY ([LessonId]) REFERENCES [Lesson].[Lesson] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_StudentLesson_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Master].[Student] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Lesson].[Topic] (
    [Id] int NOT NULL IDENTITY,
    [LessonId] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [SequenceNo] int NOT NULL,
    [LearningExperience] nvarchar(max) NULL,
    [IsActive] bit NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    [ModifiedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_Topic] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Topic_Lesson_LessonId] FOREIGN KEY ([LessonId]) REFERENCES [Lesson].[Lesson] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Master].[StudentClassSubject] (
    [StudentId] int NOT NULL,
    [ClassNameId] int NOT NULL,
    [AcademicYearId] int NOT NULL,
    [AcademicLevelId] int NOT NULL,
    [SubjectId] int NOT NULL,
    CONSTRAINT [PK_StudentClassSubject] PRIMARY KEY ([StudentId], [ClassNameId], [AcademicLevelId], [AcademicYearId], [SubjectId]),
    CONSTRAINT [FK_StudentClassSubject_StudentClass_StudentId_ClassNameId_AcademicLevelId_AcademicYearId] FOREIGN KEY ([StudentId], [ClassNameId], [AcademicLevelId], [AcademicYearId]) REFERENCES [Master].[StudentClass] ([StudentId], [ClassNameId], [AcademicLevelId], [AcademicYearId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_StudentClassSubject_SubjectAcademicLevel_SubjectId_AcademicLevelId] FOREIGN KEY ([SubjectId], [AcademicLevelId]) REFERENCES [Master].[SubjectAcademicLevel] ([SubjectId], [AcademicLevelId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Master].[ClassSubjectTeacher] (
    [Id] int NOT NULL IDENTITY,
    [ClassNameId] int NOT NULL,
    [AcademicLevelId] int NOT NULL,
    [AcademicYearId] int NOT NULL,
    [SubjectId] int NOT NULL,
    [SubjectTeacherId] int NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NULL,
    [IsActive] bit NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdatedOn] datetime2 NOT NULL,
    [UpdatedById] int NOT NULL,
    CONSTRAINT [PK_ClassSubjectTeacher] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ClassSubjectTeacher_Class_ClassNameId_AcademicLevelId_AcademicYearId] FOREIGN KEY ([ClassNameId], [AcademicLevelId], [AcademicYearId]) REFERENCES [Master].[Class] ([ClassNameId], [AcademicLevelId], [AcademicYearId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ClassSubjectTeacher_Subject_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [Master].[Subject] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ClassSubjectTeacher_SubjectTeacher_SubjectTeacherId] FOREIGN KEY ([SubjectTeacherId]) REFERENCES [Master].[SubjectTeacher] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ClassSubjectTeacher_User_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ClassSubjectTeacher_User_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Master].[HeadOfDepartment] (
    [Id] int NOT NULL IDENTITY,
    [SubjectId] int NOT NULL,
    [AcademicLevelId] int NOT NULL,
    [AcademicYearId] int NOT NULL,
    [TeacherId] int NOT NULL,
    [IsActive] bit NOT NULL,
    [CreateOn] datetime2 NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdateOn] datetime2 NOT NULL,
    [UpdatedById] int NOT NULL,
    CONSTRAINT [PK_HeadOfDepartment] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_HeadOfDepartment_AcademicLevel_AcademicLevelId] FOREIGN KEY ([AcademicLevelId]) REFERENCES [Master].[AcademicLevel] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HeadOfDepartment_AcademicYear_AcademicYearId] FOREIGN KEY ([AcademicYearId]) REFERENCES [Master].[AcademicYear] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HeadOfDepartment_Subject_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [Master].[Subject] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HeadOfDepartment_SubjectTeacher_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [Master].[SubjectTeacher] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HeadOfDepartment_User_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HeadOfDepartment_User_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Lesson].[LessonAssignmentSubmission] (
    [Id] int NOT NULL IDENTITY,
    [LessonAssignmentId] int NOT NULL,
    [StudentId] int NOT NULL,
    [SubmissionPath] nvarchar(max) NULL,
    [SubmissionDate] datetime2 NOT NULL,
    [Marks] decimal(18,2) NOT NULL,
    [TeacherComments] nvarchar(max) NULL,
    CONSTRAINT [PK_LessonAssignmentSubmission] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_LessonAssignmentSubmission_LessonAssignment_LessonAssignmentId] FOREIGN KEY ([LessonAssignmentId]) REFERENCES [Lesson].[LessonAssignment] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_LessonAssignmentSubmission_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Master].[Student] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Lesson].[StudentLessonTopic] (
    [TopicId] int NOT NULL,
    [StudentId] int NOT NULL,
    [StudentLessonTopicStatus] int NOT NULL,
    [JoinedOn] datetime2 NULL,
    [CompletedOn] datetime2 NULL,
    CONSTRAINT [PK_StudentLessonTopic] PRIMARY KEY ([TopicId], [StudentId]),
    CONSTRAINT [FK_StudentLessonTopic_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Master].[Student] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_StudentLessonTopic_Topic_TopicId] FOREIGN KEY ([TopicId]) REFERENCES [Lesson].[Topic] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Lesson].[TopicContent] (
    [Id] int NOT NULL IDENTITY,
    [TopicId] int NOT NULL,
    [Introduction] nvarchar(max) NULL,
    [ContentType] int NOT NULL,
    [Content] nvarchar(max) NULL,
    [CreatedOn] datetime2 NOT NULL,
    [UpdatedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_TopicContent] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TopicContent_Topic_TopicId] FOREIGN KEY ([TopicId]) REFERENCES [Lesson].[Topic] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Lesson].[StudentLessonTopicContenet] (
    [TopicContentId] int NOT NULL,
    [StudentId] int NOT NULL,
    [StudentLessonTopicStatus] int NOT NULL,
    [JoinedOn] datetime2 NULL,
    [CompletedOn] datetime2 NULL,
    CONSTRAINT [PK_StudentLessonTopicContenet] PRIMARY KEY ([TopicContentId], [StudentId]),
    CONSTRAINT [FK_StudentLessonTopicContenet_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Master].[Student] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_StudentLessonTopicContenet_TopicContent_TopicContentId] FOREIGN KEY ([TopicContentId]) REFERENCES [Lesson].[TopicContent] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Lesson].[EssayStudentAnswer] (
    [QuestionId] int NOT NULL,
    [StudentId] int NOT NULL,
    [AnswerText] int NOT NULL,
    [TeacherComments] nvarchar(max) NULL,
    [Marks] decimal(18,2) NOT NULL,
    [EssayQuestionAnswerId] int NULL,
    CONSTRAINT [PK_EssayStudentAnswer] PRIMARY KEY ([QuestionId], [StudentId]),
    CONSTRAINT [FK_EssayStudentAnswer_User_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Lesson].[Question] (
    [Id] int NOT NULL IDENTITY,
    [LessonId] int NOT NULL,
    [TopicId] int NULL,
    [SequnceNo] int NOT NULL,
    [QuestionText] nvarchar(max) NULL,
    [Marks] decimal(18,2) NOT NULL,
    [DifficultyLevel] int NOT NULL,
    [QuestionType] int NOT NULL,
    [IsActive] bit NOT NULL,
    [CreateOn] datetime2 NOT NULL,
    [CreatedById] int NOT NULL,
    [UpdateOn] datetime2 NOT NULL,
    [UpdatedById] int NOT NULL,
    [StudentMCQQuestionQuestionId] int NULL,
    [StudentMCQQuestionStudentId] int NULL,
    CONSTRAINT [PK_Question] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Question_Lesson_LessonId] FOREIGN KEY ([LessonId]) REFERENCES [Lesson].[Lesson] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Question_Topic_TopicId] FOREIGN KEY ([TopicId]) REFERENCES [Lesson].[Topic] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Question_User_CreatedById] FOREIGN KEY ([CreatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Question_User_UpdatedById] FOREIGN KEY ([UpdatedById]) REFERENCES [Account].[User] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Lesson].[EssayQuestionAnswer] (
    [Id] int NOT NULL IDENTITY,
    [QuestionId] int NOT NULL,
    [AnswerText] nvarchar(max) NULL,
    [ModifiedOn] datetime2 NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_EssayQuestionAnswer] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EssayQuestionAnswer_Question_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Lesson].[Question] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Lesson].[MCQAnswer] (
    [Id] int NOT NULL IDENTITY,
    [QuestionId] int NOT NULL,
    [AnswerText] nvarchar(max) NULL,
    [SequenceNo] int NOT NULL,
    [IsCorrectAnswer] bit NOT NULL,
    [ModifiedDate] datetime2 NOT NULL,
    [CreatedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_MCQAnswer] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MCQAnswer_Question_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Lesson].[Question] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Lesson].[StudentMCQQuestion] (
    [QuestionId] int NOT NULL,
    [StudentId] int NOT NULL,
    [TeacherComments] nvarchar(max) NULL,
    [Marks] decimal(18,2) NOT NULL,
    [IsCorrectAnswer] bit NOT NULL,
    CONSTRAINT [PK_StudentMCQQuestion] PRIMARY KEY ([QuestionId], [StudentId]),
    CONSTRAINT [FK_StudentMCQQuestion_Question_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Lesson].[Question] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_StudentMCQQuestion_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Master].[Student] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Lesson].[MCQQuestionStudentAnswer] (
    [QuestionId] int NOT NULL,
    [StudentId] int NOT NULL,
    [MCQQuestionAnswerId] int NOT NULL,
    [AnswerText] nvarchar(max) NULL,
    [SequnceNo] int NOT NULL,
    [IsChecked] bit NOT NULL,
    CONSTRAINT [PK_MCQQuestionStudentAnswer] PRIMARY KEY ([QuestionId], [StudentId], [MCQQuestionAnswerId]),
    CONSTRAINT [FK_MCQQuestionStudentAnswer_MCQAnswer_MCQQuestionAnswerId] FOREIGN KEY ([MCQQuestionAnswerId]) REFERENCES [Lesson].[MCQAnswer] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_MCQQuestionStudentAnswer_Question_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Lesson].[Question] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MCQQuestionStudentAnswer_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Master].[Student] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MCQQuestionStudentAnswer_StudentMCQQuestion_QuestionId_StudentId] FOREIGN KEY ([QuestionId], [StudentId]) REFERENCES [Lesson].[StudentMCQQuestion] ([QuestionId], [StudentId]) ON DELETE NO ACTION
);
GO

CREATE UNIQUE INDEX [IX_User_Email] ON [Account].[User] ([Email]) WHERE [Email] IS NOT NULL;
GO

CREATE UNIQUE INDEX [IX_User_Username] ON [Account].[User] ([Username]) WHERE [Username] IS NOT NULL;
GO

CREATE INDEX [IX_AcademicLevel_CreatedById] ON [Master].[AcademicLevel] ([CreatedById]);
GO

CREATE INDEX [IX_AcademicLevel_LevelHeadId] ON [Master].[AcademicLevel] ([LevelHeadId]);
GO

CREATE INDEX [IX_AcademicLevel_UpdatedById] ON [Master].[AcademicLevel] ([UpdatedById]);
GO

CREATE INDEX [IX_AcademicYear_CreatedById] ON [Master].[AcademicYear] ([CreatedById]);
GO

CREATE INDEX [IX_AcademicYear_UpdatedById] ON [Master].[AcademicYear] ([UpdatedById]);
GO

CREATE INDEX [IX_Class_AcademicLevelId] ON [Master].[Class] ([AcademicLevelId]);
GO

CREATE INDEX [IX_Class_AcademicYearId] ON [Master].[Class] ([AcademicYearId]);
GO

CREATE INDEX [IX_Class_CreatedById] ON [Master].[Class] ([CreatedById]);
GO

CREATE INDEX [IX_Class_UpdatedById] ON [Master].[Class] ([UpdatedById]);
GO

CREATE INDEX [IX_ClassName_CreatedById] ON [Master].[ClassName] ([CreatedById]);
GO

CREATE INDEX [IX_ClassName_UpdatedById] ON [Master].[ClassName] ([UpdatedById]);
GO

CREATE INDEX [IX_ClassSubjectTeacher_ClassNameId_AcademicLevelId_AcademicYearId] ON [Master].[ClassSubjectTeacher] ([ClassNameId], [AcademicLevelId], [AcademicYearId]);
GO

CREATE INDEX [IX_ClassSubjectTeacher_CreatedById] ON [Master].[ClassSubjectTeacher] ([CreatedById]);
GO

CREATE INDEX [IX_ClassSubjectTeacher_SubjectId] ON [Master].[ClassSubjectTeacher] ([SubjectId]);
GO

CREATE INDEX [IX_ClassSubjectTeacher_SubjectTeacherId] ON [Master].[ClassSubjectTeacher] ([SubjectTeacherId]);
GO

CREATE INDEX [IX_ClassSubjectTeacher_UpdatedById] ON [Master].[ClassSubjectTeacher] ([UpdatedById]);
GO

CREATE INDEX [IX_ClassTeacher_CreatedById] ON [Master].[ClassTeacher] ([CreatedById]);
GO

CREATE INDEX [IX_ClassTeacher_TeacherId] ON [Master].[ClassTeacher] ([TeacherId]);
GO

CREATE INDEX [IX_ClassTeacher_UpdatedById] ON [Master].[ClassTeacher] ([UpdatedById]);
GO

CREATE INDEX [IX_EssayQuestionAnswer_QuestionId] ON [Lesson].[EssayQuestionAnswer] ([QuestionId]);
GO

CREATE INDEX [IX_EssayStudentAnswer_EssayQuestionAnswerId] ON [Lesson].[EssayStudentAnswer] ([EssayQuestionAnswerId]);
GO

CREATE INDEX [IX_EssayStudentAnswer_StudentId] ON [Lesson].[EssayStudentAnswer] ([StudentId]);
GO

CREATE INDEX [IX_HeadOfDepartment_AcademicLevelId] ON [Master].[HeadOfDepartment] ([AcademicLevelId]);
GO

CREATE INDEX [IX_HeadOfDepartment_AcademicYearId] ON [Master].[HeadOfDepartment] ([AcademicYearId]);
GO

CREATE INDEX [IX_HeadOfDepartment_CreatedById] ON [Master].[HeadOfDepartment] ([CreatedById]);
GO

CREATE INDEX [IX_HeadOfDepartment_SubjectId] ON [Master].[HeadOfDepartment] ([SubjectId]);
GO

CREATE INDEX [IX_HeadOfDepartment_TeacherId] ON [Master].[HeadOfDepartment] ([TeacherId]);
GO

CREATE INDEX [IX_HeadOfDepartment_UpdatedById] ON [Master].[HeadOfDepartment] ([UpdatedById]);
GO

CREATE INDEX [IX_Lesson_AcademicLevelId_ClassNameId_AcademicYearId] ON [Lesson].[Lesson] ([AcademicLevelId], [ClassNameId], [AcademicYearId]);
GO

CREATE INDEX [IX_Lesson_CreatedById] ON [Lesson].[Lesson] ([CreatedById]);
GO

CREATE INDEX [IX_Lesson_OwnerId] ON [Lesson].[Lesson] ([OwnerId]);
GO

CREATE INDEX [IX_Lesson_SubjectId] ON [Lesson].[Lesson] ([SubjectId]);
GO

CREATE INDEX [IX_Lesson_UpdatedById] ON [Lesson].[Lesson] ([UpdatedById]);
GO

CREATE INDEX [IX_LessonAssignment_CreatedById] ON [Lesson].[LessonAssignment] ([CreatedById]);
GO

CREATE INDEX [IX_LessonAssignment_LessonId] ON [Lesson].[LessonAssignment] ([LessonId]);
GO

CREATE INDEX [IX_LessonAssignment_UpdatedById] ON [Lesson].[LessonAssignment] ([UpdatedById]);
GO

CREATE INDEX [IX_LessonAssignmentSubmission_LessonAssignmentId] ON [Lesson].[LessonAssignmentSubmission] ([LessonAssignmentId]);
GO

CREATE INDEX [IX_LessonAssignmentSubmission_StudentId] ON [Lesson].[LessonAssignmentSubmission] ([StudentId]);
GO

CREATE INDEX [IX_MCQAnswer_QuestionId] ON [Lesson].[MCQAnswer] ([QuestionId]);
GO

CREATE INDEX [IX_MCQQuestionStudentAnswer_MCQQuestionAnswerId] ON [Lesson].[MCQQuestionStudentAnswer] ([MCQQuestionAnswerId]);
GO

CREATE INDEX [IX_MCQQuestionStudentAnswer_StudentId] ON [Lesson].[MCQQuestionStudentAnswer] ([StudentId]);
GO

CREATE INDEX [IX_Question_CreatedById] ON [Lesson].[Question] ([CreatedById]);
GO

CREATE INDEX [IX_Question_LessonId] ON [Lesson].[Question] ([LessonId]);
GO

CREATE INDEX [IX_Question_StudentMCQQuestionQuestionId_StudentMCQQuestionStudentId] ON [Lesson].[Question] ([StudentMCQQuestionQuestionId], [StudentMCQQuestionStudentId]);
GO

CREATE INDEX [IX_Question_TopicId] ON [Lesson].[Question] ([TopicId]);
GO

CREATE INDEX [IX_Question_UpdatedById] ON [Lesson].[Question] ([UpdatedById]);
GO

CREATE UNIQUE INDEX [IX_Student_AdmissionNo] ON [Master].[Student] ([AdmissionNo]);
GO

CREATE INDEX [IX_Student_CreatedById] ON [Master].[Student] ([CreatedById]);
GO

CREATE INDEX [IX_Student_UpdatedById] ON [Master].[Student] ([UpdatedById]);
GO

CREATE INDEX [IX_StudentClass_ClassNameId_AcademicLevelId_AcademicYearId] ON [Master].[StudentClass] ([ClassNameId], [AcademicLevelId], [AcademicYearId]);
GO

CREATE INDEX [IX_StudentClassSubject_SubjectId_AcademicLevelId] ON [Master].[StudentClassSubject] ([SubjectId], [AcademicLevelId]);
GO

CREATE INDEX [IX_StudentLesson_StudentId] ON [Lesson].[StudentLesson] ([StudentId]);
GO

CREATE INDEX [IX_StudentLessonTopic_StudentId] ON [Lesson].[StudentLessonTopic] ([StudentId]);
GO

CREATE INDEX [IX_StudentLessonTopicContenet_StudentId] ON [Lesson].[StudentLessonTopicContenet] ([StudentId]);
GO

CREATE INDEX [IX_StudentMCQQuestion_StudentId] ON [Lesson].[StudentMCQQuestion] ([StudentId]);
GO

CREATE INDEX [IX_Subject_CreatedById] ON [Master].[Subject] ([CreatedById]);
GO

CREATE INDEX [IX_Subject_ParentBasketSubjectId] ON [Master].[Subject] ([ParentBasketSubjectId]);
GO

CREATE INDEX [IX_Subject_SubjectStreamId] ON [Master].[Subject] ([SubjectStreamId]);
GO

CREATE INDEX [IX_Subject_UpdatedById] ON [Master].[Subject] ([UpdatedById]);
GO

CREATE INDEX [IX_SubjectAcademicLevel_AcademicLevelId] ON [Master].[SubjectAcademicLevel] ([AcademicLevelId]);
GO

CREATE INDEX [IX_SubjectStream_CreatedById] ON [Master].[SubjectStream] ([CreatedById]);
GO

CREATE INDEX [IX_SubjectStream_UpdatedById] ON [Master].[SubjectStream] ([UpdatedById]);
GO

CREATE INDEX [IX_SubjectTeacher_AcademicYearId] ON [Master].[SubjectTeacher] ([AcademicYearId]);
GO

CREATE INDEX [IX_SubjectTeacher_CreatedById] ON [Master].[SubjectTeacher] ([CreatedById]);
GO

CREATE INDEX [IX_SubjectTeacher_SubjectId] ON [Master].[SubjectTeacher] ([SubjectId]);
GO

CREATE INDEX [IX_SubjectTeacher_TeacherId] ON [Master].[SubjectTeacher] ([TeacherId]);
GO

CREATE INDEX [IX_SubjectTeacher_UpdatedById] ON [Master].[SubjectTeacher] ([UpdatedById]);
GO

CREATE INDEX [IX_Topic_LessonId] ON [Lesson].[Topic] ([LessonId]);
GO

CREATE INDEX [IX_TopicContent_TopicId] ON [Lesson].[TopicContent] ([TopicId]);
GO

ALTER TABLE [Lesson].[EssayStudentAnswer] ADD CONSTRAINT [FK_EssayStudentAnswer_EssayQuestionAnswer_EssayQuestionAnswerId] FOREIGN KEY ([EssayQuestionAnswerId]) REFERENCES [Lesson].[EssayQuestionAnswer] ([Id]) ON DELETE NO ACTION;
GO

ALTER TABLE [Lesson].[EssayStudentAnswer] ADD CONSTRAINT [FK_EssayStudentAnswer_Question_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Lesson].[Question] ([Id]) ON DELETE NO ACTION;
GO

ALTER TABLE [Lesson].[Question] ADD CONSTRAINT [FK_Question_StudentMCQQuestion_StudentMCQQuestionQuestionId_StudentMCQQuestionStudentId] FOREIGN KEY ([StudentMCQQuestionQuestionId], [StudentMCQQuestionStudentId]) REFERENCES [Lesson].[StudentMCQQuestion] ([QuestionId], [StudentId]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210723072837_Schoolmanagement00002', N'5.0.7');
GO

COMMIT;
GO

