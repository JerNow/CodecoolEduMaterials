USE [CodecoolEduMaterials.AuthDb]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'f0827f58-bed0-4ca4-8b58-332d5802b766', N'Admin', N'ADMIN', N'b7a4e467-d046-4b16-9d87-5f641e116229')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6440b201-9aa4-4109-9097-25cb07108338', N'User', N'USER', N'user@example.com', N'USER@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAEBT9N/ogeeiy0x/45FUdj4cU22lr1SKc5oesLGTul8bELH/FTUu35LBp7ItCHVzX2g==', N'7LKYXYILOKXRV5633HL7R4M6TSYSQ5PE', N'8df2b2a1-83e5-415e-b51f-fb2811c34c55', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'be12df84-b853-40dc-83d0-6896bef20879', N'Admin', N'ADMIN', N'admin@admin.com', N'ADMIN@ADMIN.COM', 0, N'AQAAAAEAACcQAAAAEEwyMalMEcWZdGEm4RM/iOz6xIMLPhqqcYO1Y0mrfyyNHHrbc9UsWIrG2cRHGzQWFQ==', N'NSZWOEOH6STUPKDNMBEKS4T6KF5ISPS4', N'f422c8c0-f3b0-435b-ad41-de61ff9f3e91', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'be12df84-b853-40dc-83d0-6896bef20879', N'f0827f58-bed0-4ca4-8b58-332d5802b766')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220808100658_InitialAuthDbCreate', N'6.0.7')
GO
