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
        public string? Review { get; set; }
        public DateTime DatePosted { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("MovieUserReview")]
        public Movie? Movie { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("MovieUserReview")]
        public User? User { get; set; }
        [InverseProperty("MovieUserReview")]
        public ICollection<MovieUserReviewHelpful> MovieUserReviewHelpful { get; set; }
    }
}
