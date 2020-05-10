using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieDbLite.MVC.Models
{
    public class MovieDetailsViewModel
    {
        public MovieDetailsViewModel()
        {
            MovieCastMembers = new List<MovieCastMemberDetail>();
            MovieCrewMembers = new List<MovieCrewMemberDetail>();
            AwardDetails = new List<AwardInfo>();
        }

        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        [Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        public string? RestrictionRating { get; set; }
        public long? DirectorFilmMemberId { get; set; }
        public string? DirectorName { get; set; }
        public string? Duration { get; set; }
        public decimal? AverageUserRating { get; set; }
        public string Languages { get; set; } = default!;
        public string Genres { get; set; } = default!;
        public int NumberOfUserRatings { get; set; }
        public MovieImage? Image { get; set; }

        public List<MovieCastMemberDetail> MovieCastMembers { get; set; }
        public List<MovieCrewMemberDetail> MovieCrewMembers { get; set; }
        public List<AwardInfo> AwardDetails { get; set; }
    }

    public class MovieCastMemberDetail
    {
        public long FilmMemberId { get; set; }
        public string Name { get; set; } = default!;
        [Display(Name = "Character")]
        public string CharacterName { get; set; } = default!;
        public int? Sequence { get; set; }
    }

    public class MovieCrewMemberDetail
    {
        public long FilmMemberId { get; set; }
        public string Name { get; set; } = default!;
        [Display(Name = "Role Name")]
        public string RoleName { get; set; } = default!;
    }

    public class AwardInfo
    {
        public int AwardId { get; set; }

        [Display(Name = "Award")]
        public string AwardName { get; set; } = default!;
        [Display(Name = "Award Show")]
        public string ShowName { get; set; } = default!;
        public short Year { get; set; }
        [Display(Name = "Winner")]
        public string PreferredFullName { get; set; } = default!;
    }
}
