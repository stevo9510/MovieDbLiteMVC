using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class MovieCastMember
    {
        [Key]
        public long MovieId { get; set; }
        [Key]
        public long ActorFilmMemberId { get; set; }
        [StringLength(150)]
        public string CharacterName { get; set; } = default!;
        public int? Sequence { get; set; }

        [ForeignKey(nameof(ActorFilmMemberId))]
        [InverseProperty(nameof(FilmMember.MovieCastMember))]
        public FilmMember? ActorFilmMember { get; set; }
        [ForeignKey(nameof(MovieId))]
        [InverseProperty("MovieCastMember")]
        public Movie? Movie { get; set; }
    }
}
