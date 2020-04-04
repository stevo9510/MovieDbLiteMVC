namespace MovieDbLite.MVC.Models
{
    public partial class AwardWinner
    {
        public int AwardShowInstanceId { get; set; }
        public int AwardId { get; set; }
        public long FilmMemberId { get; set; }
        public long MovieId { get; set; }

        public virtual Award Award { get; set; }
        public virtual AwardShowInstance AwardShowInstance { get; set; }
        public virtual FilmMember FilmMember { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
