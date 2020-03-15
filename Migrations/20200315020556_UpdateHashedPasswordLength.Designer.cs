﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieDbLite.Models;

namespace MovieDbLiteMvc2.Migrations
{
    [DbContext(typeof(MovieDbLiteContext))]
    [Migration("20200315020556_UpdateHashedPasswordLength")]
    partial class UpdateHashedPasswordLength
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieDbLite.Models.Award", b =>
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

                    b.HasIndex("AwardShowId");

                    b.ToTable("Award");
                });

            modelBuilder.Entity("MovieDbLite.Models.AwardShow", b =>
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

                    b.ToTable("AwardShow");
                });

            modelBuilder.Entity("MovieDbLite.Models.FilmMember", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography")
                        .HasColumnType("text");

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

                    b.ToTable("FilmMember");
                });

            modelBuilder.Entity("MovieDbLite.Models.FilmMemberAward", b =>
                {
                    b.Property<long>("FilmMemberId")
                        .HasColumnType("bigint");

                    b.Property<int>("AwardId")
                        .HasColumnType("int");

                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateReceived")
                        .HasColumnType("date");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("char(4)")
                        .IsFixedLength(true)
                        .HasMaxLength(4)
                        .IsUnicode(false);

                    b.HasKey("FilmMemberId", "AwardId", "MovieId");

                    b.HasIndex("AwardId");

                    b.HasIndex("MovieId");

                    b.ToTable("FilmMemberAward");
                });

            modelBuilder.Entity("MovieDbLite.Models.FilmRole", b =>
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

                    b.ToTable("FilmRole");
                });

            modelBuilder.Entity("MovieDbLite.Models.Genre", b =>
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

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MovieDbLite.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("MovieDbLite.Models.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

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

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MovieDbLite.Models.MovieActor", b =>
                {
                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<long>("ActorFilmMemberId")
                        .HasColumnType("bigint");

                    b.Property<string>("RoleName")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<int?>("Sequence")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "ActorFilmMemberId");

                    b.HasIndex("ActorFilmMemberId");

                    b.ToTable("Movie_Actor");
                });

            modelBuilder.Entity("MovieDbLite.Models.MovieFilmMember", b =>
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

                    b.ToTable("MovieFilmMember");
                });

            modelBuilder.Entity("MovieDbLite.Models.MovieGenre", b =>
                {
                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("Movie_Genre");
                });

            modelBuilder.Entity("MovieDbLite.Models.MovieUserReview", b =>
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

                    b.ToTable("MovieUserReview");
                });

            modelBuilder.Entity("MovieDbLite.Models.MovieUserReviewHelpful", b =>
                {
                    b.Property<long>("MovieUserReviewId")
                        .HasColumnType("bigint");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("Helpful")
                        .HasColumnType("bit");

                    b.HasKey("MovieUserReviewId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("MovieUserReviewHelpful");
                });

            modelBuilder.Entity("MovieDbLite.Models.RestrictionRating", b =>
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

                    b.ToTable("RestrictionRating");
                });

            modelBuilder.Entity("MovieDbLite.Models.User", b =>
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

                    b.ToTable("User");
                });

            modelBuilder.Entity("MovieDbLite.Models.Award", b =>
                {
                    b.HasOne("MovieDbLite.Models.AwardShow", "AwardShow")
                        .WithMany("Award")
                        .HasForeignKey("AwardShowId")
                        .HasConstraintName("FK_Award_AwardShow")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieDbLite.Models.FilmMemberAward", b =>
                {
                    b.HasOne("MovieDbLite.Models.Award", "Award")
                        .WithMany("FilmMemberAward")
                        .HasForeignKey("AwardId")
                        .HasConstraintName("FK_FilmMemberAward_Award")
                        .IsRequired();

                    b.HasOne("MovieDbLite.Models.FilmMember", "FilmMember")
                        .WithMany("FilmMemberAward")
                        .HasForeignKey("FilmMemberId")
                        .HasConstraintName("FK_FilmMemberAward_FilmMember")
                        .IsRequired();

                    b.HasOne("MovieDbLite.Models.Movie", "Movie")
                        .WithMany("FilmMemberAward")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_FilmMemberAward_Movie")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieDbLite.Models.Movie", b =>
                {
                    b.HasOne("MovieDbLite.Models.Language", "Language")
                        .WithMany("Movie")
                        .HasForeignKey("LanguageId")
                        .HasConstraintName("FK_Movie_Language");

                    b.HasOne("MovieDbLite.Models.RestrictionRating", "RestrictionRating")
                        .WithMany("Movie")
                        .HasForeignKey("RestrictionRatingId")
                        .HasConstraintName("FK_Movie_RestrictionRating");
                });

            modelBuilder.Entity("MovieDbLite.Models.MovieActor", b =>
                {
                    b.HasOne("MovieDbLite.Models.FilmMember", "ActorFilmMember")
                        .WithMany("MovieActor")
                        .HasForeignKey("ActorFilmMemberId")
                        .HasConstraintName("FK_Movie_Actor_FilmMember")
                        .IsRequired();

                    b.HasOne("MovieDbLite.Models.Movie", "Movie")
                        .WithMany("MovieActor")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_Movie_Actor_Movie")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieDbLite.Models.MovieFilmMember", b =>
                {
                    b.HasOne("MovieDbLite.Models.FilmMember", "FilmMember")
                        .WithMany("MovieFilmMember")
                        .HasForeignKey("FilmMemberId")
                        .HasConstraintName("FK_MovieFilmMember_FilmMember")
                        .IsRequired();

                    b.HasOne("MovieDbLite.Models.FilmRole", "FilmRole")
                        .WithMany("MovieFilmMember")
                        .HasForeignKey("FilmRoleId")
                        .HasConstraintName("FK_MovieFilmMember_FilmRole")
                        .IsRequired();

                    b.HasOne("MovieDbLite.Models.Movie", "Movie")
                        .WithMany("MovieFilmMember")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_MovieFilmMember_Movie")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieDbLite.Models.MovieGenre", b =>
                {
                    b.HasOne("MovieDbLite.Models.Genre", "Genre")
                        .WithMany("MovieGenre")
                        .HasForeignKey("GenreId")
                        .HasConstraintName("FK_Movie_Genre_Genre")
                        .IsRequired();

                    b.HasOne("MovieDbLite.Models.Movie", "Movie")
                        .WithMany("MovieGenre")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_Movie_Genre_Movie")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieDbLite.Models.MovieUserReview", b =>
                {
                    b.HasOne("MovieDbLite.Models.Movie", "Movie")
                        .WithMany("MovieUserReview")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_MovieUserReview_Movie")
                        .IsRequired();

                    b.HasOne("MovieDbLite.Models.User", "User")
                        .WithMany("MovieUserReview")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_MovieUserReview_User")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieDbLite.Models.MovieUserReviewHelpful", b =>
                {
                    b.HasOne("MovieDbLite.Models.MovieUserReview", "MovieUserReview")
                        .WithMany("MovieUserReviewHelpful")
                        .HasForeignKey("MovieUserReviewId")
                        .HasConstraintName("FK_MovieUserReviewHelpful_MovieUserReview")
                        .IsRequired();

                    b.HasOne("MovieDbLite.Models.User", "User")
                        .WithMany("MovieUserReviewHelpful")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_MovieUserReviewHelpful_User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
