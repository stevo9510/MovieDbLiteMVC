namespace MovieDbLite.MVC.Models
{
    public partial class MovieGenre
    {
        public long MovieId { get; set; }
        public short GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
