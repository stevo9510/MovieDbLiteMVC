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
        public Award? Award { get; set; }
        [ForeignKey(nameof(AwardShowInstanceId))]
        [InverseProperty("AwardWinner")]
        public AwardShowInstance? AwardShowInstance { get; set; }
        [ForeignKey(nameof(FilmMemberId))]
        [InverseProperty("AwardWinner")]
        public FilmMember? FilmMember { get; set; }
        [ForeignKey(nameof(MovieId))]
        [InverseProperty("AwardWinner")]
        public Movie? Movie { get; set; }
    }
}
