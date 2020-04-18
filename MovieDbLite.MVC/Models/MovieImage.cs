using System;
using System.ComponentModel.DataAnnotations;

namespace MovieDbLite.MVC.Models
{
    public partial class MovieImage
    {
        public long Id { get; set; }
        [Display(Name = "Movie")]
        public long MovieId { get; set; }
        [Display(Name = "Image Name")]
        public string ImageName { get; set; }
        public short ImageTypeId { get; set; }
        public string Description { get; set; }
        public byte[] FileContents { get; set; }
        [Display(Name = "Date Uploaded")]
        public DateTime DateUploaded { get; set; }

        [Display(Name = "Image Type")]
        public virtual ImageType ImageType { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
