using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class MovieUserReview
    {
        public MovieUserReview()
        {
            MovieUserReviewHelpful = new HashSet<MovieUserReviewHelpful>();
        }

        [Key]
        public long Id { get; set; }
        public long MovieId { get; set; }
        public int UserId { get; set; }
        public short Rating { get; set; }
        [StringLength(8000)]
        public string Review { get; set; }
        public DateTime DatePosted { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("MovieUserReview")]
        public virtual Movie Movie { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("MovieUserReview")]
        public virtual User User { get; set; }
        [InverseProperty("MovieUserReview")]
        public virtual ICollection<MovieUserReviewHelpful> MovieUserReviewHelpful { get; set; }
    }
}
