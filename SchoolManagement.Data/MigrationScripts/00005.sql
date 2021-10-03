BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Lesson].[Lesson]') AND [c].[name] = N'PlannedDate');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Lesson].[Lesson] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Lesson].[Lesson] ALTER COLUMN [PlannedDate] datetime2 NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Lesson].[Lesson]') AND [c].[name] = N'CompletedDate');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Lesson].[Lesson] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Lesson].[Lesson] ALTER COLUMN [CompletedDate] datetime2 NULL;
GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-09-30T13:22:38.9333424Z', [UpdatedOn] = '2021-09-30T13:22:38.9333666Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-09-30T13:22:38.9334318Z', [UpdatedOn] = '2021-09-30T13:22:38.9334320Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-09-30T13:22:38.9439385Z', [UpdatedOn] = '2021-09-30T13:22:38.9439707Z'
WHERE [RoleId] = 1 AND [UserId] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-09-30T13:22:38.9440933Z', [UpdatedOn] = '2021-09-30T13:22:38.9440935Z'
WHERE [RoleId] = 2 AND [UserId] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210930132240_Schoolmanagement00005', N'5.0.10');
GO

COMMIT;
GO

