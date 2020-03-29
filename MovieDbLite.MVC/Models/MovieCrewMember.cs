namespace MovieDbLite.MVC.Models
{
    public partial class MovieCrewMember
    {
        public long MovieId { get; set; }
        public long FilmMemberId { get; set; }
        public short FilmRoleId { get; set; }

        public virtual FilmMember FilmMember { get; set; }
        public virtual FilmRole FilmRole { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
