using System.ComponentModel.DataAnnotations;

namespace MovieDbLite.MVC.Models
{
    public partial class AwardWinner
    {
        [Display(Name = "Award Show Event")]
        public int AwardShowInstanceId { get; set; }
        [Display(Name = "Award")]
        public int AwardId { get; set; }
        [Display(Name = "Film Member")]
        public long FilmMemberId { get; set; }
        [Display(Name = "Movie")]
        public long MovieId { get; set; }

        public virtual Award Award { get; set; }
        public virtual AwardShowInstance AwardShowInstance { get; set; }
        public virtual FilmMember FilmMember { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
