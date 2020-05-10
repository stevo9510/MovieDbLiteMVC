using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class RestrictionRating
    {
        public RestrictionRating()
        {
            Movie = new HashSet<Movie>();
        }

        [Key]
        public short Id { get; set; }
        [StringLength(10)]
        public string Code { get; set; } = default!;
        [StringLength(50)]
        public string ShortDescription { get; set; } = default!;
        [StringLength(200)]
        public string LongDescription { get; set; } = default!;
        public bool IsActive { get; set; }

        [InverseProperty("RestrictionRating")]
        public virtual ICollection<Movie> Movie { get; set; }
    }
}
