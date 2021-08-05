BEGIN TRANSACTION;
GO

ALTER TABLE [Lesson].[Lesson] ADD [IsActive] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-08-05T10:58:30.3564637Z', [UpdatedOn] = '2021-08-05T10:58:30.3564882Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-08-05T10:58:30.3565834Z', [UpdatedOn] = '2021-08-05T10:58:30.3565836Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-08-05T10:58:30.3666081Z', [UpdatedOn] = '2021-08-05T10:58:30.3666383Z'
WHERE [RoleId] = 1 AND [UserId] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-08-05T10:58:30.3667575Z', [UpdatedOn] = '2021-08-05T10:58:30.3667577Z'
WHERE [RoleId] = 2 AND [UserId] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210805105832_Schoolmanagement00008', N'5.0.8');
GO

COMMIT;
GO

