BEGIN TRANSACTION;
GO

ALTER TABLE [Master].[Class] ADD [IsActive] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-09-12T03:52:42.4029177Z', [UpdatedOn] = '2021-09-12T03:52:42.4029854Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-09-12T03:52:42.4031878Z', [UpdatedOn] = '2021-09-12T03:52:42.4031882Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-09-12T03:52:42.4273358Z', [UpdatedOn] = '2021-09-12T03:52:42.4274163Z'
WHERE [RoleId] = 1 AND [UserId] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-09-12T03:52:42.4277427Z', [UpdatedOn] = '2021-09-12T03:52:42.4277432Z'
WHERE [RoleId] = 2 AND [UserId] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210912035244_Schoolmanagement00002', N'5.0.8');
GO

COMMIT;
GO

