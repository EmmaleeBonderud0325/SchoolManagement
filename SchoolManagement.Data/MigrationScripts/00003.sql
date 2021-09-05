BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Lesson].[LessonAssignment].[Descripstion]', N'Description', N'COLUMN';
GO

ALTER TABLE [Lesson].[LessonAssignment] ADD [DuetDate] datetime2 NULL;
GO

ALTER TABLE [Lesson].[LessonAssignment] ADD [StartDate] datetime2 NULL;
GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-08-28T13:12:28.4819001Z', [UpdatedOn] = '2021-08-28T13:12:28.4819405Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-08-28T13:12:28.4821251Z', [UpdatedOn] = '2021-08-28T13:12:28.4821261Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-08-28T13:12:28.4937542Z', [UpdatedOn] = '2021-08-28T13:12:28.4937847Z'
WHERE [RoleId] = 1 AND [UserId] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-08-28T13:12:28.4938994Z', [UpdatedOn] = '2021-08-28T13:12:28.4938996Z'
WHERE [RoleId] = 2 AND [UserId] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210828131230_Schoolmanagement00003', N'5.0.8');
GO

COMMIT;
GO

