using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieDbLite.MVC.Models
{
    public partial class FilmMember
    {
        public FilmMember()
        {
            AwardWinner = new HashSet<AwardWinner>();
            DirectorMovies = new HashSet<Movie>();
            MovieCastMember = new HashSet<MovieCastMember>();
            MovieCrewMember = new HashSet<MovieCrewMember>();
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

        public virtual ICollection<AwardWinner> AwardWinner { get; set; }
        public virtual ICollection<Movie> DirectorMovies { get; set; }
        public virtual ICollection<MovieCastMember> MovieCastMember { get; set; }
        public virtual ICollection<MovieCrewMember> MovieCrewMember { get; set; }
    }
}
