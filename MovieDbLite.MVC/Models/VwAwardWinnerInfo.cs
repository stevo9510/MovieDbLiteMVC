using System;

namespace MovieDbLite.MVC.Models
{
    public partial class VwAwardWinnerInfo
    {
        public int AwardId { get; set; }
        public string AwardName { get; set; }
        public short AwardShowId { get; set; }
        public string ShowName { get; set; }
        public short Year { get; set; }
        public long MovieId { get; set; }
        public string Title { get; set; }
        public long FilmMemberId { get; set; }
        public string PreferredFullName { get; set; }
        public DateTime DateHosted { get; set; }
    }
}
