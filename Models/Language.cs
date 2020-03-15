using System.Collections.Generic;

namespace MovieDbLite.Models
{
    public partial class Language
    {
        public Language()
        {
            Movie = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
