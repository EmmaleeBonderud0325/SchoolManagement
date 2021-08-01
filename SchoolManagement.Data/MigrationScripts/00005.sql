BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Lesson].[LessonAssignment].[CreatedByOn]', N'CreatedOn', N'COLUMN';
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Master].[Subject]') AND [c].[name] = N'ParentBasketSubjectId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Master].[Subject] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Master].[Subject] ALTER COLUMN [ParentBasketSubjectId] int NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Master].[Class]') AND [c].[name] = N'LanguageStream');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Master].[Class] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Master].[Class] ALTER COLUMN [LanguageStream] int NOT NULL;
ALTER TABLE [Master].[Class] ADD DEFAULT 0 FOR [LanguageStream];
GO

ALTER TABLE [Master].[Class] ADD [CreatedOn] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-08-01T06:56:11.6007162Z', [UpdatedOn] = '2021-08-01T06:56:11.6007541Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-08-01T06:56:11.6008883Z', [UpdatedOn] = '2021-08-01T06:56:11.6008887Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-08-01T06:56:11.6193554Z', [UpdatedOn] = '2021-08-01T06:56:11.6194067Z'
WHERE [RoleId] = 1 AND [UserId] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-08-01T06:56:11.6196016Z', [UpdatedOn] = '2021-08-01T06:56:11.6196019Z'
WHERE [RoleId] = 2 AND [UserId] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210801065613_Schoolmanagement00005', N'5.0.8');
GO

COMMIT;
GO

