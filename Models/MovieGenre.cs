namespace MovieDbLite.Models
{
    public partial class MovieGenre
    {
        public long MovieId { get; set; }
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
