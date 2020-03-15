using System.Collections.Generic;

namespace MovieDbLite.MVC.Models
{
    public partial class FilmRole
    {
        public FilmRole()
        {
            MovieFilmMember = new HashSet<MovieFilmMember>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MovieFilmMember> MovieFilmMember { get; set; }
    }
}
