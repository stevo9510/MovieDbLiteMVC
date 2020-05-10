using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbLite.MVC.Models
{
    public partial class AwardShow
    {
        public AwardShow()
        {
            Award = new HashSet<Award>();
            AwardShowInstance = new HashSet<AwardShowInstance>();
        }

        [Key]
        public short Id { get; set; }
        [StringLength(50)]
        public string ShowName { get; set; } = default!;
        [StringLength(200)]
        public string? Description { get; set; }

        [InverseProperty("AwardShow")]
        public virtual ICollection<Award> Award { get; set; }
        [InverseProperty("AwardShow")]
        public virtual ICollection<AwardShowInstance> AwardShowInstance { get; set; }
    }
}
