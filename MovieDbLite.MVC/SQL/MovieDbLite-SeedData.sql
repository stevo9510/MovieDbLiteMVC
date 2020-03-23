USE [MovieDbLite]
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [UserName], [EmailAddress], [HashedPassword]) VALUES (2, N'StevenAnderson', N'steven.a@fake.com', N'bbbbbadsfdsaewafeawf')
GO
INSERT [dbo].[User] ([Id], [UserName], [EmailAddress], [HashedPassword]) VALUES (3, N'Billy', N'Billy@fake.com', N'$2b$15$kPFqnE46Z4CyvE1FuUxywuKk7MmdGTZPy8SU3tI3C83rXxGIZSZ.2')
GO
INSERT [dbo].[User] ([Id], [UserName], [EmailAddress], [HashedPassword]) VALUES (4, N'Alice', N'Alice@fake.com', N'$2b$15$IaORm9y5.GEpQ6CNiBbOVe69AKm9vuWEyj0XfGdkPpFH7wq3kGTCm')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
INSERT [dbo].[RestrictionRating] ([Id], [Code], [ShortDescription], [LongDescription], [IsActive]) VALUES (1, N'G', N'General Audiences', N'All ages admitted. Nothing that would offend parents for viewing by children.', 1)
GO
INSERT [dbo].[RestrictionRating] ([Id], [Code], [ShortDescription], [LongDescription], [IsActive]) VALUES (2, N'PG', N'Parental Guidance Suggested', N'Some material may not be suitable for children. Parents urged to give "parental guidance". May contain some material parents might not like for their young children.', 1)
GO
INSERT [dbo].[RestrictionRating] ([Id], [Code], [ShortDescription], [LongDescription], [IsActive]) VALUES (3, N'PG-13', N'Parents Strongly Cautioned', N'Some material may be inappropriate for children under 13. Parents are urged to be cautious. Some material may be inappropriate for pre-teenagers.', 1)
GO
INSERT [dbo].[RestrictionRating] ([Id], [Code], [ShortDescription], [LongDescription], [IsActive]) VALUES (4, N'R', N'Restricted', N'Under 17 requires accompanying parent or adult guardian. Contains some adult material. Parents are urged to learn more about the film before taking their young children with them.', 1)
GO
INSERT [dbo].[RestrictionRating] ([Id], [Code], [ShortDescription], [LongDescription], [IsActive]) VALUES (5, N'NC-17', N'Adults Only', N'No One 17 and Under Admitted. Clearly adult. Children are not admitted.', 1)
GO
INSERT [dbo].[Language] ([Id], [Name]) VALUES (1, N'English')
GO
INSERT [dbo].[Language] ([Id], [Name]) VALUES (2, N'French')
GO
INSERT [dbo].[Language] ([Id], [Name]) VALUES (3, N'German')
GO
INSERT [dbo].[Language] ([Id], [Name]) VALUES (4, N'Italian')
GO
INSERT [dbo].[Language] ([Id], [Name]) VALUES (5, N'Spanish')
GO
INSERT [dbo].[Language] ([Id], [Name]) VALUES (6, N'Japanese')
GO
INSERT [dbo].[Language] ([Id], [Name]) VALUES (7, N'Korean')
GO
INSERT [dbo].[Language] ([Id], [Name]) VALUES (8, N'Russian')
GO
SET IDENTITY_INSERT [dbo].[AwardShow] ON 
GO
INSERT [dbo].[AwardShow] ([Id], [ShowName], [Description]) VALUES (1, N'Oscars', N'Awards for artistic and technical merit in the film industry. ')
GO
INSERT [dbo].[AwardShow] ([Id], [ShowName], [Description]) VALUES (2, N'Critics'' Choice Movie Awards', N'An awards show presented annually by the American-Canadian Broadcast Film Critics Association (BFCA) to honor the finest in cinematic achievement.')
GO
INSERT [dbo].[AwardShow] ([Id], [ShowName], [Description]) VALUES (3, N'Golden Globes', N'Hosted by the 93 members of the Hollywood Foreign Press Association, the Golden Globe Awards recognize excellence in film and television, both domestic and foreign.')
GO
SET IDENTITY_INSERT [dbo].[AwardShow] OFF
GO
SET IDENTITY_INSERT [dbo].[Award] ON 
GO
INSERT [dbo].[Award] ([Id], [AwardShowId], [AwardName], [Description]) VALUES (1, 3, N'Best Motion Picture - Drama', NULL)
GO
INSERT [dbo].[Award] ([Id], [AwardShowId], [AwardName], [Description]) VALUES (2, 3, N'Best Motion Picture - Comedy', NULL)
GO
INSERT [dbo].[Award] ([Id], [AwardShowId], [AwardName], [Description]) VALUES (4, 3, N'Best Director - Motion Picture', NULL)
GO
INSERT [dbo].[Award] ([Id], [AwardShowId], [AwardName], [Description]) VALUES (5, 3, N'Best Actor - Motion Picture Drama', NULL)
GO
INSERT [dbo].[Award] ([Id], [AwardShowId], [AwardName], [Description]) VALUES (6, 1, N'Best Picture', NULL)
GO
INSERT [dbo].[Award] ([Id], [AwardShowId], [AwardName], [Description]) VALUES (7, 1, N'Best Director', NULL)
GO
INSERT [dbo].[Award] ([Id], [AwardShowId], [AwardName], [Description]) VALUES (8, 1, N'Best Actor', NULL)
GO
INSERT [dbo].[Award] ([Id], [AwardShowId], [AwardName], [Description]) VALUES (9, 1, N'Best Actress', NULL)
GO
INSERT [dbo].[Award] ([Id], [AwardShowId], [AwardName], [Description]) VALUES (10, 1, N'Best Supporting Actor', NULL)
GO
INSERT [dbo].[Award] ([Id], [AwardShowId], [AwardName], [Description]) VALUES (11, 1, N'Best Costume Design', NULL)
GO
INSERT [dbo].[Award] ([Id], [AwardShowId], [AwardName], [Description]) VALUES (12, 1, N'Best Visual Effects', NULL)
GO
INSERT [dbo].[Award] ([Id], [AwardShowId], [AwardName], [Description]) VALUES (13, 2, N'Best Action Movie', NULL)
GO
INSERT [dbo].[Award] ([Id], [AwardShowId], [AwardName], [Description]) VALUES (14, 2, N'Best Actor', NULL)
GO
INSERT [dbo].[Award] ([Id], [AwardShowId], [AwardName], [Description]) VALUES (15, 2, N'Best Actress', NULL)
GO
INSERT [dbo].[Award] ([Id], [AwardShowId], [AwardName], [Description]) VALUES (16, 2, N'Best Animated Feature', NULL)
GO
INSERT [dbo].[Award] ([Id], [AwardShowId], [AwardName], [Description]) VALUES (17, 2, N'Best Cinematography', NULL)
GO
INSERT [dbo].[Award] ([Id], [AwardShowId], [AwardName], [Description]) VALUES (18, 2, N'Best Editing', NULL)
GO
SET IDENTITY_INSERT [dbo].[Award] OFF
GO
SET IDENTITY_INSERT [dbo].[FilmMember] ON 
GO
INSERT [dbo].[FilmMember] ([Id], [Prefix], [FirstName], [MiddleName], [LastName], [Suffix], [PreferredFullName], [Gender], [DateOfBirth], [DateOfDeath], [Biography]) VALUES (3, NULL, N'Leonardo', NULL, N'DiCaprio', NULL, N'Leonardo DiCaprio', N'M', CAST(N'1974-11-11' AS Date), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[FilmMember] OFF
GO
INSERT [dbo].[FilmRole] ([Id], [RoleName], [Description]) VALUES (1, N'Producer', NULL)
GO
INSERT [dbo].[FilmRole] ([Id], [RoleName], [Description]) VALUES (2, N'Actor', NULL)
GO
INSERT [dbo].[FilmRole] ([Id], [RoleName], [Description]) VALUES (3, N'Director', NULL)
GO
INSERT [dbo].[FilmRole] ([Id], [RoleName], [Description]) VALUES (4, N'Screenwriter', NULL)
GO
INSERT [dbo].[FilmRole] ([Id], [RoleName], [Description]) VALUES (5, N'Costume Designer', NULL)
GO
INSERT [dbo].[FilmRole] ([Id], [RoleName], [Description]) VALUES (6, N'Cinematographer', NULL)
GO
INSERT [dbo].[FilmRole] ([Id], [RoleName], [Description]) VALUES (7, N'Editor', NULL)
GO
INSERT [dbo].[FilmRole] ([Id], [RoleName], [Description]) VALUES (8, N'Music Supervisor', NULL)
GO
INSERT [dbo].[Genre] ([Id], [GenreName], [Description]) VALUES (1, N'Action', N'A film genre in which the protagonist or protagonists are thrust into a series of events that typically include violence, extended fighting, physical feats, and frantic chases')
GO
INSERT [dbo].[Genre] ([Id], [GenreName], [Description]) VALUES (2, N'Science Fiction', NULL)
GO
INSERT [dbo].[Genre] ([Id], [GenreName], [Description]) VALUES (3, N'Comedy', NULL)
GO
INSERT [dbo].[Genre] ([Id], [GenreName], [Description]) VALUES (4, N'Horror', N'A genre for a film that seeks to elicit fear for entertainment purposes')
GO
INSERT [dbo].[Genre] ([Id], [GenreName], [Description]) VALUES (5, N'Animation', NULL)
GO
INSERT [dbo].[Genre] ([Id], [GenreName], [Description]) VALUES (6, N'Romance', NULL)
GO
INSERT [dbo].[Genre] ([Id], [GenreName], [Description]) VALUES (7, N'Documentary', NULL)
GO
INSERT [dbo].[Genre] ([Id], [GenreName], [Description]) VALUES (8, N'Drama', NULL)
GO
INSERT [dbo].[Genre] ([Id], [GenreName], [Description]) VALUES (9, N'Thriller', NULL)
GO
INSERT [dbo].[Genre] ([Id], [GenreName], [Description]) VALUES (10, N'Adventure', NULL)
GO
INSERT [dbo].[Genre] ([Id], [GenreName], [Description]) VALUES (11, N'Western', NULL)
GO