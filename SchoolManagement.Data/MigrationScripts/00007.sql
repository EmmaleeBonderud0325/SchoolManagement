BEGIN TRANSACTION;
GO

ALTER TABLE [Lesson].[EssayStudentAnswer] DROP CONSTRAINT [FK_EssayStudentAnswer_EssayQuestionAnswer_EssayQuestionAnswerId];
GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-08-04T05:34:35.6778822Z', [UpdatedOn] = '2021-08-04T05:34:35.6779180Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-08-04T05:34:35.6780590Z', [UpdatedOn] = '2021-08-04T05:34:35.6780593Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-08-04T05:34:35.6912435Z', [UpdatedOn] = '2021-08-04T05:34:35.6912782Z'
WHERE [RoleId] = 1 AND [UserId] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-08-04T05:34:35.6914146Z', [UpdatedOn] = '2021-08-04T05:34:35.6914148Z'
WHERE [RoleId] = 2 AND [UserId] = 2;
SELECT @@ROWCOUNT;

GO

ALTER TABLE [Lesson].[EssayStudentAnswer] ADD CONSTRAINT [FK_EssayStudentAnswer_EssayQuestionAnswer_EssayQuestionAnswerId] FOREIGN KEY ([EssayQuestionAnswerId]) REFERENCES [Lesson].[EssayQuestionAnswer] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210804053438_Schoolmanagement00007', N'5.0.8');
GO

COMMIT;
GO

