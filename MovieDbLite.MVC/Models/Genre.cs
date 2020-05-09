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
        [Required]
        [StringLength(25)]
        public string GenreName { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        [InverseProperty("Genre")]
        public virtual ICollection<MovieGenre> MovieGenre { get; set; }
    }
}
