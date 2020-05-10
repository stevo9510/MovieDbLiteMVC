using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class AwardWinner
    {
        [Key]
        public int AwardShowInstanceId { get; set; }
        [Key]
        [Display(Name = "Award")]
        public int AwardId { get; set; }
        [Key]
        public long FilmMemberId { get; set; }
        public long MovieId { get; set; }

        [ForeignKey(nameof(AwardId))]
        [InverseProperty("AwardWinner")]
        public virtual Award Award { get; set; }
        [ForeignKey(nameof(AwardShowInstanceId))]
        [InverseProperty("AwardWinner")]
        public virtual AwardShowInstance AwardShowInstance { get; set; }
        [ForeignKey(nameof(FilmMemberId))]
        [InverseProperty("AwardWinner")]
        public virtual FilmMember FilmMember { get; set; }
        [ForeignKey(nameof(MovieId))]
        [InverseProperty("AwardWinner")]
        public virtual Movie Movie { get; set; }
    }
}
