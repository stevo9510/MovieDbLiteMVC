USE [MovieDbLite]
GO
/****** Object:  Table [dbo].[Award]    Script Date: 3/14/2020 10:40:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AwardShowId] [int] NOT NULL,
	[AwardName] [varchar](50) NOT NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AwardShow]    Script Date: 3/14/2020 10:40:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AwardShow](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShowName] [varchar](50) NOT NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_AwardShow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmMember]    Script Date: 3/14/2020 10:40:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmMember](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Prefix] [varchar](5) NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[Suffix] [varchar](5) NULL,
	[PreferredFullName] [varchar](150) NULL,
	[Gender] [char](1) NOT NULL,
	[DateOfBirth] [date] NULL,
	[DateOfDeath] [date] NULL,
	[Biography] [text] NULL,
 CONSTRAINT [PK_FilmMember] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmMemberAward]    Script Date: 3/14/2020 10:40:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmMemberAward](
	[FilmMemberId] [bigint] NOT NULL,
	[AwardId] [int] NOT NULL,
	[MovieId] [bigint] NOT NULL,
	[Year] [char](4) NOT NULL,
	[DateReceived] [date] NOT NULL,
 CONSTRAINT [PK_FilmMemberAward] PRIMARY KEY CLUSTERED 
(
	[FilmMemberId] ASC,
	[AwardId] ASC,
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmRole]    Script Date: 3/14/2020 10:40:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmRole](
	[Id] [int] NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_FilmRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 3/14/2020 10:40:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[Id] [int] NOT NULL,
	[DisplayName] [varchar](25) NOT NULL,
	[Description] [varchar](500) NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 3/14/2020 10:40:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 3/14/2020 10:40:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](200) NOT NULL,
	[Description] [text] NULL,
	[ReleaseDate] [date] NULL,
	[RestrictionRatingId] [smallint] NULL,
	[DirectorFilmMemberId] [bigint] NOT NULL,
	[DurationInMinutes] [int] NULL,
	[LanguageId] [int] NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_Actor]    Script Date: 3/14/2020 10:40:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_Actor](
	[MovieId] [bigint] NOT NULL,
	[ActorFilmMemberId] [bigint] NOT NULL,
	[RoleName] [varchar](150) NULL,
	[Sequence] [int] NULL,
 CONSTRAINT [PK_Movie_Actor] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[ActorFilmMemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_Genre]    Script Date: 3/14/2020 10:40:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_Genre](
	[MovieId] [bigint] NOT NULL,
	[GenreId] [int] NOT NULL,
 CONSTRAINT [PK_Movie_Genre] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieFilmMember]    Script Date: 3/14/2020 10:40:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieFilmMember](
	[MovieId] [bigint] NOT NULL,
	[FilmMemberId] [bigint] NOT NULL,
	[FilmRoleId] [int] NOT NULL,
 CONSTRAINT [PK_MovieFilmMember] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[FilmMemberId] ASC,
	[FilmRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieUserReview]    Script Date: 3/14/2020 10:40:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieUserReview](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[MovieId] [bigint] NOT NULL,
	[UserId] [int] NOT NULL,
	[Rating] [smallint] NOT NULL,
	[Review] [text] NULL,
	[DatePosted] [datetime] NOT NULL,
 CONSTRAINT [PK_MovieUserReview] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieUserReviewHelpful]    Script Date: 3/14/2020 10:40:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieUserReviewHelpful](
	[MovieUserReviewId] [bigint] NOT NULL,
	[UserId] [int] NOT NULL,
	[Helpful] [bit] NOT NULL,
 CONSTRAINT [PK_MovieUserReviewHelpful] PRIMARY KEY CLUSTERED 
(
	[MovieUserReviewId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RestrictionRating]    Script Date: 3/14/2020 10:40:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestrictionRating](
	[Id] [smallint] NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[ShortDescription] [varchar](50) NOT NULL,
	[LongDescription] [varchar](200) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_RestrictionRating] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/14/2020 10:40:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](25) NOT NULL,
	[EmailAddress] [varchar](255) NOT NULL,
	[HashedPassword] [varchar](60) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Award]  WITH CHECK ADD  CONSTRAINT [FK_Award_AwardShow] FOREIGN KEY([AwardShowId])
REFERENCES [dbo].[AwardShow] ([Id])
GO
ALTER TABLE [dbo].[Award] CHECK CONSTRAINT [FK_Award_AwardShow]
GO
ALTER TABLE [dbo].[FilmMemberAward]  WITH CHECK ADD  CONSTRAINT [FK_FilmMemberAward_Award] FOREIGN KEY([AwardId])
REFERENCES [dbo].[Award] ([Id])
GO
ALTER TABLE [dbo].[FilmMemberAward] CHECK CONSTRAINT [FK_FilmMemberAward_Award]
GO
ALTER TABLE [dbo].[FilmMemberAward]  WITH CHECK ADD  CONSTRAINT [FK_FilmMemberAward_FilmMember] FOREIGN KEY([FilmMemberId])
REFERENCES [dbo].[FilmMember] ([Id])
GO
ALTER TABLE [dbo].[FilmMemberAward] CHECK CONSTRAINT [FK_FilmMemberAward_FilmMember]
GO
ALTER TABLE [dbo].[FilmMemberAward]  WITH CHECK ADD  CONSTRAINT [FK_FilmMemberAward_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[FilmMemberAward] CHECK CONSTRAINT [FK_FilmMemberAward_Movie]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Language] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Language] ([Id])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_Language]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_RestrictionRating] FOREIGN KEY([RestrictionRatingId])
REFERENCES [dbo].[RestrictionRating] ([Id])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_RestrictionRating]
GO
ALTER TABLE [dbo].[Movie_Actor]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Actor_FilmMember] FOREIGN KEY([ActorFilmMemberId])
REFERENCES [dbo].[FilmMember] ([Id])
GO
ALTER TABLE [dbo].[Movie_Actor] CHECK CONSTRAINT [FK_Movie_Actor_FilmMember]
GO
ALTER TABLE [dbo].[Movie_Actor]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Actor_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[Movie_Actor] CHECK CONSTRAINT [FK_Movie_Actor_Movie]
GO
ALTER TABLE [dbo].[Movie_Genre]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Genre_Genre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([Id])
GO
ALTER TABLE [dbo].[Movie_Genre] CHECK CONSTRAINT [FK_Movie_Genre_Genre]
GO
ALTER TABLE [dbo].[Movie_Genre]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Genre_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[Movie_Genre] CHECK CONSTRAINT [FK_Movie_Genre_Movie]
GO
ALTER TABLE [dbo].[MovieFilmMember]  WITH CHECK ADD  CONSTRAINT [FK_MovieFilmMember_FilmMember] FOREIGN KEY([FilmMemberId])
REFERENCES [dbo].[FilmMember] ([Id])
GO
ALTER TABLE [dbo].[MovieFilmMember] CHECK CONSTRAINT [FK_MovieFilmMember_FilmMember]
GO
ALTER TABLE [dbo].[MovieFilmMember]  WITH CHECK ADD  CONSTRAINT [FK_MovieFilmMember_FilmRole] FOREIGN KEY([FilmRoleId])
REFERENCES [dbo].[FilmRole] ([Id])
GO
ALTER TABLE [dbo].[MovieFilmMember] CHECK CONSTRAINT [FK_MovieFilmMember_FilmRole]
GO
ALTER TABLE [dbo].[MovieFilmMember]  WITH CHECK ADD  CONSTRAINT [FK_MovieFilmMember_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[MovieFilmMember] CHECK CONSTRAINT [FK_MovieFilmMember_Movie]
GO
ALTER TABLE [dbo].[MovieUserReview]  WITH CHECK ADD  CONSTRAINT [FK_MovieUserReview_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[MovieUserReview] CHECK CONSTRAINT [FK_MovieUserReview_Movie]
GO
ALTER TABLE [dbo].[MovieUserReview]  WITH CHECK ADD  CONSTRAINT [FK_MovieUserReview_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[MovieUserReview] CHECK CONSTRAINT [FK_MovieUserReview_User]
GO
ALTER TABLE [dbo].[MovieUserReviewHelpful]  WITH CHECK ADD  CONSTRAINT [FK_MovieUserReviewHelpful_MovieUserReview] FOREIGN KEY([MovieUserReviewId])
REFERENCES [dbo].[MovieUserReview] ([Id])
GO
ALTER TABLE [dbo].[MovieUserReviewHelpful] CHECK CONSTRAINT [FK_MovieUserReviewHelpful_MovieUserReview]
GO
ALTER TABLE [dbo].[MovieUserReviewHelpful]  WITH CHECK ADD  CONSTRAINT [FK_MovieUserReviewHelpful_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[MovieUserReviewHelpful] CHECK CONSTRAINT [FK_MovieUserReviewHelpful_User]
GO
