USE [MovieDbLite]
GO
SET IDENTITY_INSERT [dbo].[FilmMember] ON 
GO
INSERT [dbo].[FilmMember] ([Id], [Prefix], [FirstName], [MiddleName], [LastName], [Suffix], [PreferredFullName], [Gender], [DateOfBirth], [DateOfDeath], [Biography]) VALUES (3, NULL, N'Leonardo', NULL, N'DiCaprio', NULL, N'Leonardo DiCaprio', N'M', CAST(N'1974-11-11' AS Date), NULL, NULL)
GO
INSERT [dbo].[FilmMember] ([Id], [Prefix], [FirstName], [MiddleName], [LastName], [Suffix], [PreferredFullName], [Gender], [DateOfBirth], [DateOfDeath], [Biography]) VALUES (4, NULL, N'James', NULL, N'Cameron', NULL, N'James Cameron', N'M', CAST(N'1954-08-16' AS Date), NULL, N'James Francis Cameron was born on August 16, 1954 in Kapuskasing, Ontario, Canada. He moved to the United States in 1971. The son of an engineer, he majored in physics at California State University before switching to English, and eventually dropping out. He then drove a truck to support his screenwriting ambition. He landed his first professional film job as art director, miniature-set builder, and process-projection supervisor on Roger Corman''s Battle Beyond the Stars (1980) and had his first experience as a director with a two week stint on Piranha II: The Spawning (1981) before being fired. In 1984, he wrote and directed The Terminator (1984), a futuristic action-thriller starring Arnold Schwarzenegger, Michael Biehn and Linda Hamilton. It was a huge success. After this came a string of successful science-fiction action films such as Aliens (1986), The Abyss (1989) and Terminator 2: Judgment Day (1991). In 1990, Cameron formed his own production company, Lightstorm Entertainment. In 1997, he wrote and directed Titanic (1997), a romance epic about two young lovers from different social classes who meet on board the famous ship. The movie went on to break all box office records and earned eleven Academy Awards. It became the highest grossing movie of all time. The rest is history. James Cameron is now one of the most sought-after directors in Hollywood. He was formerly married to producer Gale Anne Hurd, who produced several of his films. In 2000, he married actress Suzy Amis, who appeared in Titanic, and they have three children.')
GO
INSERT [dbo].[FilmMember] ([Id], [Prefix], [FirstName], [MiddleName], [LastName], [Suffix], [PreferredFullName], [Gender], [DateOfBirth], [DateOfDeath], [Biography]) VALUES (5, NULL, N'Kate', NULL, N'Winslet', NULL, N'Kate Winslet', N'F', CAST(N'1975-08-05' AS Date), NULL, NULL)
GO
INSERT [dbo].[FilmMember] ([Id], [Prefix], [FirstName], [MiddleName], [LastName], [Suffix], [PreferredFullName], [Gender], [DateOfBirth], [DateOfDeath], [Biography]) VALUES (6, NULL, N'Kathleen', N'Doyle', N'Bates', NULL, N'Kathy Bates', N'F', NULL, NULL, NULL)
GO
INSERT [dbo].[FilmMember] ([Id], [Prefix], [FirstName], [MiddleName], [LastName], [Suffix], [PreferredFullName], [Gender], [DateOfBirth], [DateOfDeath], [Biography]) VALUES (7, NULL, N'Pamela', NULL, N'Easley', NULL, N'Pamela Easley', N'F', NULL, NULL, NULL)
GO
INSERT [dbo].[FilmMember] ([Id], [Prefix], [FirstName], [MiddleName], [LastName], [Suffix], [PreferredFullName], [Gender], [DateOfBirth], [DateOfDeath], [Biography]) VALUES (8, NULL, N'Russell', NULL, N'Carpenter', NULL, N'Russell Carpenter', N'M', NULL, NULL, NULL)
GO
INSERT [dbo].[FilmMember] ([Id], [Prefix], [FirstName], [MiddleName], [LastName], [Suffix], [PreferredFullName], [Gender], [DateOfBirth], [DateOfDeath], [Biography]) VALUES (9, NULL, N'Deborah', N'Lynn', N'Scott', NULL, N'Deborah Scott', N'F', NULL, NULL, NULL)
GO
INSERT [dbo].[FilmMember] ([Id], [Prefix], [FirstName], [MiddleName], [LastName], [Suffix], [PreferredFullName], [Gender], [DateOfBirth], [DateOfDeath], [Biography]) VALUES (10, NULL, N'Lynne', NULL, N'Hockney', NULL, N'Lynne Hockney', N'F', NULL, NULL, NULL)
GO
INSERT [dbo].[FilmMember] ([Id], [Prefix], [FirstName], [MiddleName], [LastName], [Suffix], [PreferredFullName], [Gender], [DateOfBirth], [DateOfDeath], [Biography]) VALUES (11, NULL, N'James', NULL, N'Horner', NULL, N'James Horner', N'M', NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[FilmMember] OFF
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
SET IDENTITY_INSERT [dbo].[Movie] ON 
GO
INSERT [dbo].[Movie] ([Id], [Title], [Description], [ReleaseDate], [RestrictionRatingId], [DirectorFilmMemberId], [DurationInMinutes], [AverageUserRating]) VALUES (2, N'Fight Club', N'A ticking-time-bomb insomniac and a slippery soap salesman channel primal male aggression into a shocking new form of therapy. Their concept catches on, with underground "fight clubs" forming in every town, until an eccentric gets in the way and ignites an out-of-control spiral toward oblivion.', CAST(N'1999-10-15' AS Date), NULL, 3, 139, NULL)
GO
INSERT [dbo].[Movie] ([Id], [Title], [Description], [ReleaseDate], [RestrictionRatingId], [DirectorFilmMemberId], [DurationInMinutes], [AverageUserRating]) VALUES (3, N'Titanic', N'A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.', NULL, 3, 4, 194, NULL)
GO
SET IDENTITY_INSERT [dbo].[Movie] OFF
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
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (3, 6)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (3, 8)
GO
INSERT [dbo].[Language] ([LanguageIsoCode], [LanguageName]) VALUES (N'de', N'German')
GO
INSERT [dbo].[Language] ([LanguageIsoCode], [LanguageName]) VALUES (N'en', N'English')
GO
INSERT [dbo].[Language] ([LanguageIsoCode], [LanguageName]) VALUES (N'es', N'Spanish')
GO
INSERT [dbo].[Language] ([LanguageIsoCode], [LanguageName]) VALUES (N'fr', N'French')
GO
INSERT [dbo].[Language] ([LanguageIsoCode], [LanguageName]) VALUES (N'it', N'Italian')
GO
INSERT [dbo].[Language] ([LanguageIsoCode], [LanguageName]) VALUES (N'ja', N'Japanese')
GO
INSERT [dbo].[Language] ([LanguageIsoCode], [LanguageName]) VALUES (N'ko', N'Korean')
GO
INSERT [dbo].[Language] ([LanguageIsoCode], [LanguageName]) VALUES (N'rs', N'Russian')
GO
INSERT [dbo].[MovieCastMember] ([MovieId], [ActorFilmMemberId], [CharacterName], [Sequence]) VALUES (3, 3, N'Jack Dawson', 1)
GO
INSERT [dbo].[MovieCastMember] ([MovieId], [ActorFilmMemberId], [CharacterName], [Sequence]) VALUES (3, 5, N'Rose Dewitt Bukater', 2)
GO
INSERT [dbo].[MovieCastMember] ([MovieId], [ActorFilmMemberId], [CharacterName], [Sequence]) VALUES (3, 6, N'Molly Brown', 3)
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
INSERT [dbo].[MovieCrewMember] ([MovieId], [FilmMemberId], [FilmRoleId]) VALUES (3, 4, 1)
GO
INSERT [dbo].[MovieCrewMember] ([MovieId], [FilmMemberId], [FilmRoleId]) VALUES (3, 4, 4)
GO
INSERT [dbo].[MovieCrewMember] ([MovieId], [FilmMemberId], [FilmRoleId]) VALUES (3, 7, 1)
GO
INSERT [dbo].[MovieCrewMember] ([MovieId], [FilmMemberId], [FilmRoleId]) VALUES (3, 8, 6)
GO
INSERT [dbo].[MovieCrewMember] ([MovieId], [FilmMemberId], [FilmRoleId]) VALUES (3, 9, 5)
GO
INSERT [dbo].[MovieCrewMember] ([MovieId], [FilmMemberId], [FilmRoleId]) VALUES (3, 11, 8)
GO
INSERT [dbo].[ImageType] ([Id], [ImageExtension], [Name]) VALUES (1, N'.jpg', N'JPEG')
GO
INSERT [dbo].[ImageType] ([Id], [ImageExtension], [Name]) VALUES (2, N'.png', N'PNG')
GO
INSERT [dbo].[ImageType] ([Id], [ImageExtension], [Name]) VALUES (3, N'.tiff', N'TIFF')
GO
INSERT [dbo].[ImageType] ([Id], [ImageExtension], [Name]) VALUES (4, N'.bmp', N'BMP')
GO
INSERT [dbo].[UserRole] ([Id], [RoleName], [Description]) VALUES (1, N'User', N'Basic user with access to viewing details about movies/films as well as rating/reviewing films.')
GO
INSERT [dbo].[UserRole] ([Id], [RoleName], [Description]) VALUES (2, N'Admin', N'Administrative user with all the access of a basic user as well as the ability to manage certain data elements of system (such as movies, film members, etc.)')
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [UserRoleId], [UserName], [EmailAddress], [HashedPassword]) VALUES (2, 1, N'StevenAnderson', N'steven.a@fake.com', N'bbbbbadsfdsaewafeawf')
GO
INSERT [dbo].[User] ([Id], [UserRoleId], [UserName], [EmailAddress], [HashedPassword]) VALUES (3, 1, N'Billy', N'Billy@fake.com', N'$2b$15$mO6iwyH6PY7c8vrFqVxJ..g9cviH9M6S3iIt0Xblk9wwcHUh6.ff2')
GO
INSERT [dbo].[User] ([Id], [UserRoleId], [UserName], [EmailAddress], [HashedPassword]) VALUES (4, 1, N'Alice', N'Alice@fake.com', N'$2b$15$IaORm9y5.GEpQ6CNiBbOVe69AKm9vuWEyj0XfGdkPpFH7wq3kGTCm')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[AwardShowInstance] ON 
GO
INSERT [dbo].[AwardShowInstance] ([Id], [AwardShowId], [Year], [DateHosted]) VALUES (1, 1, 2019, CAST(N'2020-02-09' AS Date))
GO
SET IDENTITY_INSERT [dbo].[AwardShowInstance] OFF
GO
