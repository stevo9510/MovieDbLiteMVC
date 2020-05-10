using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    [Table("Movie_Genre")]
    public partial class MovieGenre
    {
        [Key]
        public long MovieId { get; set; }
        [Key]
        public short GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        [InverseProperty("MovieGenre")]
        public virtual Genre? Genre { get; set; }
        [ForeignKey(nameof(MovieId))]
        [InverseProperty("MovieGenre")]
        public virtual Movie? Movie { get; set; }
    }
}
