using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class ImageType
    {
        public ImageType()
        {
            MovieImage = new HashSet<MovieImage>();
        }

        [Key]
        public short Id { get; set; }
        [Required]
        [StringLength(10)]
        public string ImageExtension { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [InverseProperty("ImageType")]
        public virtual ICollection<MovieImage> MovieImage { get; set; }
    }
}
