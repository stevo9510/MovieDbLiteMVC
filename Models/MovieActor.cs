namespace MovieDbLite.Models
{
    public partial class MovieActor
    {
        public long MovieId { get; set; }
        public long ActorFilmMemberId { get; set; }
        public string RoleName { get; set; }
        public int? Sequence { get; set; }

        public virtual FilmMember ActorFilmMember { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
