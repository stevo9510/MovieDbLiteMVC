using System;
using System.Collections.Generic;

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

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public short? RestrictionRatingId { get; set; }
        public long? DirectorFilmMemberId { get; set; }
        public int? DurationInMinutes { get; set; }
        public decimal? AverageUserRating { get; set; }

        public virtual RestrictionRating RestrictionRating { get; set; }
        public virtual ICollection<AwardWinner> AwardWinner { get; set; }
        public virtual ICollection<MovieCastMember> MovieCastMember { get; set; }
        public virtual ICollection<MovieCrewMember> MovieCrewMember { get; set; }
        public virtual ICollection<MovieGenre> MovieGenre { get; set; }
        public virtual ICollection<MovieImage> MovieImage { get; set; }
        public virtual ICollection<MovieLanguage> MovieLanguage { get; set; }
        public virtual ICollection<MovieUserReview> MovieUserReview { get; set; }
    }
}
