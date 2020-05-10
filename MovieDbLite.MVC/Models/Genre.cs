using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class Genre
    {
        public Genre()
        {
            MovieGenre = new HashSet<MovieGenre>();
        }

        [Key]
        public short Id { get; set; }
        [StringLength(25)]
        [Display(Name = "Genre")]
        public string GenreName { get; set; } = default!;
        [StringLength(500)]
        public string? Description { get; set; }

        [InverseProperty("Genre")]
        public virtual ICollection<MovieGenre> MovieGenre { get; set; }
    }
}
