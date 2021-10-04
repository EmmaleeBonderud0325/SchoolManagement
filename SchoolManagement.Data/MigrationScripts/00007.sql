BEGIN TRANSACTION;
GO

ALTER TABLE [Lesson].[TopicContent] ADD [Name] nvarchar(max) NULL;
GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-10-03T22:05:30.5076327Z', [UpdatedOn] = '2021-10-03T22:05:30.5076560Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-10-03T22:05:30.5077200Z', [UpdatedOn] = '2021-10-03T22:05:30.5077201Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-10-03T22:05:30.5184365Z', [UpdatedOn] = '2021-10-03T22:05:30.5184771Z'
WHERE [RoleId] = 1 AND [UserId] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-10-03T22:05:30.5186077Z', [UpdatedOn] = '2021-10-03T22:05:30.5186079Z'
WHERE [RoleId] = 2 AND [UserId] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211003220533_Schoolmanagement00007', N'5.0.10');
GO

COMMIT;
GO

