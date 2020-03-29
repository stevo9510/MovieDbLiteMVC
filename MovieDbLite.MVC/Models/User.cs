using System.Collections.Generic;

namespace MovieDbLite.MVC.Models
{
    public partial class User
    {
        public User()
        {
            MovieUserReview = new HashSet<MovieUserReview>();
            MovieUserReviewHelpful = new HashSet<MovieUserReviewHelpful>();
        }

        public int Id { get; set; }
        public int UserRoleId { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string HashedPassword { get; set; }

        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<MovieUserReview> MovieUserReview { get; set; }
        public virtual ICollection<MovieUserReviewHelpful> MovieUserReviewHelpful { get; set; }
    }
}
