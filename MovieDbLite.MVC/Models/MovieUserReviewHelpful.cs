using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class MovieUserReviewHelpful
    {
        [Key]
        public long MovieUserReviewId { get; set; }
        [Key]
        public int UserId { get; set; }
        public bool IsHelpful { get; set; }

        [ForeignKey(nameof(MovieUserReviewId))]
        [InverseProperty("MovieUserReviewHelpful")]
        public virtual MovieUserReview? MovieUserReview { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("MovieUserReviewHelpful")]
        public virtual User? User { get; set; }
    }
}
