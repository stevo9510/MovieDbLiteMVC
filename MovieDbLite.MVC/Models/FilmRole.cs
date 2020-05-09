using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class FilmRole
    {
        public FilmRole()
        {
            MovieCrewMember = new HashSet<MovieCrewMember>();
        }

        [Key]
        public short Id { get; set; }
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }
        [StringLength(200)]
        public string Description { get; set; }

        [InverseProperty("FilmRole")]
        public virtual ICollection<MovieCrewMember> MovieCrewMember { get; set; }
    }
}
