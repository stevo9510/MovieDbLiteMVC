USE [MovieDbLite]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 3/29/2020 4:43:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](150) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[ReleaseDate] [date] NULL,
	[RestrictionRatingId] [smallint] NULL,
	[DirectorFilmMemberId] [bigint] NULL,
	[DurationInMinutes] [int] NULL,
	[AverageUserRating] [decimal](5, 2) NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[tvf_GetAllMovieFilmMembers]    Script Date: 3/29/2020 4:43:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Steven Anderson
-- Create date: 03/20/2020
-- Description:	Retrieves all the actors, director, and cast/crew members of a film.
-- =============================================
CREATE FUNCTION [dbo].[tvf_GetAllMovieFilmMembers] 
(	
	-- Add the parameters for the function here
	@MovieId bigint
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT 
		MovieCastMember.ActorFilmMemberId as FilmMemberId,
		cast(2 as int) as FilmRoleId,  -- @FilmRoleId_Actor
		MovieCastMember.CharacterName,
		MovieCastMember.Sequence
	FROM MovieCastMember
	WHERE MovieCastMember.MovieId = @MovieId
	
	UNION 

	SELECT 
		MovieCrewMember.FilmMemberId,
		MovieCrewMember.FilmRoleId,
		NULL, -- Role Name
		NULL  -- sequence
	FROM MovieCrewMember
	WHERE MovieCrewMember.MovieId = @MovieId

	UNION 

	SELECT 
		Movie.DirectorFilmMemberId,
		3, -- @FilmRoleId_Director
		NULL, -- RoleName
		NULL  -- sequence
	FROM Movie
	WHERE Movie.Id = @MovieId
)
GO
/****** Object:  Table [dbo].[AwardShow]    Script Date: 3/29/2020 4:43:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AwardShow](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[ShowName] [varchar](50) NOT NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_AwardShow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AwardShowInstance]    Script Date: 3/29/2020 4:43:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AwardShowInstance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AwardShowId] [smallint] NOT NULL,
	[Year] [char](4) NOT NULL,
	[DateHosted] [date] NOT NULL,
 CONSTRAINT [PK_AwardShowInstance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Award]    Script Date: 3/29/2020 4:43:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AwardShowId] [smallint] NOT NULL,
	[AwardName] [varchar](50) NOT NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AwardWinner]    Script Date: 3/29/2020 4:43:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AwardWinner](
	[AwardShowInstanceId] [int] NOT NULL,
	[AwardId] [int] NOT NULL,
	[FilmMemberId] [bigint] NOT NULL,
	[MovieId] [bigint] NOT NULL,
 CONSTRAINT [PK_AwardWinner] PRIMARY KEY CLUSTERED 
(
	[AwardShowInstanceId] ASC,
	[AwardId] ASC,
	[FilmMemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmMember]    Script Date: 3/29/2020 4:43:32 AM ******/
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
	[PreferredFullName] [varchar](150) NOT NULL,
	[Gender] [char](1) NOT NULL,
	[DateOfBirth] [date] NULL,
	[DateOfDeath] [date] NULL,
	[Biography] [varchar](max) NULL,
 CONSTRAINT [PK_FilmMember] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_AwardWinnerInfo]    Script Date: 3/29/2020 4:43:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_AwardWinnerInfo] AS
SELECT
	Award.Id as AwardId,
	Award.AwardName, 
	AwardShow.Id as AwardShowId,
	AwardShow.ShowName,
	AwardShowInstance.Year,
	AwardWinner.MovieId,
	Movie.Title,
	FilmMember.Id as FilmMemberId,
	FilmMember.PreferredFullName,
	AwardShowInstance.DateHosted
FROM AwardWinner 
INNER JOIN AwardShowInstance ON AwardShowInstance.Id = AwardWinner.AwardShowInstanceId
INNER JOIN Award ON Award.Id = AwardWinner.AwardId
INNER JOIN FilmMember ON FilmMember.Id = AwardWinner.FilmMemberId
INNER JOIN Movie ON Movie.Id = AwardWinner.MovieId
INNER JOIN AwardShow ON AwardShow.Id = Award.AwardShowId
GO
/****** Object:  Table [dbo].[FilmRole]    Script Date: 3/29/2020 4:43:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmRole](
	[Id] [smallint] NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_FilmRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 3/29/2020 4:43:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[Id] [smallint] NOT NULL,
	[GenreName] [varchar](25) NOT NULL,
	[Description] [varchar](500) NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageType]    Script Date: 3/29/2020 4:43:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageType](
	[Id] [int] NOT NULL,
	[ImageExtension] [varchar](10) NOT NULL,
	[Name] [varchar](25) NOT NULL,
 CONSTRAINT [PK_ImageType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Language]    Script Date: 3/29/2020 4:43:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Language](
	[LanguageIsoCode] [char](2) NOT NULL,
	[LanguageName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[LanguageIsoCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_Genre]    Script Date: 3/29/2020 4:43:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_Genre](
	[MovieId] [bigint] NOT NULL,
	[GenreId] [smallint] NOT NULL,
 CONSTRAINT [PK_Movie_Genre] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_Language]    Script Date: 3/29/2020 4:43:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_Language](
	[MovieId] [bigint] NOT NULL,
	[LanguageIsoCode] [char](2) NOT NULL,
 CONSTRAINT [PK_Movie_Language] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[LanguageIsoCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieCastMember]    Script Date: 3/29/2020 4:43:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieCastMember](
	[MovieId] [bigint] NOT NULL,
	[ActorFilmMemberId] [bigint] NOT NULL,
	[CharacterName] [varchar](150) NULL,
	[Sequence] [int] NULL,
 CONSTRAINT [PK_MovieCastMember] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[ActorFilmMemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieCrewMember]    Script Date: 3/29/2020 4:43:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieCrewMember](
	[MovieId] [bigint] NOT NULL,
	[FilmMemberId] [bigint] NOT NULL,
	[FilmRoleId] [smallint] NOT NULL,
 CONSTRAINT [PK_MovieCrewMember] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[FilmMemberId] ASC,
	[FilmRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieImage]    Script Date: 3/29/2020 4:43:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieImage](
	[Id] [bigint] NOT NULL,
	[MovieId] [bigint] NOT NULL,
	[ImageName] [varchar](100) NOT NULL,
	[ImageTypeId] [int] NOT NULL,
	[Description] [varchar](500) NULL,
	[FileContents] [varbinary](max) NOT NULL,
	[DateUploaded] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_MovieImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieUserReview]    Script Date: 3/29/2020 4:43:33 AM ******/
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
/****** Object:  Table [dbo].[MovieUserReviewHelpful]    Script Date: 3/29/2020 4:43:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieUserReviewHelpful](
	[MovieUserReviewId] [bigint] NOT NULL,
	[UserId] [int] NOT NULL,
	[IsHelpful] [bit] NOT NULL,
 CONSTRAINT [PK_MovieUserReviewHelpful] PRIMARY KEY CLUSTERED 
(
	[MovieUserReviewId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RestrictionRating]    Script Date: 3/29/2020 4:43:33 AM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 3/29/2020 4:43:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserRoleId] [smallint] NOT NULL,
	[UserName] [varchar](25) NOT NULL,
	[EmailAddress] [varchar](255) NOT NULL,
	[HashedPassword] [varchar](60) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 3/29/2020 4:43:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [smallint] NOT NULL,
	[RoleName] [varchar](25) NOT NULL,
	[Description] [varchar](500) NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Award_AwardShowId_AwardName]    Script Date: 3/29/2020 4:43:33 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Award_AwardShowId_AwardName] ON [dbo].[Award]
(
	[AwardShowId] ASC,
	[AwardName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_AwardShow_ShowName]    Script Date: 3/29/2020 4:43:33 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_AwardShow_ShowName] ON [dbo].[AwardShow]
(
	[ShowName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_AwardShowInstance_AwardShowId_Year]    Script Date: 3/29/2020 4:43:33 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_AwardShowInstance_AwardShowId_Year] ON [dbo].[AwardShowInstance]
(
	[AwardShowId] ASC,
	[Year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_FilmMember_PreferredFullName]    Script Date: 3/29/2020 4:43:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_FilmMember_PreferredFullName] ON [dbo].[FilmMember]
(
	[PreferredFullName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_FilmRole_RoleName]    Script Date: 3/29/2020 4:43:33 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_FilmRole_RoleName] ON [dbo].[FilmRole]
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_Genre_GenreName]    Script Date: 3/29/2020 4:43:33 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Genre_GenreName] ON [dbo].[Genre]
(
	[GenreName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Movie_Title]    Script Date: 3/29/2020 4:43:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_Movie_Title] ON [dbo].[Movie]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_MovieImage_MovieId_ImageName]    Script Date: 3/29/2020 4:43:33 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_MovieImage_MovieId_ImageName] ON [dbo].[MovieImage]
(
	[MovieId] ASC,
	[ImageName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UX_MovieUserReview_MovieId_UserId]    Script Date: 3/29/2020 4:43:33 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_MovieUserReview_MovieId_UserId] ON [dbo].[MovieUserReview]
(
	[MovieId] ASC,
	[UserId] ASC
)
INCLUDE ( 	[Rating]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_RestrictionRating_Code]    Script Date: 3/29/2020 4:43:33 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_RestrictionRating_Code] ON [dbo].[RestrictionRating]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_User_UserName]    Script Date: 3/29/2020 4:43:33 AM ******/
CREATE NONCLUSTERED INDEX [UX_User_UserName] ON [dbo].[User]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_UserRole_RoleName]    Script Date: 3/29/2020 4:43:33 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_UserRole_RoleName] ON [dbo].[UserRole]
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Award]  WITH CHECK ADD  CONSTRAINT [FK_Award_AwardShow] FOREIGN KEY([AwardShowId])
REFERENCES [dbo].[AwardShow] ([Id])
GO
ALTER TABLE [dbo].[Award] CHECK CONSTRAINT [FK_Award_AwardShow]
GO
ALTER TABLE [dbo].[AwardShowInstance]  WITH CHECK ADD  CONSTRAINT [FK_AwardShowInstance_AwardShow] FOREIGN KEY([AwardShowId])
REFERENCES [dbo].[AwardShow] ([Id])
GO
ALTER TABLE [dbo].[AwardShowInstance] CHECK CONSTRAINT [FK_AwardShowInstance_AwardShow]
GO
ALTER TABLE [dbo].[AwardWinner]  WITH CHECK ADD  CONSTRAINT [FK_AwardWinner_Award] FOREIGN KEY([AwardId])
REFERENCES [dbo].[Award] ([Id])
GO
ALTER TABLE [dbo].[AwardWinner] CHECK CONSTRAINT [FK_AwardWinner_Award]
GO
ALTER TABLE [dbo].[AwardWinner]  WITH CHECK ADD  CONSTRAINT [FK_AwardWinner_FilmMember] FOREIGN KEY([FilmMemberId])
REFERENCES [dbo].[FilmMember] ([Id])
GO
ALTER TABLE [dbo].[AwardWinner] CHECK CONSTRAINT [FK_AwardWinner_FilmMember]
GO
ALTER TABLE [dbo].[AwardWinner]  WITH CHECK ADD  CONSTRAINT [FK_AwardWinner_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[AwardWinner] CHECK CONSTRAINT [FK_AwardWinner_Movie]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_RestrictionRating] FOREIGN KEY([RestrictionRatingId])
REFERENCES [dbo].[RestrictionRating] ([Id])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_RestrictionRating]
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
ALTER TABLE [dbo].[Movie_Language]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Language_Language] FOREIGN KEY([LanguageIsoCode])
REFERENCES [dbo].[Language] ([LanguageIsoCode])
GO
ALTER TABLE [dbo].[Movie_Language] CHECK CONSTRAINT [FK_Movie_Language_Language]
GO
ALTER TABLE [dbo].[Movie_Language]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Language_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[Movie_Language] CHECK CONSTRAINT [FK_Movie_Language_Movie]
GO
ALTER TABLE [dbo].[MovieCastMember]  WITH CHECK ADD  CONSTRAINT [FK_MovieCastMember_FilmMember] FOREIGN KEY([ActorFilmMemberId])
REFERENCES [dbo].[FilmMember] ([Id])
GO
ALTER TABLE [dbo].[MovieCastMember] CHECK CONSTRAINT [FK_MovieCastMember_FilmMember]
GO
ALTER TABLE [dbo].[MovieCastMember]  WITH CHECK ADD  CONSTRAINT [FK_MovieCastMember_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[MovieCastMember] CHECK CONSTRAINT [FK_MovieCastMember_Movie]
GO
ALTER TABLE [dbo].[MovieCrewMember]  WITH CHECK ADD  CONSTRAINT [FK_MovieCrewMember_FilmMember] FOREIGN KEY([FilmMemberId])
REFERENCES [dbo].[FilmMember] ([Id])
GO
ALTER TABLE [dbo].[MovieCrewMember] CHECK CONSTRAINT [FK_MovieCrewMember_FilmMember]
GO
ALTER TABLE [dbo].[MovieCrewMember]  WITH CHECK ADD  CONSTRAINT [FK_MovieCrewMember_FilmRole] FOREIGN KEY([FilmRoleId])
REFERENCES [dbo].[FilmRole] ([Id])
GO
ALTER TABLE [dbo].[MovieCrewMember] CHECK CONSTRAINT [FK_MovieCrewMember_FilmRole]
GO
ALTER TABLE [dbo].[MovieCrewMember]  WITH CHECK ADD  CONSTRAINT [FK_MovieCrewMember_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[MovieCrewMember] CHECK CONSTRAINT [FK_MovieCrewMember_Movie]
GO
ALTER TABLE [dbo].[MovieImage]  WITH CHECK ADD  CONSTRAINT [FK_MovieImage_ImageType] FOREIGN KEY([ImageTypeId])
REFERENCES [dbo].[ImageType] ([Id])
GO
ALTER TABLE [dbo].[MovieImage] CHECK CONSTRAINT [FK_MovieImage_ImageType]
GO
ALTER TABLE [dbo].[MovieImage]  WITH CHECK ADD  CONSTRAINT [FK_MovieImage_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[MovieImage] CHECK CONSTRAINT [FK_MovieImage_Movie]
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
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserRole] FOREIGN KEY([UserRoleId])
REFERENCES [dbo].[UserRole] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserRole]
GO
