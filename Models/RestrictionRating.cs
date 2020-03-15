using System.Collections.Generic;

namespace MovieDbLite.MVC.Models
{
    public partial class RestrictionRating
    {
        public RestrictionRating()
        {
            Movie = new HashSet<Movie>();
        }

        public short Id { get; set; }
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
