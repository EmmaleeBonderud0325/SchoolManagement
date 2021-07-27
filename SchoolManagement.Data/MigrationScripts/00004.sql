BEGIN TRANSACTION;
GO

ALTER TABLE [Lesson].[StudentLessonTopicContenet] DROP CONSTRAINT [FK_StudentLessonTopicContenet_Student_StudentId];
GO

ALTER TABLE [Lesson].[StudentLessonTopicContenet] DROP CONSTRAINT [FK_StudentLessonTopicContenet_TopicContent_TopicContentId];
GO

ALTER TABLE [Lesson].[StudentLessonTopicContenet] DROP CONSTRAINT [PK_StudentLessonTopicContenet];
GO

EXEC sp_rename N'[Lesson].[StudentLessonTopicContenet]', N'StudentLessonTopicContent';
GO

EXEC sp_rename N'[Lesson].[StudentLessonTopicContent].[IX_StudentLessonTopicContenet_StudentId]', N'IX_StudentLessonTopicContent_StudentId', N'INDEX';
GO

ALTER TABLE [Lesson].[StudentLessonTopicContent] ADD CONSTRAINT [PK_StudentLessonTopicContent] PRIMARY KEY ([TopicContentId], [StudentId]);
GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-07-27T09:29:18.8639758Z', [UpdatedOn] = '2021-07-27T09:29:18.8639987Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-07-27T09:29:18.8640641Z', [UpdatedOn] = '2021-07-27T09:29:18.8640643Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-07-27T09:29:18.8737133Z', [UpdatedOn] = '2021-07-27T09:29:18.8737455Z'
WHERE [RoleId] = 1 AND [UserId] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-07-27T09:29:18.8738707Z', [UpdatedOn] = '2021-07-27T09:29:18.8738709Z'
WHERE [RoleId] = 2 AND [UserId] = 2;
SELECT @@ROWCOUNT;

GO

ALTER TABLE [Lesson].[StudentLessonTopicContent] ADD CONSTRAINT [FK_StudentLessonTopicContent_Student_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Master].[Student] ([Id]) ON DELETE NO ACTION;
GO

ALTER TABLE [Lesson].[StudentLessonTopicContent] ADD CONSTRAINT [FK_StudentLessonTopicContent_TopicContent_TopicContentId] FOREIGN KEY ([TopicContentId]) REFERENCES [Lesson].[TopicContent] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210727092921_Schoolmanagement00004', N'5.0.8');
GO

COMMIT;
GO

