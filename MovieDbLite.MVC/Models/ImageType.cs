using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieDbLite.MVC.Models
{
    public partial class ImageType
    {
        public ImageType()
        {
            MovieImage = new HashSet<MovieImage>();
        }

        public short Id { get; set; }
        [Display(Name = "Image Type")]
        public string ImageExtension { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MovieImage> MovieImage { get; set; }
    }
}
