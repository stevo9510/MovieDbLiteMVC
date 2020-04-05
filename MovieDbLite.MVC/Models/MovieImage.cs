using System;

namespace MovieDbLite.MVC.Models
{
    public partial class MovieImage
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public string ImageName { get; set; }
        public short ImageTypeId { get; set; }
        public string Description { get; set; }
        public byte[] FileContents { get; set; }
        public DateTime DateUploaded { get; set; }

        public virtual ImageType ImageType { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
