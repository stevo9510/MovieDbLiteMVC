using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class VwAwardWinnerInfo
    {
        public int AwardId { get; set; }
        [StringLength(50)]
        public string AwardName { get; set; } = default!;
        public short AwardShowId { get; set; }
        [StringLength(50)]
        public string ShowName { get; set; } = default!;
        public short Year { get; set; }
        public long MovieId { get; set; }
        [StringLength(150)]
        public string Title { get; set; } = default!;
        public long FilmMemberId { get; set; }
        [StringLength(150)]
        public string PreferredFullName { get; set; } = default!;
        [Column(TypeName = "date")]
        public DateTime DateHosted { get; set; }
    }
}
