BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Account].[User]') AND [c].[name] = N'ProfileImage');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Account].[User] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Account].[User] ALTER COLUMN [ProfileImage] nvarchar(max) NULL;
GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-10-05T19:51:32.2607289Z', [ProfileImage] = NULL, [UpdatedOn] = '2021-10-05T19:51:32.2607555Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-10-05T19:51:32.2608330Z', [ProfileImage] = NULL, [UpdatedOn] = '2021-10-05T19:51:32.2608332Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-10-05T19:51:32.2720637Z', [UpdatedOn] = '2021-10-05T19:51:32.2720985Z'
WHERE [RoleId] = 1 AND [UserId] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-10-05T19:51:32.2722338Z', [UpdatedOn] = '2021-10-05T19:51:32.2722340Z'
WHERE [RoleId] = 2 AND [UserId] = 2;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211005195135_Schoolmanagement00008', N'5.0.10');
GO

COMMIT;
GO

