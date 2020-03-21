namespace MovieDbLite.MVC.Models
{
    public partial class MovieCastMember
    {
        public long MovieId { get; set; }
        public long ActorFilmMemberId { get; set; }
        public string CharacterName { get; set; }
        public int? Sequence { get; set; }

        public virtual FilmMember ActorFilmMember { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
