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
        public virtual DbSet<FilmMember> FilmMember { get; set; }
        public virtual DbSet<FilmMemberAward> FilmMemberAward { get; set; }
        public virtual DbSet<FilmRole> FilmRole { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieActor> MovieActor { get; set; }
        public virtual DbSet<MovieFilmMember> MovieFilmMember { get; set; }
        public virtual DbSet<MovieGenre> MovieGenre { get; set; }
        public virtual DbSet<MovieUserReview> MovieUserReview { get; set; }
        public virtual DbSet<MovieUserReviewHelpful> MovieUserReviewHelpful { get; set; }
        public virtual DbSet<RestrictionRating> RestrictionRating { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=MovieDbLite;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Award>(entity =>
            {
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
                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ShowName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FilmMember>(entity =>
            {
                entity.Property(e => e.Biography)
                    .IsUnicode(false);

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
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Suffix)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FilmMemberAward>(entity =>
            {
                entity.HasKey(e => new { e.FilmMemberId, e.AwardId, e.MovieId });

                entity.Property(e => e.DateReceived).HasColumnType("date");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Award)
                    .WithMany(p => p.FilmMemberAward)
                    .HasForeignKey(d => d.AwardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FilmMemberAward_Award");

                entity.HasOne(d => d.FilmMember)
                    .WithMany(p => p.FilmMemberAward)
                    .HasForeignKey(d => d.FilmMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FilmMemberAward_FilmMember");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.FilmMemberAward)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FilmMemberAward_Movie");
            });

            modelBuilder.Entity<FilmRole>(entity =>
            {
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
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.ReleaseDate).HasColumnType("date");
                
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_Movie_Language");

                entity.HasOne(d => d.RestrictionRating)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.RestrictionRatingId)
                    .HasConstraintName("FK_Movie_RestrictionRating");

                entity.Property(e => e.AverageUserRating)
                    .HasColumnType("decimal(5,2)");

            });

            modelBuilder.Entity<MovieActor>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.ActorFilmMemberId });

                entity.ToTable("MovieCastMember");

                entity.Property(e => e.RoleName)
                    .HasColumnName("CharacterName")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActorFilmMember)
                    .WithMany(p => p.MovieActor)
                    .HasForeignKey(d => d.ActorFilmMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieCastMember_FilmMember");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieActor)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieCastMember_Movie");
            });

            modelBuilder.Entity<MovieFilmMember>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.FilmMemberId, e.FilmRoleId });

                entity.ToTable("MovieCrewMember");

                entity.HasOne(d => d.FilmMember)
                    .WithMany(p => p.MovieFilmMember)
                    .HasForeignKey(d => d.FilmMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieCrewMember_FilmMember");

                entity.HasOne(d => d.FilmRole)
                    .WithMany(p => p.MovieFilmMember)
                    .HasForeignKey(d => d.FilmRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovieCrewMember_FilmRole");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieFilmMember)
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

            modelBuilder.Entity<MovieUserReview>(entity =>
            {
                entity.Property(e => e.DatePosted).HasColumnType("datetime");

                entity.Property(e => e.Review).HasColumnType("text");

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

                entity.Property(e => e.Helpful).HasColumnName("IsHelpful");

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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
