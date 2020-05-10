using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            User = new HashSet<User>();
        }

        [Key]
        public short Id { get; set; }
        [StringLength(25)]
        public string RoleName { get; set; } = default!;
        [StringLength(500)]
        public string Description { get; set; } = default!;

        [InverseProperty("UserRole")]
        public virtual ICollection<User> User { get; set; }
    }
}
