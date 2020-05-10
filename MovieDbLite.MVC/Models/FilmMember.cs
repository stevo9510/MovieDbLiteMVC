using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Key]
        public long Id { get; set; }
        [StringLength(10)]
        public string? Prefix { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = default!;
        [StringLength(50)]
        public string? MiddleName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = default!;
        [StringLength(5)]
        public string? Suffix { get; set; }
        [StringLength(150)]
        public string PreferredFullName { get; set; } = default!;
        [StringLength(1)]
        public string Gender { get; set; } = default!;
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateOfDeath { get; set; }
        public string? Biography { get; set; }

        [InverseProperty("FilmMember")]
        public virtual ICollection<AwardWinner> AwardWinner { get; set; }
        [InverseProperty("DirectorFilmMember")]
        public virtual ICollection<Movie> DirectorMovies { get; set; }
        [InverseProperty("ActorFilmMember")]
        public virtual ICollection<MovieCastMember> MovieCastMember { get; set; }
        [InverseProperty("FilmMember")]
        public virtual ICollection<MovieCrewMember> MovieCrewMember { get; set; }
    }
}
