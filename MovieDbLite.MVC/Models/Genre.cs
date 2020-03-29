using System.Collections.Generic;

namespace MovieDbLite.MVC.Models
{
    public partial class Genre
    {
        public Genre()
        {
            MovieGenre = new HashSet<MovieGenre>();
        }

        public short Id { get; set; }
        public string GenreName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MovieGenre> MovieGenre { get; set; }
    }
}
