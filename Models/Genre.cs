using System.Collections.Generic;

namespace MovieDbLite.Models
{
    public partial class Genre
    {
        public Genre()
        {
            MovieGenre = new HashSet<MovieGenre>();
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MovieGenre> MovieGenre { get; set; }
    }
}
