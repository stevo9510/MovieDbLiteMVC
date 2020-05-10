using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class Language
    {
        public Language()
        {
            MovieLanguage = new HashSet<MovieLanguage>();
        }

        [Key]
        [StringLength(2)]
        public string LanguageIsoCode { get; set; } = default!;
        [StringLength(50)]
        public string LanguageName { get; set; } = default!;

        [InverseProperty("LanguageIsoCodeNavigation")]
        public virtual ICollection<MovieLanguage> MovieLanguage { get; set; }
    }
}
