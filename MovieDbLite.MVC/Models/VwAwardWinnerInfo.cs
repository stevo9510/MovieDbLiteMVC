using System;
using System.ComponentModel.DataAnnotations;

namespace MovieDbLite.MVC.Models
{
    public partial class VwAwardWinnerInfo
    {
        public int AwardId { get; set; }
        [Display(Name = "Award")]
        public string AwardName { get; set; }
        public short AwardShowId { get; set; }
        [Display(Name = "Show")]
        public string ShowName { get; set; }
        [Display(Name = "Year")]
        public short Year { get; set; }
        public long MovieId { get; set; }
        [Display(Name = "Movie")]
        public string Title { get; set; }
        public long FilmMemberId { get; set; }
        [Display(Name = "Name")]
        public string PreferredFullName { get; set; }
        [Display(Name = "Award Date"), DataType(DataType.Date)]
        public DateTime DateHosted { get; set; }
    }
}
