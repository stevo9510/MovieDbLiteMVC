using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class User
    {
        public User()
        {
            MovieUserReview = new HashSet<MovieUserReview>();
            MovieUserReviewHelpful = new HashSet<MovieUserReviewHelpful>();
        }

        [Key]
        public int Id { get; set; }
        public short UserRoleId { get; set; }
        [Required]
        [StringLength(25)]
        public string UserName { get; set; } = default!;
        [Required]
        [StringLength(255)]
        public string EmailAddress { get; set; } = default!;
        [Required]
        [StringLength(60)]
        public string HashedPassword { get; set; } = default!;

        [ForeignKey(nameof(UserRoleId))]
        [InverseProperty("User")]
        public virtual UserRole? UserRole { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<MovieUserReview> MovieUserReview { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<MovieUserReviewHelpful> MovieUserReviewHelpful { get; set; }
    }
}
