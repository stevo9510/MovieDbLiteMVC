using System.Collections.Generic;

namespace MovieDbLite.MVC.Models
{
    public partial class Language
    {
        public Language()
        {
            MovieLanguage = new HashSet<MovieLanguage>();
        }

        public string LanguageIsoCode { get; set; }
        public string LanguageName { get; set; }

        public virtual ICollection<MovieLanguage> MovieLanguage { get; set; }
    }
}
