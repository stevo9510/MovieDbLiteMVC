using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class VwAwardWinnerInfo
    {
        public int AwardId { get; set; }
        [Required]
        [StringLength(50)]
        public string AwardName { get; set; }
        public short AwardShowId { get; set; }
        [Required]
        [StringLength(50)]
        public string ShowName { get; set; }
        public short Year { get; set; }
        public long MovieId { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        public long FilmMemberId { get; set; }
        [Required]
        [StringLength(150)]
        public string PreferredFullName { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateHosted { get; set; }
    }
}
