using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieDbLite.Models
{
    public partial class User
    {
        public User()
        {
            MovieUserReview = new HashSet<MovieUserReview>();
            MovieUserReviewHelpful = new HashSet<MovieUserReviewHelpful>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string HashedPassword { get; set; }

        public virtual ICollection<MovieUserReview> MovieUserReview { get; set; }
        public virtual ICollection<MovieUserReviewHelpful> MovieUserReviewHelpful { get; set; }
    }
}
