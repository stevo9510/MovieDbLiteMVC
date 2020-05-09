using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class MovieImage
    {
        [Key]
        public long Id { get; set; }
        public long MovieId { get; set; }
        [Required]
        [StringLength(100)]
        public string ImageName { get; set; }
        public short ImageTypeId { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public byte[] FileContents { get; set; }
        public DateTime DateUploaded { get; set; }

        [ForeignKey(nameof(ImageTypeId))]
        [InverseProperty("MovieImage")]
        public virtual ImageType ImageType { get; set; }
        [ForeignKey(nameof(MovieId))]
        [InverseProperty("MovieImage")]
        public virtual Movie Movie { get; set; }
    }
}
