using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class Movie
    {
        public Movie()
        {
            AwardWinner = new HashSet<AwardWinner>();
            MovieCastMember = new HashSet<MovieCastMember>();
            MovieCrewMember = new HashSet<MovieCrewMember>();
            MovieGenre = new HashSet<MovieGenre>();
            MovieImage = new HashSet<MovieImage>();
            MovieLanguage = new HashSet<MovieLanguage>();
            MovieUserReview = new HashSet<MovieUserReview>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(150)]
        public string Title { get; set; } = default!;
        [StringLength(500)]
        public string Description { get; set; } = default!;
        [Column(TypeName = "date")]
        public DateTime? ReleaseDate { get; set; }
        public short? RestrictionRatingId { get; set; }
        public long? DirectorFilmMemberId { get; set; }
        public int? DurationInMinutes { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? AverageUserRating { get; set; }

        [ForeignKey(nameof(DirectorFilmMemberId))]
        [InverseProperty(nameof(FilmMember.DirectorMovies))]
        public FilmMember? DirectorFilmMember { get; set; }
        [ForeignKey(nameof(RestrictionRatingId))]
        [InverseProperty("Movie")]
        public RestrictionRating? RestrictionRating { get; set; }
        [InverseProperty("Movie")]
        public ICollection<AwardWinner> AwardWinner { get; set; }
        [InverseProperty("Movie")]
        public ICollection<MovieCastMember> MovieCastMember { get; set; }
        [InverseProperty("Movie")]
        public ICollection<MovieCrewMember> MovieCrewMember { get; set; }
        [InverseProperty("Movie")]
        public ICollection<MovieGenre> MovieGenre { get; set; }
        [InverseProperty("Movie")]
        public ICollection<MovieImage> MovieImage { get; set; }
        [InverseProperty("Movie")]
        public ICollection<MovieLanguage> MovieLanguage { get; set; }
        [InverseProperty("Movie")]
        public ICollection<MovieUserReview> MovieUserReview { get; set; }
    }
}
