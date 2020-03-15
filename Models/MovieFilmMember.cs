namespace MovieDbLite.MVC.Models
{
    public partial class MovieFilmMember
    {
        public long MovieId { get; set; }
        public long FilmMemberId { get; set; }
        public int FilmRoleId { get; set; }

        public virtual FilmMember FilmMember { get; set; }
        public virtual FilmRole FilmRole { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
