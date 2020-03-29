namespace MovieDbLite.MVC.Models
{
    public partial class MovieLanguage
    {
        public long MovieId { get; set; }
        public string LanguageIsoCode { get; set; }

        public virtual Language LanguageIsoCodeNavigation { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
