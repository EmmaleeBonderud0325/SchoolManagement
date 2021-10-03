BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Lesson].[Lesson]') AND [c].[name] = N'SubjectId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Lesson].[Lesson] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Lesson].[Lesson] ALTER COLUMN [SubjectId] int NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Lesson].[Lesson]') AND [c].[name] = N'ClassNameId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Lesson].[Lesson] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Lesson].[Lesson] ALTER COLUMN [ClassNameId] int NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Lesson].[Lesson]') AND [c].[name] = N'AcademicYearId');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Lesson].[Lesson] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Lesson].[Lesson] ALTER COLUMN [AcademicYearId] int NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Lesson].[Lesson]') AND [c].[name] = N'AcademicLevelId');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Lesson].[Lesson] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Lesson].[Lesson] ALTER COLUMN [AcademicLevelId] int NULL;
GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-09-30T12:58:09.9402024Z', [UpdatedOn] = '2021-09-30T12:58:09.9402670Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-09-30T12:58:09.9404727Z', [UpdatedOn] = '2021-09-30T12:58:09.9404732Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-09-30T12:58:09.9658872Z', [UpdatedOn] = '2021-09-30T12:58:09.9659696Z'
WHERE [RoleId] = 1 AND [UserId] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-09-30T12:58:09.9663215Z', [UpdatedOn] = '2021-09-30T12:58:09.9663224Z'
WHERE [RoleId] = 2 AND [UserId] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210930125812_Schoolmanagement00004', N'5.0.10');
GO

COMMIT;
GO

