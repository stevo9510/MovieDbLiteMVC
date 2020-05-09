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
        [Required]
        [StringLength(150)]
        public string CharacterName { get; set; }
        public int? Sequence { get; set; }

        [ForeignKey(nameof(ActorFilmMemberId))]
        [InverseProperty(nameof(FilmMember.MovieCastMember))]
        public virtual FilmMember ActorFilmMember { get; set; }
        [ForeignKey(nameof(MovieId))]
        [InverseProperty("MovieCastMember")]
        public virtual Movie Movie { get; set; }
    }
}
