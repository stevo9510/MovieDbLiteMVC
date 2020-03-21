﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieDbLite.MVC.Models;

namespace MovieDbLiteMvc.Migrations
{
    [DbContext(typeof(MovieDbLiteContext))]
    partial class MovieDbLiteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieDbLite.MVC.Models.Award", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AwardName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("AwardShowId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("AwardShowId", "AwardName")
                        .IsUnique()
                        .HasName("UX_Award_AwardShowId_AwardName");

                    b.ToTable("Award");
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.AwardShow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("ShowName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("ShowName")
                        .IsUnique()
                        .HasName("UX_AwardShow_ShowName");

                    b.ToTable("AwardShow");
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.AwardShowInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwardShowId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateHosted")
                        .HasColumnType("date");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("char(4)")
                        .IsFixedLength(true)
                        .HasMaxLength(4)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("AwardShowId", "Year")
                        .IsUnique()
                        .HasName("UX_AwardShowInstance_AwardShowId_Year");

                    b.ToTable("AwardShowInstance");
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.AwardWinner", b =>
                {
                    b.Property<int>("AwardShowInstanceId")
                        .HasColumnType("int");

                    b.Property<int>("AwardId")
                        .HasColumnType("int");

                    b.Property<long>("FilmMemberId")
                        .HasColumnType("bigint");

                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.HasKey("AwardShowInstanceId", "AwardId", "FilmMemberId");

                    b.HasIndex("AwardId");

                    b.HasIndex("FilmMemberId");

                    b.HasIndex("MovieId");

                    b.ToTable("AwardWinner");
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.FilmMember", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateOfDeath")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("char(1)")
                        .IsFixedLength(true)
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("MiddleName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("PreferredFullName")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("Prefix")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<string>("Suffix")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("PreferredFullName");

                    b.ToTable("FilmMember");
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.FilmRole", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("RoleName")
                        .IsUnique()
                        .HasName("UX_FilmRole_RoleName");

                    b.ToTable("FilmRole");
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("DisplayName")
                        .IsUnique()
                        .HasName("UX_Genre_DisplayName");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("UX_Language_Name");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("AverageUserRating")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<long>("DirectorFilmMemberId")
                        .HasColumnType("bigint");

                    b.Property<int?>("DurationInMinutes")
                        .HasColumnType("int");

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<short?>("RestrictionRatingId")
                        .HasColumnType("smallint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("RestrictionRatingId");

                    b.HasIndex("Title");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.MovieCastMember", b =>
                {
                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<long>("ActorFilmMemberId")
                        .HasColumnType("bigint");

                    b.Property<string>("CharacterName")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<int?>("Sequence")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "ActorFilmMemberId");

                    b.HasIndex("ActorFilmMemberId");

                    b.ToTable("MovieCastMember");
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.MovieCrewMember", b =>
                {
                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<long>("FilmMemberId")
                        .HasColumnType("bigint");

                    b.Property<int>("FilmRoleId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "FilmMemberId", "FilmRoleId");

                    b.HasIndex("FilmMemberId");

                    b.HasIndex("FilmRoleId");

                    b.ToTable("MovieCrewMember");
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.MovieGenre", b =>
                {
                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("Movie_Genre");
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.MovieUserReview", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime");

                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<short>("Rating")
                        .HasColumnType("smallint");

                    b.Property<string>("Review")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.HasIndex("Rating", "MovieId", "UserId")
                        .IsUnique()
                        .HasName("UX_MovieUserReview_MovieId_UserId");

                    b.ToTable("MovieUserReview");
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.MovieUserReviewHelpful", b =>
                {
                    b.Property<long>("MovieUserReviewId")
                        .HasColumnType("bigint");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsHelpful")
                        .HasColumnType("bit");

                    b.HasKey("MovieUserReviewId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("MovieUserReviewHelpful");
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.RestrictionRating", b =>
                {
                    b.Property<short>("Id")
                        .HasColumnType("smallint");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasName("UX_RestrictionRating_Code");

                    b.ToTable("RestrictionRating");
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60)
                        .IsUnicode(false);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .HasName("UX_User_UserName");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.Award", b =>
                {
                    b.HasOne("MovieDbLite.MVC.Models.AwardShow", "AwardShow")
                        .WithMany("Award")
                        .HasForeignKey("AwardShowId")
                        .HasConstraintName("FK_Award_AwardShow")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.AwardShowInstance", b =>
                {
                    b.HasOne("MovieDbLite.MVC.Models.AwardShow", "AwardShow")
                        .WithMany("AwardShowInstance")
                        .HasForeignKey("AwardShowId")
                        .HasConstraintName("FK_AwardShowInstance_AwardShow")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.AwardWinner", b =>
                {
                    b.HasOne("MovieDbLite.MVC.Models.Award", "Award")
                        .WithMany("AwardWinner")
                        .HasForeignKey("AwardId")
                        .HasConstraintName("FK_AwardWinner_Award")
                        .IsRequired();

                    b.HasOne("MovieDbLite.MVC.Models.FilmMember", "FilmMember")
                        .WithMany("AwardWinner")
                        .HasForeignKey("FilmMemberId")
                        .HasConstraintName("FK_AwardWinner_FilmMember")
                        .IsRequired();

                    b.HasOne("MovieDbLite.MVC.Models.Movie", "Movie")
                        .WithMany("AwardWinner")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_AwardWinner_Movie")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.Movie", b =>
                {
                    b.HasOne("MovieDbLite.MVC.Models.Language", "Language")
                        .WithMany("Movie")
                        .HasForeignKey("LanguageId")
                        .HasConstraintName("FK_Movie_Language");

                    b.HasOne("MovieDbLite.MVC.Models.RestrictionRating", "RestrictionRating")
                        .WithMany("Movie")
                        .HasForeignKey("RestrictionRatingId")
                        .HasConstraintName("FK_Movie_RestrictionRating");
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.MovieCastMember", b =>
                {
                    b.HasOne("MovieDbLite.MVC.Models.FilmMember", "ActorFilmMember")
                        .WithMany("MovieCastMember")
                        .HasForeignKey("ActorFilmMemberId")
                        .HasConstraintName("FK_MovieCastMember_FilmMember")
                        .IsRequired();

                    b.HasOne("MovieDbLite.MVC.Models.Movie", "Movie")
                        .WithMany("MovieCastMember")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_MovieCastMember_Movie")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.MovieCrewMember", b =>
                {
                    b.HasOne("MovieDbLite.MVC.Models.FilmMember", "FilmMember")
                        .WithMany("MovieCrewMember")
                        .HasForeignKey("FilmMemberId")
                        .HasConstraintName("FK_MovieCrewMember_FilmMember")
                        .IsRequired();

                    b.HasOne("MovieDbLite.MVC.Models.FilmRole", "FilmRole")
                        .WithMany("MovieCrewMember")
                        .HasForeignKey("FilmRoleId")
                        .HasConstraintName("FK_MovieCrewMember_FilmRole")
                        .IsRequired();

                    b.HasOne("MovieDbLite.MVC.Models.Movie", "Movie")
                        .WithMany("MovieCrewMember")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_MovieCrewMember_Movie")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.MovieGenre", b =>
                {
                    b.HasOne("MovieDbLite.MVC.Models.Genre", "Genre")
                        .WithMany("MovieGenre")
                        .HasForeignKey("GenreId")
                        .HasConstraintName("FK_Movie_Genre_Genre")
                        .IsRequired();

                    b.HasOne("MovieDbLite.MVC.Models.Movie", "Movie")
                        .WithMany("MovieGenre")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_Movie_Genre_Movie")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.MovieUserReview", b =>
                {
                    b.HasOne("MovieDbLite.MVC.Models.Movie", "Movie")
                        .WithMany("MovieUserReview")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_MovieUserReview_Movie")
                        .IsRequired();

                    b.HasOne("MovieDbLite.MVC.Models.User", "User")
                        .WithMany("MovieUserReview")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_MovieUserReview_User")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieDbLite.MVC.Models.MovieUserReviewHelpful", b =>
                {
                    b.HasOne("MovieDbLite.MVC.Models.MovieUserReview", "MovieUserReview")
                        .WithMany("MovieUserReviewHelpful")
                        .HasForeignKey("MovieUserReviewId")
                        .HasConstraintName("FK_MovieUserReviewHelpful_MovieUserReview")
                        .IsRequired();

                    b.HasOne("MovieDbLite.MVC.Models.User", "User")
                        .WithMany("MovieUserReviewHelpful")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_MovieUserReviewHelpful_User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
