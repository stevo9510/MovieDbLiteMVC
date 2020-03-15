using System;
using System.Collections.Generic;

namespace MovieDbLite.Models
{
    public partial class MovieUserReview
    {
        public MovieUserReview()
        {
            MovieUserReviewHelpful = new HashSet<MovieUserReviewHelpful>();
        }

        public long Id { get; set; }
        public long MovieId { get; set; }
        public int UserId { get; set; }
        public short Rating { get; set; }
        public string Review { get; set; }
        public DateTime DatePosted { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<MovieUserReviewHelpful> MovieUserReviewHelpful { get; set; }
    }
}
