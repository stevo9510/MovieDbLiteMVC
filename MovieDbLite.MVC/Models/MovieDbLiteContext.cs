using Microsoft.EntityFrameworkCore;

namespace MovieDbLite.MVC.Models
{
    public partial class MovieDbLiteContext : DbContext
    {
        public MovieDbLiteContext()
        {
        }

        public MovieDbLiteContext(DbContextOptions<MovieDbLiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Award> Award { get; set; }
        public virtual DbSet<AwardShow> AwardShow { get; set; }
        public virtual DbSet<AwardShowInstance> AwardShowInstance { get; set; }
        public virtual DbSet<AwardWinner> AwardWinner { get; set; }
        public virtual DbSet<FilmMember> FilmMember { get; set; }
        public virtual DbSet<FilmRole> FilmRole { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<ImageType> ImageType { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieCastMember> MovieCastMember { get; set; }
        public virtual DbSet<MovieCrewMember> MovieCrewMember { get; set; }
        public virtual DbSet<MovieGenre> MovieGenre { get; set; }
        public virtual DbSet<MovieImage> MovieImage { get; set; }
        public virtual DbSet<MovieLanguage> MovieLanguage { get; set; }
        public virtual DbSet<MovieUserReview> MovieUserReview { get; set; }
        public virtual DbSet<MovieUserReviewHelpful> MovieUserReviewHelpful { get; set; }
        public virtual DbSet<RestrictionRating> RestrictionRating { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<VwAwardWinnerInfo> VwAwardWinnerInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=MovieDbLite;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Award>(entity =>
            {
                entity.HasIndex(e => new { e.AwardShowId, e.AwardName })
                    .HasName("UX_Award_AwardShowId_AwardName")
                    .IsUnique();

                entity.Property(e => e.AwardName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.AwardShow)
                    .WithMany(p => p.Award)
                    .HasForeignKey(d => d.AwardShowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Award_AwardShow");
            });

            modelBuilder.Entity<AwardShow>(entity =>
            {
                entity.HasIndex(e => e.ShowName)
                    .HasName("UX_AwardShow_ShowName")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ShowName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AwardShowInstance>(entity =>
            {
                entity.HasIndex(e => new { e.AwardShowId, e.Year })
                    .HasName("UX_AwardShowInstance_AwardShowId_Year")
                    .IsUnique();

                entity.Property(e => e.DateHosted).HasColumnType("date");

                entity.HasOne(d => d.AwardShow)
                    .WithMany(p => p.AwardShowInstance)
                    .HasForeignKey(d => d.AwardShowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AwardShowInstance_AwardShow");
            });

            modelBuilder.Entity<AwardWinner>(entity =>
            {
                entity.HasKey(e => new { e.AwardShowInstanceId, e.AwardId, e.FilmMemberId });

                entity.HasOne(d => d.Award)
                    .WithMany(p => p.AwardWinner)
                    .HasForeignKey(d => d.AwardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AwardWinner_Award");

                entity.HasOne(d => d.AwardShowInstance)
                    .WithMany(p => p.AwardWinner)
                    .HasForeignKey(d => d.AwardShowInstanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AwardWinner_AwardShowInstanceId");

                entity.HasOne(d => d.FilmMember)
                    .WithMany(p => p.AwardWinner)
                    .HasForeignKey(d => d.FilmMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AwardWinner_FilmMember");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.AwardWinner)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AwardWinner_Movie");
            });

            modelBuilder.Entity<FilmMember>(entity =>
            {
                entity.HasIndex(e => e.PreferredFullName);

                entity.Property(e => e.Biography).IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DateOfDeath).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PreferredFullName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Prefix)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Suffix)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FilmRole>(entity =>
            {
                entity.HasIndex(e => e.RoleName)
                    .HasName("UX_FilmRole_RoleName")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasIndex(e => e.GenreName)
                    .HasName("UX_Genre_GenreName")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ImageType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ImageExtension)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.LanguageIsoCode);

                entity.Property(e => e.LanguageIsoCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasIndex(e => e.Title);

                entity.Property(e => e.AverageUserRating).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.DirectorFilmMember)
                    .WithMany(p => p.DirectorMovies)
                    .HasForeignKey(d => d.DirectorFilmMemberId)
                    .HasConstraintName("FK_Movie_DirectorFilmMember");

                entity.HasOne(d => d.RestrictionRating)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.RestrictionRatingId)
                    .HasConstraintName("FK_Movie_RestrictionRating");
            });

            modelBuilder.Entity<MovieCastMember>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.ActorFilmMemberId });

                entity.Property(e => e.CharacterName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActorFilmMember)
                    .WithMany(p => p.MovieCastMember)
                    .HasForeignKey(d => d.ActorFilmMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieCastMember_FilmMember");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieCastMember)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieCastMember_Movie");
            });

            modelBuilder.Entity<MovieCrewMember>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.FilmMemberId, e.FilmRoleId });

                entity.HasOne(d => d.FilmMember)
                    .WithMany(p => p.MovieCrewMember)
                    .HasForeignKey(d => d.FilmMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieCrewMember_FilmMember");

                entity.HasOne(d => d.FilmRole)
                    .WithMany(p => p.MovieCrewMember)
                    .HasForeignKey(d => d.FilmRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieCrewMember_FilmRole");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieCrewMember)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieCrewMember_Movie");
            });

            modelBuilder.Entity<MovieGenre>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.GenreId });

                entity.ToTable("Movie_Genre");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.MovieGenre)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movie_Genre_Genre");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieGenre)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movie_Genre_Movie");
            });

            modelBuilder.Entity<MovieImage>(entity =>
            {
                entity.HasIndex(e => new { e.MovieId, e.ImageName })
                    .HasName("UX_MovieImage_MovieId_ImageName")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FileContents).IsRequired();

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.ImageType)
                    .WithMany(p => p.MovieImage)
                    .HasForeignKey(d => d.ImageTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieImage_ImageType");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieImage)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieImage_Movie");
            });

            modelBuilder.Entity<MovieLanguage>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.LanguageIsoCode });

                entity.ToTable("Movie_Language");

                entity.Property(e => e.LanguageIsoCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.LanguageIsoCodeNavigation)
                    .WithMany(p => p.MovieLanguage)
                    .HasForeignKey(d => d.LanguageIsoCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movie_Language_Language");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieLanguage)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movie_Language_Movie");
            });

            modelBuilder.Entity<MovieUserReview>(entity =>
            {
                entity.HasIndex(e => new { e.Rating, e.MovieId, e.UserId })
                    .HasName("UX_MovieUserReview_MovieId_UserId")
                    .IsUnique();

                entity.Property(e => e.Review)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieUserReview)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieUserReview_Movie");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MovieUserReview)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieUserReview_User");
            });

            modelBuilder.Entity<MovieUserReviewHelpful>(entity =>
            {
                entity.HasKey(e => new { e.MovieUserReviewId, e.UserId });

                entity.HasOne(d => d.MovieUserReview)
                    .WithMany(p => p.MovieUserReviewHelpful)
                    .HasForeignKey(d => d.MovieUserReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieUserReviewHelpful_MovieUserReview");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MovieUserReviewHelpful)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieUserReviewHelpful_User");
            });

            modelBuilder.Entity<RestrictionRating>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .HasName("UX_RestrictionRating_Code")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LongDescription)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UX_User_UserName");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HashedPassword)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserRole");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasIndex(e => e.RoleName)
                    .HasName("UX_UserRole_RoleName")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwAwardWinnerInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_AwardWinnerInfo");

                entity.Property(e => e.AwardName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateHosted).HasColumnType("date");

                entity.Property(e => e.PreferredFullName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ShowName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
