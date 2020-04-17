using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieDbLite.MVC.Models
{
    public class MovieDetailsViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        public string RestrictionRating { get; set; }
        public string DirectorName { get; set; }
        public string Duration { get; set; }
        public decimal? AverageUserRating { get; set; }
        public string Languages { get; set; }
        public string Genres { get; set; }
        public byte[] Image { get; set; }

        public List<MovieCastMemberDetail> MovieCastMembers { get; set; }
        public List<MovieCrewMemberDetail> MovieCrewMembers { get; set; }
        public List<AwardInfo> AwardDetails { get; set; }
    }

    public class MovieCastMemberDetail
    {
        public long FilmMemberId { get; set; }
        public string Name { get; set; }
        public string CharacterName { get; set; }
        public int? Sequence { get; set; }
    }

    public class MovieCrewMemberDetail
    {
        public long FilmMemberId { get; set; }
        public string Name { get; set; }
        public string RoleName { get; set; }
    }

    public class AwardInfo
    {
        public string AwardName { get; set; }
        public string ShowName { get; set; }
        public short Year { get; set; }
        public string PreferredFullName { get; set; }
    }
}
