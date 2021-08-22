BEGIN TRANSACTION;
GO

ALTER TABLE [Lesson].[Lesson] DROP CONSTRAINT [FK_Lesson_Subject_SubjectId];
GO

DROP INDEX [IX_Lesson_SubjectId] ON [Lesson].[Lesson];
GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-08-22T16:11:13.1038924Z', [UpdatedOn] = '2021-08-22T16:11:13.1039833Z'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[User] SET [CreatedOn] = '2021-08-22T16:11:13.1042531Z', [UpdatedOn] = '2021-08-22T16:11:13.1042543Z'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-08-22T16:11:13.1479455Z', [UpdatedOn] = '2021-08-22T16:11:13.1480339Z'
WHERE [RoleId] = 1 AND [UserId] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Account].[UserRole] SET [CreatedOn] = '2021-08-22T16:11:13.1485312Z', [UpdatedOn] = '2021-08-22T16:11:13.1485321Z'
WHERE [RoleId] = 2 AND [UserId] = 2;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_Lesson_SubjectId_AcademicLevelId] ON [Lesson].[Lesson] ([SubjectId], [AcademicLevelId]);
GO

ALTER TABLE [Lesson].[Lesson] ADD CONSTRAINT [FK_Lesson_SubjectAcademicLevel_SubjectId_AcademicLevelId] FOREIGN KEY ([SubjectId], [AcademicLevelId]) REFERENCES [Master].[SubjectAcademicLevel] ([SubjectId], [AcademicLevelId]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210822161116_Schoolmanagement00002', N'5.0.8');
GO

COMMIT;
GO

