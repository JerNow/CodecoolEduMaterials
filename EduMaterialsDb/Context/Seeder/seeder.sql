USE [CodecoolEduMaterials.EduMaterialsDb]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([AuthorId], [Name], [Description]) VALUES (1, N'Janusz Tracz', N'Najlepszy biznesman')
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[EduMaterialTypes] ON 

INSERT [dbo].[EduMaterialTypes] ([EduMaterialTypeId], [Name], [Definition]) VALUES (1, N'Youtube Video', N'A movie on Google''s platform')
INSERT [dbo].[EduMaterialTypes] ([EduMaterialTypeId], [Name], [Definition]) VALUES (2, N'Article', N'A written article on the internet')
INSERT [dbo].[EduMaterialTypes] ([EduMaterialTypeId], [Name], [Definition]) VALUES (3, N'Book', N'A physical book in library')
INSERT [dbo].[EduMaterialTypes] ([EduMaterialTypeId], [Name], [Definition]) VALUES (4, N'EBook', N'An electric version of a book in internet')
SET IDENTITY_INSERT [dbo].[EduMaterialTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[EduMaterials] ON 

INSERT [dbo].[EduMaterials] ([EduMaterialId], [Title], [AuthorId], [Description], [Location], [EduMaterialTypeId], [PublishDay]) VALUES (1, N'How to create API', 1, N'A tutorial on creation of API in .net', N'internet href here', 1, CAST(N'2022-05-12T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[EduMaterials] OFF
GO
SET IDENTITY_INSERT [dbo].[EduMaterialReviews] ON 

INSERT [dbo].[EduMaterialReviews] ([EduMaterialReviewId], [Review], [ReviewScore], [EduMaterialId]) VALUES (1, N'Best Video I''ve seen', 10, 1)
INSERT [dbo].[EduMaterialReviews] ([EduMaterialReviewId], [Review], [ReviewScore], [EduMaterialId]) VALUES (2, N'I Hate good content', 1, 1)
SET IDENTITY_INSERT [dbo].[EduMaterialReviews] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220808121547_InitialEduMaterialDbCreate', N'6.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220809214514_UpdateValidation', N'6.0.7')
GO
