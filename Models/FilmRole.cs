using System.Collections.Generic;

namespace MovieDbLite.MVC.Models
{
    public partial class FilmRole
    {
        public FilmRole()
        {
            MovieCrewMember = new HashSet<MovieCrewMember>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MovieCrewMember> MovieCrewMember { get; set; }
    }
}
