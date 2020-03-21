using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieDbLite.MVC.Models
{
    public partial class FilmMember
    {
        public FilmMember()
        {
            FilmMemberAward = new HashSet<FilmMemberAward>();
            MovieActor = new HashSet<MovieActor>();
            MovieFilmMember = new HashSet<MovieFilmMember>();
        }

        public long Id { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string PreferredFullName { get; set; }
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfDeath { get; set; }

        public string Biography { get; set; }

        public virtual ICollection<FilmMemberAward> FilmMemberAward { get; set; }
        public virtual ICollection<MovieActor> MovieActor { get; set; }
        public virtual ICollection<MovieFilmMember> MovieFilmMember { get; set; }
    }
}
