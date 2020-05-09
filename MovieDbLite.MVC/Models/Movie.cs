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
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ReleaseDate { get; set; }
        public short? RestrictionRatingId { get; set; }
        public long? DirectorFilmMemberId { get; set; }
        public int? DurationInMinutes { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? AverageUserRating { get; set; }

        [ForeignKey(nameof(DirectorFilmMemberId))]
        [InverseProperty(nameof(FilmMember.DirectorMovies))]
        public virtual FilmMember DirectorFilmMember { get; set; }
        [ForeignKey(nameof(RestrictionRatingId))]
        [InverseProperty("Movie")]
        public virtual RestrictionRating RestrictionRating { get; set; }
        [InverseProperty("Movie")]
        public virtual ICollection<AwardWinner> AwardWinner { get; set; }
        [InverseProperty("Movie")]
        public virtual ICollection<MovieCastMember> MovieCastMember { get; set; }
        [InverseProperty("Movie")]
        public virtual ICollection<MovieCrewMember> MovieCrewMember { get; set; }
        [InverseProperty("Movie")]
        public virtual ICollection<MovieGenre> MovieGenre { get; set; }
        [InverseProperty("Movie")]
        public virtual ICollection<MovieImage> MovieImage { get; set; }
        [InverseProperty("Movie")]
        public virtual ICollection<MovieLanguage> MovieLanguage { get; set; }
        [InverseProperty("Movie")]
        public virtual ICollection<MovieUserReview> MovieUserReview { get; set; }
    }
}
