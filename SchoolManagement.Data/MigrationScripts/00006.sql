BEGIN TRANSACTION;
GO

ALTER TABLE [Lesson].[EssayStudentAnswer] DROP CONSTRAINT [FK_EssayStudentAnswer_EssayQuestionAnswer_EssayQuestionAnswerId];
GO

EXEC sp_rename N'[Lesson].[Question].[SequnceNo]', N'SequenceNo', N'COLUMN';
GO

DROP INDEX [IX_EssayStudentAnswer_EssayQuestionAnswerId] ON [Lesson].[EssayStudentAnswer];
DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Lesson].[EssayStudentAnswer]') AND [c].[name] = N'EssayQuestionAnswerId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Lesson].[EssayStudentAnswer] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Lesson].[EssayStudentAnswer] ALTER COLUMN [EssayQuestionAnswerId] int NOT NULL;
ALTER TABLE [Lesson].[EssayStudentAnswer] ADD DEFAULT 0 FOR [EssayQuestionAnswerId];
CREATE INDEX [IX_EssayStudentAnswer_EssayQuestionAnswerId] ON [Lesson].[EssayStudentAnswer] ([EssayQuestionAnswerId]);
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Lesson].[EssayStudentAnswer]') AND [c].[name] = N'AnswerText');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Lesson].[EssayStudentAnswer] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Lesson].[EssayStudentAnswer] ALTER COLUMN [AnswerText] nvarchar(max) NULL;
GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-08-03T14:21:29.9691473Z', [UpdatedOn] = '2021-08-03T14:21:29.9691991Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-08-03T14:21:29.9694216Z', [UpdatedOn] = '2021-08-03T14:21:29.9694220Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-08-03T14:21:29.9892927Z', [UpdatedOn] = '2021-08-03T14:21:29.9893460Z'
WHERE [RoleId] = 1 AND [UserId] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-08-03T14:21:29.9895623Z', [UpdatedOn] = '2021-08-03T14:21:29.9895626Z'
WHERE [RoleId] = 2 AND [UserId] = 2;
SELECT @@ROWCOUNT;

GO

ALTER TABLE [Lesson].[EssayStudentAnswer] ADD CONSTRAINT [FK_EssayStudentAnswer_EssayQuestionAnswer_EssayQuestionAnswerId] FOREIGN KEY ([EssayQuestionAnswerId]) REFERENCES [Lesson].[EssayQuestionAnswer] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210803142132_Schoolmanagement00006', N'5.0.8');
GO

COMMIT;
GO

