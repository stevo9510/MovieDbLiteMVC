using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    [Table("Movie_Language")]
    public partial class MovieLanguage
    {
        [Key]
        public long MovieId { get; set; }
        [Key]
        [StringLength(2)]
        public string LanguageIsoCode { get; set; }

        [ForeignKey(nameof(LanguageIsoCode))]
        [InverseProperty(nameof(Language.MovieLanguage))]
        public virtual Language LanguageIsoCodeNavigation { get; set; }
        [ForeignKey(nameof(MovieId))]
        [InverseProperty("MovieLanguage")]
        public virtual Movie Movie { get; set; }
    }
}
