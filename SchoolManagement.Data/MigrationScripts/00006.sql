BEGIN TRANSACTION;
GO

ALTER TABLE [Master].[AcademicYear] ADD [IsCurrentYear] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-10-02T12:01:06.1309524Z', [UpdatedOn] = '2021-10-02T12:01:06.1310183Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-10-02T12:01:06.1312195Z', [UpdatedOn] = '2021-10-02T12:01:06.1312200Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-10-02T12:01:06.1580994Z', [UpdatedOn] = '2021-10-02T12:01:06.1581828Z'
WHERE [RoleId] = 1 AND [UserId] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-10-02T12:01:06.1585653Z', [UpdatedOn] = '2021-10-02T12:01:06.1585658Z'
WHERE [RoleId] = 2 AND [UserId] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211002120108_Schoolmanagement00006', N'5.0.10');
GO

COMMIT;
GO

