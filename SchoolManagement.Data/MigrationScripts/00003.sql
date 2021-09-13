BEGIN TRANSACTION;
GO

ALTER TABLE [Master].[StudentClass] ADD [IsActive] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-09-12T06:10:32.0657484Z', [UpdatedOn] = '2021-09-12T06:10:32.0658149Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-09-12T06:10:32.0659372Z', [UpdatedOn] = '2021-09-12T06:10:32.0659377Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-09-12T06:10:32.0767260Z', [UpdatedOn] = '2021-09-12T06:10:32.0767582Z'
WHERE [RoleId] = 1 AND [UserId] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-09-12T06:10:32.0768791Z', [UpdatedOn] = '2021-09-12T06:10:32.0768793Z'
WHERE [RoleId] = 2 AND [UserId] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210912061034_Schoolmanagement00003', N'5.0.8');
GO

COMMIT;
GO

