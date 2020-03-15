namespace MovieDbLite.MVC.Models
{
    public partial class MovieUserReviewHelpful
    {
        public long MovieUserReviewId { get; set; }
        public int UserId { get; set; }
        public bool Helpful { get; set; }

        public virtual MovieUserReview MovieUserReview { get; set; }
        public virtual User User { get; set; }
    }
}
