using System.ComponentModel.DataAnnotations;

namespace MovieDbLite.MVC.ViewModels
{
    public class AwardBase
    {
        [Key]
        public int Id { get; set; }

        public short AwardShowId { get; set; }
        [StringLength(50)]
        [Display(Name = "Award")]
        public string AwardName { get; set; } = default!;
        [StringLength(200)]
        public string? Description { get; set; }

    }
}